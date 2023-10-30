using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti
{
    public class ProgettiWorkSetting: GenericAuditableEntity
    {
        public long ProgettiWorkId { get; set; }
        public string UserId { get; set; }
        public bool AddJobNotification { get; set; }
        public bool UpdateJobNotification { get; set; }
        public bool DeleteJobNotification { get; set; }
        public bool WorkStatusMail { get; set; }

        public ProgettiWork ProgettiWork { get; set; }

    }
}
