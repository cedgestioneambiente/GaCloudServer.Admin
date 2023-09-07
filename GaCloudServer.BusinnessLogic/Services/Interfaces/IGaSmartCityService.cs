using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.SmartCity.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaSmartCityService
    {
        #region GaSmartCityPermissions

        #region Functions
        Task<bool> ChangeGaSmartCityPermissionsAsync(string userId,string permissions);
        #endregion

        #region Views
        Task<PagedList<ViewGaSmartCityPermissions>> GetViewGaSmartCityPermissionsAsync();
        Task<PagedList<ViewGaSmartCityPermissions>> GetViewGaSmartCityPermissionsByUserIdAsync(string userId);
        #endregion

        #endregion


    }
}
