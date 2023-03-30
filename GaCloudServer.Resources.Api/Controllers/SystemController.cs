using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Api.Dtos.Resources.System;
using GaCloudServer.BusinnessLogic.Dtos.Resources.System;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
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
    public class SystemController : Controller
    {
        private readonly ISystemService _systemService;
        private readonly ILogger<SystemController> _logger;

        public SystemController(
            ISystemService systemService
            , ILogger<SystemController> logger)
        {

            _systemService = systemService;
            _logger = logger;
        }


        #region SystemVersions
        [HttpGet("GetSystemVersionsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetSystemVersionsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _systemService.GetSystemVersionsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<SystemVersionsApiDto, SystemVersionsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetSystemVersionByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetSystemVersionByIdAsync(long id)
        {
            try
            {
                var dto = await _systemService.GetSystemVersionByIdAsync(id);
                var apiDto = dto.ToApiDto<SystemVersionApiDto, SystemVersionDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddSystemVersionAsync")]
        public async Task<ActionResult<ApiResponse>> AddSystemVersionAsync([FromBody] SystemVersionApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SystemVersionDto, SystemVersionApiDto>();
                var response = await _systemService.AddSystemVersionAsync(dto);

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

        [HttpPost("UpdateSystemVersionAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateSystemVersionAsync([FromBody] SystemVersionApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SystemVersionDto, SystemVersionApiDto>();
                var response = await _systemService.UpdateSystemVersionAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteSystemVersionAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteSystemVersionAsync(long id)
        {
            try
            {
                var response = await _systemService.DeleteSystemVersionAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateSystemVersionAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateSystemVersionAsync(long id, string descrizione)
        {
            try
            {
                var response = await _systemService.ValidateSystemVersionAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusSystemVersionAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusSystemVersionAsync(long id)
        {
            try
            {
                var response = await _systemService.ChangeStatusSystemVersionAsync(id);
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

    }
}

