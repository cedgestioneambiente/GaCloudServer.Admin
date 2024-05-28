using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectInspectionAttachment:GenericFileAuditableEntity
    {
        [ForeignKey("ObjectInspection")]
        public long ObjectInspectionId { get; set; }
        public string Descrizione { get; set; }
       

        //Navigation Props
        public PreventiviObjectInspection ObjectInspection { get; set; }

    }

}
