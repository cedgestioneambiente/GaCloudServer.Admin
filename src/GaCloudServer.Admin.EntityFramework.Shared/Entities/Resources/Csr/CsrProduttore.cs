using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr
{
    public class CsrProduttore : GenericEntity
    {
        public string RagioneSociale { get; set; }
        public string Colore { get; set; }
    }
}
