using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views
{
    public class ViewGaCsrRegistrazioniPesi : GenericEntity
    {
        public long RegistrazioneId { get; set; }
        public long CsrProduttoreId { get; set; }
        public string Produttore { get; set; }
        public string Colore { get; set; }
        public int Percentuale { get; set; }
        public double Peso { get; set; }
    }
}
