using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneAuto;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPrenotazioneAutoService
    {
        #region GaPrenotazioneAutoSedi
        Task<PrenotazioneAutoSediDto> GetGaPrenotazioneAutoSediAsync(int page = 1, int pageSize = 0);
        Task<PrenotazioneAutoSedeDto> GetGaPrenotazioneAutoSedeByIdAsync(long id);
        Task<long> AddGaPrenotazioneAutoSedeAsync(PrenotazioneAutoSedeDto dto);
        Task<long> UpdateGaPrenotazioneAutoSedeAsync(PrenotazioneAutoSedeDto dto);
        Task<bool> DeleteGaPrenotazioneAutoSedeAsync(long id);
        #region Functions
        Task<bool> ValidateGaPrenotazioneAutoSedeAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPrenotazioneAutoSedeAsync(long id);

        #endregion
        #endregion

        #region GaPrenotazioneAutoVeicoli
        Task<PrenotazioneAutoVeicoliDto> GetGaPrenotazioneAutoVeicoliAsync(int page = 1, int pageSize = 0);
        Task<PrenotazioneAutoVeicoloDto> GetGaPrenotazioneAutoVeicoloByIdAsync(long id);
        Task<long> AddGaPrenotazioneAutoVeicoloAsync(PrenotazioneAutoVeicoloDto dto);
        Task<long> UpdateGaPrenotazioneAutoVeicoloAsync(PrenotazioneAutoVeicoloDto dto);
        Task<bool> DeleteGaPrenotazioneAutoVeicoloAsync(long id);
        #region Functions
        Task<bool> ValidateGaPrenotazioneAutoVeicoloAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPrenotazioneAutoVeicoloAsync(long id);

        #endregion

        #region Views
        Task<PagedList<ViewGaPrenotazioneAutoVeicoli>> GetViewGaPrenotazioneAutoVeicoliAsync(bool all = false);
        #endregion

        #endregion

        #region GaPrenotazioneAutoRegistrazione
        Task<PrenotazioneAutoRegistrazioneDto> GetGaPrenotazioneAutoRegistrazioneByIdAsync(long id);
        Task<long> AddGaPrenotazioneAutoRegistrazioneAsync(PrenotazioneAutoRegistrazioneDto dto);
        Task<long> UpdateGaPrenotazioneAutoRegistrazioneAsync(PrenotazioneAutoRegistrazioneDto dto);
        Task<bool> DeleteGaPrenotazioneAutoRegistrazioneAsync(long id);
        #region Functions
        Task<int> ValidateGaPrenotazioneAutoRegistrazioneAsync(PrenotazioneAutoRegistrazioneDto dto);
        Task<bool> ChangeStatusGaPrenotazioneAutoRegistrazioneAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPrenotazioneAutoRegistrazioni>> GetViewGaPrenotazioneAutoRegistrazioniAsync(bool all = false);
        Task<ViewGaPrenotazioneAutoRegistrazioni> GetViewGaPrenotazioneAutoRegistrazioniByIdAsync(long id);
        #endregion
        #endregion
    }
}