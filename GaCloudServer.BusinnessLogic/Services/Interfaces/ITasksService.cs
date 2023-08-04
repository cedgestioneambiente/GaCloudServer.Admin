

using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Tasks;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface ITasksService
    {
        #region TasksTags
        Task<TasksTagsDto> GetTasksTagsAsync(int page = 1, int pageSize = 0);
        Task<TasksTagDto> GetTasksTagByIdAsync(long id);

        Task<long> AddTasksTagAsync(TasksTagDto dto);
        Task<long> UpdateTasksTagAsync(TasksTagDto dto);

        Task<bool> DeleteTasksTagAsync(long id);

        #region Functions
        Task<bool> ValidateTasksTagAsync(long id, string descrizione);
        Task<bool> ChangeStatusTasksTagAsync(long id);
        #endregion

        #endregion

        #region TasksItems
        Task<TasksItemsDto> GetTasksItemsAsync(int page = 1, int pageSize = 0);
        Task<TasksItemDto> GetTasksItemByIdAsync(long id);

        Task<long> AddTasksItemAsync(TasksItemDto dto);
        Task<long> UpdateTasksItemAsync(TasksItemDto dto);

        Task<bool> DeleteTasksItemAsync(long id);

        #region Functions
        Task<bool> ValidateTasksItemAsync(long id, string descrizione);
        Task<bool> ChangeStatusTasksItemAsync(long id);
        Task<bool> ChangeOrderTasksItemAsync(List<ViewTasks> tasks);
        Task<long> CopyTaskItemAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewTasks>> GetViewTasksAsync(bool all = true);
        Task<PagedList<ViewTasks>> GetViewTasksByUserIdAsync(string userId);
        Task<PagedList<ViewTasksTags>> GetViewTasksTagsAsync(bool all = true);

        #endregion

        #endregion

        #region TaskActions
        Task<TasksActionsDto> GetTaskItemActionsByTaskIdAsync(long taskId);
        Task<TasksActionDto> GetTaskItemActionByIdAsync(long id);

        Task<long> AddTaskItemActionAsync(TasksActionDto dto);
        Task<long> UpdateTaskItemActionAsync(TasksActionDto dto);

        Task<bool> DeleteTaskItemActionAsync(long id);

        #region Functions
        //Task<bool> ValidateGaProgettiJobAllegatoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaProgettiJobAllegatoAsync(long id);
        #endregion

        #endregion
    }
}
