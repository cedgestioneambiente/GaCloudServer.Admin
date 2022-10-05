using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class ProcedureManager<TDbContext,T>: IProcedureManager<T>
        where TDbContext : DbContext, IResourcesDbContext
        where T:class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entities;

        public ProcedureManager(TDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }

        public void ExecStoreNoResultProcedure(string query)
        {
            query = QueryBuilder(query);
            _entities.FromSqlRaw(query);
        }

        public async void ExecStoreNoResultProcedureAsync(string query)
        {
            query = QueryBuilder(query);
            await _entities.FromSqlRaw(query).CountAsync();
        }

        public void ExecStoreNoResultWithParamsProcedure(string query, params object[] parameters)
        {
            query = QueryBuilder(query);
            _entities.FromSqlRaw(query);
        }

        public IEnumerable<T> ExecStoreProcedure(string query)
        {
            query = QueryBuilder(query);
            return _entities.FromSqlRaw(query).ToList();
        }

        public async Task<IList<T>> ExecStoreProcedureAsync(string query)
        {
            query = QueryBuilder(query);
            return await _entities.FromSqlRaw(query).ToListAsync();
        }

        public async void ExecStoreProcedureNoResultWithParamsAsync(string query, params object[] parameters)
        {
            query = QueryBuilder(query);
            await _entities.FromSqlRaw(query, parameters).CountAsync();
        }

        public IEnumerable<T> ExecStoreProcedureWithParams(string query, params object[] parameters)
        {
            query = QueryBuilder(query);
            return _entities.FromSqlRaw(query, parameters).ToList();
        }

        public async Task<IList<T>> ExecStoreProcedureWithParamsAsync(string query, params object[] parameters)
        {
            query = QueryBuilder(query);
            return await _entities.FromSqlRaw(query, parameters).ToListAsync();
        }

        private string QueryBuilder(string query)
        {
            StringBuilder str = new StringBuilder();
            str.Append($"EXECUTE {query}");
            return str.ToString();
        }
    }
}
