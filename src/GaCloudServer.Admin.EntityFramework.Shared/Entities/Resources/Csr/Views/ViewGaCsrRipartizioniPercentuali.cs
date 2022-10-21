using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views
{
    public class ViewGaCsrRipartizioniPercentuali : GenericEntity
    {
        public long ComuneId { get; set; }
        public long ProduttoreId { get; set; }
        public string Produttore { get; set; }
        public int Percentuale { get; set; }
    }
}
