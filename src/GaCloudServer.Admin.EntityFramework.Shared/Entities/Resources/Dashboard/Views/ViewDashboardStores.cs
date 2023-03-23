using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard.Views
{
    public class ViewDashboardStores:GenericEntity
    {
        public string UserId { get; set; }
        public string Type { get; set; }
        public long TypeId { get; set; }
        public string Section { get; set; }
        public string SectionId { get; set; }
        public string Title { get; set; }
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public int Order { get; set; }
    }
}
