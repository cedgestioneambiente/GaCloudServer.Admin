using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Personale;
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
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaPersonaleController : Controller
    {
        private readonly IGaPersonaleService _gaPersonaleService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaPersonaleController> _logger;

        public GaPersonaleController(
            IGaPersonaleService gaPersonaleService
            , IFileService fileService
            , ILogger<GaPersonaleController> logger)
        {

            _gaPersonaleService = gaPersonaleService;
            _fileService = fileService;
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

        #region Views
        [HttpGet("GetViewGaPersonaleUsersOnDipendentiAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPersonaleUsersOnDipendentiAsync(bool all=true)
        {
            try
            {
                var view = await _gaPersonaleService.GetViewGaPersonaleUsersOnDipendentiAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPersonaleDipendentiByQualificaAndSedeAsync/{qualificaId}/{sedeId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPersonaleDipendentiByQualificaAndSedeAsync(long qualificaId=0,long sedeId=0)
        {
            try
            {
                var view = await _gaPersonaleService.GetViewGaPersonaleDipendentiByQualificaAndSedeAsync(qualificaId,sedeId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPersonaleDipendenteByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPersonaleDipendenteByIdAsync(long id)
        {
            try
            {
                var view = await _gaPersonaleService.GetViewGaPersonaleDipendenteByIdAsync(id);
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

        #region PersonaleScadenzeDettagli
        [HttpGet("GetGaPersonaleScadenzeDettagliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleScadenzeDettagliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleScadenzeDettagliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleScadenzeDettagliApiDto, PersonaleScadenzeDettagliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleScadenzaDettaglioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleScadenzaDettaglioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleScadenzaDettaglioByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleScadenzaDettaglioApiDto, PersonaleScadenzaDettaglioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleScadenzaDettaglioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleScadenzaDettaglioAsync([FromBody] PersonaleScadenzaDettaglioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleScadenzaDettaglioDto, PersonaleScadenzaDettaglioApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleScadenzaDettaglioAsync(dto);

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

        [HttpPost("UpdateGaPersonaleScadenzaDettaglioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleScadenzaDettaglioAsync([FromBody] PersonaleScadenzaDettaglioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleScadenzaDettaglioDto, PersonaleScadenzaDettaglioApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleScadenzaDettaglioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleScadenzaDettaglioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleScadenzaDettaglioAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleScadenzaDettaglioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleScadenzaDettaglioAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleScadenzaDettaglioAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleScadenzaDettaglioAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleScadenzaDettaglioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleScadenzaDettaglioAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleScadenzaDettaglioAsync(id);
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

        #region PersonaleScadenzeTipi
        [HttpGet("GetGaPersonaleScadenzeTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleScadenzeTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleScadenzeTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleScadenzeTipiApiDto, PersonaleScadenzeTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleScadenzaTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleScadenzaTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleScadenzaTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleScadenzaTipoApiDto, PersonaleScadenzaTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleScadenzaTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleScadenzaTipoAsync([FromBody] PersonaleScadenzaTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleScadenzaTipoDto, PersonaleScadenzaTipoApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleScadenzaTipoAsync(dto);

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

        [HttpPost("UpdateGaPersonaleScadenzaTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleScadenzaTipoAsync([FromBody] PersonaleScadenzaTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleScadenzaTipoDto, PersonaleScadenzaTipoApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleScadenzaTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleScadenzaTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleScadenzaTipoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleScadenzaTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleScadenzaTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleScadenzaTipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleScadenzaTipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleScadenzaTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleScadenzaTipoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleScadenzaTipoAsync(id);
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

        #region PersonaleDipendentiScadenze
        [HttpGet("GetGaPersonaleDipendentiScadenzeAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleDipendentiScadenzeAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleDipendentiScadenzeAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleDipendentiScadenzeApiDto, PersonaleDipendentiScadenzeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleDipendenteScadenzaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleDipendenteScadenzaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleDipendenteScadenzaByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleDipendenteScadenzaApiDto, PersonaleDipendenteScadenzaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleDipendenteScadenzaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleDipendenteScadenzaAsync([FromBody] PersonaleDipendenteScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleDipendenteScadenzaDto, PersonaleDipendenteScadenzaApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleDipendenteScadenzaAsync(dto);

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

        [HttpPost("UpdateGaPersonaleDipendenteScadenzaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleDipendenteScadenzaAsync([FromBody] PersonaleDipendenteScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleDipendenteScadenzaDto, PersonaleDipendenteScadenzaApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleDipendenteScadenzaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleDipendenteScadenzaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleDipendenteScadenzaAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleDipendenteScadenzaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaPersonaleDipendenteScadenzaAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleDipendenteScadenzaAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaPersonaleService.ValidateGaPersonaleDipendenteScadenzaAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        [HttpGet("ChangeStatusGaPersonaleDipendenteScadenzaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleDipendenteScadenzaAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleDipendenteScadenzaAsync(id);
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


        #region PersonaleSanzioniMotivi
        [HttpGet("GetGaPersonaleSanzioniMotiviAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSanzioniMotiviAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleSanzioniMotiviAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleSanzioniMotiviApiDto, PersonaleSanzioniMotiviDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleSanzioneMotivoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSanzioneMotivoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleSanzioneMotivoByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleSanzioneMotivoApiDto, PersonaleSanzioneMotivoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleSanzioneMotivoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleSanzioneMotivoAsync([FromBody] PersonaleSanzioneMotivoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleSanzioneMotivoDto, PersonaleSanzioneMotivoApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleSanzioneMotivoAsync(dto);

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

        [HttpPost("UpdateGaPersonaleSanzioneMotivoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleSanzioneMotivoAsync([FromBody] PersonaleSanzioneMotivoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleSanzioneMotivoDto, PersonaleSanzioneMotivoApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleSanzioneMotivoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleSanzioneMotivoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleSanzioneMotivoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleSanzioneMotivoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleSanzioneMotivoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleSanzioneMotivoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleSanzioneMotivoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleSanzioneMotivoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleSanzioneMotivoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleSanzioneMotivoAsync(id);
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

        #region PersonaleSanzioniDescrizioni
        [HttpGet("GetGaPersonaleSanzioniDescrizioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSanzioniDescrizioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleSanzioniDescrizioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleSanzioniDescrizioniApiDto, PersonaleSanzioniDescrizioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleSanzioneDescrizioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSanzioneDescrizioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleSanzioneDescrizioneByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleSanzioneDescrizioneApiDto, PersonaleSanzioneDescrizioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleSanzioneDescrizioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleSanzioneDescrizioneAsync([FromBody] PersonaleSanzioneDescrizioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleSanzioneDescrizioneDto, PersonaleSanzioneDescrizioneApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleSanzioneDescrizioneAsync(dto);

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

        [HttpPost("UpdateGaPersonaleSanzioneDescrizioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleSanzioneDescrizioneAsync([FromBody] PersonaleSanzioneDescrizioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleSanzioneDescrizioneDto, PersonaleSanzioneDescrizioneApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleSanzioneDescrizioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleSanzioneDescrizioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleSanzioneDescrizioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleSanzioneDescrizioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleSanzioneDescrizioneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleSanzioneDescrizioneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleSanzioneDescrizioneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleSanzioneDescrizioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleSanzioneDescrizioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleSanzioneDescrizioneAsync(id);
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

        #region PersonaleSanzioni
        [HttpGet("GetGaPersonaleSanzioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSanzioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleSanzioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleSanzioniApiDto, PersonaleSanzioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleSanzioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSanzioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleSanzioneByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleSanzioneApiDto, PersonaleSanzioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleSanzioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleSanzioneAsync([FromForm] PersonaleSanzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleSanzioni";
                var dto = apiDto.ToDto<PersonaleSanzioneDto, PersonaleSanzioneApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleSanzioneAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleSanzioneAsync(dto);
                    return new ApiResponse("CreatedWithFile", response, code.Status201Created);
                }

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

        [HttpPost("UpdateGaPersonaleSanzioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleSanzioneAsync([FromForm] PersonaleSanzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleSanzioni";
                var dto = apiDto.ToDto<PersonaleSanzioneDto, PersonaleSanzioneApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleSanzioneAsync(dto);
                bool failureDelete = false;
                if (apiDto.deleteFile)
                {
                    var deleteResponse = await _fileService.Remove(apiDto.FileId);
                    if (!deleteResponse)
                    {
                        failureDelete = true;

                    }
                    else
                    {
                        dto.Id = response;
                        dto.FileFolder = null;
                        dto.FileName = null;
                        dto.FileSize = null;
                        dto.FileType = null;
                        dto.FileId = null;
                        var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleSanzioneAsync(dto);
                    }
                }

                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleSanzioneAsync(dto);

                    if (!failureDelete)
                    {
                        return new ApiResponse("UpdatedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("UpdatedWithFile/FailureDelete", response, code.Status207MultiStatus);
                    }

                }

                if (!failureDelete)
                {
                    return new ApiResponse("Updated", response, code.Status200OK);
                }
                else
                {
                    return new ApiResponse("Updated/FailureDelete", response, code.Status207MultiStatus);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleSanzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleSanzioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleSanzioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleSanzioneAsync/{id}/{personaleDipendenteId}/{personaleSanzioneMotivoId}/{personaleSanzioneDescrizioneId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleSanzioneAsync(long id, long personaleDipendenteId, long personaleSanzioneMotivoId, long personaleSanzioneDescrizioneId)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleSanzioneAsync(id, personaleDipendenteId, personaleSanzioneMotivoId, personaleSanzioneDescrizioneId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleSanzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleSanzioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleSanzioneAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        //[HttpGet("ExportGaDipendentiSanzioni")]
        //[ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        //[AutoWrapIgnore]
        //public IActionResult ExportGaDipendentiSanzioni()
        //{

        //    try
        //    {
        //        var entities = _gaPersonaleService.GetViewGaDipendentiSanzioniAsync(0).Result.Data;
        //        string title = "Riepilogo Sanzioni Dipendenti";
        //        string[] columns = { "Id", "Dipendente", "Sede", "Data", "Motivo", "Descrizione", "DettaglioSanzione", "Disabled" };
        //        byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "RIEPILOGO_SANZIONI_DIPENDENTI", true, columns);

        //        return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
        //        {
        //            FileDownloadName = "Riepilogo_Sanzioni_Dipendenti.xlsx"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiException(ex.Message);
        //    }
        //}
        #endregion

        #endregion


        #region PersonaleAbilitazioniTipi
        [HttpGet("GetGaPersonaleAbilitazioniTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleAbilitazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleAbilitazioniTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleAbilitazioniTipiApiDto, PersonaleAbilitazioniTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleAbilitazioneTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleAbilitazioneTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleAbilitazioneTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleAbilitazioneTipoApiDto, PersonaleAbilitazioneTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleAbilitazioneTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleAbilitazioneTipoAsync([FromBody] PersonaleAbilitazioneTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleAbilitazioneTipoDto, PersonaleAbilitazioneTipoApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleAbilitazioneTipoAsync(dto);

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

        [HttpPost("UpdateGaPersonaleAbilitazioneTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleAbilitazioneTipoAsync([FromBody] PersonaleAbilitazioneTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleAbilitazioneTipoDto, PersonaleAbilitazioneTipoApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleAbilitazioneTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleAbilitazioneTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleAbilitazioneTipoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleAbilitazioneTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleAbilitazioneTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleAbilitazioneTipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleAbilitazioneTipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleAbilitazioneTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleAbilitazioneTipoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleAbilitazioneTipoAsync(id);
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

        #region PersonaleAbilitazioni
        [HttpGet("GetGaPersonaleAbilitazioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleAbilitazioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleAbilitazioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleAbilitazioniApiDto, PersonaleAbilitazioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleAbilitazioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleAbilitazioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleAbilitazioneByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleAbilitazioneApiDto, PersonaleAbilitazioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleAbilitazioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleAbilitazioneAsync([FromForm] PersonaleAbilitazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleAbilitazioni";
                var dto = apiDto.ToDto<PersonaleAbilitazioneDto, PersonaleAbilitazioneApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleAbilitazioneAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleAbilitazioneAsync(dto);
                    return new ApiResponse("CreatedWithFile", response, code.Status201Created);
                }

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

        [HttpPost("UpdateGaPersonaleAbilitazioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleAbilitazioneAsync([FromForm] PersonaleAbilitazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleAbilitazioni";
                var dto = apiDto.ToDto<PersonaleAbilitazioneDto, PersonaleAbilitazioneApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleAbilitazioneAsync(dto);
                bool failureDelete = false;
                if (apiDto.deleteFile)
                {
                    var deleteResponse = await _fileService.Remove(apiDto.FileId);
                    if (!deleteResponse)
                    {
                        failureDelete = true;

                    }
                    else
                    {
                        dto.Id = response;
                        dto.FileFolder = null;
                        dto.FileName = null;
                        dto.FileSize = null;
                        dto.FileType = null;
                        dto.FileId = null;
                        var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleAbilitazioneAsync(dto);
                    }
                }

                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleAbilitazioneAsync(dto);

                    if (!failureDelete)
                    {
                        return new ApiResponse("UpdatedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("UpdatedWithFile/FailureDelete", response, code.Status207MultiStatus);
                    }

                }

                if (!failureDelete)
                {
                    return new ApiResponse("Updated", response, code.Status200OK);
                }
                else
                {
                    return new ApiResponse("Updated/FailureDelete", response, code.Status207MultiStatus);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleAbilitazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleAbilitazioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleAbilitazioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleAbilitazioneAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleAbilitazioneAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaPersonaleService.ValidateGaPersonaleAbilitazioneAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        [HttpGet("ChangeStatusGaPersonaleAbilitazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleAbilitazioneAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleAbilitazioneAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        //[HttpGet("ExportGaDipendentiScadenziarioIdoneita")]
        //[ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        //[AutoWrapIgnore]
        //public IActionResult ExportGaDipendentiScadenziarioIdoneita()
        //{

        //    try
        //    {
        //        var entities = _gaPersonaleService.GetViewGaDipendentiScadenziarioIdoneitaAsync().Result.Data;
        //        string title = "Scadenziario Idoneità Dipendenti";
        //        string[] columns = { "Id", "Dipendente", "Sede", "DataScadenza", "DataVisita", "IdoneitaTipo", "IdoneitaDettaglio", "Stato", "Disabled" };
        //        byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "SCADENZIARIO_IDONEITA_DIPENDENTI", true, columns);

        //        return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
        //        {
        //            FileDownloadName = "Scadenziario_Idoneita_Dipendenti.xlsx"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiException(ex.Message);
        //    }
        //}

        #endregion

        #endregion


        #region PersonaleRetributiviTipi
        [HttpGet("GetGaPersonaleRetributiviTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleRetributiviTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleRetributiviTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleRetributiviTipiApiDto, PersonaleRetributiviTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleRetributivoTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleRetributivoTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleRetributivoTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleRetributivoTipoApiDto, PersonaleRetributivoTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleRetributivoTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleRetributivoTipoAsync([FromBody] PersonaleRetributivoTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleRetributivoTipoDto, PersonaleRetributivoTipoApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleRetributivoTipoAsync(dto);

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

        [HttpPost("UpdateGaPersonaleRetributivoTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleRetributivoTipoAsync([FromBody] PersonaleRetributivoTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleRetributivoTipoDto, PersonaleRetributivoTipoApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleRetributivoTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleRetributivoTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleRetributivoTipoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleRetributivoTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleRetributivoTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleRetributivoTipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleRetributivoTipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleRetributivoTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleRetributivoTipoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleRetributivoTipoAsync(id);
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

        #region PersonaleRetributivi
        [HttpGet("GetGaPersonaleRetributiviAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleRetributiviAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleRetributiviAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleRetributiviApiDto, PersonaleRetributiviDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleRetributivoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleRetributivoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleRetributivoByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleRetributivoApiDto, PersonaleRetributivoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleRetributivoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleRetributivoAsync([FromForm] PersonaleRetributivoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleRetributivi";
                var dto = apiDto.ToDto<PersonaleRetributivoDto, PersonaleRetributivoApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleRetributivoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleRetributivoAsync(dto);
                    return new ApiResponse("CreatedWithFile", response, code.Status201Created);
                }

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

        [HttpPost("UpdateGaPersonaleRetributivoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleRetributivoAsync([FromForm] PersonaleRetributivoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleRetributivi";
                var dto = apiDto.ToDto<PersonaleRetributivoDto, PersonaleRetributivoApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleRetributivoAsync(dto);
                bool failureDelete = false;
                if (apiDto.deleteFile)
                {
                    var deleteResponse = await _fileService.Remove(apiDto.FileId);
                    if (!deleteResponse)
                    {
                        failureDelete = true;

                    }
                    else
                    {
                        dto.Id = response;
                        dto.FileFolder = null;
                        dto.FileName = null;
                        dto.FileSize = null;
                        dto.FileType = null;
                        dto.FileId = null;
                        var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleRetributivoAsync(dto);
                    }
                }

                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleRetributivoAsync(dto);

                    if (!failureDelete)
                    {
                        return new ApiResponse("UpdatedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("UpdatedWithFile/FailureDelete", response, code.Status207MultiStatus);
                    }

                }

                if (!failureDelete)
                {
                    return new ApiResponse("Updated", response, code.Status200OK);
                }
                else
                {
                    return new ApiResponse("Updated/FailureDelete", response, code.Status207MultiStatus);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleRetributivoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleRetributivoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleRetributivoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleRetributivoAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleRetributivoAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaPersonaleService.ValidateGaPersonaleRetributivoAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        [HttpGet("ChangeStatusGaPersonaleRetributivoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleRetributivoAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleRetributivoAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        //[HttpGet("ExportGaDipendentiScadenziarioIdoneita")]
        //[ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        //[AutoWrapIgnore]
        //public IActionResult ExportGaDipendentiScadenziarioIdoneita()
        //{

        //    try
        //    {
        //var entities = _gaPersonaleService.GetViewGaDipendentiRetributiviAsync(0).Result.Data;
        //string title = "Riepilogo Retributivi Dipendenti";
        //string[] columns = { "Id", "Dipendente", "Sede", "Data", "Tipo", "DettaglioRetributivo", "Disabled" };
        //byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "RIEPILOGO_RETRIBUTIVI_DIPENDENTI", true, columns);

        //        return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
        //{
        //    FileDownloadName = "Riepilogo_Retributivi_Dipendenti.xlsx"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiException(ex.Message);
        //    }
        //}

        #endregion

        #endregion


        #region PersonaleSchedeConsegne
        [HttpGet("GetGaPersonaleSchedeConsegneAsync/{personaleDipendenteId}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSchedeConsegneAsync(long personaleDipendenteId)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleSchedeConsegneAsync(personaleDipendenteId);
                var apiDtos = dtos.ToApiDto<PersonaleSchedeConsegneApiDto, PersonaleSchedeConsegneDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleSchedaConsegnaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSchedaConsegnaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleSchedaConsegnaByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleSchedaConsegnaApiDto, PersonaleSchedaConsegnaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleSchedaConsegnaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleSchedaConsegnaAsync([FromForm] PersonaleSchedaConsegnaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleSchedeConsegne";
                var dto = apiDto.ToDto<PersonaleSchedaConsegnaDto, PersonaleSchedaConsegnaApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleSchedaConsegnaAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleSchedaConsegnaAsync(dto);
                    return new ApiResponse("CreatedWithFile", response, code.Status201Created);
                }

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

        [HttpPost("UpdateGaPersonaleSchedaConsegnaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleSchedaConsegnaAsync([FromForm] PersonaleSchedaConsegnaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "PersonaleSchedeConsegne";
                var dto = apiDto.ToDto<PersonaleSchedaConsegnaDto, PersonaleSchedaConsegnaApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleSchedaConsegnaAsync(dto);
                bool failureDelete = false;
                if (apiDto.deleteFile)
                {
                    var deleteResponse = await _fileService.Remove(apiDto.FileId);
                    if (!deleteResponse)
                    {
                        failureDelete = true;

                    }
                    else
                    {
                        dto.Id = response;
                        dto.FileFolder = null;
                        dto.FileName = null;
                        dto.FileSize = null;
                        dto.FileType = null;
                        dto.FileId = null;
                        var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleSchedaConsegnaAsync(dto);
                    }
                }

                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleSchedaConsegnaAsync(dto);

                    if (!failureDelete)
                    {
                        return new ApiResponse("UpdatedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("UpdatedWithFile/FailureDelete", response, code.Status207MultiStatus);
                    }

                }

                if (!failureDelete)
                {
                    return new ApiResponse("Updated", response, code.Status200OK);
                }
                else
                {
                    return new ApiResponse("Updated/FailureDelete", response, code.Status207MultiStatus);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleSchedaConsegnaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleSchedaConsegnaAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleSchedaConsegnaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaPersonaleSchedaConsegnaAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleSchedaConsegnaAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaPersonaleService.ValidateGaPersonaleSchedaConsegnaAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaPersonaleSchedaConsegnaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleSchedaConsegnaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaPersonaleService.ChangeStatusGaPersonaleSchedaConsegnaAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("PrintDipendentiSchedaById/{id}")]
        //public async Task<ApiResponse> PrintDipendentiSchedaById(long id)
        //{
        //    try
        //    {
        //        var entities = await _gaPersonaleService.GetViewGaDipendentiSchedeConsegnaAsync(id);
        //        var scheda = entities.Data.FirstOrDefault();

        //        string path = @"Report/dipendenti_schede";
        //        string fileName = "dipendenti_schede.pdf";
        //        string table_content = "";

        //        foreach (var itm in entities.Data)
        //        {

        //            table_content += String.Format("<tr>" +
        //            "<td style='border: 1px solid #000;padding:5px;'>{0}</td>" +
        //            "<td style='border: 1px solid #000;padding:5px;text-align:center;'>{1}</td>" +
        //            "<td style='border: 1px solid #000;padding:5px;text-align:center;'>{2}</td>" +
        //            "</tr>", itm.Articolo, itm.Taglia, itm.Qta);
        //        }

        //        string htmlContent = "";

        //        htmlContent = DipendentiSchedeTemplateGenerator.GetHTMLString(
        //            scheda.Numero, scheda.Data.ToString("dd-MM-yyyy"), scheda.Sede, scheda.Dipendente, "", table_content);


        //        var response = _localFileService.UploadOnServerReport(fileName, path, htmlContent, "Scheda Consegna", "DipendentiSchede");
        //        return new ApiResponse(response, code.Status200OK);


        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiException(ex.Message);
        //    }
        //}

        //[HttpGet("ExportGaDipendentiRiepilogoConsegne")]
        //[ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        //[AutoWrapIgnore]
        //public IActionResult ExportGaDipendentiRiepilogoConsegne()
        //{

        //    try
        //    {
        //        var entities = _gaPersonaleService.GetViewGaDipendentiRiepilogoConsegneAsync().Result.Data;
        //        string title = "Riepilogo Consegne Dipendenti";
        //        string[] columns = { "Id", "Data", "Numero", "Dipendente", "Sede", "Articolo", "Taglia", "Qta" };
        //        byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "RIEPILOGO_CONSEGNE_DIPENDENTI", true, columns);

        //        return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
        //        {
        //            FileDownloadName = "Riepilogo_Consegne_Dipendenti.xlsx"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiException(ex.Message);
        //    }
        //}

        #endregion

        #endregion

        #region PersonaleSchedeConsegneDettagli
        [HttpGet("GetGaPersonaleSchedeConsegneDettagliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSchedeConsegneDettagliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleSchedeConsegneDettagliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleSchedeConsegneDettagliApiDto, PersonaleSchedeConsegneDettagliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleSchedaConsegnaDettaglioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleSchedaConsegnaDettaglioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleSchedaConsegnaDettaglioByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleSchedaConsegnaDettaglioApiDto, PersonaleSchedaConsegnaDettaglioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleSchedaConsegnaDettaglioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleSchedaConsegnaDettaglioAsync([FromBody] PersonaleSchedaConsegnaDettaglioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleSchedaConsegnaDettaglioDto, PersonaleSchedaConsegnaDettaglioApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleSchedaConsegnaDettaglioAsync(dto);

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

        [HttpPost("UpdateGaPersonaleSchedaConsegnaDettaglioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleSchedaConsegnaDettaglioAsync([FromBody] PersonaleSchedaConsegnaDettaglioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleSchedaConsegnaDettaglioDto, PersonaleSchedaConsegnaDettaglioApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleSchedaConsegnaDettaglioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleSchedaConsegnaDettaglioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleSchedaConsegnaDettaglioAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleSchedaConsegnaDettaglioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaPersonaleSchedaConsegnaDettaglioAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleSchedaConsegnaDettaglioAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaPersonaleService.ValidateGaPersonaleSchedaConsegnaDettaglioAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaPersonaleSchedaConsegnaDettaglioAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleSchedaConsegnaDettaglioAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaPersonaleService.ChangeStatusGaPersonaleSchedaConsegnaDettaglioAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        #endregion

        #endregion


        #region PersonaleArticoliModelli
        [HttpGet("GetGaPersonaleArticoliModelliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoliModelliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleArticoliModelliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleArticoliModelliApiDto, PersonaleArticoliModelliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleArticoloModelloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoloModelloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleArticoloModelloByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleArticoloModelloApiDto, PersonaleArticoloModelloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleArticoloModelloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleArticoloModelloAsync([FromBody] PersonaleArticoloModelloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloModelloDto, PersonaleArticoloModelloApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleArticoloModelloAsync(dto);

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

        [HttpPost("UpdateGaPersonaleArticoloModelloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleArticoloModelloAsync([FromBody] PersonaleArticoloModelloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloModelloDto, PersonaleArticoloModelloApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleArticoloModelloAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleArticoloModelloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleArticoloModelloAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleArticoloModelloAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleArticoloModelloAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleArticoloModelloAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleArticoloModelloAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleArticoloModelloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleArticoloModelloAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleArticoloModelloAsync(id);
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

        #region PersonaleArticoliTipologie
        [HttpGet("GetGaPersonaleArticoliTipologieAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoliTipologieAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleArticoliTipologieAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleArticoliTipologieApiDto, PersonaleArticoliTipologieDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleArticoloTipologiaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoloTipologiaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleArticoloTipologiaByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleArticoloTipologiaApiDto, PersonaleArticoloTipologiaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleArticoloTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleArticoloTipologiaAsync([FromBody] PersonaleArticoloTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloTipologiaDto, PersonaleArticoloTipologiaApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleArticoloTipologiaAsync(dto);

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

        [HttpPost("UpdateGaPersonaleArticoloTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleArticoloTipologiaAsync([FromBody] PersonaleArticoloTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloTipologiaDto, PersonaleArticoloTipologiaApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleArticoloTipologiaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleArticoloTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleArticoloTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleArticoloTipologiaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleArticoloTipologiaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleArticoloTipologiaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleArticoloTipologiaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleArticoloTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleArticoloTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleArticoloTipologiaAsync(id);
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

        #region PersonaleArticoliDpis
        [HttpGet("GetGaPersonaleArticoliDpisAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoliDpisAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleArticoliDpisAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleArticoliDpisApiDto, PersonaleArticoliDpisDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleArticoloDpiByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoloDpiByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleArticoloDpiByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleArticoloDpiApiDto, PersonaleArticoloDpiDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleArticoloDpiAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleArticoloDpiAsync([FromBody] PersonaleArticoloDpiApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloDpiDto, PersonaleArticoloDpiApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleArticoloDpiAsync(dto);

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

        [HttpPost("UpdateGaPersonaleArticoloDpiAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleArticoloDpiAsync([FromBody] PersonaleArticoloDpiApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloDpiDto, PersonaleArticoloDpiApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleArticoloDpiAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleArticoloDpiAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleArticoloDpiAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleArticoloDpiAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleArticoloDpiAsync/{id}/{descrizione}/{caratteristiche}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleArticoloDpiAsync(long id, string descrizione, string caratteristiche)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleArticoloDpiAsync(id, descrizione, caratteristiche);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleArticoloDpiAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleArticoloDpiAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleArticoloDpiAsync(id);
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

        #region PersonaleArticoli
        [HttpGet("GetGaPersonaleArticoliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleArticoliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PersonaleArticoliApiDto, PersonaleArticoliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPersonaleArticoloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleArticoloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPersonaleService.GetGaPersonaleArticoloByIdAsync(id);
                var apiDto = dto.ToApiDto<PersonaleArticoloApiDto, PersonaleArticoloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPersonaleArticoloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleArticoloAsync([FromBody] PersonaleArticoloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloDto, PersonaleArticoloApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleArticoloAsync(dto);

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

        [HttpPost("UpdateGaPersonaleArticoloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleArticoloAsync([FromBody] PersonaleArticoloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PersonaleArticoloDto, PersonaleArticoloApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleArticoloAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPersonaleArticoloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPersonaleArticoloAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.DeleteGaPersonaleArticoloAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPersonaleArticoloAsync/{id}/{personaleArticoloModelloId}/{personaleArticoloTipologiaId}/{personaleArticoloDpiId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPersonaleArticoloAsync(long id, long personaleArticoloModelloId, long personaleArticoloTipologiaId, long personaleArticoloDpiId)
        {
            try
            {
                var response = await _gaPersonaleService.ValidateGaPersonaleArticoloAsync(id, personaleArticoloModelloId, personaleArticoloTipologiaId, personaleArticoloDpiId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPersonaleArticoloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPersonaleArticoloAsync(long id)
        {
            try
            {
                var response = await _gaPersonaleService.ChangeStatusGaPersonaleArticoloAsync(id);
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
