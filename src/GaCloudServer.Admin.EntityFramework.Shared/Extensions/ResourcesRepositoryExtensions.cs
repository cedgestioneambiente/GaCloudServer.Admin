using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views;
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
            services.AddTransient<IGenericRepository<MezziCantiere>, GenericRepository<TResourcesDbContext, MezziCantiere>>();
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
            services.AddTransient<IGenericRepository<SpGaContrattiNumeratore>, GenericRepository<TResourcesDbContext, SpGaContrattiNumeratore>>();
            services.AddTransient<IGenericRepository<SpGaContrattiPermesso>, GenericRepository<TResourcesDbContext, SpGaContrattiPermesso>>();
            services.AddTransient<IGenericRepository<SpGaContrattiPermessoMode>, GenericRepository<TResourcesDbContext, SpGaContrattiPermessoMode>>();

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


            return services; 
        }
    }
}
