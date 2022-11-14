using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;
using GaCloudServer.Resources.Api.Dtos.Base;


namespace GaCloudServer.Resources.Api.Dtos.Resources.Presenze
{
    //Amministrativi

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
        public long PersonaleDipendenteId { get; set; }
        public long PresenzeStatoRichiestaId { get; set; }
        public long PresenzeTipoOraId { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
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
        public int GgLavorativi { get; set; }
        public int GgFerie { get; set; }
        public int GgPermessiCcnl { get; set; }
        public int HhPermessiCcnl { get; set; }
    }

    public class PresenzeProfiliApiDto : GenericPagedListApiDto<PresenzeProfiloApiDto>
    {
    }
    #endregion

    //Operativi

    #region PresenzeOpDateEscluse

    public class PresenzeOpDataEsclusaApiDto : GenericApiDto
    {
        public DateTime Data { get; set; }
    }

    public class PresenzeOpDateEscluseApiDto : GenericPagedListApiDto<PresenzeOpDataEsclusaApiDto>
    {
    }
    #endregion

    #region PresenzeOpBancheOre

    public class PresenzeOpBancaOraApiDto : GenericApiDto
    {
        public long PersonaleDipendenteId { get; set; }
        public double GgFerie { get; set; }
        public double GgFerieCcnl { get; set; }
        public double HhPermessoCcnl { get; set; }
        public double HhRecupero { get; set; }
    }

    public class PresenzeOpBancheOreApiDto : GenericPagedListApiDto<PresenzeOpBancaOraApiDto>
    {
    }
    #endregion

    #region PresenzeOpBancheOreUtilizzi

    public class PresenzeOpBancaOraUtilizzoApiDto : GenericApiDto
    {
        public long PersonaleDipendenteId { get; set; }
        public long PresenzeRichiestaId { get; set; }
        public int Tipo { get; set; }
        public double Qta { get; set; }
    }

    public class PresenzeOpBancheOreUtilizziApiDto : GenericPagedListApiDto<PresenzeOpBancaOraUtilizzoApiDto>
    {
    }
    #endregion
}
