using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Extensions
{
    public static class ResourcesServiceExtensions
    {
        public static IServiceCollection AddResourcesServices<TResourcesDbContext>(this IServiceCollection services)
            where TResourcesDbContext:DbContext,IResourcesDbContext
        {
            services.AddTransient<IGaAutorizzazioniService, GaAutorizzazioniService>();
            services.AddTransient<IGaContrattiService, GaContrattiService>();
            services.AddTransient<IGaCdrService, GaCdrService>();
            services.AddTransient<IUnitOfWork, UnitOfWork<TResourcesDbContext>>();

            return services;
        }
    }
}
