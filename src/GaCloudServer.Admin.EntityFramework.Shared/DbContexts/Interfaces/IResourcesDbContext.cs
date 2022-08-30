using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using Microsoft.EntityFrameworkCore;

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces
{
    public interface IResourcesDbContext
    {
        #region GaAutorizzazioni Tables
        //DbSet<Autorizzazione> GaAutorizzazioni { get; set; }
        DbSet<AutorizzazioniTipo> GaAutorizzazioniTipi { get; set; }
        DbSet<AutorizzazioniDocumento> GaAutorizzazioniDocumenti { get; set; }
        DbSet<AutorizzazioniAllegato> GaAutorizzazioniAllegati { get; set; }

        //#region Views
        DbSet<ViewGaAutorizzazioniDocumenti> ViewGaAutorizzazioniDocumenti { get; set; }
        //#endregion
        #endregion

        #region GaContratti Tables
        //DbSet<Contratto> GaContratti { get; set; }
        //DbSet<ContrattoFornitore> GaContrattiFornitori { get; set; }
        //DbSet<ContrattoModalita> GaContrattiModalitas { get; set; }
        DbSet<ContrattoPermesso> GaContrattiPermessi { get; set; }
        DbSet<ContrattoServizio> GaContrattiServizi { get; set; }
        DbSet<ContrattoTipologia> GaContrattiTipologie { get; set; }
        DbSet<ContrattoUtenteOnPermesso> GaContrattiUtentiOnPermessi { get; set; }

        //#region Views
        //DbSet<ViewGaContrattoUtente> ViewGaContrattiUtenti { get; set; }
        //DbSet<ViewGaContrattoUtenteOnPermesso> ViewGaContrattiUtentiOnPermessi { get; set; }
        //DbSet<ViewGaContratto> ViewGaContratti { get; set; }
        //DbSet<ViewGaContrattoList> ViewGaContrattiList { get; set; }
        //DbSet<ViewGaContrattoNumeratore> ViewGaContrattiNumeratori { get; set; }
        //#endregion

        //#region Sp
        //DbSet<SpGaContrattoNumeratore> SpGaContrattiNumeratori { get; set; }
        //DbSet<SpGaContrattoPermesso> SpGaContrattiPermessi { get; set; }
        //DbSet<SpGaContrattoPermessoMode> SpGaContrattiPermessiMode { get; set; }
        //#endregion

        #endregion

        #region GaCdr Tables
        //DbSet<CdrAccount> GaCdrAccounts { get; set; }
        //DbSet<CdrAccountRuolo> GaCdrAccountsRuoli { get; set; }
        //DbSet<CdrAppVersione> GaCdrAppsVersioni { get; set; }
        DbSet<CdrCentro> GaCdrCentri { get; set; }
        DbSet<CdrCer> GaCdrCers { get; set; }
        DbSet<CdrCerDettaglio> GaCdrCersDettagli { get; set; }
        DbSet<CdrCerOnCentro> GaCdrCersOnCentri { get; set; }
        DbSet<CdrComune> GaCdrComuni { get; set; }
        DbSet<CdrComuneOnCentro> GaCdrComuniOnCentri { get; set; }
        //DbSet<CdrComunicazione> GaCdrComunicazioni { get; set; }
        //DbSet<CdrComunicazioneLetta> GaCdrComunicazioniLette { get; set; }
        //DbSet<CdrConferimento> GaCdrConferimenti { get; set; }
        //DbSet<CdrRichiestaSvuotamento> GaCdrRichiesteSvuotamenti { get; set; }
        //DbSet<CdrRichiestaViaggio> GaCdrRichiesteViaggi { get; set; }
        //DbSet<CdrSessione> GaCdrSessioni { get; set; }
        //DbSet<CdrStatoRichiesta> GaCdrStatiRichieste { get; set; }
        //DbSet<CdrUtente> GaCdrUtenti { get; set; }

        #region Views
        //DbSet<ViewGaCdrAccount> ViewGaCdrAccounts { get; set; }
        //DbSet<ViewGaCdrComuneOnCentro> ViewGaCdrComuniOnCentri { get; set; }
        //DbSet<ViewGaCdrCerOnCentro> ViewGaCdrCersOnCentri { get; set; }
        //DbSet<ViewGaCdrUtente> ViewGaCdrUtenti { get; set; }
        //DbSet<ViewGaCdrComune> ViewGaCdrComuni { get; set; }
        //DbSet<ViewGaCdrConferimenti> ViewGaCdrConferimenti { get; set; }
        //DbSet<ViewGaCdrRichiestaViaggio> ViewGaCdrRichiesteViaggi { get; set; }
        #endregion
        #endregion
    }
}
