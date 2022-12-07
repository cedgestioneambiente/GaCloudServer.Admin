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
        public double HhFerie { get; set; }
        public double HhPermessiCcnl { get; set; }
    }
}
