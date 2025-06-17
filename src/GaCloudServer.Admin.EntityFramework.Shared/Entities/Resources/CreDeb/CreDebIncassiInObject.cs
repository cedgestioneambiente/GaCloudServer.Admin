using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.CreDeb
{
    public class CreDebIncassiInObject: GenericFileAuditableEntity
    {
        public DateTime DtReg { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
        public int NumPag { get; set; }
        public double TotPag { get; set; }
        public bool Contab { get; set; }

    }

}
