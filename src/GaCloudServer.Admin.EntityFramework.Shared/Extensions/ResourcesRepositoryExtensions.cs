using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.CreDeb;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Emz.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Ost.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Quicklinks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Recapiti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.SmartCity;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.SmartCity.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.System;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
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
            //Identity
            services.AddTransient<IGenericRepository<ViewUserIdentity>, GenericRepository<TResourcesDbContext, ViewUserIdentity>>();
            //Common
            #region Common
            services.AddTransient<IGenericRepository<Gauge>, GenericRepository<TResourcesDbContext, Gauge>>();
            services.AddTransient<IGenericRepository<IvaCode>, GenericRepository<TResourcesDbContext, IvaCode>>();
            services.AddTransient<IGenericRepository<BankAccount>, GenericRepository<TResourcesDbContext, BankAccount>>();
            #endregion

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
            services.AddTransient<IGenericRepository<ContrattiSoggetto>, GenericRepository<TResourcesDbContext, ContrattiSoggetto>>();
            services.AddTransient<IGenericRepository<ContrattiDocumento>, GenericRepository<TResourcesDbContext, ContrattiDocumento>>();
            services.AddTransient<IGenericRepository<ContrattiDocumentoAllegato>, GenericRepository<TResourcesDbContext, ContrattiDocumentoAllegato>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaContrattiUtenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiUtentiOnPermessi>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtentiOnPermessi>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumentiScadenziario>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumentiScadenziario>>();
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
            services.AddTransient<IGenericRepository<BackOfficeParametroOnCategoria>, GenericRepository<TResourcesDbContext, BackOfficeParametroOnCategoria>>();
            services.AddTransient<IGenericRepository<BackOfficeMargine>, GenericRepository<TResourcesDbContext, BackOfficeMargine>>();
            services.AddTransient<IGenericRepository<BackOfficeZona>, GenericRepository<TResourcesDbContext, BackOfficeZona>>();
            services.AddTransient<IGenericRepository<BackOfficeDocReceipt>, GenericRepository<TResourcesDbContext, BackOfficeDocReceipt>>();

            services.AddTransient<IGenericRepository<ViewGaBackOfficeComuni>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeComuni>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeGrouped>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeGrouped>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeNdUtenze>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeNdUtenze>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeNdUtenzeGrouped>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeContenitoriLetture>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeContenitoriLetture>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeZone>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeZone>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenze>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenze>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartite>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartite>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartiteDetail>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartiteDetail>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartiteGrp>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartiteGrp>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeDispositivi>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeDispositivi>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeTipCon>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeTipCon>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeZone>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeZone>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeInsolutoTariNovi>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeInsolutoTariNovi>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeNovi>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeNovi>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeCliFat>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeCliFat>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeCliSed>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeCliSed>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartiteVariazioni>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartiteVariazioni>>();

            //Sp
            services.AddTransient<IProcedureManager<SpGaBackOfficeUtenze>, ProcedureManager<TResourcesDbContext, SpGaBackOfficeUtenze>>();
            services.AddTransient<IProcedureManager<SpGaBackOfficeUtenzePartite>, ProcedureManager<TResourcesDbContext, SpGaBackOfficeUtenzePartite>>();
            services.AddTransient<IProcedureManager<SpGaBackOfficeUtenzeDispositivi>, ProcedureManager<TResourcesDbContext, SpGaBackOfficeUtenzeDispositivi>>();
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
            services.AddTransient<IGenericRepository<SegnalazioniDocumentoImmagine>, GenericRepository<TResourcesDbContext, SegnalazioniDocumentoImmagine>>();
            services.AddTransient<IGenericRepository<SegnalazioniDocumento>, GenericRepository<TResourcesDbContext, SegnalazioniDocumento>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaSegnalazioniDocumenti>, GenericRepository<TResourcesDbContext, ViewGaSegnalazioniDocumenti>>();


            #endregion

            //EcSegnalazioni
            #region EcSegnalazioni
            services.AddTransient<IGenericRepository<EcSegnalazioniTipo>, GenericRepository<TResourcesDbContext, EcSegnalazioniTipo>>();
            services.AddTransient<IGenericRepository<EcSegnalazioniStato>, GenericRepository<TResourcesDbContext, EcSegnalazioniStato>>();
            services.AddTransient<IGenericRepository<EcSegnalazioniDocumentoImmagine>, GenericRepository<TResourcesDbContext, EcSegnalazioniDocumentoImmagine>>();
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
            services.AddTransient<IGenericRepository<ContactCenterPrintTemplate>, GenericRepository<TResourcesDbContext, ContactCenterPrintTemplate>>();

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
            services.AddTransient<IGenericRepository<ViewGaPresenzeRichiesteRisorse>, GenericRepository<TResourcesDbContext, ViewGaPresenzeRichiesteRisorse>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeRichiesteEventi>, GenericRepository<TResourcesDbContext, ViewGaPresenzeRichiesteEventi>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeRichiesteQualificheRisorse>, GenericRepository<TResourcesDbContext, ViewGaPresenzeRichiesteQualificheRisorse>>();
            services.AddTransient<IGenericRepository<ViewGaPresenzeRichiesteQualificheEventi>, GenericRepository<TResourcesDbContext, ViewGaPresenzeRichiesteQualificheEventi>>();

            //Widget
            services.AddTransient<IGenericRepository<WidgetGaPresenzeSchedule>, GenericRepository<TResourcesDbContext, WidgetGaPresenzeSchedule>>();




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

            //Ost
            #region Ost
            services.AddTransient<IGenericRepository<ViewOstTickets>, GenericRepository<TResourcesDbContext, ViewOstTickets>>();
            #endregion

            //Previsio
            #region Previsio
            services.AddTransient<IGenericRepository<PrevisioOdsLettura>, GenericRepository<TResourcesDbContext, PrevisioOdsLettura>>();
            services.AddTransient<IGenericRepository<PrevisioAnomaliaLettura>, GenericRepository<TResourcesDbContext, PrevisioAnomaliaLettura>>();

            services.AddTransient<IGenericRepository<ViewGaPrevisioOdsReport>, GenericRepository<TResourcesDbContext, ViewGaPrevisioOdsReport>>();
            services.AddTransient<IGenericRepository<ViewGaPrevisioOdsServiziReport>, GenericRepository<TResourcesDbContext, ViewGaPrevisioOdsServiziReport>>();
            services.AddTransient<IGenericRepository<ViewGaPrevisioOdsLetture>, GenericRepository<TResourcesDbContext, ViewGaPrevisioOdsLetture>>();
            #endregion

            //Shortcuts
            #region Shortcuts
            services.AddTransient<IGenericRepository<ShortcutLink>, GenericRepository<TResourcesDbContext, ShortcutLink>>();
            services.AddTransient<IGenericRepository<ShortcutItem>, GenericRepository<TResourcesDbContext, ShortcutItem>>();
            services.AddTransient<IGenericRepository<QuickLink>, GenericRepository<TResourcesDbContext, QuickLink>>();


            services.AddTransient<IGenericRepository<ViewShortcutItems>, GenericRepository<TResourcesDbContext, ViewShortcutItems>>();
            
            #endregion

            //QueryBuilder
            #region QueryBuilder
            services.AddTransient<IGenericRepository<QueryBuilderParamType>,GenericRepository<TResourcesDbContext,QueryBuilderParamType>>();
            services.AddTransient<IGenericRepository<QueryBuilderSection>,GenericRepository<TResourcesDbContext,QueryBuilderSection>>();
            services.AddTransient<IGenericRepository<QueryBuilderParamOnScript>,GenericRepository<TResourcesDbContext,QueryBuilderParamOnScript>>();
            services.AddTransient<IGenericRepository<QueryBuilderScript>,GenericRepository<TResourcesDbContext,QueryBuilderScript>>();

            services.AddTransient<IGenericRepository<ViewQueryBuilderParamOnScripts>, GenericRepository<TResourcesDbContext, ViewQueryBuilderParamOnScripts>>();
            services.AddTransient<IGenericRepository<ViewQueryBuilderScripts>, GenericRepository<TResourcesDbContext, ViewQueryBuilderScripts>>();

            services.AddTransient<IQueryManager, QueryManager<TResourcesDbContext>>();
            #endregion

            //Dashboard
            #region Dashboard
            services.AddTransient<IGenericRepository<DashboardType>, GenericRepository<TResourcesDbContext, DashboardType>>();
            services.AddTransient<IGenericRepository<DashboardSection>, GenericRepository<TResourcesDbContext, DashboardSection>>();
            services.AddTransient<IGenericRepository<DashboardItem>, GenericRepository<TResourcesDbContext, DashboardItem>>();
            services.AddTransient<IGenericRepository<DashboardStore>, GenericRepository<TResourcesDbContext, DashboardStore>>();

            services.AddTransient<IGenericRepository<ViewDashboardItems>, GenericRepository<TResourcesDbContext, ViewDashboardItems>>();
            services.AddTransient<IGenericRepository<ViewDashboardStores>, GenericRepository<TResourcesDbContext, ViewDashboardStores>>();
            # endregion

            //Progetti
            #region Progetti
            services.AddTransient<IGenericRepository<ProgettiWork>, GenericRepository<TResourcesDbContext, ProgettiWork>>();
            services.AddTransient<IGenericRepository<ProgettiJob>, GenericRepository<TResourcesDbContext, ProgettiJob>>();
            services.AddTransient<IGenericRepository<ProgettiJobAllegato>, GenericRepository<TResourcesDbContext, ProgettiJobAllegato>>();
            services.AddTransient<IGenericRepository<ProgettiJobTask>, GenericRepository<TResourcesDbContext, ProgettiJobTask>>();
            services.AddTransient<IGenericRepository<ProgettiWorkSetting>, GenericRepository<TResourcesDbContext, ProgettiWorkSetting>>();
            services.AddTransient<IGenericRepository<ProgettiJobUndertaking>, GenericRepository<TResourcesDbContext, ProgettiJobUndertaking>>();
            services.AddTransient<IGenericRepository<ProgettiJobUndertakingState>, GenericRepository<TResourcesDbContext, ProgettiJobUndertakingState>>();
            services.AddTransient<IGenericRepository<ProgettiJobUndertakingAllegato >, GenericRepository<TResourcesDbContext, ProgettiJobUndertakingAllegato>>();

            services.AddTransient<IGenericRepository<ViewGaProgettiJobs>, GenericRepository<TResourcesDbContext, ViewGaProgettiJobs>>();

            #endregion

            //Tasks
            #region Tasks
            services.AddTransient<IGenericRepository<TasksTag>, GenericRepository<TResourcesDbContext, TasksTag>>();
            services.AddTransient<IGenericRepository<TasksItem>, GenericRepository<TResourcesDbContext, TasksItem>>();
            services.AddTransient<IGenericRepository<TasksAction>, GenericRepository<TResourcesDbContext, TasksAction>>();

            services.AddTransient<IGenericRepository<ViewTasks>, GenericRepository<TResourcesDbContext, ViewTasks>>();
            services.AddTransient<IGenericRepository<ViewTasksTags>, GenericRepository<TResourcesDbContext, ViewTasksTags>>();
            #endregion

            //System
            #region System
            services.AddTransient<IGenericRepository<SystemVersion>, GenericRepository<TResourcesDbContext, SystemVersion>>();
            #endregion

            //Consorzio
            #region Consorzio
            services.AddTransient<IGenericRepository<ConsorzioCer>, GenericRepository<TResourcesDbContext, ConsorzioCer>>();
            services.AddTransient<IGenericRepository<ConsorzioSmaltimento>, GenericRepository<TResourcesDbContext, ConsorzioSmaltimento>>();
            services.AddTransient<IGenericRepository<ConsorzioComune>, GenericRepository<TResourcesDbContext, ConsorzioComune>>();
            services.AddTransient<IGenericRepository<ConsorzioDestinatario>, GenericRepository<TResourcesDbContext, ConsorzioDestinatario>>();
            services.AddTransient<IGenericRepository<ConsorzioProduttore>, GenericRepository<TResourcesDbContext, ConsorzioProduttore>>();
            services.AddTransient<IGenericRepository<ConsorzioTrasportatore>, GenericRepository<TResourcesDbContext, ConsorzioTrasportatore>>();
            services.AddTransient<IGenericRepository<ConsorzioRegistrazione>, GenericRepository<TResourcesDbContext, ConsorzioRegistrazione>>();
            services.AddTransient<IGenericRepository<ConsorzioRegistrazioneAllegato>, GenericRepository<TResourcesDbContext, ConsorzioRegistrazioneAllegato>>();
            services.AddTransient<IGenericRepository<ConsorzioPeriodo>, GenericRepository<TResourcesDbContext, ConsorzioPeriodo>>();
            services.AddTransient<IGenericRepository<ConsorzioOperazione>, GenericRepository<TResourcesDbContext, ConsorzioOperazione>>();
            services.AddTransient<IGenericRepository<ConsorzioImportTask>, GenericRepository<TResourcesDbContext, ConsorzioImportTask>>();
            services.AddTransient<IGenericRepository<ConsorzioComuneDemografia>, GenericRepository<TResourcesDbContext, ConsorzioComuneDemografia>>();

            services.AddTransient<IGenericRepository<ViewConsorzioCers>, GenericRepository<TResourcesDbContext, ViewConsorzioCers>>();
            services.AddTransient<IGenericRepository<ViewConsorzioDestinatari>, GenericRepository<TResourcesDbContext, ViewConsorzioDestinatari>>();
            services.AddTransient<IGenericRepository<ViewConsorzioProduttori>, GenericRepository<TResourcesDbContext, ViewConsorzioProduttori>>();
            services.AddTransient<IGenericRepository<ViewConsorzioTrasportatori>, GenericRepository<TResourcesDbContext, ViewConsorzioTrasportatori>>();
            services.AddTransient<IGenericRepository<ViewConsorzioRegistrazioni>, GenericRepository<TResourcesDbContext, ViewConsorzioRegistrazioni>>();
            services.AddTransient<IGenericRepository<ViewConsorzioComuni>, GenericRepository<TResourcesDbContext, ViewConsorzioComuni>>();
            services.AddTransient<IGenericRepository<ViewConsorzioImportsTasks>, GenericRepository<TResourcesDbContext, ViewConsorzioImportsTasks>>();
            services.AddTransient<IGenericRepository<ViewConsorzioComuniDemografie>, GenericRepository<TResourcesDbContext, ViewConsorzioComuniDemografie>>();
            #endregion

            //Crm
            #region Crm
            services.AddTransient<IGenericRepository<CrmEventState>, GenericRepository<TResourcesDbContext, CrmEventState>>();
            services.AddTransient<IGenericRepository<CrmEventArea>, GenericRepository<TResourcesDbContext, CrmEventArea>>();
            services.AddTransient<IGenericRepository<CrmEventComune>, GenericRepository<TResourcesDbContext, CrmEventComune>>();
            services.AddTransient<IGenericRepository<CrmEvent>, GenericRepository<TResourcesDbContext, CrmEvent>>();
            services.AddTransient<IGenericRepository<CrmEventDevice>, GenericRepository<TResourcesDbContext, CrmEventDevice>>();
            services.AddTransient<IGenericRepository<CrmTicket>, GenericRepository<TResourcesDbContext, CrmTicket>>();
            services.AddTransient<IGenericRepository<CrmTicketTag>, GenericRepository<TResourcesDbContext, CrmTicketTag>>();
            services.AddTransient<IGenericRepository<CrmTicketAllegato>, GenericRepository<TResourcesDbContext, CrmTicketAllegato>>();
            services.AddTransient<IGenericRepository<CrmTicketAzione>, GenericRepository<TResourcesDbContext, CrmTicketAzione>>();

            services.AddTransient<IGenericRepository<ViewGaCrmCanali>, GenericRepository<TResourcesDbContext, ViewGaCrmCanali>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCausali>, GenericRepository<TResourcesDbContext, ViewGaCrmCausali>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCausaliTypes>, GenericRepository<TResourcesDbContext, ViewGaCrmCausaliTypes>>();
            services.AddTransient<IGenericRepository<ViewGaCrmState>, GenericRepository<TResourcesDbContext, ViewGaCrmState>>();
            services.AddTransient<IGenericRepository<ViewGaCrmTickets>, GenericRepository<TResourcesDbContext, ViewGaCrmTickets>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCommercialeTickets>, GenericRepository<TResourcesDbContext, ViewGaCrmCommercialeTickets>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCalendarTickets>, GenericRepository<TResourcesDbContext, ViewGaCrmCalendarTickets>>();
            services.AddTransient<IGenericRepository<ViewGaCrmEventJobs>, GenericRepository<TResourcesDbContext, ViewGaCrmEventJobs>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageUtenze>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageUtenze>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbagePartite>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbagePartite>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageTipologie>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageTipologie>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageProvenienze>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageProvenienze>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageStati>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageStati>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageTicketContactCenter>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageTicketContactCenter>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageTicketMagazzino>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageTicketMagazzino>>();
            #endregion

            //PrenotazioneLocali
            #region PrenotazioneLocali
            services.AddTransient<IGenericRepository<PrenotazioneLocaliRegistrazione>, GenericRepository<TResourcesDbContext, PrenotazioneLocaliRegistrazione>>();
            services.AddTransient<IGenericRepository<PrenotazioneLocaliSede>, GenericRepository<TResourcesDbContext, PrenotazioneLocaliSede>>();
            services.AddTransient<IGenericRepository<PrenotazioneLocaliUfficio>, GenericRepository<TResourcesDbContext, PrenotazioneLocaliUfficio>>();

            services.AddTransient<IGenericRepository<ViewGaPrenotazioneLocaliUffici>, GenericRepository<TResourcesDbContext, ViewGaPrenotazioneLocaliUffici>>();
            services.AddTransient<IGenericRepository<ViewGaPrenotazioneLocaliRegistrazioni>, GenericRepository<TResourcesDbContext, ViewGaPrenotazioneLocaliRegistrazioni>>();
            #endregion

            //Emz
            #region Emz

            services.AddTransient<IGenericRepository<ViewEmzWhiteList>, GenericRepository<TResourcesDbContext, ViewEmzWhiteList>>();
            #endregion

            //Dispositivi
            #region Dispositivi

            services.AddTransient<IGenericRepository<DispositiviCategoria>, GenericRepository<TResourcesDbContext, DispositiviCategoria>>();
            services.AddTransient<IGenericRepository<DispositiviClasse>, GenericRepository<TResourcesDbContext, DispositiviClasse>>();
            services.AddTransient<IGenericRepository<DispositiviItem>, GenericRepository<TResourcesDbContext, DispositiviItem>>();
            services.AddTransient<IGenericRepository<DispositiviMarca>, GenericRepository<TResourcesDbContext, DispositiviMarca>>();
            services.AddTransient<IGenericRepository<DispositiviModello>, GenericRepository<TResourcesDbContext, DispositiviModello>>();
            services.AddTransient<IGenericRepository<DispositiviModulo>, GenericRepository<TResourcesDbContext, DispositiviModulo>>();
            services.AddTransient<IGenericRepository<DispositiviOnDipendente>, GenericRepository<TResourcesDbContext, DispositiviOnDipendente>>();
            services.AddTransient<IGenericRepository<DispositiviOnModulo>, GenericRepository<TResourcesDbContext, DispositiviOnModulo>>();
            services.AddTransient<IGenericRepository<DispositiviStock>, GenericRepository<TResourcesDbContext, DispositiviStock>>();
            services.AddTransient<IGenericRepository<DispositiviTipologia>, GenericRepository<TResourcesDbContext, DispositiviTipologia>>();

            services.AddTransient<IGenericRepository<ViewGaDispositiviItems>, GenericRepository<TResourcesDbContext, ViewGaDispositiviItems>>();
            services.AddTransient<IGenericRepository<ViewGaDispositiviOnDipendenti>, GenericRepository<TResourcesDbContext, ViewGaDispositiviOnDipendenti>>();
            services.AddTransient<IGenericRepository<ViewGaDispositiviOnModuli>, GenericRepository<TResourcesDbContext, ViewGaDispositiviOnModuli>>();
            services.AddTransient<IGenericRepository<ViewGaDispositiviStocks>, GenericRepository<TResourcesDbContext, ViewGaDispositiviStocks>>();

            #endregion

            //SmartCity
            #region SmartCity

            services.AddTransient<IGenericRepository<SmartCityPermission>, GenericRepository<TResourcesDbContext, SmartCityPermission>>();

            services.AddTransient<IGenericRepository<ViewGaSmartCityPermissions>, GenericRepository<TResourcesDbContext, ViewGaSmartCityPermissions>>();

            #endregion

            //Preventivi
            #region Preventivi

            services.AddTransient<IGenericRepository<PreventiviAnticipoTipologia>, GenericRepository<TResourcesDbContext, PreventiviAnticipoTipologia>>();
            services.AddTransient<IGenericRepository<PreventiviAnticipoPagamento>, GenericRepository<TResourcesDbContext, PreventiviAnticipoPagamento>>();
            services.AddTransient<IGenericRepository<PreventiviAnticipo>, GenericRepository<TResourcesDbContext, PreventiviAnticipo>>();
            services.AddTransient<IGenericRepository<PreventiviAnticipoAllegato>, GenericRepository<TResourcesDbContext, PreventiviAnticipoAllegato>>();
            services.AddTransient<IGenericRepository<PreventiviObject>, GenericRepository<TResourcesDbContext, PreventiviObject>>();
            services.AddTransient<IGenericRepository<PreventiviObjectAttachment>, GenericRepository<TResourcesDbContext, PreventiviObjectAttachment>>();
            services.AddTransient<IGenericRepository<PreventiviObjectStatus>, GenericRepository<TResourcesDbContext, PreventiviObjectStatus>>();
            services.AddTransient<IGenericRepository<PreventiviObjectType>, GenericRepository<TResourcesDbContext, PreventiviObjectType>>();
            services.AddTransient<IGenericRepository<PreventiviAction>, GenericRepository<TResourcesDbContext, PreventiviAction>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspection>, GenericRepository<TResourcesDbContext, PreventiviObjectInspection>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionMode>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionMode>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionAttachment>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionAttachment>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionImage>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionImage>>();
            services.AddTransient<IGenericRepository<PreventiviObjectServiceType>, GenericRepository<TResourcesDbContext, PreventiviObjectServiceType>>();
            services.AddTransient<IGenericRepository<PreventiviObjectServiceTypeDetail>, GenericRepository<TResourcesDbContext, PreventiviObjectServiceTypeDetail>>();
            services.AddTransient<IGenericRepository<PreventiviObjectService>, GenericRepository<TResourcesDbContext, PreventiviObjectService>>();
            services.AddTransient<IGenericRepository<PreventiviObjectSection>, GenericRepository<TResourcesDbContext, PreventiviObjectSection>>();
            services.AddTransient<IGenericRepository<PreventiviGarbage>, GenericRepository<TResourcesDbContext, PreventiviGarbage>>();
            services.AddTransient<IGenericRepository<PreventiviServiceNoteTemplate>, GenericRepository<TResourcesDbContext, PreventiviServiceNoteTemplate>>();
            services.AddTransient<IGenericRepository<PreventiviConditionTemplate>, GenericRepository<TResourcesDbContext, PreventiviConditionTemplate>>();
            services.AddTransient<IGenericRepository<PreventiviObjectPeriod>, GenericRepository<TResourcesDbContext, PreventiviObjectPeriod>>();
            services.AddTransient<IGenericRepository<PreventiviObjectPayout>, GenericRepository<TResourcesDbContext, PreventiviObjectPayout>>();
            services.AddTransient<IGenericRepository<PreventiviObjectCondition>, GenericRepository<TResourcesDbContext, PreventiviObjectCondition>>();
            services.AddTransient<IGenericRepository<PreventiviDestination>, GenericRepository<TResourcesDbContext, PreventiviDestination>>();
            services.AddTransient<IGenericRepository<PreventiviProducer>, GenericRepository<TResourcesDbContext, PreventiviProducer>>();
            services.AddTransient<IGenericRepository<PreventiviObjectHistory>, GenericRepository<TResourcesDbContext, PreventiviObjectHistory>>();
            services.AddTransient<IGenericRepository<PreventiviPaymentTerm>, GenericRepository<TResourcesDbContext, PreventiviPaymentTerm>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionNotePreliminariTemplate>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionNotePreliminariTemplate>>();
            services.AddTransient<IGenericRepository<PreventiviIsmartDocumento>, GenericRepository<TResourcesDbContext, PreventiviIsmartDocumento>>();



            services.AddTransient<IGenericRepository<ViewGaPreventiviAnticipi>, GenericRepository<TResourcesDbContext, ViewGaPreventiviAnticipi>>();
            services.AddTransient<IGenericRepository<ViewGaPreventiviCrmTickets>, GenericRepository<TResourcesDbContext, ViewGaPreventiviCrmTickets>>();
            services.AddTransient<IGenericRepository<ViewGaPreventiviIsmartDocumenti>, GenericRepository<TResourcesDbContext, ViewGaPreventiviIsmartDocumenti>>();


            #endregion

            //CreDeb
            #region CreDeb

            services.AddTransient<IGenericRepository<CreDebCanale>, GenericRepository<TResourcesDbContext, CreDebCanale>>();
            services.AddTransient<IGenericRepository<CreDebConto>, GenericRepository<TResourcesDbContext, CreDebConto>>();
            services.AddTransient<IGenericRepository<CreDebIncassiInObject>, GenericRepository<TResourcesDbContext, CreDebIncassiInObject>>();
            services.AddTransient<IGenericRepository<CreDebIncassiInObjectDetail>, GenericRepository<TResourcesDbContext, CreDebIncassiInObjectDetail>>();

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
            services.AddTransient<IGenericRepository<ContrattiSoggetto>, GenericRepository<TResourcesDbContext, ContrattiSoggetto>>();
            services.AddTransient<IGenericRepository<ContrattiDocumento>, GenericRepository<TResourcesDbContext, ContrattiDocumento>>();
            services.AddTransient<IGenericRepository<ContrattiDocumentoAllegato>, GenericRepository<TResourcesDbContext, ContrattiDocumentoAllegato>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaContrattiUtenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiUtentiOnPermessi>, GenericRepository<TResourcesDbContext, ViewGaContrattiUtentiOnPermessi>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumenti>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumenti>>();
            services.AddTransient<IGenericRepository<ViewGaContrattiDocumentiScadenziario>, GenericRepository<TResourcesDbContext, ViewGaContrattiDocumentiScadenziario>>();
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

            //Emz
            #region Emz

            services.AddTransient<IGenericRepository<ViewEmzWhiteList>, GenericRepository<TResourcesDbContext, ViewEmzWhiteList>>();
            #endregion

            //Crm
            #region Crm
            services.AddTransient<IGenericRepository<CrmEventState>, GenericRepository<TResourcesDbContext, CrmEventState>>();
            services.AddTransient<IGenericRepository<CrmEventArea>, GenericRepository<TResourcesDbContext, CrmEventArea>>();
            services.AddTransient<IGenericRepository<CrmEventComune>, GenericRepository<TResourcesDbContext, CrmEventComune>>();
            services.AddTransient<IGenericRepository<CrmEvent>, GenericRepository<TResourcesDbContext, CrmEvent>>();
            services.AddTransient<IGenericRepository<CrmEventDevice>, GenericRepository<TResourcesDbContext, CrmEventDevice>>();
            services.AddTransient<IGenericRepository<CrmTicket>, GenericRepository<TResourcesDbContext, CrmTicket>>();
            services.AddTransient<IGenericRepository<CrmTicketTag>, GenericRepository<TResourcesDbContext, CrmTicketTag>>();
            services.AddTransient<IGenericRepository<CrmTicketAllegato>, GenericRepository<TResourcesDbContext, CrmTicketAllegato>>();
            services.AddTransient<IGenericRepository<CrmTicketAzione>, GenericRepository<TResourcesDbContext, CrmTicketAzione>>();

            services.AddTransient<IGenericRepository<ViewGaCrmCanali>, GenericRepository<TResourcesDbContext, ViewGaCrmCanali>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCausali>, GenericRepository<TResourcesDbContext, ViewGaCrmCausali>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCausaliTypes>, GenericRepository<TResourcesDbContext, ViewGaCrmCausaliTypes>>();
            services.AddTransient<IGenericRepository<ViewGaCrmState>, GenericRepository<TResourcesDbContext, ViewGaCrmState>>();
            services.AddTransient<IGenericRepository<ViewGaCrmTickets>, GenericRepository<TResourcesDbContext, ViewGaCrmTickets>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCommercialeTickets>, GenericRepository<TResourcesDbContext, ViewGaCrmCommercialeTickets>>();
            services.AddTransient<IGenericRepository<ViewGaCrmCalendarTickets>, GenericRepository<TResourcesDbContext, ViewGaCrmCalendarTickets>>();
            services.AddTransient<IGenericRepository<ViewGaCrmEventJobs>, GenericRepository<TResourcesDbContext, ViewGaCrmEventJobs>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageUtenze>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageUtenze>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbagePartite>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbagePartite>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageTipologie>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageTipologie>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageProvenienze>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageProvenienze>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageStati>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageStati>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageTicketContactCenter>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageTicketContactCenter>>();
            services.AddTransient<IGenericRepository<ViewGaCrmGarbageTicketMagazzino>, GenericRepository<TResourcesDbContext, ViewGaCrmGarbageTicketMagazzino>>();
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
            services.AddTransient<IGenericRepository<ContactCenterPrintTemplate>, GenericRepository<TResourcesDbContext, ContactCenterPrintTemplate>>();

            //Views
            services.AddTransient<IGenericRepository<ViewGaContactCenterTickets>, GenericRepository<TResourcesDbContext, ViewGaContactCenterTickets>>();
            services.AddTransient<IGenericRepository<ViewFoContactCenterTickets>, GenericRepository<TResourcesDbContext, ViewFoContactCenterTickets>>();
            services.AddTransient<IGenericRepository<ViewGaContactCenterTicketsIngombranti>, GenericRepository<TResourcesDbContext, ViewGaContactCenterTicketsIngombranti>>();

            #endregion

            //BackOffice
            #region BackOffice
            services.AddTransient<IGenericRepository<BackOfficeTicket>, GenericRepository<TResourcesDbContext, BackOfficeTicket>>();
            services.AddTransient<IGenericRepository<BackOfficeParametroOnCategoria>, GenericRepository<TResourcesDbContext, BackOfficeParametroOnCategoria>>();
            services.AddTransient<IGenericRepository<BackOfficeMargine>, GenericRepository<TResourcesDbContext, BackOfficeMargine>>();
            services.AddTransient<IGenericRepository<BackOfficeZona>, GenericRepository<TResourcesDbContext, BackOfficeZona>>();
            services.AddTransient<IGenericRepository<BackOfficeDocReceipt>, GenericRepository<TResourcesDbContext, BackOfficeDocReceipt>>();

            services.AddTransient<IGenericRepository<ViewGaBackOfficeComuni>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeComuni>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeGrouped>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeGrouped>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeNdUtenze>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeNdUtenze>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeNdUtenzeGrouped>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeContenitoriLetture>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeContenitoriLetture>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeZone>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeZone>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenze>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenze>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeZone>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeZone>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartite>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartite>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartiteDetail>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartiteDetail>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartiteGrp>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartiteGrp>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeDispositivi>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeDispositivi>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeTipCon>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeTipCon>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeInsolutoTariNovi>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeInsolutoTariNovi>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeNovi>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeNovi>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeCliFat>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeCliFat>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzeCliSed>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzeCliSed>>();
            services.AddTransient<IGenericRepository<ViewGaBackOfficeUtenzePartiteVariazioni>, GenericRepository<TResourcesDbContext, ViewGaBackOfficeUtenzePartiteVariazioni>>();


            //Sp
            services.AddTransient<IProcedureManager<SpGaBackOfficeUtenze>, ProcedureManager<TResourcesDbContext, SpGaBackOfficeUtenze>>();
            services.AddTransient<IProcedureManager<SpGaBackOfficeUtenzePartite>, ProcedureManager<TResourcesDbContext, SpGaBackOfficeUtenzePartite>>();
            services.AddTransient<IProcedureManager<SpGaBackOfficeUtenzeDispositivi>, ProcedureManager<TResourcesDbContext, SpGaBackOfficeUtenzeDispositivi>>();
            #endregion

            //Previsio
            #region Previsio
            services.AddTransient<IGenericRepository<PrevisioOdsLettura>, GenericRepository<TResourcesDbContext, PrevisioOdsLettura>>();
            services.AddTransient<IGenericRepository<PrevisioAnomaliaLettura>, GenericRepository<TResourcesDbContext, PrevisioAnomaliaLettura>>();

            services.AddTransient<IGenericRepository<ViewGaPrevisioOdsReport>, GenericRepository<TResourcesDbContext, ViewGaPrevisioOdsReport>>();
            services.AddTransient<IGenericRepository<ViewGaPrevisioOdsServiziReport>, GenericRepository<TResourcesDbContext, ViewGaPrevisioOdsServiziReport>>();
            services.AddTransient<IGenericRepository<ViewGaPrevisioOdsLetture>, GenericRepository<TResourcesDbContext, ViewGaPrevisioOdsLetture>>();
            #endregion

            //Preventivi
            #region Preventivi

            services.AddTransient<IGenericRepository<PreventiviAnticipoTipologia>, GenericRepository<TResourcesDbContext, PreventiviAnticipoTipologia>>();
            services.AddTransient<IGenericRepository<PreventiviAnticipoPagamento>, GenericRepository<TResourcesDbContext, PreventiviAnticipoPagamento>>();
            services.AddTransient<IGenericRepository<PreventiviAnticipo>, GenericRepository<TResourcesDbContext, PreventiviAnticipo>>();
            services.AddTransient<IGenericRepository<PreventiviAnticipoAllegato>, GenericRepository<TResourcesDbContext, PreventiviAnticipoAllegato>>();
            services.AddTransient<IGenericRepository<PreventiviObject>, GenericRepository<TResourcesDbContext, PreventiviObject>>();
            services.AddTransient<IGenericRepository<PreventiviObjectAttachment>, GenericRepository<TResourcesDbContext, PreventiviObjectAttachment>>();
            services.AddTransient<IGenericRepository<PreventiviObjectStatus>, GenericRepository<TResourcesDbContext, PreventiviObjectStatus>>();
            services.AddTransient<IGenericRepository<PreventiviObjectType>, GenericRepository<TResourcesDbContext, PreventiviObjectType>>();
            services.AddTransient<IGenericRepository<PreventiviAction>, GenericRepository<TResourcesDbContext, PreventiviAction>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspection>, GenericRepository<TResourcesDbContext, PreventiviObjectInspection>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionMode>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionMode>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionAttachment>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionAttachment>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionImage>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionImage>>();
            services.AddTransient<IGenericRepository<PreventiviObjectServiceType>, GenericRepository<TResourcesDbContext, PreventiviObjectServiceType>>();
            services.AddTransient<IGenericRepository<PreventiviObjectServiceTypeDetail>, GenericRepository<TResourcesDbContext, PreventiviObjectServiceTypeDetail>>();
            services.AddTransient<IGenericRepository<PreventiviObjectService>, GenericRepository<TResourcesDbContext, PreventiviObjectService>>();
            services.AddTransient<IGenericRepository<PreventiviObjectSection>, GenericRepository<TResourcesDbContext, PreventiviObjectSection>>();
            services.AddTransient<IGenericRepository<PreventiviGarbage>, GenericRepository<TResourcesDbContext, PreventiviGarbage>>();
            services.AddTransient<IGenericRepository<PreventiviServiceNoteTemplate>, GenericRepository<TResourcesDbContext, PreventiviServiceNoteTemplate>>();
            services.AddTransient<IGenericRepository<PreventiviConditionTemplate>, GenericRepository<TResourcesDbContext, PreventiviConditionTemplate>>();
            services.AddTransient<IGenericRepository<PreventiviObjectPeriod>, GenericRepository<TResourcesDbContext, PreventiviObjectPeriod>>();
            services.AddTransient<IGenericRepository<PreventiviObjectPayout>, GenericRepository<TResourcesDbContext, PreventiviObjectPayout>>();
            services.AddTransient<IGenericRepository<PreventiviObjectCondition>, GenericRepository<TResourcesDbContext, PreventiviObjectCondition>>();
            services.AddTransient<IGenericRepository<PreventiviDestination>, GenericRepository<TResourcesDbContext, PreventiviDestination>>();
            services.AddTransient<IGenericRepository<PreventiviProducer>, GenericRepository<TResourcesDbContext, PreventiviProducer>>();
            services.AddTransient<IGenericRepository<PreventiviObjectHistory>, GenericRepository<TResourcesDbContext, PreventiviObjectHistory>>();
            services.AddTransient<IGenericRepository<PreventiviPaymentTerm>, GenericRepository<TResourcesDbContext, PreventiviPaymentTerm>>();
            services.AddTransient<IGenericRepository<PreventiviObjectInspectionNotePreliminariTemplate>, GenericRepository<TResourcesDbContext, PreventiviObjectInspectionNotePreliminariTemplate>>();
            services.AddTransient<IGenericRepository<PreventiviIsmartDocumento>, GenericRepository<TResourcesDbContext, PreventiviIsmartDocumento>>();



            services.AddTransient<IGenericRepository<ViewGaPreventiviAnticipi>, GenericRepository<TResourcesDbContext, ViewGaPreventiviAnticipi>>();
            services.AddTransient<IGenericRepository<ViewGaPreventiviCrmTickets>, GenericRepository<TResourcesDbContext, ViewGaPreventiviCrmTickets>>();
            services.AddTransient<IGenericRepository<ViewGaPreventiviIsmartDocumenti>, GenericRepository<TResourcesDbContext, ViewGaPreventiviIsmartDocumenti>>();


            #endregion


            //QueryBuilder
            #region QueryBuilder
            services.AddTransient<IGenericRepository<QueryBuilderParamType>, GenericRepository<TResourcesDbContext, QueryBuilderParamType>>();
            services.AddTransient<IGenericRepository<QueryBuilderSection>, GenericRepository<TResourcesDbContext, QueryBuilderSection>>();
            services.AddTransient<IGenericRepository<QueryBuilderParamOnScript>, GenericRepository<TResourcesDbContext, QueryBuilderParamOnScript>>();
            services.AddTransient<IGenericRepository<QueryBuilderScript>, GenericRepository<TResourcesDbContext, QueryBuilderScript>>();

            services.AddTransient<IGenericRepository<ViewQueryBuilderParamOnScripts>, GenericRepository<TResourcesDbContext, ViewQueryBuilderParamOnScripts>>();
            services.AddTransient<IGenericRepository<ViewQueryBuilderScripts>, GenericRepository<TResourcesDbContext, ViewQueryBuilderScripts>>();

            services.AddTransient<IQueryManager, QueryManager<TResourcesDbContext>>();
            #endregion

            return services;
        }
    }
}
