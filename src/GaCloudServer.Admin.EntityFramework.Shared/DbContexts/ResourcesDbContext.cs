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
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Recapiti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Ost.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.System;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Emz.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views;

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts
{
    public class ResourcesDbContext : DbContext, IResourcesDbContext
    {
        #region GaGlobal Tables
        public DbSet<GlobalSede> GlobalSedi { get; set; }
        public DbSet<GlobalCentroCosto> GlobalCentriCosti { get; set; }
        public DbSet<GlobalSettore> GlobalSettori { get; set; }
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
        public DbSet<ContrattiSoggetto> GaContrattiSoggetti { get; set; }
        public DbSet<ContrattiDocumento> GaContrattiDocumenti { get; set; }
        public DbSet<ContrattiDocumentoAllegato> GaContrattiDocumentiAllegati { get; set; }


        #region Views
        public DbSet<ViewGaContrattiUtenti> ViewGaContrattiUtenti { get; set; }
        public DbSet<ViewGaContrattiUtentiOnPermessi> ViewGaContrattiUtentiOnPermessi { get; set; }
        public DbSet<ViewGaContrattiDocumenti> ViewGaContrattiDocumenti { get; set; }
        public DbSet<ViewGaContrattiDocumentiScadenziario> ViewGaContrattiDocumentiScadenziario { get; set; }
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
        public DbSet<BackOfficeMargine> GaBackOfficeMargini { get; set; }
        public DbSet<BackOfficeZona> GaBackOfficeZone { get; set; }
        public DbSet<BackOfficeStatoTicket> GaBackOfficeStatiTickets { get; set; }
        public DbSet<BackOfficeTipoTicket> GaBackOfficeTipiTickets { get; set; }
        public DbSet<BackOfficeTicket> GaBackOfficeTickets { get; set; }

        #region Views
        public DbSet<ViewGaBackOfficeNdUtenze> ViewGaBackOfficeNdUtenze { get; set; }
        public DbSet<ViewGaBackOfficeNdUtenzeGrouped> ViewGaBackOfficeNdUtenzeGrouped { get; set; }
        public DbSet<ViewGaBackOfficeUtenzeGrouped> ViewGaBackOfficeUtenzeGrouped { get; set; }
        public DbSet<ViewGaBackOfficeComuni> ViewGaBackOfficeComuni { get; set; }
        public DbSet<ViewGaBackOfficeCategorie> ViewGaBackOfficeCategorie { get; set; }
        public DbSet<ViewGaBackOfficeContenitoriLetture> ViewGaBackOfficeContenitoriLetture { get; set; }
        public DbSet<ViewGaBackOfficeZone> ViewGaBackOfficeZone { get; set; }
        public DbSet<ViewGaBackOfficeTipCon> ViewGaBackOfficeTipCon { get; set; }

        public DbSet<ViewGaBackOfficeUtenze> ViewGaBackOfficeUtenze { get; set; }
        public DbSet<ViewGaBackOfficeUtenzePartite> ViewGaBackOfficeUtenzePartite { get; set; }
        public DbSet<ViewGaBackOfficeUtenzePartiteGrp> ViewGaBackOfficeUtenzePartiteGrp { get; set; }
        public DbSet<ViewGaBackOfficeUtenzeDispositivi> ViewGaBackOfficeUtenzeDispositivi { get; set; }
        #endregion

        #region Sp
        public DbSet<SpGaBackOfficeUtenzeContenitori> SpGaBackOfficeUtenzeContenitori { get; set; }
        public DbSet<SpGaBackOfficeLettureMezzi> SpGaBackOfficeLettureMezzi { get; set; }
        public DbSet<SpGaBackOfficeLettureEmz> SpGaBackOfficeLettureEmz { get; set; }
        public DbSet<SpGaBackOfficeUtenze> SpGaBackOfficeUtenze { get; set; }
        public DbSet<SpGaBackOfficeUtenzePartite> SpGaBackOfficeUtenzePartite { get; set; }
        public DbSet<SpGaBackOfficeUtenzeDispositivi> SpGaBackOfficeUtenzeDispositivi { get; set; }
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
        public DbSet<NotificationEvent> NotificationEvents { get; set; }

        #region Views
        public DbSet<ViewNotificationRolesOnApps> ViewNotificationRolesOnApps { get; set; }
        public DbSet<ViewNotificationUsersOnApps> ViewNotificationUsersOnApps { get; set; }
        public DbSet<ViewNotificationEvents> ViewNotificationEvents { get; set; }
        #endregion
        #endregion

        #region GaPersonale Tables
        public DbSet<PersonaleDipendente> GaPersonaleDipendenti { get; set; }
        public DbSet<PersonaleQualifica> GaPersonaleQualifiche { get; set; }
        public DbSet<PersonaleAssunzione> GaPersonaleAssunzioni { get; set; }
        public DbSet<PersonaleScadenza> GaPersonaleScadenze { get; set; }
        public DbSet<PersonaleScadenzaTipo> GaPersonaleScadenzeTipi { get; set; }
        public DbSet<PersonaleScadenzaDettaglio> GaPersonaleScadenzeDettagli { get; set; }
        public DbSet<PersonaleSanzione> GaPersonaleSanzioni { get; set; }
        public DbSet<PersonaleSanzioneDescrizione> GaPersonaleSanzioniDescrizioni { get; set; }
        public DbSet<PersonaleSanzioneMotivo> GaPersonaleSanzioniMotivi { get; set; }
        public DbSet<PersonaleAbilitazione> GaPersonaleAbilitazioni { get; set; }
        public DbSet<PersonaleAbilitazioneTipo> GaPersonaleAbilitazioniTipi { get; set; }
        public DbSet<PersonaleRetributivo> GaPersonaleRetributivi { get; set; }
        public DbSet<PersonaleRetributivoTipo> GaPersonaleRetributiviTipi { get; set; }
        public DbSet<PersonaleSchedaConsegna> GaPersonaleSchedeConsegne { get; set; }
        public DbSet<PersonaleSchedaConsegnaDettaglio> GaPersonaleSchedeConsegneDettagli { get; set; }
        public DbSet<PersonaleArticolo> GaPersonaleArticoli { get; set; }
        public DbSet<PersonaleArticoloModello> GaPersonaleArticoliModelli { get; set; }
        public DbSet<PersonaleArticoloTipologia> GaPersonaleArticoliTipologie { get; set; }
        public DbSet<PersonaleArticoloDpi> GaPersonaleArticoliDpis { get; set; }

        #region Views
        public DbSet<ViewGaPersonaleUsersOnDipendenti> ViewGaPersonaleUsersOnDipendenti { get; set; }
        public DbSet<ViewGaPersonaleDipendenti> ViewGaPersonaleDipendenti { get; set; }
        public DbSet<ViewGaPersonaleScadenze> ViewGaPersonaleScadenze { get; set; }
        public DbSet<ViewGaPersonaleAbilitazioni> ViewGaPersonaleAbilitazioni { get; set; }
        public DbSet<ViewGaPersonaleArticoli> ViewGaPersonaleArticoli { get; set; }
        public DbSet<ViewGaPersonaleNuoveSchede> ViewGaPersonaleNuoveSchede { get; set; }
        public DbSet<ViewGaPersonaleRetributivi> ViewGaPersonaleRetributivi { get; set; }
        public DbSet<ViewGaPersonaleSanzioni> ViewGaPersonaleSanzioni { get; set; }
        public DbSet<ViewGaPersonaleScadenziario> ViewGaPersonaleScadenziario { get; set; }
        public DbSet<ViewGaPersonaleScadenziarioAbilitazioni> ViewGaPersonaleScadenziarioAbilitazioni { get; set; }
        public DbSet<ViewGaPersonaleSchedeConsegne> ViewGaPersonaleSchedeConsegne { get; set; }
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
        public DbSet<SegnalazioniDocumentoImmagine> GaSegnalazioniDocumentiImmagini { get; set; }
        public DbSet<SegnalazioniDocumento> GaSegnalazioniDocumenti { get; set; }

        #region Views
        public DbSet<ViewGaSegnalazioniDocumenti> ViewGaSegnalazioniDocumenti { get; set; }
        #endregion

        #endregion

        #region EcSegnalazioni Tables
        public DbSet<EcSegnalazioniTipo> EcSegnalazioniTipi { get; set; }
        public DbSet<EcSegnalazioniStato> EcSegnalazioniStati { get; set; }
        public DbSet<EcSegnalazioniDocumentoImmagine> EcSegnalazioniDocumentiImmagini { get; set; }
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
        public DbSet<ContactCenterPrintTemplate> ContactCenterPrintTemplates { get; set; }

        #region Views
        public DbSet<ViewGaContactCenterTickets> ViewGaContactCenterTickets { get; set; }
        public DbSet<ViewFoContactCenterTickets> ViewFoContactCenterTickets { get; set; }
        public DbSet<ViewGaContactCenterTicketsIngombranti> ViewGaContactCenterTicketsIngombranti { get; set; }
        #endregion

        #endregion

        #region GaPresenze Tables
        public DbSet<PresenzeStatoRichiesta> GaPresenzeStatiRichieste { get; set; }
        public DbSet<PresenzeRichiesta> GaPresenzeRichieste { get; set; }
        public DbSet<PresenzeTipoOra> GaPresenzeTipiOre { get; set; }
        public DbSet<PresenzeResponsabile> GaPresenzeResponsabili { get; set; }
        public DbSet<PresenzeResponsabileOnSettore> GaPresenzeResponsabiliOnSettori { get; set; }
        public DbSet<PresenzeProfilo> GaPresenzeProfili { get; set; }
        public DbSet<PresenzeDataEsclusa> GaPresenzeDateEscluse { get; set; }
        public DbSet<PresenzeBancaOraUtilizzo> GaPresenzeBancheOreUtilizzi { get; set; }
        public DbSet<PresenzeDipendente> GaPresenzeDipendenti { get; set; }
        public DbSet<PresenzeOrario> GaPresenzeOrari { get; set; }
        public DbSet<PresenzeOrarioGiornata> GaPresenzeOrariGiornate { get; set; }


        #region Views
        public DbSet<ViewGaPresenzeResponsabili> ViewGaPresenzeResponsabili { get; set; }
        public DbSet<ViewGaPresenzeResponsabiliOnSettori> ViewGaPresenzeResponsabiliOnSettori { get; set; }
        public DbSet<ViewGaPresenzeDipendenti> ViewGaPresenzeDipendenti { get; set; }
        public DbSet<ViewGaPresenzeOrariGiornate> ViewGaPresenzeOrariGiornate { get; set; }
        public DbSet<ViewGaPresenzeRichieste> ViewGaPresenzeRichieste { get; set; }
        public DbSet<ViewGaPresenzeRichiestaMail> ViewGaPresenzeRichiestaMail { get; set; }
        public DbSet<ViewGaPresenzeRichiesteRisorse> ViewGaPresenzeRichiesteRisorse { get; set; }
        public DbSet<ViewGaPresenzeRichiesteEventi> ViewGaPresenzeRichiesteEventi { get; set; }
        public DbSet<ViewGaPresenzeRichiesteQualificheRisorse> ViewGaPresenzeRichiesteQualificheRisorse { get; set; }
        public DbSet<ViewGaPresenzeRichiesteQualificheEventi> ViewGaPresenzeRichiesteQualificheEventi { get; set; }

        #endregion

        #region Widget
        public DbSet<WidgetGaPresenzeSchedule> WidgetGaPresenzeSchedules { get; set; }
        #endregion

        #endregion

        #region GaRecapiti Tables

        #region Views
        public DbSet<ViewGaRecapitiContatti> ViewGaRecapitiContatti { get; set; }
        #endregion

        #endregion

        #region Mail Tables
        public DbSet<MailJob> MailJobs { get; set; }
        #endregion

        #region Ost Tables
        public DbSet<ViewOstTickets> ViewOstTickets { get; set; }
        #endregion

        #region GaPrevisio
        public DbSet<ViewGaPrevisioOdsReport> ViewGaPrevisioOdsReport { get; set; }
        public DbSet<ViewGaPrevisioOdsServiziReport> ViewGaPrevisioOdsServiziReport { get; set; }
        #endregion

        #region Shortcut
        public DbSet<ShortcutLink> ShortcutLinks { get; set; }
        public DbSet<ShortcutItem> ShortcutItems { get; set; }

        #region Views
        public DbSet<ViewShortcutItems> ViewShortcutItems { get; set; }
        #endregion
        #endregion

        #region Progetti
        public DbSet<ProgettiWork> GaProgettiWorks { get; set; }
        public DbSet<ProgettiJob> GaProgettiJobs { get; set; }
        public DbSet<ProgettiJobAllegato> GaProgettiJobAllegati { get; set; }
        public DbSet<ProgettiWorkSetting> GaProgettiWorkSettings { get; set; }

        #region Views
        public DbSet<ViewGaProgettiJobs> ViewGaProgettiJobs { get; set; }
        #endregion
        #endregion

        #region QueryBuilder
        public DbSet<QueryBuilderParamType> QueryBuilderParamTypes { get; set; }
        public DbSet<QueryBuilderSection> QueryBuilderSections { get; set; }
        public DbSet<QueryBuilderParamOnScript> QueryBuilderParamOnScripts { get; set; }
        public DbSet<QueryBuilderScript> QueryBuilderScripts { get; set; }

        #region Views
        public DbSet<ViewQueryBuilderParamOnScripts> ViewQueryBuilderParamOnScripts { get; set; }
        public DbSet<ViewQueryBuilderScripts> ViewQueryBuilderScripts { get; set; }
        #endregion
        #endregion

        #region Dashboard
        public DbSet<DashboardType> DashboardTypes { get; set; }
        public DbSet<DashboardSection> DashboardSections { get; set; }
        public DbSet<DashboardItem> DashboardItems { get; set; }
        public DbSet<DashboardStore> DashboardStores { get; set; }

        #region Views
        public DbSet<ViewDashboardItems> ViewDashboardItems { get; set; }
        public DbSet<ViewDashboardStores> ViewDashboardStores { get; set; }
        #endregion
        #endregion

        #region Tasks
        public DbSet<TasksTag> TasksTags { get; set; }
        public DbSet<TasksItem> TasksItems { get; set; }

        #region Views
        public DbSet<ViewTasks> ViewTasks { get; set; }
        public DbSet<ViewTasksTags> ViewTasksTags { get; set; }
        #endregion
        #endregion

        #region System
        public DbSet<SystemVersion> SystemVersions { get; set; }
        #endregion

        #region Consorzio
        public DbSet<ConsorzioCer> ConsorzioCers { get; set; }
        public DbSet<ConsorzioSmaltimento> ConsorzioSmaltimenti { get; set; }
        public DbSet<ConsorzioComune> ConsorzioComuni { get; set; }
        public DbSet<ConsorzioProduttore> ConsorzioProduttori { get; set; }
        public DbSet<ConsorzioDestinatario> ConsorzioDestinatari { get; set; }
        public DbSet<ConsorzioTrasportatore> ConsorzioTrasportatori { get; set; }
        public DbSet<ConsorzioRegistrazione> ConsorzioRegistrazioni { get; set; }
        public DbSet<ConsorzioRegistrazioneAllegato> ConsorzioRegistrazioniAllegati { get; set; }
        public DbSet<ConsorzioPeriodo> ConsorzioPeriodi { get; set; }
        public DbSet<ConsorzioOperazione> ConsorzioOperazioni { get; set; }
        public DbSet<ConsorzioImportTask> ConsorzioImportsTasks { get; set; }

        #region Views
        public DbSet<ViewConsorzioCers> ViewConsorzioCers { get; set; }
        public DbSet<ViewConsorzioProduttori> ViewConsorzioProduttori { get; set; }
        public DbSet<ViewConsorzioDestinatari> ViewConsorzioDestinatari { get; set; }
        public DbSet<ViewConsorzioTrasportatori> ViewConsorzioTrasportatori { get; set; }
        public DbSet<ViewConsorzioRegistrazioni> ViewConsorzioRegistrazioni { get; set; }
        public DbSet<ViewConsorzioComuni> ViewConsorzioComuni { get; set; }
        public DbSet<ViewConsorzioImportsTasks> ViewConsorzioImportsTasks { get; set; }
        #endregion

        #endregion

        #region Crm
        public DbSet<CrmEventState> GaCrmEventStates { get; set; }
        public DbSet<CrmEventArea> GaCrmEventAreas { get; set; }
        public DbSet<CrmEventComune> GaCrmEventComuni { get; set; }
        public DbSet<CrmEvent> GaCrmEvents { get; set; }
        public DbSet<CrmEventDevice> GaCrmEventDevices { get; set; }
        public DbSet<CrmTicket> GaCrmTickets { get; set; }
        public DbSet<CrmTicketTag> GaCrmTicketTags { get; set; }
        public DbSet<CrmTicketAllegato> GaCrmTicketAllegati { get; set; }


        #region Views
        public DbSet<ViewGaCrmCanali> ViewGaCrmCanali { get; set; }
        public DbSet<ViewGaCrmCausali> ViewGaCrmCausali { get; set; }
        public DbSet<ViewGaCrmCausaliTypes> ViewGaCrmCausaliTypes { get; set; }
        public DbSet<ViewGaCrmState> ViewGaCrmState { get; set; }
        public DbSet<ViewGaCrmTickets> ViewGaCrmTickets { get; set; }
        public DbSet<ViewGaCrmCalendarTickets> ViewGaCrmCalendarTickets { get; set; }
        public DbSet<ViewGaCrmEventJobs> ViewGaCrmEventJobs { get; set; }
        #endregion
        #endregion

        #region GaPrenotazioneLocali
        public DbSet<PrenotazioneLocaliRegistrazione> GaPrenotazioneLocaliRegistrazioni { get; set; }
        public DbSet<PrenotazioneLocaliUfficio> GaPrenotazioneLocaliUffici { get; set; }
        public DbSet<PrenotazioneLocaliSede> GaPrenotazioneLocaliSedi { get; set; }

        #region Views
        public DbSet<ViewGaPrenotazioneLocaliUffici> ViewGaPrenotazioneLocaliUffici { get; set; }
        public DbSet<ViewGaPrenotazioneLocaliRegistrazioni> ViewGaPrenotazioneLocaliRegistrazioni { get; set; }
        #endregion

        #endregion

        #region Emz

        #region Views
        public DbSet<ViewEmzWhiteList> ViewEmzWhiteList { get; set; }
        #endregion
        #endregion

        #region GaDispositivi

        public DbSet<DispositiviCategoria> GaDispositiviCategorie { get; set; }
        public DbSet<DispositiviClasse> GaDispositiviClassi { get; set; }
        public DbSet<DispositiviItem> GaDispositiviItems { get; set; }
        public DbSet<DispositiviMarca> GaDispositiviMarche { get; set; }
        public DbSet<DispositiviModello> GaDispositiviModelli { get; set; }
        public DbSet<DispositiviOnDipendente> GaDispositiviOnDipendenti { get; set; }
        public DbSet<DispositiviStock> GaDispositiviStocks { get; set; }
        public DbSet<DispositiviTipologia> GaDispositiviTipologie { get; set; }
        public DbSet<DispositiviModulo> GaDispositiviModuli { get; set; }
        public DbSet<DispositiviOnModulo> GaDispositiviOnModuli { get; set; }



        #region Views
        public DbSet<ViewGaDispositiviItems> ViewGaDispositiviItems { get; set; }
        public DbSet<ViewGaDispositiviOnDipendenti> ViewGaDispositiviOnDipendenti { get; set; }
        public DbSet<ViewGaDispositiviStocks> ViewGaDispositiviStocks { get; set; }
        public DbSet<ViewGaDispositiviOnModuli> ViewGaDispositiviOnModuli { get; set; }

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
                    .Property(x => x.Id);
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
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCdrRichiesteViaggi>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaCdrRichiesteViaggi))
                    .HasKey(x => x.Id);
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

            builder.Entity<ViewGaContrattiDocumentiScadenziario>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContrattiDocumentiScadenziario))
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


            builder.Entity<ViewGaBackOfficeContenitoriLetture>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeContenitoriLetture))
                .HasNoKey()
                .Property(x => x.Identi1);
            });

            builder.Entity<ViewGaBackOfficeZone>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeZone))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaBackOfficeTipCon>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeTipCon))
                .HasNoKey();
            });


            builder.Entity<ViewGaBackOfficeUtenze>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeUtenze))
                .HasNoKey();
            });

            builder.Entity<ViewGaBackOfficeUtenzePartite>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeUtenzePartite))
                .HasNoKey();
            });

            builder.Entity<ViewGaBackOfficeUtenzePartiteGrp>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeUtenzePartiteGrp))
                .HasNoKey();
            });

            builder.Entity<ViewGaBackOfficeUtenzeDispositivi>(entity =>
            {
                entity
                .ToView(nameof(ViewGaBackOfficeUtenzeDispositivi))
                .HasNoKey();
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

            builder.Entity<SpGaBackOfficeUtenze>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
            });

            builder.Entity<SpGaBackOfficeUtenzePartite>(entity =>
            {
                entity
                .HasNoKey()
                .ToView(null);
            });


            builder.Entity<SpGaBackOfficeUtenzeDispositivi>(entity =>
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

            builder.Entity<ViewNotificationEvents>(entity =>
            {
                entity
                .ToView(nameof(ViewNotificationEvents))
                .HasKey(x => x.Id);
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
                    .HasNoKey()
                    .Property(x => x.Id);
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
                    .HasNoKey()
                    .Property(x => x.Id);
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
                    .HasKey(x => x.UserId);
            });

            builder.Entity<ViewGaPersonaleDipendenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleDipendenti))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleScadenze>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleScadenze))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleAbilitazioni>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleAbilitazioni))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleArticoli>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleArticoli))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleNuoveSchede>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleNuoveSchede))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleRetributivi>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleRetributivi))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleSanzioni>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleSanzioni))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleScadenziario>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleScadenziario))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleScadenziarioAbilitazioni>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleScadenziarioAbilitazioni))
                    .HasNoKey()
                    .Property(x => x.Id);
            });

            builder.Entity<ViewGaPersonaleSchedeConsegne>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPersonaleSchedeConsegne))
                    .HasNoKey()
                    .Property(x => x.Id);
            });
            #endregion

            #region ContactCenter
            builder.Entity<ViewGaContactCenterTickets>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContactCenterTickets))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewFoContactCenterTickets>(entity =>
            {
                entity
                    .ToView(nameof(ViewFoContactCenterTickets))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaContactCenterTicketsIngombranti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaContactCenterTicketsIngombranti))
                    .HasKey(x => x.Id);
            });


            #endregion

            #region Presenze
            builder.Entity<ViewGaPresenzeResponsabili>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeResponsabili))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaPresenzeResponsabiliOnSettori>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeResponsabiliOnSettori))
                    .HasNoKey();
            });

            builder.Entity<ViewGaPresenzeDipendenti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeDipendenti))
                    .HasNoKey();
            });

            builder.Entity<ViewGaPresenzeOrariGiornate>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeOrariGiornate))
                    .HasKey(x => x.Id);
            });


            builder.Entity<ViewGaPresenzeRichieste>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeRichieste))
                    .HasKey(x => x.Id);
            });


            builder.Entity<ViewGaPresenzeRichiestaMail>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeRichiestaMail))
                    .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaPresenzeRichiesteRisorse>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeRichiesteRisorse))
                    .HasNoKey();
            });

            builder.Entity<ViewGaPresenzeRichiesteEventi>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeRichiesteEventi))
                    .HasNoKey();
            });


            builder.Entity<ViewGaPresenzeRichiesteQualificheRisorse>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeRichiesteQualificheRisorse))
                    .HasNoKey();
            });

            builder.Entity<ViewGaPresenzeRichiesteQualificheEventi>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaPresenzeRichiesteQualificheEventi))
                    .HasNoKey();
            });

            builder.Entity<WidgetGaPresenzeSchedule>(entity =>
            {
                entity
                    .ToView(nameof(WidgetGaPresenzeSchedule))
                    .HasNoKey();
            });

            #endregion

            #region Recapiti
            builder.Entity<ViewGaRecapitiContatti>(entity =>
            {
                entity
                    .ToView(nameof(ViewGaRecapitiContatti))
                .HasNoKey()
                .Property(x => x.Id);
            });

            #endregion

            #region Ost
            builder.Entity<ViewOstTickets>(entity =>
            {
                entity
                    .ToView(nameof(ViewOstTickets))
                .HasNoKey()
                .Property(x => x.Id);
            });

            #endregion

            #region Previsio
            builder.Entity<ViewGaPrevisioOdsReport>(entity =>
            {
                entity
                .ToView(nameof(ViewGaPrevisioOdsReport))
                .HasNoKey()
                .Property(x => x.IDservizio);
            });

            builder.Entity<ViewGaPrevisioOdsServiziReport>(entity =>
            {
                entity
                .ToView(nameof(ViewGaPrevisioOdsServiziReport))
                .HasNoKey()
                .Property(x => x.IDservizio);
            });
            #endregion

            #region Shortcut
            builder.Entity<ViewShortcutItems>(entity =>
            {
                entity
                .ToView(nameof(ViewShortcutItems))
                .HasKey(x=>x.Id);
            });
            #endregion

            #region QueryBuilder
            builder.Entity<ViewQueryBuilderParamOnScripts>(entity =>
            {
                entity
                .ToView(nameof(ViewQueryBuilderParamOnScripts))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewQueryBuilderScripts>(entity =>
            {
                entity
                .ToView(nameof(ViewQueryBuilderScripts))
                .HasKey(x => x.Id);
            });
            #endregion

            #region Dashboard
            builder.Entity<ViewDashboardItems>(entity =>
            {
                entity
                .ToView(nameof(ViewDashboardItems))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewDashboardStores>(entity =>
            {
                entity
                .ToView(nameof(ViewDashboardStores))
                .HasNoKey();
            });
            #endregion

            #region Progetti
            builder.Entity<ViewGaProgettiJobs>(entity =>
            {
                entity
                .ToView(nameof(ViewGaProgettiJobs))
                .HasKey(x => x.Id);
            });


            #endregion

            #region Tasks
            builder.Entity<ViewTasks>(entity =>
            {
                entity
                .ToView(nameof(ViewTasks))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewTasksTags>(entity =>
            {
                entity
                .ToView(nameof(ViewTasksTags))
                .HasNoKey();
            });


            #endregion

            #region Consorzio

            builder.Entity<ViewConsorzioCers>(entity =>
            {
                entity
                .ToView(nameof(ViewConsorzioCers))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewConsorzioProduttori>(entity =>
            {
                entity
                .ToView(nameof(ViewConsorzioProduttori))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewConsorzioDestinatari>(entity =>
            {
                entity
                .ToView(nameof(ViewConsorzioDestinatari))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewConsorzioTrasportatori>(entity =>
            {
                entity
                .ToView(nameof(ViewConsorzioTrasportatori))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewConsorzioRegistrazioni>(entity =>
            {
                entity
                .ToView(nameof(ViewConsorzioRegistrazioni))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewConsorzioComuni>(entity =>
            {
                entity
                .ToView(nameof(ViewConsorzioComuni))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewConsorzioImportsTasks>(entity =>
            {
                entity
                .ToView(nameof(ViewConsorzioImportsTasks))
                .HasKey(x => x.Id);
            });


            #endregion

            #region Crm

            builder.Entity<ViewGaCrmCanali>(entity =>
            {
                entity
                .ToView(nameof(ViewGaCrmCanali))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCrmCausali>(entity =>
            {
                entity
                .ToView(nameof(ViewGaCrmCausali))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCrmCausaliTypes>(entity =>
            {
                entity
                .ToView(nameof(ViewGaCrmCausaliTypes))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCrmState>(entity =>
            {
                entity
                .ToView(nameof(ViewGaCrmState))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCrmTickets>(entity =>
            {
                entity
                .ToView(nameof(ViewGaCrmTickets))
                .HasKey(x => x.Id);
            });


            builder.Entity<ViewGaCrmCalendarTickets>(entity =>
            {
                entity
                .ToView(nameof(ViewGaCrmCalendarTickets))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaCrmEventJobs>(entity =>
            {
                entity
                .ToView(nameof(ViewGaCrmEventJobs))
                .HasNoKey();
            });
            #endregion

            #region PrenotazioneLocali
            builder.Entity<ViewGaPrenotazioneLocaliRegistrazioni>(entity =>
            {
                entity
                .ToView(nameof(ViewGaPrenotazioneLocaliRegistrazioni))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaPrenotazioneLocaliUffici>(entity =>
            {
                entity
                .ToView(nameof(ViewGaPrenotazioneLocaliUffici))
                .HasKey(x => x.Id);
            });

            #endregion

            #region Emz

            builder.Entity<ViewEmzWhiteList>(entity =>
            {
                entity
                .ToView(nameof(ViewEmzWhiteList))
                .HasNoKey();
            });
            #endregion

            #region Dispositivi

            builder.Entity<ViewGaDispositiviItems>(entity =>
            {
                entity
                .ToView(nameof(ViewGaDispositiviItems))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaDispositiviStocks>(entity =>
            {
                entity
                .ToView(nameof(ViewGaDispositiviStocks))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaDispositiviOnDipendenti>(entity =>
            {
                entity
                .ToView(nameof(ViewGaDispositiviOnDipendenti))
                .HasKey(x => x.Id);
            });

            builder.Entity<ViewGaDispositiviOnModuli>(entity =>
            {
                entity
                .ToView(nameof(ViewGaDispositiviOnModuli))
                .HasKey(x => x.Id);
            });

            #endregion


            base.OnModelCreating(builder);

        }
    }
}