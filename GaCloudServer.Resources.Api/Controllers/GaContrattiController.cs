using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Contratti;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Models;
using GaCloudServer.Resources.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    public class GaContrattiController : Controller
    {
        private readonly IGaContrattiService _gaContrattiService;
        private readonly IApiErrorResources _errorResources;
        private readonly ILogger<GaContrattiController> _logger;

        public GaContrattiController(
                    IGaContrattiService gaContrattiService
                    ,ILogger<GaContrattiController> logger)
        {

            _gaContrattiService = gaContrattiService;
            _logger = logger;
        }

        #region GaContrattiPermessi
        [HttpGet("GetGaContrattiPermessiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiPermessiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiPermessiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiPermessiApiDto, ContrattiPermessiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetGaContrattiPermessoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiPermessoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiPermessoByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiPermessoApiDto, ContrattiPermessoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiPermessoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiPermessoAsync([FromBody] ContrattiPermessoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiPermessoDto, ContrattiPermessoApiDto>();
                var response = await _gaContrattiService.AddGaContrattiPermessoAsync(dto);

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

        [HttpPost("UpdateGaContrattiPermessoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiPermessoAsync([FromBody] ContrattiPermessoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiPermessoDto, ContrattiPermessoApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiPermessoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContrattiPermessoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiPermessoAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiPermessoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContrattiPermessoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContrattiPermessoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContrattiService.ValidateGaContrattiPermessoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContrattiPermessoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiPermessoAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiPermessoAsync(id);
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

        #region GaContrattiServizi
        [HttpGet("GetGaContrattiServiziAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiServiziAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiServiziAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiServiziApiDto, ContrattiServiziDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContrattiServizioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiServizioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiServizioByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiServizioApiDto, ContrattiServizioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiServizioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiServizioAsync([FromBody] ContrattiServizioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiServizioDto, ContrattiServizioApiDto>();
                var response = await _gaContrattiService.AddGaContrattiServizioAsync(dto);

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

        [HttpPost("UpdateGaContrattiServizioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiServizioAsync([FromBody] ContrattiServizioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiServizioDto, ContrattiServizioApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiServizioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContrattiServizioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiServizioAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiServizioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContrattiServizioAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContrattiServizioAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContrattiService.ValidateGaContrattiServizioAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContrattiServizioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiServizioAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiServizioAsync(id);
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

        #region GaContrattiTipologie
        [HttpGet("GetGaContrattiTipologieAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiTipologieAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiTipologieAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiTipologieApiDto, ContrattiTipologieDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContrattiTipologiaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiTipologiaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiTipologiaByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiTipologiaApiDto, ContrattiTipologiaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiTipologiaAsync([FromBody] ContrattiTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiTipologiaDto, ContrattiTipologiaApiDto>();
                var response = await _gaContrattiService.AddGaContrattiTipologiaAsync(dto);

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

        [HttpPost("UpdateGaContrattiTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiTipologiaAsync([FromBody] ContrattiTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiTipologiaDto, ContrattiTipologiaApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiTipologiaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContrattiTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiTipologiaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContrattiTipologiaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContrattiTipologiaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContrattiService.ValidateGaContrattiTipologiaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContrattiTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiTipologiaAsync(id);
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

        #region GaContrattiUtentiOnServizi

        #region Functions
        [HttpGet("UpdateGaContrattiUtenteOnPermessoAsync/{utenteId}/{permessoId}")]
        public async Task<ApiResponse> UpdateGaContrattiUtenteOnPermessoAsync(string utenteId, long permessoId)
        {
            var result = await _gaContrattiService.UpdateGaContrattiUtenteOnPermessoAsync(utenteId, permessoId);
            return new ApiResponse(result);
        }
        #endregion

        #region Views 
        [HttpGet("GetViewGaContrattiUtentiOnPermessiAsync/{id}")]
        public async Task<ApiResponse> GetViewGaContrattiUtentiOnPermessiAsync(string id)
        {
            var response = await _gaContrattiService.GetViewGaContrattiUtentiOnPermessiAsync(id);
            return new ApiResponse(response);
        }

        #endregion

        #endregion
    }
}