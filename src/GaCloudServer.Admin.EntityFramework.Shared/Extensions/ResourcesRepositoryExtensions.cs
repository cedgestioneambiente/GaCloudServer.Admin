using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GaCloudServer.Admin.EntityFramework.Shared.Extensions
{
    public static class ResourcesRepositoryExtensions
    {
        public static IServiceCollection AddResourcesRepository<TResourcesDbContext>(this IServiceCollection services)
            where TResourcesDbContext : DbContext,IResourcesDbContext
        {
            //Autorizzazioni
            #region Autorizzazioni
            services.AddTransient<IGenericRepository<AutorizzazioniTipo>, GenericRepository<TResourcesDbContext, AutorizzazioniTipo>>();
            services.AddTransient<IGenericRepository<AutorizzazioniDocumento>, GenericRepository<TResourcesDbContext, AutorizzazioniDocumento>>();
            services.AddTransient<IGenericRepository<AutorizzazioniAllegato>, GenericRepository<TResourcesDbContext, AutorizzazioniAllegato>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaAutorizzazioniDocumenti>, GenericRepository<TResourcesDbContext, ViewGaAutorizzazioniDocumenti>>();
            #endregion

            //Cdr
            #region Cdr
            services.AddTransient<IGenericRepository<CdrComune>,GenericRepository<TResourcesDbContext, CdrComune>>();
            services.AddTransient<IGenericRepository<CdrComuneOnCentro>, GenericRepository<TResourcesDbContext, CdrComuneOnCentro>>();
            services.AddTransient<IGenericRepository<CdrCentro>, GenericRepository<TResourcesDbContext, CdrCentro>>();
            services.AddTransient<IGenericRepository<CdrCer>, GenericRepository<TResourcesDbContext, CdrCer>>();
            services.AddTransient<IGenericRepository<CdrCerOnCentro>,GenericRepository<TResourcesDbContext, CdrCerOnCentro>>();
            #endregion

            //Comunicati
            #region Comunicati
            services.AddTransient<IGenericRepository<ComunicatiDocumento>, GenericRepository<TResourcesDbContext, ComunicatiDocumento>>();
            #endregion

            //Mezzi
            #region Mezzi
            services.AddTransient<IGenericRepository<MezziAlimentazione>, GenericRepository<TResourcesDbContext, MezziAlimentazione>>();
            services.AddTransient<IGenericRepository<MezziCantiere>, GenericRepository<TResourcesDbContext, MezziCantiere>>();
            services.AddTransient<IGenericRepository<MezziClasse>, GenericRepository<TResourcesDbContext, MezziClasse>>();
            services.AddTransient<IGenericRepository<MezziDocumento>, GenericRepository<TResourcesDbContext, MezziDocumento>>();
            services.AddTransient<IGenericRepository<MezziPatente>, GenericRepository<TResourcesDbContext, MezziPatente>>();
            services.AddTransient<IGenericRepository<MezziPeriodoScadenza>, GenericRepository<TResourcesDbContext, MezziPeriodoScadenza>>();
            services.AddTransient<IGenericRepository<MezziProprietario>, GenericRepository<TResourcesDbContext, MezziProprietario>>();
            services.AddTransient<IGenericRepository<MezziScadenza>, GenericRepository<TResourcesDbContext, MezziScadenza>>();
            services.AddTransient<IGenericRepository<MezziScadenzaTipo>, GenericRepository<TResourcesDbContext, MezziScadenzaTipo>>();
            services.AddTransient<IGenericRepository<MezziTipo>, GenericRepository<TResourcesDbContext, MezziTipo>>();
            services.AddTransient<IGenericRepository<MezziVeicolo>, GenericRepository<TResourcesDbContext, MezziVeicolo>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaMezziVeicoli>, GenericRepository<TResourcesDbContext, ViewGaMezziVeicoli>>();
            services.AddTransient<IGenericRepository<ViewGaMezziDocumenti>, GenericRepository<TResourcesDbContext, ViewGaMezziDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaMezziScadenze>, GenericRepository<TResourcesDbContext, ViewGaMezziScadenze>>();

            #endregion

            return services; 
        }
    }
}
