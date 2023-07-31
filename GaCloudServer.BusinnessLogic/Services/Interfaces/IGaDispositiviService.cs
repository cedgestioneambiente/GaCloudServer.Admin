using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Dispositivi;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaDispositiviService
    {
        #region GaDispositiviTipologie
        Task<DispositiviTipologieDto> GetGaDispositiviTipologieAsync(int page = 1, int pageSize = 0);
        Task<DispositiviTipologiaDto> GetGaDispositiviTipologiaByIdAsync(long id);

        Task<long> AddGaDispositiviTipologiaAsync(DispositiviTipologiaDto dto);
        Task<long> UpdateGaDispositiviTipologiaAsync(DispositiviTipologiaDto dto);

        Task<bool> DeleteGaDispositiviTipologiaAsync(long id);

        #region Functions
        Task<bool> ValidateGaDispositiviTipologiaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaDispositiviTipologiaAsync(long id);
        #endregion

        #endregion

        #region GaDispositiviModelli
        Task<DispositiviModelliDto> GetGaDispositiviModelliAsync(int page = 1, int pageSize = 0);
        Task<DispositiviModelloDto> GetGaDispositiviModelloByIdAsync(long id);

        Task<long> AddGaDispositiviModelloAsync(DispositiviModelloDto dto);
        Task<long> UpdateGaDispositiviModelloAsync(DispositiviModelloDto dto);

        Task<bool> DeleteGaDispositiviModelloAsync(long id);

        #region Functions
        Task<bool> ValidateGaDispositiviModelloAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaDispositiviModelloAsync(long id);
        #endregion

        #endregion

        #region GaDispositiviMarche
        Task<DispositiviMarcheDto> GetGaDispositiviMarcheAsync(int page = 1, int pageSize = 0);
        Task<DispositiviMarcaDto> GetGaDispositiviMarcaByIdAsync(long id);

        Task<long> AddGaDispositiviMarcaAsync(DispositiviMarcaDto dto);
        Task<long> UpdateGaDispositiviMarcaAsync(DispositiviMarcaDto dto);

        Task<bool> DeleteGaDispositiviMarcaAsync(long id);

        #region Functions
        Task<bool> ValidateGaDispositiviMarcaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaDispositiviMarcaAsync(long id);
        #endregion

        #endregion

        #region GaDispositiviClassi
        Task<DispositiviClassiDto> GetGaDispositiviClassiAsync(int page = 1, int pageSize = 0);
        Task<DispositiviClasseDto> GetGaDispositiviClasseByIdAsync(long id);

        Task<long> AddGaDispositiviClasseAsync(DispositiviClasseDto dto);
        Task<long> UpdateGaDispositiviClasseAsync(DispositiviClasseDto dto);

        Task<bool> DeleteGaDispositiviClasseAsync(long id);

        #region Functions
        Task<bool> ValidateGaDispositiviClasseAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaDispositiviClasseAsync(long id);
        #endregion

        #endregion

        #region GaDispositiviCategorie
        Task<DispositiviCategorieDto> GetGaDispositiviCategorieAsync(int page = 1, int pageSize = 0);
        Task<DispositiviCategoriaDto> GetGaDispositiviCategoriaByIdAsync(long id);

        Task<long> AddGaDispositiviCategoriaAsync(DispositiviCategoriaDto dto);
        Task<long> UpdateGaDispositiviCategoriaAsync(DispositiviCategoriaDto dto);

        Task<bool> DeleteGaDispositiviCategoriaAsync(long id);

        #region Functions
        Task<bool> ValidateGaDispositiviCategoriaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaDispositiviCategoriaAsync(long id);
        #endregion

        #endregion

        #region GaDispositiviItems
        Task<DispositiviItemsDto> GetGaDispositiviItemsAsync(int page = 1, int pageSize = 0);
        Task<DispositiviItemDto> GetGaDispositiviItemByIdAsync(long id);

        Task<long> AddGaDispositiviItemAsync(DispositiviItemDto dto);
        Task<long> UpdateGaDispositiviItemAsync(DispositiviItemDto dto);

        Task<bool> DeleteGaDispositiviItemAsync(long id);

        #region Functions
        Task<bool> ValidateGaDispositiviItemAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaDispositiviItemAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaDispositiviItems>> GetViewGaDispositiviItemsAsync(int page = 1, int pageSize = 0);
        #endregion

        #endregion

        #region GaDispositiviStocks
        Task<DispositiviStocksDto> GetGaDispositiviStocksAsync(int page = 1, int pageSize = 0);
        Task<DispositiviStockDto> GetGaDispositiviStockByIdAsync(long id);

        Task<long> AddGaDispositiviStockAsync(DispositiviStockDto dto);
        Task<long> UpdateGaDispositiviStockAsync(DispositiviStockDto dto);

        Task<bool> DeleteGaDispositiviStockAsync(long id);

        #region Functions
        Task<bool> ChangeStatusGaDispositiviStockAsync(long id);
        Task<bool> SetGaDispositiviStockDisponibileAsync(long id);
        Task<bool> SetGaDispositiviStockNonDisponibileAsync(long id);
        Task<bool> DuplicateGaDispositiviStockAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaDispositiviStocks>> GetViewGaDispositiviStocksAsync(bool all = true);
        Task<PagedList<ViewGaDispositiviStocks>> GetViewGaDispositiviStocksListAsync();
        #endregion

        #endregion

        #region GaDispositiviOnDipendenti
        Task<DispositiviOnDipendentiDto> GetGaDispositiviOnDipendentiAsync(int page = 1, int pageSize = 0);
        Task<DispositiviOnDipendenteDto> GetGaDispositiviOnDipendenteByIdAsync(long id);

        Task<long> AddGaDispositiviOnDipendenteAsync(DispositiviOnDipendenteDto dto);
        Task<long> UpdateGaDispositiviOnDipendenteAsync(DispositiviOnDipendenteDto dto);

        Task<bool> DeleteGaDispositiviOnDipendenteAsync(long id);

        #region Functions
        Task<bool> ChangeStatusGaDispositiviOnDipendenteAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaDispositiviOnDipendenti>> GetViewGaDispositiviOnDipendentiAsync(int page = 1, int pageSize = 0);
        Task<PagedList<ViewGaDispositiviOnDipendenti>> GetViewGaDispositiviOnDipendentiByDipendenteIdAsync(long personaleDipendenteId);
        #endregion

        #endregion

        #region GaDispositiviOnModuli

        #region Views
        Task<PagedList<ViewGaDispositiviOnModuli>> GetViewGaDispositiviOnModuloByIdAsync(long id);
        #endregion

        #endregion

        #region GaDispositiviModuli
        Task<DispositiviModuliDto> GetGaDispositiviModuliByDipendenteIdAsync(long dipendenteId);
        Task<DispositiviModuloDto> GetGaDispositiviModuloByIdAsync(long id);

        Task<long> AddGaDispositiviModuloAsync(DispositiviModuloDto dto);
        Task<long> UpdateGaDispositiviModuloAsync(DispositiviModuloDto dto);

        Task<bool> DeleteGaDispositiviModuloAsync(long id);


        #endregion

    }
}