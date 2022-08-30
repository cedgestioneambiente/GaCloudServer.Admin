using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrComuneOnCentro : GenericEntity
    {
        public long Id { get; set; }
        public long CdrCentroId { get; set; }
        public long CdrComuneId { get; set; }
        public bool Disabled { get; set; }

        public CdrCentro CdrCentro { get; set; }
        public CdrComune CdrComune { get; set; }
    }
}