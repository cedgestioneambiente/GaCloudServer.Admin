using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrRichiestaViaggio : GenericAuditableEntity
    {
        public DateTime Data { get; set; }
        public string UserId { get; set; }
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }
        public long CdrStatoRichiestaId { get; set; }
        public DateTime? DataChiusura { get; set; }
        public double PesoPresunto { get; set; }
        public double PesoDestino { get; set; }
        public string Note { get; set; }
        public bool Inviata { get; set; }
        public string CdrRichiestaId { get; set; }

        public CdrCer CdrCer { get; set; }
        public CdrStatoRichiesta CdrStatoRichiesta { get; set; }
    }
}