using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneLocali;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPrenotazioneLocaliService
    {
        #region GaPrenotazioneLocaliSedi
        Task<PrenotazioneLocaliSediDto> GetGaPrenotazioneLocaliSediAsync(int page = 1, int pageSize = 0);
        Task<PrenotazioneLocaliSedeDto> GetGaPrenotazioneLocaliSedeByIdAsync(long id);
        Task<long> AddGaPrenotazioneLocaliSedeAsync(PrenotazioneLocaliSedeDto dto);
        Task<long> UpdateGaPrenotazioneLocaliSedeAsync(PrenotazioneLocaliSedeDto dto);
        Task<bool> DeleteGaPrenotazioneLocaliSedeAsync(long id);

        #region Functions
        Task<bool> ValidateGaPrenotazioneLocaliSedeAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPrenotazioneLocaliSedeAsync(long id);

        #endregion
        #endregion

        #region GaPrenotazioneLocaliUffici
        Task<PrenotazioneLocaliUfficiDto> GetGaPrenotazioneLocaliUfficiAsync(int page = 1, int pageSize = 0);
        Task<PrenotazioneLocaliUfficioDto> GetGaPrenotazioneLocaliUfficioByIdAsync(long id);
        Task<long> AddGaPrenotazioneLocaliUfficioAsync(PrenotazioneLocaliUfficioDto dto);
        Task<long> UpdateGaPrenotazioneLocaliUfficioAsync(PrenotazioneLocaliUfficioDto dto);
        Task<bool> DeleteGaPrenotazioneLocaliUfficioAsync(long id);

        #region Functions
        Task<bool> ValidateGaPrenotazioneLocaliUfficioAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPrenotazioneLocaliUfficioAsync(long id);

        #endregion

        #region Views
        Task<PagedList<ViewGaPrenotazioneLocaliUffici>> GetViewGaPrenotazioneLocaliUfficiAsync(bool all = false);
        #endregion

        #endregion

        #region GaPrenotazioneLocaliRegistrazione
        Task<PrenotazioneLocaliRegistrazioniDto> GetGaPrenotazioneLocaliRegistrazioniAsync(int page = 1, int pageSize = 0);
        Task<PrenotazioneLocaliRegistrazioneDto> GetGaPrenotazioneLocaliRegistrazioneByIdAsync(long id);
        Task<long> AddGaPrenotazioneLocaliRegistrazioneAsync(PrenotazioneLocaliRegistrazioneDto dto);
        Task<long> UpdateGaPrenotazioneLocaliRegistrazioneAsync(PrenotazioneLocaliRegistrazioneDto dto);
        Task<bool> DeleteGaPrenotazioneLocaliRegistrazioneAsync(long id);

        #region Functions
        Task<int> ValidateGaPrenotazioneLocaliRegistrazioneAsync(PrenotazioneLocaliRegistrazioneDto dto);
        Task<bool> ChangeStatusGaPrenotazioneLocaliRegistrazioneAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPrenotazioneLocaliRegistrazioni>> GetViewGaPrenotazioneLocaliRegistrazioniAsync(bool all = false);
        Task<ViewGaPrenotazioneLocaliRegistrazioni> GetViewGaPrenotazioneLocaliRegistrazioniByIdAsync(long id);
        #endregion
        #endregion
    }
}
