using GaCloudServer.BusinnessLogic.DTOs.Base;
using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Preventivi
{
    #region PreventiviAnticipiTipologie
    public class PreventiviAnticipoTipologiaApiDto : GenericListApiDto
    {
    }

    public class PreventiviAnticipiTipologieApiDto : GenericPagedListApiDto<PreventiviAnticipoTipologiaApiDto>
    {
    }

    #endregion

    #region PreventiviAnticipiPagamenti
    public class PreventiviAnticipoPagamentoApiDto : GenericListApiDto
    {
    }

    public class PreventiviAnticipiPagamentiApiDto : GenericPagedListApiDto<PreventiviAnticipoPagamentoApiDto>
    {
    }

    #endregion

    #region PreventiviAnticipi
    public class PreventiviAnticipoApiDto : GenericApiDto
    {
        public string? RagioneSociale { get; set; }
        public string? Numero { get; set; }
        public DateTime? DataPreventivo { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? CfPiva { get; set; }
        public double? Incassato { get; set; }
        public double? ImportoTotale { get; set; }
        public double? Anticipo { get; set; }
        public string? NoteContabili { get; set; }
        public string? NoteOperative { get; set; }
        public string? Causale { get; set; }
        public bool Pagato { get; set; }
        public bool Fatturato { get; set; }
        public bool RegistratoContabilita { get; set; }
        public long PreventiviAnticipoTipologiaId { get; set; }
        public long? PreventiviAnticipoPagamentoId { get; set; }
    }

    public class PreventiviAnticipiApiDto : GenericPagedListApiDto<PreventiviAnticipoApiDto>
    {
    }

    #endregion

    #region PreventiviAnticipiAllegati
    public class PreventiviAnticipoAllegatoApiDto : GenericFileApiDto
    {
        public string? Descrizione { get; set; }
        public long PreventiviAnticipoId { get; set; }
    }

    public class PreventiviAnticipiAllegatiApiDto : GenericPagedListDto<PreventiviAnticipoAllegatoApiDto>
    {
    }

    #endregion
}
