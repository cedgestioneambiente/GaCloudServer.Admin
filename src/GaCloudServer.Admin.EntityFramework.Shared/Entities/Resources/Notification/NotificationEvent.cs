using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification
{
    public class NotificationEvent:GenericEntity
    {
        public DateTime DateEvent { get; set; }
        public string UserId { get; set; }
        public long NotificationAppId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Read { get; set; }

        public NotificationApp NotificationApp { get; set; }
    }
}
