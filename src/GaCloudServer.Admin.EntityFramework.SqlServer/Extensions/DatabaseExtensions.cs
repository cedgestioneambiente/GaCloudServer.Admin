using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Extensions
{
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Register DbContexts for Custom DbContexts
        /// Configure the connection strings in AppSettings.json
        /// </summary>
        /// <typeparam name="TResourcesDbContext"></typeparam>
        /// <param name="services"></param>
        /// <param name="resourcesConnectionString"></param>
        public static void RegisterSqlServerDbContexts<TResourcesDbContext>(this IServiceCollection services, string resourcesConnectionString = null)
            where TResourcesDbContext : DbContext, IResourcesDbContext
        {
            var migrationsAssembly = typeof(DatabaseExtensions).GetTypeInfo().Assembly.GetName().Name;

            // Resources DB
            services.AddDbContext<TResourcesDbContext>(options => options.UseSqlServer(resourcesConnectionString, optionsSql => optionsSql.MigrationsAssembly(migrationsAssembly)));
        }
    }
}
