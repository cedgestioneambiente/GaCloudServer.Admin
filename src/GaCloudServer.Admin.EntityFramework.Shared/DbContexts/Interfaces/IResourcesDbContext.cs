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

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces
{
    public interface IResourcesDbContext
    {
        #region GaAutorizzazioni Tables
        DbSet<AutorizzazioniTipo> GaAutorizzazioniTipi { get; set; }
        DbSet<AutorizzazioniDocumento> GaAutorizzazioniDocumenti { get; set; }
        DbSet<AutorizzazioniAllegato> GaAutorizzazioniAllegati { get; set; }

        //#region Views
        DbSet<ViewGaAutorizzazioniDocumenti> ViewGaAutorizzazioniDocumenti { get; set; }
        //#endregion
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

        //#region Views
        DbSet<ViewGaCdrCersOnCentri> ViewGaCdrCersOnCentri { get; set; }
        DbSet<ViewGaCdrComuniOnCentri> ViewGaCdrComuniOnCentri { get; set; }
        DbSet<ViewGaCdrComuni> ViewGaCdrComuni { get; set; }
        DbSet<ViewGaCdrConferimenti> ViewGaCdrConferimenti { get; set; }
        DbSet<ViewGaCdrRichiesteViaggi> ViewGaCdrRichiesteViaggi { get; set; }
        DbSet<ViewGaCdrUtenti> ViewGaCdrUtenti { get; set; }
        //#endregion
        #endregion

        #region GaContratti Tables
        DbSet<ContrattiPermesso> GaContrattiPermessi { get; set; }
        DbSet<ContrattiServizio> GaContrattiServizi { get; set; }
        DbSet<ContrattiTipologia> GaContrattiTipologie { get; set; }
        DbSet<ContrattiUtenteOnPermesso> GaContrattiUtentiOnPermessi { get; set; }

        //#region Views
        DbSet<ViewGaContrattiUtenti> ViewGaContrattiUtenti { get; set; }
        DbSet<ViewGaContrattiUtentiOnPermessi> ViewGaContrattiUtentiOnPermessi { get; set; }
        //#endregion
        #endregion

        #region GaComunicati Tables
        DbSet<ComunicatiDocumento> GaComunicatiDocumenti { get; set; }
        #endregion

        #region GaMezzi Tables
        DbSet<MezziVeicolo> GaMezziVeicoli { get; set; }
        DbSet<MezziAlimentazione> GaMezziAlimentazioni { get; set; }
        DbSet<MezziCantiere> GaMezziCantieri { get; set; }
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

        #region GaAutorizzazioni Tables
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

    }
}