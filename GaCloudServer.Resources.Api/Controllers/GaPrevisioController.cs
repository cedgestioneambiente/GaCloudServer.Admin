using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Previsio;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Resources.Previsio;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaPrevisioController : Controller
    {
        private readonly IGaPrevisioService _gaPrevisioService;
        private readonly ILogger<GaMezziController> _logger;
        private readonly IEcoFinderService _ecoFinderService;
        private readonly string EcoFinderBaseUri = "http://tellus.formulaconsorzio.it:8080/ecofinder/services/extern/";

        public GaPrevisioController(
            IGaPrevisioService gaPrevisioService
            ,IEcoFinderService ecoFinderService
            ,ILogger<GaMezziController> logger)
        {

            _gaPrevisioService = gaPrevisioService;
            _ecoFinderService = ecoFinderService;
            _logger = logger;
        }

        #region PrevisioOdsLetture
        [HttpGet("GetGaPrevisioOdsLettureAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrevisioOdsLettureAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPrevisioService.GetGaPrevisioOdsLettureAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PrevisioOdsLettureApiDto, PrevisioOdsLettureDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPrevisioOdsLetturaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPrevisioOdsLetturaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPrevisioService.GetGaPrevisioOdsLetturaByIdAsync(id);
                var apiDto = dto.ToApiDto<PrevisioOdsLetturaApiDto, PrevisioOdsLetturaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPrevisioOdsLetturaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPrevisioOdsLetturaAsync([FromBody] PrevisioOdsLetturaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrevisioOdsLetturaDto, PrevisioOdsLetturaApiDto>();
                var response = await _gaPrevisioService.AddGaPrevisioOdsLetturaAsync(dto);

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

        [HttpPost("UpdateGaPrevisioOdsLetturaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPrevisioOdsLetturaAsync([FromBody] PrevisioOdsLetturaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PrevisioOdsLetturaDto, PrevisioOdsLetturaApiDto>();
                var response = await _gaPrevisioService.UpdateGaPrevisioOdsLetturaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPrevisioOdsLetturaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPrevisioOdsLetturaAsync(long id)
        {
            try
            {
                var response = await _gaPrevisioService.DeleteGaPrevisioOdsLetturaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPrevisioOdsLetturaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPrevisioOdsLetturaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPrevisioService.ValidateGaPrevisioOdsLetturaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusElaboratoGaPrevisioOdsLetturaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusElaboratoGaPrevisioOdsLetturaAsync(long id)
        {
            try
            {
                var response = await _gaPrevisioService.ChangeStatusElaboratoGaPrevisioOdsLetturaAsync(id);
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

        #region PrevisioOdsReport

        #region Views
        [HttpPost("GetViewGaPrevisioOdsReportByDateAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPrevisioOdsReportByDateAsync(DateRangeDto dto)
        {
            try
            {
                var view = await _gaPrevisioService.GetViewGaPrevisioOdsReportByDateAsync(dto.dateStart, dto.dateEnd.SetTime(23,59,59));
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("GetViewGaPrevisioOdsServiziReportByDateAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPrevisioOdsServiziReportByDateAsync(DateRangeDto dto)
        {
            try
            {
                var view = await _gaPrevisioService.GetViewGaPrevisioOdsServiziReportByDateAsync(dto.dateStart, dto.dateEnd.SetTime(23, 59, 59));
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region Functions
        [HttpPost("GetEventsByOdsAsync")]
        public async Task<ApiResponse> GetEventsByOdsAsync([FromBody] DeviceDataRequest apiDto)
        {
            try
            {
                var token = await _ecoFinderService.GetTokenAsync();
                var devices = await _ecoFinderService.GetDevices(token.token);
                var deviceId = (from x in devices where x.description == apiDto.targa.Trim() select x.id).FirstOrDefault();
                var deviceData =                  
                    await _ecoFinderService.GetDeviceData(token.token, deviceId.ToString(), 
                    apiDto.dateStart.ToString("yyyy-MM-ddTHH:mm:ss"), 
                    apiDto.dateEnd.ToString("yyyy-MM-ddTHH:mm:ss"));

                return new ApiResponse(deviceData, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("ExportEventsByOdsAsync")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportEventsByOdsAsync(DeviceDataResponse apiDto)
        {

            try
            {
                var entities = apiDto.events;
                string title = "Lista Eventi Ods";
                string[] columns = { "id","description", "idDevice","idEvent","dateTime","info","km",
                "xcoord","ycoord"};
                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "PrevisioEventiOds", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Previsio_Eventi_Ods.xlsx"
                };

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPut("ExportEventsWithDetailsByOdsAsync/{userId}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportEventsWithDetailsByOdsAsync(string userId,[FromBody] DeviceDataResponse apiDto)
        {

            try
            {
                var entities = _gaPrevisioService.GetDetailedEventsTypeAsync(userId,apiDto.events).Result.Data;
                string title = "Lista Eventi Ods Dettagli";
                string[] columns = { "id","description", "idDevice","idEvent","dateTime","info","km",
                "xcoord","ycoord","utenza","comune","indirizzo","numCon","partita","tipoContenitore","tag","matricola"};
                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "PrevisioEventiDettagliOds", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Previsio_Eventi_Dettagli_Ods.xlsx"
                };

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }
        #endregion

        #endregion

    }
}