using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Reclami
{
    #region ReclamiMittenti
    public class ReclamiMittenteDto : GenericListDto
    {
    }

    public class ReclamiMittentiDto : GenericPagedListDto<ReclamiMittenteDto>
    {
    }

    #endregion

    #region ReclamiStati
    public class ReclamiStatoDto : GenericListDto
    {
    }

    public class ReclamiStatiDto : GenericPagedListDto<ReclamiStatoDto>
    {
    }

    #endregion

    #region ReclamiTempiRisposte
    public class ReclamiTempoRispostaDto : GenericListDto
    {
        public int Giorni { get; set; }
    }

    public class ReclamiTempiRisposteDto : GenericPagedListDto<ReclamiTempoRispostaDto>
    {
    }

    #endregion

    #region ReclamiTipiAzioni
    public class ReclamiTipoAzioneDto : GenericListDto
    {
        public string DescrizioneBreve { get; set; }
    }

    public class ReclamiTipiAzioniDto : GenericPagedListDto<ReclamiTipoAzioneDto>
    {
    }

    #endregion

    #region ReclamiTipiOrigini
    public class ReclamiTipoOrigineDto : GenericListDto
    {
        public string DescrizioneBreve { get; set; }
    }

    public class ReclamiTipiOriginiDto : GenericPagedListDto<ReclamiTipoOrigineDto>
    {
    }

    #endregion

    #region ReclamiAzioni
    public class ReclamiAzioneDto : GenericListDto
    {
        public long ReclamiDocumentoId { get; set; }
        public long ReclamiTipoAzioneId { get; set; }
        public DateTime Data { get; set; }
        public string Note { get; set; }
        public bool Risposta { get; set; }
        public DateTime? RispostaDefinitiva { get; set; }
    }

    public class ReclamiAzioniDto : GenericPagedListDto<ReclamiAzioneDto>
    {
    }

    #endregion

    #region ReclamiDocumenti
    public class ReclamiDocumentoDto : GenericDto
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

    public class ReclamiDocumentiDto : GenericPagedListDto<ReclamiDocumentoDto>
    {
    }

    #endregion
}