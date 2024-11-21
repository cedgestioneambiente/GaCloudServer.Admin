using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectHistory:GenericAuditableEntity
    {
        [ForeignKey("Object")]
        public long ObjectId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string AssigneeId { get; set; }

        [ForeignKey("Status")]
        public long StatusId { get; set; }
        public string Note {  get; set; }

        //Navigation Props
        public PreventiviObject Object { get; set; }
        public PreventiviObjectStatus Status { get; set; }


    }

}
