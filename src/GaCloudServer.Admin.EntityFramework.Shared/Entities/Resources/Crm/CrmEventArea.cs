using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmEventArea : GenericListAuditableEntity
    {
        public string Days { get; set; }
        public string Color { get; set; }
    }
}
