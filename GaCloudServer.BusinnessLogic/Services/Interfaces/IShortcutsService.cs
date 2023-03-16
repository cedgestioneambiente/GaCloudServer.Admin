using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IShortcutsService
    {
        #region ShortcutLinks
        Task<ShortcutLinksDto> GetShortcutLinksAsync(int page = 1, int pageSize = 0);
        Task<ShortcutLinksDto> GetShortcutLinksByRolesAsync(string roles);
        Task<ShortcutLinkDto> GetShortcutLinkByIdAsync(long id);

        Task<long> AddShortcutLinkAsync(ShortcutLinkDto dto);
        Task<long> UpdateShortcutLinkAsync(ShortcutLinkDto dto);

        Task<bool> DeleteShortcutLinkAsync(long id);

        #region Functions
        Task<bool> ValidateShortcutLinkAsync(long id, string link);
        Task<bool> ChangeStatusShortcutLinkAsync(long id);
        #endregion

        #endregion

        #region ShortcutItems
        Task<ShortcutItemsDto> GetShortcutItemsAsync(int page = 1, int pageSize = 0);
        Task<ShortcutItemDto> GetShortcutItemByIdAsync(long id);

        Task<long> AddShortcutItemAsync(ShortcutItemDto dto);
        Task<long> UpdateShortcutItemAsync(ShortcutItemDto dto);

        Task<bool> DeleteShortcutItemAsync(long id);


        #region Views
        Task<PagedList<ViewShortcutItems>> GetViewShortcutByUserIdAsync(string userId);
        #endregion

        #endregion
    }
}
