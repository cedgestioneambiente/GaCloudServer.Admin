using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti
{
    public class ProgettiWork: GenericListAuditableEntity
    {
        public string Title { get; set; }
        public string Resources { get; set; }
    }
}
