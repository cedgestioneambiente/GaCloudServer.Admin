using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami
{
    public class ReclamiDocumento : GenericAuditableEntity
    {
        public string ReclamiDocumentoId { get; set; }
        public long GlobalSedeId { get; set; }
        public long ReclamiTipoOrigineId { get; set; }
        public string OrigineDescrizione { get; set; }
        public DateTime OrigineData { get; set; }
        public long ReclamiMittenteId { get; set; }
        public string Oggetto { get; set; }
        public long ReclamiTempoRispostaId { get; set; }
        public DateTime RispostaEntroData { get; set; }
        public bool Fondato { get; set; }
        public string Infondato { get; set; }
        public long ReclamiStatoId { get; set; }
        public string Note { get; set; }
        public string AzioniCorrettive { get; set; }
        public DateTime? RispostaInviata { get; set; }
        public DateTime? RispostaDefinitiva { get; set; }

        public GlobalSede GlobalSede { get; set; }
        public ReclamiTipoOrigine ReclamiTipoOrigine { get; set; }
        public ReclamiMittente ReclamiMittente { get; set; }
        public ReclamiTempoRisposta ReclamiTempoRisposta { get; set; }
        public ReclamiStato ReclamiStato { get; set; }
    }
}
