using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.BusinnessLogic.DTOs.Base;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze
{
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
        public long PresenzeDipendenteId { get; set; }
        public long PresenzeStatoRichiestaId { get; set; }
        public long PresenzeTipoOraId { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public double TotaleOre { get; set; }
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
        public double HhFerie { get; set; }
        public double HhPermessiCcnl { get; set; }
    }

    public class PresenzeProfiliDto : GenericPagedListDto<PresenzeProfiloDto>
    {
    }
    #endregion

    #region PresenzeDateEscluse

    public class PresenzeDataEsclusaDto : GenericDto
    {
        public DateTime Data { get; set; }
    }

    public class PresenzeDateEscluseDto : GenericPagedListDto<PresenzeDataEsclusaDto>
    {
    }
    #endregion

    #region PresenzeBancheOreUtilizzi

    public class PresenzeBancaOraUtilizzoDto : GenericDto
    {
        public long PersonaleDipendenteId { get; set; }
        public long PresenzeRichiestaId { get; set; }
        public int Tipo { get; set; }
        public double Qta { get; set; }
    }

    public class PresenzeBancheOreUtilizziDto : GenericPagedListDto<PresenzeBancaOraUtilizzoDto>
    {
    }
    #endregion

    #region PresenzeDipendenti

    public class PresenzeDipendenteDto : GenericDto
    {
        public long PersonaleDipendenteId { get; set; }
        public string Matricola { get; set; }
        public long PresenzeOrarioId { get; set; }
        public long PresenzeProfiloId { get; set; }
        public double HhFerie { get; set; }
        public double HhPermessiCcnl { get; set; }
        public double HhRecupero { get; set; }
        public bool PrivilegiElevati { get; set; }
        public bool AutoApprova { get; set; }
        public bool SuperUser { get; set; }
        public bool BancaOre { get; set; }
    }

    public class PresenzeDipendentiDto : GenericPagedListDto<PresenzeDipendenteDto>
    {
    }
    #endregion

    #region PresenzeOrari

    public class PresenzeOrarioDto : GenericListDto
    {
    }

    public class PresenzeOrariDto : GenericPagedListDto<PresenzeOrarioDto>
    {
    }
    #endregion

    #region PresenzeOrariGiornate

    public class PresenzeOrarioGiornataDto : GenericDto
    {
        public long PresenzeOrarioId { get; set; }
        public int Giorno { get; set; }
        public DateTime OraInizio { get; set; }
        public DateTime OraFine { get; set; }
        public DateTime? PausaInizio { get; set; }
        public DateTime? PausaFine { get; set; }
    }

    public class PresenzeOrariGiornateDto : GenericPagedListDto<PresenzeOrarioGiornataDto>
    {
    }
    #endregion

    //Internal
    public class PresenzeProfiloUtenteDto 
    { 
        public string UserId { get; set; }
        public long PresenzeDipendenteId { get; set; }
        public long SettoreId { get; set; }
        public List<long>? ResponsabileSettori { get; set; }
        public bool SuperUser { get; set; }
        public bool PrivilegiElevati { get; set; }
        public bool AutoApprova { get; set; }
        public bool BancaOre { get; set; }

        public PresenzeProfiloUtenteDto() { }


    }

    public class PresenzeRichiestaValidateDto
    { 
        public PresenzeRichiestaDto richiesta { get; set; }
        public PresenzeProfiloUtenteDto profiloUtente { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}

