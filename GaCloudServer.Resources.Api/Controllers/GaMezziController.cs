using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Mezzi;
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
    public class GaMezziController : Controller
    {
        private readonly IGaMezziService _gaMezziService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaMezziController> _logger;

        public GaMezziController(
            IGaMezziService gaMezziService
            ,IFileService fileService
            ,ILogger<GaMezziController> logger)
        {

            _gaMezziService = gaMezziService;
            _fileService = fileService;
            _logger = logger;
        }


        #region MezziAlimentazioni
        [HttpGet("GetGaMezziAlimentazioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziAlimentazioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziAlimentazioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziAlimentazioniApiDto, MezziAlimentazioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetGaMezziAlimentazioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziAlimentazioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziAlimentazioneByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziAlimentazioneApiDto, MezziAlimentazioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziAlimentazioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziAlimentazioneAsync([FromBody]MezziAlimentazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziAlimentazioneDto, MezziAlimentazioneApiDto>();
                var response = await _gaMezziService.AddGaMezziAlimentazioneAsync(dto);

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

        [HttpPost("UpdateGaMezziAlimentazioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziAlimentazioneAsync([FromBody] MezziAlimentazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziAlimentazioneDto, MezziAlimentazioneApiDto>();
                var response = await _gaMezziService.UpdateGaMezziAlimentazioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziAlimentazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziAlimentazioneAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziAlimentazioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziAlimentazioneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziAlimentazioneAsync(long id,string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziAlimentazioneAsync(id,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziAlimentazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziAlimentazioneAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziAlimentazioneAsync(id);
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

        #region MezziClassi
        [HttpGet("GetGaMezziClassiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziClassiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziClassiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziClassiApiDto, MezziClassiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziClasseByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziClasseByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziClasseByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziClasseApiDto, MezziClasseDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziClasseAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziClasseAsync([FromBody] MezziClasseApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziClasseDto, MezziClasseApiDto>();
                var response = await _gaMezziService.AddGaMezziClasseAsync(dto);

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

        [HttpPost("UpdateGaMezziClasseAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziClasseAsync([FromBody] MezziClasseApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziClasseDto, MezziClasseApiDto>();
                var response = await _gaMezziService.UpdateGaMezziClasseAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziClasseAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziClasseAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziClasseAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziClasseAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziClasseAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziClasseAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziClasseAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziClasseAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziClasseAsync(id);
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

        #region MezziPatenti
        [HttpGet("GetGaMezziPatentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziPatentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziPatentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziPatentiApiDto, MezziPatentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziPatenteByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziPatenteByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziPatenteByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziPatenteApiDto, MezziPatenteDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziPatenteAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziPatenteAsync([FromBody] MezziPatenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziPatenteDto, MezziPatenteApiDto>();
                var response = await _gaMezziService.AddGaMezziPatenteAsync(dto);

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

        [HttpPost("UpdateGaMezziPatenteAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziPatenteAsync([FromBody] MezziPatenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziPatenteDto, MezziPatenteApiDto>();
                var response = await _gaMezziService.UpdateGaMezziPatenteAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziPatenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziPatenteAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziPatenteAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziPatenteAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziPatenteAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziPatenteAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziPatenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziPatenteAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziPatenteAsync(id);
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

        #region MezziPeriodiScadenze
        [HttpGet("GetGaMezziPeriodiScadenzeAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziPeriodiScadenzeAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziPeriodiScadenzeAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziPeriodiScadenzeApiDto, MezziPeriodiScadenzeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziPeriodoScadenzaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziPeriodoScadenzaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziPeriodoScadenzaByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziPeriodoScadenzaApiDto, MezziPeriodoScadenzaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziPeriodoScadenzaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziPeriodoScadenzaAsync([FromBody] MezziPeriodoScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziPeriodoScadenzaDto, MezziPeriodoScadenzaApiDto>();
                var response = await _gaMezziService.AddGaMezziPeriodoScadenzaAsync(dto);

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

        [HttpPost("UpdateGaMezziPeriodoScadenzaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziPeriodoScadenzaAsync([FromBody] MezziPeriodoScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziPeriodoScadenzaDto, MezziPeriodoScadenzaApiDto>();
                var response = await _gaMezziService.UpdateGaMezziPeriodoScadenzaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziPeriodoScadenzaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziPeriodoScadenzaAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziPeriodoScadenzaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziPeriodoScadenzaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziPeriodoScadenzaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziPeriodoScadenzaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziPeriodoScadenzaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziPeriodoScadenzaAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziPeriodoScadenzaAsync(id);
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

        #region MezziProprietari
        [HttpGet("GetGaMezziProprietariAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziProprietariAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziProprietariAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziProprietariApiDto, MezziProprietariDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetGaMezziProprietarioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziProprietarioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziProprietarioByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziProprietarioApiDto, MezziProprietarioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziProprietarioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziProprietarioAsync([FromBody]MezziProprietarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziProprietarioDto, MezziProprietarioApiDto>();
                var response = await _gaMezziService.AddGaMezziProprietarioAsync(dto);

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

        [HttpPost("UpdateGaMezziProprietarioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziProprietarioAsync([FromBody] MezziProprietarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziProprietarioDto, MezziProprietarioApiDto>();
                var response = await _gaMezziService.UpdateGaMezziProprietarioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziProprietarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziProprietarioAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziProprietarioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziProprietarioAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziProprietarioAsync(long id,string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziProprietarioAsync(id,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziProprietarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziProprietarioAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziProprietarioAsync(id);
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

        #region MezziScadenzeTipi
        [HttpGet("GetGaMezziScadenzeTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziScadenzeTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziScadenzeTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziScadenzeTipiApiDto, MezziScadenzeTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziScadenzaTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziScadenzaTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziScadenzaTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziScadenzaTipoApiDto, MezziScadenzaTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziScadenzaTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziScadenzaTipoAsync([FromBody] MezziScadenzaTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziScadenzaTipoDto, MezziScadenzaTipoApiDto>();
                var response = await _gaMezziService.AddGaMezziScadenzaTipoAsync(dto);

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

        [HttpPost("UpdateGaMezziScadenzaTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziScadenzaTipoAsync([FromBody] MezziScadenzaTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziScadenzaTipoDto, MezziScadenzaTipoApiDto>();
                var response = await _gaMezziService.UpdateGaMezziScadenzaTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziScadenzaTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziScadenzaTipoAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziScadenzaTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziScadenzaTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziScadenzaTipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziScadenzaTipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziScadenzaTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziScadenzaTipoAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziScadenzaTipoAsync(id);
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

        #region MezziTipi
        [HttpGet("GetGaMezziTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziTipiApiDto, MezziTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziTipoApiDto, MezziTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziTipoAsync([FromBody] MezziTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziTipoDto, MezziTipoApiDto>();
                var response = await _gaMezziService.AddGaMezziTipoAsync(dto);

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

        [HttpPost("UpdateGaMezziTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziTipoAsync([FromBody] MezziTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziTipoDto, MezziTipoApiDto>();
                var response = await _gaMezziService.UpdateGaMezziTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziTipoAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziTipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziTipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziTipoAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziTipoAsync(id);
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

        #region MezziVeicoli
        [HttpGet("GetGaMezziVeicoliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziVeicoliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziVeicoliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziVeicoliApiDto, MezziVeicoliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziVeicoloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziVeicoloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziVeicoloByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziVeicoloApiDto, MezziVeicoloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziVeicoloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziVeicoloAsync([FromBody] MezziVeicoloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziVeicoloDto, MezziVeicoloApiDto>();
                var response = await _gaMezziService.AddGaMezziVeicoloAsync(dto);

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

        [HttpPost("UpdateGaMezziVeicoloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziVeicoloAsync([FromBody] MezziVeicoloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziVeicoloDto, MezziVeicoloApiDto>();
                var response = await _gaMezziService.UpdateGaMezziVeicoloAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziVeicoloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziVeicoloAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziVeicoloAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziVeicoloAsync/{id}/{targa}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziVeicoloAsync(long id, string targa)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziVeicoloAsync(id, targa);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziVeicoloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziVeicoloAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziVeicoloAsync(id);
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
        [HttpGet("GetViewGaMezziVeicoliAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaMezziVeicoliAsync(bool all = true)
        {
            try
            {
                var view = await _gaMezziService.GetViewGaMezziVeicoliAsync(all);
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

        #region MezziScadenze
        [HttpGet("GetGaMezziScadenzeByVeicoloIdAsync/{mezziVeicoloId}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziScadenzeByVeicoloIdAsync(long mezziVeicoloId)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziScadenzeByVeicoloIdAsync(mezziVeicoloId);
                var apiDtos = dtos.ToApiDto<MezziScadenzeApiDto, MezziScadenzeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziScadenzaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziScadenzaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziScadenzaByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziScadenzaApiDto, MezziScadenzaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziScadenzaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziScadenzaAsync([FromForm] MezziScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Mezzi/Scadenze";
                var dto = apiDto.ToDto<MezziScadenzaDto, MezziScadenzaApiDto>();
                var response = await _gaMezziService.AddGaMezziScadenzaAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaMezziService.UpdateGaMezziScadenzaAsync(dto);
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

        [HttpPost("UpdateGaMezziScadenzaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziScadenzaAsync([FromForm] MezziScadenzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Mezzi/Scadenze";
                var dto = apiDto.ToDto<MezziScadenzaDto, MezziScadenzaApiDto>();
                var response = await _gaMezziService.UpdateGaMezziScadenzaAsync(dto);
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
                        var updateFileResponse = await _gaMezziService.UpdateGaMezziScadenzaAsync(dto);
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
                    var updateFileResponse = await _gaMezziService.UpdateGaMezziScadenzaAsync(dto);

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

        [HttpDelete("DeleteGaMezziScadenzaAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziScadenzaAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziScadenzaAsync(id);
                if (response && fileId != null && fileId != "null" && fileId != "")
                {
                    var deleteResponse = await _fileService.Remove(fileId);
                    if (deleteResponse)
                    {
                        return new ApiResponse("DeletedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("DeletedErrorFile", response, code.Status206PartialContent);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions

        [HttpGet("ChangeStatusGaMezziScadenzaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziScadenzaAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziScadenzaAsync(id);
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
        [HttpGet("GetViewGaMezziScadenzeAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaMezziScadenzeAsync(bool all=false)
        {
            try
            {
                var view = await _gaMezziService.GetViewGaMezziScadenzeAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaMezziScadenzeByVeicoloIdAsync/{mezziVeicoloId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaMezziScadenzeByVeicoloIdAsync(long mezziVeicoloId)
        {
            try
            {
                var view = await _gaMezziService.GetViewGaMezziScadenzeByVeicoloIdAsync(mezziVeicoloId);
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

        #region MezziDocumenti
        [HttpGet("GetGaMezziDocumentiByVeicoloIdAsync/{mezziVeicoloId}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziDocumentiByVeicoloIdAsync(long mezziVeicoloId)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziDocumentiByVeicoloIdAsync(mezziVeicoloId);
                var apiDtos = dtos.ToApiDto<MezziDocumentiApiDto, MezziDocumentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziDocumentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziDocumentoByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziDocumentoApiDto, MezziDocumentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziDocumentoAsync([FromForm] MezziDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Mezzi";
                var dto = apiDto.ToDto<MezziDocumentoDto, MezziDocumentoApiDto>();
                var response = await _gaMezziService.AddGaMezziDocumentoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaMezziService.UpdateGaMezziDocumentoAsync(dto);
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

        [HttpPost("UpdateGaMezziDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziDocumentoAsync([FromForm] MezziDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Mezzi";
                var dto = apiDto.ToDto<MezziDocumentoDto, MezziDocumentoApiDto>();
                var response = await _gaMezziService.UpdateGaMezziDocumentoAsync(dto);
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
                        var updateFileResponse = await _gaMezziService.UpdateGaMezziDocumentoAsync(dto);
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
                    var updateFileResponse = await _gaMezziService.UpdateGaMezziDocumentoAsync(dto);

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

        [HttpDelete("DeleteGaMezziDocumentoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziDocumentoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziDocumentoAsync(id);
                if (response && fileId != null && fileId != "null" && fileId != "")
                {
                    var deleteResponse = await _fileService.Remove(fileId);
                    if (deleteResponse)
                    {
                        return new ApiResponse("DeletedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("DeletedErrorFile", response, code.Status206PartialContent);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions

        [HttpGet("ChangeStatusGaMezziDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziDocumentoAsync(id);
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
        [HttpGet("GetViewGaMezziDocumentiByVeicoloIdAsync/{mezziVeicoloId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaMezziDocumentiByVeicoloIdAsync(long mezziVeicoloId)
        {
            try
            {
                var view = await _gaMezziService.GetViewGaMezziDocumentiByVeicoloIdAsync(mezziVeicoloId);
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