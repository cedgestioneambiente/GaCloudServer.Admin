using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;
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
    public class GaContactCenterController : Controller
    {
        private readonly IGaContactCenterService _gaContactCenterService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaContactCenterController> _logger;

        public GaContactCenterController(
            IGaContactCenterService gaContactCenterService
            , IFileService fileService
            , ILogger<GaContactCenterController> logger)
        {

            _gaContactCenterService = gaContactCenterService;
            _fileService = fileService;
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
        [HttpGet("GetGaContactCenterAllegatiAsync")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterAllegatiAsync(long id)
        {
            try
            {
                var dtos = await _gaContactCenterService.GetGaContactCenterAllegatiAsync(id);
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
                string fileFolder = "ContactCenter";
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
                string fileFolder = "ContactCenter";
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

        [HttpDelete("DeleteGaContactCenterAllegatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterAllegatoAsync(long id)
        {
            try
            {
                var response = await _gaContactCenterService.DeleteGaContactCenterAllegatoAsync(id);

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

        [HttpGet("GetGaContactCenterMailOnTicketByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailOnTicketByTicketIdAsync(long ticketId)
        {
            try
            {
                var dto = await _gaContactCenterService.GetGaContactCenterMailOnTicketByIdAsync(ticketId);
                var apiDto = dto.ToApiDto<ContactCenterMailOnTicketApiDto, ContactCenterMailOnTicketDto>();
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
                var entities = await _gaContactCenterService.SetPrintedGaContactCenterTicketAsync(apiDto.ticketsId);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        #endregion

        #endregion
    }
}
