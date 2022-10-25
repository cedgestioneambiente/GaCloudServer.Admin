using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Reclami
{
    #region ReclamiMittenti
    public class ReclamiMittenteApiDto : GenericListApiDto
    {
    }

    public class ReclamiMittentiApiDto : GenericPagedListApiDto<ReclamiMittenteApiDto>
    {
    }

    #endregion

    #region ReclamiStati
    public class ReclamiStatoApiDto : GenericListApiDto
    {
    }

    public class ReclamiStatiApiDto : GenericPagedListApiDto<ReclamiStatoApiDto>
    {
    }

    #endregion

    #region ReclamiTempiRisposte
    public class ReclamiTempoRispostaApiDto : GenericListApiDto
    {
        public int Giorni { get; set; }
    }

    public class ReclamiTempiRisposteApiDto : GenericPagedListApiDto<ReclamiTempoRispostaApiDto>
    {
    }

    #endregion

    #region ReclamiTipiAzioni
    public class ReclamiTipoAzioneApiDto : GenericListApiDto
    {
        public string DescrizioneBreve { get; set; }
    }

    public class ReclamiTipiAzioniApiDto : GenericPagedListApiDto<ReclamiTipoAzioneApiDto>
    {
    }

    #endregion

    #region ReclamiTipiOrigini
    public class ReclamiTipoOrigineApiDto : GenericListApiDto
    {
        public string DescrizioneBreve { get; set; }
    }

    public class ReclamiTipiOriginiApiDto : GenericPagedListApiDto<ReclamiTipoOrigineApiDto>
    {
    }

    #endregion

    #region ReclamiAzioni
    public class ReclamiAzioneApiDto : GenericListApiDto
    {
        public long ReclamiDocumentoId { get; set; }
        public long ReclamiTipoAzioneId { get; set; }
        public DateTime Data { get; set; }
        public string Note { get; set; }
        public bool Risposta { get; set; }
        public DateTime? RispostaDefinitiva { get; set; }
    }

    public class ReclamiAzioniApiDto : GenericPagedListApiDto<ReclamiAzioneApiDto>
    {
    }

    #endregion

    #region ReclamiDocumenti
    public class ReclamiDocumentoApiDto : GenericApiDto
    {
        public string ReclamiDocumentoId { get; set; }
        public long GlobalSedeId { get; set; }
        public long ReclamiTipoOrigineId { get; set; }
        public string OrigineDescrizione { get; set; }
        public DateTime OrigineData { get; set; }
        public long ReclamiMittenteId { get; set; }
        public string Oggetto { get; set; }
        public long ReclamiTempoRispostaId { get; set; }
        public DateTime RispostaEntroData { get; set; }
        public bool Fondato { get; set; }
        public string Infondato { get; set; }
        public long ReclamiStatoId { get; set; }
        public string Note { get; set; }
        public string AzioniCorrettive { get; set; }
        public DateTime? RispostaInviata { get; set; }
        public DateTime? RispostaDefinitiva { get; set; }
    }

    public class ReclamiDocumentiApiDto : GenericPagedListApiDto<ReclamiDocumentoApiDto>
    {
    }

    #endregion
}
