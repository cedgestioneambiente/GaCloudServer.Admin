using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeResponsabili:GenericEntity
    {
        public long DipendenteId { get; set; }
        public string CognomeNome { get; set; }
    }
}
