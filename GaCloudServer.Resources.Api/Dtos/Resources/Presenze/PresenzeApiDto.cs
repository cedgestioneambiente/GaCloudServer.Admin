using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;
using GaCloudServer.Resources.Api.Dtos.Base;


namespace GaCloudServer.Resources.Api.Dtos.Resources.Presenze
{
    #region PresenzeStatiRichieste

    public class PresenzeStatoRichiestaApiDto : GenericListApiDto
    {
    }

    public class PresenzeStatiRichiesteApiDto : GenericPagedListApiDto<PresenzeStatoRichiestaApiDto>
    {
    }
    #endregion

    #region PresenzeRichieste

    public class PresenzeRichiestaApiDto : GenericApiDto
    {
        public long PresenzeDipendenteId { get; set; }
        public long PresenzeStatoRichiestaId { get; set; }
        public long PresenzeTipoOraId { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public double TotaleOre { get; set; }
    }

    public class PresenzeRichiesteApiDto : GenericPagedListApiDto<PresenzeRichiestaApiDto>
    {
    }
    #endregion

    #region PresenzeTipiOre

    public class PresenzeTipoOraApiDto : GenericListApiDto
    {
        public bool ApprovazioneAutomatica { get; set; }
        public int DecrementaTipo { get; set; }
    }

    public class PresenzeTipiOreApiDto : GenericPagedListApiDto<PresenzeTipoOraApiDto>
    {
    }
    #endregion

    #region PresenzeResponsabili

    public class PresenzeResponsabileApiDto : GenericApiDto
    {
        public long PersonaleDipendenteId { get; set; }
    }

    public class PresenzeResponsabiliApiDto : GenericPagedListApiDto<PresenzeResponsabileApiDto>
    {
    }
    #endregion

    #region PresenzeResponsabiliOnSettori

    public class PresenzeResponsabileOnSettoreApiDto : GenericApiDto
    {
        public long PresenzeResponsabileId { get; set; }
        public long GlobalSettoreId { get; set; }
    }

    public class PresenzeResponsabiliOnSettoriApiDto : GenericPagedListApiDto<PresenzeResponsabileOnSettoreApiDto>
    {
    }
    #endregion

    #region PresenzeProfili

    public class PresenzeProfiloApiDto : GenericListApiDto
    {
        public double HhFerie { get; set; }
        public double HhPermessiCcnl { get; set; }
    }

    public class PresenzeProfiliApiDto : GenericPagedListApiDto<PresenzeProfiloApiDto>
    {
    }
    #endregion

    #region PresenzeDateEscluse

    public class PresenzeDataEsclusaApiDto : GenericApiDto
    {
        public DateTime Data { get; set; }
    }

    public class PresenzeDateEscluseApiDto : GenericPagedListApiDto<PresenzeDataEsclusaApiDto>
    {
    }
    #endregion

    #region PresenzeBancheOreUtilizzi

    public class PresenzeBancaOraUtilizzoApiDto : GenericApiDto
    {
        public long PersonaleDipendenteId { get; set; }
        public long PresenzeRichiestaId { get; set; }
        public int Tipo { get; set; }
        public double Qta { get; set; }
    }

    public class PresenzeBancheOreUtilizziApiDto : GenericPagedListApiDto<PresenzeBancaOraUtilizzoApiDto>
    {
    }
    #endregion

    #region PresenzeDipendenti

    public class PresenzeDipendenteApiDto : GenericApiDto
    {
        public long PersonaleDipendenteId { get; set; }
        public string? Matricola { get; set; }
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

    public class PresenzeDipendentiApiDto : GenericPagedListApiDto<PresenzeDipendenteApiDto>
    {
    }
    #endregion

    #region PresenzeOrari

    public class PresenzeOrarioApiDto : GenericListApiDto
    {
    }

    public class PresenzeOrariApiDto : GenericPagedListApiDto<PresenzeOrarioApiDto>
    {
    }
    #endregion

    #region PresenzeOrariGiornate

    public class PresenzeOrarioGiornataApiDto : GenericApiDto
    {
        public long PresenzeOrarioId { get; set; }
        public int Giorno { get; set; }
        public DateTime OraInizio { get; set; }
        public DateTime OraFine { get; set; }
        public DateTime? PausaInizio { get; set; }
        public DateTime? PausaFine { get; set; }
    }

    public class PresenzeOrariGiornateApiDto : GenericPagedListApiDto<PresenzeOrarioGiornataApiDto>
    {
    }
    #endregion
}
