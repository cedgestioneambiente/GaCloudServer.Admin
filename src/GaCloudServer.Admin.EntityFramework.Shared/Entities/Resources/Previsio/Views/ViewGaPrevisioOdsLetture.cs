using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views
{
    public class ViewGaPrevisioOdsLetture:GenericEntity
    {
        public string IdServizio { get; set; }
        public string FileName { get; set; }
        public string Descrizione { get; set; }
       
    }
}
