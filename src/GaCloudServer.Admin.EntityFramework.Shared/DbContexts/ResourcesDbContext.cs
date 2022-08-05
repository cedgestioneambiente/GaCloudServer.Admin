using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts
{
    public class ResourcesDbContext : DbContext,IResourcesDbContext
    {
        public DbSet<AutorizzazioneTipo> GaAutorizzazioniTipi { get; set; }

        public ResourcesDbContext(DbContextOptions<ResourcesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

    }
}
