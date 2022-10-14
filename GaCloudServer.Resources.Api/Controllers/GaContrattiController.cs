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
using code = Microsoft.AspNetCore.Http.StatusCodes;

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

        #region GaContrattiFornitori
        [HttpGet("GetGaContrattiFornitoriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiFornitoriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiFornitoriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiFornitoriApiDto, ContrattiFornitoriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContrattiFornitoreByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiFornitoreByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContrattiService.GetGaContrattiFornitoreByIdAsync(id);
                var apiDto = dto.ToApiDto<ContrattiFornitoreApiDto, ContrattiFornitoreDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContrattiFornitoreAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContrattiFornitoreAsync([FromBody] ContrattiFornitoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiFornitoreDto, ContrattiFornitoreApiDto>();
                var response = await _gaContrattiService.AddGaContrattiFornitoreAsync(dto);

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

        [HttpPost("UpdateGaContrattiFornitoreAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiFornitoreAsync([FromBody] ContrattiFornitoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContrattiFornitoreDto, ContrattiFornitoreApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiFornitoreAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContrattiFornitoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiFornitoreAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.DeleteGaContrattiFornitoreAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContrattiFornitoreAsync/{id}/{partitaIva}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContrattiFornitoreAsync(long id, string partitaIva)
        {
            try
            {
                var response = await _gaContrattiService.ValidateGaContrattiFornitoreAsync(id, partitaIva);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContrattiFornitoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContrattiFornitoreAsync(long id)
        {
            try
            {
                var response = await _gaContrattiService.ChangeStatusGaContrattiFornitoreAsync(id);
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
        public async Task<ActionResult<ApiResponse>> AddGaContrattiDocumentoAsync([FromForm] ContrattiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Contratti";
                var dto = apiDto.ToDto<ContrattiDocumentoDto, ContrattiDocumentoApiDto>();
                var response = await _gaContrattiService.AddGaContrattiDocumentoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaContrattiService.UpdateGaContrattiDocumentoAsync(dto);
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

        [HttpPost("UpdateGaContrattiDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContrattiDocumentoAsync([FromForm] ContrattiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Contratti";
                var dto = apiDto.ToDto<ContrattiDocumentoDto, ContrattiDocumentoApiDto>();
                var response = await _gaContrattiService.UpdateGaContrattiDocumentoAsync(dto);
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
                        var updateFileResponse = await _gaContrattiService.UpdateGaContrattiDocumentoAsync(dto);
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
                    var updateFileResponse = await _gaContrattiService.UpdateGaContrattiDocumentoAsync(dto);

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

        [HttpDelete("DeleteGaContrattiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContrattiDocumentoAsync(long id)
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

        [HttpGet("GetViewGaContrattiDocumentiByIdAsync")]
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
        //[HttpGet("GetSpGaContrattiNumeratoriAsync")]
        //public async Task<ApiResponse> GetSpGaContrattiNumeratoreAsync()
        //{
        //    var entities = await _gaContrattiService.GetSpGaContrattiNumeratoreAsync();
        //    return new ApiResponse(entities);
        //}

        //[HttpGet("GetSpGaContrattiPermessiAsync")]
        //public async Task<ApiResponse> GetSpGaContrattiPermessiAsync([FromBody] ContrattiDocumentiRequestApiDto apiDto)
        //{
        //    var dto = apiDto.ToDto<ContrattiDocumentiRequestDto, ContrattiDocumentiRequestApiDto>();
        //    var entities = await _gaContrattiService.GetSpGaContrattiPermessoAsync(dto);
        //    return new ApiResponse(entities);
        //}

        //[HttpGet("GetSpGaContrattiPermessiModeAsync")]
        //public async Task<ApiResponse> GetSpGaContrattiPermessiModeAsync([FromBody] ContrattiDocumentiListRequestApiDto apiDto)
        //{
        //    var dto = apiDto.ToDto<ContrattiDocumentiListRequestDto, ContrattiDocumentiListRequestApiDto>();
        //    var entities = await _gaContrattiService.GetSpGaContrattiPermessoModeAsync(dto);
        //    return new ApiResponse(entities);
        //}
        #endregion

        #endregion
    }
}