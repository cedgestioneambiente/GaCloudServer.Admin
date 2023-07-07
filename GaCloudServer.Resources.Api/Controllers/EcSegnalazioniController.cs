using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.BusinnessLogic.Shared;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Segnalazioni;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fh = GaCloudServer.BusinnessLogic.Helpers.FileHelper;
using code = Microsoft.AspNetCore.Http.StatusCodes;
using GaCloudServer.BusinnessLogic.Dtos.Template;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class EcSegnalazioniController : Controller
    {
        private readonly IEcSegnalazioniService _ecSegnalazioniService;
        private readonly IFileService _fileService;
        private readonly ILogger<EcSegnalazioniController> _logger;
        private readonly IPrintService _printService;

        public EcSegnalazioniController(
            IEcSegnalazioniService ecSegnalazioniService
            , IFileService fileService
            , ILogger<EcSegnalazioniController> logger
            , IPrintService printService)
        {

            _ecSegnalazioniService = ecSegnalazioniService;
            _fileService = fileService;
            _logger = logger;
            _printService = printService;
        }


        #region SegnalazioniTipi
        [HttpGet("GetEcSegnalazioniTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _ecSegnalazioniService.GetEcSegnalazioniTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<SegnalazioniTipiApiDto, SegnalazioniTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetEcSegnalazioniTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _ecSegnalazioniService.GetEcSegnalazioniTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<SegnalazioniTipoApiDto, SegnalazioniTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddEcSegnalazioniTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddEcSegnalazioniTipoAsync([FromBody] SegnalazioniTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniTipoDto, SegnalazioniTipoApiDto>();
                var response = await _ecSegnalazioniService.AddEcSegnalazioniTipoAsync(dto);

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

        [HttpPost("UpdateEcSegnalazioniTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateEcSegnalazioniTipoAsync([FromBody] SegnalazioniTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniTipoDto, SegnalazioniTipoApiDto>();
                var response = await _ecSegnalazioniService.UpdateEcSegnalazioniTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteEcSegnalazioniTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteEcSegnalazioniTipoAsync(long id)
        {
            try
            {
                var response = await _ecSegnalazioniService.DeleteEcSegnalazioniTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateEcSegnalazioniTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateEcSegnalazioniTipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _ecSegnalazioniService.ValidateEcSegnalazioniTipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusEcSegnalazioniTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusEcSegnalazioniTipoAsync(long id)
        {
            try
            {
                var response = await _ecSegnalazioniService.ChangeStatusEcSegnalazioniTipoAsync(id);
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

        #region SegnalazioniStati
        [HttpGet("GetEcSegnalazioniStatiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniStatiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _ecSegnalazioniService.GetEcSegnalazioniStatiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<SegnalazioniStatiApiDto, SegnalazioniStatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetEcSegnalazioniStatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniStatoByIdAsync(long id)
        {
            try
            {
                var dto = await _ecSegnalazioniService.GetEcSegnalazioniStatoByIdAsync(id);
                var apiDto = dto.ToApiDto<SegnalazioniStatoApiDto, SegnalazioniStatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddEcSegnalazioniStatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddEcSegnalazioniStatoAsync([FromBody] SegnalazioniStatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniStatoDto, SegnalazioniStatoApiDto>();
                var response = await _ecSegnalazioniService.AddEcSegnalazioniStatoAsync(dto);

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

        [HttpPost("UpdateEcSegnalazioniStatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateEcSegnalazioniStatoAsync([FromBody] SegnalazioniStatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniStatoDto, SegnalazioniStatoApiDto>();
                var response = await _ecSegnalazioniService.UpdateEcSegnalazioniStatoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteEcSegnalazioniStatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteEcSegnalazioniStatoAsync(long id)
        {
            try
            {
                var response = await _ecSegnalazioniService.DeleteEcSegnalazioniStatoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateEcSegnalazioniStatoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateEcSegnalazioniStatoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _ecSegnalazioniService.ValidateEcSegnalazioniStatoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusEcSegnalazioniStatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusEcSegnalazioniStatoAsync(long id)
        {
            try
            {
                var response = await _ecSegnalazioniService.ChangeStatusEcSegnalazioniStatoAsync(id);
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

        #region SegnalazioniDocumentiImmagini

        [HttpGet("GetEcSegnalazioniDocumentoImmaginiByDocumentoIdAsync/{segnalazioniDocumentoId}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniDocumentoImmaginiByDocumentoIdAsync(long segnalazioniDocumentoId)
        {
            try
            {
                var dto = await _ecSegnalazioniService.GetEcSegnalazioniDocumentoImmaginiByDocumentoIdAsync(segnalazioniDocumentoId);
                var apiDto = dto.ToApiDto<SegnalazioniDocumentiImmaginiApiDto, SegnalazioniDocumentiImmaginiDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddEcSegnalazioniDocumentoImmagineAsync")]
        public async Task<ActionResult<ApiResponse>> AddEcSegnalazioniDocumentoImmagineAsync([FromBody] ImageItemApiDto apiDto)
        {

            byte[] bytes = Convert.FromBase64String(apiDto.image.Replace("data:image/jpeg;base64,", ""));
            MemoryStream stream = new MemoryStream(bytes);

            string fileFolder = string.Format("GaCloud/EcSegnalazioni/{0}", apiDto.id);
            string generatedFileName = fh.GenerateFileName("image.jpg");
            var fileUploadResponse = await _fileService.UploadStream(stream, fileFolder, generatedFileName);
            await _ecSegnalazioniService.UpdateEcSegnalazionePhotoAsync(apiDto.id, fileUploadResponse.id);

            var dto = new SegnalazioniDocumentoImmagineDto();
            dto.Id = 0;
            dto.SegnalazioniDocumentoId = apiDto.id;
            dto.FileFolder = fileFolder;
            dto.FileId = fileUploadResponse.id;
            dto.FileName = generatedFileName;
            dto.FileSize = fileUploadResponse.fileSize;
            dto.FileType = "";

            var response = await _ecSegnalazioniService.AddEcSegnalazioniDocumentoImmagineAsync(dto);

            return new ApiResponse("CreatedWithFile", response, code.Status201Created);

        }

        [HttpDelete("DeleteEcSegnalazioniDocumentoImmagineAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteEcSegnalazioniDocumentoImmagineAsync(long id, string fileId)
        {
            try
            {
                var response = await _ecSegnalazioniService.DeleteEcSegnalazioniDocumentoImmagineAsync(id);
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

        #region SegnalazioniDocumenti
        [HttpGet("GetEcSegnalazioniDocumentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniDocumentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _ecSegnalazioniService.GetEcSegnalazioniDocumentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<SegnalazioniDocumentiApiDto, SegnalazioniDocumentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetEcSegnalazioniDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniDocumentoByIdAsync(long id)
        {
            try
            {
                var dto = await _ecSegnalazioniService.GetEcSegnalazioniDocumentoByIdAsync(id);
                var apiDto = dto.ToApiDto<SegnalazioniDocumentoApiDto, SegnalazioniDocumentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddEcSegnalazioniDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddEcSegnalazioniDocumentoAsync([FromBody] SegnalazioniDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniDocumentoDto, SegnalazioniDocumentoApiDto>();
                var response = await _ecSegnalazioniService.AddEcSegnalazioniDocumentoAsync(dto);

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

        [HttpPost("UpdateEcSegnalazioniDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateEcSegnalazioniDocumentoAsync([FromBody] SegnalazioniDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniDocumentoDto, SegnalazioniDocumentoApiDto>();
                var response = await _ecSegnalazioniService.UpdateEcSegnalazioniDocumentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteEcSegnalazioniDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteEcSegnalazioniDocumentoAsync(long id)
        {
            try
            {
                var response = await _ecSegnalazioniService.DeleteEcSegnalazioniDocumentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("PrintEcSegnalazioneById/{id}")]
        public async Task<ActionResult<ApiResponse>> PrintEcSegnalazioneById(long id)
        {
            try
            {
                var view = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentoByIdAsync(id);
                var immagini = await _ecSegnalazioniService.GetEcSegnalazioniDocumentoImmaginiByDocumentoIdAsync(id);
                EcSegnalazioniDocumentoTemplateDto dto = new EcSegnalazioniDocumentoTemplateDto();
                dto.FileName = "EcSegnalazioniDocumento.pdf";
                dto.FilePath = @"Print/EcSegnalazione";
                dto.Title = "EcSegnalazione";
                dto.Css = "EcSegnalazioniDocumento";

                dto.Numero = view.Data.FirstOrDefault().Id.ToString();
                dto.Data = view.Data.FirstOrDefault().DataOra;
                dto.Note = view.Data.FirstOrDefault().Note;
                dto.User = view.Data.FirstOrDefault().User;
                dto.Tipo = view.Data.FirstOrDefault().Tipo;

                dto.Immagini = (from x in immagini.Data
                                select x.FileId).ToList();

                var response = await _printService.Print("EcSegnalazioniDocumento", dto);
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
        [HttpGet("GetViewEcSegnalazioniDocumentiAsync/{mode}/{userId}")]
        public async Task<ApiResponse> GetViewEcSegnalazioniDocumentiAsync(int mode = 1, string userId = "ec-s-administrator")
        {

            var response = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentiAsync((SegnalazioniDocumentiMode)mode, userId);
            return new ApiResponse("GetView", response);
        }

        [HttpGet("GetViewEcSegnalazioniDocumentiAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewEcSegnalazioniDocumentiAsync(bool all = true)
        {
            try
            {
                var view = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentiAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewEcSegnalazioniDocumentiAsync/{mode}/{userId}/{page}/{pageSize}")]
        public async Task<ApiResponse> GetViewEcSegnalazioniDocumentiAsync(int mode = 1, string userId = "ec-s-administrator", int page = 1, int pageSize = 100)
        {

            var response = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentiAsync((SegnalazioniDocumentiMode)mode, userId, page, pageSize);
            return new ApiResponse("GetView", response);
        }

        [HttpGet("GetViewEcSegnalazioniDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetViewEcSegnalazioniDocumentoByIdAsync(long id)
        {
            try
            {
                var view = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentoByIdAsync(id);
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
    }
}
