using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectService:GenericAuditableEntity
    {
        public int Order {  get; set; }
        [ForeignKey("Object")]
        public long ObjectId { get; set; }
        [ForeignKey("Section")]
        public long SectionId { get; set; }
        public string Descrizione { get; set; }

        [ForeignKey("ServiceType")]
        public long ServiceTypeId { get; set; }

        [ForeignKey("ServiceTypeDetail")]
        public long ServiceTypeDetailId { get; set; }
        [ForeignKey("IvaCode")]
        public long IvaCodeId { get; set; }
        public double Amount { get; set; }
        public bool ShowAmountOnPrint { get; set; }
        public double CostUnit { get; set; }
        public double CostTotal { get; set; }

        public string Notes { get; set; }
        public string NotesExtra { get; set; }
        public bool Analysis { get; set; }
        public string AnalysisDesc {  get; set; }
        public bool Accepted { get; set; }

        //Navigation Props
        public PreventiviObjectServiceType ServiceType { get; set; }
        public PreventiviObjectServiceTypeDetail ServiceTypeDetail { get; set; }
        public PreventiviObjectSection Section { get; set; }
        public PreventiviObject Object { get; set; }
        public IvaCode IvaCode { get; set; }
    }

}
