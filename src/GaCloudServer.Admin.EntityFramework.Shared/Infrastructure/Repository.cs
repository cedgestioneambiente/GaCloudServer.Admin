using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Extensions;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Skoruba.AuditLogging.Services;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity>,IDisposable
        where TDbContext : DbContext, IResourcesDbContext
        where TEntity :  GenericEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;
        protected readonly IAuditEventLogger auditEventLogger;

        public Repository(TDbContext context,IAuditEventLogger auditEventLogger)
        {
            _context = context;
            _entities = context.Set<TEntity>();
            this.auditEventLogger = auditEventLogger;

        }

        #region CRUD
        public virtual void Add(TEntity entity)
        {
            auditEventLogger.LogEventAsync(new AddEventModel(string.Format("ADD - {0}", _entities.EntityType)) { });
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            auditEventLogger.LogEventAsync(new UpdateEventModel(string.Format("UPDATE - {0}", _entities.EntityType)) { });
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            auditEventLogger.LogEventAsync(new DeleteEventModel(string.Format("REMOVE - {0}", _entities.EntityType)) { });
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        //Async
        public virtual async Task AddAsync(TEntity entity)
        {
            await auditEventLogger.LogEventAsync(new AddEventModel(string.Format("ADD - {0}", _entities.EntityType)) { });
            await _entities.AddAsync(entity);
        }
        public virtual async Task<bool> CanInsertAsync(TEntity entity, bool isCloned = false)
        {
            if (entity.Id == 0 || isCloned)
            {
                var exist = await _entities.Where(x => x.Id == entity.Id).SingleOrDefaultAsync();
                return exist == null;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region GET
        public virtual TEntity GetById(long id)
        {

            return _entities.Find(id);
        }

        public virtual TEntity GetByIdAsNoTraking(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual IEnumerable<TEntity> GetWithFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        //Async
        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET BY ID - {0}",_entities.EntityType)) { });
            return await _entities.FindAsync(id);
        }

        public virtual async Task<PagedList<TEntity>> GetAllAsync(int page = 1, int pageSize = 0, string orderField = "Id", string orderType = "OrderBy")
        {
            var pagedList = new PagedList<TEntity>();

            List<TEntity> entities;
            var queryableEntities = _entities.AsQueryable();

            var prop = typeof(TEntity).GetProperty("Id");
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var selector = Expression.PropertyOrField(parameter, orderField);

            Expression expression = queryableEntities.Expression;
            expression = Expression.Call(typeof(Queryable), orderType,
                    new Type[] { queryableEntities.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));

            if (pageSize != 0)
            {

                entities = await _entities.PageBy(x => x.Id, page, pageSize).ToListAsync();
            }
            else
            {
                entities = await queryableEntities.Provider.CreateQuery<TEntity>(expression).ToListAsync();
            }

            pagedList.Data.AddRange(entities);
            pagedList.PageSize = pageSize;
            pagedList.TotalCount = _entities.Count();

            auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET ALL - {0}", _entities.EntityType)) { });
            return pagedList;
        }

        public virtual async Task<PagedList<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> predicate, int page = 1, int pageSize = 0, string orderField = "Id", string orderType = "OrderBy")
        {
            var pagedList = new PagedList<TEntity>();

            List<TEntity> entities;
            var queryableEntities = _entities.Where(predicate).AsQueryable();

            var prop = typeof(TEntity).GetProperty(orderField);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var selector = Expression.PropertyOrField(parameter, orderField);

            Expression expression = queryableEntities.Expression;
            expression = Expression.Call(typeof(Queryable), orderType,
                    new Type[] { queryableEntities.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));

            if (pageSize != 0)
            {

                entities = await _entities.Where(predicate).PageBy(x => x.Id, page, pageSize).ToListAsync();
            }
            else
            {
                entities = await queryableEntities.Provider.CreateQuery<TEntity>(expression).ToListAsync();
            }

            pagedList.Data.AddRange(entities);
            pagedList.PageSize = pageSize;
            pagedList.TotalCount = entities.Count();

            auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET WITH FILTER - {0}", _entities.EntityType)) { });

            return pagedList;

        }

        public virtual async Task<TEntity> GetSingleWithFilter(Expression<Func<TEntity, bool>> predicate)
        {
            auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET SINGLE - {0}", _entities.EntityType)) { });
            return await _entities.Where(predicate).FirstOrDefaultAsync();
        }
        #endregion

        public virtual PagedList<TEntity> GetAllQueryable(GridOperationsModel filterParams)
        {
            var pagedList = new PagedList<TEntity>();

            var data = _entities.AsQueryable()
            .FilterBy(filterParams);
            pagedList.TotalCount = data.Count();

            var pageData = data
                .Skip(filterParams.startRow)
                .Take(filterParams.endRow)
                .OrderBy(filterParams.sortModel)
                .AsNoTracking()
                .ToList();

            pagedList.Data.AddRange(pageData);

            return pagedList;

        }

        public virtual PagedList<TEntity> GetAllQueryableV2(GridOperationsModel filterParams)
        {
            var pagedList = new PagedList<TEntity>();

            if (filterParams.sortModel.Count() == 0)
            {

                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var selector = Expression.PropertyOrField(parameter, "Id");
                var method = "OrderByDescending";

                var data = _entities.AsQueryable();
                Expression expression = data.Expression;

                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { data.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                data = data.Provider.CreateQuery<TEntity>(expression);

                data = data
                    .FilterByV2(filterParams);

                pagedList.TotalCount = data.Count();

                var pageData = data
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow)
                    .OrderBy(filterParams.sortModel)
                    .AsNoTracking()
                    .ToList();

                pagedList.Data.AddRange(pageData);

                return pagedList;
            }
            else
            {

                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var selector = Expression.PropertyOrField(parameter, filterParams.sortModel[0].colId);
                var method = filterParams.sortModel[0].sort == "desc" ? "OrderByDescending" : "OrderBy";

                var data = _entities.AsQueryable();
                Expression expression = data.Expression;

                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { data.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                data = data.Provider.CreateQuery<TEntity>(expression);

                data = data.AsQueryable()
                .FilterByV2(filterParams);

                pagedList.TotalCount = data.Count();

                var pageData = data
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow)
                    .OrderBy(filterParams.sortModel)
                    .AsNoTracking()
                    .ToList();

                pagedList.Data.AddRange(pageData);

                return pagedList;
            }

        }
        public virtual PagedList<TEntity> GetWithFilterQueryableV2(Expression<Func<TEntity, bool>> predicate,GridOperationsModel filterParams)
        {
            var pagedList = new PagedList<TEntity>();

            if (filterParams.sortModel.Count() == 0)
            {

                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var selector = Expression.PropertyOrField(parameter, "Id");
                var method = "OrderByDescending";

                var data = _entities.Where(predicate).AsQueryable();
                Expression expression = data.Expression;

                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { data.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                data = data.Provider.CreateQuery<TEntity>(expression);

                data = data
                    .FilterByV2(filterParams);

                pagedList.TotalCount = data.Count();

                var pageData = data
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow)
                    .OrderBy(filterParams.sortModel)
                    .AsNoTracking()
                    .ToList();

                pagedList.Data.AddRange(pageData);

                return pagedList;
            }
            else
            {

                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var selector = Expression.PropertyOrField(parameter, filterParams.sortModel[0].colId);
                var method = filterParams.sortModel[0].sort == "desc" ? "OrderByDescending" : "OrderBy";

                var data = _entities.Where(predicate).AsQueryable();
                Expression expression = data.Expression;

                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { data.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                data = data.Provider.CreateQuery<TEntity>(expression);

                data = data.AsQueryable()
                .FilterByV2(filterParams);

                pagedList.TotalCount = data.Count();

                var pageData = data
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow)
                    .OrderBy(filterParams.sortModel)
                    .AsNoTracking()
                    .ToList();

                pagedList.Data.AddRange(pageData);

                return pagedList;
            }

        }

        public virtual PagedList<TEntity> GetAllQueryableV2WithQuickFilter(GridOperationsModel filterParams, string quickFilter)
        {
            var pagedList = new PagedList<TEntity>();

            var data = _entities.AsQueryable()
            .FilterByV2(filterParams)
            .QuickFilterBy(quickFilter);

            pagedList.TotalCount = data.Count();

            var pageData = data
                .Skip(filterParams.startRow)
                .Take(filterParams.endRow)
                .OrderBy(filterParams.sortModel)
                .AsNoTracking()
                .ToList();

            pagedList.Data.AddRange(pageData);

            return pagedList;

        }


        public virtual PagedList<TEntity> GetWithFilterQueryableV2WithQuickFilter(Expression<Func<TEntity, bool>> predicate,GridOperationsModel filterParams, string quickFilter)
        {
            var pagedList = new PagedList<TEntity>();

            var data = _entities.Where(predicate).AsQueryable()
            .FilterByV2(filterParams)
            .QuickFilterBy(quickFilter);

            pagedList.TotalCount = data.Count();

            var pageData = data
                .Skip(filterParams.startRow)
                .Take(filterParams.endRow)
                .OrderBy(filterParams.sortModel)
                .AsNoTracking()
                .ToList();

            pagedList.Data.AddRange(pageData);

            return pagedList;

        }

        public virtual PagedList<TEntity> GetAllQueryableV2NoSkip(GridOperationsModel filterParams)
        {
            var pagedList = new PagedList<TEntity>();

            if (filterParams.sortModel.Count() == 0)
            {

                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var selector = Expression.PropertyOrField(parameter, "Id");
                var method = "OrderByDescending";

                var data = _entities.AsQueryable();
                Expression expression = data.Expression;

                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { data.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                data = data.Provider.CreateQuery<TEntity>(expression);

                data = data
                    .FilterByV2(filterParams);

                pagedList.TotalCount = data.Count();

                var pageData = data
                    .OrderBy(filterParams.sortModel)
                    .AsNoTracking()
                    .ToList();

                pagedList.Data.AddRange(pageData);

                return pagedList;
            }
            else
            {
                var data = _entities.AsQueryable()
                .FilterByV2(filterParams);

                pagedList.TotalCount = data.Count();

                var pageData = data
                    .OrderBy(filterParams.sortModel)
                    .AsNoTracking()
                    .ToList();

                pagedList.Data.AddRange(pageData);

                return pagedList;
            }



        }

        public virtual PagedList<TEntity> GetAllQueryableV2WithQuickFilterNoSkip(GridOperationsModel filterParams, string quickFilter)
        {
            var pagedList = new PagedList<TEntity>();

            var data = _entities.AsQueryable()
            .FilterByV2(filterParams)
            .QuickFilterBy(quickFilter);

            pagedList.TotalCount = data.Count();

            var pageData = data
                .OrderBy(filterParams.sortModel)
                .AsNoTracking()
                .ToList();

            pagedList.Data.AddRange(pageData);

            return pagedList;

        }

        public virtual PagedList<TEntity> GetAllQueryableQuikFilter(string filter)
        {
            var pagedList = new PagedList<TEntity>();

            var data = _entities.AsQueryable()
            .QuickFilterBy(filter);
            pagedList.TotalCount = data.Count();

            var pageData = data
                .AsNoTracking()
                .ToList();

            pagedList.Data.AddRange(pageData);

            return pagedList;

        }

        #region Functions
        public async Task<bool> CheckIsUnique(Expression<Func<TEntity, bool>> predicate)
        {
            bool exist = await _entities.AnyAsync(predicate);
            if (exist)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> CheckIfExist(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.AsNoTracking().AnyAsync(predicate);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
