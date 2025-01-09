using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviPaymentTerm:GenericAuditableEntity
    {
        public string Descrizione { get; set; }
        public string Code { get; set; }
    }

}
