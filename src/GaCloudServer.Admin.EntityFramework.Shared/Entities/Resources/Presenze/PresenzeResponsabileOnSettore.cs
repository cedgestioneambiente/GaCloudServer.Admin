using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeResponsabileOnSettore : GenericAuditableEntity
    {
        public long PresenzeResponsabileId { get; set; }
        public long GlobalSettoreId { get; set; }

        public PresenzeResponsabile PresenzeResponsabile { get; set; }
        public GlobalSettore GlobalSettore { get; set; }
    }
}
