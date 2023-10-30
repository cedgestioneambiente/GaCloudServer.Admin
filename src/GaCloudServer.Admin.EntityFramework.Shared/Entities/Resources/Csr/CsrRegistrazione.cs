using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr
{
    public class CsrRegistrazione : GenericAuditableEntity
    {
        public DateTime Data { get; set; }
        public long CsrComuneId { get; set; }
        public long CsrCodiceCerId { get; set; }
        public long CsrDestinatarioId { get; set; }
        public long CsrTrasportatoreId { get; set; }
        public int PesoTotale { get; set; }
        public string Operazione { get; set; }

        public CsrComune CsrComune { get; set; }
        public CsrCodiceCer CsrCodiceCer { get; set; }
        public CsrDestinatario CsrDestinatario { get; set; }
        public CsrTrasportatore CsrTrasportatore { get; set; }
    }
}
