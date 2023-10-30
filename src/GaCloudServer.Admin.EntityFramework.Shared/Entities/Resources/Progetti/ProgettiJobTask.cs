using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti
{
    public class ProgettiJobTask: GenericAuditableEntity
    {
        public string Content { get; set; }
        public bool? Completed { get; set; }
        public long ProgettiJobId { get; set; }

        public ProgettiJob ProgettiJob { get; set; }

    }
}
