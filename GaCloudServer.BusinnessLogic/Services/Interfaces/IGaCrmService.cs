using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaCrmService
    {
        #region CrmMaster

        #region Views
        Task<PagedList<ViewGaCrmTickets>> GetViewGaCrmMasterAsync();
        #endregion

        #endregion

        #region CrmEventStates
        Task<CrmEventStatesDto> GetGaCrmEventStatesAsync(int page = 1, int pageSize = 0);
        Task<CrmEventStateDto> GetGaCrmEventStateByIdAsync(long id);

        Task<long> AddGaCrmEventStateAsync(CrmEventStateDto dto);
        Task<long> UpdateGaCrmEventStateAsync(CrmEventStateDto dto);

        Task<bool> DeleteGaCrmEventStateAsync(long id);

        #region Views
        #endregion

        #endregion

        #region CrmEventAreas
        Task<CrmEventAreasDto> GetGaCrmEventAreasAsync(int page = 1, int pageSize = 0);
        Task<CrmEventAreaDto> GetGaCrmEventAreaByIdAsync(long id);

        Task<long> AddGaCrmEventAreaAsync(CrmEventAreaDto dto);
        Task<long> UpdateGaCrmEventAreaAsync(CrmEventAreaDto dto);

        Task<bool> DeleteGaCrmEventAreaAsync(long id);

        #region Views
        #endregion

        #endregion

        #region CrmEvents
        Task<CrmEventsDto> GetGaCrmEventsAsync(int page = 1, int pageSize = 0);
        Task<CrmEventDto> GetGaCrmEventByIdAsync(long id);
        Task<CrmEventDto> GetGaCrmEventByTicketIdAsync(long id);

        Task<long> AddGaCrmEventAsync(CrmEventDto dto);
        Task<long> UpdateGaCrmEventAsync(CrmEventDto dto);

        Task<bool> DeleteGaCrmEventAsync(long id);

        #region Views
        #endregion

        #endregion

        #region CrmEventDevices
        Task<bool> ChangeStatusGaCrmEventDeviceAsync(long id);
        Task<bool> ChangeSelectionGaCrmEventDeviceAsync(long id);
        #endregion


    }
}
