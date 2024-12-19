using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmTicketAzione : GenericFileAuditableEntity
    {
        public long CrmTicketId { get; set; }
        public string Descrizione { get; set; }
        public DateTime Data {  get; set; }
        public bool Risposta { get; set; }

        [ForeignKey("ReclamiTipoAzione")]
        public long CrmTicketTipoAzioneId { get; set; }

        public ReclamiTipoAzione ReclamiTipoAzione { get; set; }
    }
}
