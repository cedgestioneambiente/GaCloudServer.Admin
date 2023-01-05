using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
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

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces
{
    public interface IResourcesDbContext
    {
        #region GaGlobal Tables
        DbSet<GlobalSede> GlobalSedi { get; set; }
        DbSet<GlobalCentroCosto> GlobalCentriCosti { get; set; }
        DbSet<GlobalSettore> GlobalSettori { get; set; }
        #endregion

        #region GaAutorizzazioni Tables
        DbSet<AutorizzazioniTipo> GaAutorizzazioniTipi { get; set; }
        DbSet<AutorizzazioniDocumento> GaAutorizzazioniDocumenti { get; set; }
        DbSet<AutorizzazioniAllegato> GaAutorizzazioniAllegati { get; set; }

        #region Views
        DbSet<ViewGaAutorizzazioniDocumenti> ViewGaAutorizzazioniDocumenti { get; set; }
        #endregion
        #endregion

        #region GaCdr Tables
        DbSet<CdrCentro> GaCdrCentri { get; set; }
        DbSet<CdrCer> GaCdrCers { get; set; }
        DbSet<CdrCerDettaglio> GaCdrCersDettagli { get; set; }
        DbSet<CdrCerOnCentro> GaCdrCersOnCentri { get; set; }
        DbSet<CdrComune> GaCdrComuni { get; set; }
        DbSet<CdrComuneOnCentro> GaCdrComuniOnCentri { get; set; }
        DbSet<CdrConferimento> GaCdrConferimenti { get; set; }
        DbSet<CdrRichiestaViaggio> GaCdrRichiesteViaggi { get; set; }
        DbSet<CdrStatoRichiesta> GaCdrStatiRichieste { get; set; }
        DbSet<CdrUtente> GaCdrUtenti { get; set; }

        #region Views
        DbSet<ViewGaCdrCersOnCentri> ViewGaCdrCersOnCentri { get; set; }
        DbSet<ViewGaCdrComuniOnCentri> ViewGaCdrComuniOnCentri { get; set; }
        DbSet<ViewGaCdrComuni> ViewGaCdrComuni { get; set; }
        DbSet<ViewGaCdrConferimenti> ViewGaCdrConferimenti { get; set; }
        DbSet<ViewGaCdrRichiesteViaggi> ViewGaCdrRichiesteViaggi { get; set; }
        DbSet<ViewGaCdrUtenti> ViewGaCdrUtenti { get; set; }
        #endregion
        #endregion

        #region GaContratti Tables
        DbSet<ContrattiPermesso> GaContrattiPermessi { get; set; }
        DbSet<ContrattiServizio> GaContrattiServizi { get; set; }
        DbSet<ContrattiTipologia> GaContrattiTipologie { get; set; }
        DbSet<ContrattiUtenteOnPermesso> GaContrattiUtentiOnPermessi { get; set; }
        DbSet<ContrattiModalita> GaContrattiModalitas { get; set; }
        DbSet<ContrattiFornitore> GaContrattiFornitori { get; set; }
        DbSet<ContrattiDocumento> GaContrattiDocumenti { get; set; }

        #region Views
        DbSet<ViewGaContrattiUtenti> ViewGaContrattiUtenti { get; set; }
        DbSet<ViewGaContrattiUtentiOnPermessi> ViewGaContrattiUtentiOnPermessi { get; set; }
        DbSet<ViewGaContrattiDocumenti> ViewGaContrattiDocumenti { get; set; }
        DbSet<ViewGaContrattiDocumentiList> ViewGaContrattiDocumentiList { get; set; }
        DbSet<ViewGaContrattiNumeratori> ViewGaContrattiNumeratori { get; set; }
        #endregion

        # region Sp
        DbSet<SpGaContrattiNumeratore> SpGaContrattiNumeratori { get; set; }
        DbSet<SpGaContrattiPermesso> SpGaContrattiPermessi { get; set; }
        DbSet<SpGaContrattiPermessoMode> SpGaContrattiPermessiModes { get; set; }

        #endregion
        #endregion

        #region GaComunicati Tables
        DbSet<ComunicatiDocumento> GaComunicatiDocumenti { get; set; }
        #endregion

        #region GaMezzi Tables
        DbSet<MezziVeicolo> GaMezziVeicoli { get; set; }
        DbSet<MezziAlimentazione> GaMezziAlimentazioni { get; set; }
        DbSet<MezziClasse> GaMezziClassi { get; set; }
        DbSet<MezziDocumento> GaMezziDocumenti { get; set; }
        DbSet<MezziPatente> GaMezziPatenti { get; set; }
        DbSet<MezziPeriodoScadenza> GaMezziPeriodiScadenze { get; set; }
        DbSet<MezziProprietario> GaMezziProprietari { get; set; }
        DbSet<MezziScadenza> GaMezziScadenze { get; set; }
        DbSet<MezziScadenzaTipo> GaMezziScadenzeTipi { get; set; }
        DbSet<MezziTipo> GaMezziTipi { get; set; }

        #region Views
        DbSet<ViewGaMezziVeicoli> ViewGaMezziVeicoli { get; set; }
        DbSet<ViewGaMezziScadenze> ViewGaMezziScadenze { get; set; }
        DbSet<ViewGaMezziDocumenti> ViewGaMezziDocumenti { get; set; }
        #endregion

        #endregion

        #region GaAziende Tables
        DbSet<AziendeLista> GaAziendeListe { get; set; }
        #endregion

        #region GaBackOffice
        DbSet<BackOfficeParametroOnCategoria> GaBackOfficeParametriOnCategorie { get; set; }
        DbSet<BackOfficeStatoTicket> GaBackOfficeStatiTickets { get; set; }
        DbSet<BackOfficeTipoTicket> GaBackOfficeTipiTickets { get; set; }
        DbSet<BackOfficeTicket> GaBackOfficeTickets { get; set; }

        #region Views
        DbSet<ViewGaBackOfficeNdUtenze> ViewGaBackOfficeNdUtenze { get; set; }
        DbSet<ViewGaBackOfficeNdUtenzeGrouped> ViewGaBackOfficeNdUtenzeGrouped { get; set; }
        DbSet<ViewGaBackOfficeUtenzeGrouped> ViewGaBackOfficeUtenzeGrouped { get; set; }
        DbSet<ViewGaBackOfficeComuni> ViewGaBackOfficeComuni { get; set; }
        DbSet<ViewGaBackOfficeCategorie> ViewGaBackOfficeCategorie { get; set; }
        #endregion

        #region Sp
        DbSet<SpGaBackOfficeUtenzeContenitori> SpGaBackOfficeUtenzeContenitori { get; set; }
        DbSet<SpGaBackOfficeLettureMezzi> SpGaBackOfficeLettureMezzi { get; set; }
        DbSet<SpGaBackOfficeLettureEmz> SpGaBackOfficeLettureEmz { get; set; }
        #endregion
        #endregion

        #region GaPrenotazioneAuto
        DbSet<PrenotazioneAutoRegistrazione> GaPrenotazioneAutoRegistrazioni { get; set; }
        DbSet<PrenotazioneAutoVeicolo> GaPrenotazioneAutoVeicoli { get; set; }
        DbSet<PrenotazioneAutoSede> GaPrenotazioneAutoSedi { get; set; }

        #region Views
        DbSet<ViewGaPrenotazioneAutoVeicoli> ViewGaPrenotazioneAutoVeicoli { get; set; }
        DbSet<ViewGaPrenotazioneAutoRegistrazioni> ViewGaPrenotazioneAutoRegistrazioni { get; set; }
        #endregion

        #endregion

        #region Notification
        DbSet<NotificationApp> NotificationApps { get; set; }
        DbSet<NotificationRoleOnApp> NotificationRolesOnApps { get; set; }
        DbSet<NotificationUserOnApp> NotificationUsersOnApps { get; set; }
        DbSet<NotificationEvent> NotificationEvents { get; set; }

        #region Views
        DbSet<ViewNotificationRolesOnApps> ViewNotificationRolesOnApps { get; set; }
        DbSet<ViewNotificationUsersOnApps> ViewNotificationUsersOnApps { get; set; }
        DbSet<ViewNotificationEvents> ViewNotificationEvents { get; set; }
        #endregion
        #endregion

        #region GaPersonale Tables
        DbSet<PersonaleDipendente> GaPersonaleDipendenti { get; set; }
        DbSet<PersonaleQualifica> GaPersonaleQualifiche { get; set; }
        DbSet<PersonaleAssunzione> GaPersonaleAssunzioni { get; set; }
        DbSet<PersonaleScadenza> GaPersonaleScadenze { get; set; }
        DbSet<PersonaleScadenzaTipo> GaPersonaleScadenzeTipi { get; set; }
        DbSet<PersonaleScadenzaDettaglio> GaPersonaleScadenzeDettagli { get; set; }
        DbSet<PersonaleSanzione> GaPersonaleSanzioni { get; set; }
        DbSet<PersonaleSanzioneDescrizione> GaPersonaleSanzioniDescrizioni { get; set; }
        DbSet<PersonaleSanzioneMotivo> GaPersonaleSanzioniMotivi { get; set; }
        DbSet<PersonaleAbilitazione> GaPersonaleAbilitazioni { get; set; }
        DbSet<PersonaleAbilitazioneTipo> GaPersonaleAbilitazioniTipi { get; set; }
        DbSet<PersonaleRetributivo> GaPersonaleRetributivi { get; set; }
        DbSet<PersonaleRetributivoTipo> GaPersonaleRetributiviTipi { get; set; }
        DbSet<PersonaleSchedaConsegna> GaPersonaleSchedeConsegne { get; set; }
        DbSet<PersonaleSchedaConsegnaDettaglio> GaPersonaleSchedeConsegneDettagli { get; set; }
        DbSet<PersonaleArticolo> GaPersonaleArticoli { get; set; }
        DbSet<PersonaleArticoloModello> GaPersonaleArticoliModelli { get; set; }
        DbSet<PersonaleArticoloTipologia> GaPersonaleArticoliTipologie { get; set; }
        DbSet<PersonaleArticoloDpi> GaPersonaleArticoliDpis { get; set; }

        #region Views
        DbSet<ViewGaPersonaleUsersOnDipendenti> ViewGaPersonaleUsersOnDipendenti { get; set; }
        DbSet<ViewGaPersonaleDipendenti> ViewGaPersonaleDipendenti { get; set; }
        DbSet<ViewGaPersonaleScadenze> ViewGaPersonaleScadenze { get; set; }
        DbSet<ViewGaPersonaleAbilitazioni> ViewGaPersonaleAbilitazioni { get; set; }
        DbSet<ViewGaPersonaleArticoli> ViewGaPersonaleArticoli { get; set; }
        DbSet<ViewGaPersonaleNuoveSchede> ViewGaPersonaleNuoveSchede { get; set; }
        DbSet<ViewGaPersonaleRetributivi> ViewGaPersonaleRetributivi { get; set; }
        DbSet<ViewGaPersonaleSanzioni> ViewGaPersonaleSanzioni { get; set; }
        DbSet<ViewGaPersonaleScadenziario> ViewGaPersonaleScadenziario { get; set; }
        DbSet<ViewGaPersonaleScadenziarioAbilitazioni> ViewGaPersonaleScadenziarioAbilitazioni { get; set; }
        DbSet<ViewGaPersonaleSchedeConsegne> ViewGaPersonaleSchedeConsegne { get; set; }
        #endregion

        #endregion

        #region GaCsr Tables
        DbSet<CsrCodiceCer> GaCsrCodiciCers { get; set; }
        DbSet<CsrComune> GaCsrComuni { get; set; }
        DbSet<CsrDestinatario> GaCsrDestinatari { get; set; }
        DbSet<CsrProduttore> GaCsrProduttori { get; set; }
        DbSet<CsrRegistrazione> GaCsrRegistrazioni { get; set; }
        DbSet<CsrRegistrazionePeso> GaCsrRegistrazioniPesi { get; set; }
        DbSet<CsrRipartizionePercentuale> GaCsrRipartizioniPercentuali { get; set; }
        DbSet<CsrTrasportatore> GaCsrTrasportatori { get; set; }

        #region Views
        DbSet<ViewGaCsrCodiciCers> ViewGaCsrCodiciCers { get; set; }
        DbSet<ViewGaCsrDestinatari> ViewGaCsrDestinatari { get; set; }
        DbSet<ViewGaCsrExports> ViewGaCsrExports { get; set; }
        DbSet<ViewGaCsrProduttori> ViewGaCsrProduttori { get; set; }
        DbSet<ViewGaCsrRegistrazioni> ViewGaCsrRegistrazioni { get; set; }
        DbSet<ViewGaCsrRegistrazioniPesi> ViewGaCsrRegistrazioniPesi { get; set; }
        DbSet<ViewGaCsrRipartizioniPercentuali> ViewGaCsrRipartizioniPercentuali { get; set; }
        DbSet<ViewGaCsrTrasportatori> ViewGaCsrTrasportatori { get; set; }
        #endregion

        #endregion

        #region GaReclami Tables
        DbSet<ReclamiAzione> GaReclamiAzioni { get; set; }
        DbSet<ReclamiDocumento> GaReclamiDocumenti { get; set; }
        DbSet<ReclamiMittente> GaReclamiMittenti { get; set; }
        DbSet<ReclamiStato> GaReclamiStati { get; set; }
        DbSet<ReclamiTempoRisposta> GaReclamiTempiRisposte { get; set; }
        DbSet<ReclamiTipoAzione> GaReclamiTipiAzioni { get; set; }
        DbSet<ReclamiTipoOrigine> GaReclamiTipiOrigini { get; set; }

        #region Views
        DbSet<ViewGaReclamiAzioni> ViewGaReclamiAzioni { get; set; }
        DbSet<ViewGaReclamiDocumenti> ViewGaReclamiDocumenti { get; set; }
        DbSet<ViewGaReclamiRegistri> ViewGaReclamiRegistri { get; set; }
        #endregion

        #endregion

        #region GaSegnalazioni Tables
        DbSet<SegnalazioniTipo> GaSegnalazioniTipi { get; set; }
        DbSet<SegnalazioniStato> GaSegnalazioniStati { get; set; }
        DbSet<SegnalazioniAllegato> GaSegnalazioniAllegati { get; set; }
        DbSet<SegnalazioniDocumento> GaSegnalazioniDocumenti { get; set; }

        #region Views
        DbSet<ViewGaSegnalazioniDocumenti> ViewGaSegnalazioniDocumenti { get; set; }
        #endregion

        #endregion

        #region EcSegnalazioni Tables
        DbSet<EcSegnalazioniTipo> EcSegnalazioniTipi { get; set; }
        DbSet<EcSegnalazioniStato> EcSegnalazioniStati { get; set; }
        DbSet<EcSegnalazioniAllegato> EcSegnalazioniAllegati { get; set; }
        DbSet<EcSegnalazioniDocumento> EcSegnalazioniDocumenti { get; set; }

        #region Views
        DbSet<ViewEcSegnalazioniDocumenti> ViewEcSegnalazioniDocumenti { get; set; }
        #endregion

        #endregion

        #region GaContactCenter Tables
        DbSet<ContactCenterComune> GaContactCenterComuni { get; set; }
        DbSet<ContactCenterProvenienza> GaContactCenterProvenienze { get; set; }
        DbSet<ContactCenterTipoRichiesta> GaContactCenterTipiRichieste { get; set; }
        DbSet<ContactCenterStatoRichiesta> GaContactCenterStatiRichieste { get; set; }
        DbSet<ContactCenterMail> GaContactCenterMails { get; set; }
        DbSet<ContactCenterAllegato> GaContactCenterAllegati { get; set; }
        DbSet<ContactCenterMailOnTicket> GaContactCenterMailsOnTickets { get; set; }
        DbSet<ContactCenterTicket> GaContactCenterTickets { get; set; }

        #region Views
        DbSet<ViewGaContactCenterTickets> ViewGaContactCenterTickets { get; set; }
        DbSet<ViewFoContactCenterTickets> ViewFoContactCenterTickets { get; set; }
        DbSet<ViewGaContactCenterTicketsIngombranti> ViewGaContactCenterTicketsIngombranti { get; set; }
        #endregion

        #endregion

        #region GaPresenze Tables
        DbSet<PresenzeStatoRichiesta> GaPresenzeStatiRichieste { get; set; }
        DbSet<PresenzeRichiesta> GaPresenzeRichieste { get; set; }
        DbSet<PresenzeTipoOra> GaPresenzeTipiOre { get; set; }
        DbSet<PresenzeResponsabile> GaPresenzeResponsabili { get; set; }
        DbSet<PresenzeResponsabileOnSettore> GaPresenzeResponsabiliOnSettori { get; set; }
        DbSet<PresenzeProfilo> GaPresenzeProfili { get; set; }
        DbSet<PresenzeDataEsclusa> GaPresenzeDateEscluse { get; set; }
        DbSet<PresenzeBancaOraUtilizzo> GaPresenzeBancheOreUtilizzi { get; set; }
        DbSet<PresenzeDipendente> GaPresenzeDipendenti { get; set; }
        DbSet<PresenzeOrario> GaPresenzeOrari { get; set; }
        DbSet<PresenzeOrarioGiornata> GaPresenzeOrariGiornate { get; set; }


        #region Views
        DbSet<ViewGaPresenzeResponsabili> ViewGaPresenzeResponsabili { get; set; }
        DbSet<ViewGaPresenzeResponsabiliOnSettori> ViewGaPresenzeResponsabiliOnSettori { get; set; }
        DbSet<ViewGaPresenzeDipendenti> ViewGaPresenzeDipendenti { get; set; }
        DbSet<ViewGaPresenzeOrariGiornate> ViewGaPresenzeOrariGiornate { get; set; }
        DbSet<ViewGaPresenzeRichieste> ViewGaPresenzeRichieste { get; set; }
        DbSet<ViewGaPresenzeRichiestaMail> ViewGaPresenzeRichiestaMail { get; set; }

        #endregion

        #endregion

        #region GaRecapiti Tables

        #region Views
        DbSet<ViewGaRecapitiContatti> ViewGaRecapitiContatti { get; set; }
        #endregion

        #endregion

        #region Mail Tables

        DbSet<MailJob> MailJobs { get; set; }

        #endregion
    }
}