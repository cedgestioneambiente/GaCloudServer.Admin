using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectStatus:GenericListAuditableEntity
    {
        public int? Order { get; set; }
    }

}
