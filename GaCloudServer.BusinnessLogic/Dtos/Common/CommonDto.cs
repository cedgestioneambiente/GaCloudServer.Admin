using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Common
{
    public class CommonGaugeDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string DescrizioneBreve { get; set; }
    }

    public class CommonIvaCodeDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string DescrizioneBreve { get; set; }
        public double Valore { get; set; }
        public bool Split { get; set; }
    }

    public class CommonBankAccountDto : GenericAuditableEntity
    {
        public string Descrizione { get; set; }
        public string RagioneSociale { get; set; }
        public string Iban { get; set; }
        public bool IsPersonal { get; set; }
    }
}
