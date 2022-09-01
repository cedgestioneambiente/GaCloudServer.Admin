using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.BusinnessLogic.DTOs.Cdr;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Autorizzazioni;
using GaCloudServer.Resources.Api.Dtos.Cdr;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Resources;
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
    public class GaCdrController : Controller
    {
        private readonly IGaCdrService _gaCdrService;
        private readonly IApiErrorResources _errorResources;
        private readonly IFileService _fileService;
        private readonly ILogger<GaAutorizzazioniController> _logger;

        public GaCdrController(
            IGaCdrService gaCdrService
            ,IApiErrorResources errorResources
            ,IFileService fileService
            ,ILogger<GaAutorizzazioniController> logger)
        {

            _gaCdrService = gaCdrService;
            _fileService = fileService;
            _errorResources= errorResources;
            _logger = logger;
        }


        #region CdrCentri
        [HttpGet("GetGaCdrCentriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCentriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrCentriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrCentriApiDto, CdrCentriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetGaCdrCentroByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCentroByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCdrService.GetGaCdrCentroByIdAsync(id);
                var apiDto = dto.ToApiDto<CdrCentroApiDto, CdrCentroDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCdrCentroAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCdrCentroAsync([FromBody]CdrCentroApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCentroDto, CdrCentroApiDto>();
                var response = await _gaCdrService.AddGaCdrCentroAsync(dto);

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

        [HttpPost("UpdateGaCdrCentroAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrCentroAsync([FromBody] CdrCentroApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCentroDto, CdrCentroApiDto>();
                var response = await _gaCdrService.UpdateGaCdrCentroAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCdrCentroAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCdrCentroAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.DeleteGaCdrCentroAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCdrCentroAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCdrCentroAsync(long id,string descrizione)
        {
            try
            {
                var response = await _gaCdrService.ValidateGaCdrCentroAsync(id,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCdrCentroAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCdrCentroAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.ChangeStatusGaCdrCentroAsync(id);
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