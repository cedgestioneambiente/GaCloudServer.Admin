using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard
{
    public class DashboardItem : GenericEntity
    {
        public long DashboardSectionId { get; set; }
        public long DashboardTypeId { get; set; }
        public string Title { get; set; }
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public string Roles { get; set; }

        public DashboardSection DashboardSection { get; set; }
        public DashboardType DashboardType { get; set; }
    }
}
