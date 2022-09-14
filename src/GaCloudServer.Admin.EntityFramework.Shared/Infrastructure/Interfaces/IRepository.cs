using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> :IDisposable
        where TEntity : class 
    {
        #region CRUD
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        //Async
        Task AddAsync(TEntity entity);
        Task<bool> CanInsertAsync(TEntity entity, bool isCloned = false);

        #endregion

        #region List
        TEntity GetById(long id);
        TEntity GetByIdAsNoTraking(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetWithFilter(Expression<Func<TEntity, bool>> predicate);

        //Async
        Task<TEntity> GetByIdAsync(long id);
        Task<PagedList<TEntity>> GetAllAsync(int page = 1, int pageSize = 0, string orderField = "Id", string orderType = "OrderBy");
        Task<PagedList<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> predicate, int page = 1, int pageSize = 0, string orderField = "Id", string orderType = "OrderBy");
        Task<TEntity> GetSingleWithFilter(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Functions
        Task<bool> CheckIsUnique(Expression<Func<TEntity, bool>> predicate);
        Task<bool> CheckIfExist(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
