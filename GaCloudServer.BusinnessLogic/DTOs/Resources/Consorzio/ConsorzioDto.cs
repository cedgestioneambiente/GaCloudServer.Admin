using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio
{
    #region ConsorzioCers
    public class ConsorzioCerDto : GenericListDto
    {
        public string Codice { get; set; }
        public bool Pericoloso { get; set; }
        public string? Immagine { get; set; }
        public long ConsorzioCerSmaltimentoId { get; set; }
    }

    public class ConsorzioCersDto : GenericPagedListDto<ConsorzioCerDto>
    {
    }

    #endregion

    #region ConsorzioCersSmaltimenti
    public class ConsorzioCerSmaltimentoDto : GenericListDto
    {
    }

    public class ConsorzioCersSmaltimentiDto : GenericPagedListDto<ConsorzioCerSmaltimentoDto>
    {
    }

    #endregion

    #region ConsorzioCersComuni
    public class ConsorzioComuneDto : GenericListDto
    {
        public string? Cap { get; set; }
    }

    public class ConsorzioComuniDto : GenericPagedListDto<ConsorzioComuneDto>
    {
    }

    #endregion

    #region ConsorzioDestinatari
    public class ConsorzioDestinatarioDto : GenericListDto
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CdPiva { get; set; }
    }

    public class ConsorzioDestinatariDto : GenericPagedListDto<ConsorzioDestinatarioDto>
    {
    }

    #endregion

    #region ConsorzioProduttori
    public class ConsorzioProduttoreDto : GenericListDto
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CdPiva { get; set; }
    }

    public class ConsorzioProduttoriDto : GenericPagedListDto<ConsorzioProduttoreDto>
    {
    }

    #endregion

    #region ConsorzioTrasportatori
    public class ConsorzioTrasportatoreDto : GenericListDto
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CdPiva { get; set; }
    }

    public class ConsorzioTrasportatoriDto : GenericPagedListDto<ConsorzioTrasportatoreDto>
    {
    }

    #endregion

    #region ConsorzioRegistrazioni
    public class ConsorzioRegistrazioneDto : GenericDto
    {
        public string? UserId { get; set; }
        public string? Roles { get; set; }
        public float PesoTotale { get; set; }
        public string? Operazione { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public long ConsorzioCerId { get; set; }
        public long ConsorzioProduttoreId { get; set; }
        public long ConsorzioTrasportatoreId { get; set; }
        public long ConsorzioDestinatarioId { get; set; }
    }

    public class ConsorzioRegistrazioniDto : GenericPagedListDto<ConsorzioRegistrazioneDto>
    {
    }

    #endregion

    #region ConsorzioRegistrazioniAllegati
    public class ConsorzioRegistrazioneAllegatoDto : GenericFileDto
    {
        public string? Descrizione { get; set; }
        public long ConsorzioRegistrazioneId { get; set; }
    }

    public class ConsorzioRegistrazioniAllegatiDto : GenericPagedListDto<ConsorzioRegistrazioneAllegatoDto>
    {
    }

    #endregion
}
