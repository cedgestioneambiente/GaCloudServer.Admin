using System;
using System.IO;
using System.Reflection;
using GaCloudServer.Admin.Configuration.Constants;
using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.SqlServer.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Configuration.Configuration;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Configuration.SqlServer;
using Skoruba.Duende.IdentityServer.Admin.UI.Helpers.ApplicationBuilder;

namespace GaCloudServer.Admin.Helpers
{
    public static class StartupHelpers
    {
        public static void AddAdminUIRazorRuntimeCompilation(this IServiceCollection services, IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                var builder = services.AddControllersWithViews();

                var adminAssembly = typeof(AdminUIApplicationBuilderExtensions).GetTypeInfo().Assembly.GetName().Name;

                builder.AddRazorRuntimeCompilation(options =>
                {
                    if (adminAssembly == null) return;

                    var libraryPath = Path.GetFullPath(Path.Combine(hostingEnvironment.ContentRootPath, "..", adminAssembly));

                    if (Directory.Exists(libraryPath))
                    {
                        options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
                    }
                });
            }
        }

        public static void RegisterCustomDbContext<TResourcesDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TResourcesDbContext : DbContext,IResourcesDbContext
        { 
            var databaseProvider = configuration.GetSection(nameof(DatabaseProviderConfiguration)).Get<DatabaseProviderConfiguration>();
            var resourcesConnectionString = configuration.GetConnectionString(ConfigurationConsts.ResourcesDbConnectionStringKey);

            switch (databaseProvider.ProviderType)
            {
                case DatabaseProviderType.SqlServer:
                    services.RegisterSqlServerDbContexts<TResourcesDbContext>( resourcesConnectionString);
                    break;
                case DatabaseProviderType.PostgreSQL:
                    
                    break;
                case DatabaseProviderType.MySql:

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(databaseProvider.ProviderType), $@"The value needs to be one of {string.Join(", ", Enum.GetNames(typeof(DatabaseProviderType)))}.");
            }
        }
    }
}







