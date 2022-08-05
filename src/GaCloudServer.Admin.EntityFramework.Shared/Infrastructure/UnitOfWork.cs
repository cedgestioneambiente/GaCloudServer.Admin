using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : DbContext, IResourcesDbContext
    {
        readonly DbContext context;
        public UnitOfWork(TDbContext _context)
        {
            context = _context;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void DetachEntity<T>(T entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }
    }
}
