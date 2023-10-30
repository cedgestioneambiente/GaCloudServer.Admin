using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrCerOnCentro: GenericAuditableEntity
    {
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }

        public CdrCentro CdrCentro { get; set; }
        public CdrCer CdrCer { get; set; }

    }
}
