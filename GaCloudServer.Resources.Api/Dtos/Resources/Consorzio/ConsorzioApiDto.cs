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
        public long ConsorzioCerSmaltimentoId { get; set; }
    }

    public class ConsorzioCersApiDto : GenericPagedListApiDto<ConsorzioCerApiDto>
    {
    }

    #endregion

    #region ConsorzioCersSmaltimenti
    public class ConsorzioCerSmaltimentoApiDto : GenericListApiDto
    {
    }

    public class ConsorzioCersSmaltimentiApiDto : GenericPagedListApiDto<ConsorzioCerSmaltimentoApiDto>
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
        public string CdPiva { get; set; }
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
        public string CdPiva { get; set; }
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
        public string CdPiva { get; set; }
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
        public string? Operazione { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public long ConsorzioCerId { get; set; }
        public long ConsorzioProduttoreId { get; set; }
        public long ConsorzioTrasportatoreId { get; set; }
        public long ConsorzioDestinatarioId { get; set; }
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


    //Internal
    public class ConsorzioRegistrazioniFilterApiDto
    {
        public long id { get; set; }
        public string roles { get; set; }
        public string quickFilter { get; set; }
    }
}