using GaCloudServer.Admin.EntityFramework.Shared.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Extensions
{
    public static class ResourcesDatabaseExtensions
    {
        public static void RegisterSqlServerDbContexts<TResourcesDbContext>(this IServiceCollection services, ExtendedConnectionStringConfiguration connectionStrings, ExtendedDatabaseMigrationsConfiguration databaseMigrations, int OperationTimeout=30) 
            where TResourcesDbContext : DbContext 
        {
            string migrationsAssembly = typeof(ResourcesDatabaseExtensions).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<TResourcesDbContext>(delegate (DbContextOptionsBuilder options)
            {
                options.UseSqlServer(connectionStrings.ResourcesDbConnection, delegate (SqlServerDbContextOptionsBuilder sql)
                {
                    sql.CommandTimeout(OperationTimeout);
                    sql.MigrationsAssembly(databaseMigrations.ResourcesDbMigrationsAssembly ?? migrationsAssembly);
                });
            });
            
        }

    }
}
