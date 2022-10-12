using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneAuto;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.PrenotazioneAuto;
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
    public class GaPrenotazioneAutoController : Controller
    {
        private readonly IGaPrenotazioneAutoService _gaPrenotazioneAutoService;
        private readonly ILogger<GaPrenotazioneAutoController> _logger;
        private readonly TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);

        public GaPrenotazioneAutoController(
            IGaPrenotazioneAutoService gaPrenotazioneAutoService
            ,ILogger<GaPrenotazioneAutoController> logger)
        {

            _gaPrenotazioneAutoService = gaPrenotazioneAutoService;
            _logger = logger;
        }


        #region PrenotazioneAutoSedi
        [HttpGet("GetGaPrenotazioneAutoSediAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneAutoSediAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPrenotazioneAutoService.GetGaPrenotazioneAutoSediAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PrenotazioneAutoSediApiDto, PrenotazioneAutoSediDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetGaPrenotazioneAutoSedeByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneAutoSedeByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPrenotazioneAutoService.GetGaPrenotazioneAutoSedeByIdAsync(id);
                var apiDto = dto.ToApiDto<PrenotazioneAutoSedeApiDto, PrenotazioneAutoSedeDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPrenotazioneAutoSedeAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPrenotazioneAutoSedeAsync([FromBody]PrenotazioneAutoSedeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneAutoSedeDto, PrenotazioneAutoSedeApiDto>();
                var response = await _gaPrenotazioneAutoService.AddGaPrenotazioneAutoSedeAsync(dto);

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

        [HttpPost("UpdateGaPrenotazioneAutoSedeAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPrenotazioneAutoSedeAsync([FromBody] PrenotazioneAutoSedeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneAutoSedeDto, PrenotazioneAutoSedeApiDto>();
                var response = await _gaPrenotazioneAutoService.UpdateGaPrenotazioneAutoSedeAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPrenotazioneAutoSedeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPrenotazioneAutoSedeAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.DeleteGaPrenotazioneAutoSedeAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPrenotazioneAutoSedeAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPrenotazioneAutoSedeAsync(long id,string descrizione)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.ValidateGaPrenotazioneAutoSedeAsync(id,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPrenotazioneAutoSedeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPrenotazioneAutoSedeAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.ChangeStatusGaPrenotazioneAutoSedeAsync(id);
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

        #region PrenotazioneAutoVeicoli
        [HttpGet("GetGaPrenotazioneAutoVeicoliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneAutoVeicoliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPrenotazioneAutoService.GetGaPrenotazioneAutoVeicoliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PrenotazioneAutoVeicoliApiDto, PrenotazioneAutoVeicoliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPrenotazioneAutoVeicoloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneAutoVeicoloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPrenotazioneAutoService.GetGaPrenotazioneAutoVeicoloByIdAsync(id);
                var apiDto = dto.ToApiDto<PrenotazioneAutoVeicoloApiDto, PrenotazioneAutoVeicoloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPrenotazioneAutoVeicoloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPrenotazioneAutoVeicoloAsync([FromBody] PrenotazioneAutoVeicoloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneAutoVeicoloDto, PrenotazioneAutoVeicoloApiDto>();
                var response = await _gaPrenotazioneAutoService.AddGaPrenotazioneAutoVeicoloAsync(dto);

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

        [HttpPost("UpdateGaPrenotazioneAutoVeicoloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPrenotazioneAutoVeicoloAsync([FromBody] PrenotazioneAutoVeicoloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneAutoVeicoloDto, PrenotazioneAutoVeicoloApiDto>();
                var response = await _gaPrenotazioneAutoService.UpdateGaPrenotazioneAutoVeicoloAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPrenotazioneAutoVeicoloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPrenotazioneAutoVeicoloAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.DeleteGaPrenotazioneAutoVeicoloAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPrenotazioneAutoVeicoloAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPrenotazioneAutoVeicoloAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.ValidateGaPrenotazioneAutoVeicoloAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPrenotazioneAutoVeicoloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPrenotazioneAutoVeicoloAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.ChangeStatusGaPrenotazioneAutoVeicoloAsync(id);
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
        [HttpGet("GetViewGaPrenotazioneAutoVeicoliAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPrenotazioneAutoVeicoliAsync(bool all = true)
        {
            try
            {
                var view = await _gaPrenotazioneAutoService.GetViewGaPrenotazioneAutoVeicoliAsync(all);
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

        #region PrenotazioneAutoRegistrazioni
        [HttpGet("GetGaPrenotazioneAutoRegistrazioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneAutoRegistrazioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPrenotazioneAutoService.GetGaPrenotazioneAutoRegistrazioneByIdAsync(id);
                var apiDto = dto.ToApiDto<PrenotazioneAutoRegistrazioneApiDto, PrenotazioneAutoRegistrazioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPrenotazioneAutoRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPrenotazioneAutoRegistrazioneAsync([FromBody] PrenotazioneAutoRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);
                var dto = apiDto.ToDto<PrenotazioneAutoRegistrazioneDto, PrenotazioneAutoRegistrazioneApiDto>();
                var response = await _gaPrenotazioneAutoService.AddGaPrenotazioneAutoRegistrazioneAsync(dto);

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

        [HttpPost("UpdateGaPrenotazioneAutoRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPrenotazioneAutoRegistrazioneAsync([FromBody] PrenotazioneAutoRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);
                var dto = apiDto.ToDto<PrenotazioneAutoRegistrazioneDto, PrenotazioneAutoRegistrazioneApiDto>();
                var response = await _gaPrenotazioneAutoService.UpdateGaPrenotazioneAutoRegistrazioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPrenotazioneAutoRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPrenotazioneAutoRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.DeleteGaPrenotazioneAutoRegistrazioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpPost("ValidateGaPrenotazioneAutoRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPrenotazioneAutoRegistrazioneAsync([FromBody] PrenotazioneAutoRegistrazioneApiDto apiDto)
        {
            try
            {
                var dto = apiDto.ToDto<PrenotazioneAutoRegistrazioneDto, PrenotazioneAutoRegistrazioneApiDto>();
                var response = await _gaPrenotazioneAutoService.ValidateGaPrenotazioneAutoRegistrazioneAsync(dto);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPrenotazioneAutoRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPrenotazioneAutoRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneAutoService.ChangeStatusGaPrenotazioneAutoRegistrazioneAsync(id);
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
        [HttpGet("GetViewGaPrenotazioneAutoRegistrazioniAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPrenotazioneAutoRegistrazioniAsync(bool all=true)
        {
            try
            {
                var view = await _gaPrenotazioneAutoService.GetViewGaPrenotazioneAutoRegistrazioniAsync(all);
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