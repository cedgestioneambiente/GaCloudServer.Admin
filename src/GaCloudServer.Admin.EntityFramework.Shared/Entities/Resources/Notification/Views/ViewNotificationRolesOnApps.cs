using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views
{
    public class ViewNotificationRolesOnApps:GenericListEntity
    {
        public string Info { get; set; }
        public string RoleId { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
