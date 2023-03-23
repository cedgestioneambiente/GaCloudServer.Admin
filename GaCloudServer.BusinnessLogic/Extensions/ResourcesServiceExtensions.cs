using DinkToPdf;
using DinkToPdf.Contracts;
using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Helpers;
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
            var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddTransient<IGaAutorizzazioniService, GaAutorizzazioniService>();
            services.AddTransient<IGaCdrService,GaCdrService>();
            services.AddTransient<IGaContrattiService, GaContrattiService>();
            services.AddTransient<IGaComunicatiService, GaComunicatiService>();
            services.AddTransient<IGaMezziService, GaMezziService>();
            services.AddTransient<IGaAziendeService, GaAziendeService>();
            services.AddTransient<IGaBackOfficeService,GaBackOfficeService>();
            services.AddTransient<IGaPrenotazioneAutoService,GaPrenotazioneAutoService>();
            services.AddTransient<IGlobalService, GlobalService>();
            services.AddTransient<IGaPersonaleService, GaPersonaleService>();
            services.AddTransient<IGaCsrService, GaCsrService>();
            services.AddTransient<IGaReclamiService, GaReclamiService>();
            services.AddTransient<IGaSegnalazioniService, GaSegnalazioniService>();
            services.AddTransient<IEcSegnalazioniService, EcSegnalazioniService>();
            services.AddTransient<IGaContactCenterService, GaContactCenterService>();
            services.AddTransient<IGaPresenzeService, GaPresenzeService>();
            services.AddTransient<IGaRecapitiService, GaRecapitiService>();
            services.AddTransient<IOstService, OstService>();
            services.AddTransient<IGaPrevisioService, GaPrevisioService>();

            services.AddTransient<IFileService, FileService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IPrintService, PrintService>();
            services.AddTransient<ILocalFileService, LocalFileService>();
            services.AddTransient<IMailService,MailService>();
            services.AddTransient<IEcoFinderService, EcoFinderService>();
            services.AddTransient<IShortcutsService, ShortcutsService>();
            services.AddTransient<IDashboardService,DashboardService>();

            services.AddTransient<IQueryBuilderService, QueryBuilderService>();


            services.AddTransient<IUnitOfWork, UnitOfWork<TResourcesDbContext>>();



            return services;
        }

        public static IServiceCollection AddJobsResourcesServices<TResourcesDbContext>(this IServiceCollection services)
            where TResourcesDbContext : DbContext, IResourcesDbContext
        {
            services.AddTransient<IGaAutorizzazioniService, GaAutorizzazioniService>();
            services.AddTransient<IGaMezziService, GaMezziService>();

            services.AddTransient<IMailService, MailService>();
            services.AddTransient<INotificationService, NotificationService>();
           

            services.AddTransient<IUnitOfWork, UnitOfWork<TResourcesDbContext>>();



            return services;
        }
    }
}
