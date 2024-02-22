using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Preventivi;
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
    public class GaPreventiviController : Controller
    {
        private readonly IGaPreventiviService _gaPreventiviService;
        private readonly ILogger<GaPreventiviController> _logger;
        private readonly IFileService _fileService;

        public GaPreventiviController(
            IGaPreventiviService gaPreventiviService
            , IFileService fileService
            , ILogger<GaPreventiviController> logger)
        {

            _gaPreventiviService = gaPreventiviService;
            _fileService = fileService;
            _logger = logger;
            
        }


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

        [HttpPost("UpdateGaPreventiviAnticipoTipologiaAsync")]
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

        [HttpPost("UpdateGaPreventiviAnticipoPagamentoAsync")]
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

        [HttpPost("UpdateGaPreventiviAnticipoAsync")]
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

        [HttpPost("UpdateGaPreventiviAnticipoAllegatoAsync")]
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
    }
}
