using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Notifiation
{
    public class NotificationAppDto:GenericListDto
    {
        public string Info { get; set; }
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
}

