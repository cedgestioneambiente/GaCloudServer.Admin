using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Notification
{
    public class NotificationAppDto:GenericListDto
    {
        public string Info { get; set; }
        public string Icon { get; set; }
    }

    public class NotificationAppsDto : GenericPagedListDto<NotificationAppDto>
    { }

    public class NotificationRoleOnAppDto : GenericDto
    { 
        public long NotificationAppId { get; set; }
        public string RoleId { get; set; }
    }

    public class NotificationRolesOnAppsDto:GenericPagedListDto<NotificationRoleOnAppDto>
    { }

    public class NotificationUserOnAppDto : GenericDto
    { 
        public long NotificationAppId { get; set; }
        public string UserId { get; set; }
    }

    public class NotificationUsersOnAppsDto : GenericPagedListDto<NotificationUserOnAppDto>
    { }

    public class NotificationEventDto : GenericDto
    {
        public DateTime DateEvent { get; set; }
        public string UserId { get; set; }
        public long NotificationAppId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public bool Routing { get; set; }
        public bool Read { get; set; }
    }

    public class NotificationEventsDto : GenericPagedListDto<NotificationEventDto>
    { }
}

