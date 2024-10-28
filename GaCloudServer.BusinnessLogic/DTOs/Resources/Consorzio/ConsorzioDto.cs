using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio
{
    #region ConsorzioCers
    public class ConsorzioCerDto : GenericListDto
    {
        public string Codice { get; set; }
        public bool Pericoloso { get; set; }
        public string? Immagine { get; set; }
        public string? CodiceRaggruppamento { get; set; }
        public bool Conteggio { get; set; }
    }

    public class ConsorzioCersDto : GenericPagedListDto<ConsorzioCerDto>
    {
    }

    #endregion

    #region ConsorzioSmaltimenti
    public class ConsorzioSmaltimentoDto : GenericListDto
    {
    }

    public class ConsorzioSmaltimentiDto : GenericPagedListDto<ConsorzioSmaltimentoDto>
    {
    }

    #endregion

    #region ConsorzioComuni
    public class ConsorzioComuneDto : GenericListDto
    {
        public string? Cap { get; set; }
        public string? Istat { get; set; }
        public string? Regione { get; set; }
        public string? Provincia { get; set; }
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
        public string CfPiva { get; set; }
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
        public string CfPiva { get; set; }
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
        public string CfPiva { get; set; }
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
        public double PesoTotale { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public long ConsorzioOperazioneId { get; set; }
        public long ConsorzioCerId { get; set; }
        public long ConsorzioProduttoreId { get; set; }
        public long ConsorzioTrasportatoreId { get; set; }
        public long ConsorzioDestinatarioId { get; set; }
        public long ConsorzioPeriodoId { get; set; }
        public string? Note { get; set; }
        public string? ConsorzioImportTaskId { get; set; }
        public string? ImportRecordId { get; set; }
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

    #region ConsorzioOperazioni
    public class ConsorzioOperazioneDto : GenericListDto
    {
        public long ConsorzioSmaltimentoId { get; set; }
    }

    public class ConsorzioOperazioniDto : GenericPagedListDto<ConsorzioOperazioneDto>
    {
    }

    #endregion

    #region ConsorzioPeriodi
    public class ConsorzioPeriodoDto : GenericListDto
    {
        public int Giorni { get; set; }
    }

    public class ConsorzioPeriodiDto : GenericPagedListDto<ConsorzioPeriodoDto>
    {
    }

    #endregion

    #region ConsorzioImportsTasks
    public class ConsorzioImportTaskDto : GenericFileDto
    {
        public string? TaskId { get; set; }
        public byte[] Log { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? Completed { get; set; }
        public int? Error { get; set; }
        public string? UserId { get; set; }
        public bool Deleted { get; set; }
    }

    public class ConsorzioImportsTasksDto : GenericPagedListDto<ConsorzioImportTaskDto>
    {
    }

    #endregion

    #region ConsorzioComuniDemografie
    public class ConsorzioComuneDemografiaDto : GenericDto
    {
        public long ConsorzioComuneId { get; set; }
        public int? Anno2022 { get; set; }
        public int? Anno2023 { get; set; }
        public int? Anno2024 { get; set; }
        public int? Anno2025 { get; set; }
        public int? Anno2026 { get; set; }
        public int? Anno2027 { get; set; }
    }

    public class ConsorzioComuniDemografieDto : GenericPagedListDto<ConsorzioComuneDemografiaDto>
    {
    }

    #endregion

}






























