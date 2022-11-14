using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Presenze;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Resources;
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
    public class GaPresenzeController : Controller
    {
        private readonly IGaPresenzeService _gaPresenzeService;
        private readonly ILogger<GaPresenzeController> _logger;

        public GaPresenzeController(
            IGaPresenzeService gaPresenzeService
            , ILogger<GaPresenzeController> logger)
        {

            _gaPresenzeService = gaPresenzeService;
            _logger = logger;
        }

        #region PresenzeStatiRichieste
        [HttpGet("GetGaPresenzeStatiRichiesteAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeStatiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeStatiRichiesteAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeStatiRichiesteApiDto, PresenzeStatiRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeStatoRichiestaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeStatoRichiestaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeStatoRichiestaByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeStatoRichiestaApiDto, PresenzeStatoRichiestaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeStatoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeStatoRichiestaAsync([FromBody] PresenzeStatoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeStatoRichiestaDto, PresenzeStatoRichiestaApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeStatoRichiestaAsync(dto);

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

        [HttpPost("UpdateGaPresenzeStatoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeStatoRichiestaAsync([FromBody] PresenzeStatoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeStatoRichiestaDto, PresenzeStatoRichiestaApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeStatoRichiestaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeStatoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeStatoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeStatoRichiestaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeStatoRichiestaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeStatoRichiestaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeStatoRichiestaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeStatoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeStatoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeStatoRichiestaAsync(id);
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

        #region PresenzeRichieste
        [HttpGet("GetGaPresenzeRichiesteAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeRichiesteAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeRichiesteAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeRichiesteApiDto, PresenzeRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeRichiestaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeRichiestaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeRichiestaByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeRichiestaApiDto, PresenzeRichiestaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeRichiestaAsync([FromBody] PresenzeRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);//apiDto.DataInizio.ToUniversalTime()
                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);

                var dto = apiDto.ToDto<PresenzeRichiestaDto, PresenzeRichiestaApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeRichiestaAsync(dto);

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

        [HttpPost("UpdateGaPresenzeRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeRichiestaAsync([FromBody] PresenzeRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);

                var dto = apiDto.ToDto<PresenzeRichiestaDto, PresenzeRichiestaApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeRichiestaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeRichiestaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions

        [HttpGet("ChangeStatusGaPresenzeRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeRichiestaAsync(id);
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

        #region PresenzeTipiOre
        [HttpGet("GetGaPresenzeTipiOreAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeTipiOreAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeTipiOreAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeTipiOreApiDto, PresenzeTipiOreDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeTipoOraByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeTipoOraByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeTipoOraByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeTipoOraApiDto, PresenzeTipoOraDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeTipoOraAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeTipoOraAsync([FromBody] PresenzeTipoOraApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeTipoOraDto, PresenzeTipoOraApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeTipoOraAsync(dto);

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

        [HttpPost("UpdateGaPresenzeTipoOraAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeTipoOraAsync([FromBody] PresenzeTipoOraApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeTipoOraDto, PresenzeTipoOraApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeTipoOraAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeTipoOraAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeTipoOraAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeTipoOraAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeTipoOraAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeTipoOraAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeTipoOraAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeTipoOraAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeTipoOraAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeTipoOraAsync(id);
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

        #region PresenzeResponsabili
        [HttpGet("GetGaPresenzeResponsabiliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeResponsabiliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeResponsabiliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeResponsabiliApiDto, PresenzeResponsabiliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeResponsabileByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeResponsabileByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeResponsabileByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeResponsabileApiDto, PresenzeResponsabileDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeResponsabileAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeResponsabileAsync([FromBody] PresenzeResponsabileApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeResponsabileDto, PresenzeResponsabileApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeResponsabileAsync(dto);

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

        [HttpPost("UpdateGaPresenzeResponsabileAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeResponsabileAsync([FromBody] PresenzeResponsabileApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeResponsabileDto, PresenzeResponsabileApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeResponsabileAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeResponsabileAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeResponsabileAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeResponsabileAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeResponsabileAsync/{id}/{personaleDipendenteId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeResponsabileAsync(long id, long personaleDipendenteId)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeResponsabileAsync(id, personaleDipendenteId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeResponsabileAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeResponsabileAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeResponsabileAsync(id);
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

        #region PresenzeResponsabiliOnSettori

        [HttpPost("UpdateGaPresenzeResponsabileOnSettoreAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeResponsabileOnSettoreAsync([FromBody] PresenzeResponsabileOnSettoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeResponsabileOnSettoreDto, PresenzeResponsabileOnSettoreApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeResponsabileOnSettoreAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        #endregion

        #region PresenzeProfili
        [HttpGet("GetGaPresenzeProfiliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeProfiliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeProfiliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeProfiliApiDto, PresenzeProfiliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeProfiloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeProfiloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeProfiloByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeProfiloApiDto, PresenzeProfiloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeProfiloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeProfiloAsync([FromBody] PresenzeProfiloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeProfiloDto, PresenzeProfiloApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeProfiloAsync(dto);

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

        [HttpPost("UpdateGaPresenzeProfiloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeProfiloAsync([FromBody] PresenzeProfiloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeProfiloDto, PresenzeProfiloApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeProfiloAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeProfiloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeProfiloAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeProfiloAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeProfiloAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeProfiloAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeProfiloAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeProfiloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeProfiloAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeProfiloAsync(id);
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
