using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneAuto
{
    public class PrenotazioneAutoRegistrazioneDto:GenericDto
    {
        public string Colore { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public bool InteraGiornata { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public long PrenotazioneAutoVeicoloId { get; set; }
        public string RealeUtilizzatore { get; set; }

    }

    public class PrenotazioneAutoRegistrazioniDto:GenericPagedListDto<PrenotazioneAutoRegistrazioneDto>
    {
    }

    public class PrenotazioneAutoSedeDto:GenericListDto
    {
    }

    public class PrenotazioneAutoSediDto:GenericPagedListDto<PrenotazioneAutoSedeDto>
    {
    }

    public class PrenotazioneAutoVeicoloDto:GenericListDto
    {
        public string Targa { get; set; }
        public string Colore { get; set; }
        public long PrenotazioneAutoSedeId { get; set; }
        public bool Weekend { get; set; }
        public bool Disabled { get; set; }
    }

    public class PrenotazioneAutoVeicoliDto:GenericPagedListDto<PrenotazioneAutoVeicoloDto>
    {
    }
}
