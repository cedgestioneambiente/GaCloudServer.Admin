using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectCondition:GenericAuditableEntity
    {
        [ForeignKey("Object")]
        public long ObjectId { get; set; }
        public int Order { get; set; }
        public string Descrizione { get; set; }

        //Navigation props
        public PreventiviObject Object { get; set; }
    }

}
