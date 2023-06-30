using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.ApiDtos.Resources.Progetti;
using GaCloudServer.Resources.Api.Configuration.Constants;
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
    public class GaProgettiController : Controller
    {
        private readonly IGaProgettiService _gaProgettiService;
        private readonly INotificationService _notificationService;
        private readonly IMailService _mailService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaProgettiController> _logger;

        public GaProgettiController(
            IGaProgettiService gaProgettiService,
            INotificationService notificationService,
            IMailService mailService
            , IFileService fileService
            , ILogger<GaProgettiController> logger)
        {

            _gaProgettiService = gaProgettiService;
            _notificationService = notificationService;
            _mailService = mailService;
            _fileService = fileService;
            _logger = logger;
        }

        #region ProgettiWork
        [HttpGet("GetGaProgettiWorksAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorksAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiWorksAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ProgettiWorksApiDto, ProgettiWorksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiWorkByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorkByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiWorkByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiWorkApiDto, ProgettiWorkDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiWorksByUserAsync/{userId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorksByUserAsync(string userId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiWorksByUserAsync(userId);
                var apiDtos = dtos.ToApiDto<ProgettiWorksApiDto, ProgettiWorksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiWorkAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiWorkAsync([FromBody] ProgettiWorkApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiWorkDto, ProgettiWorkApiDto>();
                var response = await _gaProgettiService.AddGaProgettiWorkAsync(dto);

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

        [HttpPost("UpdateGaProgettiWorkAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiWorkAsync([FromBody] ProgettiWorkApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiWorkDto, ProgettiWorkApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiWorkAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaProgettiWorkAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiWorkAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiWorkAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaProgettiWorkAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaProgettiWorkAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaProgettiService.ValidateGaProgettiWorkAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaProgettiWorkAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaProgettiWorkAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.ChangeStatusGaProgettiWorkAsync(id);
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

        #endregion

        #endregion

        #region ProgettiJobs
        [HttpGet("GetGaProgettiJobsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ProgettiJobsApiDto, ProgettiJobsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiJobApiDto, ProgettiJobDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobsByWorkIdAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsByWorkIdAsync(long workId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsByWorkIdAsync(workId);
                var apiDtos = dtos.ToApiDto<ProgettiJobsApiDto, ProgettiJobsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobsByWorkIdAndParentIdAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsByWorkIdAndParentIdAsync(workId,parentId);
                var apiDtos = dtos.ToApiDto<ProgettiJobsApiDto, ProgettiJobsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiJobAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobAsync([FromBody] ProgettiJobApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobDto, ProgettiJobApiDto>();
                var response = await _gaProgettiService.AddGaProgettiJobAsync(dto);

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

        [HttpPost("UpdateGaProgettiJobAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiJobAsync([FromBody] ProgettiJobApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobDto, ProgettiJobApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiJobAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaProgettiJobAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiJobAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiJobAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaProgettiJobAsync/{id}/{descrizione}/{workId}/{parentId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaProgettiJobAsync(long id, string descrizione, long workId,long parentId)
        {
            try
            {
                var response = await _gaProgettiService.ValidateGaProgettiJobAsync(id, descrizione,workId,parentId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaProgettiJobAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaProgettiJobAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.ChangeStatusGaProgettiJobAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpGet("AddGaProgettiJobLinkAsync/{targetId}/{sourceId}")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobLinkAsync(long targetId,long sourceId)
        {
            try
            {
                var response = await _gaProgettiService.AddGaProgettiJobLinkAsync(targetId,sourceId);
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
        [HttpGet("GetViewGaProgettiJobsByWorkIdAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdAsync(long workId)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdAsync(workId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpGet("GetViewGaProgettiJobsByWorkIdWithChildrenAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdWithChildrenAsync(long workId)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdWithChildrenAsync(workId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync/{workId}/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync(long workId,bool all=true)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync(workId,all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaProgettiJobsByWorkIdAndParentIdAsync/{workId}/{parentId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId)
        {
            try
            {
                var view = await _gaProgettiService.GetViewGaProgettiJobsByWorkIdAndParentIdAsync(workId,parentId);
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

        #region ProgettiJobAllegati
        [HttpGet("GetGaProgettiJobAllegatiByJobIdAsync/{jobId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobAllegatiByJobIdAsync(long jobId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobAllegatiByJobIdAsync(jobId);
                var apiDtos = dtos.ToApiDto<ProgettiJobAllegatiApiDto, ProgettiJobAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiJobAllegatoApiDto, ProgettiJobAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiJobAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobAllegatoAsync([FromForm] ProgettiJobAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Progetti";
                var dto = apiDto.ToDto<ProgettiJobAllegatoDto, ProgettiJobAllegatoApiDto>();
                var response = await _gaProgettiService.AddGaProgettiJobAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaProgettiService.UpdateGaProgettiJobAllegatoAsync(dto);
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

        [HttpPost("UpdateGaProgettiJobAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiJobAllegatoAsync([FromBody] ProgettiJobAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/CrmTicket";
                var dto = apiDto.ToDto<ProgettiJobAllegatoDto, ProgettiJobAllegatoApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiJobAllegatoAsync(dto);
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
                        var updateFileResponse = await _gaProgettiService.UpdateGaProgettiJobAllegatoAsync(dto);
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
                    var updateFileResponse = await _gaProgettiService.UpdateGaProgettiJobAllegatoAsync(dto);

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

        [HttpDelete("DeleteGaProgettiJobAllegatoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiJobAllegatoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiJobAllegatoAsync(id);
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
        
        #endregion

        #endregion


    }
}
