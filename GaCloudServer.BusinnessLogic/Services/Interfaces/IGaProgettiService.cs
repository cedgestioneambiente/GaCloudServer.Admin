using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti.Views;
using GaCloudServer.BusinnessLogic.Dtos.Custom;
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
        Task<ProgettiJobsDto> GetGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId);

        Task<long> AddGaProgettiJobAsync(ProgettiJobDto dto);
        Task<long> UpdateGaProgettiJobAsync(ProgettiJobDto dto);

        Task<bool> DeleteGaProgettiJobAsync(long id);

        #region Functions
        Task<long> ValidateGaProgettiJobAsync(ProgettiJobDto dto);
        Task<bool> ValidateDeleteGaProgettiJobAsync(long id);
        Task<bool> ChangeStatusGaProgettiJobAsync(long id);
        Task<bool> AddGaProgettiJobLinkAsync(long sourceId, long targetId);
        #endregion

        #region Views
        Task<PagedList<ViewGaProgettiJobs>> GetViewGaProgettiJobsByWorkIdAsync(long workId);
        Task<List<GanttItemDto>> GetViewGaProgettiJobsByWorkIdWithChildrenAsync(long workId);
        Task<List<GanttItemDto>> GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync(long workId,bool all=true);
        Task<PagedList<ViewGaProgettiJobs>> GetViewGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId);
        #endregion

        #endregion

        #region GaProgettiJobAllegati
        Task<ProgettiJobAllegatiDto> GetGaProgettiJobAllegatiByJobIdAsync(long jobId);
        Task<ProgettiJobAllegatoDto> GetGaProgettiJobAllegatoByIdAsync(long id);

        Task<long> AddGaProgettiJobAllegatoAsync(ProgettiJobAllegatoDto dto);
        Task<long> UpdateGaProgettiJobAllegatoAsync(ProgettiJobAllegatoDto dto);

        Task<bool> DeleteGaProgettiJobAllegatoAsync(long id);

        #region Functions
        //Task<bool> ValidateGaProgettiJobAllegatoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaProgettiJobAllegatoAsync(long id);
        #endregion

        #endregion

        #region GaProgettiJobTasks
        Task<ProgettiJobTasksDto> GetGaProgettiJobTasksByJobIdAsync(long jobId);
        Task<ProgettiJobTaskDto> GetGaProgettiJobTaskByIdAsync(long id);

        Task<long> AddGaProgettiJobTaskAsync(ProgettiJobTaskDto dto);
        Task<long> UpdateGaProgettiJobTaskAsync(ProgettiJobTaskDto dto);

        Task<bool> DeleteGaProgettiJobTaskAsync(long id);

        #region Functions
        //Task<bool> ValidateGaProgettiJobAllegatoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaProgettiJobAllegatoAsync(long id);
        #endregion

        #endregion

        #region GaProgettiWorkSettings
        Task<ProgettiWorkSettingDto> GetGaProgettiWorkSettingByWorkIdAndUserIdAsync(long workId, string userId);
        Task<ProgettiWorkSettingsDto> GetGaProgettiWorkSettingsByWorkIdAsync(long workId);
        Task<long> UpdateGaProgettiWorkSettingAsync(ProgettiWorkSettingDto dto);

        #endregion

        #region GaProgettiJobUndertakings
        Task<ProgettiJobsUndertakingsDto> GetGaProgettiJobsUndertakingsAsync(int page = 1, int pageSize = 0);
        Task<ProgettiJobUndertakingDto> GetGaProgettiJobUndertakingByIdAsync(long id);
        Task<ProgettiJobsUndertakingsDto> GetGaProgettiJobsUndertakingsByJobIdAsync(long jobId);

        Task<long> AddGaProgettiJobUndertakingAsync(ProgettiJobUndertakingDto dto);
        Task<long> UpdateGaProgettiJobUndertakingAsync(ProgettiJobUndertakingDto dto);

        Task<bool> DeleteGaProgettiJobUndertakingAsync(long id);

        #region Functions
        Task<bool> ValidateGaProgettiJobUndertakingAsync(long id, string descrizione, long jobId);
        Task<bool> ChangeStatusGaProgettiJobUndertakingAsync(long id);
        #endregion

        #endregion

        #region GaProgettiJobsUndertakingAllegati
        Task<ProgettiJobsUndertakingsAllegatiDto> GetGaProgettiJobsUndertakingsAllegatiByUndertakingIdAsync(long undertakingId);
        Task<ProgettiJobUndertakingAllegatoDto> GetGaProgettiJobUndertakingAllegatoByIdAsync(long id);

        Task<long> AddGaProgettiJobUndertakingAllegatoAsync(ProgettiJobUndertakingAllegatoDto dto);
        Task<long> UpdateGaProgettiJobUndertakingAllegatoAsync(ProgettiJobUndertakingAllegatoDto dto);

        Task<bool> DeleteGaProgettiJobUndertakingAllegatoAsync(long id);


        #endregion

        #region GaProgettiJobUndertakingsStates
        Task<ProgettiJobsUndertakingsStatesDto> GetGaProgettiJobsUndertakingsStatesAsync(int page = 1, int pageSize = 0);
        Task<ProgettiJobUndertakingStateDto> GetGaProgettiJobUndertakingStateByIdAsync(long id);

        Task<long> AddGaProgettiJobUndertakingStateAsync(ProgettiJobUndertakingStateDto dto);
        Task<long> UpdateGaProgettiJobUndertakingStateAsync(ProgettiJobUndertakingStateDto dto);

        Task<bool> DeleteGaProgettiJobUndertakingStateAsync(long id);

        #region Functions
        Task<bool> ValidateGaProgettiJobUndertakingStateAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaProgettiJobUndertakingStateAsync(long id);
        #endregion

        #endregion

    }
}
