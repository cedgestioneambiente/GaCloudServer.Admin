using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Previsio
{
    #region PrevisioOdsLetture
    public class PrevisioOdsLetturaApiDto : GenericListApiDto
    {
        public string IdServizio { get; set; }
        public string FileName { get; set; }
        public string ProcDescription { get; set; }
        public string ErrDescription { get; set; }
        public bool Elaborato { get; set; }
        public int Retry { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class PrevisioOdsLettureApiDto : GenericPagedListApiDto<PrevisioOdsLetturaApiDto>
    {
    }

    #endregion

    # region PrevisioAnomalieLetture
    public class PrevisioAnomaliaLetturaApiDto : GenericApiDto
    {
        public string? NoteSegnalazione { get; set; }
        public string? NoteGestione { get; set; }
        public bool Gestito { get; set; }
        public string? Evento { get; set; }
        public string? Matricola { get; set; }
        public string? Tag { get; set; }
        public string? TipoCont { get; set; }
        public string? Contratto { get; set; }
        public string? Partita { get; set; }
        public string? Utenza { get; set; }
        public string? Comune { get; set; }
        public string? Indirizzo { get; set; }
        public DateTime DataEvento { get; set; }
        public double? Longitudine { get; set; }
        public double? Latitudine { get; set; }
    }

    public class PrevisioAnomalieLettureApiDto : GenericPagedListApiDto<PrevisioAnomaliaLetturaApiDto>
    {
    }

    #endregion
}