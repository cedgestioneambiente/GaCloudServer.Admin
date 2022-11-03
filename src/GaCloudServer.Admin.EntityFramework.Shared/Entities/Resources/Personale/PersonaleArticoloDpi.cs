using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleArticoloDpi : GenericListEntity
    {
        public string Caratteristiche { get; set; }
        public bool OmettiStampa { get; set; }
    }
}
