using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Autorizzazioni;
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
    public class GaAutorizzazioniController : Controller
    {
        private readonly IGaAutorizzazioniService _gaAutorizzazioniService;
        private readonly IApiErrorResources _errorResources;
        private readonly IFileService _fileService;
        private readonly ILogger<GaAutorizzazioniController> _logger;

        public GaAutorizzazioniController(
            IGaAutorizzazioniService gaAutorizzazioniService
            ,IApiErrorResources errorResources
            ,IFileService fileService
            ,ILogger<GaAutorizzazioniController> logger)
        {

            _gaAutorizzazioniService = gaAutorizzazioniService;
            _fileService = fileService;
            _errorResources= errorResources;
            _logger = logger;
        }


        #region AutorizzazioniTipi
        [HttpGet("GetGaAutorizzazioniTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaAutorizzazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaAutorizzazioniService.GetGaAutorizzazioniTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<AutorizzazioniTipiApiDto, AutorizzazioniTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetGaAutorizzazioniTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaAutorizzazioniTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaAutorizzazioniService.GetGaAutorizzazioniTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<AutorizzazioniTipoApiDto, AutorizzazioniTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaAutorizzazioniTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaAutorizzazioniTipoAsync([FromBody]AutorizzazioniTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<AutorizzazioniTipoDto, AutorizzazioniTipoApiDto>();
                var response = await _gaAutorizzazioniService.AddGaAutorizzazioniTipoAsync(dto);

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

        [HttpPost("UpdateGaAutorizzazioniTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaAutorizzazioniTipoAsync([FromBody] AutorizzazioniTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<AutorizzazioniTipoDto, AutorizzazioniTipoApiDto>();
                var response = await _gaAutorizzazioniService.UpdateGaAutorizzazioniTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaAutorizzazioniTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaAutorizzazioniTipoAsync(long id)
        {
            try
            {
                var response = await _gaAutorizzazioniService.DeleteGaAutorizzazioniTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaAutorizzazioniTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaAutorizzazioniTipoAsync(long id,string descrizione)
        {
            try
            {
                var response = await _gaAutorizzazioniService.ValidateGaAutorizzazioniTipoAsync(id,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaAutorizzazioniTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaAutorizzazioniTipoAsync(long id)
        {
            try
            {
                var response = await _gaAutorizzazioniService.ChangeStatusGaAutorizzazioniTipoAsync(id);
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

        #region AutorizzazioniDocumenti
        [HttpGet("GetGaAutorizzazioniDocumentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaAutorizzazioniDocumentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaAutorizzazioniService.GetGaAutorizzazioniDocumentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<AutorizzazioniDocumentiApiDto, AutorizzazioniDocumentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaAutorizzazioniDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaAutorizzazioniDocumentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaAutorizzazioniService.GetGaAutorizzazioniDocumentoByIdAsync(id);
                var apiDto = dto.ToApiDto<AutorizzazioniDocumentoApiDto, AutorizzazioniDocumentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaAutorizzazioniDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaAutorizzazioniDocumentoAsync([FromBody] AutorizzazioniDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<AutorizzazioniDocumentoDto, AutorizzazioniDocumentoApiDto>();
                var response = await _gaAutorizzazioniService.AddGaAutorizzazioniDocumentoAsync(dto);

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

        [HttpPost("UpdateGaAutorizzazioniDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaAutorizzazioniDocumentoAsync([FromBody] AutorizzazioniDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<AutorizzazioniDocumentoDto, AutorizzazioniDocumentoApiDto>();
                var response = await _gaAutorizzazioniService.UpdateGaAutorizzazioniDocumentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaAutorizzazioniDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaAutorizzazioniDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaAutorizzazioniService.DeleteGaAutorizzazioniDocumentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaAutorizzazioniDocumentoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaAutorizzazioniDocumentoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaAutorizzazioniService.ValidateGaAutorizzazioniDocumentoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaAutorizzazioniDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaAutorizzazioniDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaAutorizzazioniService.ChangeStatusGaAutorizzazioniDocumentoAsync(id);
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
        [HttpGet("GetViewGaAutorizzazioniDocumentiAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaAutorizzazioniDocumentiAsync(bool all=true)
        {
            try
            {
                var view = await _gaAutorizzazioniService.GetViewGaAutorizzazioniDocumentiAsync(all);
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

        #region AutorizzazioniAllegati
        [HttpGet("GetGaAutorizzazioniAllegatiByDocumentoIdAsync/{autorizzazioniDocumentoId}")]
        public async Task<ActionResult<ApiResponse>> GetGaAutorizzazioniAllegatiByDocumentoIdAsync(long autorizzazioniDocumentoid)
        {
            try
            {
                var dtos = await _gaAutorizzazioniService.GetGaAutorizzazioniAllegatiByDocumentoIdAsync(autorizzazioniDocumentoid);
                var apiDtos = dtos.ToApiDto<AutorizzazioniAllegatiApiDto, AutorizzazioniAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaAutorizzazioniAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaAutorizzazioniAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaAutorizzazioniService.GetGaAutorizzazioniAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<AutorizzazioniAllegatoApiDto, AutorizzazioniAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaAutorizzazioniAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaAutorizzazioniAllegatoAsync([FromForm] AutorizzazioniAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Autorizzazioni";
                var dto = apiDto.ToDto<AutorizzazioniAllegatoDto, AutorizzazioniAllegatoApiDto>();
                var response = await _gaAutorizzazioniService.AddGaAutorizzazioniAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaAutorizzazioniService.UpdateGaAutorizzazioniAllegatoAsync(dto);
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

        [HttpPost("UpdateGaAutorizzazioniAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaAutorizzazioniAllegatoAsync([FromForm] AutorizzazioniAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Autorizzazioni";
                var dto = apiDto.ToDto<AutorizzazioniAllegatoDto, AutorizzazioniAllegatoApiDto>();
                var response = await _gaAutorizzazioniService.UpdateGaAutorizzazioniAllegatoAsync(dto);
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
                        var updateFileResponse = await _gaAutorizzazioniService.UpdateGaAutorizzazioniAllegatoAsync(dto);
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
                    var updateFileResponse = await _gaAutorizzazioniService.UpdateGaAutorizzazioniAllegatoAsync(dto);

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

        [HttpDelete("DeleteGaAutorizzazioniAllegatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaAutorizzazioniAllegatoAsync(long id)
        {
            try
            {
                var response = await _gaAutorizzazioniService.DeleteGaAutorizzazioniAllegatoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions

        [HttpGet("ChangeStatusGaAutorizzazioniAllegatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaAutorizzazioniAllegatoAsync(long id)
        {
            try
            {
                var response = await _gaAutorizzazioniService.ChangeStatusGaAutorizzazioniAllegatoAsync(id);
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