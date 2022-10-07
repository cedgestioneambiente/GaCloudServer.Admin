using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GaCloudServer.BusinnessLogic.Extensions
{
    public static class ResourcesServiceExtensions
    {
        public static IServiceCollection AddResourcesServices<TResourcesDbContext>(this IServiceCollection services)
            where TResourcesDbContext:DbContext,IResourcesDbContext
        {
            services.AddTransient<IGaAutorizzazioniService, GaAutorizzazioniService>();
            services.AddTransient<IGaCdrService,GaCdrService>();
            services.AddTransient<IGaContrattiService, GaContrattiService>();
            services.AddTransient<IGaComunicatiService, GaComunicatiService>();
            services.AddTransient<IGaMezziService, GaMezziService>();
            services.AddTransient<IGaAziendeService, GaAziendeService>();
            services.AddTransient<IGaBackOfficeService,GaBackOfficeService>();
            services.AddTransient<IGaPrenotazioneAutoService,GaPrenotazioneAutoService>();

            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IUnitOfWork, UnitOfWork<TResourcesDbContext>>();

            return services;
        }
    }
}
