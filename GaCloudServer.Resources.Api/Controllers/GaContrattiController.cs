using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Contratti;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Models;
using GaCloudServer.Resources.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System.Diagnostics;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaContrattiController : Controller
    {
        private readonly IGaContrattiService _gaContrattiService;
        private readonly ILogger<GaContrattiController> _logger;
        private readonly IFileService _fileService;

        public GaContrattiController(
                    IGaContrattiService gaContrattiService
                    , IFileService fileService
                    , ILogger<GaContrattiController> logger)
        {

            _gaContrattiService = gaContrattiService;
            _logger = logger;
            _fileService = fileService;
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

        #region GaContrattiUtentiOnPermessi

        #region Functions
        [HttpGet("UpdateGaContrattiUtenteOnPermessoAsync/{utenteId}/{permessoId}")]
        public async Task<ApiResponse> UpdateGaContrattiUtenteOnPermessoAsync(string utenteId, long permessoId)
        {
            var result = await _gaContrattiService.UpdateGaContrattiUtenteOnPermessoAsync(utenteId, permessoId);
            return new ApiResponse(result);
        }
        #endregion

        #region Views 
        [HttpGet("GetViewGaContrattiUtentiOnPermessiAsync/{utenteId}")]
        public async Task<ApiResponse> GetViewGaContrattiUtentiOnPermessiAsync(string utenteId)
        {
            var response = await _gaContrattiService.GetViewGaContrattiUtentiOnPermessiAsync(utenteId);
            return new ApiResponse(response);
        }

        #endregion

        #endregion

        #region GaContrattiUtenti

        #region Views 
        [HttpGet("GetViewGaContrattiUtentiAsync/{page}/{pageSize}")]
        public async Task<ApiResponse> GetViewGaContrattiUtentiAsync(int page = 1, int pageSize = 0)
        {
            var response = await _gaContrattiService.GetViewGaContrattiUtentiAsync(page, pageSize);
            return new ApiResponse(response);
        }

        #endregion

        #endregion

        #region GaContrattiModalitas
        [HttpGet("GetGaContrattiModalitasAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiModalitasAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiModalitasAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiModalitasApiDto, ContrattiModalitasDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContrattiModalitaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiModalitaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiModalitaByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiModalitaApiDto, ContrattiModalitaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiModalitaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiModalitaAsync([FromBody] ContrattiModalitaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiModalitaDto, ContrattiModalitaApiDto>();
                var response = await _gaContrattiService.AddGaContrattiModalitaAsync(dto);

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

        [HttpPost("UpdateGaContrattiModalitaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiModalitaAsync([FromBody] ContrattiModalitaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiModalitaDto, ContrattiModalitaApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiModalitaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContrattiModalitaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiModalitaAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiModalitaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContrattiModalitaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContrattiModalitaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContrattiService.ValidateGaContrattiModalitaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContrattiModalitaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiModalitaAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiModalitaAsync(id);
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

        #region GaContrattiSoggetti
        [HttpGet("GetGaContrattiSoggettiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiSoggettiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiSoggettiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiSoggettiApiDto, ContrattiSoggettiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContrattiSoggettoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiSoggettoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiSoggettoByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiSoggettoApiDto, ContrattiSoggettoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiSoggettoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiSoggettoAsync([FromBody] ContrattiSoggettoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiSoggettoDto, ContrattiSoggettoApiDto>();
                var response = await _gaContrattiService.AddGaContrattiSoggettoAsync(dto);

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

        [HttpPost("UpdateGaContrattiSoggettoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiSoggettoAsync([FromBody] ContrattiSoggettoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiSoggettoDto, ContrattiSoggettoApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiSoggettoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContrattiSoggettoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiSoggettoAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiSoggettoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContrattiSoggettoAsync/{id}/{partitaIva}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContrattiSoggettoAsync(long id, string partitaIva)
        {
            try
            {
                var response = await _gaContrattiService.ValidateGaContrattiSoggettoAsync(id, partitaIva);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContrattiSoggettoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiSoggettoAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiSoggettoAsync(id);
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

        #region GaContrattiDocumenti
        [HttpGet("GetGaContrattiDocumentiByIdAsync/{fornitoreId}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiDocumentiByIdAsync(long fornitoreId)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiDocumentiByIdAsync(fornitoreId);
                var apiDtos = dtos.ToApiDto<ContrattiDocumentiApiDto, ContrattiDocumentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContrattiDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiDocumentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiDocumentoByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiDocumentoApiDto, ContrattiDocumentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiDocumentoAsync([FromBody] ContrattiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiDocumentoDto, ContrattiDocumentoApiDto>();
                var response = await _gaContrattiService.AddGaContrattiDocumentoAsync(dto);

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

        [HttpPost("UpdateGaContrattiDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiDocumentoAsync([FromBody] ContrattiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiDocumentoDto, ContrattiDocumentoApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiDocumentoAsync(dto);

                return new ApiResponse(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContrattiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiDocumentoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiDocumentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContrattiDocumentoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContrattiDocumentoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContrattiService.ValidateGaContrattiDocumentoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContrattiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiDocumentoAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusArchiviatoGaContrattiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusArchiviatoGaContrattiDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusArchiviatoGaContrattiDocumentoAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("ExportGaContrattiDocumentiAsync")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportGaContrattiDocumentiAsync([FromBody] long[] ids)
        {

            try
            {
                var entities = _gaContrattiService.ExportGaContrattiDocumentiByIdsAsync(ids).Result.Data;
                string title = "Lista Contratti";
                string[] columns = { "Id", "Numero", "Faldone", "RagioneSociale", "Descrizione", "CodiceCig","Tipologia",
                    "DataScadenza","NumAllegati","Stato" };
                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "LISTA_Contratti", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Lista_Contratti.xlsx"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }
        #endregion

        #region Views

        [HttpGet("GetViewGaContrattiNumeratoriAsync")]
        public async Task<ApiResponse> GetViewGaContrattiNumeratoriAsync()
        {
            try
            {
                var view = await _gaContrattiService.GetViewGaContrattiNumeratoriAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("GetViewGaContrattiDocumentiByFilterAsync")]//GetViewGaContrattiDocumentiBySoggettoId/{contrattiSoggettoId}
        public async Task<ApiResponse> GetViewGaContrattiDocumentiByFilterAsync([FromBody] ContrattiFilterApiDto apiDto)
        {
            try
            {
                var view = await _gaContrattiService.GetViewGaContrattiDocumentiByFilterAsync(apiDto.id,apiDto.roles,apiDto.archiviato);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpPost("GetViewGaContrattiDocumentiScadenziarioByFilterAsync")]//GetViewGaContrattiDocumentiBySoggettoId/{contrattiSoggettoId}
        public async Task<ApiResponse> GetViewGaContrattiDocumentiScadenziarioByFilterAsync([FromBody] ContrattiFilterApiDto apiDto)
        {
            try
            {
                var view = await _gaContrattiService.GetViewGaContrattiDocumentiScadenziarioByFilterAsync(apiDto.id, apiDto.roles,apiDto.tipologie, apiDto.archiviato,apiDto.quickFilter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("GetViewGaContrattiDocumentiByIdAsync")]//GetViewGaContrattiDocumentiBySoggettoId/{contrattiSoggettoId}
        public async Task<ApiResponse> GetViewGaContrattiByIdAsync([FromBody] ContrattiDocumentiRequestApiDto apiDto)
        {
            try
            {
                var dto = apiDto.ToDto<ContrattiDocumentiRequestDto, ContrattiDocumentiRequestApiDto>();
                var view = await _gaContrattiService.GetViewGaContrattiDocumentiByIdAsync(dto);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("GetViewGaContrattiDocumentiListByModeAsync")]
        public async Task<ApiResponse> GetViewGaContrattiDocumentiListByModeAsync([FromBody] ContrattiDocumentiListRequestApiDto apiDto)
        {
            try
            {
                var dto = apiDto.ToDto<ContrattiDocumentiListRequestDto, ContrattiDocumentiListRequestApiDto>();
                var view = await _gaContrattiService.GetViewGaContrattiDocumentiListByModeAsync(dto);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
        #endregion

        #region Sp
        //[HttpPost("GetSpGaContrattiNumeratoriAsync")]
        //public async Task<ApiResponse> GetSpGaContrattiNumeratoreAsync()
        //{
        //    var entities = await _gaContrattiService.GetSpGaContrattiNumeratoreAsync();
        //    return new ApiResponse(entities);
        //}

        //[HttpPost("GetSpGaContrattiPermessiAsync")]
        //public async Task<ApiResponse> GetSpGaContrattiPermessiAsync([FromBody] ContrattiDocumentiRequestApiDto apiDto)
        //{
        //    try
        //    {
        //        var dto = apiDto.ToDto<ContrattiDocumentiRequestDto, ContrattiDocumentiRequestApiDto>();
        //        var entities = await _gaContrattiService.GetSpGaContrattiPermessoAsync(dto);
        //        return new ApiResponse(entities);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }
        //}

        //[HttpPost("GetSpGaContrattiPermessiModeAsync")]
        //public async Task<ApiResponse> GetSpGaContrattiPermessiModeAsync([FromBody] ContrattiDocumentiListRequestApiDto apiDto)
        //{
        //    try
        //    {
        //        var dto = apiDto.ToDto<ContrattiDocumentiListRequestDto, ContrattiDocumentiListRequestApiDto>();
        //        var entities = await _gaContrattiService.GetSpGaContrattiPermessoModeAsync(dto);
        //        return new ApiResponse(entities);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }
        //}
        #endregion

        #endregion

        #region ContrattiDocumentiAllegati
        [HttpGet("GetGaContrattiDocumentiAllegatiByDocumentoIdAsync/{contrattiDocumentoId}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiDocumentiAllegatiByDocumentoIdAsync(long contrattiDocumentoId)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiDocumentiAllegatiByDocumentoIdAsync(contrattiDocumentoId);
                var apiDtos = dtos.ToApiDto<ContrattiDocumentiAllegatiApiDto, ContrattiDocumentiAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContrattiDocumentoAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiDocumentoAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiDocumentoAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiDocumentoAllegatoApiDto, ContrattiDocumentoAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiDocumentoAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiDocumentoAllegatoAsync([FromForm] ContrattiDocumentoAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Contratti";
                var dto = apiDto.ToDto<ContrattiDocumentoAllegatoDto, ContrattiDocumentoAllegatoApiDto>();
                var response = await _gaContrattiService.AddGaContrattiDocumentoAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaContrattiService.UpdateGaContrattiDocumentoAllegatoAsync(dto);
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

        [HttpPost("UpdateGaContrattiDocumentoAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiDocumentoAllegatoAsync([FromForm] ContrattiDocumentoAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Contratti";
                var dto = apiDto.ToDto<ContrattiDocumentoAllegatoDto, ContrattiDocumentoAllegatoApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiDocumentoAllegatoAsync(dto);
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
                        var updateFileResponse = await _gaContrattiService.UpdateGaContrattiDocumentoAllegatoAsync(dto);
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
                    var updateFileResponse = await _gaContrattiService.UpdateGaContrattiDocumentoAllegatoAsync(dto);

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

        [HttpDelete("DeleteGaContrattiDocumentoAllegatoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiDocumentoAllegatoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiDocumentoAllegatoAsync(id);
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

        [HttpGet("ChangeStatusGaContrattiDocumentoAllegatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiDocumentoAllegatoAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiDocumentoAllegatoAsync(id);
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