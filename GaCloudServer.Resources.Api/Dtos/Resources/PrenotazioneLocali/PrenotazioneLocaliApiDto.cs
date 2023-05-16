using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.PrenotazioneLocali
{
    #region PrenotazioneLocaliSedi
    public class PrenotazioneLocaliSedeApiDto : GenericListApiDto
    {
        
    }

    public class PrenotazioneLocaliSediApiDto : GenericPagedListApiDto<PrenotazioneLocaliSedeApiDto>
    {
    }

    #endregion

    #region PrenotazioneLocaliUffici
    public class PrenotazioneLocaliUfficioApiDto : GenericListApiDto
    {
        public string Colore { get; set; }
        public long PrenotazioneLocaliSedeId { get; set; }
    }

    public class PrenotazioneLocaliUfficiApiDto : GenericPagedListApiDto<PrenotazioneLocaliUfficiApiDto>
    {
    }

    #endregion

    #region PrenotazioneLocaliRegistrazioni
    public class PrenotazioneLocaliRegistrazioneApiDto : GenericApiDto
    {
        public string Colore { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public bool InteraGiornata { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? Motivazione { get; set; }
        public long PrenotazioneLocaliUfficioId { get; set; }
    }

    public class PrenotazioneLocaliRegistrazioniApiDto : GenericPagedListApiDto<PrenotazioneLocaliRegistrazioneApiDto>
    {
    }

    #endregion
}
