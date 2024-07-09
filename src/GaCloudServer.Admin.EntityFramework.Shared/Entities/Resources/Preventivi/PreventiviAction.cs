using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviAction:GenericAuditableEntity
    {
        public string Descrizione { get; set; }
        public string UserId { get; set; }
        public DateTime Data { get; set; }
        public string Link { get; set; }
        [ForeignKey("Object")]
        public long ObjectId { get; set; }

        //Navigation Props
        public PreventiviObject Object { get; set; }

        public PreventiviAction(string descrizione) { 
            this.Descrizione = descrizione;
        }
    }

}
