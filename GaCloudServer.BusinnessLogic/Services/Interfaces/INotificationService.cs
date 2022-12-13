using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Notifiation;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface INotificationService
    {
        #region NotificationApps
        Task<NotificationAppsDto> GetNotificationAppsAsync(int page = 1, int pageSize = 0);
        Task<NotificationAppDto> GetNotificationAppByIdAsync(long id);
        Task<NotificationAppDto> GetNotificationAppByDescrizioneAsync(string descrizione);
        Task<long> AddNotificationAppAsync(NotificationAppDto dto);
        Task<long> UpdateNotificationAppAsync(NotificationAppDto dto);
        Task<bool> DeleteNotificationAppAsync(long id);

        #region Functions
        Task<bool> ValidateNotificationAppAsync(long id, string descrizione);
        Task<bool> ChangeStatusNotificationAppAsync(long id);
        #endregion

        #endregion

        #region NotificationRolesOnApps
        Task<bool> UpdateNotificationRoleOnAppFromViewAsync(ViewNotificationRolesOnApps view);

        #region Functions

        #endregion

        #region Views
        Task<PagedList<ViewNotificationRolesOnApps>> GetViewViewNotificationRolesOnAppsAsync(bool all = true);
        Task<PagedList<ViewNotificationRolesOnApps>> GetViewViewNotificationRolesOnAppsByAppIdAsync(long appId);
        #endregion

        #endregion

        #region NotificationUserOnApps
        Task<bool> UpdateNotificationUserOnAppFromViewAsync(ViewNotificationUsersOnApps view);

        #region Views
        Task<PagedList<ViewNotificationUsersOnApps>> GetViewViewNotificationUsersOnAppsAsync(bool all = true);
        Task<PagedList<ViewNotificationUsersOnApps>> GetViewViewNotificationUsersOnAppsByUserIdAsync(string userId);
        Task<PagedList<ViewNotificationUsersOnApps>> GetViewViewNotificationUsersOnAppsByAppIdAsync(long appId);
        #endregion
        #endregion






    }
}