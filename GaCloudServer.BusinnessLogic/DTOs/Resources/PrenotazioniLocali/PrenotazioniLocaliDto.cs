using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneLocali
{
    #region PrenotazioneLocaliSedi
    public class PrenotazioneLocaliSedeDto : GenericListDto
    {

    }

    public class PrenotazioneLocaliSediDto : GenericPagedListDto<PrenotazioneLocaliSedeDto>
    {
    }

    #endregion

    #region PrenotazioneLocaliUffici
    public class PrenotazioneLocaliUfficioDto : GenericListDto
    {
        public string Colore { get; set; }
        public long PrenotazioneLocaliSedeId { get; set; }

    }

    public class PrenotazioneLocaliUfficiDto : GenericPagedListDto<PrenotazioneLocaliUfficiDto>
    {
    }

    #endregion

    #region PrenotazioneLocaliRegistrazioni
    public class PrenotazioneLocaliRegistrazioneDto : GenericDto
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

    public class PrenotazioneLocaliRegistrazioniDto : GenericPagedListDto<PrenotazioneLocaliRegistrazioneDto>
    {
    }

    #endregion
}
