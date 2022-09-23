using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattiFornitore : GenericEntity
    {
        public string RagioneSociale { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        public string SedeLegale { get; set; }
        public string RecapitoFatture { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }
}