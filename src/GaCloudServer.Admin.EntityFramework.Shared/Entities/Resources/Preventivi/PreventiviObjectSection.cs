using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectSection:GenericAuditableEntity
    {
        public int Order {  get; set; }
        [ForeignKey("Object")]
        public long ObjectId { get; set; }
        public string Descrizione { get; set; }

        [ForeignKey("Producer")]
        public long ProducerId { get; set; }
        [ForeignKey("Destination")]
        public long DestinationId { get; set; }
        public bool DestinationOnPrint { get; set; }
        public bool TotalOnPrint { get; set; }
        public bool OmitLabelTypeOnPrint { get; set; }
        public string Garbages { get; set; }

        public bool Accepted { get; set; }
        public string Note { get; set; }

        //Navigation Props
        public PreventiviProducer Producer { get; set; }
        public PreventiviObject Object { get; set; }
        public PreventiviDestination Destination { get; set; }
    }

}
