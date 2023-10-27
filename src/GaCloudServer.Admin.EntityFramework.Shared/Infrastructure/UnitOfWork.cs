using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : DbContext, IResourcesDbContext
    {
        readonly TDbContext context;
        public UnitOfWork(TDbContext _context)
        {
            context = _context;
        }

        public int SaveChanges()
        {
            //Recupero tutte le entità che ereditano da GenericAuditableEntity
            //con lo stato Added o Modified
            var entries = context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is GenericAuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            //per tutte le entità trovate setto le Audit prop
            foreach (var entityEntry in entries)
            {
                //Se lo stato è Added
                //setto CreatedAt e CreatedBy
                if (entityEntry.State == EntityState.Added)
                {
                    ((GenericAuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((GenericAuditableEntity)entityEntry.Entity).CreatedBy = context.httpContextAccessor?.HttpContext?.User?.Claims?.Where(X => X.Type == "sub").FirstOrDefault().Value ?? "System ga.Cloud";
                }
                else
                {
                    // Da rivedere
                    // qui vorrei fare in modo che non vengano sicuramente modificate le proprietà createdat e createdby dato che mi trovo in stato Updated

                    context.Entry((GenericAuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    context.Entry((GenericAuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                // Setto comunque sempre le proprietà
                // ModifiedAt e ModifiedBy anche se mi trovo in creazione
                ((GenericAuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
                ((GenericAuditableEntity)entityEntry.Entity).ModifiedBy = context.httpContextAccessor?.HttpContext?.User?.Claims?.Where(X => X.Type == "sub").FirstOrDefault().Value ?? "System ga.Cloud";
            }
            // salvo il dato con le aggiunte audit a db
            return context.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            //Recupero tutte le entità che ereditano da GenericAuditableEntity
            //con lo stato Added o Modified
            var entries = context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is GenericAuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            //per tutte le entità trovate setto le Audit prop
            foreach (var entityEntry in entries)
            {
                //Se lo stato è Added
                //setto CreatedAt e CreatedBy
                if (entityEntry.State == EntityState.Added)
                {
                    ((GenericAuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((GenericAuditableEntity)entityEntry.Entity).CreatedBy = context.httpContextAccessor?.HttpContext?.User?.Claims?.Where(X => X.Type == "sub").FirstOrDefault().Value ?? "System ga.Cloud";
                }
                else
                {
                    // Da rivedere
                    // qui vorrei fare in modo che non vengano sicuramente modificate le proprietà createdat e createdby dato che mi trovo in stato Updated

                    context.Entry((GenericAuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    context.Entry((GenericAuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                // Setto comunque sempre le proprietà
                // ModifiedAt e ModifiedBy anche se mi trovo in creazione
                ((GenericAuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
                ((GenericAuditableEntity)entityEntry.Entity).ModifiedBy = context.httpContextAccessor?.HttpContext?.User?.Claims?.Where(X=>X.Type=="sub").FirstOrDefault().Value ?? "System ga.Cloud";
            }
            // salvo il dato con le aggiunte audit a db

            return await context.SaveChangesAsync();
        }

        public void DetachEntity<T>(T entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }

        
    }
}
