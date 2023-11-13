using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.ApiDtos.Resources.Progetti;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaProgettiController<TUser, TKey> : Controller
        where TUser : IdentityUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        private readonly IGaProgettiService _gaProgettiService;
        private readonly INotificationService _notificationService;
        private readonly IMailService _mailService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaProgettiController<TUser,TKey>> _logger;

        public GaProgettiController(
            IGaProgettiService gaProgettiService
            , INotificationService notificationService
            , IMailService mailService
            , IFileService fileService
            , ILogger<GaProgettiController<TUser,TKey>> logger
            )
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

                var work = await _gaProgettiService.GetGaProgettiWorkByIdAsync(dto.ProgettiWorkId);
                var settings = await _gaProgettiService.GetGaProgettiWorkSettingsByWorkIdAsync(dto.ProgettiWorkId);
                var user = User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
                string link = "/progetti/calendar/progetti-works-gantt-calendar";

                foreach (var setting in settings.Data.Where(x => x.UserId != user && x.AddJobNotification == true))
                {
                    await _notificationService.CreateNotificationAsync("Nuovo Task", string.Format("È stato aggiunto il task [{0}] all'area di lavoro [{1}]",apiDto.Title, work.Descrizione), null, setting.UserId, "Progetti", link, true);
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

                var work = await _gaProgettiService.GetGaProgettiWorkByIdAsync(dto.ProgettiWorkId);
                var settings = await _gaProgettiService.GetGaProgettiWorkSettingsByWorkIdAsync(dto.ProgettiWorkId);
                var user = User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
                string link = "/progetti/calendar/progetti-works-gantt-calendar";

                foreach (var setting in settings.Data.Where(x => x.UserId != user && x.UpdateJobNotification == true))
                {
                    await _notificationService.CreateNotificationAsync("Task Aggiornato", string.Format("È stato aggiornato il task [{0}] nell'area di lavoro [{1}]", apiDto.Title, work.Descrizione), null, setting.UserId, "Progetti", link, true);
                }

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
                var dto = await _gaProgettiService.GetGaProgettiJobByIdAsync(id);
                var response = await _gaProgettiService.DeleteGaProgettiJobAsync(id);

                var work = await _gaProgettiService.GetGaProgettiWorkByIdAsync(dto.ProgettiWorkId);
                var settings = await _gaProgettiService.GetGaProgettiWorkSettingsByWorkIdAsync(dto.ProgettiWorkId);
                var user = User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
                string link = "/progetti/calendar/progetti-works-gantt-calendar";

                foreach (var setting in settings.Data.Where(x => x.UserId != user && x.AddJobNotification == true))
                {
                    await _notificationService.CreateNotificationAsync("Task Eliminato", string.Format("È stato eliminato il task [{0}] all'area di lavoro [{1}]", dto.Title, work.Descrizione), null, setting.UserId, "Progetti", link, true);
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
                string fileFolder = "GaCloud/Progetti";
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

        #region ProgettiJobTasks
        [HttpGet("GetGaProgettiJobTasksByJobIdAsync/{jobId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobTasksByJobIdAsync(long jobId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobTasksByJobIdAsync(jobId);
                var apiDtos = dtos.ToApiDto<ProgettiJobTasksApiDto, ProgettiJobTasksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobTaskByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobTaskByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobTaskByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiJobTaskApiDto, ProgettiJobTaskDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiJobTaskAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobTaskAsync([FromBody] ProgettiJobTaskApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var dto = apiDto.ToDto<ProgettiJobTaskDto, ProgettiJobTaskApiDto>();
                var response = await _gaProgettiService.AddGaProgettiJobTaskAsync(dto);
                

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

        [HttpPost("UpdateGaProgettiJobTaskAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiJobTaskAsync([FromBody] ProgettiJobTaskApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobTaskDto, ProgettiJobTaskApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiJobTaskAsync(dto);

                return new ApiResponse(response, code.Status200OK);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpDelete("DeleteGaProgettiJobTaskAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiJobTaskAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiJobTaskAsync(id);
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

        #region ProgettiWorkSettings
        [HttpGet("GetGaProgettiWorkSettingByWorkIdAndUserIdAsync/{workId}/{userId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorkSettingByWorkIdAndUserIdAsync(long workId, string userId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiWorkSettingByWorkIdAndUserIdAsync(workId, userId);
                var apiDtos = dtos.ToApiDto<ProgettiWorkSettingApiDto, ProgettiWorkSettingDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiWorkSettingsByWorkIdAsync/{workId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiWorkSettingsByWorkIdAsync(long workId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiWorkSettingsByWorkIdAsync(workId);
                var apiDtos = dtos.ToApiDto<ProgettiWorkSettingsApiDto, ProgettiWorkSettingsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("UpdateGaProgettiWorkSettingAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiWorkSettingAsync([FromBody] ProgettiWorkSettingApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiWorkSettingDto, ProgettiWorkSettingApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiWorkSettingAsync(dto);

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
        #endregion

        #region ProgettiJobsUndertakings
        [HttpGet("GetGaProgettiJobsUndertakingsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsUndertakingsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsUndertakingsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ProgettiJobsUndertakingsApiDto, ProgettiJobsUndertakingsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobUndertakingByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobUndertakingByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobUndertakingByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiJobUndertakingApiDto, ProgettiJobUndertakingDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobsUndertakingsByJobIdAsync/{jobId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsUndertakingsByWorkIdAsync(long jobId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsUndertakingsByJobIdAsync(jobId);
                var apiDtos = dtos.ToApiDto<ProgettiJobsUndertakingsApiDto, ProgettiJobsUndertakingsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpPost("AddGaProgettiJobUndertakingAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobUndertakingAsync([FromBody] ProgettiJobUndertakingApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobUndertakingDto, ProgettiJobUndertakingApiDto>();
                var response = await _gaProgettiService.AddGaProgettiJobUndertakingAsync(dto);

                //var work = await _gaProgettiService.GetGaProgettiWorkByIdAsync(dto.ProgettiWorkId);
                //var settings = await _gaProgettiService.GetGaProgettiWorkSettingsByWorkIdAsync(dto.ProgettiWorkId);
                //var user = User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
                //string link = "/progetti/calendar/progetti-works-gantt-calendar";

                //foreach (var setting in settings.Data.Where(x => x.UserId != user && x.AddJobNotification == true))
                //{
                //    await _notificationService.CreateNotificationAsync("Nuovo Task", string.Format("È stato aggiunto il task [{0}] all'area di lavoro [{1}]", apiDto.Title, work.Descrizione), null, setting.UserId, "Progetti", link, true);
                //}

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

        [HttpPost("UpdateGaProgettiJobUndertakingAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiJobUndertakingAsync([FromBody] ProgettiJobUndertakingApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobUndertakingDto, ProgettiJobUndertakingApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiJobUndertakingAsync(dto);

                //var work = await _gaProgettiService.GetGaProgettiWorkByIdAsync(dto.ProgettiWorkId);
                //var settings = await _gaProgettiService.GetGaProgettiWorkSettingsByWorkIdAsync(dto.ProgettiWorkId);
                //var user = User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
                //string link = "/progetti/calendar/progetti-works-gantt-calendar";

                //foreach (var setting in settings.Data.Where(x => x.UserId != user && x.UpdateJobNotification == true))
                //{
                //    await _notificationService.CreateNotificationAsync("Task Aggiornato", string.Format("È stato aggiornato il task [{0}] nell'area di lavoro [{1}]", apiDto.Title, work.Descrizione), null, setting.UserId, "Progetti", link, true);
                //}

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaProgettiJobUndertakingAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiJobUndertakingAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobUndertakingByIdAsync(id);
                var response = await _gaProgettiService.DeleteGaProgettiJobUndertakingAsync(id);

                //var work = await _gaProgettiService.GetGaProgettiWorkByIdAsync(dto.ProgettiWorkId);
                //var settings = await _gaProgettiService.GetGaProgettiWorkSettingsByWorkIdAsync(dto.ProgettiWorkId);
                //var user = User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
                //string link = "/progetti/calendar/progetti-works-gantt-calendar";

                //foreach (var setting in settings.Data.Where(x => x.UserId != user && x.AddJobNotification == true))
                //{
                //    await _notificationService.CreateNotificationAsync("Task Eliminato", string.Format("È stato eliminato il task [{0}] all'area di lavoro [{1}]", dto.Title, work.Descrizione), null, setting.UserId, "Progetti", link, true);
                //}

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaProgettiJobUndertakingAsync/{id}/{descrizione}/{jobId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaProgettiJobUndertakingAsync(long id, string descrizione, long jobId)
        {
            try
            {
                var response = await _gaProgettiService.ValidateGaProgettiJobUndertakingAsync(id, descrizione, jobId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaProgettiJobUndertakingAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaProgettiJobUndertakingAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.ChangeStatusGaProgettiJobUndertakingAsync(id);
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

        #region ProgettiJobsUndertakingsAllegati
        [HttpGet("GetGaProgettiJobsUndertakingsAllegatiByUndertakingIdAsync/{undertakingId}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsUndertakingsAllegatiByUndertakingIdAsync(long undertakingId)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsUndertakingsAllegatiByUndertakingIdAsync(undertakingId);
                var apiDtos = dtos.ToApiDto<ProgettiJobsUndertakingsAllegatiApiDto, ProgettiJobsUndertakingsAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobUndertakingAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobUndertakingAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobUndertakingAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiJobUndertakingAllegatoApiDto, ProgettiJobUndertakingAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiJobUndertakingAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobUndertakingAllegatoAsync([FromForm] ProgettiJobUndertakingAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Progetti/UndertakingsAllegati";
                var dto = apiDto.ToDto<ProgettiJobUndertakingAllegatoDto, ProgettiJobUndertakingAllegatoApiDto>();
                var response = await _gaProgettiService.AddGaProgettiJobUndertakingAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaProgettiService.UpdateGaProgettiJobUndertakingAllegatoAsync(dto);
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

        [HttpPost("UpdateGaProgettiJobUndertakingAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiJobUndertakingAllegatoAsync([FromBody] ProgettiJobUndertakingAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud//UndertakingsAllegati";
                var dto = apiDto.ToDto<ProgettiJobUndertakingAllegatoDto, ProgettiJobUndertakingAllegatoApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiJobUndertakingAllegatoAsync(dto);
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
                        var updateFileResponse = await _gaProgettiService.UpdateGaProgettiJobUndertakingAllegatoAsync(dto);
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
                    var updateFileResponse = await _gaProgettiService.UpdateGaProgettiJobUndertakingAllegatoAsync(dto);

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

        [HttpDelete("DeleteGaProgettiJobUndertakingAllegatoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiJobUndertakingAllegatoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiJobUndertakingAllegatoAsync(id);
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


        #endregion

        #region ProgettiJobsUndertakingsStates
        [HttpGet("GetGaProgettiJobsUndertakingsStatesAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobsUndertakingsStatesAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaProgettiService.GetGaProgettiJobsUndertakingsStatesAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ProgettiJobsUndertakingsStatesApiDto, ProgettiJobsUndertakingsStatesDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaProgettiJobUndertakingStateByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaProgettiJobUndertakingStateByIdAsync(long id)
        {
            try
            {
                var dto = await _gaProgettiService.GetGaProgettiJobUndertakingStateByIdAsync(id);
                var apiDto = dto.ToApiDto<ProgettiJobUndertakingStateApiDto, ProgettiJobUndertakingStateDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaProgettiJobUndertakingStateAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaProgettiJobUndertakingStateAsync([FromBody] ProgettiJobUndertakingStateApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobUndertakingStateDto, ProgettiJobUndertakingStateApiDto>();
                var response = await _gaProgettiService.AddGaProgettiJobUndertakingStateAsync(dto);

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

        [HttpPost("UpdateGaProgettiJobUndertakingStateAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaProgettiJobUndertakingStateAsync([FromBody] ProgettiJobUndertakingStateApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ProgettiJobUndertakingStateDto, ProgettiJobUndertakingStateApiDto>();
                var response = await _gaProgettiService.UpdateGaProgettiJobUndertakingStateAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaProgettiJobUndertakingStateAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaProgettiJobUndertakingStateAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.DeleteGaProgettiJobUndertakingStateAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaProgettiJobUndertakingStateAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaProgettiJobUndertakingStateAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaProgettiService.ValidateGaProgettiJobUndertakingStateAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaProgettiJobUndertakingStateAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaProgettiJobUndertakingStateAsync(long id)
        {
            try
            {
                var response = await _gaProgettiService.ChangeStatusGaProgettiJobUndertakingStateAsync(id);
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
