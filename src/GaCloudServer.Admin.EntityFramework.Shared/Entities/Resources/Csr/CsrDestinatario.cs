using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr
{
    public class CsrDestinatario : GenericEntity
    {
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
    }
}
