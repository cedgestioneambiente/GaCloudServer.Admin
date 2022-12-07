using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeResponsabiliOnSettori:GenericEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public string CognomeNome { get; set; }
        public string UserId { get; set; }
        public long GlobalIdSettore { get; set; }
        public string Settore { get; set; }
        public bool Abilitato { get; set; }
    }
}
