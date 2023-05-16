using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali.Views
{
    public class ViewGaPrenotazioneLocaliUffici : GenericListEntity
    {
        public string Colore { get; set; }
        public string Sede { get; set; }
    }
}