using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr
{
    public class CsrRipartizionePercentuale : GenericAuditableEntity
    {
        public long CsrComuneId { get; set; }
        public long CsrProduttoreId { get; set; }
        public int Percentuale { get; set; }

        public CsrComune CsrComune { get; set; }
        public CsrProduttore CsrProduttore { get; set; }
    }
}
