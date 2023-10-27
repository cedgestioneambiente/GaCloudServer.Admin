using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmEventComune : GenericListAuditableEntity
    {
        public string CodAzi { get; set; }
        public long Duration { get; set; }
    }
}
