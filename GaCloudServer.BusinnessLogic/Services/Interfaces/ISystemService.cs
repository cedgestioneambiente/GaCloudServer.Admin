using GaCloudServer.BusinnessLogic.Dtos.Resources.System;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface ISystemService
    {
        #region SystemVersions
        Task<SystemVersionsDto> GetSystemVersionsAsync(int page = 1, int pageSize = 0);
        Task<SystemVersionDto> GetSystemVersionByIdAsync(long id);

        Task<long> AddSystemVersionAsync(SystemVersionDto dto);
        Task<long> UpdateSystemVersionAsync(SystemVersionDto dto);

        Task<bool> DeleteSystemVersionAsync(long id);

        #region Functions
        Task<bool> ValidateSystemVersionAsync(long id, string descrizione);
        Task<bool> ChangeStatusSystemVersionAsync(long id);
        #endregion

        #endregion
    }
}
