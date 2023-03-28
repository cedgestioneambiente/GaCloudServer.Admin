using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaProgettiService
    {
        #region GaProgettiWorks
        Task<ProgettiWorksDto> GetGaProgettiWorksAsync(int page = 1, int pageSize = 0);
        Task<ProgettiWorkDto> GetGaProgettiWorkByIdAsync(long id);
        Task<ProgettiWorksDto> GetGaProgettiWorksByUserAsync(string userId);

        Task<long> AddGaProgettiWorkAsync(ProgettiWorkDto dto);
        Task<long> UpdateGaProgettiWorkAsync(ProgettiWorkDto dto);

        Task<bool> DeleteGaProgettiWorkAsync(long id);

        #region Functions
        Task<bool> ValidateGaProgettiWorkAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaProgettiWorkAsync(long id);
        #endregion

        #endregion

        #region GaProgettiJobs
        Task<ProgettiJobsDto> GetGaProgettiJobsAsync(int page = 1, int pageSize = 0);
        Task<ProgettiJobDto> GetGaProgettiJobByIdAsync(long id);
        Task<ProgettiJobsDto> GetGaProgettiJobsByWorkIdAsync(long workId);

        Task<long> AddGaProgettiJobAsync(ProgettiJobDto dto);
        Task<long> UpdateGaProgettiJobAsync(ProgettiJobDto dto);

        Task<bool> DeleteGaProgettiJobAsync(long id);

        #region Functions
        Task<bool> ValidateGaProgettiJobAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaProgettiJobAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaProgettiJobs>> GetViewGaProgettiJobsByWorkIdAsync(long workId);
        #endregion

        #endregion

    }
}
