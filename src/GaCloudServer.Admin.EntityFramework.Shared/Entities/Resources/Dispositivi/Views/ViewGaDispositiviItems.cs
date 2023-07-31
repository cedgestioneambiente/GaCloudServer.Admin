using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views
{
    public class ViewGaDispositiviItems : GenericListEntity
    {
        public string Tipologia { get; set; }
        public string Modello { get; set; }
        public string Marca { get; set; }
        public string Classe { get; set; }
        public string InfoDispositivo { get; set; }
    }
}
