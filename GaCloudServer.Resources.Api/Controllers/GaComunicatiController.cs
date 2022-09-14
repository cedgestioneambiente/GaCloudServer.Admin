using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Comunicati;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Comunicati;
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
    public class GaComunicatiController : Controller
    {
        private readonly IGaComunicatiService _gaComunicatiService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaComunicatiController> _logger;

        public GaComunicatiController(
            IGaComunicatiService gaComunicatiService
            , IFileService fileService
            ,ILogger<GaComunicatiController> logger)
        {

            _gaComunicatiService = gaComunicatiService;
            _fileService = fileService;
            _logger = logger;
        }

        #region ComunicatiDocumenti
        [HttpGet("GetGaComunicatiDocumentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaComunicatiDocumentiByDocumentoIdAsync(int page,int pageSize)
        {
            try
            {
                var dtos = await _gaComunicatiService.GetGaComunicatiDocumentiAsync(page,pageSize);
                var apiDtos = dtos.ToApiDto<ComunicatiDocumentiApiDto, ComunicatiDocumentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaComunicatiDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaComunicatiDocumentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaComunicatiService.GetGaComunicatiDocumentoByIdAsync(id);
                var apiDto = dto.ToApiDto<ComunicatiDocumentoApiDto, ComunicatiDocumentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaComunicatiDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaComunicatiDocumentoAsync([FromForm] ComunicatiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Comunicati";
                var dto = apiDto.ToDto<ComunicatiDocumentoDto, ComunicatiDocumentoApiDto>();
                var response = await _gaComunicatiService.AddGaComunicatiDocumentoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaComunicatiService.UpdateGaComunicatiDocumentoAsync(dto);
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

        [HttpPost("UpdateGaComunicatiDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaComunicatiDocumentoAsync([FromForm] ComunicatiDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "Comunicati";
                var dto = apiDto.ToDto<ComunicatiDocumentoDto, ComunicatiDocumentoApiDto>();
                var response = await _gaComunicatiService.UpdateGaComunicatiDocumentoAsync(dto);
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
                        var updateFileResponse = await _gaComunicatiService.UpdateGaComunicatiDocumentoAsync(dto);
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
                    var updateFileResponse = await _gaComunicatiService.UpdateGaComunicatiDocumentoAsync(dto);

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

        [HttpDelete("DeleteGaComunicatiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaComunicatiDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaComunicatiService.DeleteGaComunicatiDocumentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaComunicatiDocumentoAsync/{id}/{numero}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaComunicatiDocumentoAsync(long id, string numero)
        {
            try
            {
                var response = await _gaComunicatiService.ValidateGaComunicatiDocumentoAsync(id, numero);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaComunicatiDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaComunicatiDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaComunicatiService.ChangeStatusGaComunicatiDocumentoAsync(id);
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