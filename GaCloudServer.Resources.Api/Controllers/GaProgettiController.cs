using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.ApiDtos.Resources.Progetti;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaProgettiController : Controller
    {
        private readonly IGaProgettiService _gaProgettiService;
        private readonly INotificationService _notificationService;
        private readonly IMailService _mailService;
        private readonly ILogger<GaProgettiController> _logger;

        public GaProgettiController(
            IGaProgettiService gaProgettiService,
            INotificationService notificationService,
            IMailService mailService
            ,ILogger<GaProgettiController> logger)
        {

            _gaProgettiService = gaProgettiService;
            _notificationService = notificationService;
            _mailService = mailService;
            _logger = logger;
        }

        #region ProgettiWork
        [HttpGet("GetGaProgettiWorksAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorksAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiWorksAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ProgettiWorksApiDto, ProgettiWorksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiWorkByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorkByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiWorkByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiWorkApiDto, ProgettiWorkDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiWorksByUserAsync/{userId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorksByUserAsync(string userId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiWorksByUserAsync(userId);
                var apiDtos = dtos.ToApiDto<ProgettiWorksApiDto, ProgettiWorksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiWorkAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiWorkAsync([FromBody] ProgettiWorkApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiWorkDto, ProgettiWorkApiDto>();
                var response = await _gaProgettiService.AddGaProgettiWorkAsync(dto);

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

        [HttpPost("UpdateGaProgettiWorkAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiWorkAsync([FromBody] ProgettiWorkApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiWorkDto, ProgettiWorkApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiWorkAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaProgettiWorkAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiWorkAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiWorkAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaProgettiWorkAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaProgettiWorkAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaProgettiService.ValidateGaProgettiWorkAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaProgettiWorkAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaProgettiWorkAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.ChangeStatusGaProgettiWorkAsync(id);
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

        #endregion

        #endregion

        #region ProgettiJobs
        [HttpGet("GetGaProgettiJobsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ProgettiJobsApiDto, ProgettiJobsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiJobApiDto, ProgettiJobDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobsByWorkIdAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsByWorkIdAsync(long workId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsByWorkIdAsync(workId);
                var apiDtos = dtos.ToApiDto<ProgettiJobsApiDto, ProgettiJobsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobsByWorkIdAndParentIdAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsByWorkIdAndParentIdAsync(workId,parentId);
                var apiDtos = dtos.ToApiDto<ProgettiJobsApiDto, ProgettiJobsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiJobAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobAsync([FromBody] ProgettiJobApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobDto, ProgettiJobApiDto>();
                var response = await _gaProgettiService.AddGaProgettiJobAsync(dto);

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

        [HttpPost("UpdateGaProgettiJobAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiJobAsync([FromBody] ProgettiJobApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobDto, ProgettiJobApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiJobAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaProgettiJobAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiJobAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiJobAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaProgettiJobAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaProgettiJobAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaProgettiService.ValidateGaProgettiJobAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaProgettiJobAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaProgettiJobAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.ChangeStatusGaProgettiJobAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpGet("AddGaProgettiJobLinkAsync/{targetId}/{sourceId}")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobLinkAsync(long targetId,long sourceId)
        {
            try
            {
                var response = await _gaProgettiService.AddGaProgettiJobLinkAsync(targetId,sourceId);
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
        [HttpGet("GetViewGaProgettiJobsByWorkIdAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdAsync(long workId)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdAsync(workId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpGet("GetViewGaProgettiJobsByWorkIdWithChildrenAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdWithChildrenAsync(long workId)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdWithChildrenAsync(workId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync/{workId}/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync(long workId,bool all=true)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync(workId,all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaProgettiJobsByWorkIdAndParentIdAsync/{workId}/{parentId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdAndParentIdAsync(workId,parentId);
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
