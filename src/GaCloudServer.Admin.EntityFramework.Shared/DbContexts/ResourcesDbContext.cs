using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
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
        #region GaAutorizzazioni Tables
        public DbSet<AutorizzazioniTipo> GaAutorizzazioniTipi { get; set; }
        public DbSet<AutorizzazioniDocumento> GaAutorizzazioniDocumenti { get; set; }
        public DbSet<AutorizzazioniAllegato> GaAutorizzazioniAllegati { get; set; }

        //Views
        public DbSet<ViewGaAutorizzazioniDocumenti> ViewGaAutorizzazioniDocumenti { get; set; }
        #endregion

        #region GaContratti Tables
        //public DbSet<Contratto> GaContratti { get; set; }
        //public DbSet<ContrattoFornitore> GaContrattiFornitori { get; set; }
        //public DbSet<ContrattoModalita> GaContrattiModalitas { get; set; }
        public DbSet<ContrattoPermesso> GaContrattiPermessi { get; set; }
        public DbSet<ContrattoServizio> GaContrattiServizi { get; set; }
        public DbSet<ContrattoTipologia> GaContrattiTipologie { get; set; }
        public DbSet<ContrattoUtenteOnPermesso> GaContrattiUtentiOnPermessi { get; set; }

        //#region Views
        //public DbSet<ViewGaContrattoUtente> ViewGaContrattiUtenti { get; set; }
        //public DbSet<ViewGaContrattoUtenteOnPermesso> ViewGaContrattiUtentiOnPermessi { get; set; }
        //public DbSet<ViewGaContratto> ViewGaContratti { get; set; }
        //public DbSet<ViewGaContrattoList> ViewGaContrattiList { get; set; }
        //public DbSet<ViewGaContrattoNumeratore> ViewGaContrattiNumeratori { get; set; }
        //#endregion

        //#region Sp
        //public DbSet<SpGaContrattoNumeratore> SpGaContrattiNumeratori { get; set; }
        //public DbSet<SpGaContrattoPermesso> SpGaContrattiPermessi { get; set; }
        //public DbSet<SpGaContrattoPermessoMode> SpGaContrattiPermessiMode { get; set; }
        //#endregion

        #endregion

        #region GaCdr Tables
        public DbSet<CdrCentro> GaCdrCentri { get; set; }
        public DbSet<CdrCer> GaCdrCers { get; set; }
        public DbSet<CdrCerDettaglio> GaCdrCersDettagli { get; set; }
        public DbSet<CdrCerOnCentro> GaCdrCersOnCentri { get; set; }
        public DbSet<CdrComune> GaCdrComuni { get; set; }
        public DbSet<CdrComuneOnCentro> GaCdrComuniOnCentri { get; set; }


        #region Views

        #endregion

        #endregion

        public ResourcesDbContext(DbContextOptions<ResourcesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Views

            #region Autorizzazioni

            builder.Entity<ViewGaAutorizzazioniDocumenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaAutorizzazioniDocumenti))
                    .HasKey(x => x.Id);
            });

            #endregion

            #endregion

            base.OnModelCreating(builder);

        }
    }
}
