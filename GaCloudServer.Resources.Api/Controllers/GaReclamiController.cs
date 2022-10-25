using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Reclami;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Reclami;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Report.ReclamiRegistro;
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
    public class GaReclamiController : Controller
    {
        private readonly IGaReclamiService _gaReclamiService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaReclamiController> _logger;

        public GaReclamiController(
            IGaReclamiService gaReclamiService
            , IFileService fileService
            , ILogger<GaReclamiController> logger)
        {

            _gaReclamiService = gaReclamiService;
            _fileService = fileService;
            _logger = logger;
        }

        #region ReclamiMittenti
        [HttpGet("GetGaReclamiMittentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiMittentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaReclamiService.GetGaReclamiMittentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ReclamiMittentiApiDto, ReclamiMittentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiMittenteByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiMittenteByIdAsync(long id)
        {
            try
            {
                var dto = await _gaReclamiService.GetGaReclamiMittenteByIdAsync(id);
                var apiDto = dto.ToApiDto<ReclamiMittenteApiDto, ReclamiMittenteDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaReclamiMittenteAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaReclamiMittenteAsync([FromBody] ReclamiMittenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiMittenteDto, ReclamiMittenteApiDto>();
                var response = await _gaReclamiService.AddGaReclamiMittenteAsync(dto);

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

        [HttpPost("UpdateGaReclamiMittenteAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaReclamiMittenteAsync([FromBody] ReclamiMittenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiMittenteDto, ReclamiMittenteApiDto>();
                var response = await _gaReclamiService.UpdateGaReclamiMittenteAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaReclamiMittenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaReclamiMittenteAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.DeleteGaReclamiMittenteAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaReclamiMittenteAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaReclamiMittenteAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaReclamiService.ValidateGaReclamiMittenteAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaReclamiMittenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaReclamiMittenteAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.ChangeStatusGaReclamiMittenteAsync(id);
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

        #region ReclamiStati
        [HttpGet("GetGaReclamiStatiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiStatiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaReclamiService.GetGaReclamiStatiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ReclamiStatiApiDto, ReclamiStatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiStatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiStatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaReclamiService.GetGaReclamiStatoByIdAsync(id);
                var apiDto = dto.ToApiDto<ReclamiStatoApiDto, ReclamiStatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaReclamiStatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaReclamiStatoAsync([FromBody] ReclamiStatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiStatoDto, ReclamiStatoApiDto>();
                var response = await _gaReclamiService.AddGaReclamiStatoAsync(dto);

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

        [HttpPost("UpdateGaReclamiStatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaReclamiStatoAsync([FromBody] ReclamiStatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiStatoDto, ReclamiStatoApiDto>();
                var response = await _gaReclamiService.UpdateGaReclamiStatoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaReclamiStatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaReclamiStatoAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.DeleteGaReclamiStatoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaReclamiStatoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaReclamiStatoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaReclamiService.ValidateGaReclamiStatoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaReclamiStatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaReclamiStatoAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.ChangeStatusGaReclamiStatoAsync(id);
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

        #region ReclamiTempiRisposte
        [HttpGet("GetGaReclamiTempiRisposteAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiTempiRisposteAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaReclamiService.GetGaReclamiTempiRisposteAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ReclamiTempiRisposteApiDto, ReclamiTempiRisposteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiTempoRispostaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiTempoRispostaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaReclamiService.GetGaReclamiTempoRispostaByIdAsync(id);
                var apiDto = dto.ToApiDto<ReclamiTempoRispostaApiDto, ReclamiTempoRispostaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaReclamiTempoRispostaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaReclamiTempoRispostaAsync([FromBody] ReclamiTempoRispostaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiTempoRispostaDto, ReclamiTempoRispostaApiDto>();
                var response = await _gaReclamiService.AddGaReclamiTempoRispostaAsync(dto);

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

        [HttpPost("UpdateGaReclamiTempoRispostaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaReclamiTempoRispostaAsync([FromBody] ReclamiTempoRispostaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiTempoRispostaDto, ReclamiTempoRispostaApiDto>();
                var response = await _gaReclamiService.UpdateGaReclamiTempoRispostaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaReclamiTempoRispostaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaReclamiTempoRispostaAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.DeleteGaReclamiTempoRispostaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaReclamiTempoRispostaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaReclamiTempoRispostaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaReclamiService.ValidateGaReclamiTempoRispostaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaReclamiTempoRispostaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaReclamiTempoRispostaAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.ChangeStatusGaReclamiTempoRispostaAsync(id);
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

        #region ReclamiTipiAzioni
        [HttpGet("GetGaReclamiTipiAzioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiTipiAzioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaReclamiService.GetGaReclamiTipiAzioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ReclamiTipiAzioniApiDto, ReclamiTipiAzioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiTipoAzioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiTipoAzioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaReclamiService.GetGaReclamiTipoAzioneByIdAsync(id);
                var apiDto = dto.ToApiDto<ReclamiTipoAzioneApiDto, ReclamiTipoAzioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaReclamiTipoAzioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaReclamiTipoAzioneAsync([FromBody] ReclamiTipoAzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiTipoAzioneDto, ReclamiTipoAzioneApiDto>();
                var response = await _gaReclamiService.AddGaReclamiTipoAzioneAsync(dto);

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

        [HttpPost("UpdateGaReclamiTipoAzioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaReclamiTipoAzioneAsync([FromBody] ReclamiTipoAzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiTipoAzioneDto, ReclamiTipoAzioneApiDto>();
                var response = await _gaReclamiService.UpdateGaReclamiTipoAzioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaReclamiTipoAzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaReclamiTipoAzioneAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.DeleteGaReclamiTipoAzioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaReclamiTipoAzioneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaReclamiTipoAzioneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaReclamiService.ValidateGaReclamiTipoAzioneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaReclamiTipoAzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaReclamiTipoAzioneAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.ChangeStatusGaReclamiTipoAzioneAsync(id);
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

        #region ReclamiTipiOrigini
        [HttpGet("GetGaReclamiTipiOriginiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiTipiOriginiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaReclamiService.GetGaReclamiTipiOriginiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ReclamiTipiOriginiApiDto, ReclamiTipiOriginiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiTipoOrigineByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiTipoOrigineByIdAsync(long id)
        {
            try
            {
                var dto = await _gaReclamiService.GetGaReclamiTipoOrigineByIdAsync(id);
                var apiDto = dto.ToApiDto<ReclamiTipoOrigineApiDto, ReclamiTipoOrigineDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaReclamiTipoOrigineAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaReclamiTipoOrigineAsync([FromBody] ReclamiTipoOrigineApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiTipoOrigineDto, ReclamiTipoOrigineApiDto>();
                var response = await _gaReclamiService.AddGaReclamiTipoOrigineAsync(dto);

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

        [HttpPost("UpdateGaReclamiTipoOrigineAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaReclamiTipoOrigineAsync([FromBody] ReclamiTipoOrigineApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiTipoOrigineDto, ReclamiTipoOrigineApiDto>();
                var response = await _gaReclamiService.UpdateGaReclamiTipoOrigineAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaReclamiTipoOrigineAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaReclamiTipoOrigineAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.DeleteGaReclamiTipoOrigineAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaReclamiTipoOrigineAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaReclamiTipoOrigineAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaReclamiService.ValidateGaReclamiTipoOrigineAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaReclamiTipoOrigineAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaReclamiTipoOrigineAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.ChangeStatusGaReclamiTipoOrigineAsync(id);
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

        #region ReclamiAzioni
        [HttpGet("GetGaReclamiAzioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiAzioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaReclamiService.GetGaReclamiAzioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ReclamiAzioniApiDto, ReclamiAzioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiAzioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiAzioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaReclamiService.GetGaReclamiAzioneByIdAsync(id);
                var apiDto = dto.ToApiDto<ReclamiAzioneApiDto, ReclamiAzioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaReclamiAzioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaReclamiAzioneAsync([FromBody] ReclamiAzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiAzioneDto, ReclamiAzioneApiDto>();
                var response = await _gaReclamiService.AddGaReclamiAzioneAsync(dto);

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

        [HttpPost("UpdateGaReclamiAzioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaReclamiAzioneAsync([FromBody] ReclamiAzioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiAzioneDto, ReclamiAzioneApiDto>();
                var response = await _gaReclamiService.UpdateGaReclamiAzioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaReclamiAzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaReclamiAzioneAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.DeleteGaReclamiAzioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaReclamiAzioneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaReclamiAzioneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaReclamiService.ValidateGaReclamiAzioneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaReclamiAzioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaReclamiAzioneAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.ChangeStatusGaReclamiAzioneAsync(id);
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
        [HttpGet("GetViewGaReclamiAzioniByReclamoIdAsync/{reclamoId}")]
        public async Task<ApiResponse> GetViewGaReclamiAzioniByReclamoIdAsync(long reclamoId)
        {
            var response = await _gaReclamiService.GetViewGaReclamiAzioniByReclamoIdAsync(reclamoId);
            return new ApiResponse(response);
        }
        #endregion

        #endregion

        #region ReclamiDocumenti
        [HttpGet("GetGaReclamiDocumentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiDocumentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaReclamiService.GetGaReclamiDocumentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ReclamiDocumentiApiDto, ReclamiDocumentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaReclamiDocumentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaReclamiService.GetGaReclamiDocumentoByIdAsync(id);
                var apiDto = dto.ToApiDto<ReclamiDocumentoApiDto, ReclamiDocumentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaReclamiDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaReclamiDocumentoAsync([FromBody] ReclamiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiDocumentoDto, ReclamiDocumentoApiDto>();
                var response = await _gaReclamiService.AddGaReclamiDocumentoAsync(dto);

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

        [HttpPost("UpdateGaReclamiDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaReclamiDocumentoAsync([FromBody] ReclamiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ReclamiDocumentoDto, ReclamiDocumentoApiDto>();
                var response = await _gaReclamiService.UpdateGaReclamiDocumentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaReclamiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaReclamiDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.DeleteGaReclamiDocumentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaReclamiDocumentoAsync/{id}/{oggetto}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaReclamiDocumentoAsync(long id, string oggetto)
        {
            try
            {
                var response = await _gaReclamiService.ValidateGaReclamiDocumentoAsync(id, oggetto);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaReclamiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaReclamiDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaReclamiService.ChangeStatusGaReclamiDocumentoAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaReclamiAnni")]
        public async Task<ApiResponse> GetGaReclamiAnni()
        {
            try
            {
                var response = await _gaReclamiService.GetGaReclamiAnni();
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
        [HttpGet("GetViewGaReclamiDocumentiAsync")]
        public async Task<ApiResponse> GetViewGaReclamiDocumentiAsync()
        {
            try
            {
                var view = await _gaReclamiService.GetViewGaReclamiDocumentiAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            };
        }

        [HttpGet("ExportGaReclamiDocumentiAsync")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public async Task<IActionResult> ExportGaReclamiDocumentiAsync()
        {

            try
            {
                var entities = await _gaReclamiService.ExportGaReclamiDocumentiAsync();
                string title = "Export Reclami";
                string[] columns = { "NumeroReclamo", "OrigineReclamo", "OrigineReclamoData","Mittente","Oggetto","RispostaEntroData","RispostaInviataData","RispostaDefinitivaData","Fondato",
                                "Infondato","Stato","Cantiere","Note"};
                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "EXPORT_RECLAMI", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Export_Reclami.xlsx"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        //[HttpGet("PrintGaReclamiRegistro/{anno}")]
        //public async Task<ApiResponse> PrintGaReclamiRegistro(int anno)
        //{
        //    try
        //    {
        //        var registro = await _gaReclamiService.GetGaReclamiRegistriAsync(anno);
        //        var registro_stampa = new List<ViewGaReclamiRegistri>();



        //        string path = @"Report/reclami";
        //        string fileName = "registro_reclami.pdf";

        //        foreach (var itm in registro)
        //        {
        //            itm.AzioniIntraprese = _gaReclamiService.CreateAzioni(itm.Id);
        //            registro_stampa.Add(itm);
        //        }


        //        string table_content = "";
        //        foreach (var itm in registro_stampa)
        //        {
        //            table_content += String.Format("<tr>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{0}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;min-width:90px;'>{1}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{2}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{3}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{4}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{5}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{10}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{6}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{7}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{8}</td>" +
        //                "<td style='border: 1px solid #000;padding:5px;'>{9}</td>" +
        //                "</tr>", itm.Numeratore, itm.Data.ToString("dd/MM/yyyy"), itm.Cliente, itm.Motivo,
        //                itm.RispostaEntro.ToString("dd/MM/yyyy"), itm.RispostaInviata != null ? itm.RispostaInviata.GetValueOrDefault().ToString("dd/MM/yyyy") : "/", itm.AzioniIntraprese, itm.Fondato ? "SI" : "NO", itm.Infondato, itm.Note, itm.RispostaDefinitiva != null ? itm.RispostaDefinitiva.GetValueOrDefault().ToString("dd/MM/yyyy") : "/");

        //        }


        //        string htmlContent = ReclamiRegistroTemplateGenerator.GetHTMLString(anno.ToString(), table_content);
        //        var response = _fileService.UploadOnServerReport(fileName, path, htmlContent, "Registro Reclami", "ReclamiRegistro", DinkToPdf.Orientation.Landscape);
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
    }
}
