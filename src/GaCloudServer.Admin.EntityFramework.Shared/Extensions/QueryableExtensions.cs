using GaCloudServer.Admin.EntityFramework.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }

        public static IQueryable<T> TakeIf<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> orderBy, bool condition, int limit, bool orderByDescending = true)
        {
            // It is necessary sort items before it
            query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

            return condition
                ? query.Take(limit)
                : query;
        }

        public static IQueryable<T> PageBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> orderBy, int page, int pageSize, bool orderByDescending = true)
        {
            const int defaultPageNumber = 1;

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            // Check if the page number is greater then zero - otherwise use default page number
            if (page <= 0)
            {
                page = defaultPageNumber;
            }

            // It is necessary sort items before it
            query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> FilterBy<T>(this IQueryable<T> source, GridOperationsModel gom)
        {
            Func<string, FilterModel, List<object>, string> getConditionFromModel =
            (string colName, FilterModel model, List<object> values) =>
            {
                string modelResult = "";

                switch (model.filterType)
                {
                    case "text":
                        switch (model.type)
                        {
                            case "equals":
                                modelResult = $"{colName} = \"{model.filter}\"";
                                break;
                            case "notEqual":
                                modelResult = $"{colName} = \"{model.filter}\"";
                                break;
                            case "contains":
                                modelResult = $"{colName}.Contains(@{values.Count})";
                                values.Add(model.filter);
                                break;
                            case "notContains":
                                modelResult = $"!{colName}.Contains(@{values.Count})";
                                values.Add(model.filter);
                                break;
                            case "startsWith":
                                modelResult = $"{colName}.StartsWith(@{values.Count})";
                                values.Add(model.filter);
                                break;
                            case "endsWith":
                                modelResult = $"!{colName}.StartsWith(@{values.Count})";
                                values.Add(model.filter);
                                break;
                        }
                        break;
                    case "number":
                        switch (model.type)
                        {
                            case "equals":
                                modelResult = $"{colName} = {model.filter}";
                                break;
                            case "notEqual":
                                modelResult = $"{colName} <> {model.filter}";
                                break;
                            case "lessThan":
                                modelResult = $"{colName} < {model.filter}";
                                break;
                            case "lessThanOrEqual":
                                modelResult = $"{colName} <= {model.filter}";
                                break;
                            case "greaterThan":
                                modelResult = $"{colName} > {model.filter}";
                                break;
                            case "greaterThanOrEqual":
                                modelResult = $"{colName} >= {model.filter}";
                                break;
                            case "inRange":
                                modelResult = $"({colName} >= {model.filter} and {colName} <= {model.filterTo})";
                                break;
                        }
                        break;
                    case "date":
                        values.Add(Convert.ToDateTime(model.dateFrom));

                        switch (model.type)
                        {
                            case "equals":
                                modelResult = $"{colName} = @{values.Count - 1}";
                                break;
                            case "notEqual":
                                modelResult = $"{colName} <> @{values.Count - 1}";
                                break;
                            case "lessThan":
                                modelResult = $"{colName} < @{values.Count - 1}";
                                break;
                            case "lessThanOrEqual":
                                modelResult = $"{colName} <= @{values.Count - 1}";
                                break;
                            case "greaterThan":
                                modelResult = $"{colName} > @{values.Count - 1}";
                                break;
                            case "greaterThanOrEqual":
                                modelResult = $"{colName} >= @{values.Count - 1}";
                                break;
                            case "inRange":
                                values.Add(Convert.ToDateTime(model.dateTo));
                                modelResult = $"{colName} >= @{values.Count - 2} and {colName} <= @{values.Count - 1}";
                                //modelResult = $"({colName} >= @{values.Count - 2} AND {colName} <= @{values.Count - 1})";
                                break;
                        }
                        break;
                }
                return modelResult;
            };

            foreach (var f in gom.filterModel)
            {
                string condition, tmp;
                List<object> conditionValues = new List<object>();

                if (!string.IsNullOrWhiteSpace(f.Value.Operator))
                {
                    tmp = getConditionFromModel(f.Key, f.Value.condition1, conditionValues);
                    condition = tmp;

                    tmp = getConditionFromModel(f.Key, f.Value.condition2, conditionValues);
                    condition = $"{condition} {f.Value.Operator.ToLower()} {tmp}";
                }
                else
                {
                    tmp = getConditionFromModel(f.Key, f.Value, conditionValues);
                    condition = tmp;
                }
                if (conditionValues.Count == 0) source = source.Where(condition);
                else source = source.Where(condition, conditionValues.ToArray());
            }

            //foreach (var s in gom.sortModel)
            //{
            //    switch (s.sort)
            //    {
            //        case "asc":
            //            source = source.OrderBy(s.colId);
            //            break;
            //        case "desc":
            //            source = source.OrderBy($"{s.colId} descending");
            //            break;
            //    };
            //};

            return source;
        }
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<SortModel> sortModels)
        {
            Expression expression = source.Expression;

            int count = 0;

            foreach (SortModel item in sortModels)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, item.colId);

                var method = string.Equals(item.sort, "desc", StringComparison.OrdinalIgnoreCase) ?
                    (count == 0 ? "OrderByDescending" : "ThenByDescending") :
                    (count == 0 ? "OrderBy" : "ThenBy");

                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));

                count++;
            }

            if (count > 0)
            {
                return source.Provider.CreateQuery<T>(expression);
            }
            else
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, "Id");
                var method = "OrderByDescending";
                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));

                return source.Provider.CreateQuery<T>(expression);
            }
        }

        public static IQueryable<T> QuickFilterBy<T>(this IQueryable<T> source, string filter)
        {
            try
            {
                var t = typeof(T);
                var properties = t.GetProperties().Where(x => x.PropertyType == typeof(string) || x.PropertyType == typeof(int) || x.PropertyType == typeof(long));
                var predicate = PredicateBuilder.False<T>();
                foreach (var prop in properties)
                {
                    var parameterExp = Expression.Parameter(typeof(T), "type");
                    var propertyExp = Expression.Property(parameterExp, prop.Name);
                    MethodInfo method = null;
                    ConstantExpression someValue = null;
                    if (prop.PropertyType == typeof(string))
                    {
                        try
                        {
                            method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                            someValue = Expression.Constant(filter, typeof(string));
                        }
                        catch (Exception ex) { }
                    }
                    else if (prop.PropertyType == typeof(int))
                    {
                        try
                        {
                            method = typeof(int).GetMethod("Equals", new[] { typeof(int) });
                            someValue = Expression.Constant(Convert.ToInt32(filter), typeof(int));
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else if (prop.PropertyType == typeof(long))
                    {
                        try
                        {
                            method = typeof(long).GetMethod("Equals", new[] { typeof(long) });
                            someValue = Expression.Constant(Convert.ToInt64(filter), typeof(long));
                        }
                        catch (Exception ex) { }
                    }

                    try
                    {
                        var containsMethodExp = Expression.Call(propertyExp, method, someValue);
                        var lambda = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);

                        predicate = predicate.Or(lambda);
                    }
                    catch (Exception ex)
                    { }

                }



                return source.Where(predicate);
            }
            catch (Exception ex)
            {
                return source;
            }
        }

        public static IQueryable<T> FilterByV2<T>(this IQueryable<T> source, GridOperationsModel gom)
        {
            try
            {
                var predicate = PredicateBuilder.True<T>();

                foreach (var f in gom.filterModel)
                {
                    if (!string.IsNullOrWhiteSpace(f.Value.Operator))
                    {
                        var lambda1 = CreateExpression<T>(f.Key, f.Value.condition1);
                        var lambda2 = CreateExpression<T>(f.Key, f.Value.condition2);

                        if (f.Value.Operator.ToLower() == "and")
                        {
                            //var lambda = AndAlso(lambda1, lambda2);
                            predicate = predicate.And<T>(lambda1);
                            predicate = predicate.And<T>(lambda2);
                        }
                        else
                        {
                            predicate = predicate.And<T>(lambda1);
                            predicate = predicate.Or<T>(lambda2);
                        }

                    }
                    else if (f.Value.type == "inRange")
                    {
                        FilterModel fm = new FilterModel();
                        var lambda1 = CreateExpression<T>(f.Key, f.Value);

                        predicate = predicate.And<T>(lambda1);

                    }
                    else
                    {
                        if (f.Value.filterType == "boolean" && f.Value.filter.Equals("All"))
                        {
                            continue;
                        }
                        else
                        {
                            var lambda = CreateExpression<T>(f.Key, f.Value);
                            predicate = predicate.And<T>(lambda);
                        }
                    }


                }

                return source.Where(predicate);
            }
            catch (Exception ex)
            {
                return source;
            }
        }

        private static Expression<Func<T, bool>> CreateExpression<T>(string colName, FilterModel model)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression property = Expression.Property(parameter, colName);
            Type propertyType = property.Type;
            Expression target;
            Expression targetTo;
            Expression targetNext;
            Expression targetPrev;


            Expression body;
            try
            {
                if (model.filterType == "number")
                {
                    target = Expression.Constant(ConvertTo(model.filter, propertyType));
                    targetTo = Expression.Constant(ConvertTo(model.filterTo, propertyType));

                    targetNext = null;
                    targetPrev = null;
                }
                else if (model.filterType == "date")
                {
                    //target = Expression.Constant(ConvertTo(model.dateFrom, propertyType));
                    //targetTo = Expression.Constant(ConvertTo(model.dateTo, propertyType));

                    //targetNext = Expression.Constant(((DateTime)ConvertTo(model.dateFrom, propertyType)).AddDays(1));
                    //targetPrev = Expression.Constant(((DateTime)ConvertTo(model.dateFrom, propertyType)).AddDays(-1));

                    if (model.type == "equals" || model.type == "notEqual")
                    {
                        target = Expression.Constant(ConvertToDateTime(model.dateFrom));
                        targetTo = Expression.Constant(ConvertToDateTime(model.dateFrom));

                        targetNext = Expression.Constant(MakeTargetNext(ConvertToDateTime(model.dateFrom)));
                        targetPrev = Expression.Constant(MakeTargetPrev(ConvertToDateTime(model.dateFrom)));
                    }
                    else
                    {
                        target = Expression.Constant(ConvertToDateTime(model.dateFrom));
                        targetTo = Expression.Constant(ConvertToDateTime(model.dateTo));

                        targetNext = Expression.Constant(MakeTargetNext(ConvertToDateTime(model.dateFrom)));
                        targetPrev = Expression.Constant(MakeTargetPrev(ConvertToDateTime(model.dateTo)));
                    }


                }
                else if (model.filterType == "boolean")
                {
                    target = Expression.Constant(ConvertTo(model.filter, propertyType));
                    targetTo = Expression.Constant(0);

                    targetNext = null;
                    targetPrev = null;
                }
                else
                {
                    target = Expression.Constant(model.filter);
                    targetTo = Expression.Constant(0);

                    targetNext = null;
                    targetPrev = null;
                }


                switch (model.filterType)
                {
                    case "text":
                        switch (model.type)
                        {
                            case "equals":
                                body = Expression.Call(property, equalsMethodStr, target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "notEqual":
                                body = Expression.Call(property, notEqualsMethodStr, target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "contains":
                                body = Expression.Call(property, containsMethodStr, target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "notContains":
                                body = Expression.Not(Expression.Call(property, containsMethodStr, target));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "startsWith":
                                body = Expression.Call(property, startsWithMethodStr, target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "endsWith":
                                body = Expression.Call(property, endsWithMethodStr, target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                        }
                        break;
                    case "number":
                        switch (model.type)
                        {
                            case "equals":
                                body = Expression.Call(property, MethodNumber(propertyType, "Equals"), target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "notEqual":
                                body = Expression.Call(property, MethodNumber(propertyType, "NotEqual"), target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "lessThan":
                                body = Expression.LessThan(property, target);//Expression.Call(property, MethodNumber(propertyType, "LessThan"), target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "lessThanOrEqual":
                                body = Expression.LessThanOrEqual(property, target);//Expression.Call(property, MethodNumber(propertyType, "LessThanOrEqual"), target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "greaterThan":
                                body = Expression.GreaterThan(property, target); //Expression.Call(property, MethodNumber(propertyType, "GreaterThan"), target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "greaterThanOrEqual":
                                body = Expression.GreaterThanOrEqual(property, target); //Expression.Call(property, MethodNumber(propertyType, "GreaterThanOrEqual"), target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "inRange":
                                body = Expression.AndAlso(Expression.GreaterThanOrEqual(property, target), Expression.LessThanOrEqual(property, targetTo));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                        }
                        break;
                    case "date":

                        switch (model.type)
                        {
                            case "equals":
                                body = Expression.AndAlso(Expression.GreaterThanOrEqual(property, Expression.Convert(targetPrev, property.Type)), Expression.LessThanOrEqual(property, Expression.Convert(targetNext, property.Type))); //Expression.Call(property, MethodNumber(propertyType, "Equals"), target);
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "notEqual":
                                body = Expression.OrElse(Expression.LessThanOrEqual(property, Expression.Convert(targetPrev, property.Type)), Expression.GreaterThanOrEqual(property, Expression.Convert(targetNext, property.Type)));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "lessThan":
                                body = Expression.LessThan(property, Expression.Convert(target, property.Type));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "lessThanOrEqual":
                                body = Expression.LessThanOrEqual(property, Expression.Convert(target, property.Type));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "greaterThan":
                                body = Expression.GreaterThan(property, Expression.Convert(target, property.Type));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "greaterThanOrEqual":
                                body = Expression.GreaterThanOrEqual(property, Expression.Convert(target, property.Type));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                            case "inRange":
                                body = Expression.AndAlso(Expression.GreaterThanOrEqual(property, Expression.Convert(target, property.Type)), Expression.LessThanOrEqual(property, Expression.Convert(targetTo, property.Type)));
                                return Expression.Lambda<Func<T, bool>>(body, parameter);
                        }
                        break;
                    case "boolean":
                        if (target.ToString() == "null")
                        {
                            var targetTrue = Expression.Constant(ConvertTo("True", typeof(bool)));
                            var targetFalse = Expression.Constant(ConvertTo("False", typeof(bool)));
                            body = Expression.OrElse(Expression.Call(property, MethodBoolean(propertyType, "Equals"), targetTrue), Expression.Call(property, MethodBoolean(propertyType, "Equals"), targetFalse));
                        }
                        else
                        {
                            body = Expression.Call(property, MethodBoolean(propertyType, "Equals"), target);
                        }
                        body = Expression.Call(property, MethodBoolean(propertyType, "Equals"), target);
                        return Expression.Lambda<Func<T, bool>>(body, parameter);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //String Methods
        private static readonly MethodInfo containsMethodStr = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        private static readonly MethodInfo startsWithMethodStr = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo endsWithMethodStr = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo equalsMethodStr = typeof(string).GetMethod("Equals", new[] { typeof(string) });
        private static readonly MethodInfo notEqualsMethodStr = typeof(string).GetMethod("NotEqual", new[] { typeof(string) });

        //Number Methods
        private static MethodInfo MethodNumber(Type type, string method)
        {
            return type.GetMethod(method, new[] { type });
        }

        private static MethodInfo MethodBoolean(Type type, string method)
        {
            return type.GetMethod(method, new[] { type });
        }

        private static dynamic ConvertTo(dynamic source, Type dest)
        {
            try
            {
                return Convert.ChangeType(source, dest);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static DateTime? ConvertToDateTime(string source)
        {
            try
            {
                DateTime? dest = Convert.ToDateTime(source);
                return dest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static DateTime? MakeTargetNext(DateTime? source)
        {
            try
            {
                DateTime? dest = source.GetValueOrDefault().Add(new TimeSpan(23, 59, 59));
                return dest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static DateTime? MakeTargetPrev(DateTime? source)
        {
            try
            {
                DateTime? dest = source.GetValueOrDefault().Add(new TimeSpan(0, 0, 0));
                return dest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static Type GetStaticType<T>(T x) { return typeof(T); }

        private static Expression<Func<T, bool>> And<T>(Expression<Func<T, Boolean>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return (Expression.Lambda<Func<T, Boolean>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters));
        }

        private static Expression<Func<T, bool>> Or<T>(Expression<Func<T, Boolean>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return (Expression.Lambda<Func<T, Boolean>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters));
        }

        private static Expression<Func<T, bool>> AndAlso<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(
                    Expression.Invoke(left, param),
                    Expression.Invoke(right, param)
                );
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return lambda;
        }

        private static Expression<Func<T, bool>> OrElse<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.OrElse(
                    Expression.Invoke(left, param),
                    Expression.Invoke(right, param)
                );
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return lambda;
        }
    }
}
