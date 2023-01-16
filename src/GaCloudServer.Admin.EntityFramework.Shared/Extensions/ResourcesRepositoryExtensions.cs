using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Recapiti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
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
            //Global
            #region Global
            services.AddTransient<IGenericRepository<GlobalSede>, GenericRepository<TResourcesDbContext, GlobalSede>>();
            services.AddTransient<IGenericRepository<GlobalCentroCosto>, GenericRepository<TResourcesDbContext, GlobalCentroCosto>>();
            services.AddTransient<IGenericRepository<GlobalSettore>, GenericRepository<TResourcesDbContext, GlobalSettore>>();
            #endregion

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
            services.AddTransient<IGenericRepository<CdrConferimento>, GenericRepository<TResourcesDbContext, CdrConferimento>>();
            services.AddTransient<IGenericRepository<CdrRichiestaViaggio>, GenericRepository<TResourcesDbContext, CdrRichiestaViaggio>>();
            services.AddTransient<IGenericRepository<CdrStatoRichiesta>, GenericRepository<TResourcesDbContext, CdrStatoRichiesta>>();
            services.AddTransient<IGenericRepository<CdrUtente>, GenericRepository<TResourcesDbContext, CdrUtente>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaCdrCersOnCentri>, GenericRepository<TResourcesDbContext, ViewGaCdrCersOnCentri>>();
            services.AddTransient<IGenericRepository<ViewGaCdrComuniOnCentri>, GenericRepository<TResourcesDbContext, ViewGaCdrComuniOnCentri>>();
            services.AddTransient<IGenericRepository<ViewGaCdrComuni>, GenericRepository<TResourcesDbContext, ViewGaCdrComuni>>();
            services.AddTransient<IGenericRepository<ViewGaCdrConferimenti>, GenericRepository<TResourcesDbContext, ViewGaCdrConferimenti>>();
            services.AddTransient<IGenericRepository<ViewGaCdrRichiesteViaggi>, GenericRepository<TResourcesDbContext, ViewGaCdrRichiesteViaggi>>();
            services.AddTransient<IGenericRepository<ViewGaCdrUtenti>, GenericRepository<TResourcesDbContext, ViewGaCdrUtenti>>();
            #endregion

            //Comunicati
            #region Comunicati
            services.AddTransient<IGenericRepository<ComunicatiDocumento>, GenericRepository<TResourcesDbContext, ComunicatiDocumento>>();
            #endregion

            //Mezzi
            #region Mezzi
            services.AddTransient<IGenericRepository<MezziAlimentazione>, GenericRepository<TResourcesDbContext, MezziAlimentazione>>();
            services.AddTransient<IGenericRepository<MezziClasse>, GenericRepository<TResourcesDbContext, MezziClasse>>();
            services.AddTransient<IGenericRepository<MezziDocumento>, GenericRepository<TResourcesDbContext, MezziDocumento>>();
            services.AddTransient<IGenericRepository<MezziPatente>, GenericRepository<TResourcesDbContext, MezziPatente>>();
            services.AddTransient<IGenericRepository<MezziPeriodoScadenza>, GenericRepository<TResourcesDbContext, MezziPeriodoScadenza>>();
            services.AddTransient<IGenericRepository<MezziProprietario>, GenericRepository<TResourcesDbContext, MezziProprietario>>();
            services.AddTransient<IGenericRepository<MezziScadenza>, GenericRepository<TResourcesDbContext, MezziScadenza>>();
            services.AddTransient<IGenericRepository<MezziScadenzaTipo>, GenericRepository<TResourcesDbContext, MezziScadenzaTipo>>();
            services.AddTransient<IGenericRepository<MezziTipo>, GenericRepository<TResourcesDbContext, MezziTipo>>();
            services.AddTransient<IGenericRepository<MezziVeicolo>, GenericRepository<TResourcesDbContext, MezziVeicolo>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaMezziVeicoli>, GenericRepository<TResourcesDbContext, ViewGaMezziVeicoli>>();
            services.AddTransient<IGenericRepository<ViewGaMezziDocumenti>, GenericRepository<TResourcesDbContext, ViewGaMezziDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaMezziScadenze>, GenericRepository<TResourcesDbContext, ViewGaMezziScadenze>>();
            #endregion

            //Contratti
            #region Contratti
            services.AddTransient<IGenericRepository<ContrattiPermesso>, GenericRepository<TResourcesDbContext, ContrattiPermesso>>();
            services.AddTransient<IGenericRepository<ContrattiServizio>, GenericRepository<TResourcesDbContext, ContrattiServizio>>();
            services.AddTransient<IGenericRepository<ContrattiTipologia>, GenericRepository<TResourcesDbContext, ContrattiTipologia>>();
            services.AddTransient<IGenericRepository<ContrattiUtenteOnPermesso>, GenericRepository<TResourcesDbContext, ContrattiUtenteOnPermesso>>();
            services.AddTransient<IGenericRepository<ContrattiModalita>, GenericRepository<TResourcesDbContext, ContrattiModalita>>();
            services.AddTransient<IGenericRepository<ContrattiFornitore>, GenericRepository<TResourcesDbContext, ContrattiFornitore>>();
            services.AddTransient<IGenericRepository<ContrattiDocumento>, GenericRepository<TResourcesDbContext, ContrattiDocumento>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaContrattiUtenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiUtentiOnPermessi>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtentiOnPermessi>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumentiList>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumentiList>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiNumeratori>, GenericRepository<TResourcesDbContext, ViewGaContrattiNumeratori>>();

            //Sp
            services.AddTransient<IProcedureManager<SpGaContrattiNumeratore>, ProcedureManager<TResourcesDbContext, SpGaContrattiNumeratore>>();
            services.AddTransient<IProcedureManager<SpGaContrattiPermesso>, ProcedureManager<TResourcesDbContext, SpGaContrattiPermesso>>();
            services.AddTransient<IProcedureManager<SpGaContrattiPermessoMode>, ProcedureManager<TResourcesDbContext, SpGaContrattiPermessoMode>>();

            #endregion

            //Aziende
            #region Aziende
            services.AddTransient<IGenericRepository<AziendeLista>, GenericRepository<TResourcesDbContext, AziendeLista>>();
            #endregion

            //BackOffice
            #region BackOffice
            services.AddTransient<IGenericRepository<BackOfficeTicket>, GenericRepository<TResourcesDbContext, BackOfficeTicket>>();

            services.AddTransient<IGenericRepository<ViewGaBackOfficeComuni>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeComuni>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeGrouped>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeGrouped>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeNdUtenze>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeNdUtenze>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeNdUtenzeGrouped>>();
            #endregion

            //PrenotazioneAuto
            #region PrenotazioneAuto
            services.AddTransient<IGenericRepository<PrenotazioneAutoRegistrazione>, GenericRepository<TResourcesDbContext, PrenotazioneAutoRegistrazione>>();
            services.AddTransient<IGenericRepository<PrenotazioneAutoSede>, GenericRepository<TResourcesDbContext, PrenotazioneAutoSede>>();
            services.AddTransient<IGenericRepository<PrenotazioneAutoVeicolo>, GenericRepository<TResourcesDbContext, PrenotazioneAutoVeicolo>>();

            services.AddTransient<IGenericRepository<ViewGaPrenotazioneAutoVeicoli>, GenericRepository<TResourcesDbContext, ViewGaPrenotazioneAutoVeicoli>>();
            services.AddTransient<IGenericRepository<ViewGaPrenotazioneAutoRegistrazioni>, GenericRepository<TResourcesDbContext, ViewGaPrenotazioneAutoRegistrazioni>>();
            #endregion

            //Notifications
            #region Notification
            services.AddTransient<IGenericRepository<NotificationApp>, GenericRepository<TResourcesDbContext, NotificationApp>>();
            services.AddTransient<IGenericRepository<NotificationRoleOnApp>, GenericRepository<TResourcesDbContext, NotificationRoleOnApp>>();
            services.AddTransient<IGenericRepository<NotificationUserOnApp>, GenericRepository<TResourcesDbContext, NotificationUserOnApp>>();
            services.AddTransient<IGenericRepository<NotificationEvent>, GenericRepository<TResourcesDbContext, NotificationEvent>>();

            services.AddTransient<IGenericRepository<ViewNotificationRolesOnApps>, GenericRepository<TResourcesDbContext, ViewNotificationRolesOnApps>>();
            services.AddTransient<IGenericRepository<ViewNotificationUsersOnApps>, GenericRepository<TResourcesDbContext, ViewNotificationUsersOnApps>>();
            services.AddTransient<IGenericRepository<ViewNotificationEvents>, GenericRepository<TResourcesDbContext, ViewNotificationEvents>>();
            #endregion

            //Personale
            #region Personale
            services.AddTransient<IGenericRepository<PersonaleDipendente>, GenericRepository<TResourcesDbContext, PersonaleDipendente>>();
            services.AddTransient<IGenericRepository<PersonaleQualifica>, GenericRepository<TResourcesDbContext, PersonaleQualifica>>();
            services.AddTransient<IGenericRepository<PersonaleAssunzione>, GenericRepository<TResourcesDbContext, PersonaleAssunzione>>();
            services.AddTransient<IGenericRepository<PersonaleScadenza>, GenericRepository<TResourcesDbContext, PersonaleScadenza>>();
            services.AddTransient<IGenericRepository<PersonaleScadenzaTipo>, GenericRepository<TResourcesDbContext, PersonaleScadenzaTipo>>();
            services.AddTransient<IGenericRepository<PersonaleScadenzaDettaglio>, GenericRepository<TResourcesDbContext, PersonaleScadenzaDettaglio>>();
            services.AddTransient<IGenericRepository<PersonaleSanzioneMotivo>, GenericRepository<TResourcesDbContext, PersonaleSanzioneMotivo>>();
            services.AddTransient<IGenericRepository<PersonaleSanzioneDescrizione>, GenericRepository<TResourcesDbContext, PersonaleSanzioneDescrizione>>();
            services.AddTransient<IGenericRepository<PersonaleSanzione>, GenericRepository<TResourcesDbContext, PersonaleSanzione>>();
            services.AddTransient<IGenericRepository<PersonaleAbilitazione>, GenericRepository<TResourcesDbContext, PersonaleAbilitazione>>();
            services.AddTransient<IGenericRepository<PersonaleAbilitazioneTipo>, GenericRepository<TResourcesDbContext, PersonaleAbilitazioneTipo>>();
            services.AddTransient<IGenericRepository<PersonaleRetributivo>, GenericRepository<TResourcesDbContext, PersonaleRetributivo>>();
            services.AddTransient<IGenericRepository<PersonaleRetributivoTipo>, GenericRepository<TResourcesDbContext, PersonaleRetributivoTipo>>();
            services.AddTransient<IGenericRepository<PersonaleSchedaConsegna>, GenericRepository<TResourcesDbContext, PersonaleSchedaConsegna>>();
            services.AddTransient<IGenericRepository<PersonaleSchedaConsegnaDettaglio>, GenericRepository<TResourcesDbContext, PersonaleSchedaConsegnaDettaglio>>();
            services.AddTransient<IGenericRepository<PersonaleArticolo>, GenericRepository<TResourcesDbContext, PersonaleArticolo>>();
            services.AddTransient<IGenericRepository<PersonaleArticoloModello>, GenericRepository<TResourcesDbContext, PersonaleArticoloModello>>();
            services.AddTransient<IGenericRepository<PersonaleArticoloTipologia>, GenericRepository<TResourcesDbContext, PersonaleArticoloTipologia>>();
            services.AddTransient<IGenericRepository<PersonaleArticoloDpi>, GenericRepository<TResourcesDbContext, PersonaleArticoloDpi>>();

            services.AddTransient<IGenericRepository<ViewGaPersonaleUsersOnDipendenti>, GenericRepository<TResourcesDbContext, ViewGaPersonaleUsersOnDipendenti>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleDipendenti>, GenericRepository<TResourcesDbContext, ViewGaPersonaleDipendenti>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleScadenze>, GenericRepository<TResourcesDbContext, ViewGaPersonaleScadenze>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleAbilitazioni>, GenericRepository<TResourcesDbContext, ViewGaPersonaleAbilitazioni>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleScadenziarioAbilitazioni>, GenericRepository<TResourcesDbContext, ViewGaPersonaleScadenziarioAbilitazioni>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleArticoli>, GenericRepository<TResourcesDbContext, ViewGaPersonaleArticoli>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleNuoveSchede>, GenericRepository<TResourcesDbContext, ViewGaPersonaleNuoveSchede>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleRetributivi>, GenericRepository<TResourcesDbContext, ViewGaPersonaleRetributivi>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleSanzioni>, GenericRepository<TResourcesDbContext, ViewGaPersonaleSanzioni>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleSchedeConsegne>, GenericRepository<TResourcesDbContext, ViewGaPersonaleSchedeConsegne>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleScadenziario>, GenericRepository<TResourcesDbContext, ViewGaPersonaleScadenziario>>();

            #endregion

            //Csr
            #region Csr
            services.AddTransient<IGenericRepository<CsrCodiceCer>, GenericRepository<TResourcesDbContext, CsrCodiceCer>>();
            services.AddTransient<IGenericRepository<CsrComune>, GenericRepository<TResourcesDbContext, CsrComune>>();
            services.AddTransient<IGenericRepository<CsrDestinatario>, GenericRepository<TResourcesDbContext, CsrDestinatario>>();
            services.AddTransient<IGenericRepository<CsrProduttore>, GenericRepository<TResourcesDbContext, CsrProduttore>>();
            services.AddTransient<IGenericRepository<CsrRegistrazione>, GenericRepository<TResourcesDbContext, CsrRegistrazione>>();
            services.AddTransient<IGenericRepository<CsrRegistrazionePeso>, GenericRepository<TResourcesDbContext, CsrRegistrazionePeso>>();
            services.AddTransient<IGenericRepository<CsrRipartizionePercentuale>, GenericRepository<TResourcesDbContext, CsrRipartizionePercentuale>>();
            services.AddTransient<IGenericRepository<CsrTrasportatore>, GenericRepository<TResourcesDbContext, CsrTrasportatore>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaCsrCodiciCers>, GenericRepository<TResourcesDbContext, ViewGaCsrCodiciCers>>();
            services.AddTransient<IGenericRepository<ViewGaCsrDestinatari>, GenericRepository<TResourcesDbContext, ViewGaCsrDestinatari>>();
            services.AddTransient<IGenericRepository<ViewGaCsrExports>, GenericRepository<TResourcesDbContext, ViewGaCsrExports>>();
            services.AddTransient<IGenericRepository<ViewGaCsrProduttori>, GenericRepository<TResourcesDbContext, ViewGaCsrProduttori>>();
            services.AddTransient<IGenericRepository<ViewGaCsrRegistrazioni>, GenericRepository<TResourcesDbContext, ViewGaCsrRegistrazioni>>();
            services.AddTransient<IGenericRepository<ViewGaCsrRegistrazioniPesi>, GenericRepository<TResourcesDbContext, ViewGaCsrRegistrazioniPesi>>();
            services.AddTransient<IGenericRepository<ViewGaCsrRipartizioniPercentuali>, GenericRepository<TResourcesDbContext, ViewGaCsrRipartizioniPercentuali>>();
            services.AddTransient<IGenericRepository<ViewGaCsrTrasportatori>, GenericRepository<TResourcesDbContext, ViewGaCsrTrasportatori>>();
            #endregion

            //Reclami
            #region Reclami
            services.AddTransient<IGenericRepository<ReclamiAzione>, GenericRepository<TResourcesDbContext, ReclamiAzione>>();
            services.AddTransient<IGenericRepository<ReclamiDocumento>, GenericRepository<TResourcesDbContext, ReclamiDocumento>>();
            services.AddTransient<IGenericRepository<ReclamiMittente>, GenericRepository<TResourcesDbContext, ReclamiMittente>>();
            services.AddTransient<IGenericRepository<ReclamiStato>, GenericRepository<TResourcesDbContext, ReclamiStato>>();
            services.AddTransient<IGenericRepository<ReclamiTempoRisposta>, GenericRepository<TResourcesDbContext, ReclamiTempoRisposta>>();
            services.AddTransient<IGenericRepository<ReclamiTipoAzione>, GenericRepository<TResourcesDbContext, ReclamiTipoAzione>>();
            services.AddTransient<IGenericRepository<ReclamiTipoOrigine>, GenericRepository<TResourcesDbContext, ReclamiTipoOrigine>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaReclamiAzioni>, GenericRepository<TResourcesDbContext, ViewGaReclamiAzioni>>();
            services.AddTransient<IGenericRepository<ViewGaReclamiDocumenti>, GenericRepository<TResourcesDbContext, ViewGaReclamiDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaReclamiRegistri>, GenericRepository<TResourcesDbContext, ViewGaReclamiRegistri>>();

            #endregion

            //Segnalazioni
            #region Segnalazioni
            services.AddTransient<IGenericRepository<SegnalazioniTipo>, GenericRepository<TResourcesDbContext, SegnalazioniTipo>>();
            services.AddTransient<IGenericRepository<SegnalazioniStato>, GenericRepository<TResourcesDbContext, SegnalazioniStato>>();
            services.AddTransient<IGenericRepository<SegnalazioniAllegato>, GenericRepository<TResourcesDbContext, SegnalazioniAllegato>>();
            services.AddTransient<IGenericRepository<SegnalazioniDocumento>, GenericRepository<TResourcesDbContext, SegnalazioniDocumento>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaSegnalazioniDocumenti>, GenericRepository<TResourcesDbContext, ViewGaSegnalazioniDocumenti>>();


            #endregion

            //EcSegnalazioni
            #region EcSegnalazioni
            services.AddTransient<IGenericRepository<EcSegnalazioniTipo>, GenericRepository<TResourcesDbContext, EcSegnalazioniTipo>>();
            services.AddTransient<IGenericRepository<EcSegnalazioniStato>, GenericRepository<TResourcesDbContext, EcSegnalazioniStato>>();
            services.AddTransient<IGenericRepository<EcSegnalazioniAllegato>, GenericRepository<TResourcesDbContext, EcSegnalazioniAllegato>>();
            services.AddTransient<IGenericRepository<EcSegnalazioniDocumento>, GenericRepository<TResourcesDbContext, EcSegnalazioniDocumento>>();

            //Views
            services.AddTransient<IGenericRepository<ViewEcSegnalazioniDocumenti>, GenericRepository<TResourcesDbContext, ViewEcSegnalazioniDocumenti>>();


            #endregion

            //ContactCenter
            #region ContactCenter
            services.AddTransient<IGenericRepository<ContactCenterComune>, GenericRepository<TResourcesDbContext, ContactCenterComune>>();
            services.AddTransient<IGenericRepository<ContactCenterProvenienza>, GenericRepository<TResourcesDbContext, ContactCenterProvenienza>>();
            services.AddTransient<IGenericRepository<ContactCenterStatoRichiesta>, GenericRepository<TResourcesDbContext, ContactCenterStatoRichiesta>>();
            services.AddTransient<IGenericRepository<ContactCenterTipoRichiesta>, GenericRepository<TResourcesDbContext, ContactCenterTipoRichiesta>>();
            services.AddTransient<IGenericRepository<ContactCenterMail>, GenericRepository<TResourcesDbContext, ContactCenterMail>>();
            services.AddTransient<IGenericRepository<ContactCenterAllegato>, GenericRepository<TResourcesDbContext, ContactCenterAllegato>>();
            services.AddTransient<IGenericRepository<ContactCenterMailOnTicket>, GenericRepository<TResourcesDbContext, ContactCenterMailOnTicket>>();
            services.AddTransient<IGenericRepository<ContactCenterTicket>, GenericRepository<TResourcesDbContext, ContactCenterTicket>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaContactCenterTickets>, GenericRepository<TResourcesDbContext, ViewGaContactCenterTickets>>();
            services.AddTransient<IGenericRepository<ViewFoContactCenterTickets>, GenericRepository<TResourcesDbContext, ViewFoContactCenterTickets>>();
            services.AddTransient<IGenericRepository<ViewGaContactCenterTicketsIngombranti>, GenericRepository<TResourcesDbContext, ViewGaContactCenterTicketsIngombranti>>();

            #endregion

            //Presenze
            #region Presenze
            services.AddTransient<IGenericRepository<PresenzeStatoRichiesta>, GenericRepository<TResourcesDbContext, PresenzeStatoRichiesta>>();
            services.AddTransient<IGenericRepository<PresenzeRichiesta>, GenericRepository<TResourcesDbContext, PresenzeRichiesta>>();
            services.AddTransient<IGenericRepository<PresenzeTipoOra>, GenericRepository<TResourcesDbContext, PresenzeTipoOra>>();
            services.AddTransient<IGenericRepository<PresenzeResponsabile>, GenericRepository<TResourcesDbContext, PresenzeResponsabile>>();
            services.AddTransient<IGenericRepository<PresenzeResponsabileOnSettore>, GenericRepository<TResourcesDbContext, PresenzeResponsabileOnSettore>>();
            services.AddTransient<IGenericRepository<PresenzeProfilo>, GenericRepository<TResourcesDbContext, PresenzeProfilo>>();
            services.AddTransient<IGenericRepository<PresenzeDataEsclusa>, GenericRepository<TResourcesDbContext, PresenzeDataEsclusa>>();
            services.AddTransient<IGenericRepository<PresenzeBancaOraUtilizzo>, GenericRepository<TResourcesDbContext, PresenzeBancaOraUtilizzo>>();
            services.AddTransient<IGenericRepository<PresenzeDipendente>, GenericRepository<TResourcesDbContext, PresenzeDipendente>>();
            services.AddTransient<IGenericRepository<PresenzeOrario>, GenericRepository<TResourcesDbContext, PresenzeOrario>>();
            services.AddTransient<IGenericRepository<PresenzeOrarioGiornata>, GenericRepository<TResourcesDbContext, PresenzeOrarioGiornata>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaPresenzeResponsabili>, GenericRepository<TResourcesDbContext, ViewGaPresenzeResponsabili>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeResponsabiliOnSettori>, GenericRepository<TResourcesDbContext, ViewGaPresenzeResponsabiliOnSettori>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeDipendenti>, GenericRepository<TResourcesDbContext, ViewGaPresenzeDipendenti>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeOrariGiornate>, GenericRepository<TResourcesDbContext, ViewGaPresenzeOrariGiornate>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeRichieste>, GenericRepository<TResourcesDbContext, ViewGaPresenzeRichieste>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeRichiestaMail>, GenericRepository<TResourcesDbContext, ViewGaPresenzeRichiestaMail>>();



            #endregion

            //Recapiti
            #region Recapiti

            //Views
            services.AddTransient<IGenericRepository<ViewGaRecapitiContatti>, GenericRepository<TResourcesDbContext, ViewGaRecapitiContatti>>();

            #endregion

            //Mail
            #region Mail
            services.AddTransient<IGenericRepository<MailJob>, GenericRepository<TResourcesDbContext, MailJob>>();
            #endregion


            return services; 
        }

        public static IServiceCollection AddJobsResourcesRepository<TResourcesDbContext>(this IServiceCollection services)
    where TResourcesDbContext : DbContext, IResourcesDbContext
        {
            //Autorizzazioni
            #region Autorizzazioni
            services.AddTransient<IGenericRepository<AutorizzazioniTipo>, GenericRepository<TResourcesDbContext, AutorizzazioniTipo>>();
            services.AddTransient<IGenericRepository<AutorizzazioniDocumento>, GenericRepository<TResourcesDbContext, AutorizzazioniDocumento>>();
            services.AddTransient<IGenericRepository<AutorizzazioniAllegato>, GenericRepository<TResourcesDbContext, AutorizzazioniAllegato>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaAutorizzazioniDocumenti>, GenericRepository<TResourcesDbContext, ViewGaAutorizzazioniDocumenti>>();
            #endregion

            //Mezzi
            #region Mezzi
            services.AddTransient<IGenericRepository<MezziAlimentazione>, GenericRepository<TResourcesDbContext, MezziAlimentazione>>();
            services.AddTransient<IGenericRepository<MezziClasse>, GenericRepository<TResourcesDbContext, MezziClasse>>();
            services.AddTransient<IGenericRepository<MezziDocumento>, GenericRepository<TResourcesDbContext, MezziDocumento>>();
            services.AddTransient<IGenericRepository<MezziPatente>, GenericRepository<TResourcesDbContext, MezziPatente>>();
            services.AddTransient<IGenericRepository<MezziPeriodoScadenza>, GenericRepository<TResourcesDbContext, MezziPeriodoScadenza>>();
            services.AddTransient<IGenericRepository<MezziProprietario>, GenericRepository<TResourcesDbContext, MezziProprietario>>();
            services.AddTransient<IGenericRepository<MezziScadenza>, GenericRepository<TResourcesDbContext, MezziScadenza>>();
            services.AddTransient<IGenericRepository<MezziScadenzaTipo>, GenericRepository<TResourcesDbContext, MezziScadenzaTipo>>();
            services.AddTransient<IGenericRepository<MezziTipo>, GenericRepository<TResourcesDbContext, MezziTipo>>();
            services.AddTransient<IGenericRepository<MezziVeicolo>, GenericRepository<TResourcesDbContext, MezziVeicolo>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaMezziVeicoli>, GenericRepository<TResourcesDbContext, ViewGaMezziVeicoli>>();
            services.AddTransient<IGenericRepository<ViewGaMezziDocumenti>, GenericRepository<TResourcesDbContext, ViewGaMezziDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaMezziScadenze>, GenericRepository<TResourcesDbContext, ViewGaMezziScadenze>>();
            #endregion

            //Contratti
            #region Contratti
            services.AddTransient<IGenericRepository<ContrattiPermesso>, GenericRepository<TResourcesDbContext, ContrattiPermesso>>();
            services.AddTransient<IGenericRepository<ContrattiServizio>, GenericRepository<TResourcesDbContext, ContrattiServizio>>();
            services.AddTransient<IGenericRepository<ContrattiTipologia>, GenericRepository<TResourcesDbContext, ContrattiTipologia>>();
            services.AddTransient<IGenericRepository<ContrattiUtenteOnPermesso>, GenericRepository<TResourcesDbContext, ContrattiUtenteOnPermesso>>();
            services.AddTransient<IGenericRepository<ContrattiModalita>, GenericRepository<TResourcesDbContext, ContrattiModalita>>();
            services.AddTransient<IGenericRepository<ContrattiFornitore>, GenericRepository<TResourcesDbContext, ContrattiFornitore>>();
            services.AddTransient<IGenericRepository<ContrattiDocumento>, GenericRepository<TResourcesDbContext, ContrattiDocumento>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaContrattiUtenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiUtentiOnPermessi>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtentiOnPermessi>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumentiList>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumentiList>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiNumeratori>, GenericRepository<TResourcesDbContext, ViewGaContrattiNumeratori>>();

            //Sp
            services.AddTransient<IProcedureManager<SpGaContrattiNumeratore>, ProcedureManager<TResourcesDbContext, SpGaContrattiNumeratore>>();
            services.AddTransient<IProcedureManager<SpGaContrattiPermesso>, ProcedureManager<TResourcesDbContext, SpGaContrattiPermesso>>();
            services.AddTransient<IProcedureManager<SpGaContrattiPermessoMode>, ProcedureManager<TResourcesDbContext, SpGaContrattiPermessoMode>>();

            #endregion

            //Personale
            #region Personale
            services.AddTransient<IGenericRepository<PersonaleDipendente>, GenericRepository<TResourcesDbContext, PersonaleDipendente>>();
            services.AddTransient<IGenericRepository<PersonaleQualifica>, GenericRepository<TResourcesDbContext, PersonaleQualifica>>();
            services.AddTransient<IGenericRepository<PersonaleAssunzione>, GenericRepository<TResourcesDbContext, PersonaleAssunzione>>();
            services.AddTransient<IGenericRepository<PersonaleScadenza>, GenericRepository<TResourcesDbContext, PersonaleScadenza>>();
            services.AddTransient<IGenericRepository<PersonaleScadenzaTipo>, GenericRepository<TResourcesDbContext, PersonaleScadenzaTipo>>();
            services.AddTransient<IGenericRepository<PersonaleScadenzaDettaglio>, GenericRepository<TResourcesDbContext, PersonaleScadenzaDettaglio>>();
            services.AddTransient<IGenericRepository<PersonaleSanzioneMotivo>, GenericRepository<TResourcesDbContext, PersonaleSanzioneMotivo>>();
            services.AddTransient<IGenericRepository<PersonaleSanzioneDescrizione>, GenericRepository<TResourcesDbContext, PersonaleSanzioneDescrizione>>();
            services.AddTransient<IGenericRepository<PersonaleSanzione>, GenericRepository<TResourcesDbContext, PersonaleSanzione>>();
            services.AddTransient<IGenericRepository<PersonaleAbilitazione>, GenericRepository<TResourcesDbContext, PersonaleAbilitazione>>();
            services.AddTransient<IGenericRepository<PersonaleAbilitazioneTipo>, GenericRepository<TResourcesDbContext, PersonaleAbilitazioneTipo>>();
            services.AddTransient<IGenericRepository<PersonaleRetributivo>, GenericRepository<TResourcesDbContext, PersonaleRetributivo>>();
            services.AddTransient<IGenericRepository<PersonaleRetributivoTipo>, GenericRepository<TResourcesDbContext, PersonaleRetributivoTipo>>();
            services.AddTransient<IGenericRepository<PersonaleSchedaConsegna>, GenericRepository<TResourcesDbContext, PersonaleSchedaConsegna>>();
            services.AddTransient<IGenericRepository<PersonaleSchedaConsegnaDettaglio>, GenericRepository<TResourcesDbContext, PersonaleSchedaConsegnaDettaglio>>();
            services.AddTransient<IGenericRepository<PersonaleArticolo>, GenericRepository<TResourcesDbContext, PersonaleArticolo>>();
            services.AddTransient<IGenericRepository<PersonaleArticoloModello>, GenericRepository<TResourcesDbContext, PersonaleArticoloModello>>();
            services.AddTransient<IGenericRepository<PersonaleArticoloTipologia>, GenericRepository<TResourcesDbContext, PersonaleArticoloTipologia>>();
            services.AddTransient<IGenericRepository<PersonaleArticoloDpi>, GenericRepository<TResourcesDbContext, PersonaleArticoloDpi>>();

            services.AddTransient<IGenericRepository<ViewGaPersonaleUsersOnDipendenti>, GenericRepository<TResourcesDbContext, ViewGaPersonaleUsersOnDipendenti>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleDipendenti>, GenericRepository<TResourcesDbContext, ViewGaPersonaleDipendenti>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleScadenze>, GenericRepository<TResourcesDbContext, ViewGaPersonaleScadenze>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleAbilitazioni>, GenericRepository<TResourcesDbContext, ViewGaPersonaleAbilitazioni>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleScadenziarioAbilitazioni>, GenericRepository<TResourcesDbContext, ViewGaPersonaleScadenziarioAbilitazioni>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleArticoli>, GenericRepository<TResourcesDbContext, ViewGaPersonaleArticoli>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleNuoveSchede>, GenericRepository<TResourcesDbContext, ViewGaPersonaleNuoveSchede>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleRetributivi>, GenericRepository<TResourcesDbContext, ViewGaPersonaleRetributivi>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleSanzioni>, GenericRepository<TResourcesDbContext, ViewGaPersonaleSanzioni>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleSchedeConsegne>, GenericRepository<TResourcesDbContext, ViewGaPersonaleSchedeConsegne>>();
            services.AddTransient<IGenericRepository<ViewGaPersonaleScadenziario>, GenericRepository<TResourcesDbContext, ViewGaPersonaleScadenziario>>();

            #endregion

            //Notifications
            #region Notification
            services.AddTransient<IGenericRepository<NotificationApp>, GenericRepository<TResourcesDbContext, NotificationApp>>();
            services.AddTransient<IGenericRepository<NotificationRoleOnApp>, GenericRepository<TResourcesDbContext, NotificationRoleOnApp>>();
            services.AddTransient<IGenericRepository<NotificationUserOnApp>, GenericRepository<TResourcesDbContext, NotificationUserOnApp>>();
            services.AddTransient<IGenericRepository<NotificationEvent>, GenericRepository<TResourcesDbContext, NotificationEvent>>();

            services.AddTransient<IGenericRepository<ViewNotificationRolesOnApps>, GenericRepository<TResourcesDbContext, ViewNotificationRolesOnApps>>();
            services.AddTransient<IGenericRepository<ViewNotificationUsersOnApps>, GenericRepository<TResourcesDbContext, ViewNotificationUsersOnApps>>();
            services.AddTransient<IGenericRepository<ViewNotificationEvents>, GenericRepository<TResourcesDbContext, ViewNotificationEvents>>();
            #endregion

            //Reclami
            #region Reclami
            services.AddTransient<IGenericRepository<ReclamiAzione>, GenericRepository<TResourcesDbContext, ReclamiAzione>>();
            services.AddTransient<IGenericRepository<ReclamiDocumento>, GenericRepository<TResourcesDbContext, ReclamiDocumento>>();
            services.AddTransient<IGenericRepository<ReclamiMittente>, GenericRepository<TResourcesDbContext, ReclamiMittente>>();
            services.AddTransient<IGenericRepository<ReclamiStato>, GenericRepository<TResourcesDbContext, ReclamiStato>>();
            services.AddTransient<IGenericRepository<ReclamiTempoRisposta>, GenericRepository<TResourcesDbContext, ReclamiTempoRisposta>>();
            services.AddTransient<IGenericRepository<ReclamiTipoAzione>, GenericRepository<TResourcesDbContext, ReclamiTipoAzione>>();
            services.AddTransient<IGenericRepository<ReclamiTipoOrigine>, GenericRepository<TResourcesDbContext, ReclamiTipoOrigine>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaReclamiAzioni>, GenericRepository<TResourcesDbContext, ViewGaReclamiAzioni>>();
            services.AddTransient<IGenericRepository<ViewGaReclamiDocumenti>, GenericRepository<TResourcesDbContext, ViewGaReclamiDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaReclamiRegistri>, GenericRepository<TResourcesDbContext, ViewGaReclamiRegistri>>();

            #endregion

            //Mail
            #region Mail
            services.AddTransient<IGenericRepository<MailJob>, GenericRepository<TResourcesDbContext, MailJob>>();
            #endregion


            return services;
        }
    }
}
