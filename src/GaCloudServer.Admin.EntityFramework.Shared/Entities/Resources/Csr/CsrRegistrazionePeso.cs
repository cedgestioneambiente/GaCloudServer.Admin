using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr
{
    public class CsrRegistrazionePeso : GenericAuditableEntity
    {
        public long CsrProduttoreId { get; set; }
        public long CsrCodiceCerId { get; set; }
        public long CsrDestinatarioId { get; set; }
        public long CsrTrasportatoreId { get; set; }
        public long CsrComuneId { get; set; }
        public int Percentuale { get; set; }
        public double Peso { get; set; }
        public long CsrRegistrazioneId { get; set; }

        public CsrProduttore CsrProduttore { get; set; }
        public CsrCodiceCer CsrCodiceCer { get; set; }
        public CsrDestinatario CsrDestinatario { get; set; }
        public CsrTrasportatore CsrTrasportatore { get; set; }
        public CsrRegistrazione CsrRegistrazione { get; set; }

    }
}
