using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Personale;
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
    public class GaPersonaleController : Controller
    {
        private readonly IGaPersonaleService _gaPersonaleService;
        private readonly ILogger<GaPersonaleController> _logger;

        public GaPersonaleController(
            IGaPersonaleService gaPersonaleService
            , ILogger<GaPersonaleController> logger)
        {

            _gaPersonaleService = gaPersonaleService;
            _logger = logger;
        }


        #region PersonaleQualifiche
        [HttpGet("GetGaPersonaleQualificheAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleQualificheAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleQualificheAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleQualificheApiDto, PersonaleQualificheDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleQualificaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleQualificaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleQualificaByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleQualificaApiDto, PersonaleQualificaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleQualificaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleQualificaAsync([FromBody] PersonaleQualificaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleQualificaDto, PersonaleQualificaApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleQualificaAsync(dto);

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

        [HttpPost("UpdateGaPersonaleQualificaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleQualificaAsync([FromBody] PersonaleQualificaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleQualificaDto, PersonaleQualificaApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleQualificaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleQualificaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleQualificaAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleQualificaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleQualificaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleQualificaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleQualificaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleQualificaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleQualificaAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleQualificaAsync(id);
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

        #region PersonaleAssunzioni
        [HttpGet("GetGaPersonaleAssunzioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleAssunzioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleAssunzioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleAssunzioniApiDto, PersonaleAssunzioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleAssunzioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleAssunzioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleAssunzioneByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleAssunzioneApiDto, PersonaleAssunzioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleAssunzioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleAssunzioneAsync([FromBody] PersonaleAssunzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleAssunzioneDto, PersonaleAssunzioneApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleAssunzioneAsync(dto);

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

        [HttpPost("UpdateGaPersonaleAssunzioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleAssunzioneAsync([FromBody] PersonaleAssunzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleAssunzioneDto, PersonaleAssunzioneApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleAssunzioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleAssunzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleAssunzioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleAssunzioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleAssunzioneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleAssunzioneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleAssunzioneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleAssunzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleAssunzioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleAssunzioneAsync(id);
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

        #region PersonaleDipendenti
        [HttpGet("GetGaPersonaleDipendentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleDipendentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleDipendentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleDipendentiApiDto, PersonaleDipendentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleDipendenteByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleDipendenteByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleDipendenteByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleDipendenteApiDto, PersonaleDipendenteDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleDipendenteAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleDipendenteAsync([FromBody] PersonaleDipendenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleDipendenteDto, PersonaleDipendenteApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleDipendenteAsync(dto);

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

        [HttpPost("UpdateGaPersonaleDipendenteAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleDipendenteAsync([FromBody] PersonaleDipendenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleDipendenteDto, PersonaleDipendenteApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleDipendenteAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleDipendenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleDipendenteAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleDipendenteAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleDipendenteAsync/{id}/{userId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleDipendenteAsync(long id, string userId)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleDipendenteAsync(id, userId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleDipendenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleDipendenteAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleDipendenteAsync(id);
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
