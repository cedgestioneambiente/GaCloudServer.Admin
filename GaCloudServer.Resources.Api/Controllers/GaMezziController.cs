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

        #region MezziCantieri
        [HttpGet("GetGaMezziCantieriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziCantieriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaMezziService.GetGaMezziCantieriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<MezziCantieriApiDto, MezziCantieriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaMezziCantiereByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaMezziCantiereByIdAsync(long id)
        {
            try
            {
                var dto = await _gaMezziService.GetGaMezziCantiereByIdAsync(id);
                var apiDto = dto.ToApiDto<MezziCantiereApiDto, MezziCantiereDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaMezziCantiereAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaMezziCantiereAsync([FromBody] MezziCantiereApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziCantiereDto, MezziCantiereApiDto>();
                var response = await _gaMezziService.AddGaMezziCantiereAsync(dto);

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

        [HttpPost("UpdateGaMezziCantiereAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaMezziCantiereAsync([FromBody] MezziCantiereApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<MezziCantiereDto, MezziCantiereApiDto>();
                var response = await _gaMezziService.UpdateGaMezziCantiereAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaMezziCantiereAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaMezziCantiereAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.DeleteGaMezziCantiereAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaMezziCantiereAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaMezziCantiereAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaMezziService.ValidateGaMezziCantiereAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaMezziCantiereAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaMezziCantiereAsync(long id)
        {
            try
            {
                var response = await _gaMezziService.ChangeStatusGaMezziCantiereAsync(id);
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
    }
}