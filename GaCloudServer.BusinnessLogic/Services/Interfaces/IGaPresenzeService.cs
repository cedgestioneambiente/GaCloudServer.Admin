using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPresenzeService
    {
        #region GaPresenzeStatiRichieste
        Task<PresenzeStatiRichiesteDto> GetGaPresenzeStatiRichiesteAsync(int page = 1, int pageSize = 0);
        Task<PresenzeStatoRichiestaDto> GetGaPresenzeStatoRichiestaByIdAsync(long id);

        Task<long> AddGaPresenzeStatoRichiestaAsync(PresenzeStatoRichiestaDto dto);
        Task<long> UpdateGaPresenzeStatoRichiestaAsync(PresenzeStatoRichiestaDto dto);

        Task<bool> DeleteGaPresenzeStatoRichiestaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeStatoRichiestaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeStatoRichiestaAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeRichieste
        Task<PresenzeRichiesteDto> GetGaPresenzeRichiesteAsync(int page = 1, int pageSize = 0);
        Task<PresenzeRichiestaDto> GetGaPresenzeRichiestaByIdAsync(long id);

        Task<long> AddGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto);
        Task<long> UpdateGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto);

        Task<bool> DeleteGaPresenzeRichiestaAsync(long id);

        #region Functions
        Task<int> ValidateGaPresenzeRichiestaAsync(PresenzeRichiestaValidateDto dto);
        Task<bool> ChangeStatusGaPresenzeRichiestaAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPresenzeRichieste>> GetGaViewPresenzeRichiesteBySettoreIdAsync(long globalSettoreId);
        Task<ViewGaPresenzeRichiestaMail> GetViewGaPresenzeRichiestaMailByIdAsync(long id);
        Task<PagedList<ViewGaPresenzeRichiesteRisorse>> GetViewGaPresenzeRichiesteRisorseBySettoreIdAsync(long globalSettoreId);
        Task<PagedList<ViewGaPresenzeRichiesteEventi>> GetViewGaPresenzeRichiesteEventiBySettoreIdAsync(long globalSettoreId);
        #endregion

        #endregion

        #region GaPresenzeTipiOre
        Task<PresenzeTipiOreDto> GetGaPresenzeTipiOreAsync(int page = 1, int pageSize = 0);
        Task<PresenzeTipoOraDto> GetGaPresenzeTipoOraByIdAsync(long id);

        Task<long> AddGaPresenzeTipoOraAsync(PresenzeTipoOraDto dto);
        Task<long> UpdateGaPresenzeTipoOraAsync(PresenzeTipoOraDto dto);

        Task<bool> DeleteGaPresenzeTipoOraAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeTipoOraAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeTipoOraAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeResponsabili
        Task<PresenzeResponsabiliDto> GetGaPresenzeResponsabiliAsync(int page = 1, int pageSize = 0);
        Task<PresenzeResponsabileDto> GetGaPresenzeResponsabileByIdAsync(long id);

        Task<long> AddGaPresenzeResponsabileAsync(PresenzeResponsabileDto dto);
        Task<long> UpdateGaPresenzeResponsabileAsync(PresenzeResponsabileDto dto);

        Task<bool> DeleteGaPresenzeResponsabileAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeResponsabileAsync(long id, long personaleDipendenteId);   
        Task<bool> ChangeStatusGaPresenzeResponsabileAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPresenzeResponsabili>> GetViewGaPresenzeResponsabiliAsync(bool all = true);
        #endregion

        #endregion

        #region GaPresenzeResponsabiliOnSettori
        Task<bool> UpdateGaPresenzeResponsabileOnSettoreAsync(long responsabileId, long settoreId);

        #region Functions
        //Task<bool> ValidateGaPresenzeResponsabileOnSettoreAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaPresenzeResponsabileOnSettoreAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPresenzeResponsabiliOnSettori>> GetViewGaPresenzeResponsabiliOnSettoriByDipendenteAsync(long personaleDipendenteId);
        Task<PagedList<ViewGaPresenzeResponsabiliOnSettori>> GetViewGaPresenzeResponsabiliOnSettoreMailBySettoreId(long settoreId);
        #endregion

        #endregion

        #region GaPresenzeProfili
        Task<PresenzeProfiliDto> GetGaPresenzeProfiliAsync(int page = 1, int pageSize = 0);
        Task<PresenzeProfiloDto> GetGaPresenzeProfiloByIdAsync(long id);

        Task<long> AddGaPresenzeProfiloAsync(PresenzeProfiloDto dto);
        Task<long> UpdateGaPresenzeProfiloAsync(PresenzeProfiloDto dto);

        Task<bool> DeleteGaPresenzeProfiloAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeProfiloAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeProfiloAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeOrari
        Task<PresenzeOrariDto> GetGaPresenzeOrariAsync(int page = 1, int pageSize = 0);
        Task<PresenzeOrarioDto> GetGaPresenzeOrarioByIdAsync(long id);

        Task<long> AddGaPresenzeOrarioAsync(PresenzeOrarioDto dto);
        Task<long> UpdateGaPresenzeOrarioAsync(PresenzeOrarioDto dto);

        Task<bool> DeleteGaPresenzeOrarioAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeOrarioAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeOrarioAsync(long id);
        #endregion



        #endregion

        #region GaPresenzeDipendenti
        Task<PresenzeDipendentiDto> GetGaPresenzeDipendentiAsync(int page = 1, int pageSize = 0);
        Task<PresenzeDipendenteDto> GetGaPresenzeDipendenteByIdAsync(long id);

        Task<long> AddGaPresenzeDipendenteAsync(PresenzeDipendenteDto dto);
        Task<long> UpdateGaPresenzeDipendenteAsync(PresenzeDipendenteDto dto);

        Task<bool> DeleteGaPresenzeDipendenteAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeDipendenteAsync(long id, string matricola);
        Task<bool> ChangeStatusGaPresenzeDipendenteAsync(long id,long personaleDipendenteId,long profiloId,long orarioId);
        #endregion

        #region Views
        Task<PagedList<ViewGaPresenzeDipendenti>> GetViewGaPresenzeDipendentiBySettoreIdAsync(long globalSettoreId);

        #endregion

        #endregion

        #region GaPresenzeOrariGiornate
        Task<PresenzeOrariGiornateDto> GetGaPresenzeOrariGiornateAsync(int page = 1, int pageSize = 0);
        Task<PresenzeOrarioGiornataDto> GetGaPresenzeOrarioGiornataByIdAsync(long id);

        Task<long> AddGaPresenzeOrarioGiornataAsync(PresenzeOrarioGiornataDto dto);
        Task<long> UpdateGaPresenzeOrarioGiornataAsync(PresenzeOrarioGiornataDto dto);

        Task<bool> DeleteGaPresenzeOrarioGiornataAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeOrarioGiornataAsync(long id, long orarioId, int giorno);
        Task<bool> ChangeStatusGaPresenzeOrarioGiornataAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPresenzeOrariGiornate>> GetViewGaPresenzeOrariGiornateByOrarioIdAsync(long orarioId);
        #endregion

        #endregion

        #region GaPresenzeBancheOreUtilizzi
        Task<PresenzeBancheOreUtilizziDto> GetGaPresenzeBancheOreUtilizziAsync(int page = 1, int pageSize = 0);
        Task<PresenzeBancaOraUtilizzoDto> GetGaPresenzeBancaOraUtilizzoByIdAsync(long id);

        Task<long> AddGaPresenzeBancaOraUtilizzoAsync(PresenzeBancaOraUtilizzoDto dto);
        Task<long> UpdateGaPresenzeBancaOraUtilizzoAsync(PresenzeBancaOraUtilizzoDto dto);

        Task<bool> DeleteGaPresenzeBancaOraUtilizzoAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPresenzeBancaOraUtilizzoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeBancaOraUtilizzoAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeDateEscluse
        Task<PresenzeDateEscluseDto> GetGaPresenzeDateEscluseAsync(int page = 1, int pageSize = 0);
        Task<PresenzeDataEsclusaDto> GetGaPresenzeDataEsclusaByIdAsync(long id);

        Task<long> AddGaPresenzeDataEsclusaAsync(PresenzeDataEsclusaDto dto);
        Task<long> UpdateGaPresenzeDataEsclusaAsync(PresenzeDataEsclusaDto dto);

        Task<bool> DeleteGaPresenzeDataEsclusaAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPresenzeDataEsclusaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeDataEsclusaAsync(long id);
        #endregion

        #endregion

        #region Extras
        Task<PresenzeProfiloUtenteDto> GetGaPresenzeProfiloUtenteByUserIdAsync(string userId, bool isAdmin);
        Task<PagedList<GlobalSettore>> GetGaPresenzeGlobalSettoriByUserId(string userId, bool isAdmin);
        Task<double> CalcTimeGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto);

        #endregion
    }
}
