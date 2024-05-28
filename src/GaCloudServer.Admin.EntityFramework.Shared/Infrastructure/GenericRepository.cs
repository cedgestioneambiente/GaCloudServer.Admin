using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class GenericRepository<TDbContext, TEntity> : Repository<TDbContext, TEntity>, IGenericRepository<TEntity>
        where TDbContext : DbContext, IResourcesDbContext
        where TEntity :  GenericEntity
    {
        public GenericRepository(TDbContext context,ILogger<Repository<TDbContext,TEntity>> logger, IHttpContextAccessor httpContextAccessor) : base(context,logger,httpContextAccessor) { }
    }

}
