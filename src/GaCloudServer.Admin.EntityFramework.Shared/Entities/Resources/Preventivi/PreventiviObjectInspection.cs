using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectInspection:GenericFileAuditableEntity
    {
        [ForeignKey("Object")]
        public long ObjectId { get; set; }
        public DateTime? DateInspection { get; set; }
        public DateTime? DateExecution { get; set; }
        public string AssigneeId { get; set; }
        [ForeignKey("Mode")]
        public long ModeId { get; set; }

        [ForeignKey("Status")]
        public long StatusId { get; set; }

        public string Note {  get; set; }
        public string NoteInspection { get; set; }
       

        //Navigation Props
        public PreventiviObject Object { get; set; }
        public PreventiviObjectStatus Status { get; set; }
        public PreventiviObjectInspectionMode Mode { get; set; }

    }

}
