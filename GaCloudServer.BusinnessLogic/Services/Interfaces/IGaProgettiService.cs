using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaProgettiService
    {
        #region GaProgettiWorks
        Task<ProgettiWorksDto> GetGaProgettiWorksAsync(int page = 1, int pageSize = 0);
        Task<ProgettiWorkDto> GetGaProgettiWorkByIdAsync(long id);

        Task<long> AddGaProgettiWorkAsync(ProgettiWorkDto dto);
        Task<long> UpdateGaProgettiWorkAsync(ProgettiWorkDto dto);

        Task<bool> DeleteGaProgettiWorkAsync(long id);

        #region Functions
        Task<bool> ValidateGaProgettiWorkAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaProgettiWorkAsync(long id);
        #endregion

        #endregion
        
    }
}
