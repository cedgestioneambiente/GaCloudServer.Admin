using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti
{
    public class ProgettiJobUndertaking : GenericAuditableEntity
    {
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public long ProgettiJobId { get; set; }
        public string Resources { get; set; }
        public string? Info { get; set; }
        public long ProgettiJobUndertakingStateId { get; set; }

        public ProgettiJobUndertakingState ProgettiJobUndertakingState { get; set; }
    }
}
