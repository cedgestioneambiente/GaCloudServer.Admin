using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Quicklinks;
using GaCloudServer.Shared;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IShortcutsService
    {
        #region ShortcutLinks
        Task<PageResponse<ShortcutLinkDto>> GetShortcutLinksAsync(PageRequest request);
        Task<PageResponse<ShortcutLinkDto>> GetShortcutLinksByRolesAsync(string roles);
        Task<ShortcutLinkDto> GetShortcutLinkByIdAsync(long id);

        Task<long> CreateShortcutLinkAsync(ShortcutLinkDto model);
        Task<long> UpdateShortcutLinkAsync(long id, ShortcutLinkDto model);

        Task<bool> DeleteShortcutLinkAsync(long id);

        #region Functions
        Task<bool> ValidateShortcutLinkAsync(long id, string link);
        Task<bool> ChangeStatusShortcutLinkAsync(long id);
        #endregion

        #endregion

        #region ShortcutItems
        Task<PageResponse<ShortcutItemDto>> GetShortcutItemsAsync(PageRequest request);
        Task<ShortcutItemDto> GetShortcutItemByIdAsync(long id);

        Task<long> CreateShortcutItemAsync(ShortcutItemDto model);
        Task<long> UpdateShortcutItemAsync(long id, ShortcutItemDto model);

        Task<bool> DeleteShortcutItemAsync(long id);


        #region Views
        Task<PageResponse<ViewShortcutItems>> GetViewShortcutByUserIdAsync(string userId);
        #endregion

        #endregion

        #region QuickLinks
        Task<PageResponse<QuickLinkDto>> GetQuickLinksAsync(PageRequest request);
        Task<QuickLinkDto> GetQuickLinkByIdAsync(long id);
        Task<long> CreateQuickLinkAsync(QuickLinkDto model);
        Task<long> UpdateQuickLinkAsync(long id, QuickLinkDto model);
        Task<bool> DeleteQuickLinkAsync(long id);
        #endregion
    }
}
