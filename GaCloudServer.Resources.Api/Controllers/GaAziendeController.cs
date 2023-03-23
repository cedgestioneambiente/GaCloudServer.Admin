using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Aziende;
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
    public class GaAziendeController : Controller
    {
        private readonly IGaAziendeService _gaAziendeService;
        private readonly ILogger<GaAziendeController> _logger;

        public GaAziendeController(
            IGaAziendeService gaAziendeService
            , ILogger<GaAziendeController> logger)
        {

            _gaAziendeService = gaAziendeService;
            _logger = logger;
        }

        #region AziendeListe
        [HttpGet("GetGaAziendeListeAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaAziendeListeAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaAziendeService.GetGaAziendeListeAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<AziendeListeApiDto, AziendeListeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaAziendeListeByRoleAsync/{roleAdmin}/{roleFormula}")]
        public async Task<ActionResult<ApiResponse>> GetGaAziendeListeByRoleAsync(bool roleAdmin,bool roleFormula)
        {
            try
            {
                var dtos = await _gaAziendeService.GetGaAziendeListeByRoleAsync(roleAdmin,roleFormula);
                var apiDtos = dtos.ToApiDto<AziendeListeApiDto, AziendeListeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaAziendeListaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaAziendeListaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaAziendeService.GetGaAziendeListaByIdAsync(id);
                var apiDto = dto.ToApiDto<AziendeListaApiDto, AziendeListaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaAziendeListaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaAziendeListaAsync([FromBody] AziendeListaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<AziendeListaDto, AziendeListaApiDto>();
                var response = await _gaAziendeService.AddGaAziendeListaAsync(dto);

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

        [HttpPost("UpdateGaAziendeListaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaAziendeListaAsync([FromBody] AziendeListaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<AziendeListaDto, AziendeListaApiDto>();
                var response = await _gaAziendeService.UpdateGaAziendeListaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaAziendeListaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaAziendeListaAsync(long id)
        {
            try
            {
                var response = await _gaAziendeService.DeleteGaAziendeListaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaAziendeListaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaAziendeListaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaAziendeService.ValidateGaAziendeListaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaAziendeListaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaAziendeListaAsync(long id)
        {
            try
            {
                var response = await _gaAziendeService.ChangeStatusGaAziendeListaAsync(id);
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