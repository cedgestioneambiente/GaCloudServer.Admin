using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
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

        #region GaComunicati Tables
        public DbSet<ComunicatiDocumento> GaComunicatiDocumenti { get; set; }
        #endregion

        #region GaMezzi Tables
        public DbSet<MezziVeicolo> GaMezziVeicoli { get; set; }
        public DbSet<MezziAlimentazione> GaMezziAlimentazioni { get; set; }
        public DbSet<MezziCantiere> GaMezziCantieri { get; set; }
        public DbSet<MezziClasse> GaMezziClassi { get; set; }
        public DbSet<MezziDocumento> GaMezziDocumenti { get; set; }
        public DbSet<MezziPatente> GaMezziPatenti { get; set; }
        public DbSet<MezziPeriodoScadenza> GaMezziPeriodiScadenze { get; set; }
        public DbSet<MezziProprietario> GaMezziProprietari { get; set; }
        public DbSet<MezziScadenza> GaMezziScadenze { get; set; }
        public DbSet<MezziScadenzaTipo> GaMezziScadenzeTipi { get; set; }
        public DbSet<MezziTipo> GaMezziTipi { get; set; }

        #region Views
        public DbSet<ViewGaMezziVeicoli> ViewGaMezziVeicoli { get; set; }
        public DbSet<ViewGaMezziScadenze> ViewGaMezziScadenze { get; set; }
        public DbSet<ViewGaMezziDocumenti> ViewGaMezziDocumenti { get; set; }
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

            #region Mezzi

            builder.Entity<ViewGaMezziVeicoli>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaMezziVeicoli))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaMezziScadenze>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaMezziScadenze))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaMezziDocumenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaMezziDocumenti))
                    .HasKey(x => x.Id);
            });

            #endregion

            #endregion

            base.OnModelCreating(builder);

        }
    }
}
