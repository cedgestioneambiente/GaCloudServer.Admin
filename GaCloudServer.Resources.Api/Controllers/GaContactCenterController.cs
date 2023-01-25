using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Constants;
using GaCloudServer.Resources.Api.Dtos.Aziende;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter.ContactCenterAllegatoApiDto;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaContactCenterController : Controller
    {
        private readonly IGaContactCenterService _gaContactCenterService;
        private readonly IGaAziendeService _gaAziendeService;
        private readonly IFileService _fileService;
        private readonly IPrintService _printService;
        private readonly IMailService _mailService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<GaContactCenterController> _logger;
        private readonly CultureInfo itIT = new CultureInfo("it-IT");

        public GaContactCenterController(
            IGaContactCenterService gaContactCenterService,
            IGaAziendeService gaAziendeService
            ,IFileService fileService
            ,IPrintService printService
            ,IMailService mailService
            ,INotificationService notificationService
            ,ILogger<GaContactCenterController> logger)
        {

            _gaContactCenterService = gaContactCenterService;
            _gaAziendeService = gaAziendeService;
            _fileService = fileService;
            _printService = printService;
            _mailService = mailService;
            _notificationService= notificationService;
            _logger = logger;
        }


        #region ContactCenterComuni
        [HttpGet("GetGaContactCenterComuniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterComuniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterComuniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterComuniApiDto, ContactCenterComuniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterComuneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterComuneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterComuneByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterComuneApiDto, ContactCenterComuneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContactCenterComuneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContactCenterComuneAsync([FromBody] ContactCenterComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterComuneDto, ContactCenterComuneApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterComuneAsync(dto);

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

        [HttpPost("UpdateGaContactCenterComuneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterComuneAsync([FromBody] ContactCenterComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterComuneDto, ContactCenterComuneApiDto>();
                var response = await _gaContactCenterService.UpdateGaContactCenterComuneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContactCenterComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterComuneAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterComuneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContactCenterComuneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterComuneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContactCenterService.ValidateGaContactCenterComuneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContactCenterComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterComuneAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.ChangeStatusGaContactCenterComuneAsync(id);
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

        #region ContactCenterProvenienze
        [HttpGet("GetGaContactCenterProvenienzeAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterProvenienzeAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterProvenienzeAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterProvenienzeApiDto, ContactCenterProvenienzeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterProvenienzaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterProvenienzaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterProvenienzaByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterProvenienzaApiDto, ContactCenterProvenienzaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContactCenterProvenienzaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContactCenterProvenienzaAsync([FromBody] ContactCenterProvenienzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterProvenienzaDto, ContactCenterProvenienzaApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterProvenienzaAsync(dto);

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

        [HttpPost("UpdateGaContactCenterProvenienzaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterProvenienzaAsync([FromBody] ContactCenterProvenienzaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterProvenienzaDto, ContactCenterProvenienzaApiDto>();
                var response = await _gaContactCenterService.UpdateGaContactCenterProvenienzaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContactCenterProvenienzaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterProvenienzaAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterProvenienzaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContactCenterProvenienzaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterProvenienzaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContactCenterService.ValidateGaContactCenterProvenienzaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContactCenterProvenienzaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterProvenienzaAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.ChangeStatusGaContactCenterProvenienzaAsync(id);
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

        #region ContactCenterStatiRichieste
        [HttpGet("GetGaContactCenterStatiRichiesteAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterStatiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterStatiRichiesteAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterStatiRichiesteApiDto, ContactCenterStatiRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterStatoRichiestaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterStatoRichiestaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterStatoRichiestaByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterStatoRichiestaApiDto, ContactCenterStatoRichiestaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContactCenterStatoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContactCenterStatoRichiestaAsync([FromBody] ContactCenterStatoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterStatoRichiestaDto, ContactCenterStatoRichiestaApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterStatoRichiestaAsync(dto);

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

        [HttpPost("UpdateGaContactCenterStatoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterStatoRichiestaAsync([FromBody] ContactCenterStatoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterStatoRichiestaDto, ContactCenterStatoRichiestaApiDto>();
                var response = await _gaContactCenterService.UpdateGaContactCenterStatoRichiestaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContactCenterStatoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterStatoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterStatoRichiestaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContactCenterStatoRichiestaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterStatoRichiestaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContactCenterService.ValidateGaContactCenterStatoRichiestaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContactCenterStatoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterStatoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.ChangeStatusGaContactCenterStatoRichiestaAsync(id);
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

        #region ContactCenterTipiRichieste
        [HttpGet("GetGaContactCenterTipiRichiesteAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterTipiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterTipiRichiesteAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterTipiRichiesteApiDto, ContactCenterTipiRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterTipoRichiestaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterTipoRichiestaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterTipoRichiestaByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterTipoRichiestaApiDto, ContactCenterTipoRichiestaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContactCenterTipoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContactCenterTipoRichiestaAsync([FromBody] ContactCenterTipoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterTipoRichiestaDto, ContactCenterTipoRichiestaApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterTipoRichiestaAsync(dto);

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

        [HttpPost("UpdateGaContactCenterTipoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterTipoRichiestaAsync([FromBody] ContactCenterTipoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterTipoRichiestaDto, ContactCenterTipoRichiestaApiDto>();
                var response = await _gaContactCenterService.UpdateGaContactCenterTipoRichiestaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContactCenterTipoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterTipoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterTipoRichiestaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContactCenterTipoRichiestaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterTipoRichiestaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaContactCenterService.ValidateGaContactCenterTipoRichiestaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContactCenterTipoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterTipoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.ChangeStatusGaContactCenterTipoRichiestaAsync(id);
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

        #region ContactCenterMails
        [HttpGet("GetGaContactCenterMailsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterMailsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterMailsApiDto, ContactCenterMailsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterMailByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterMailByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterMailApiDto, ContactCenterMailDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContactCenterMailAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContactCenterMailAsync([FromBody] ContactCenterMailApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterMailDto, ContactCenterMailApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterMailAsync(dto);

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

        [HttpPost("UpdateGaContactCenterMailAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterMailAsync([FromBody] ContactCenterMailApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterMailDto, ContactCenterMailApiDto>();
                var response = await _gaContactCenterService.UpdateGaContactCenterMailAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContactCenterMailAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterMailAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterMailAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaContactCenterMailAsync/{id}/{mail}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterMailAsync(long id, string mail)
        {
            try
            {
                var response = await _gaContactCenterService.ValidateGaContactCenterMailAsync(id, mail);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaContactCenterMailAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterMailAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.ChangeStatusGaContactCenterMailAsync(id);
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

        #region ContactCenterAllegati
        [HttpGet("GetGaContactCenterAllegatiByTicketIdAsync/{contactCenterTicketId}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterAllegatiByTicketIdAsync(long contactCenterTicketId)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterAllegatiByTicketIdAsync(contactCenterTicketId);
                var apiDtos = dtos.ToApiDto<ContactCenterAllegatiApiDto, ContactCenterAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterAllegatoApiDto, ContactCenterAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContactCenterAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContactCenterAllegatoAsync([FromForm] ContactCenterAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/ContactCenter";
                var dto = apiDto.ToDto<ContactCenterAllegatoDto, ContactCenterAllegatoApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaContactCenterService.UpdateGaContactCenterAllegatoAsync(dto);
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

        [HttpPost("UpdateGaContactCenterAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterAllegatoAsync([FromBody] ContactCenterAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/ContactCenter";
                var dto = apiDto.ToDto<ContactCenterAllegatoDto, ContactCenterAllegatoApiDto>();
                var response = await _gaContactCenterService.UpdateGaContactCenterAllegatoAsync(dto);
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
                        var updateFileResponse = await _gaContactCenterService.UpdateGaContactCenterAllegatoAsync(dto);
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
                    var updateFileResponse = await _gaContactCenterService.UpdateGaContactCenterAllegatoAsync(dto);

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

        [HttpDelete("DeleteGaContactCenterAllegatoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterAllegatoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterAllegatoAsync(id);
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
        //[HttpGet("ValidateGaContactCenterAllegatoAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterAllegatoAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterAllegatoAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterAllegatoAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterAllegatoAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterAllegatoAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        #endregion

        #endregion

        #region ContactCenterMailsOnTickets
        [HttpGet("GetGaContactCenterMailsOnTicketsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailsOnTicketsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterMailsOnTicketsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterMailsOnTicketsApiDto, ContactCenterMailsOnTicketsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterMailOnTicketByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailOnTicketByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterMailOnTicketByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterMailOnTicketApiDto, ContactCenterMailOnTicketDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterMailsOnTicketsByTicketIdAsync/{ticketId}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailsOnTicketsByTicketIdAsync(long ticketId)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterMailsOnTicketsByTicketIdAsync(ticketId);
                var apiDto = dto.ToApiDto<ContactCenterMailsOnTicketsApiDto, ContactCenterMailsOnTicketsDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContactCenterMailOnTicketAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterMailOnTicketAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterMailOnTicketAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaContactCenterMailOnTicketAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterMailOnTicketAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterMailOnTicketAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterMailOnTicketAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterMailOnTicketAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterMailOnTicketAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        #endregion

        #endregion

        #region ContactCenterTickets
        [HttpGet("GetGaContactCenterTicketsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterTicketsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterTicketsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterTicketsApiDto, ContactCenterTicketsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaContactCenterTicketByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterTicketByIdAsync(long id)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterTicketByIdAsync(id);
                var apiDto = dto.ToApiDto<ContactCenterTicketApiDto, ContactCenterTicketDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaContactCenterTicketAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaContactCenterTicketAsync([FromBody] ContactCenterTicketApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                apiDto.DataTicket = DateTime.UtcNow;
                var dto = apiDto.ToDto<ContactCenterTicketDto, ContactCenterTicketApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterTicketAsync(dto);

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

        [HttpPost("UpdateGaContactCenterTicketAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterTicketAsync([FromBody] ContactCenterTicketApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ContactCenterTicketDto, ContactCenterTicketApiDto>();
                var response = await _gaContactCenterService.UpdateGaContactCenterTicketAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaContactCenterTicketAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterTicketAsync(long id)
        {
            try
            {
                var allegati = await _gaContactCenterService.GetGaContactCenterAllegatiByTicketIdAsync(id);
                foreach (var itm in allegati.Data)
                {
                    var fileId = itm.FileId;
                    var resp = await _gaContactCenterService.DeleteGaContactCenterAllegatoAsync(itm.Id);
                    if (resp && fileId != null && fileId != "null" && fileId != "")
                    {
                        var deleteResponse = await _fileService.Remove(fileId);
                    }
                }

                var response = await _gaContactCenterService.DeleteGaContactCenterTicketAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpPost("SendGaContactCenterTicketAsync")]
        public async Task<ApiResponse> SendGaContactCenterTicketAsync([FromBody] ContactCenterSendMailApiDto apiDto)
        {
            try 
            {
                var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.ContactCenter);
                var notifications = await _notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(notificationApp.Id);

                var ticket = await _gaContactCenterService.GetViewGaContactCenterTicketById(apiDto.id);

                string dataStampa = "-";
                if (ticket.DataEsecuzione != null)
                {

                    dataStampa = Convert.ToDateTime(ticket.DataEsecuzione).ToString("dddd dd MMMM yyyy", itIT);
                }

                ContactCenterMailsOnTicketsApiDto mailList = new ContactCenterMailsOnTicketsApiDto();
                string mailTo = "";

                foreach (var mailId in apiDto.mailList)
                {
                    var mail = await _gaContactCenterService.GetGaContactCenterMailByIdAsync(mailId);
                    mailList.Data.Add(new ContactCenterMailOnTicketApiDto() { Id = 0,ContactCenterTicketId=apiDto.id,ContactCenterMailId=mailId,MailAddress=mail.Mail,Data=DateTime.Now,Disabled=false });
                }

                mailTo = string.Join(";",(from x in mailList.Data
                          select x.MailAddress).ToList<string>());

                if (!ticket.Ingombranti)
                {
                    var dto = GenerateContactCenterTicketIntTemplate(ticket, dataStampa);

                    var attachPath = await _printService.Print("ContactCenterTicketInt", dto);


                    var result = await _mailService.AddMailJobAsync(new MailJob()
                    {
                        Id = 0,
                        Description = "Ticket Contact Center N° "+apiDto.id,
                        DateScheduled = DateTime.Now,
                        Title = "Ticket Contact Center N° " + apiDto.id,
                        MailingTo = mailTo,
                        MailCc = "",
                        Application = String.Format("{0}|{1}", notificationApp.Id, AppConsts.ContactCenter),
                        Content = HtmlHelpers.GenerateText("In allegato è possibile visionare il ticket.<br>Note:"+apiDto.mailNote+"<br>"+apiDto.userName+""),
                        Template = "DefaultMailJob.html",
                        UserId = apiDto.userid,
                        OkMessage = String.Format("Il Ticket {0} è stato inoltrato correttamente.", ticket.Id),
                        KoMessage = String.Format("Si è verificato un problema durante l'invio del ticket {0}.",ticket.Id),
                        Attachment = true,
                        AttachmentPath = attachPath
                    });
                    

                    
                }
                else
                {
                    var dto = GenerateContactCenterTicketIngTemplate(ticket, dataStampa);

                    var attachPath = await _printService.Print("ContactCenterTicketIng", dto);
                    var result = await _mailService.AddMailJobAsync(new MailJob()
                    {
                        Id = 0,
                        Description = "Ticket Contact Center N° " + apiDto.id,
                        DateScheduled = DateTime.Now,
                        Title = "Ticket Contact Center N° " + apiDto.id,
                        MailingTo = mailTo,
                        MailCc = "",
                        Application = String.Format("{0}|{1}", notificationApp.Id, AppConsts.ContactCenter),
                        Content = HtmlHelpers.GenerateText("In allegato è possibile visionare il ticket.<br>Note:" + apiDto.mailNote + "<br>" + apiDto.userName + ""),
                        Template = "DefaultMailJob.html",
                        UserId = apiDto.userid,
                        OkMessage = String.Format("Il Ticket {0} è stato inoltrato correttamente.",ticket.Id),
                        KoMessage = String.Format("Si è verificato un problema durante l'invio del ticket {0}.", ticket.Id),
                        Attachment = true,
                        AttachmentPath = attachPath
                    });


                }

                var dtos = mailList.ToDto<ContactCenterMailsOnTicketsDto, ContactCenterMailsOnTicketsApiDto>();
                var response = await _gaContactCenterService.AddGaContactCenterMailOnTicketAsync(ticket.Id, dtos);
                return new ApiResponse(response);

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("SetPrintedGaContactCenterTicketsAsync")]
        public async Task<ApiResponse> SetPrintedGaContactCenterTicketsAsync([FromBody] long[] ticketsId)
        {
            try
            {
                var entities = await _gaContactCenterService.SetPrintedGaContactCenterTicketsAsync(ticketsId);
                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("GetGaContactCenterTicketsIngAsync")]
        public async Task<ApiResponse> GetGaContactCenterTicketsIngAsync([FromBody] ContactCenterIngByDateFilterApiDto apiDto)
        {
            try
            {
                var response = await _gaContactCenterService.GetGaContactCenterTicketsIngAsync(apiDto.comuneId, apiDto.dataEsecuzione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }

        }

        [HttpGet("PrintGaContactCenterTicketByIdAsync/{id}")]
        public async Task<ApiResponse> PrintGaContactCenterTicketByIdAsync(long id)
        {
            try
            {
                var ticket = await _gaContactCenterService.GetViewGaContactCenterTicketById(id);

                string dataStampa = "-";
                if (ticket.DataEsecuzione != null)
                {

                    dataStampa = Convert.ToDateTime(ticket.DataEsecuzione).ToString("dddd dd MMMM yyyy", itIT);
                }

                if (!ticket.Ingombranti)
                {
                    var dto = GenerateContactCenterTicketIntTemplate(ticket, dataStampa);

                    var response = await _printService.Print("ContactCenterTicketInt", dto);
                    return new ApiResponse(response);
                }
                else
                {
                    var dto = GenerateContactCenterTicketIngTemplate(ticket, dataStampa);

                    var response = await _printService.Print("ContactCenterTicketIng", dto);
                    return new ApiResponse(response);

                }

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("PrintGaContactCenterIngByFilterAsync")]
        public async Task<ApiResponse> PrintGaContactCenterIngByFilterAsync([FromBody] ContactCenterIngPrintFilterApiDto apiDto)
        {
            try
            {
                if (apiDto.comuneId != 1)
                {
                    var comune = await _gaContactCenterService.GetGaContactCenterComuneByIdAsync(apiDto.comuneId);
                    apiDto.comuneAltro = comune.Descrizione;
                }

                var list = await _gaContactCenterService.GetGaContactCenterTicketsIngPrintAsync(apiDto.comuneAltro, apiDto.dataEsecuzione, apiDto.tipoStampa);

                if (list == null || (apiDto.all == false && list.Where(x => x.Stato == "IN GESTIONE").Count() == 0))
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

                var dto = GenerateContactCenterTicketsIngTemplate(apiDto.all?list:list.Where(x=>x.Stato=="IN GESTIONE").ToList(), apiDto.comuneAltro, apiDto.dataEsecuzione.GetValueOrDefault(), apiDto.tipoStampa);
                var response = await _printService.Print("ContactCenterTicketsIng", dto);


                var printDto = new ContactCenterStatusTicketsApiDto();
                if(apiDto.all)
                {
                    printDto.ticketsId = (from x in list
                                          select x.Id).ToArray();

                }
                else
                {
                    printDto.ticketsId = (from x in list
                                          where x.Stato=="IN GESTIONE"
                                          select x.Id).ToArray();

                }
                await _gaContactCenterService.SetPrintedGaContactCenterTicketsAsync(printDto.ticketsId);

                return new ApiResponse(response);

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("PrintGaContactCenterIntByFilterAsync")]
        public async Task<ApiResponse> PrintGaContactCenterIntByFilterAsync([FromBody] ContactCenterIntPrintFilterApiDto apiDto)
        {
            try
            {

                var list = await _gaContactCenterService.GetGaContactCenterTicketsIntPrintAsync(apiDto.fromId, apiDto.toId, apiDto.fromDate,apiDto.toDate);
                int nInt = 0;
                if (apiDto.all)
                {
                    nInt = nInt + list.Where(x => x.Stato == "IN GESTIONE").Count() + list.Where(x => x.Stato == "GESTITO").Count();
                }
                else
                {
                    nInt = nInt + list.Where(x => x.Stato == "IN GESTIONE").Count();
                }

                if (list == null || nInt == 0)
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

               

                var dto = GenerateContactCenterTicketsIntTemplate(apiDto.all ? list : list.Where(x => x.Stato == "IN GESTIONE").ToList());
                var response = await _printService.Print("ContactCenterTicketsInt", dto);

                var printDto = new ContactCenterStatusTicketsApiDto();
                if (apiDto.all)
                {
                    printDto.ticketsId = (from x in list
                                          select x.Id).ToArray();

                }
                else
                {
                    printDto.ticketsId = (from x in list
                                          where x.Stato == "IN GESTIONE"
                                          select x.Id).ToArray();

                }
                await _gaContactCenterService.SetPrintedGaContactCenterTicketsAsync(printDto.ticketsId);

                return new ApiResponse(response);

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }


        //[HttpGet("ValidateGaContactCenterTicketAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterTicketAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterTicketAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterTicketAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterTicketAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterTicketAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        [HttpPost("DuplicateGaContactCenterTicketAsync")]
        public async Task<ApiResponse> DuplicateGaContactCenterTicketAsync([FromBody] ContactCenterDuplicateTicketsApiDto apiDto)
        {
            try
            {
                var entities = await _gaContactCenterService.DuplicateGaContactCenterTicketAsync(apiDto.ticketsId, apiDto.userId, apiDto.stampato);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        [HttpPost("SetDoneContactCenterTicketAsync")]
        public async Task<ApiResponse> SetDoneContactCenterTicketAsync([FromBody] ContactCenterStatusTicketsApiDto apiDto)
        {
            try
            {
                var entities = await _gaContactCenterService.SetDoneGaContactCenterTicketAsync(apiDto.ticketsId);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        [HttpPost("SetUndoneContactCenterTicketAsync")]
        public async Task<ApiResponse> SetUndoneContactCenterTicketAsync([FromBody] ContactCenterStatusTicketsApiDto apiDto)
        {
            try
            {
                var entities = await _gaContactCenterService.SetUndoneGaContactCenterTicketAsync(apiDto.ticketsId);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }


        [HttpPost("SetPrintedContactCenterTicketAsync")]
        public async Task<ApiResponse> SetPrintedContactCenterTicketAsync([FromBody] ContactCenterStatusTicketsApiDto apiDto)
        {
            try
            {
                var entities = await _gaContactCenterService.SetPrintedGaContactCenterTicketsAsync(apiDto.ticketsId);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        #endregion

        #region Views
        [HttpGet("ExportGaContactCenterTicketsQueryable")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportGaContactCenterTicketsQueryable(GridOperationsModel filter)
        {

            try
            {
                var entities = _gaContactCenterService.GetViewGaContactCenterTicketsQueryableNoSkip(filter);
                string title = "Lista Ticket";
                string[] columns = { "Id", "DataTicket", "Comune","Indirizzo","Utente","TelefonoMail","TipoTicket","Materiali",
                                "DataEsecuzione","Note1","Note2","Note3","StatoTicket","Cantiere","Richiedente","Reclamo","Stato","EseguitoIl"};
                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "TICKET_CONTACT_CENTER", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Ticket_ContactCenter.xlsx"
                };
            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpGet("ExportFoContactCenterTicketsQueryable")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportFoContactCenterTicketsQueryable(GridOperationsModel filter)
        {

            try
            {
                var entities = _gaContactCenterService.GetViewFoContactCenterTicketsQueryableNoSkip(filter);
                string title = "Lista Ticket";
                string[] columns = { "Id", "DataTicket", "Comune","Indirizzo","Utente","TelefonoMail","TipoTicket","Materiali",
                                "DataEsecuzione","Note1","Note2","Note3","StatoTicket","Cantiere","Richiedente","Reclamo","Stato","EseguitoIl"};
                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "TICKET_CONTACT_CENTER", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Ticket_ContactCenter.xlsx"
                };
            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("GetViewGaContactCenterTicketsQueryable")]
        public ApiResponse GetViewGaContactCenterTicketsQueryable(GridOperationsModel filter)
        {
            try
            {
                var entities = _gaContactCenterService.GetViewGaContactCenterTicketsQueryable(filter);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        [HttpPost("GetViewFoContactCenterTicketsQueryable")]
        public ApiResponse GetViewFoContactCenterTicketsQueryable(GridOperationsModel filter)
        {
            try
            {
                var entities = _gaContactCenterService.GetViewFoContactCenterTicketsQueryable(filter);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
        #endregion

        #endregion

        #region Extras
        [HttpGet("GetGaContactCenterCantieriAsync")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterCantietiAsync()
        {
            try
            {
                var dtos = await _gaAziendeService.GetGaAziendeListeForContactCenterAsync();
                var apiDtos = dtos.ToApiDto<AziendeListeApiDto, AziendeListeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region Helpers
        private ContactCenterTicketIntTemplateDto GenerateContactCenterTicketIntTemplate(ViewGaContactCenterTickets ticket, string dataStampa) 
        {
            var dto = new ContactCenterTicketIntTemplateDto()
            {
                FileName = "ContactCenterInterventoTicket.pdf",
                FilePath = @"Print/ContactCenter",
                Title = "Contact Center Ticket Intervento",
                Css = "ContactCenterTicketInt"

            };

            dto.Id = ticket.Id.ToString();
            dto.DataTicket = ticket.DataTicket.ToString("dd-MM-yyyy");
            dto.Comune = ticket.Comune;
            dto.Indirizzo = ticket.Indirizzo;
            dto.Utente = ticket.RagioneSociale;
            dto.TelefonoMail = ticket.TelefonoMail;
            dto.TipoTicket = ticket.TipoTicket;
            dto.DataStampa = dataStampa;
            dto.Richiedente = ticket.Richiedente;
            dto.Note1 = ticket.Note1;
            dto.Note2 = ticket.Note2;
            dto.Provenienza = ticket.Provenienza;
            dto.EseguitoIl = ticket.EseguitoIl == null ? "" : ticket.EseguitoIl.ToString();
            dto.Promemoria = ticket.Promemoria == true ? "&#9745;" : "&#9744;";
            dto.Reclamo = ticket.Reclamo == true ? "&#9745;" : "&#9744;";
            dto.DaFatturare = ticket.DaFatturare == true ? "&#9745;" : "&#9744;";

            return dto;
        }

        private ContactCenterTicketIngTemplateDto GenerateContactCenterTicketIngTemplate(ViewGaContactCenterTickets ticket, string dataStampa)
        {
            var dto = new ContactCenterTicketIngTemplateDto()
            {
                FileName = "ContactCenterIngombrantiTicket.pdf",
                FilePath = @"Print/ContactCenter",
                Title = "Contact Center Ticket Ingombranti",
                Css = "ContactCenterTicketIng"

            };

            dto.Id = ticket.Id.ToString();
            dto.DataTicket = ticket.DataTicket.ToString("dd-MM-yyyy");
            dto.Comune = ticket.Comune;
            dto.Indirizzo = ticket.Indirizzo;
            dto.Utente = ticket.RagioneSociale;
            dto.TelefonoMail = ticket.TelefonoMail;
            dto.TipoTicket = ticket.TipoTicket;
            dto.DataStampa = dataStampa;
            dto.Richiedente = ticket.Richiedente;
            dto.Note1 = ticket.Note1;
            dto.Note2 = ticket.Note2;
            dto.Materiali = ticket.Materiali;

            return dto;
        }

        private ContactCenterTicketsIngTemplateDto GenerateContactCenterTicketsIngTemplate(List<ViewGaContactCenterTickets> tickets, string comune,DateTime data,int tipoStampa)
        {

            string descStampa = "";

            switch (tipoStampa)
            {
                case 1:
                    descStampa = "Ritiro Ingombranti + RAEE";
                    break;
                case 2:
                    descStampa = "Ritiro Ingombranti";
                    break;
                case 3:
                    descStampa = "Ritiro Ingombranti RAEE";
                    break;
            }

            var dto = new ContactCenterTicketsIngTemplateDto()
            {
                FileName = "ContactCenterIngombrantiTickets.pdf",
                FilePath = @"Print/ContactCenter",
                Title = "Contact Center Tickets Ingombranti",
                Css = "ContactCenterTicketsIng",
                Comune=comune,
                Data=data.ToString("dd/MM/yyyy"),
                TipoStampa=descStampa,
                Items= new List<ContactCenterTicketIngTemplateDto>()
            };

            foreach (var itm in tickets)
            {
                dto.Items.Add(new ContactCenterTicketIngTemplateDto()
                {
                    Id = itm.Id.ToString(),
                    DataTicket = itm.DataTicket.ToString("dd-MM-yyyy"),
                    Comune = itm.Comune,
                    Indirizzo = itm.Indirizzo,
                    Utente = itm.RagioneSociale,
                    TelefonoMail = itm.TelefonoMail,
                    TipoTicket = itm.TipoTicket,
                    DataStampa = "",
                    Richiedente = itm.Richiedente,
                    Note1 = itm.Note1,
                    Note2 = itm.Note2,
                    Materiali = itm.Materiali
                });
                
            }          

            return dto;
        }

        private ContactCenterTicketsIntTemplateDto GenerateContactCenterTicketsIntTemplate(List<ViewGaContactCenterTickets> tickets)
        {
            var dto = new ContactCenterTicketsIntTemplateDto()
            {
                FileName = "ContactCenterIngombrantiTickets.pdf",
                FilePath = @"Print/ContactCenter",
                Title = "Contact Center Tickets Ingombranti",
                Css = "ContactCenterTicketsIng",
                Items = new List<ContactCenterTicketIntTemplateDto>()
            };

            List<ContactCenterTicketIntTemplateDto> dtos = new List<ContactCenterTicketIntTemplateDto>();
            foreach (var ticket in tickets)
            {
                string dataStampa = "-";
                if (ticket.DataEsecuzione != null)
                {
                    dataStampa = Convert.ToDateTime(ticket.DataEsecuzione).ToString("dddd dd MMMM yyyy", itIT);
                }

                dto.Items.Add(new ContactCenterTicketIntTemplateDto() {
                    Id = ticket.Id.ToString(),
                    DataTicket = ticket.DataTicket.ToString("dd-MM-yyyy"),
                    Comune = ticket.Comune,
                    Indirizzo = ticket.Indirizzo,
                    Utente = ticket.RagioneSociale,
                    TelefonoMail = ticket.TelefonoMail,
                    TipoTicket = ticket.TipoTicket,
                    DataStampa = dataStampa,
                    Richiedente = ticket.Richiedente,
                    Note1 = ticket.Note1,
                    Note2 = ticket.Note2,
                    Provenienza = ticket.Provenienza,
                    EseguitoIl = ticket.EseguitoIl == null ? "" : ticket.EseguitoIl.ToString(),
                    Promemoria = ticket.Promemoria == true ? "&#9745;" : "&#9744;",
                    Reclamo = ticket.Reclamo == true ? "&#9745;" : "&#9744;",
                    DaFatturare = ticket.DaFatturare == true ? "&#9745;" : "&#9744;",
            });

            }

            return dto;
        }

        #endregion
    }
}
