using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Global;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Tasks;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Global;
using GaCloudServer.Resources.Api.Dtos.Resources.Tasks;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(
            ITasksService tasksService
            ,ILogger<TasksController> logger)
        {

            _tasksService = tasksService;
            _logger = logger;
        }


        #region TasksTags
        [HttpGet("GetTasksTagsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetTasksTagsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _tasksService.GetTasksTagsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<TasksTagsApiDto, TasksTagsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetTasksTagByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetTasksTagByIdAsync(long id)
        {
            try
            {
                var dto = await _tasksService.GetTasksTagByIdAsync(id);
                var apiDto = dto.ToApiDto<TasksTagApiDto, TasksTagDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddTasksTagAsync")]
        public async Task<ActionResult<ApiResponse>> AddTasksTagAsync([FromBody] TasksTagApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<TasksTagDto, TasksTagApiDto>();
                var response = await _tasksService.AddTasksTagAsync(dto);

                return new ApiResponse(response);
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }

        }

        [HttpPost("UpdateTasksTagAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateTasksTagAsync([FromBody] TasksTagApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<TasksTagDto, TasksTagApiDto>();
                var response = await _tasksService.UpdateTasksTagAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteTasksTagAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteTasksTagAsync(long id)
        {
            try
            {
                var response = await _tasksService.DeleteTasksTagAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateTasksTagAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateTasksTagAsync(long id, string descrizione)
        {
            try
            {
                var response = await _tasksService.ValidateTasksTagAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusTasksTagAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusTasksTagAsync(long id)
        {
            try
            {
                var response = await _tasksService.ChangeStatusTasksTagAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #endregion

        #region TasksItems
        [HttpGet("GetTasksItemsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetTasksItemsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _tasksService.GetTasksItemsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<TasksItemsApiDto, TasksItemsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetTasksItemByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetTasksItemByIdAsync(long id)
        {
            try
            {
                var dto = await _tasksService.GetTasksItemByIdAsync(id);
                var apiDto = dto.ToApiDto<TasksItemApiDto, TasksItemDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddTasksItemAsync")]
        public async Task<ActionResult<ApiResponse>> AddTasksItemAsync([FromBody] TasksItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<TasksItemDto, TasksItemApiDto>();
                var response = await _tasksService.AddTasksItemAsync(dto);

                return new ApiResponse(response);
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }

        }

        [HttpPost("UpdateTasksItemAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateTasksItemAsync([FromBody] TasksItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<TasksItemDto, TasksItemApiDto>();
                var response = await _tasksService.UpdateTasksItemAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteTasksItemAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteTasksItemAsync(long id)
        {
            try
            {
                var response = await _tasksService.DeleteTasksItemAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateTasksItemAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateTasksItemAsync(long id, string descrizione)
        {
            try
            {
                var response = await _tasksService.ValidateTasksItemAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusTasksItemAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusTasksItemAsync(long id)
        {
            try
            {
                var response = await _tasksService.ChangeStatusTasksItemAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpPost("ChangeOrderTasksItemAsync")]
        public async Task<ActionResult<ApiResponse>> ChangeOrderTasksItemAsync([FromBody] List<ViewTasks> tasks)
        {
            try
            {
                var response = await _tasksService.ChangeOrderTasksItemAsync(tasks);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region Views
        [HttpGet("GetViewTasksAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewTasksAsync(bool all = true)
        {
            try
            {
                var view = await _tasksService.GetViewTasksAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewTasksByUserIdAsync/{userId}")]
        public async Task<ActionResult<ApiResponse>> GetViewTasksByUserIdAsync(string userId)
        {
            try
            {
                var view = await _tasksService.GetViewTasksByUserIdAsync(userId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewTasksTagsAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewTasksTagsAsync(bool all = true)
        {
            try
            {
                var view = await _tasksService.GetViewTasksTagsAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #endregion
    }
}
