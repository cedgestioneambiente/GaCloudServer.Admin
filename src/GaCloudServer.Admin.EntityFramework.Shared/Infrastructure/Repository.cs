using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Extensions;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity>,IDisposable
        where TDbContext : DbContext, IResourcesDbContext
        where TEntity :  GenericEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;
        private readonly ILogger<Repository<TDbContext,TEntity>> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Repository(TDbContext context,ILogger<Repository<TDbContext,TEntity>> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _entities = context.Set<TEntity>();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        }

        #region OLD
        #region CRUD
        public virtual void Add(TEntity entity)
        {
            //auditEventLogger.LogEventAsync(new AddEventModel(string.Format("ADD - {0}", _entities.EntityType)) { });
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            //auditEventLogger.LogEventAsync(new UpdateEventModel(string.Format("UPDATE - {0}", _entities.EntityType)) { });
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            //auditEventLogger.LogEventAsync(new DeleteEventModel(string.Format("REMOVE - {0}", _entities.EntityType)) { });
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        //Async
        public virtual async Task AddAsync(TEntity entity)
        {
            //await auditEventLogger.LogEventAsync(new AddEventModel(string.Format("ADD - {0}", _entities.EntityType)) { });
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
            //auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET BY ID - {0}",_entities.EntityType)) { });
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

            //auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET ALL - {0}", _entities.EntityType)) { });
            return pagedList;
        }

        public virtual async Task<PagedList<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> predicate, int page = 1, int pageSize = 0, string orderField = "Id", string orderType = "OrderBy")
        {
            var pagedList = new PagedList<TEntity>();

            List<TEntity> entities;
            IQueryable<TEntity> queryableEntities = _entities.Where(predicate);

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

            //auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET WITH FILTER - {0}", _entities.EntityType)) { });

            return pagedList;

        }

        public virtual async Task<PagedList<TEntity>> GetWithFilterAsNoTrakingAsync(Expression<Func<TEntity, bool>> predicate, int page = 1, int pageSize = 0, string orderField = "Id", string orderType = "OrderBy")
        {
            var pagedList = new PagedList<TEntity>();

            List<TEntity> entities;
            IQueryable<TEntity> queryableEntities = _entities.Where(predicate);

            var prop = typeof(TEntity).GetProperty(orderField);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var selector = Expression.PropertyOrField(parameter, orderField);

            Expression expression = queryableEntities.Expression;
            expression = Expression.Call(typeof(Queryable), orderType,
                    new Type[] { queryableEntities.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));

            if (pageSize != 0)
            {

                entities = await _entities.AsNoTracking().Where(predicate).PageBy(x => x.Id, page, pageSize).ToListAsync();
            }
            else
            {
                entities = await queryableEntities.AsNoTracking().Provider.CreateQuery<TEntity>(expression).ToListAsync();
            }

            pagedList.Data.AddRange(entities);
            pagedList.PageSize = pageSize;
            pagedList.TotalCount = entities.Count();

            //auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET WITH FILTER - {0}", _entities.EntityType)) { });

            return pagedList;

        }




        public virtual async Task<TEntity> GetSingleWithFilter(Expression<Func<TEntity, bool>> predicate)
        {
            //auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET SINGLE - {0}", _entities.EntityType)) { });
            return await _entities.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetSingleWithFilterAsNoTrakingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            //auditEventLogger.LogEventAsync(new GetEventModel(string.Format("GET SINGLE - {0}", _entities.EntityType)) { });

            return await _entities.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
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

                var filteredData = data.OrderBy(filterParams.sortModel).ToList();

                pagedList.TotalCount = filteredData.Count();

                var pageData = filteredData
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow);

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

                var filteredData = data.OrderBy(filterParams.sortModel).ToList();

                pagedList.TotalCount = filteredData.Count();

                var pageData = filteredData
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow);

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

                var filteredData = data.OrderBy(filterParams.sortModel).ToList();

                pagedList.TotalCount = filteredData.Count();

                var pageData = filteredData
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow);

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

                var filteredData = data.OrderBy(filterParams.sortModel).ToList();

                pagedList.TotalCount = filteredData.Count();

                var pageData = filteredData
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow);

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

            var filteredData = data.OrderBy(filterParams.sortModel).ToList();

            pagedList.TotalCount = filteredData.Count();

            var pageData = filteredData
                .Skip(filterParams.startRow)
                .Take(filterParams.endRow);

            pagedList.Data.AddRange(pageData);

            return pagedList;

           

        }


        public virtual PagedList<TEntity> GetWithFilterQueryableV2WithQuickFilter(Expression<Func<TEntity, bool>> predicate,GridOperationsModel filterParams, string quickFilter)
        {
            var pagedList = new PagedList<TEntity>();

            var data = _entities.Where(predicate).AsQueryable()
            .FilterByV2(filterParams)
            .QuickFilterBy(quickFilter);

            var filteredData = data.OrderBy(filterParams.sortModel).ToList();

            pagedList.TotalCount = filteredData.Count();

            var pageData = filteredData
                .Skip(filterParams.startRow)
                .Take(filterParams.endRow);

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

                var filteredData = data.OrderBy(filterParams.sortModel).ToList();

                pagedList.TotalCount = filteredData.Count();

                var pageData = filteredData
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow);

                pagedList.Data.AddRange(pageData);

                return pagedList;
            }
            else
            {
                var data = _entities.AsQueryable()
                .FilterByV2(filterParams);

                var filteredData = data.OrderBy(filterParams.sortModel).ToList();

                pagedList.TotalCount = filteredData.Count();

                var pageData = filteredData
                    .Skip(filterParams.startRow)
                    .Take(filterParams.endRow);

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

            var filteredData = data.OrderBy(filterParams.sortModel).ToList();

            pagedList.TotalCount = filteredData.Count();

            var pageData = filteredData
                .Skip(filterParams.startRow)
                .Take(filterParams.endRow);

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

        private IQueryable<TEntity> ApplyOrdering(IQueryable<TEntity> query, string orderField, string orderType)
        {
            var entityType = typeof(TEntity);
            var parameter = Expression.Parameter(entityType, "x");

            // Get the property specified by orderField
            var property = Expression.Property(parameter, orderField);

            // Create the lambda expression x => x.Property
            var lambda = Expression.Lambda(property, parameter);

            // Get the OrderBy or OrderByDescending method based on orderType
            var methodName = orderType == "OrderByDescending" ? "OrderByDescending" : "OrderBy";

            // Create the expression for the OrderBy/OrderByDescending method call
            var methodCallExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { entityType, property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );

            return query.Provider.CreateQuery<TEntity>(methodCallExpression);
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

        #endregion
        public Task<TEntity> GetAsync(long id, GetRequest request, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<TEntity>().AsNoTracking();
            query = query.Expand(request?.Expand);
            return query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken: cancellationToken);
        }

        public async Task<PageResponse<TEntity>> GetAsync(PageRequest request, CancellationToken cancellationToken = default)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));
            request.OrderBy ??= nameof(GenericEntity.Id);

            var query = _context.Set<TEntity>().AsNoTracking();
            var odataQuery = query.GetODataQuery(request);

            query = odataQuery.Inner as IQueryable<TEntity>;

            int? count = request.Take.HasValue || request.Skip.HasValue ? await query.CountAsync(cancellationToken).ConfigureAwait(false) : null;

            var page = query.GetPage(request);

            var items = await page.ToListAsync(cancellationToken).ConfigureAwait(false);

            return new PageResponse<TEntity>
            {
                Count = count ?? items.Count,
                Items = items
            };
        }


        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity = entity ?? throw new ArgumentNullException(nameof(entity));

            if (entity is GenericAuditableEntity  auditable)
            {
                auditable.CreatedAt = DateTime.UtcNow;
                auditable.CreatedBy = _httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == "sub").FirstOrDefault().Value ?? "system";
            }

            if (entity is GenericListAuditableEntity auditableList)
            {
                auditableList.CreatedAt = DateTime.UtcNow;
                auditableList.CreatedBy = _httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == "sub").FirstOrDefault().Value ?? "system";
            }

            if (entity is GenericFileAuditableEntity auditableFile)
            {
                auditableFile.CreatedAt = DateTime.UtcNow;
                auditableFile.CreatedBy = _httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == "sub").FirstOrDefault().Value ?? "system";
            }
            await _context.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogInformation("Entity {EntityId} created", entity.Id);
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity = entity ?? throw new ArgumentNullException(nameof(entity));
            var storedEntity = await _context.Set<TEntity>()
                .Where(e => e.Id == entity.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            if (storedEntity == null)
            {
                throw new DbUpdateException($"Entity type {typeof(TEntity).Name} at id {entity.Id} is not found");
            }

            if (entity is GenericAuditableEntity auditable)
            {
                auditable.ModifiedAt = DateTime.UtcNow;
                auditable.ModifiedBy = _httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == "sub").FirstOrDefault().Value ?? "system";
            }

            if (entity is GenericListAuditableEntity auditableList)
            {
                auditableList.ModifiedAt = DateTime.UtcNow;
                auditableList.ModifiedBy = _httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == "sub").FirstOrDefault().Value ?? "system";
            }

            if (entity is GenericFileAuditableEntity auditableFile)
            {
                auditableFile.ModifiedAt = DateTime.UtcNow;
                auditableFile.ModifiedBy = _httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == "sub").FirstOrDefault().Value ?? "system";
            }

            entity.Copy(storedEntity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogInformation("Entity {EntityId} updated", entity.Id);
            return entity;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogInformation("Entity {EntityId} deleted", entity.Id);
        }

    }
}
