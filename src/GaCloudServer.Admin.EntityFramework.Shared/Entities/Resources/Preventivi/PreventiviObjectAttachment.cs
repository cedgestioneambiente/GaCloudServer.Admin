using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectAttachment:GenericFileAuditableEntity
    {
        [ForeignKey("Object")]
        public long ObjectId { get; set; }
        public string Descrizione { get; set; }
       

        //Navigation Props
        public PreventiviObject Object { get; set; }

    }

}
