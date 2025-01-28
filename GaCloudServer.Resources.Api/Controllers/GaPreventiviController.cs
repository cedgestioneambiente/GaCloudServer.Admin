using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Helpers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Preventivi;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using blfh = GaCloudServer.BusinnessLogic.Helpers.FileHelper;
using code = Microsoft.AspNetCore.Http.StatusCodes;


namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaPreventiviController<TUser,TKey> : ControllerBase
        where TUser: IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly string basePath = "GaCloud/Preventivi";

        private readonly IGaPreventiviService _gaPreventiviService;
        private readonly ICommonService _commonService;
        private readonly ILogger<GaPreventiviController<TUser,TKey>> _logger;
        private readonly IFileService _fileService;
        private readonly IMailService _mailService;
        private readonly IPrintService _printService;
        private readonly INotificationService _notificationService;
        private readonly IQueryBuilderService _queryBuilderService;
        private readonly UserManager<TUser> _userManager;

        public GaPreventiviController(
            IGaPreventiviService gaPreventiviService
            , ICommonService commonService
            , IFileService fileService
            , IMailService mailService
            , IPrintService printService
            , INotificationService notificationService
            , IQueryBuilderService queryBuilderService
            , UserManager<TUser> userManager
            , ILogger<GaPreventiviController<TUser,TKey>> logger)
        {

            _gaPreventiviService = gaPreventiviService;
            _commonService = commonService;
            _fileService = fileService;
            _mailService = mailService;
            _printService = printService;
            _notificationService = notificationService;
            _queryBuilderService = queryBuilderService;
            _userManager = userManager;
            _logger = logger;
            
        }

        #region OLD

        #region PreventiviAnticipiTipologie
        [HttpGet("GetGaPreventiviAnticipiTipologieAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipiTipologieAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPreventiviService.GetGaPreventiviAnticipiTipologieAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PreventiviAnticipiTipologieApiDto, PreventiviAnticipiTipologieDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPreventiviAnticipoTipologiaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipoTipologiaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPreventiviService.GetGaPreventiviAnticipoTipologiaByIdAsync(id);
                var apiDto = dto.ToApiDto<PreventiviAnticipoTipologiaApiDto, PreventiviAnticipoTipologiaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPreventiviAnticipoTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPreventiviAnticipoTipologiaAsync([FromBody] PreventiviAnticipoTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PreventiviAnticipoTipologiaDto, PreventiviAnticipoTipologiaApiDto>();
                var response = await _gaPreventiviService.AddGaPreventiviAnticipoTipologiaAsync(dto);

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

        [HttpPut("UpdateGaPreventiviAnticipoTipologiaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPreventiviAnticipoTipologiaAsync([FromBody] PreventiviAnticipoTipologiaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PreventiviAnticipoTipologiaDto, PreventiviAnticipoTipologiaApiDto>();
                var response = await _gaPreventiviService.UpdateGaPreventiviAnticipoTipologiaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPreventiviAnticipoTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPreventiviAnticipoTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeleteGaPreventiviAnticipoTipologiaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPreventiviAnticipoTipologiaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPreventiviAnticipoTipologiaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPreventiviService.ValidateGaPreventiviAnticipoTipologiaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPreventiviAnticipoTipologiaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPreventiviAnticipoTipologiaAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.ChangeStatusGaPreventiviAnticipoTipologiaAsync(id);
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

        #region PreventiviAnticipiPagamenti
        [HttpGet("GetGaPreventiviAnticipiPagamentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipiPagamentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPreventiviService.GetGaPreventiviAnticipiPagamentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PreventiviAnticipiPagamentiApiDto, PreventiviAnticipiPagamentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPreventiviAnticipoPagamentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipoPagamentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPreventiviService.GetGaPreventiviAnticipoPagamentoByIdAsync(id);
                var apiDto = dto.ToApiDto<PreventiviAnticipoPagamentoApiDto, PreventiviAnticipoPagamentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPreventiviAnticipoPagamentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPreventiviAnticipoPagamentoAsync([FromBody] PreventiviAnticipoPagamentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PreventiviAnticipoPagamentoDto, PreventiviAnticipoPagamentoApiDto>();
                var response = await _gaPreventiviService.AddGaPreventiviAnticipoPagamentoAsync(dto);

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

        [HttpPut("UpdateGaPreventiviAnticipoPagamentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPreventiviAnticipoPagamentoAsync([FromBody] PreventiviAnticipoPagamentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PreventiviAnticipoPagamentoDto, PreventiviAnticipoPagamentoApiDto>();
                var response = await _gaPreventiviService.UpdateGaPreventiviAnticipoPagamentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPreventiviAnticipoPagamentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPreventiviAnticipoPagamentoAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeleteGaPreventiviAnticipoPagamentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPreventiviAnticipoPagamentoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPreventiviAnticipoPagamentoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPreventiviService.ValidateGaPreventiviAnticipoPagamentoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPreventiviAnticipoPagamentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPreventiviAnticipoPagamentoAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.ChangeStatusGaPreventiviAnticipoPagamentoAsync(id);
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

        #region PreventiviAnticipi
        [HttpGet("GetGaPreventiviAnticipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPreventiviService.GetGaPreventiviAnticipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PreventiviAnticipiApiDto, PreventiviAnticipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPreventiviAnticipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPreventiviService.GetGaPreventiviAnticipoByIdAsync(id);
                var apiDto = dto.ToApiDto<PreventiviAnticipoApiDto, PreventiviAnticipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPreventiviAnticipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPreventiviAnticipoAsync([FromBody] PreventiviAnticipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PreventiviAnticipoDto, PreventiviAnticipoApiDto>();
                var response = await _gaPreventiviService.AddGaPreventiviAnticipoAsync(dto);

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

        [HttpPut("UpdateGaPreventiviAnticipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPreventiviAnticipoAsync([FromBody] PreventiviAnticipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PreventiviAnticipoDto, PreventiviAnticipoApiDto>();
                var response = await _gaPreventiviService.UpdateGaPreventiviAnticipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPreventiviAnticipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPreventiviAnticipoAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeleteGaPreventiviAnticipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPreventiviAnticipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPreventiviAnticipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPreventiviService.ValidateGaPreventiviAnticipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPreventiviAnticipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPreventiviAnticipoAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.ChangeStatusGaPreventiviAnticipoAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("SetGaPreventiviAnticipoPagatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> SetGaPreventiviAnticipoPagatoAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.SetGaPreventiviAnticipoPagatoAsync(id);
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
        [HttpGet("GetViewGaPreventiviAnticipiAsync")]
        public async Task<ApiResponse> GetViewGaPreventiviAnticipiAsync()
        {
            try
            {
                var view = await _gaPreventiviService.GetViewGaPreventiviAnticipiAsync();
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

        #region PreventiviAnticipiAllegati
        [HttpGet("GetGaPreventiviAnticipiAllegatiByAnticipoAsync/{preventiviAnticipoId}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipiAllegatiByAnticipoAsync(long preventiviAnticipoId)
        {
            try
            {
                var dtos = await _gaPreventiviService.GetGaPreventiviAnticipiAllegatiByAnticipoAsync(preventiviAnticipoId);
                var apiDtos = dtos.ToApiDto<PreventiviAnticipiAllegatiApiDto, PreventiviAnticipiAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPreventiviAnticipoAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPreventiviAnticipoAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPreventiviService.GetGaPreventiviAnticipoAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<PreventiviAnticipoAllegatoApiDto, PreventiviAnticipoAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPreventiviAnticipoAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPreventiviAnticipoAllegatoAsync([FromForm] PreventiviAnticipoAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Preventivi/Anticipi";
                var dto = apiDto.ToDto<PreventiviAnticipoAllegatoDto, PreventiviAnticipoAllegatoApiDto>();
                var response = await _gaPreventiviService.AddGaPreventiviAnticipoAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaPreventiviService.UpdateGaPreventiviAnticipoAllegatoAsync(dto);
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

        [HttpPut("UpdateGaPreventiviAnticipoAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPreventiviAnticipoAllegatoAsync([FromForm] PreventiviAnticipoAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Preventivi/Anticipi";
                var dto = apiDto.ToDto<PreventiviAnticipoAllegatoDto, PreventiviAnticipoAllegatoApiDto>();
                var response = await _gaPreventiviService.UpdateGaPreventiviAnticipoAllegatoAsync(dto);
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
                        var updateFileResponse = await _gaPreventiviService.UpdateGaPreventiviAnticipoAllegatoAsync(dto);
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
                    var updateFileResponse = await _gaPreventiviService.UpdateGaPreventiviAnticipoAllegatoAsync(dto);

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

        [HttpDelete("DeleteGaPreventiviAnticipoAllegatoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPreventiviAnticipoAllegatoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaPreventiviService.DeleteGaPreventiviAnticipoAllegatoAsync(id);
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

        [HttpGet("ChangeStatusGaPreventiviAnticipoAllegatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPreventiviAnticipoAllegatoAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.ChangeStatusGaPreventiviAnticipoAllegatoAsync(id);
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

        #endregion

        #region TicketCrm/Standalone
        [HttpPost("GetViewPreventiviCrmTicketsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetViewPreventiviCrmTicketsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetViewPreventiviCrmTicketsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("GetPreventiviCrmComuniAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviCrmComuniAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviCrmComuniAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectFromCrmTicketAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectFromCrmTicketAsync(PreventiviObjectAssignementDto model)
        {
            try
            {
                var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.Preventivi, AppConsts.PreventiviInfo);
                var notifications = await _notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(notificationApp.Id);
                
                var query = System.IO.File.ReadAllText(@".\Query\Preventivi\FinancialPosition.sql");
                query = string.Format(query, model.ClienteCfPiva,model.ClienteCfPiva,model.IntestatarioCfPiva,model.IntestatarioCfPiva);
                var saldo = await _gaPreventiviService.CheckPreventiviFinancialPositionAsync(query);
                
                var response = await _gaPreventiviService.CreatePreventiviObjectFromCrmTicketAsync(model,saldo);
                var history = new PreventiviObjectHistoryDto();
                history.ObjectId = response.Id;
                history.AssigneeId = model.AssigneeId;
                history.AssigneeDesc = model.AssigneeMail;
                history.DateStart = DateTime.Now;
                history.StatusId = response.StatusId;


                var regHistory = await _gaPreventiviService.CreatePreventiviObjectHistoryAsync(history);

                var condition = await _gaPreventiviService.GetPreventiviConditionTemplateByIdAsync(1);
                var objectCondition = new PreventiviObjectConditionDto();
                objectCondition.Descrizione = condition.Content;
                objectCondition.ObjectId = response.Id;
                objectCondition.Order = 1;
                var responseCondition = await _gaPreventiviService.CreatePreventiviObjectConditionAsync(objectCondition);

                if (model.SendEmail.GetValueOrDefault())
                {

                    #region Assignee Communication
                    await sendMail(response.Id, response.ObjectNumber, model.AssigneeMail, TextConsts.objectManage, model.NoteCrm, model.CreatorName, "", model.CreatorId);
                    if (model.SendNotify.GetValueOrDefault()) { await sendNotification(response.Id, response.ObjectNumber, model.AssigneeId,TextConsts.objectManage); }

                    #endregion

                    if (model.Inspection == 2)
                    {
                        await sendMail(response.Id, response.ObjectNumber, model.InspectionAssigneeMail, TextConsts.inspectionManage, model.NoteCrm, model.CreatorName, "", model.CreatorId);
                        if (model.SendNotify.GetValueOrDefault()) { await sendNotification(response.Id, response.ObjectNumber, model.InspectionAssigneeId,TextConsts.inspectionManage); }

                    }
                }

                

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }



        #endregion

        #region Object
        [HttpPost("GetPreventiviObjectsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectAsync(PreventiviObjectDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectAsync(model);

                var history = new PreventiviObjectHistoryDto();
                history.ObjectId = response;
                history.AssigneeId = model.AssigneeId;
                history.AssigneeDesc = model.AssigneeMail;
                history.DateStart = DateTime.Now;
                history.Status = model.Status;


                var regHistory = await _gaPreventiviService.CreatePreventiviObjectHistoryAsync(history);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectAsync(long id, [FromBody]PreventiviObjectDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectAsync(id,model);



                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        #region Functions
        [HttpPut("UpdatePreventiviObjectAssigneeAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectAssigneeAsync(long id, [FromBody] PreventiviObjectDto model)
        {
            try
            {
                var requestLast = new PageRequest();
                requestLast.Filter = $"ObjectId eq {model.Id}";
                requestLast.OrderBy = "DateStart desc";
                requestLast.Take = 1;
                var historyLast = _gaPreventiviService.GetPreventiviObjectHistoriesAsync(requestLast).Result.Items.FirstOrDefault();
                historyLast.DateEnd = DateTime.Now;
                await _gaPreventiviService.UpdatePreventiviObjectHistoryAsync(historyLast.Id,historyLast);

                var response = await _gaPreventiviService.UpdatePreventiviObjectAssigneeAsync(id, model);

                var history = new PreventiviObjectHistoryDto();
                history.ObjectId = model.Id;
                history.AssigneeId = model.AssigneeId;
                history.AssigneeDesc = model.AssigneeMail;
                history.DateStart = DateTime.Now;
                history.StatusId = model.StatusId;
                history.Note = model.Note;


                var regHistory = await _gaPreventiviService.CreatePreventiviObjectHistoryAsync(history);



                if (model.SendEmail.GetValueOrDefault()) { await sendMail(model.Id, model.ObjectNumber, model.AssigneeMail, TextConsts.objectManage, model.NoteCrm, model.CreatorName, "", model.CreatorId); }
                if (model.SendNotify.GetValueOrDefault()) { await sendNotification(model.Id, model.ObjectNumber, model.AssigneeId, TextConsts.objectManage); }


                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectContactDetailsAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectContactDetailsAsync(long id, [FromBody] PreventiviObjectDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectContactDetailsAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectOperativeDetailsAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectOperativeDetailsAsync(long id, [FromBody] PreventiviObjectDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectOperativeDetailsAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectTypeDetailsAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectTypeDetailsAsync(long id, [FromBody] PreventiviObjectDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectTypeDetailsAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectCliSedAsync/{codCom}/{codCli}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectCliSedAsync(string codCom, string codCli)
        {
            try
            {
                var query = System.IO.File.ReadAllText(@".\Query\Preventivi\ObjectCliSed.sql");
                query = string.Format(query, codCom, codCli);

                var response = await _queryBuilderService.GetFromQueryAsync(query);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectCliSpedAsync/{codCom}/{codCli}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectCliSpedAsync(string codCom, string codCli)
        {
            try
            {
                var query = System.IO.File.ReadAllText(@".\Query\Preventivi\ObjectCliSped.sql");
                query = string.Format(query, codCom, codCli);

                var response = await _queryBuilderService.GetFromQueryAsync(query);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("PrintPreventiviObjectByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> PrintPreventiviObjectByIdAsync(long id)
        {
            try
            {
                var _object = await _gaPreventiviService.GetPreventiviObjectByIdAsync(id);
                var _objectInspection = await _gaPreventiviService.GetPreventiviObjectInspectionsAsync(new PageRequest() { Filter = $"objectId eq {id}" });
                var _objectPayout = await _gaPreventiviService.GetPreventiviObjectPayoutsAsync(new PageRequest() { Filter = $"objectId eq {id}", Expand = "Period,BankAccount" });
                var _objectSections = await _gaPreventiviService.GetPreventiviObjectSectionsAsync(new PageRequest() { Filter = $"objectId eq {id}", Expand = "Producer,Destination" });
                var _objectService = await _gaPreventiviService.GetPreventiviObjectServicesAsync(new PageRequest() { Filter = $"objectId eq {id}", Expand = "ServiceType,ServiceTypeDetail,IvaCode" });
                var _objectConditions = await _gaPreventiviService.GetPreventiviObjectConditionsAsync(new PageRequest() { Filter = $"objectId eq {id}" });
                var _garbages = await _gaPreventiviService.GetPreventiviGarbagesAsync(new PageRequest());
                var _gauges = await _commonService.GetCommonGaugesAsync(new PageRequest());

                // Validazione dei dati
                var validationErrors = new List<string>();
                if (_object == null) validationErrors.Add("Oggetto principale non definito.");
                if (!_objectInspection.Items.Any()) validationErrors.Add("Sopralluogo mancante.");
                if (!_objectPayout.Items.Any()) validationErrors.Add("Condizioni di pagamento mancanti.");
                if (!_objectSections.Items.Any()) validationErrors.Add("Servizio mancante.");
                if (!_objectService.Items.Any()) validationErrors.Add("Dettagli servizi mancanti.");
                if (!_objectConditions.Items.Any()) validationErrors.Add("Condizioni contrattuali mancanti.");

                if (validationErrors.Any())
                {
                    var res = new
                    {
                        Code = code.Status409Conflict, // Assicurati che sia un valore numerico
                        Response = string.Join(" ; ", validationErrors.Where(x => x != null && x.Any()).ToList())
                        
                    };

                    return Ok(res);
                }


                // Genera il template con i dati
                var dto = await generatePreventiviObjectTemplate(
                    _object,
                    _objectInspection.Items.FirstOrDefault(),
                    _objectPayout.Items.FirstOrDefault(),
                    _objectSections.Items.ToList(),
                    _objectService.Items.ToList(),
                    _objectConditions.Items.ToList(),
                    _garbages.Items.ToList(),
                    _gauges.Items.ToList(),
                    "Preventivo"
                );

                // Stampa il documento
                var response = await _printService.Print("PreventiviObjectDefault", dto);

                return Ok(new { Code = code.Status200OK, Response = response });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new { Code = code.Status400BadRequest, Response = "Si è verificato un errore interno" });
            }
        }


        #endregion

        #endregion

        #region ObjectAttachment
        [HttpPost("GetPreventiviObjectAttachmentsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectAttachmentsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectAttachmentsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectAttachmentByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectAttachmentByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectAttachmentByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectAttachmentAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectAttachmentAsync([FromForm]PreventiviObjectAttachmentDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectAttachmentAsync(model);

                if (model.uploadFile)
                {
                    var fileModel = model.ToCreateFileModel(response, model.FileName, basePath, "Object");

                    var fileData = blfh.CreateFileData(fileModel.File, response.ToString(), fileModel.FileFolder);
                    var fileUploadResponse = await _fileService.Upload(fileData);

                    if (fileUploadResponse!=null)
                    {
                        fileModel.FileId = fileUploadResponse.id;
                        await _gaPreventiviService.UpdatePreventiviObjectAttachmentAsync(fileModel.Id, fileModel);
                        return Ok(new { Code = code.Status201Created, Response = response });
                    }
                    else
                    {
                        return Ok(new { Code = code.Status206PartialContent, Response = response });
                    }


                }
                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectAttachmentAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status207MultiStatus)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectAttachmentAsync(long id, [FromForm] PreventiviObjectAttachmentDto model)
        {
            try
            {
                bool failureDelete = false;
                var response = await _gaPreventiviService.UpdatePreventiviObjectAttachmentAsync(id, model);



                if (model.deleteFile)
                {
                    var fileData = blfh.DeleteFileData(model.FileId, model.FileFolder);
                    var fileDeleteResponse = await _fileService.Remove(model.FileId);

                    var fileModel = model.ToDeleteFileModel<PreventiviObjectAttachmentDto>();

                    if (fileDeleteResponse)
                    {
                        await _gaPreventiviService.UpdatePreventiviObjectAttachmentAsync(fileModel.Id, fileModel);
                    }
                    else
                    {
                        failureDelete = true;
                    }
                }

                if (model.uploadFile)
                {
                    var fileModel = model.ToCreateFileModel<PreventiviObjectAttachmentDto>(response, model.FileName, basePath, "ObjectInspection");

                    var fileData = blfh.CreateFileData(fileModel.File, id.ToString(), fileModel.FileFolder);
                    var fileUploadResponse = await _fileService.Upload(fileData);

                    if (fileUploadResponse!=null)
                    {
                        fileModel.FileId = fileUploadResponse.id;
                        await _gaPreventiviService.UpdatePreventiviObjectAttachmentAsync(fileModel.Id, fileModel);
                        if (failureDelete)
                        {
                            return Ok(new { Code = code.Status207MultiStatus, Response = response });
                        }
                        else
                        {
                            return Ok(new { Code = code.Status204NoContent, Response = response });
                        }

                    }
                    else
                    {
                        return Ok(new { Code = code.Status206PartialContent, Response = response });
                    }
                }

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectAttachmentAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectAttachmentAsync(long id)
        {
            try
            {
                var model=await _gaPreventiviService.GetPreventiviObjectAttachmentByIdAsync(id);
                var fileDeleteResponse = await _fileService.Remove(model.FileId);
                if (fileDeleteResponse)
                {
                    var response = await _gaPreventiviService.DeletePreventiviObjectAttachmentAsync(id);

                    return Ok(new { Code = code.Status200OK, Response = response });
                }
                else
                {
                    var response = await _gaPreventiviService.DeletePreventiviObjectAttachmentAsync(id);

                    return Ok(new { Code = code.Status206PartialContent, Response = response });
                }

                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectType
        [HttpPost("GetPreventiviObjectTypesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectTypesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectTypesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectTypeByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectTypeByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectTypeByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectTypeAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectTypeAsync(PreventiviObjectTypeDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectTypeAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectTypeAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectTypeAsync(long id, [FromBody] PreventiviObjectTypeDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectTypeAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectTypeAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectTypeAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectTypeAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectStatuses
        [HttpPost("GetPreventiviObjectStatusesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectStatusesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectStatusesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectStatusByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectStatusByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectStatusByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectStatusAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectStatusAsync(PreventiviObjectStatusDto model)
        {
            try
            {
                model.Order = 999;
                var response = await _gaPreventiviService.CreatePreventiviObjectStatusAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectStatusAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectStatusAsync(long id, [FromBody] PreventiviObjectStatusDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectStatusAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectStatusAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectStatusAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectStatusAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectInspectionMode
        [HttpPost("GetPreventiviObjectInspectionModesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionModesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionModesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectInspectionModeByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionModeByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionModeByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectInspectionModeAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectInspectionModeAsync(PreventiviObjectInspectionModeDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectInspectionModeAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectInspectionModeAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectInspectionModeAsync(long id, [FromBody] PreventiviObjectInspectionModeDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectInspectionModeAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectInspectionModeAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectInspectionModeAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectInspectionModeAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectInspection
        [HttpPost("GetPreventiviObjectInspectionsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectInspectionByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectInspectionAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectInspectionAsync(PreventiviObjectInspectionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectInspectionAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectInspectionAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectInspectionAsync(long id, [FromBody] PreventiviObjectInspectionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectInspectionAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectInspectionAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectInspectionAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectInspectionAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }


        #region Functions
        [HttpPut("UpdatePreventiviObjectInspectionStatementAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectInspectionStatementAsync(long id, [FromBody] PreventiviObjectInspectionStatementDto model)
        {
            try
            {
                if (model.SendManager.GetValueOrDefault())
                {
                    await sendMail(model.Id, model.ObjectNumber, model.AssigneeMail, TextConsts.inspectionUpdated, model.Note, model.NoteInspection, model.CreatorName, model.CreatorId);
                    await sendNotification(model.Id, model.ObjectNumber, model.AssigneeId, TextConsts.inspectionUpdated);
                }

                if (model.SendInspector.GetValueOrDefault())
                {
                    await sendMail(model.Id, model.ObjectNumber, model.InspectionAssigneeMail, TextConsts.inspectionUpdated, model.Note, model.NoteInspection, model.CreatorName, model.CreatorId);
                    await sendNotification(model.Id, model.ObjectNumber, model.InspectionAssigneeId, TextConsts.inspectionUpdated);
                }


                return Ok(new { Code = code.Status204NoContent, Response = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("PrintPreventiviObjectInspectionByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> PrintPreventiviObjectInspectionByIdAsync(long id)
        {
            try
            {
                var _object = await _gaPreventiviService.GetPreventiviObjectByIdAsync(id);
                var _objectInspection = _gaPreventiviService.GetPreventiviObjectInspectionsAsync(new PageRequest() { Filter = $"objectId eq {id}" }).Result.Items.FirstOrDefault();

                var user = await _userManager.FindByIdAsync(_objectInspection.AssigneeId);

                _objectInspection.AssigneeId = user.NormalizedUserName.Replace(".", " ");

                var dto = await generatePreventiviObjectTemplate(_object,
                    _objectInspection,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    "Preventivo");
                var response = await _printService.Print("PreventiviObjectInspectionDefault", dto);

                return Ok(new { Code = code.Status200OK, Response = response });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        #endregion

        #endregion

        #region ObjectInspectionAttachment
        [HttpPost("GetPreventiviObjectInspectionAttachmentsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionAttachmentsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionAttachmentsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectInspectionAttachmentByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionAttachmentByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionAttachmentByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectInspectionAttachmentAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectInspectionAttachmentAsync([FromForm] PreventiviObjectInspectionAttachmentDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectInspectionAttachmentAsync(model);

                if (model.uploadFile)
                {
                    var fileModel = model.ToCreateFileModel(response, model.FileName, basePath, "ObjectInspection");

                    var fileData = blfh.CreateFileData(fileModel.File, response.ToString(), fileModel.FileFolder);
                    var fileUploadResponse = await _fileService.Upload(fileData);

                    if (fileUploadResponse != null)
                    {
                        fileModel.FileId = fileUploadResponse.id;
                        await _gaPreventiviService.UpdatePreventiviObjectInspectionAttachmentAsync(fileModel.Id, fileModel);
                        return Ok(new { Code = code.Status201Created, Response = response });
                    }
                    else
                    {
                        return Ok(new { Code = code.Status206PartialContent, Response = response });
                    }


                }
                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectInspectionAttachmentAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status207MultiStatus)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectInspectionAttachmentAsync(long id, [FromForm] PreventiviObjectInspectionAttachmentDto model)
        {
            try
            {
                bool failureDelete = false;
                var response = await _gaPreventiviService.UpdatePreventiviObjectInspectionAttachmentAsync(id, model);



                if (model.deleteFile)
                {
                    var fileData = blfh.DeleteFileData(model.FileId, model.FileFolder);
                    var fileDeleteResponse = await _fileService.Remove(model.FileId);

                    var fileModel = model.ToDeleteFileModel<PreventiviObjectInspectionAttachmentDto>();

                    if (fileDeleteResponse)
                    {
                        await _gaPreventiviService.UpdatePreventiviObjectInspectionAttachmentAsync(fileModel.Id, fileModel);
                    }
                    else
                    {
                        failureDelete = true;
                    }
                }

                if (model.uploadFile)
                {
                    var fileModel = model.ToCreateFileModel<PreventiviObjectInspectionAttachmentDto>(response, model.FileName, basePath, "ObjectInspection");

                    var fileData = blfh.CreateFileData(fileModel.File, id.ToString(), fileModel.FileFolder);
                    var fileUploadResponse = await _fileService.Upload(fileData);

                    if (fileUploadResponse != null)
                    {
                        fileModel.FileId = fileUploadResponse.id;
                        await _gaPreventiviService.UpdatePreventiviObjectInspectionAttachmentAsync(fileModel.Id, fileModel);
                        if (failureDelete)
                        {
                            return Ok(new { Code = code.Status207MultiStatus, Response = response });
                        }
                        else
                        {
                            return Ok(new { Code = code.Status204NoContent, Response = response });
                        }

                    }
                    else
                    {
                        return Ok(new { Code = code.Status206PartialContent, Response = response });
                    }
                }

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectInspectionAttachmentAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectInspectionAttachmentAsync(long id)
        {
            try
            {
                var model = await _gaPreventiviService.GetPreventiviObjectInspectionAttachmentByIdAsync(id);
                var fileDeleteResponse = await _fileService.Remove(model.FileId);
                if (fileDeleteResponse)
                {
                    var response = await _gaPreventiviService.DeletePreventiviObjectInspectionAttachmentAsync(id);

                    return Ok(new { Code = code.Status200OK, Response = response });
                }
                else
                {
                    var response = await _gaPreventiviService.DeletePreventiviObjectInspectionAttachmentAsync(id);

                    return Ok(new { Code = code.Status206PartialContent, Response = response });
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectInspectionImage
        [HttpPost("GetPreventiviObjectInspectionImagesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionImagesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionImagesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectInspectionImageByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectInspectionImageByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectInspectionImageByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectInspectionImageAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectInspectionImageAsync([FromForm] PreventiviObjectInspectionImageDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectInspectionImageAsync(model);

                if (model.uploadFile)
                {
                    var fileModel = model.ToCreateFileModel(response, model.FileName, basePath, "ObjectInspection");

                    var fileData = blfh.CreateFileData(fileModel.File, response.ToString(), fileModel.FileFolder);
                    var fileUploadResponse = await _fileService.Upload(fileData);

                    if (fileUploadResponse != null)
                    {
                        fileModel.FileId = fileUploadResponse.id;
                        await _gaPreventiviService.UpdatePreventiviObjectInspectionImageAsync(fileModel.Id, fileModel);
                        return Ok(new { Code = code.Status201Created, Response = response });
                    }
                    else
                    {
                        return Ok(new { Code = code.Status206PartialContent, Response = response });
                    }


                }
                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectInspectionImageAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status207MultiStatus)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectInspectionImageAsync(long id, [FromForm] PreventiviObjectInspectionImageDto model)
        {
            try
            {
                bool failureDelete = false;
                var response = await _gaPreventiviService.UpdatePreventiviObjectInspectionImageAsync(id, model);



                if (model.deleteFile)
                {
                    var fileData = blfh.DeleteFileData(model.FileId, model.FileFolder);
                    var fileDeleteResponse = await _fileService.Remove(model.FileId);

                    var fileModel = model.ToDeleteFileModel<PreventiviObjectInspectionImageDto>();

                    if (fileDeleteResponse)
                    {
                        await _gaPreventiviService.UpdatePreventiviObjectInspectionImageAsync(fileModel.Id, fileModel);
                    }
                    else
                    {
                        failureDelete = true;
                    }
                }

                if (model.uploadFile)
                {
                    var fileModel = model.ToCreateFileModel<PreventiviObjectInspectionImageDto>(response, model.FileName, basePath, "ObjectInspection");

                    var fileData = blfh.CreateFileData(fileModel.File, id.ToString(), fileModel.FileFolder);
                    var fileUploadResponse = await _fileService.Upload(fileData);

                    if (fileUploadResponse != null)
                    {
                        fileModel.FileId = fileUploadResponse.id;
                        await _gaPreventiviService.UpdatePreventiviObjectInspectionImageAsync(fileModel.Id, fileModel);
                        if (failureDelete)
                        {
                            return Ok(new { Code = code.Status207MultiStatus, Response = response });
                        }
                        else
                        {
                            return Ok(new { Code = code.Status204NoContent, Response = response });
                        }

                    }
                    else
                    {
                        return Ok(new { Code = code.Status206PartialContent, Response = response });
                    }
                }

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectInspectionImageAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status206PartialContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectInspectionImageAsync(long id)
        {
            try
            {
                var model = await _gaPreventiviService.GetPreventiviObjectInspectionImageByIdAsync(id);
                var fileDeleteResponse = await _fileService.Remove(model.FileId);
                if (fileDeleteResponse)
                {
                    var response = await _gaPreventiviService.DeletePreventiviObjectInspectionImageAsync(id);

                    return Ok(new { Code = code.Status200OK, Response = response });
                }
                else
                {
                    var response = await _gaPreventiviService.DeletePreventiviObjectInspectionImageAsync(id);

                    return Ok(new { Code = code.Status206PartialContent, Response = response });
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region Financial
        [HttpGet("GetPreventiviSubjectFinancialPositionAsync/{cf}/{piva}/{cf2}/{piva2}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviSubjectFinancialPositionAsync(string cf,string piva, string cf2,string piva2)
        {
            try
            {
                var query= System.IO.File.ReadAllText(@".\Query\Preventivi\FinancialPosition.sql");
                query = string.Format(query, cf, piva,cf2,piva2);

                var response = await _queryBuilderService.GetFromQueryAsync(query);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("RequestPreventiviSubjectFinancialUnlockAsync")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> RequestPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model)
        {
            try
            {
                await _gaPreventiviService.RequestPreventiviSubjectFinancialUnlockAsync(model);
                await sendMail(model.Id,model.ObjectNumber, "federico.laigueglia@gestioneambiente.net", TextConsts.financialUnlockRequest,"", model.CreatorName,"",model.CreatorId);

                return Ok(new { Code = code.Status204NoContent, Response = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("ExecPreventiviSubjectFinancialUnlockAsync")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> ExecPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model)
        {
            try
            {
                await _gaPreventiviService.ExecPreventiviSubjectFinancialUnlockAsync(model);
                await sendMail(model.Id,model.ObjectNumber, model.AssigneeMail, TextConsts.financialUnlockExec, "", model.CreatorName, "", model.CreatorId);

                return Ok(new { Code = code.Status204NoContent, Response = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("ExecPreventiviSubjectFinancialLockAsync")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> ExecPreventiviSubjectFinancialLockAsync(PreventiviSubjectFinancialDto model)
        {
            try
            {
                await _gaPreventiviService.ExecPreventiviSubjectFinancialLockAsync(model);
                await sendMail(model.Id, model.ObjectNumber, model.AssigneeMail, TextConsts.financialLockExec, "", model.CreatorName, "", model.CreatorId);

                return Ok(new { Code = code.Status204NoContent, Response = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region Action
        [HttpPost("GetPreventiviActionsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviActionsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviActionsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviActionByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviActionByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviActionByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviActionAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviActionAsync(PreventiviActionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviActionAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviActionAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviActionAsync(long id, [FromBody] PreventiviActionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviActionAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviActionAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviActionAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviActionAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectSection
        [HttpPost("GetPreventiviObjectSectionsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectSectionsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectSectionsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectSectionByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectSectionByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectSectionByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectSectionAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectSectionAsync(PreventiviObjectSectionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectSectionAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectSectionAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectSectionAsync(long id, [FromBody] PreventiviObjectSectionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectSectionAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectSectionAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectSectionAsync(long id)
        {
            try
            {
                var services = await _gaPreventiviService.GetPreventiviObjectServicesAsync(new PageRequest() { Filter = $"sectionId eq {id}" });
                foreach (var service in services.Items)
                {
                    await _gaPreventiviService.DeletePreventiviObjectServiceAsync(service.Id);
                }

                var response = await _gaPreventiviService.DeletePreventiviObjectSectionAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        #region Functions
        [HttpPost("ChangeOrderPreventiviObjectSectionAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> ChangeOrderPreventiviObjectSectionAsync([FromBody] List<PreventiviObjectSectionDto> model)
        {
            try
            {
                var response = await _gaPreventiviService.ChangeOrderPreventiviObjectSectionAsync(model);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #endregion

        #region ObjectServiceType
        [HttpPost("GetPreventiviObjectServiceTypesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectServiceTypesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectServiceTypesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectServiceTypeByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectServiceTypeByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectServiceTypeByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectServiceTypeAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectServiceTypeAsync(PreventiviObjectServiceTypeDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectServiceTypeAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectServiceTypeAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectServiceTypeAsync(long id, [FromBody] PreventiviObjectServiceTypeDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectServiceTypeAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectServiceTypeAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectServiceTypeAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectServiceTypeAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                if (ex.InnerException is SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        return Ok(new { Code = code.Status409Conflict, Response = "Cannot delete this item because it is referenced by another entity." });
                    }
                }
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectServiceTypeDetail
        [HttpPost("GetPreventiviObjectServiceTypeDetailsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectServiceTypeDetailsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectServiceTypeDetailsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectServiceTypeDetailByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectServiceTypeDetailByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectServiceTypeDetailByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectServiceTypeDetailAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectServiceTypeDetailAsync(PreventiviObjectServiceTypeDetailDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectServiceTypeDetailAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectServiceTypeDetailAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectServiceTypeDetailAsync(long id, [FromBody] PreventiviObjectServiceTypeDetailDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectServiceTypeDetailAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectServiceTypeDetailAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectServiceTypeDetailAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectServiceTypeDetailAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectService
        [HttpPost("GetPreventiviObjectServicesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectServicesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectServicesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectServiceByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectServiceByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectServiceByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectServiceAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectServiceAsync(PreventiviObjectServiceDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectServiceAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectServiceAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectServiceAsync(long id, [FromBody] PreventiviObjectServiceDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectServiceAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectServiceAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectServiceAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectServiceAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        #region Functions
        [HttpPost("ChangeOrderPreventiviObjectServiceAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> ChangeOrderPreventiviObjectServiceAsync([FromBody] List<PreventiviObjectServiceDto> model)
        {
            try
            {
                var response = await _gaPreventiviService.ChangeOrderPreventiviObjectServiceAsync(model);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #endregion

        #region Garbage
        [HttpPost("GetPreventiviGarbagesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviGarbagesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviGarbagesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviGarbageByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviGarbageByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviGarbageByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviGarbageAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviGarbageAsync(PreventiviGarbageDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviGarbageAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviGarbageAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviGarbageAsync(long id, [FromBody] PreventiviGarbageDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviGarbageAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviGarbageAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviGarbageAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviGarbageAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ServiceNoteTemplate
        [HttpPost("GetPreventiviServiceNoteTemplatesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviServiceNoteTemplatesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviServiceNoteTemplatesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviServiceNoteTemplateByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviServiceNoteTemplateByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviServiceNoteTemplateByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviServiceNoteTemplateAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviServiceNoteTemplateAsync(PreventiviServiceNoteTemplateDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviServiceNoteTemplateAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviServiceNoteTemplateAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviServiceNoteTemplateAsync(long id, [FromBody] PreventiviServiceNoteTemplateDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviServiceNoteTemplateAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviServiceNoteTemplateAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviServiceNoteTemplateAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviServiceNoteTemplateAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ConditionTemplate
        [HttpPost("GetPreventiviConditionTemplatesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviConditionTemplatesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviConditionTemplatesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviConditionTemplateByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviConditionTemplateByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviConditionTemplateByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviConditionTemplateAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviConditionTemplateAsync(PreventiviConditionTemplateDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviConditionTemplateAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviConditionTemplateAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviConditionTemplateAsync(long id, [FromBody] PreventiviConditionTemplateDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviConditionTemplateAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviConditionTemplateAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviConditionTemplateAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviConditionTemplateAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectPeriod
        [HttpPost("GetPreventiviObjectPeriodsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectPeriodsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectPeriodsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectPeriodByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectPeriodByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectPeriodByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectPeriodAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectPeriodAsync(PreventiviObjectPeriodDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectPeriodAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectPeriodAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectPeriodAsync(long id, [FromBody] PreventiviObjectPeriodDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectPeriodAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectPeriodAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectPeriodAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectPeriodAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectPayout
        [HttpPost("GetPreventiviObjectPayoutsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectPayoutsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectPayoutsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectPayoutByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectPayoutByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectPayoutByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectPayoutAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectPayoutAsync(PreventiviObjectPayoutDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectPayoutAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectPayoutAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectPayoutAsync(long id, [FromBody] PreventiviObjectPayoutDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectPayoutAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectPayoutAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectPayoutAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectPayoutAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectCondition
        [HttpPost("GetPreventiviObjectConditionsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectConditionsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectConditionsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectConditionByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectConditionByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectConditionByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectConditionAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectConditionAsync(PreventiviObjectConditionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectConditionAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectConditionAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectConditionAsync(long id, [FromBody] PreventiviObjectConditionDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectConditionAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectConditionAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectConditionAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectConditionAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        #region Functions
        [HttpPost("ChangeOrderPreventiviObjectConditionAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> ChangeOrderPreventiviObjectConditionAsync([FromBody] List<PreventiviObjectConditionDto> model)
        {
            try
            {
                var response = await _gaPreventiviService.ChangeOrderPreventiviObjectConditionAsync(model);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #endregion

        #region Destination
        [HttpPost("GetPreventiviDestinationsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviDestinationsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviDestinationsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviDestinationByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviDestinationByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviDestinationByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviDestinationAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviDestinationAsync(PreventiviDestinationDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviDestinationAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviDestinationAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviDestinationAsync(long id, [FromBody] PreventiviDestinationDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviDestinationAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviDestinationAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviDestinationAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviDestinationAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region Producer
        [HttpPost("GetPreventiviProducersAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviProducersAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviProducersAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviProducerByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviProducerByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviProducerByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviProducerAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviProducerAsync(PreventiviProducerDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviProducerAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviProducerAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviProducerAsync(long id, [FromBody] PreventiviProducerDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviProducerAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviProducerAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviProducerAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviProducerAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region ObjectHistories
        [HttpPost("GetPreventiviObjectHistoriesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectHistoriesAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectHistoriesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviObjectHistoryByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviObjectHistoryByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviObjectHistoryByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviObjectHistoryAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviObjectHistoryAsync(PreventiviObjectHistoryDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviObjectHistoryAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviObjectHistoryAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviObjectHistoryAsync(long id, [FromBody] PreventiviObjectHistoryDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviObjectHistoryAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviObjectHistoryAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviObjectHistoryAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviObjectHistoryAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region PaymentTerms
        [HttpPost("GetPreventiviPaymentTermsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviPaymentTermsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviPaymentTermsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetPreventiviPaymentTermByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetPreventiviPaymentTermByIdAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.GetPreventiviPaymentTermByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreatePreventiviPaymentTermAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreatePreventiviPaymentTermAsync(PreventiviPaymentTermDto model)
        {
            try
            {
                var response = await _gaPreventiviService.CreatePreventiviPaymentTermAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdatePreventiviPaymentTermAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdatePreventiviPaymentTermAsync(long id, [FromBody] PreventiviPaymentTermDto model)
        {
            try
            {
                var response = await _gaPreventiviService.UpdatePreventiviPaymentTermAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeletePreventiviPaymentTermAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeletePreventiviPaymentTermAsync(long id)
        {
            try
            {
                var response = await _gaPreventiviService.DeletePreventiviPaymentTermAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region Ismart Documenti
        [HttpPost("GetViewPreventiviIsmartDocumentiAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetViewPreventiviIsmartDocumentiAsync(PageRequest request)
        {
            try
            {
                var response = await _gaPreventiviService.GetViewPreventiviIsmartDocumentiAsync(request);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion



        #region Helpers
        private async Task<bool> sendMail(long id, string number,string mail, string type, string note, string noteIspection,string creator,string creatorId)
        {
            var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.Preventivi, AppConsts.PreventiviInfo);
            var notifications = await _notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(notificationApp.Id);

            var mailJob = await _mailService.AddMailJobAsync(new MailJob()
            {
                Id = 0,
                Description = "Assegnazione Preventivo N° " + number,
                DateScheduled = DateTime.Now,
                Title = "Preventivo N° " + number,
                MailingTo = mail,
                MailCc = "",
                Application = String.Format("{0}|{1}", notificationApp.Id, AppConsts.Preventivi),
                Content = HtmlHelpers.GenerateText(type+"<br>Note Preliminari: " + note + "<br>"  +"Note Sopralluogo: " + noteIspection + "<br>" + creator + ""),
                Link = true,
                LinkHref = String.Format("https://cloud.gestioneambiente.net/preventivi/tab/object/{0}", id),
                LinkDescription = "Vai al preventivo",
                Template = "DefaultMailWithLinkJob.html",
                UserId = creatorId,
                OkMessage = String.Format("L'assegnazione del Preventivo N° {0} è stata inoltrata correttamente.", number),
                KoMessage = String.Format("Si è verificato un problema durante l'invio dell'assegnazione del Preventivo N° {0}.", number),
                Attachment = false,
                AttachmentPath = null
            });

            return true;

        }

        private async Task<bool> sendNotification(long id,string number,string assigneeId,string type)
        {
            var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.Preventivi, AppConsts.PreventiviInfo);
            var assigneeNotification = _notificationService.GetViewViewNotificationUsersOnAppsByUserIdAsync(assigneeId).Result;
            if ((from x in assigneeNotification.Data where x.AppId == notificationApp.Id && x.Enabled select x).ToList().Count > 0)
            {
                var notification = _notificationService.AddNotificationEventAsync(new NotificationEventDto()
                {
                    Id = 0,
                    DateEvent = DateTime.Now,
                    UserId = assigneeId,
                    NotificationAppId = notificationApp.Id,
                    Title = "Preventivo N° " + number,
                    Message = type,
                    Read = false,
                    Routing = false,
                    Link = String.Format("/preventivi/tab/object/{0}", id),
                    Disabled = false
                }).Result;
            }

            return true;

        }

        private async Task<PreventiviObjectTemplateDto> generatePreventiviObjectTemplate(
            PreventiviObjectDto preventiviObject,
            PreventiviObjectInspectionDto preventiviObjectInspection,
            PreventiviObjectPayoutDto preventiviObjectPayout,
            List<PreventiviObjectSectionDto> preventiviObjectSections,
            List<PreventiviObjectServiceDto> preventiviObjectServices,
            List<PreventiviObjectConditionDto> preventiviObjectConditions,
            List<PreventiviGarbageDto> preventiviGarbages,
            List<CommonGaugeDto> commonGauges,
            string title, string fileName = "PreventiviObjectDefault.pdf", string css = "PreventiviObjectDefault")
        {
            var dto = new PreventiviObjectTemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/Preventivi",
                Title = title,
                Css = css,
                HeaderSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = $"#{preventiviObject.ObjectNumber}", Line = true },
                FooterSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true, Center = "Gestione Ambiente S.p.A." },
                Copies = 1,
                preventiviObject = preventiviObject,
                preventiviObjectInspection= preventiviObjectInspection,
                preventiviObjectPayout=preventiviObjectPayout,
                preventiviObjectSections= preventiviObjectSections,
                preventiviObjectServices= preventiviObjectServices,
                preventiviObjectConditions= preventiviObjectConditions,
                preventiviGarbages = preventiviGarbages,
                commonGauges= commonGauges

            };

            return dto;
        }

        #endregion

    }

    static class TextConsts
    {
        public const string objectManage = "Ti è stato assegnato un Preventivo.";
        public const string inspectionManage = "Ti è stato assegnato un Sopralluogo.";

        public const string inspectionUpdated = "Sono stati aggiornati i dati su un sopralluogo.";

        public const string financialUnlockRequest = "É stato rischiesto lo sblocco del cliente per poter procedere il lavoro sul preventivo in oggetto";
        public const string financialUnlockExec = "É stato sbloccato il cliente sul Preventivo in oggetto, è ora possibile procedere con l'elaborazione";
        public const string financialLockExec = "É stato bloccato il cliente sul Preventivo in oggetto, non è pertanto possibile procedere con l'avanzamento dei lavori";

    }
}



