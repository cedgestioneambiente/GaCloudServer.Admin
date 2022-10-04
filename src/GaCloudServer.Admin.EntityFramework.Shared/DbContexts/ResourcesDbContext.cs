using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts
{
    public class ResourcesDbContext : DbContext,IResourcesDbContext
    {
        #region GaAutorizzazioni Tables
        public DbSet<AutorizzazioniTipo> GaAutorizzazioniTipi { get; set; }
        public DbSet<AutorizzazioniDocumento> GaAutorizzazioniDocumenti { get; set; }
        public DbSet<AutorizzazioniAllegato> GaAutorizzazioniAllegati { get; set; }

        #region Views
        public DbSet<ViewGaAutorizzazioniDocumenti> ViewGaAutorizzazioniDocumenti { get; set; }
        #endregion

        #endregion

        #region GaCdr Tables
        public DbSet<CdrCentro> GaCdrCentri { get; set; }
        public DbSet<CdrCer> GaCdrCers { get; set; }
        public DbSet<CdrCerDettaglio> GaCdrCersDettagli { get; set; }
        public DbSet<CdrCerOnCentro> GaCdrCersOnCentri { get; set; }
        public DbSet<CdrComune> GaCdrComuni { get; set; }
        public DbSet<CdrComuneOnCentro> GaCdrComuniOnCentri { get; set; }
        public DbSet<CdrConferimento> GaCdrConferimenti { get; set; }
        public DbSet<CdrRichiestaViaggio> GaCdrRichiesteViaggi { get; set; }
        public DbSet<CdrStatoRichiesta> GaCdrStatiRichieste { get; set; }
        public DbSet<CdrUtente> GaCdrUtenti { get; set; }

        #region Views
        public DbSet<ViewGaCdrCersOnCentri> ViewGaCdrCersOnCentri { get; set; }
        public DbSet<ViewGaCdrComuniOnCentri> ViewGaCdrComuniOnCentri { get; set; }
        public DbSet<ViewGaCdrComuni> ViewGaCdrComuni { get; set; }
        public DbSet<ViewGaCdrConferimenti> ViewGaCdrConferimenti { get; set; }
        public DbSet<ViewGaCdrRichiesteViaggi> ViewGaCdrRichiesteViaggi { get; set; }
        public DbSet<ViewGaCdrUtenti> ViewGaCdrUtenti { get; set; }
        #endregion

        #endregion

        #region GaContratti Tables
        public DbSet<ContrattiPermesso> GaContrattiPermessi { get; set; }
        public DbSet<ContrattiServizio> GaContrattiServizi { get; set; }
        public DbSet<ContrattiTipologia> GaContrattiTipologie { get; set; }
        public DbSet<ContrattiUtenteOnPermesso> GaContrattiUtentiOnPermessi { get; set; }


        #region Views
        public DbSet<ViewGaContrattiUtenti> ViewGaContrattiUtenti { get; set; }
        public DbSet<ViewGaContrattiUtentiOnPermessi> ViewGaContrattiUtentiOnPermessi { get; set; }
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

        #region GaAziende Tables
        public DbSet<AziendeLista> GaAziendeListe { get; set; }
        #endregion

        #region GaBackOffice

        public DbSet<BackOfficeParametroOnCategoria> GaBackOfficeParametriOnCategorie { get; set; }
        public DbSet<BackOfficeStatoTicket> GaBackOfficeStatiTickets { get; set; }
        public DbSet<BackOfficeTipoTicket> GaBackOfficeTipiTickets { get; set; }
        public DbSet<BackOfficeTicket> GaBackOfficeTickets { get; set; }

        #region Views
        public DbSet<ViewGaBackOfficeNdUtenze> ViewGaBackOfficeNdUtenze { get; set; }
        public DbSet<ViewGaBackOfficeNdUtenzeGrouped> ViewGaBackOfficeNdUtenzeGrouped { get; set; }
        public DbSet<ViewGaBackOfficeUtenzeGrouped> ViewGaBackOfficeUtenzeGrouped { get; set; }
        public DbSet<ViewGaBackOfficeComuni> ViewGaBackOfficeComuni { get; set; }
        public DbSet<ViewGaBackOfficeCategorie> ViewGaBackOfficeCategorie { get; set; }
        #endregion

        #region Sp
        public DbSet<SpGaBackOfficeUtenzeContenitori> SpGaBackOfficeUtenzeContenitori { get; set; }
        public DbSet<SpGaBackOfficeLettureMezzi> SpGaBackOfficeLettureMezzi { get; set; }
        public DbSet<SpGaBackOfficeLettureEmz> SpGaBackOfficeLettureEmz { get; set; }
        #endregion

        #endregion


        public ResourcesDbContext(DbContextOptions<ResourcesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


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

            #region Cdr
            builder.Entity<ViewGaCdrCersOnCentri>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCdrCersOnCentri))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaCdrComuniOnCentri>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCdrComuniOnCentri))
                    .HasNoKey()
                    .Property(x=>x.Id);
            });

            builder.Entity<ViewGaCdrComuni>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCdrComuni))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCdrConferimenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCdrConferimenti))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaCdrRichiesteViaggi>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCdrRichiesteViaggi))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaCdrUtenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCdrUtenti))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            #endregion

            #region Contratti
            builder.Entity<ViewGaContrattiUtentiOnPermessi>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContrattiUtentiOnPermessi))
                    .HasNoKey();             
            });

            builder.Entity<ViewGaContrattiUtenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContrattiUtenti))
                    .HasNoKey();
            });

            #endregion

            #region BackOffice
            builder.Entity<ViewGaBackOfficeNdUtenze>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeNdUtenze))
                .HasNoKey()
                .Property(x => x.CodAzi);
            });

            builder.Entity<ViewGaBackOfficeNdUtenzeGrouped>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeNdUtenzeGrouped))
                .HasNoKey()
                .Property(x => x.CodAzi);
            });

            builder.Entity<ViewGaBackOfficeUtenzeGrouped>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeUtenzeGrouped))
                .HasNoKey()
                .Property(x => x.CodAzi);
            });

            builder.Entity<ViewGaBackOfficeComuni>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeComuni))
                .HasNoKey()
                .Property(x => x.Id);
            });

            builder.Entity<ViewGaBackOfficeCategorie>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeCategorie))
                .HasNoKey()
                .Property(x => x.Tipo);
            });


            builder.Entity<SpGaBackOfficeUtenzeContenitori>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
            });

            builder.Entity<SpGaBackOfficeLettureMezzi>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
            });

            builder.Entity<SpGaBackOfficeLettureEmz>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
            });
            #endregion




            base.OnModelCreating(builder);

        }
    }
}