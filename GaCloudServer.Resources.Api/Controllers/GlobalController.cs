using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Global;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Global;
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
    public class GlobalController : Controller
    {
        private readonly IGlobalService _globalService;
        private readonly ILogger<GlobalController> _logger;

        public GlobalController(
            IGlobalService globalService
            ,ILogger<GlobalController> logger)
        {

            _globalService = globalService;
            _logger = logger;
        }


        #region GlobalSedi
        [HttpGet("GetGlobalSediAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGlobalSediAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _globalService.GetGlobalSediAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<GlobalSediApiDto, GlobalSediDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGlobalSedeByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGlobalSedeByIdAsync(long id)
        {
            try
            {
                var dto = await _globalService.GetGlobalSedeByIdAsync(id);
                var apiDto = dto.ToApiDto<GlobalSedeApiDto, GlobalSedeDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGlobalSedeAsync")]
        public async Task<ActionResult<ApiResponse>> AddGlobalSedeAsync([FromBody] GlobalSedeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<GlobalSedeDto, GlobalSedeApiDto>();
                var response = await _globalService.AddGlobalSedeAsync(dto);

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

        [HttpPost("UpdateGlobalSedeAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGlobalSedeAsync([FromBody] GlobalSedeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<GlobalSedeDto, GlobalSedeApiDto>();
                var response = await _globalService.UpdateGlobalSedeAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGlobalSedeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGlobalSedeAsync(long id)
        {
            try
            {
                var response = await _globalService.DeleteGlobalSedeAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGlobalSedeAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGlobalSedeAsync(long id, string descrizione)
        {
            try
            {
                var response = await _globalService.ValidateGlobalSedeAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGlobalSedeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGlobalSedeAsync(long id)
        {
            try
            {
                var response = await _globalService.ChangeStatusGlobalSedeAsync(id);
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

        #region GlobalCentriCosti
        [HttpGet("GetGlobalCentriCostiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGlobalCentriCostiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _globalService.GetGlobalCentriCostiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<GlobalCentriCostiApiDto, GlobalCentriCostiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGlobalCentroCostoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGlobalCentroCostoByIdAsync(long id)
        {
            try
            {
                var dto = await _globalService.GetGlobalCentroCostoByIdAsync(id);
                var apiDto = dto.ToApiDto<GlobalCentroCostoApiDto, GlobalCentroCostoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGlobalCentroCostoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGlobalCentroCostoAsync([FromBody] GlobalCentroCostoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<GlobalCentroCostoDto, GlobalCentroCostoApiDto>();
                var response = await _globalService.AddGlobalCentroCostoAsync(dto);

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

        [HttpPost("UpdateGlobalCentroCostoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGlobalCentroCostoAsync([FromBody] GlobalCentroCostoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<GlobalCentroCostoDto, GlobalCentroCostoApiDto>();
                var response = await _globalService.UpdateGlobalCentroCostoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGlobalCentroCostoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGlobalCentroCostoAsync(long id)
        {
            try
            {
                var response = await _globalService.DeleteGlobalCentroCostoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGlobalCentroCostoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGlobalCentroCostoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _globalService.ValidateGlobalCentroCostoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGlobalCentroCostoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGlobalCentroCostoAsync(long id)
        {
            try
            {
                var response = await _globalService.ChangeStatusGlobalCentroCostoAsync(id);
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

        #region GlobalSettori
        [HttpGet("GetGlobalSettoriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGlobalSettoriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _globalService.GetGlobalSettoriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<GlobalSettoriApiDto, GlobalSettoriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGlobalSettoreByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGlobalSettoreByIdAsync(long id)
        {
            try
            {
                var dto = await _globalService.GetGlobalSettoreByIdAsync(id);
                var apiDto = dto.ToApiDto<GlobalSettoreApiDto, GlobalSettoreDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGlobalSettoreAsync")]
        public async Task<ActionResult<ApiResponse>> AddGlobalSettoreAsync([FromBody] GlobalSettoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<GlobalSettoreDto, GlobalSettoreApiDto>();
                var response = await _globalService.AddGlobalSettoreAsync(dto);

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

        [HttpPost("UpdateGlobalSettoreAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGlobalSettoreAsync([FromBody] GlobalSettoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<GlobalSettoreDto, GlobalSettoreApiDto>();
                var response = await _globalService.UpdateGlobalSettoreAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGlobalSettoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGlobalSettoreAsync(long id)
        {
            try
            {
                var response = await _globalService.DeleteGlobalSettoreAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGlobalSettoreAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGlobalSettoreAsync(long id, string descrizione)
        {
            try
            {
                var response = await _globalService.ValidateGlobalSettoreAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGlobalSettoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGlobalSettoreAsync(long id)
        {
            try
            {
                var response = await _globalService.ChangeStatusGlobalSettoreAsync(id);
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
