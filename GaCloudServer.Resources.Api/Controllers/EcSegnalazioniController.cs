using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.BusinnessLogic.Shared;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Segnalazioni;
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
    public class EcSegnalazioniController : Controller
    {
        private readonly IEcSegnalazioniService _ecSegnalazioniService;
        private readonly IFileService _fileService;
        private readonly ILogger<EcSegnalazioniController> _logger;

        public EcSegnalazioniController(
            IEcSegnalazioniService ecSegnalazioniService
            , IFileService fileService
            , ILogger<EcSegnalazioniController> logger)
        {

            _ecSegnalazioniService = ecSegnalazioniService;
            _fileService = fileService;
            _logger = logger;
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

        #region SegnalazioniAllegati

        [HttpGet("GetEcSegnalazioniAllegatoByDocumentoId/{segnalazioniDocumentoId}")]
        public async Task<ActionResult<ApiResponse>> GetEcSegnalazioniAllegatoByDocumentoIdAsync(long segnalazioniDocumentoId)
        {
            try
            {
                var dto = await _ecSegnalazioniService.GetEcSegnalazioniAllegatoByDocumentoIdAsync(segnalazioniDocumentoId);
                var apiDto = dto.ToApiDto<SegnalazioniAllegatoApiDto, SegnalazioniAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddEcSegnalazioniAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddEcSegnalazioniAllegatoAsync([FromForm] SegnalazioniAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/SegnalazioniEc";
                var dto = apiDto.ToDto<SegnalazioniAllegatoDto, SegnalazioniAllegatoApiDto>();
                var response = await _ecSegnalazioniService.AddEcSegnalazioniAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    //var updateFileResponse = await _ecSegnalazioniService.UpdateEcSegnalazioniAllegatoAsync(dto);
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

        [HttpDelete("DeleteEcSegnalazioniAllegatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteEcSegnalazioniAllegatoAsync(long id)
        {
            try
            {
                var response = await _ecSegnalazioniService.DeleteEcSegnalazioniAllegatoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateEcSegnalazioniAllegatoAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateEcSegnalazioniAllegatoAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _ecSegnalazioniService.ValidateEcSegnalazioniAllegatoAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusEcSegnalazioniAllegatoAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusEcSegnalazioniAllegatoAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _ecSegnalazioniService.ChangeStatusEcSegnalazioniAllegatoAsync(id);
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

        //#region Functions
        //[HttpGet("PrintEcSegnalazioneById/{id}")]
        //public async Task<ApiResponse> PrintEcSegnalazioneById(long id)
        //{
        //    try
        //    {
        //        var segnalazione = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentoByIdAsync(id);
        //        var segnalazioneAllegato = await _ecSegnalazioniService.GetEcSegnalazioneAllegatoBySegnalazioneIdAsync(id);

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
        [HttpGet("GetViewEcSegnalazioniDocumentiAsync/{mode}/{userId}")]
        public async Task<ApiResponse> GetViewEcSegnalazioniAsync(int mode = 1, string userId = "ga-s-administrator")
        {

            var response = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentiAsync((SegnalazioniDocumentiMode)mode, userId);
            return new ApiResponse("GetView", response);
        }

        [HttpGet("GetViewEcSegnalazioniDocumentiAsync/{mode}/{userId}/{page}/{pageSize}")]
        public async Task<ApiResponse> GetViewEcSegnalazioniAsync(int mode = 1, string userId = "ga-s-administrator", int page = 1, int pageSize = 100)
        {

            var response = await _ecSegnalazioniService.GetViewEcSegnalazioniDocumentiAsync((SegnalazioniDocumentiMode)mode, userId, page, pageSize);
            return new ApiResponse("GetView", response);
        }
        #endregion

        #endregion
    }
}
