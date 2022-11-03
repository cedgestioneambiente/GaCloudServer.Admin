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
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts
{
    public class ResourcesDbContext : DbContext,IResourcesDbContext
    {
        #region GaGlobal Tables
        public DbSet<GlobalSede> GlobalSedi { get; set; }
        public DbSet<GlobalCentroCosto> GlobalCentriCosti { get; set; }
        #endregion

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
        public DbSet<ContrattiModalita> GaContrattiModalitas { get; set; }
        public DbSet<ContrattiFornitore> GaContrattiFornitori { get; set; }
        public DbSet<ContrattiDocumento> GaContrattiDocumenti { get; set; }


        #region Views
        public DbSet<ViewGaContrattiUtenti> ViewGaContrattiUtenti { get; set; }
        public DbSet<ViewGaContrattiUtentiOnPermessi> ViewGaContrattiUtentiOnPermessi { get; set; }
        public DbSet<ViewGaContrattiDocumenti> ViewGaContrattiDocumenti { get; set; }
        public DbSet<ViewGaContrattiDocumentiList> ViewGaContrattiDocumentiList { get; set; }
        public DbSet<ViewGaContrattiNumeratori> ViewGaContrattiNumeratori { get; set; }

        #endregion

        #region Sp
        public DbSet<SpGaContrattiNumeratore> SpGaContrattiNumeratori { get; set; }
        public DbSet<SpGaContrattiPermesso> SpGaContrattiPermessi { get; set; }
        public DbSet<SpGaContrattiPermessoMode> SpGaContrattiPermessiModes { get; set; }
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

        #region GaPrenotazioneAuto
        public DbSet<PrenotazioneAutoRegistrazione> GaPrenotazioneAutoRegistrazioni { get; set; }
        public DbSet<PrenotazioneAutoVeicolo> GaPrenotazioneAutoVeicoli { get; set; }
        public DbSet<PrenotazioneAutoSede> GaPrenotazioneAutoSedi { get; set; }

        #region Views
        public DbSet<ViewGaPrenotazioneAutoVeicoli> ViewGaPrenotazioneAutoVeicoli { get; set; }
        public DbSet<ViewGaPrenotazioneAutoRegistrazioni> ViewGaPrenotazioneAutoRegistrazioni { get; set; }
        #endregion

        #endregion

        #region Notification
        public DbSet<NotificationApp> NotificationApps { get; set; }
        public DbSet<NotificationRoleOnApp> NotificationRolesOnApps { get; set; }
        public DbSet<NotificationUserOnApp> NotificationUsersOnApps { get; set; }

        #region Views
        public DbSet<ViewNotificationRolesOnApps> ViewNotificationRolesOnApps { get; set; }
        public DbSet<ViewNotificationUsersOnApps> ViewNotificationUsersOnApps { get; set; }
        #endregion
        #endregion

        #region GaPersonale Tables
        public DbSet<PersonaleDipendente> GaPersonaleDipendenti { get; set; }
        public DbSet<PersonaleQualifica> GaPersonaleQualifiche { get; set; }
        public DbSet<PersonaleAssunzione> GaPersonaleAssunzioni { get; set; }
        public DbSet<PersonaleDipendenteScadenza> GaPersonaleDipendentiScadenze { get; set; }
        public DbSet<PersonaleScadenzaTipo> GaPersonaleScadenzeTipi { get; set; }
        public DbSet<PersonaleScadenzaDettaglio> GaPersonaleScadenzeDettagli { get; set; }

        #region Views
        public DbSet<ViewGaPersonaleUsersOnDipendenti> ViewGaPersonaleUsersOnDipendenti { get; set; }
        public DbSet<ViewGaPersonaleDipendenti> ViewGaPersonaleDipendenti { get; set; }
        public DbSet<ViewGaPersonaleDipendentiScadenze> ViewGaPersonaleDipendentiScadenze { get; set; }
        #endregion

        #endregion

        #region GaCsr Tables
        public DbSet<CsrCodiceCer> GaCsrCodiciCers { get; set; }
        public DbSet<CsrComune> GaCsrComuni { get; set; }
        public DbSet<CsrDestinatario> GaCsrDestinatari { get; set; }
        public DbSet<CsrProduttore> GaCsrProduttori { get; set; }
        public DbSet<CsrRegistrazione> GaCsrRegistrazioni { get; set; }
        public DbSet<CsrRegistrazionePeso> GaCsrRegistrazioniPesi { get; set; }
        public DbSet<CsrRipartizionePercentuale> GaCsrRipartizioniPercentuali { get; set; }
        public DbSet<CsrTrasportatore> GaCsrTrasportatori { get; set; }

        #region Views
        public DbSet<ViewGaCsrCodiciCers> ViewGaCsrCodiciCers { get; set; }
        public DbSet<ViewGaCsrDestinatari> ViewGaCsrDestinatari { get; set; }
        public DbSet<ViewGaCsrExports> ViewGaCsrExports { get; set; }
        public DbSet<ViewGaCsrProduttori> ViewGaCsrProduttori { get; set; }
        public DbSet<ViewGaCsrRegistrazioni> ViewGaCsrRegistrazioni { get; set; }
        public DbSet<ViewGaCsrRegistrazioniPesi> ViewGaCsrRegistrazioniPesi { get; set; }
        public DbSet<ViewGaCsrRipartizioniPercentuali> ViewGaCsrRipartizioniPercentuali { get; set; }
        public DbSet<ViewGaCsrTrasportatori> ViewGaCsrTrasportatori { get; set; }
        #endregion

        #endregion

        #region GaReclami Tables
        public DbSet<ReclamiAzione> GaReclamiAzioni { get; set; }
        public DbSet<ReclamiDocumento> GaReclamiDocumenti { get; set; }
        public DbSet<ReclamiMittente> GaReclamiMittenti { get; set; }
        public DbSet<ReclamiStato> GaReclamiStati { get; set; }
        public DbSet<ReclamiTempoRisposta> GaReclamiTempiRisposte { get; set; }
        public DbSet<ReclamiTipoAzione> GaReclamiTipiAzioni { get; set; }
        public DbSet<ReclamiTipoOrigine> GaReclamiTipiOrigini { get; set; }

        #region Views
        public DbSet<ViewGaReclamiAzioni> ViewGaReclamiAzioni { get; set; }
        public DbSet<ViewGaReclamiDocumenti> ViewGaReclamiDocumenti { get; set; }
        public DbSet<ViewGaReclamiRegistri> ViewGaReclamiRegistri { get; set; }
        #endregion

        #endregion

        #region GaSegnalazioni Tables
        public DbSet<SegnalazioniTipo> GaSegnalazioniTipi { get; set; }
        public DbSet<SegnalazioniStato> GaSegnalazioniStati { get; set; }
        public DbSet<SegnalazioniFoto> GaSegnalazioniFotos { get; set; }
        public DbSet<SegnalazioniDocumento> GaSegnalazioniDocumenti { get; set; }

        #region Views
        public DbSet<ViewGaSegnalazioniDocumenti> ViewGaSegnalazioniDocumenti { get; set; }
        #endregion

        #endregion

        #region EcSegnalazioni Tables
        public DbSet<EcSegnalazioniTipo> EcSegnalazioniTipi { get; set; }
        public DbSet<EcSegnalazioniStato> EcSegnalazioniStati { get; set; }
        public DbSet<EcSegnalazioniFoto> EcSegnalazioniFotos { get; set; }
        public DbSet<EcSegnalazioniDocumento> EcSegnalazioniDocumenti { get; set; }

        #region Views
        public DbSet<ViewEcSegnalazioniDocumenti> ViewEcSegnalazioniDocumenti { get; set; }
        #endregion

        #endregion

        #region GaContactCenter Tables
        public DbSet<ContactCenterComune> GaContactCenterComuni { get; set; }
        public DbSet<ContactCenterProvenienza> GaContactCenterProvenienze { get; set; }
        public DbSet<ContactCenterTipoRichiesta> GaContactCenterTipiRichieste { get; set; }
        public DbSet<ContactCenterStatoRichiesta> GaContactCenterStatiRichieste { get; set; }
        public DbSet<ContactCenterMail> GaContactCenterMails { get; set; }
        public DbSet<ContactCenterAllegato> GaContactCenterAllegati { get; set; }
        public DbSet<ContactCenterMailOnTicket> GaContactCenterMailsOnTickets { get; set; }
        public DbSet<ContactCenterTicket> GaContactCenterTickets { get; set; }
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
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaContrattiUtenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContrattiUtenti))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaContrattiDocumenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContrattiDocumenti))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaContrattiDocumentiList>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContrattiDocumentiList))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaContrattiNumeratori>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContrattiNumeratori))
                    .HasKey(x => x.Id);
            });

            builder.Entity<SpGaContrattiNumeratore>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
            });

            builder.Entity<SpGaContrattiPermesso>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
            });

            builder.Entity<SpGaContrattiPermessoMode>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
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

            #region PrenotazioneAuto
            builder.Entity<ViewGaPrenotazioneAutoRegistrazioni>(entity =>
            {
                entity
                .ToView(nameof(ViewGaPrenotazioneAutoRegistrazioni))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaPrenotazioneAutoVeicoli>(entity =>
            {
                entity
                .ToView(nameof(ViewGaPrenotazioneAutoVeicoli))
                .HasKey(x => x.Id);
            });

            #endregion

            #region Notification
            builder.Entity<ViewNotificationRolesOnApps>(entity =>
            {
                entity
                .ToView(nameof(ViewNotificationRolesOnApps))
                .HasNoKey();
            });

            builder.Entity<ViewNotificationUsersOnApps>(entity =>
            {
                entity
                .ToView(nameof(ViewNotificationUsersOnApps))
                .HasNoKey();
            });
            #endregion

            #region Csr
            builder.Entity<ViewGaCsrCodiciCers>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrCodiciCers))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCsrDestinatari>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrDestinatari))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCsrExports>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrExports))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCsrProduttori>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrProduttori))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCsrRegistrazioni>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrRegistrazioni))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCsrRegistrazioniPesi>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrRegistrazioniPesi))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCsrRipartizioniPercentuali>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrRipartizioniPercentuali))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCsrTrasportatori>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCsrTrasportatori))
                    .HasKey(x => x.Id);
            });
            #endregion

            #region Reclami
            builder.Entity<ViewGaReclamiAzioni>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaReclamiAzioni))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaReclamiDocumenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaReclamiDocumenti))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaReclamiRegistri>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaReclamiRegistri))
                    .HasKey(x => x.Id);
            });

            #endregion

            #region Segnalazioni
            builder.Entity<ViewGaSegnalazioniDocumenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaSegnalazioniDocumenti))
                    .HasKey(x => x.Id);
            });

            #endregion

            #region EcSegnalazioni
            builder.Entity<ViewEcSegnalazioniDocumenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewEcSegnalazioniDocumenti))
                    .HasKey(x => x.Id);
            });

            #endregion

            #region Personale
            builder.Entity<ViewGaPersonaleUsersOnDipendenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleUsersOnDipendenti))
                    .HasKey(x=>x.UserId);
            });

            builder.Entity<ViewGaPersonaleDipendenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleDipendenti))
                    .HasNoKey()
                    .Property(x=>x.Id);
            });

            builder.Entity<ViewGaPersonaleDipendentiScadenze>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleDipendentiScadenze))
                    .HasNoKey()
                    .Property(x => x.Id);
            });
            #endregion

            base.OnModelCreating(builder);

        }
    }
}