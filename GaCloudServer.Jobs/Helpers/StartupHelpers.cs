using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Jobs.Configuration.AuditLogging;
using GaCloudServer.Jobs.Configuration.Configuration;
using GaCloudServer.Jobs.Configuration.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Skoruba.AuditLogging.EntityFramework.DbContexts;
using Skoruba.AuditLogging.EntityFramework.Entities;
using Skoruba.AuditLogging.EntityFramework.Extensions;
using Skoruba.AuditLogging.EntityFramework.Repositories;
using Skoruba.AuditLogging.EntityFramework.Services;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Configuration.Configuration;

namespace GaCloudServer.Jobs.Helpers
{
    public static class StartupHelpers
    {
        public static IServiceCollection AddAuditEventLogging<TAuditLoggingDbContext, TAuditLog>(
        this IServiceCollection services, IConfiguration configuration)
        where TAuditLog : AuditLog, new()
        where TAuditLoggingDbContext : IAuditLoggingDbContext<TAuditLog>
        {
            var auditLoggingConfiguration = configuration.GetSection(nameof(AuditLoggingConfiguration))
                .Get<AuditLoggingConfiguration>();
            services.AddSingleton(auditLoggingConfiguration);

            services.AddAuditLogging(options => { options.Source = auditLoggingConfiguration.Source; })
                .AddEventData<ApiAuditSubject, ApiAuditAction>()
                .AddAuditSinks<DatabaseAuditEventLoggerSink<TAuditLog>>();

            services
                .AddTransient<IAuditLoggingRepository<TAuditLog>,
                    AuditLoggingRepository<TAuditLoggingDbContext, TAuditLog>>();

            return services;
        }

        /// <summary>
        /// Register DbContexts for IdentityServer ConfigurationStore and PersistedGrants, Identity and Logging
        /// Configure the connection strings in AppSettings.json
        /// </summary>
        /// <typeparam name="TAuditLoggingDbContext"></typeparam>
        /// <typeparam name="TResourcesDbContext"></typeparam>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDbContexts<TAuditLoggingDbContext, TResourcesDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TAuditLoggingDbContext : DbContext, IAuditLoggingDbContext<AuditLog>
            where TResourcesDbContext : DbContext, IResourcesDbContext


        {
            var databaseProvider = configuration.GetSection(nameof(DatabaseProviderConfiguration)).Get<DatabaseProviderConfiguration>();

            var auditLoggingConnectionString = configuration.GetConnectionString(ConfigurationConsts.AdminAuditLogDbConnectionStringKey);
            var resourcesConnectionString = configuration.GetConnectionString(ConfigurationConsts.ResourcesDbConnectionStringKey);

            switch (databaseProvider.ProviderType)
            {
                case DatabaseProviderType.SqlServer:
                    services.AddDbContext<TAuditLoggingDbContext>(options => options.UseSqlServer(auditLoggingConnectionString));
                    services.AddDbContext<TResourcesDbContext>(options => options.UseSqlServer(resourcesConnectionString, delegate (SqlServerDbContextOptionsBuilder sql) { sql.CommandTimeout(240); }));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(databaseProvider.ProviderType), $@"The value needs to be one of {string.Join(", ", Enum.GetNames(typeof(DatabaseProviderType)))}.");
            }
        }

    }
}
