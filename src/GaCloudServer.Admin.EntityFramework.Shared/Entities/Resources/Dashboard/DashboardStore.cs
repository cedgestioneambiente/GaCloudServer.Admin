using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard
{
    public class DashboardStore : GenericEntity
    {
        public long DashboardItemId { get; set; }
        public string UserId { get; set; }
        public int Order { get; set; }

        public DashboardItem DashboardItem { get; set; }
    }
}
