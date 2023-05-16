using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali
{
    public class PrenotazioneLocaliUfficio : GenericListEntity
    {
        public string Colore { get; set; }
        public long PrenotazioneLocaliSedeId { get; set; }

        public PrenotazioneLocaliSede PrenotazioneLocaliSede { get; set; }

    }
}