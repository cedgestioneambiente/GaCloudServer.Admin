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
        public string Descrizione { get; set; }
        public int TotalCount { get; set; }
        

    }
}
