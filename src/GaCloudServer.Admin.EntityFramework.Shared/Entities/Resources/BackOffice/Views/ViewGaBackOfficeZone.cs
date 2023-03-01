using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeZone : GenericEntity
    {
        public string Comune { get; set; }
        public string Via { get; set; }
        public string Civico { get; set; }
        public string Zona { get; set; }
    }
}
