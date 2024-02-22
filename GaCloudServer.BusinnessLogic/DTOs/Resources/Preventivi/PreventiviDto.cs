using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi
{
    #region PreventiviAnticipiTipologie
    public class PreventiviAnticipoTipologiaDto : GenericListDto
    {
    }

    public class PreventiviAnticipiTipologieDto : GenericPagedListDto<PreventiviAnticipoTipologiaDto>
    {
    }

    #endregion

    #region PreventiviAnticipiPagamenti
    public class PreventiviAnticipoPagamentoDto : GenericListDto
    {
    }

    public class PreventiviAnticipiPagamentiDto : GenericPagedListDto<PreventiviAnticipoPagamentoDto>
    {
    }

    #endregion

    #region PreventiviAnticipi
    public class PreventiviAnticipoDto : GenericDto
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

    public class PreventiviAnticipiDto : GenericPagedListDto<PreventiviAnticipoDto>
    {
    }

    #endregion

    #region PreventiviAnticipiAllegati
    public class PreventiviAnticipoAllegatoDto : GenericFileDto
    {
        public string? Descrizione { get; set; }
        public long PreventiviAnticipoId { get; set; }
    }

    public class PreventiviAnticipiAllegatiDto : GenericPagedListDto<PreventiviAnticipoAllegatoDto>
    {
    }

    #endregion
}