using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using Microsoft.EntityFrameworkCore;

namespace GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces
{
    public interface IResourcesDbContext
    {
        DbSet<AutorizzazioneTipo> GaAutorizzazioniTipi { get; set; }
    }
}
