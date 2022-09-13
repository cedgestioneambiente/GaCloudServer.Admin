using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using Microsoft.EntityFrameworkCore;

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

        //#region Views
        DbSet<ViewGaCdrCersOnCentri> ViewGaCdrCersOnCentri { get; set; }
        DbSet<ViewGaCdrComuniOnCentri> ViewGaCdrComuniOnCentri { get; set; }
        DbSet<ViewGaCdrComuni> ViewGaCdrComuni { get; set; }
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

    }
}