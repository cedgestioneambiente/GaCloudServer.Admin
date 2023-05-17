using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views
{
    public class ViewGaCrmEventJobs : GenericEntity
    {
        public DateTime DateSchedule { get; set; }
        public long AreaId { get; set; }
        public string Area { get; set; }
        public int ToDoCount { get; set; }
        public int CompletedCount { get; set; }
        public int CancelledCount { get; set; }
        

    }
}
