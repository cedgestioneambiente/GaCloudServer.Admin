using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectServiceTypeDetail:GenericAuditableEntity
    {
        [ForeignKey("ServiceType")]
        public long ServiceTypeId { get; set; }
        public string Descrizione { get; set; }
        [ForeignKey("Gauge")]
        public long GaugeId { get; set; }
        public string Notes { get; set; }

        //Navigation Props
        public Gauge Gauge { get; set; }
        public PreventiviObjectServiceType ServiceType { get; set; }
    }

}
