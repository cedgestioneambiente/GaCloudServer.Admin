using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification
{
    public class NotificationRoleOnApp:GenericEntity
    {
        public string RoleId { get; set; }
        public long NotificationAppId { get; set; }

        public NotificationApp NotificationApp { get; set; }

    }
}
