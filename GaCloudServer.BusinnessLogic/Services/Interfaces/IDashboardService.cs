using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Dashboard;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<List<object>> GetFromQueryAsync(string query);

        #region DashboardTypes
        Task<DashboardTypesDto> GetDashboardTypesAsync(int page = 1, int pageSize = 0);
        Task<DashboardTypeDto> GetDashboardTypeByIdAsync(long id);

        Task<long> AddDashboardTypeAsync(DashboardTypeDto dto);
        Task<long> UpdateDashboardTypeAsync(DashboardTypeDto dto);

        Task<bool> DeleteDashboardTypeAsync(long id);

        #region Functions
        Task<bool> ValidateDashboardTypeAsync(long id, string descrizione);
        Task<bool> ChangeStatusDashboardTypeAsync(long id);
        #endregion

        #endregion

        #region DashboardSections
        Task<DashboardSectionsDto> GetDashboardSectionsAsync(int page = 1, int pageSize = 0);
        Task<DashboardSectionDto> GetDashboardSectionByIdAsync(long id);

        Task<long> AddDashboardSectionAsync(DashboardSectionDto dto);
        Task<long> UpdateDashboardSectionAsync(DashboardSectionDto dto);

        Task<bool> DeleteDashboardSectionAsync(long id);

        #region Functions
        Task<bool> ValidateDashboardSectionAsync(long id, string descrizione);
        Task<bool> ChangeStatusDashboardSectionAsync(long id);
        #endregion

        #endregion

        #region DashboardItems
        Task<DashboardItemsDto> GetDashboardItemsAsync(int page = 1, int pageSize = 0);
        Task<DashboardItemDto> GetDashboardItemByIdAsync(long id);

        Task<long> AddDashboardItemAsync(DashboardItemDto dto);
        Task<long> UpdateDashboardItemAsync(DashboardItemDto dto);

        Task<bool> DeleteDashboardItemAsync(long id);

        #region Functions
        Task<bool> ValidateDashboardItemAsync(long id, string descrizione);
        Task<bool> ChangeStatusDashboardItemAsync(long id);
        #endregion

        #endregion

        #region DashboardStores

        Task<bool> UpdateDashboardStoresAsync(List<ViewDashboardStores> stores);

        #region Views
        Task<PagedList<ViewDashboardStores>> GetViewDashboardStoresByUserIdAsync(string userId);
        #endregion

        #endregion

    }
}
