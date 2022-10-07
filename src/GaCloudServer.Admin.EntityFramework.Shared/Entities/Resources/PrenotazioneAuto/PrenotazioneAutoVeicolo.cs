using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto
{
    public class PrenotazioneAutoVeicolo:GenericListEntity
    {
        public string Targa { get; set; }
        public string Colore { get; set; }
        public long PrenotazioneAutoSedeId { get; set; }
        public bool Weekend { get; set; }

        public PrenotazioneAutoSede PrenotazioneAutoSede { get; set; }

    }
}
