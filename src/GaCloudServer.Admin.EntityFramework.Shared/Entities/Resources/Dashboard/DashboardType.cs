using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard
{
    public class DashboardType:GenericEntity
    {
        public string Descrizione { get; set; }
        public string Type { get; set; }
    }
}
