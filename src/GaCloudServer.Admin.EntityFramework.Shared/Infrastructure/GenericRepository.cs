using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Skoruba.AuditLogging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class GenericRepository<TDbContext, TEntity> : Repository<TDbContext, TEntity>, IGenericRepository<TEntity>
        where TDbContext : DbContext, IResourcesDbContext
        where TEntity :  GenericEntity
    {
        public GenericRepository(TDbContext context,IAuditEventLogger auditEventLogger) : base(context,auditEventLogger) { }
    }
}
