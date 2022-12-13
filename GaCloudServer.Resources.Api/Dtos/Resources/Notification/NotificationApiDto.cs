using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Dtos.Resources.Notification
{

    public class NotificationAppApiDto : GenericListApiDto
    {
        public string Info { get; set; }
        public string Icon { get; set; }
    }

    public class NotificationAppsApiDto : GenericPagedListApiDto<NotificationAppApiDto>
    { }

    public class NotificationRoleOnAppApiDto : GenericApiDto
    {
        public long NotificationAppId { get; set; }
        public string RoleId { get; set; }
    }

    public class NotificationRolesOnAppsApiDto : GenericPagedListApiDto<NotificationRoleOnAppApiDto>
    { }

    public class NotificationUserOnAppApiDto : GenericApiDto
    {
        public long NotificationAppId { get; set; }
        public string UserId { get; set; }
    }

    public class NotificationUsersOnAppsApiDto : GenericPagedListApiDto<NotificationUserOnAppApiDto>
    { }
    
}
