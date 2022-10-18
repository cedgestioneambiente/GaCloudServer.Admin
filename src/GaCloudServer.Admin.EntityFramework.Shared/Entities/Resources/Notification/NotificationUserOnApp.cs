using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification
{
    public class NotificationUserOnApp : GenericEntity
    {
        public long NotificationAppId { get; set; }
        public string UserId { get; set; }

        public NotificationApp NotificationApp { get; set; }

    }
}
