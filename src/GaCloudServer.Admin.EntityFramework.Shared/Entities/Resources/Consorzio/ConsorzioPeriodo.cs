using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioPeriodo : GenericListAuditableEntity
    {
        public int Giorni { get; set; }
    }
}
