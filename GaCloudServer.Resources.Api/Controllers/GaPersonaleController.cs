using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Personale;
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
    public class GaPersonaleController : Controller
    {
        private readonly IGaPersonaleService _gaPersonaleService;
        private readonly ILogger<GaPersonaleController> _logger;
        private readonly IFileService _fileService;

        public GaPersonaleController(
            IGaPersonaleService gaPersonaleService,
            IFileService fileService
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
        [HttpGet("GetGaPersonaleDipendentiScadenzeByDipendenteIdAsync/{personaleDipendenteId}")]
        public async Task<ActionResult<ApiResponse>> GetGaPersonaleDipendentiScadenzeByDipendenteIdAsync(long personaleDipendenteId)
        {
            try
            {
                var dtos = await _gaPersonaleService.GetGaPersonaleDipendentiScadenzeByDipendenteIdAsync(personaleDipendenteId);
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
        public async Task<ActionResult<ApiResponse>> AddGaPersonaleDipendenteScadenzaAsync([FromForm] PersonaleDipendenteScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Personale/Dipendenti";
                var dto = apiDto.ToDto<PersonaleDipendenteScadenzaDto, PersonaleDipendenteScadenzaApiDto>();
                var response = await _gaPersonaleService.AddGaPersonaleDipendenteScadenzaAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleDipendenteScadenzaAsync(dto);
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

        [HttpPost("UpdateGaPersonaleDipendenteScadenzaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPersonaleDipendenteScadenzaAsync([FromForm] PersonaleDipendenteScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Personale/Dipendenti";
                var dto = apiDto.ToDto<PersonaleDipendenteScadenzaDto, PersonaleDipendenteScadenzaApiDto>();
                var response = await _gaPersonaleService.UpdateGaPersonaleDipendenteScadenzaAsync(dto);
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
                        var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleDipendenteScadenzaAsync(dto);
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
                    var updateFileResponse = await _gaPersonaleService.UpdateGaPersonaleDipendenteScadenzaAsync(dto);

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

        #region Views
        [HttpGet("GetViewGaPersonaleDipendentiScadenzeByDipendenteIdAsync/{dipendenteId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPersonaleDipendentiScadenzeByDipendenteIdAsync(long dipendenteId)
        {
            try
            {
                var view = await _gaPersonaleService.GetViewGaPersonaleDipendentiScadenzeByDipendenteIdAsync(dipendenteId);
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
