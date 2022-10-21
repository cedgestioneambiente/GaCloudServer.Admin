using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views
{
    public class ViewNotificationUsersOnApps:GenericEntity
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public long AppId { get; set; }
        public string AppName { get; set; }
        public string AppInfo { get; set; }
        public bool Show { get; set; }
        public bool Enabled { get; set; }
    }
}
