using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.PrenotazioneAuto
{
    public class PrenotazioneAutoRegistrazioneApiDto : GenericApiDto
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

    public class PrenotazioneAutoRegistrazioniApiDto : GenericPagedListApiDto<PrenotazioneAutoRegistrazioneApiDto>
    {
    }

    public class PrenotazioneAutoSedeApiDto : GenericListApiDto
    {
    }

    public class PrenotazioneAutoSediApiDto : GenericPagedListApiDto<PrenotazioneAutoSedeApiDto>
    {
    }

    public class PrenotazioneAutoVeicoloApiDto : GenericApiDto
    {
        public string? Descrizione { get; set; }
        public string Targa { get; set; }
        public string Colore { get; set; }
        public long PrenotazioneAutoSedeId { get; set; }
        public bool Weekend { get; set; }
    }

    public class PrenotazioneAutoVeicoliApiDto : GenericPagedListApiDto<PrenotazioneAutoVeicoloApiDto>
    {
    }
}
