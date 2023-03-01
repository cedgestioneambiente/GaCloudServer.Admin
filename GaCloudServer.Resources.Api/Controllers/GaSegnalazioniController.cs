using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.BusinnessLogic.Shared;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Segnalazioni;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Report.Segnalazioni;
using GaCloudServer.Resources.Api.Resources; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using code = Microsoft.AspNetCore.Http.StatusCodes;
using fh = GaCloudServer.BusinnessLogic.Helpers.FileHelper;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaSegnalazioniController : Controller
    {
        private readonly IGaSegnalazioniService _gaSegnalazioniService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaSegnalazioniController> _logger;

        public GaSegnalazioniController(
            IGaSegnalazioniService gaSegnalazioniService
            , IFileService fileService
            , ILogger<GaSegnalazioniController> logger)
        {

            _gaSegnalazioniService = gaSegnalazioniService;
            _fileService = fileService;
            _logger = logger;
        }


        #region SegnalazioniTipi
        [HttpGet("GetGaSegnalazioniTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaSegnalazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaSegnalazioniService.GetGaSegnalazioniTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<SegnalazioniTipiApiDto, SegnalazioniTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaSegnalazioniTipoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaSegnalazioniTipoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaSegnalazioniService.GetGaSegnalazioniTipoByIdAsync(id);
                var apiDto = dto.ToApiDto<SegnalazioniTipoApiDto, SegnalazioniTipoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaSegnalazioniTipoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaSegnalazioniTipoAsync([FromBody] SegnalazioniTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniTipoDto, SegnalazioniTipoApiDto>();
                var response = await _gaSegnalazioniService.AddGaSegnalazioniTipoAsync(dto);

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

        [HttpPost("UpdateGaSegnalazioniTipoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaSegnalazioniTipoAsync([FromBody] SegnalazioniTipoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniTipoDto, SegnalazioniTipoApiDto>();
                var response = await _gaSegnalazioniService.UpdateGaSegnalazioniTipoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaSegnalazioniTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaSegnalazioniTipoAsync(long id)
        {
            try
            {
                var response = await _gaSegnalazioniService.DeleteGaSegnalazioniTipoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaSegnalazioniTipoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaSegnalazioniTipoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaSegnalazioniService.ValidateGaSegnalazioniTipoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaSegnalazioniTipoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaSegnalazioniTipoAsync(long id)
        {
            try
            {
                var response = await _gaSegnalazioniService.ChangeStatusGaSegnalazioniTipoAsync(id);
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
        [HttpGet("GetGaSegnalazioniStatiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaSegnalazioniStatiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaSegnalazioniService.GetGaSegnalazioniStatiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<SegnalazioniStatiApiDto, SegnalazioniStatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaSegnalazioniStatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaSegnalazioniStatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaSegnalazioniService.GetGaSegnalazioniStatoByIdAsync(id);
                var apiDto = dto.ToApiDto<SegnalazioniStatoApiDto, SegnalazioniStatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaSegnalazioniStatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaSegnalazioniStatoAsync([FromBody] SegnalazioniStatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniStatoDto, SegnalazioniStatoApiDto>();
                var response = await _gaSegnalazioniService.AddGaSegnalazioniStatoAsync(dto);

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

        [HttpPost("UpdateGaSegnalazioniStatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaSegnalazioniStatoAsync([FromBody] SegnalazioniStatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniStatoDto, SegnalazioniStatoApiDto>();
                var response = await _gaSegnalazioniService.UpdateGaSegnalazioniStatoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaSegnalazioniStatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaSegnalazioniStatoAsync(long id)
        {
            try
            {
                var response = await _gaSegnalazioniService.DeleteGaSegnalazioniStatoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaSegnalazioniStatoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaSegnalazioniStatoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaSegnalazioniService.ValidateGaSegnalazioniStatoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaSegnalazioniStatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaSegnalazioniStatoAsync(long id)
        {
            try
            {
                var response = await _gaSegnalazioniService.ChangeStatusGaSegnalazioniStatoAsync(id);
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

        #region SegnalazioniDocumenti
        [HttpGet("GetGaSegnalazioniDocumentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaSegnalazioniDocumentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaSegnalazioniService.GetGaSegnalazioniDocumentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<SegnalazioniDocumentiApiDto, SegnalazioniDocumentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaSegnalazioniDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaSegnalazioniDocumentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaSegnalazioniService.GetGaSegnalazioniDocumentoByIdAsync(id);
                var apiDto = dto.ToApiDto<SegnalazioniDocumentoApiDto, SegnalazioniDocumentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaSegnalazioniDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaSegnalazioniDocumentoAsync([FromBody] SegnalazioniDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniDocumentoDto, SegnalazioniDocumentoApiDto>();
                var response = await _gaSegnalazioniService.AddGaSegnalazioniDocumentoAsync(dto);

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

        [HttpPost("UpdateGaSegnalazioniDocumentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaSegnalazioniDocumentoAsync([FromBody] SegnalazioniDocumentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<SegnalazioniDocumentoDto, SegnalazioniDocumentoApiDto>();
                var response = await _gaSegnalazioniService.UpdateGaSegnalazioniDocumentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaSegnalazioniDocumentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaSegnalazioniDocumentoAsync(long id)
        {
            try
            {
                var response = await _gaSegnalazioniService.DeleteGaSegnalazioniDocumentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        //#region Functions
        //[HttpGet("PrintGaSegnalazioneById/{id}")]
        //public async Task<ApiResponse> PrintGaSegnalazioneById(long id)
        //{
        //    try
        //    {
        //        var segnalazione = await _gaSegnalazioniService.GetViewGaSegnalazioniDocumentoByIdAsync(id);
        //        var segnalazioneAllegato = await _gaSegnalazioniService.GetGaSegnalazioneAllegatoBySegnalazioneIdAsync(id);

        //        string path = @"Report/Segnalazioni";
        //        string fileName = "segnalazione.pdf";
        //        string htmlContent = "";

        //        string header =
        //            "<div id='details' class='clearfix'>" +
        //            "<div id='client'>" +
        //            "<div class='to'>DETTAGLI:</div>" +
        //            "<h2 class='name'>" + segnalazione.Tipo + "</h2>" +
        //            "<div class='address'>" + segnalazione.User + "</div>" +
        //            "</div>" +
        //            "<div id='invoice' >" +
        //            "<h1> SEGNALAZIONE N°: " + segnalazione.Id + "</h1>" +
        //            "<div class='date'>Data: " + segnalazione.DataOra.ToString("dd/MM/yyyy HH:mm") + "</div>" +
        //            "</div>" +
        //            "</div>" +
        //            "<div id='notes' class='clearfix'>" +
        //            "<div id='notices'>" +
        //            "<div> NOTE:</div>" +
        //            "<h2 class='name'>" + segnalazione.Note + "</div>" +
        //            "</div>" +
        //            "<div id='notes' class='clearfix'>" +
        //            "<div id='notices'>" +
        //            "<div> Allegato:</div>" +
        //            "</div>" +
        //            "</div>";

        //        string table = "<div id='photo'>";
        //        int index = 1;
        //        foreach (var itm in segnalazioneAllegato.Data)
        //        {
        //            table +=
        //                "<div class='detail'>" +
        //                "<img src='https://api-resources.gestioneambiente.net/api/Files/DownloadDirectByIdSharepoint?fileId=" + itm.FileId + "'>" +
        //                "</div>";
        //            index++;
        //        }
        //        table += "</div>";


        //        htmlContent = SegnalazioniTemplateGenerator.GetHTMLString(header, table);

        //        var response = _fileService.UploadOnServerReport(fileName, path, htmlContent, "Segnalazione N°: " + segnalazione.Id, "Segnalazioni");
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        //#endregion

        #region Views
        [HttpGet("GetViewGaSegnalazioniDocumentiAsync/{mode}/{userId}")]
        public async Task<ApiResponse> GetViewGaSegnalazioniDocumentiAsync(int mode = 1, string userId = "ga-s-administrator")
        {

            var response = await _gaSegnalazioniService.GetViewGaSegnalazioniDocumentiAsync((SegnalazioniDocumentiMode)mode, userId);
            return new ApiResponse("GetView", response);
        }

        [HttpGet("GetViewGaSegnalazioniDocumentiAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaSegnalazioniDocumentiAsync(bool all = true)
        {
            try
            {
                var view = await _gaSegnalazioniService.GetViewGaSegnalazioniDocumentiAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaSegnalazioniDocumentiAsync/{mode}/{userId}/{page}/{pageSize}")]
        public async Task<ApiResponse> GetViewGaSegnalazioniDocumentiAsync(int mode = 1, string userId = "ga-s-administrator", int page = 1, int pageSize = 100)
        {

            var response = await _gaSegnalazioniService.GetViewGaSegnalazioniDocumentiAsync((SegnalazioniDocumentiMode)mode, userId, page, pageSize);
            return new ApiResponse("GetView", response);
        }

        [HttpGet("GetViewGaSegnalazioniDocumentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaSegnalazioniDocumentoByIdAsync(long id)
        {
            try
            {
                var view = await _gaSegnalazioniService.GetViewGaSegnalazioniDocumentoByIdAsync(id);
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

        #region SegnalazioniDocumentiImmagini
        [HttpGet("GetGaSegnalazioniDocumentoImmaginiByDocumentoIdAsync/{segnalazioniDocumentoId}")]
        public async Task<ActionResult<ApiResponse>> GetGaSegnalazioniDocumentoImmaginiByDocumentoIdAsync(long segnalazioniDocumentoId)
        {
            try
            {
                var dto = await _gaSegnalazioniService.GetGaSegnalazioniDocumentoImmaginiByDocumentoIdAsync(segnalazioniDocumentoId);
                var apiDto = dto.ToApiDto<SegnalazioniDocumentiImmaginiApiDto, SegnalazioniDocumentiImmaginiDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpPost("AddGaSegnalazioniDocumentoImmagineAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaSegnalazioniDocumentoImmagineAsync([FromBody] ImageItemApiDto apiDto)
        {

            byte[] bytes = Convert.FromBase64String(apiDto.image.Replace("data:image/jpeg;base64,", ""));
            MemoryStream stream = new MemoryStream(bytes);

            string fileFolder = string.Format("GaCloud/Segnalazioni/{0}",apiDto.id);
            string generatedFileName = fh.GenerateFileName("image.jpg");
            var fileUploadResponse = await _fileService.UploadStream(stream, fileFolder, generatedFileName);
            await _gaSegnalazioniService.UpdateGaSegnalazionePhotoAsync(apiDto.id, fileUploadResponse.id);

            var dto = new SegnalazioniDocumentoImmagineDto();
            dto.Id = 0;
            dto.SegnalazioniDocumentoId = apiDto.id;
            dto.FileFolder = fileFolder;
            dto.FileId=fileUploadResponse.id;
            dto.FileName = generatedFileName;
            dto.FileSize = fileUploadResponse.fileSize;
            dto.FileType = "";

            var response = await _gaSegnalazioniService.AddGaSegnalazioniDocumentoImmagineAsync(dto);

            return new ApiResponse("CreatedWithFile", response, code.Status201Created);

        }

        [HttpDelete("DeleteGaSegnalazioniDocumentoImmagineAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaSegnalazioniDocumentoImmagineAsync(long id,string fileId)
        {
            try
            {
                var response = await _gaSegnalazioniService.DeleteGaSegnalazioniDocumentoImmagineAsync(id);
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
    }
}
