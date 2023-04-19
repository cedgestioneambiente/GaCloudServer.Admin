using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using GaCloudServer.BusinnessLogic.Hub.Interfaces;
using GaCloudServer.BusinnessLogic.Hub;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Dtos.Resources.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    //[Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IFileService _fileService;
        private readonly ILogger<NotificationController> _logger;
        private readonly IHubContext<NotificationHub, INotificationHub> _notification;
        private readonly IHubContext<BackgroundServicesHub, IBackgroundServicesHub> _backgroundServicesHub;

        public NotificationController(
            INotificationService notificationService
            ,IFileService fileService
            ,ILogger<NotificationController> logger
            , IHubContext<NotificationHub, INotificationHub> notification
            , IHubContext<BackgroundServicesHub, IBackgroundServicesHub> backgroundServicesHub)
        {

            _notificationService = notificationService;
            _fileService = fileService;
            _logger = logger;
            _notification = notification;
            _backgroundServicesHub = backgroundServicesHub;
        }


        #region NotificationApps
        [HttpGet("GetNotificationAppsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetNotificationAppsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _notificationService.GetNotificationAppsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<NotificationAppsApiDto, NotificationAppsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetNotificationAppByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetNotificationAppByIdAsync(long id)
        {
            try
            {
                var dto = await _notificationService.GetNotificationAppByIdAsync(id);
                var apiDto = dto.ToApiDto<NotificationAppApiDto, NotificationAppDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddNotificationAppAsync")]
        public async Task<ActionResult<ApiResponse>> AddNotificationAppAsync([FromBody]NotificationAppApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<NotificationAppDto, NotificationAppApiDto>();
                var response = await _notificationService.AddNotificationAppAsync(dto);

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

        [HttpPost("UpdateNotificationAppAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateNotificationAppAsync([FromBody] NotificationAppApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<NotificationAppDto, NotificationAppApiDto>();
                var response = await _notificationService.UpdateNotificationAppAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteNotificationAppAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteNotificationAppAsync(long id)
        {
            try
            {
                var response = await _notificationService.DeleteNotificationAppAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateNotificationAppAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateNotificationAppAsync(long id,string descrizione)
        {
            try
            {
                var response = await _notificationService.ValidateNotificationAppAsync(id,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusNotificationAppAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusNotificationAppAsync(long id)
        {
            try
            {
                var response = await _notificationService.ChangeStatusNotificationAppAsync(id);
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

        #region NotificationRolesOnApps
        [HttpPost("UpdateNotificationRoleOnAppFromViewAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateNotificationRoleOnAppFromViewAsync([FromBody] ViewNotificationRolesOnApps view)
        {
            try
            {
                var response = await _notificationService.UpdateNotificationRoleOnAppFromViewAsync(view);

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


        #region Views
        [HttpGet("GetViewViewNotificationRolesOnAppsAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewViewNotificationRolesOnAppsAsync(bool all=true)
        {
            try
            {
                var views = await _notificationService.GetViewViewNotificationRolesOnAppsAsync(all);
                return new ApiResponse(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewViewNotificationRolesOnAppsByAppIdAsync/{appId}")]
        public async Task<ActionResult<ApiResponse>> GetViewViewNotificationRolesOnAppsByAppIdAsync(long appId)
        {
            try
            {
                var views = await _notificationService.GetViewViewNotificationRolesOnAppsByAppIdAsync(appId);
                return new ApiResponse(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion
        #endregion

        #region NotificationUsersOnApps
        [HttpPost("UpdateNotificationUserOnAppFromViewAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateNotificationUserOnAppFromViewAsync([FromBody] ViewNotificationUsersOnApps view)
        {
            try
            {
                var response = await _notificationService.UpdateNotificationUserOnAppFromViewAsync(view);

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


        #region Views
        [HttpGet("GetViewViewNotificationUsersOnAppsAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewViewNotificationUsersOnAppsAsync(bool all = true)
        {
            try
            {
                var views = await _notificationService.GetViewViewNotificationUsersOnAppsAsync(all);
                return new ApiResponse(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewViewNotificationUsersOnAppsByUserIdAsync/{userId}")]
        public async Task<ActionResult<ApiResponse>> GetViewViewNotificationUsersOnAppsByUserIdAsync(string userId)
        {
            try
            {
                var views = await _notificationService.GetViewViewNotificationUsersOnAppsByUserIdAsync(userId);
                return new ApiResponse(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion
        #endregion

        #region NotificationEvents
        [HttpGet("TestNotificationEventAsync")]
        public async Task<ActionResult<ApiResponse>> TestNotificationEventAsync()
        {
            try
            {
                _notification.Clients.All.SendNotification(null);

                return new ApiResponse(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("TestBackgroundServicesAsync")]
        public async Task<ActionResult<ApiResponse>> TestBackgroundServicesAsync()
        {
            try
            {
                await this._backgroundServicesHub.Clients.All.PresenzeRefresh(true);

                return new ApiResponse(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteNotificationEventAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteNotificationEventAsync(long id)
        {
            try
            {
                var response = await _notificationService.DeleteNotificationEventAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions

        [HttpGet("ChangeStatusNotificationEventAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusNotificationEventAsync(long id)
        {
            try
            {
                var response = await _notificationService.ChangeStatusNotificationEventAsync(id);
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
        [HttpGet("GetViewViewNotificationEventsByUserIdAsync/{userId}/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewViewNotificationEventsByUserIdAsync(string userId,bool all = true)
        {
            try
            {
                var views = await _notificationService.GetViewViewNotificationEventsByUserIdAsync(userId,all);
                return new ApiResponse(views);
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