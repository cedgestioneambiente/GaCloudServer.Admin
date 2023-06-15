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
        public float PesoTotale { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public long ConsorzioOperazioneId { get; set; }
        public long ConsorzioCerId { get; set; }
        public long ConsorzioProduttoreId { get; set; }
        public long ConsorzioTrasportatoreId { get; set; }
        public long ConsorzioDestinatarioId { get; set; }
        public long ConsorzioPeriodoId { get; set; }
        public string? Note { get; set; }
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


    //Internal
    public class ConsorzioRegistrazioniFilterApiDto
    {
        public long id { get; set; }
        public string roles { get; set; }
        public string quickFilter { get; set; }
    }
}