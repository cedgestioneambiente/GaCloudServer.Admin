using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;

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
    }
}
