using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
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
            services.AddTransient<IGenericRepository<CdrCerDettaglio>, GenericRepository<TResourcesDbContext, CdrCerDettaglio>>();
            services.AddTransient<IGenericRepository<CdrCerOnCentro>,GenericRepository<TResourcesDbContext, CdrCerOnCentro>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaCdrCersOnCentri>, GenericRepository<TResourcesDbContext, ViewGaCdrCersOnCentri>>();
            services.AddTransient<IGenericRepository<ViewGaCdrComuniOnCentri>, GenericRepository<TResourcesDbContext, ViewGaCdrComuniOnCentri>>();
            services.AddTransient<IGenericRepository<ViewGaCdrComuni>, GenericRepository<TResourcesDbContext, ViewGaCdrComuni>>();
            #endregion

            //Contratti
            #region Contratti
            services.AddTransient<IGenericRepository<ContrattiPermesso>, GenericRepository<TResourcesDbContext, ContrattiPermesso>>();
            services.AddTransient<IGenericRepository<ContrattiServizio>, GenericRepository<TResourcesDbContext, ContrattiServizio>>();
            services.AddTransient<IGenericRepository<ContrattiTipologia>, GenericRepository<TResourcesDbContext, ContrattiTipologia>>();
            services.AddTransient<IGenericRepository<ContrattiUtenteOnPermesso>, GenericRepository<TResourcesDbContext, ContrattiUtenteOnPermesso>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaContrattiUtenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiUtentiOnPermessi>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtentiOnPermessi>>();
            #endregion

            return services; 
        }
    }
}
