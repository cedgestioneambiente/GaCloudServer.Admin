using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami
{
    public class ReclamiAzione : GenericListAuditableEntity
    {
        public long ReclamiDocumentoId { get; set; }
        public long ReclamiTipoAzioneId { get; set; }
        public DateTime Data { get; set; }
        public string Note { get; set; }
        public bool Risposta { get; set; }
        public DateTime? RispostaDefinitiva { get; set; }

        public ReclamiDocumento ReclamiDocumento { get; set; }
        public ReclamiTipoAzione ReclamiTipoAzione { get; set; }
    }
}
