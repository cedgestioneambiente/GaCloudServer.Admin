using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioComune : GenericListAuditableEntity
    {
        public string Cap { get; set; }
        public string Istat { get; set; }
        public string Provincia { get; set; }
        public string Regione { get; set; }

    }
}
