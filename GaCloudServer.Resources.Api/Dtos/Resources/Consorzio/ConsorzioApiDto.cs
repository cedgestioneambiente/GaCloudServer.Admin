using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.BusinnessLogic.Api.Dtos.Resources.Consorzio
{
    #region ConsorzioCers
    public class ConsorzioCerApiDto : GenericListApiDto
    {
        public string Codice { get; set; }
        public bool Pericoloso { get; set; }
        public string? Immagine { get; set; }
        public string? CodiceRaggruppamento { get; set; }
        public bool Conteggio { get; set; }
    }

    public class ConsorzioCersApiDto : GenericPagedListApiDto<ConsorzioCerApiDto>
    {
    }

    #endregion

    #region ConsorzioSmaltimenti
    public class ConsorzioSmaltimentoApiDto : GenericListApiDto
    {
    }

    public class ConsorzioSmaltimentiApiDto : GenericPagedListApiDto<ConsorzioSmaltimentoApiDto>
    {
    }

    #endregion

    #region ConsorzioComuni
    public class ConsorzioComuneApiDto : GenericListApiDto
    {
        public string? Cap { get; set; }
        public string? Istat { get; set; }
        public string? Regione { get; set; }
        public string? Provincia { get; set; }
    }

    public class ConsorzioComuniApiDto : GenericPagedListApiDto<ConsorzioComuneApiDto>
    {
    }

    #endregion

    #region ConsorzioDestinatari
    public class ConsorzioDestinatarioApiDto : GenericListApiDto
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }
    }

    public class ConsorzioDestinatariApiDto : GenericPagedListApiDto<ConsorzioDestinatarioApiDto>
    {
    }

    #endregion

    #region ConsorzioProduttori
    public class ConsorzioProduttoreApiDto : GenericListApiDto
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }
    }

    public class ConsorzioProduttoriApiDto : GenericPagedListApiDto<ConsorzioProduttoreApiDto>
    {
    }

    #endregion

    #region ConsorzioTrasportatori
    public class ConsorzioTrasportatoreApiDto : GenericListApiDto
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }
    }

    public class ConsorzioTrasportatoriApiDto : GenericPagedListApiDto<ConsorzioTrasportatoreApiDto>
    {
    }

    #endregion

    #region ConsorzioRegistrazioni
    public class ConsorzioRegistrazioneApiDto : GenericApiDto
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

    public class ConsorzioRegistrazioniApiDto : GenericPagedListApiDto<ConsorzioRegistrazioneApiDto>
    {
    }

    #endregion

    #region ConsorzioRegistrazioniAllegati
    public class ConsorzioRegistrazioneAllegatoApiDto : GenericFileApiDto
    {
        public string? Descrizione { get; set; }
        public long ConsorzioRegistrazioneId { get; set; }
    }

    public class ConsorzioRegistrazioniAllegatiApiDto : GenericPagedListApiDto<ConsorzioRegistrazioneAllegatoApiDto>
    {
    }

    #endregion

    #region ConsorzioOperazioni
    public class ConsorzioOperazioneApiDto : GenericListApiDto
    {
        public long ConsorzioSmaltimentoId { get; set; }
    }

    public class ConsorzioOperazioniApiDto : GenericPagedListApiDto<ConsorzioOperazioneApiDto>
    {
    }

    #endregion

    #region ConsorzioPeriodi
    public class ConsorzioPeriodoApiDto : GenericListApiDto
    {
        public int Giorni { get; set; }
    }

    public class ConsorzioPeriodiApiDto : GenericPagedListApiDto<ConsorzioPeriodoApiDto>
    {
    }

    #endregion

    #region ConsorzioImportsTasks
    public class ConsorzioImportTaskApiDto : GenericFileApiDto
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

    public class ConsorzioImportsTasksApiDto : GenericPagedListApiDto<ConsorzioImportTaskApiDto>
    {
    }

    #endregion

    #region ConsorzioComuniDemografie
    public class ConsorzioComuneDemografiaApiDto : GenericApiDto
    {
        public long ConsorzioComuneId { get; set; }
        public int? Anno2022 { get; set; }
        public int? Anno2023 { get; set; }
        public int? Anno2024 { get; set; }
        public int? Anno2025 { get; set; }
        public int? Anno2026 { get; set; }
        public int? Anno2027 { get; set; }
    }

    public class ConsorzioComuniDemografieApiDto : GenericPagedListApiDto<ConsorzioComuneDemografiaApiDto>
    {
    }

    #endregion

    //Internal
    public class ConsorzioRegistrazioniFilterApiDto
    {
        public long id { get; set; }
        public string roles { get; set; }
        public string quickFilter { get; set; }
    }

    public class ConsorzioImportErrorApiDto
    { 
        public string row { get; set; }
        public string error { get; set; }
    }

    public class ConsorzioImportFileApiDto
    { 
        public int PRG { get; set; }
        public DateTime DATA { get; set; }
        public string CER { get; set; }
        public string? RAGGRUPPAMENTO_CER { get; set; }
        public double PESO_KG { get; set; }
        public string OPERAZIONE { get; set; }
        public string PRODUTTORE_RAGSO { get; set; }
        public string PRODUTTORE_INDIRIZZO { get; set; }
        public string PRODUTTORE_CFPIVA { get; set; }
        public string PRODUTTORE_ISTAT_COMUNE { get; set; }
        public string DESTINATARIO_RAGSO { get; set; }
        public string DESTINATARIO_INDIRIZZO { get; set; }
        public string DESTINATARIO_CFPIVA { get; set; }
        public string DESTINATARIO_ISTAT_COMUNE { get; set; }
        public string TRASPORTATORE_RAGSO { get; set; }
        public string TRASPORTATORE_INDIRIZZO { get; set; }
        public string TRASPORTATORE_CFPIVA { get; set; }
        public string TRASPORTATORE_ISTAT_COMUNE { get; set; }
        public long PERIODO { get; set; }
        public bool step1Error { get; set; }
        public bool step2Error { get; set; }
        public bool step3Error { get; set; }
        public string ErrorDesc { get; set; }
        public string OperationDesc { get; set; }
        public bool Imported { get; set; }
    }

}