using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views
{
    public class ViewNotificationEvents:GenericEntity
    {
        public DateTime DateEvent { get; set; }
        public string UserId { get; set; }
        public string AppDescription { get; set; }
        public string AppInfo { get; set; }
        public string AppIcon { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Read { get; set; }
    }
}
