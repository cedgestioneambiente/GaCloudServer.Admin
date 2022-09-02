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

        #endregion
    }
}
