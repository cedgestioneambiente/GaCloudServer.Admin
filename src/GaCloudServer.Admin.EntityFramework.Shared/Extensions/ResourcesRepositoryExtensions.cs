using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
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

            return services; 
        }
    }
}
