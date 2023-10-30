using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System.Collections.Generic;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrCentro : GenericAuditableEntity
    {
        public string Centro { get; set; }
        public string Mail { get; set; }
        public string UserMail { get; set; }

        public CdrCerOnCentro CdrCerOnCentro { get; set; }

        public ICollection<CdrComuneOnCentro> CdrComuniOnCentri { get; set; }
    }
}