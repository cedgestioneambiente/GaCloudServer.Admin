using GaCloudServer.BusinnessLogic.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze
{
    //Amministrativi

    #region PresenzeStatiRichieste

    public class PresenzeStatoRichiestaDto : GenericListDto
    {
    }

    public class PresenzeStatiRichiesteDto : GenericPagedListDto<PresenzeStatoRichiestaDto>
    {
    }
    #endregion

    #region PresenzeRichieste

    public class PresenzeRichiestaDto : GenericDto
    {
        public long PersonaleDipendenteId { get; set; }
        public long PresenzeStatoRichiestaId { get; set; }
        public long PresenzeTipoOraId { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
    }

    public class PresenzeRichiesteDto : GenericPagedListDto<PresenzeRichiestaDto>
    {
    }
    #endregion

    #region PresenzeTipiOre

    public class PresenzeTipoOraDto : GenericListDto
    {
        public bool ApprovazioneAutomatica { get; set; }
        public int DecrementaTipo { get; set; }
    }

    public class PresenzeTipiOreDto : GenericPagedListDto<PresenzeTipoOraDto>
    {
    }
    #endregion

    #region PresenzeResponsabili

    public class PresenzeResponsabileDto : GenericDto
    {
        public long PersonaleDipendenteId { get; set; }
    }

    public class PresenzeResponsabiliDto : GenericPagedListDto<PresenzeResponsabileDto>
    {
    }
    #endregion

    #region PresenzeResponsabiliOnSettori

    public class PresenzeResponsabileOnSettoreDto : GenericDto
    {
        public long PresenzeResponsabileId { get; set; }
        public long GlobalSettoreId { get; set; }
    }

    public class PresenzeResponsabiliOnSettoriDto : GenericPagedListDto<PresenzeResponsabileOnSettoreDto>
    {
    }
    #endregion

    #region PresenzeProfili

    public class PresenzeProfiloDto : GenericListDto
    {
        public int GgLavorativi { get; set; }
        public int GgFerie { get; set; }
        public int GgPermessiCcnl { get; set; }
        public int HhPermessiCcnl { get; set; }
    }

    public class PresenzeProfiliDto : GenericPagedListDto<PresenzeProfiloDto>
    {
    }
    #endregion

    //Operativi

    #region PresenzeOpDateEscluse

    public class PresenzeOpDataEsclusaDto : GenericDto
    {
        public DateTime Data { get; set; }
    }

    public class PresenzeOpDateEscluseDto : GenericPagedListDto<PresenzeOpDataEsclusaDto>
    {
    }
    #endregion

    #region PresenzeOpBancheOre

    public class PresenzeOpBancaOraDto : GenericDto
    {
        public long PersonaleDipendenteId { get; set; }
        public double GgFerie { get; set; }
        public double GgFerieCcnl { get; set; }
        public double HhPermessoCcnl { get; set; }
        public double HhRecupero { get; set; }
    }

    public class PresenzeOpBancheOreDto : GenericPagedListDto<PresenzeOpBancaOraDto>
    {
    }
    #endregion

    #region PresenzeOpBancheOreUtilizzi

    public class PresenzeOpBancaOraUtilizzoDto : GenericDto
    {
        public long PersonaleDipendenteId { get; set; }
        public long PresenzeRichiestaId { get; set; }
        public int Tipo { get; set; }
        public double Qta { get; set; }
    }

    public class PresenzeOpBancheOreUtilizziDto : GenericPagedListDto<PresenzeOpBancaOraUtilizzoDto>
    {
    }
    #endregion




    //Internal da rivedere
    public class PresenzeProfiloUtenteDto
    {
        public string userId { get; set; }
        public bool isAdmin { get; set; }
        public bool isResponsabile { get; set; }
        public bool isPresenze { get; set; }
        public bool privilegiElevati { get; set; }
        public bool approvazioneConsentita { get; set; }
        public PresenzeProfiloUtenteSettoriDto settori { get; set; }
    }

    public class PresenzeRichiestaUtenteDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }
    }

    public class PresenzeRichiesteUtentiDto
    {
        public PresenzeRichiesteUtentiDto()
        {
            Data = new List<PresenzeRichiestaUtenteDto>();
        }

        public List<PresenzeRichiestaUtenteDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    public class PresenzeProfiloUtenteSettoreDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool isResponsabile { get; set; }
        public bool Disabled { get; set; }
    }

    public class PresenzeProfiloUtenteSettoriDto
    {
        public PresenzeProfiloUtenteSettoriDto()
        {
            Data = new List<PresenzeProfiloUtenteSettoreDto>();
        }

        public List<PresenzeProfiloUtenteSettoreDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}

