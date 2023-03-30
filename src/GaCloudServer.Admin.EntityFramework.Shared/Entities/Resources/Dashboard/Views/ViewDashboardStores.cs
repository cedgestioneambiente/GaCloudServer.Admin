using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard.Views
{
    public class ViewDashboardStores:GenericEntity
    {
        public long DashId { get; set; }
        public string UserId { get; set; }
        public string DashRoles { get; set; }
        public string DashTitle { get; set; }
        public string DashDesc { get; set; }
        public long DashTypeId { get; set; }
        public string DashType { get; set; }
        public string DashTypeDesc { get; set; }
        public long DashSectionId { get; set; }
        public string DashSection { get; set; }
        public string DashScript { get; set; }
        public int Order { get; set; }
        public bool Enabled { get; set; }
    }
}
