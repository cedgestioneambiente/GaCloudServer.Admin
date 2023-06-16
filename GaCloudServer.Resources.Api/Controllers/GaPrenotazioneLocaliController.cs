using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneLocali;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.PrenotazioneLocali;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
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
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class GaPrenotazioneLocaliController : Controller
    {
        private readonly IGaPrenotazioneLocaliService _gaPrenotazioneLocaliService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<GaPrenotazioneLocaliController> _logger;
        private readonly IMailService _mailService;
        private readonly TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);

        public GaPrenotazioneLocaliController(
            IGaPrenotazioneLocaliService gaPrenotazioneLocaliService
            , INotificationService notificationService
            , IMailService mailService
            , ILogger<GaPrenotazioneLocaliController> logger)
        {

            _gaPrenotazioneLocaliService = gaPrenotazioneLocaliService;
            _notificationService = notificationService;
            _mailService = mailService;
            _logger = logger;
        }


        #region PrenotazioneLocaliSedi
        [HttpGet("GetGaPrenotazioneLocaliSediAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneLocaliSediAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPrenotazioneLocaliService.GetGaPrenotazioneLocaliSediAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PrenotazioneLocaliSediApiDto, PrenotazioneLocaliSediDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPrenotazioneLocaliSedeByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneLocaliSedeByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPrenotazioneLocaliService.GetGaPrenotazioneLocaliSedeByIdAsync(id);
                var apiDto = dto.ToApiDto<PrenotazioneLocaliSedeApiDto, PrenotazioneLocaliSedeDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPrenotazioneLocaliSedeAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPrenotazioneLocaliSedeAsync([FromBody] PrenotazioneLocaliSedeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneLocaliSedeDto, PrenotazioneLocaliSedeApiDto>();
                var response = await _gaPrenotazioneLocaliService.AddGaPrenotazioneLocaliSedeAsync(dto);

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

        [HttpPost("UpdateGaPrenotazioneLocaliSedeAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPrenotazioneLocaliSedeAsync([FromBody] PrenotazioneLocaliSedeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneLocaliSedeDto, PrenotazioneLocaliSedeApiDto>();
                var response = await _gaPrenotazioneLocaliService.UpdateGaPrenotazioneLocaliSedeAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPrenotazioneLocaliSedeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPrenotazioneLocaliSedeAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.DeleteGaPrenotazioneLocaliSedeAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPrenotazioneLocaliSedeAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPrenotazioneLocaliSedeAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.ValidateGaPrenotazioneLocaliSedeAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPrenotazioneLocaliSedeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPrenotazioneLocaliSedeAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.ChangeStatusGaPrenotazioneLocaliSedeAsync(id);
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

        #region PrenotazioneLocaliUffici
        [HttpGet("GetGaPrenotazioneLocaliUfficiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneLocaliUfficiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPrenotazioneLocaliService.GetGaPrenotazioneLocaliUfficiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PrenotazioneLocaliUfficiApiDto, PrenotazioneLocaliUfficiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPrenotazioneLocaliUfficioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneLocaliUfficioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPrenotazioneLocaliService.GetGaPrenotazioneLocaliUfficioByIdAsync(id);
                var apiDto = dto.ToApiDto<PrenotazioneLocaliUfficioApiDto, PrenotazioneLocaliUfficioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPrenotazioneLocaliUfficioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPrenotazioneLocaliUfficioAsync([FromBody] PrenotazioneLocaliUfficioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneLocaliUfficioDto, PrenotazioneLocaliUfficioApiDto>();
                var response = await _gaPrenotazioneLocaliService.AddGaPrenotazioneLocaliUfficioAsync(dto);

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

        [HttpPost("UpdateGaPrenotazioneLocaliUfficioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPrenotazioneLocaliUfficioAsync([FromBody] PrenotazioneLocaliUfficioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrenotazioneLocaliUfficioDto, PrenotazioneLocaliUfficioApiDto>();
                var response = await _gaPrenotazioneLocaliService.UpdateGaPrenotazioneLocaliUfficioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPrenotazioneLocaliUfficioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPrenotazioneLocaliUfficioAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.DeleteGaPrenotazioneLocaliUfficioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPrenotazioneLocaliUfficioAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPrenotazioneLocaliUfficioAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.ValidateGaPrenotazioneLocaliUfficioAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPrenotazioneLocaliUfficioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPrenotazioneLocaliUfficioAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.ChangeStatusGaPrenotazioneLocaliUfficioAsync(id);
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
        [HttpGet("GetViewGaPrenotazioneLocaliUfficiAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPrenotazioneLocaliUfficiAsync(bool all = true)
        {
            try
            {
                var view = await _gaPrenotazioneLocaliService.GetViewGaPrenotazioneLocaliUfficiAsync(all);
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

        #region PrenotazioneLocaliRegistrazioni
        [HttpGet("GetGaPrenotazioneLocaliRegistrazioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneLocaliRegistrazioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPrenotazioneLocaliService.GetGaPrenotazioneLocaliRegistrazioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PrenotazioneLocaliRegistrazioniApiDto, PrenotazioneLocaliRegistrazioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPrenotazioneLocaliRegistrazioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrenotazioneLocaliRegistrazioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPrenotazioneLocaliService.GetGaPrenotazioneLocaliRegistrazioneByIdAsync(id);
                var apiDto = dto.ToApiDto<PrenotazioneLocaliRegistrazioneApiDto, PrenotazioneLocaliRegistrazioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPrenotazioneLocaliRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPrenotazioneLocaliRegistrazioneAsync([FromBody] PrenotazioneLocaliRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);
                var dto = apiDto.ToDto<PrenotazioneLocaliRegistrazioneDto, PrenotazioneLocaliRegistrazioneApiDto>();
                var response = await _gaPrenotazioneLocaliService.AddGaPrenotazioneLocaliRegistrazioneAsync(dto);

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

        [HttpPost("UpdateGaPrenotazioneLocaliRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPrenotazioneLocaliRegistrazioneAsync([FromBody] PrenotazioneLocaliRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);
                var dto = apiDto.ToDto<PrenotazioneLocaliRegistrazioneDto, PrenotazioneLocaliRegistrazioneApiDto>();
                var response = await _gaPrenotazioneLocaliService.UpdateGaPrenotazioneLocaliRegistrazioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPrenotazioneLocaliRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPrenotazioneLocaliRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.DeleteGaPrenotazioneLocaliRegistrazioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpPost("ValidateGaPrenotazioneLocaliRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPrenotazioneLocaliRegistrazioneAsync([FromBody] PrenotazioneLocaliRegistrazioneApiDto apiDto)
        {
            try
            {
                var dto = apiDto.ToDto<PrenotazioneLocaliRegistrazioneDto, PrenotazioneLocaliRegistrazioneApiDto>();
                var response = await _gaPrenotazioneLocaliService.ValidateGaPrenotazioneLocaliRegistrazioneAsync(dto);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPrenotazioneLocaliRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPrenotazioneLocaliRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _gaPrenotazioneLocaliService.ChangeStatusGaPrenotazioneLocaliRegistrazioneAsync(id);
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
        [HttpGet("GetViewGaPrenotazioneLocaliRegistrazioniAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPrenotazioneLocaliRegistrazioniAsync(bool all = true)
        {
            try
            {
                var view = await _gaPrenotazioneLocaliService.GetViewGaPrenotazioneLocaliRegistrazioniAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPrenotazioneLocaliRegistrazioniByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPrenotazioneLocaliRegistrazioniByIdAsync(long id)
        {
            try
            {
                var view = await _gaPrenotazioneLocaliService.GetViewGaPrenotazioneLocaliRegistrazioniByIdAsync(id);
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
