using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrCentro : GenericEntity
    {
        public long Id { get; set; }
        public string Centro { get; set; }
        public string Mail { get; set; }
        public string UserMail { get; set; }
        public bool Disabled { get; set; }

        public CdrCerOnCentro CdrCerOnCentro { get; set; }

        public ICollection<CdrComuneOnCentro> CdrComuniOnCentri { get; set; }
    }
}