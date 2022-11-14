using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeProfilo : GenericListEntity
    {
        public int GgLavorativi { get; set; }
        public int GgFerie { get; set; }
        public int GgPermessiCcnl { get; set; }
        public int HhPermessiCcnl { get; set; }
    }
}
