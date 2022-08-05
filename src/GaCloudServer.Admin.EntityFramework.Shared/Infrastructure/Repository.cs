using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Extensions;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext, IResourcesDbContext
        where TEntity : class, IGenericEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(TDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();

        }

        #region CRUD
        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        //Async
        public virtual async Task AddAsync(TEntity entity)
        {
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

        #region List
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

            return pagedList;

        }

        public virtual async Task<TEntity> GetSingleWithFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).FirstOrDefaultAsync();
        }
        #endregion

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
        #endregion


    }
}
