using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr
{
    public class CsrCodiceCer : GenericListAuditableEntity
    {
        public string Codice { get; set; }
        public string Modalita { get; set; }
    }
}
