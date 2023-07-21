using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Dispositivi;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Dispositivi;
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
    public class GaDispositiviController : Controller
    {
        private readonly IGaDispositiviService _gaDispositiviService;
        private readonly IGaPersonaleService _gaPersonaleService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaDispositiviController> _logger;
        private readonly IPrintService _printService;

        public GaDispositiviController(
            IGaDispositiviService gaDispositiviService,
            IGaPersonaleService gaPersonaleService,
            IFileService fileService,
            ILogger<GaDispositiviController> logger,
            IPrintService printService)
        {

            _gaDispositiviService = gaDispositiviService;
            _gaPersonaleService = gaPersonaleService;   
            _fileService = fileService;
            _logger = logger;
            _printService = printService;
        }


        #region DispositiviTipologie
        [HttpGet("GetGaDispositiviTipologieAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviTipologieAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviTipologieAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviTipologieApiDto, DispositiviTipologieDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviTipologiaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviTipologiaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviTipologiaByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviTipologiaApiDto, DispositiviTipologiaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviTipologiaAsync([FromBody] DispositiviTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviTipologiaDto, DispositiviTipologiaApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviTipologiaAsync(dto);

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

        [HttpPost("UpdateGaDispositiviTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviTipologiaAsync([FromBody] DispositiviTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviTipologiaDto, DispositiviTipologiaApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviTipologiaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviTipologiaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaDispositiviTipologiaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaDispositiviTipologiaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaDispositiviService.ValidateGaDispositiviTipologiaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaDispositiviTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviTipologiaAsync(id);
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

        #region DispositiviModelli
        [HttpGet("GetGaDispositiviModelliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviModelliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviModelliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviModelliApiDto, DispositiviModelliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviModelloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviModelloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviModelloByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviModelloApiDto, DispositiviModelloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviModelloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviModelloAsync([FromBody] DispositiviModelloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviModelloDto, DispositiviModelloApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviModelloAsync(dto);

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

        [HttpPost("UpdateGaDispositiviModelloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviModelloAsync([FromBody] DispositiviModelloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviModelloDto, DispositiviModelloApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviModelloAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviModelloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviModelloAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviModelloAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaDispositiviModelloAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaDispositiviModelloAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaDispositiviService.ValidateGaDispositiviModelloAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaDispositiviModelloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviModelloAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviModelloAsync(id);
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

        #region DispositiviMarche
        [HttpGet("GetGaDispositiviMarcheAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviMarcheAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviMarcheAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviMarcheApiDto, DispositiviMarcheDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviMarcaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviMarcaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviMarcaByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviMarcaApiDto, DispositiviMarcaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviMarcaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviMarcaAsync([FromBody] DispositiviMarcaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviMarcaDto, DispositiviMarcaApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviMarcaAsync(dto);

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

        [HttpPost("UpdateGaDispositiviMarcaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviMarcaAsync([FromBody] DispositiviMarcaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviMarcaDto, DispositiviMarcaApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviMarcaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviMarcaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviMarcaAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviMarcaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaDispositiviMarcaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaDispositiviMarcaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaDispositiviService.ValidateGaDispositiviMarcaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaDispositiviMarcaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviMarcaAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviMarcaAsync(id);
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

        #region DispositiviClassi
        [HttpGet("GetGaDispositiviClassiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviClassiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviClassiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviClassiApiDto, DispositiviClassiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviClasseByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviClasseByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviClasseByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviClasseApiDto, DispositiviClasseDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviClasseAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviClasseAsync([FromBody] DispositiviClasseApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviClasseDto, DispositiviClasseApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviClasseAsync(dto);

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

        [HttpPost("UpdateGaDispositiviClasseAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviClasseAsync([FromBody] DispositiviClasseApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviClasseDto, DispositiviClasseApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviClasseAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviClasseAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviClasseAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviClasseAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaDispositiviClasseAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaDispositiviClasseAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaDispositiviService.ValidateGaDispositiviClasseAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaDispositiviClasseAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviClasseAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviClasseAsync(id);
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

        #region DispositiviCategorie
        [HttpGet("GetGaDispositiviCategorieAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviCategorieAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviCategorieAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviCategorieApiDto, DispositiviCategorieDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviCategoriaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviCategoriaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviCategoriaByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviCategoriaApiDto, DispositiviCategoriaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviCategoriaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviCategoriaAsync([FromBody] DispositiviCategoriaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviCategoriaDto, DispositiviCategoriaApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviCategoriaAsync(dto);

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

        [HttpPost("UpdateGaDispositiviCategoriaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviCategoriaAsync([FromBody] DispositiviCategoriaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviCategoriaDto, DispositiviCategoriaApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviCategoriaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviCategoriaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviCategoriaAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviCategoriaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaDispositiviCategoriaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaDispositiviCategoriaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaDispositiviService.ValidateGaDispositiviCategoriaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaDispositiviCategoriaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviCategoriaAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviCategoriaAsync(id);
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

        #region DispositiviItems
        [HttpGet("GetGaDispositiviItemsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviItemsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviItemsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviItemsApiDto, DispositiviItemsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviItemByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviItemByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviItemByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviItemApiDto, DispositiviItemDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviItemAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviItemAsync([FromBody] DispositiviItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviItemDto, DispositiviItemApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviItemAsync(dto);

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

        [HttpPost("UpdateGaDispositiviItemAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviItemAsync([FromBody] DispositiviItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviItemDto, DispositiviItemApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviItemAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviItemAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviItemAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviItemAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaDispositiviItemAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaDispositiviItemAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaDispositiviService.ValidateGaDispositiviItemAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaDispositiviItemAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviItemAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviItemAsync(id);
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
        [HttpGet("GetViewGaDispositiviItemsAsync/{page}/{pageSize}")]
        public async Task<ApiResponse> GetViewGaDispositiviItemsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var entities = await _gaDispositiviService.GetViewGaDispositiviItemsAsync(page, pageSize);
                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message); throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }
        #endregion

        #endregion

        #region DispositiviStocks
        [HttpGet("GetGaDispositiviStocksAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviStocksAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviStocksAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviStocksApiDto, DispositiviStocksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviStockByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviStockByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviStockByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviStockApiDto, DispositiviStockDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviStockAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviStockAsync([FromBody] DispositiviStockApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviStockDto, DispositiviStockApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviStockAsync(dto);

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

        [HttpPost("UpdateGaDispositiviStockAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviStockAsync([FromBody] DispositiviStockApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviStockDto, DispositiviStockApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviStockAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviStockAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviStockAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviStockAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("DuplicateGaDispositiviStockAsync/{id}")]
        public async Task<ApiResponse> DuplicateGaDispositiviStockAsync(long id)
        {
            try
            {
                var entities = await _gaDispositiviService.DuplicateGaDispositiviStockAsync(id);
                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("ChangeStatusGaDispositiviStockAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviStockAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviStockAsync(id);
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
        [HttpGet("GetViewGaDispositiviStocksAsync/{all}")]
        public async Task<ApiResponse> GetViewGaDispositiviStocksAsync(bool all = true)
        {
            try
            {
                var entities = await _gaDispositiviService.GetViewGaDispositiviStocksAsync(all);
                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("GetViewGaDispositiviStocksListAsync")]
        public async Task<ApiResponse> GetViewGaDispositiviStocksListAsync()
        {
            try
            {
                var entities = await _gaDispositiviService.GetViewGaDispositiviStocksListAsync();
                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
        #endregion

        #endregion

        #region DispositiviOnDipendenti
        [HttpGet("GetGaDispositiviOnDipendentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviOnDipendentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviOnDipendentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DispositiviOnDipendentiApiDto, DispositiviOnDipendentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviOnDipendenteByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviOnDipendenteByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviOnDipendenteByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviOnDipendenteApiDto, DispositiviOnDipendenteDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviOnDipendenteAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviOnDipendenteAsync([FromBody] DispositiviOnDipendentiApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                long response = 0;
                var dtos = apiDto.ToDto<DispositiviOnDipendentiDto, DispositiviOnDipendentiApiDto>();
                foreach (var dto in dtos.Data)
                {
                    response = await _gaDispositiviService.AddGaDispositiviOnDipendenteAsync(dto);
                    await _gaDispositiviService.SetGaDispositiviStockNonDisponibileAsync(dto.DispositiviStockId);
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

        //[HttpPost("AddGaDispositiviOnDipendenteAsync")]
        //public async Task<ActionResult<ApiResponse>> AddGaDispositiviOnDipendenteAsync([FromBody] DispositiviOnDipendenteApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }

        //        var dto = new DispositiviOnDipendenteDto();
        //        dto.Id = 0;
        //        dto.Disabled = false;
        //        dto.PersonaleDipendenteId = apiDto.PersonaleDipendenteId;

        //        var response = await _gaDispositiviService.AddGaDispositiviOnDipendenteAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (ApiProblemDetailsException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex);
        //    }

        //}

        [HttpPost("UpdateGaDispositiviOnDipendenteAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviOnDipendenteAsync([FromBody] DispositiviOnDipendenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DispositiviOnDipendenteDto, DispositiviOnDipendenteApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviOnDipendenteAsync(dto);
                if (dto.DataRitiro != null)
                {
                    await _gaDispositiviService.SetGaDispositiviStockDisponibileAsync(dto.DispositiviStockId);
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaDispositiviOnDipendenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviOnDipendenteAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviOnDipendenteAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions

        [HttpGet("ChangeStatusGaDispositiviOnDipendenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaDispositiviOnDipendenteAsync(long id)
        {
            try
            {
                var response = await _gaDispositiviService.ChangeStatusGaDispositiviOnDipendenteAsync(id);
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
        [HttpGet("GetViewGaDispositiviOnDipendentiAsync/{page}/{pageSize}")]
        public async Task<ApiResponse> GetViewGaDispositiviOnDipendentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var entities = await _gaDispositiviService.GetViewGaDispositiviOnDipendentiAsync(page, pageSize);
                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("GetViewGaDispositiviOnDipendentiByDipendenteIdAsync/{personaleDipendenteId}")]
        public async Task<ApiResponse> GetViewGaDispositiviOnDipendentiByDipendenteIdAsync(long personaleDipendenteId)
        {
            try
            {
                var entities = await _gaDispositiviService.GetViewGaDispositiviOnDipendentiByDipendenteIdAsync(personaleDipendenteId);
                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        #endregion

        #endregion

        #region DispositiviOnModuli


        #endregion

        #region DispositiviModuli

        [HttpGet("GetGaDispositiviModuliByDipendenteIdAsync/{dipendenteId}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviModuliByDipendenteIdAsync(long dipendenteId)
        {
            try
            {
                var dtos = await _gaDispositiviService.GetGaDispositiviModuliByDipendenteIdAsync(dipendenteId);
                var apiDtos = dtos.ToApiDto<DispositiviModuliApiDto, DispositiviModuliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaDispositiviModuloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaDispositiviModuloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaDispositiviService.GetGaDispositiviModuloByIdAsync(id);
                var apiDto = dto.ToApiDto<DispositiviModuloApiDto, DispositiviModuloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaDispositiviModuloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaDispositiviModuloAsync([FromForm] DispositiviModuloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Dispositivi";
                var dto = apiDto.ToDto<DispositiviModuloDto, DispositiviModuloApiDto>();
                var response = await _gaDispositiviService.AddGaDispositiviModuloAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaDispositiviService.UpdateGaDispositiviModuloAsync(dto);
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

        [HttpPost("UpdateGaDispositiviModuloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaDispositiviModuloAsync([FromForm] DispositiviModuloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Dispositivi";
                var dto = apiDto.ToDto<DispositiviModuloDto, DispositiviModuloApiDto>();
                var response = await _gaDispositiviService.UpdateGaDispositiviModuloAsync(dto);
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
                        var updateFileResponse = await _gaDispositiviService.UpdateGaDispositiviModuloAsync(dto);
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
                    var updateFileResponse = await _gaDispositiviService.UpdateGaDispositiviModuloAsync(dto);

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

        [HttpDelete("DeleteGaDispositiviModuloAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaDispositiviModuloAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaDispositiviService.DeleteGaDispositiviModuloAsync(id);
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
        [HttpGet("PrintGaDispositiviModuloById/{id}")]
        public async Task<ActionResult<ApiResponse>> PrintGaDispositiviModuloById(long id)
        {
            try
            {
                var view = await _gaDispositiviService.GetViewGaDispositiviOnModuloByIdAsync(id);
                var modulo = await _gaDispositiviService.GetGaDispositiviModuloByIdAsync(id);
                var dipendente = await _gaPersonaleService.GetViewGaPersonaleDipendenteByIdAsync(modulo.PersonaleDipendenteId);
                DispositiviModuloTemplateDto dto = new DispositiviModuloTemplateDto();
                dto.FileName = "DispositiviModulo.pdf";
                dto.FilePath = @"Print/Dispositivi";
                dto.Title = "Dispositivi Consegnati";
                dto.Css = "DispositiviModulo";

                dto.Nominativo = view.Data.FirstOrDefault().Nominativo;
                dto.Data = view.Data.FirstOrDefault().Data.ToString("dd/MM/yyyy");
                //dto.Note = view.Data.FirstOrDefault().Note;
                dto.Dispositivi = new List<dynamic>();
                foreach (var itm in view.Data)
                {
                    dto.Dispositivi.Add(itm);
                }

                var response = await _printService.Print("DispositiviModulo", dto);
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