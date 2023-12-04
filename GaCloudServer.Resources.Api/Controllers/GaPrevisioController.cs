using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp;
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
using System.Net;
using static GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder.CustomEcoFinderDto;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFtpService _ftpService;
        private readonly string EcoFinderBaseUri = "http://tellus.formulaconsorzio.it:8080/ecofinder/services/extern/";
        private readonly string _userId;

        private static readonly string fileSvuotamentiFtpRoot = "20.82.78.5/";
        private static readonly string fileSvuotamentiFtpEmzRoot = "20.82.78.5/";

        private static readonly NetworkCredential fileSvuotamentiFtpCredentials = new NetworkCredential("srtgaadmin", "K8cAqARVH8*RExtL9VvD7_yU722-WQ");

        private static readonly string nasLettureFtpRoot = "gads-novi.myds.me/";
        private static readonly NetworkCredential nasLettureFtpCredentials = new NetworkCredential("csgroup", "QDS6bNPq*gH5^mZW");

        private static readonly string emzLettureFtpRoot = "gads-novi.myds.me/";
        private static readonly NetworkCredential emzLettureFtpCredentials = new NetworkCredential("emz", "nx*@TYHv8L6HJ9q7");

        public GaPrevisioController(
            IGaPrevisioService gaPrevisioService
            ,IEcoFinderService ecoFinderService
            ,IHttpContextAccessor httpContextAccessor
            ,IFtpService ftpService
            ,ILogger<GaMezziController> logger)
        {

            _gaPrevisioService = gaPrevisioService;
            _ecoFinderService = ecoFinderService;
            _ftpService = ftpService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;

            _userId=_httpContextAccessor?.HttpContext?.User?.Claims?.Where(X => X.Type == "sub").FirstOrDefault().Value ?? "System ga.Cloud";
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

        [HttpGet("TestGaPrevisioOdsLettureUploadAsync")]
        public async Task<ActionResult<ApiResponse>> TestGaPrevisioOdsLettureUploadAsync()
        {
            try
            {
                var view = await _gaPrevisioService.GetViewGaPrevisioOdsLettureAsync();

                FtpDownloadAndUploadDto dto = new FtpDownloadAndUploadDto();
                dto.serverDownloadUri = nasLettureFtpRoot;
                dto.serverUploadUri = fileSvuotamentiFtpRoot;
                dto.filePath = "";
                dto.fileName = "";
                dto.downloadCredentials = nasLettureFtpCredentials;
                dto.uploadCredentials = fileSvuotamentiFtpCredentials;
                dto.useBinary = true;
                dto.usePassive = true;
                dto.keepAlive = true;

                foreach (var itm in view.Data)
                {
                    dto.fileName = itm.FileName + ".txt";
                    PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                    apiDto.IdServizio = itm.IdServizio;
                    apiDto.Descrizione = itm.Descrizione;
                    apiDto.Elaborato = true;
                    apiDto.FileName = dto.fileName;
                    apiDto.Id = 0;
                    apiDto.Retry = 0;
                    apiDto.Disabled = false;

                    try
                    {
                        dto.filePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","LocalLibrary","Download");
                        
                        var response = await _ftpService.DownloadAndUploadAsync(dto);

                        if (response.Split("/")[0] != null && response.Split("/")[0] == "550 ")
                        {
                            apiDto.Elaborato = false;
                            apiDto.ErrDescription = response;
                            await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);
                        }
                        else
                        {
                            apiDto.ProcDescription = response;
                            await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                            var ftpMove = new FtpMoveDto();
                            ftpMove.serverUri = nasLettureFtpRoot;
                            ftpMove.fileName = dto.fileName;
                            ftpMove.sourcefilePath = "/Letture";
                            ftpMove.destinationfilePath = "/Letture/ELABORATE_GA";
                            ftpMove.credentials = nasLettureFtpCredentials;
                            ftpMove.useBinary = true;
                            ftpMove.usePassive = true;
                            ftpMove.keepAlive = true;

                            await _ftpService.MoveAsync(ftpMove);

                        }

                        
                    }
                    catch (Exception ex)
                    {
                        apiDto.ErrDescription = ex.Message;
                        await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                    }

                }

                return new ApiResponse(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                throw new ApiException(ex.Message);
            }


        }

        [HttpGet("TestGaPrevisioOdsLettureUploadV2Async")]
        public async Task<ActionResult<ApiResponse>> TestGaPrevisioOdsLettureUploadV2Async()
        {
            try
            {

                FtpFolderDto folderDto = new FtpFolderDto();
                folderDto.serverUri = nasLettureFtpRoot;
                folderDto.filePath = "Letture";
                folderDto.credentials = nasLettureFtpCredentials;
                folderDto.useBinary = true;
                folderDto.usePassive = true;
                folderDto.keepAlive = true;

                var fileList = await _ftpService.ReadFolderAsync(folderDto);

                if (fileList != null)
                {

                    FtpDownloadAndUploadDto dto = new FtpDownloadAndUploadDto();
                    dto.serverDownloadUri = nasLettureFtpRoot;
                    dto.serverUploadUri = fileSvuotamentiFtpRoot;
                    dto.filePath = "";
                    dto.fileName = "";
                    dto.downloadCredentials = nasLettureFtpCredentials;
                    dto.uploadCredentials = fileSvuotamentiFtpCredentials;
                    dto.useBinary = true;
                    dto.usePassive = true;
                    dto.keepAlive = true;

                    foreach (string file in fileList)
                    {
                        var entityView=await _gaPrevisioService.GetViewGaPrevisioOdsLettureByFileNameAsync(file.Replace(".txt",""));
                        if (entityView != null)
                        {
                            dto.fileName = file;
                            PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                            apiDto.IdServizio = entityView.IdServizio;
                            apiDto.Descrizione = entityView.Descrizione;
                            apiDto.Elaborato = true;
                            apiDto.FileName = dto.fileName;
                            apiDto.Id = 0;
                            apiDto.Retry = 0;
                            apiDto.Disabled = false;

                            try
                            {
                                dto.filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "LocalLibrary", "Download");

                                var response = await _ftpService.DownloadAndUploadAsync(dto);

                                //non ricevo più quella risposta devo intercettare in modo diverso

                                if (response.Split("/")[0] != null && response.Split("/")[0] == "550 ")
                                {
                                    apiDto.Elaborato = false;
                                    apiDto.ErrDescription = response;
                                    await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);
                                }
                                else
                                {
                                    apiDto.ProcDescription = response;
                                    await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                                    var ftpMove = new FtpMoveDto();
                                    ftpMove.serverUri = nasLettureFtpRoot;
                                    ftpMove.fileName = dto.fileName;
                                    ftpMove.sourcefilePath = "/Letture";
                                    ftpMove.destinationfilePath = "/Letture/ELABORATE_GA/";
                                    ftpMove.credentials = nasLettureFtpCredentials;
                                    ftpMove.useBinary = true;
                                    ftpMove.usePassive = true;
                                    ftpMove.keepAlive = true;

                                    await _ftpService.MoveAsync(ftpMove);

                                }


                            }
                            catch (Exception ex)
                            {
                                apiDto.ErrDescription = ex.Message;
                                await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                            }

                        }
                        else
                        {
                            dto.fileName = file;
                            PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                            apiDto.IdServizio = "ODS NON PRESENTE";
                            apiDto.Descrizione = "ODS NON PRESENTE";
                            apiDto.Elaborato = true;
                            apiDto.FileName = dto.fileName;
                            apiDto.Id = 0;
                            apiDto.Retry = 0;
                            apiDto.Disabled = false;
                            await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);
                            //ods ancora non presente
                        }

                       

                    }

                }
                else
                {
                    return new ApiResponse("Nessun file da elaborare.");
                }



                return new ApiResponse(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                throw new ApiException(ex.Message);
            }


        }

        [HttpGet("TestFaPrevisioOdsLettureUploadAsync")]
        public async Task<ActionResult<ApiResponse>> TestFaPrevisioOdsLettureUploadAsync()
        {
            try
            {

                FtpFolderDto folderDto = new FtpFolderDto();
                folderDto.serverUri = nasLettureFtpRoot;
                folderDto.filePath = "Letture//lettureFA";
                folderDto.credentials = nasLettureFtpCredentials;
                folderDto.useBinary = true;
                folderDto.usePassive = true;
                folderDto.keepAlive = true;

                var fileList = await _ftpService.ReadFolderAsync(folderDto);

                if (fileList != null)
                {

                    FtpDownloadAndUploadDto dto = new FtpDownloadAndUploadDto();
                    dto.serverDownloadUri = nasLettureFtpRoot;
                    dto.extraPath = "/lettureFA/";
                    dto.serverUploadUri = fileSvuotamentiFtpRoot;
                    dto.filePath = "";
                    dto.fileName = "";
                    dto.downloadCredentials = nasLettureFtpCredentials;
                    dto.uploadCredentials = fileSvuotamentiFtpCredentials;
                    dto.useBinary = true;
                    dto.usePassive = true;
                    dto.keepAlive = true;

                    foreach (string file in fileList)
                    {
                        dto.fileName = file;
                        PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                        apiDto.IdServizio = "FORMULA AMBIENTE";
                        apiDto.Descrizione = "FORMULA AMBIENTE";
                        apiDto.Elaborato = true;
                        apiDto.FileName = dto.fileName;
                        apiDto.Id = 0;
                        apiDto.Retry = 0;
                        apiDto.Disabled = false;

                        try
                        {
                            dto.filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "LocalLibrary", "Download");

                            var response = await _ftpService.DownloadAndUploadAsync(dto);

                            if (response.Split("/")[0] != null && response.Split("/")[0] == "550 ")
                            {
                                apiDto.Elaborato = false;
                                apiDto.ErrDescription = response;
                                await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);
                            }
                            else
                            {
                                apiDto.ProcDescription = response;
                                await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                                var ftpMove = new FtpMoveDto();
                                ftpMove.serverUri = nasLettureFtpRoot;
                                ftpMove.fileName = dto.fileName;
                                ftpMove.sourcefilePath = "/Letture/lettureFA";
                                ftpMove.destinationfilePath = "/Letture/lettureFA/ELABORATE_FA/"+dto.fileName.Substring(0,4);
                                ftpMove.credentials = nasLettureFtpCredentials;
                                ftpMove.useBinary = true;
                                ftpMove.usePassive = true;
                                ftpMove.keepAlive = true;

                                await _ftpService.MoveAsync(ftpMove);

                            }


                        }
                        catch (Exception ex)
                        {
                            apiDto.ErrDescription = ex.Message;
                            await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                        }

                    }

                }
                else
                {
                    return new ApiResponse("Nessun file da elaborare.");
                }



                return new ApiResponse(true);

               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                throw new ApiException(ex.Message);
            }


        }

        [HttpGet("TestEmzPrevisioOdsLettureUploadAsync")]
        public async Task<ActionResult<ApiResponse>> TestEmzPrevisioOdsLettureUploadAsync()
        {
            try
            {

                FtpFolderDto folderDto = new FtpFolderDto();
                folderDto.serverUri = emzLettureFtpRoot;
                folderDto.filePath = "emz//conferimenti";
                folderDto.credentials = emzLettureFtpCredentials;
                folderDto.useBinary = true;
                folderDto.usePassive = true;
                folderDto.keepAlive = true;

                var fileList = await _ftpService.ReadFolderAsync(folderDto);

                if (fileList != null)
                {

                    FtpDownloadAndUploadDto dto = new FtpDownloadAndUploadDto();
                    dto.serverDownloadUri = emzLettureFtpRoot;
                    dto.extraPath = "/emz/conferimenti/";
                    dto.serverUploadUri = fileSvuotamentiFtpEmzRoot;
                    dto.filePath = "";
                    dto.fileName = "";
                    dto.downloadCredentials = emzLettureFtpCredentials;
                    dto.uploadCredentials = fileSvuotamentiFtpCredentials;
                    dto.useBinary = true;
                    dto.usePassive = true;
                    dto.keepAlive = true;
                    dto.customRoot = true;
                    dto.customRootPath = "emz";

                    foreach (string file in fileList)
                    {
                        dto.fileName = file;
                        PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                        apiDto.IdServizio = "EMZ";
                        apiDto.Descrizione = "EMZ";
                        apiDto.Elaborato = true;
                        apiDto.FileName = dto.fileName;
                        apiDto.Id = 0;
                        apiDto.Retry = 0;
                        apiDto.Disabled = false;

                        try
                        {
                            dto.filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "LocalLibrary", "Download");

                            var response = await _ftpService.DownloadAndUploadAsync(dto);

                            if (response.Split("/")[0] != null && response.Split("/")[0] == "550 ")
                            {
                                apiDto.Elaborato = false;
                                apiDto.ErrDescription = response;
                                await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);
                            }
                            else
                            {
                                apiDto.ProcDescription = response;
                                await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                                var ftpMove = new FtpMoveDto();
                                ftpMove.serverUri = emzLettureFtpRoot;
                                ftpMove.fileName = dto.fileName;
                                ftpMove.sourcefilePath = "/emz/conferimenti";
                                ftpMove.destinationfilePath = "/emz/archivio_conferimenti/";
                                ftpMove.credentials = emzLettureFtpCredentials;
                                ftpMove.useBinary = true;
                                ftpMove.usePassive = true;
                                ftpMove.keepAlive = true;

                                await _ftpService.MoveAsync(ftpMove);

                            }


                        }
                        catch (Exception ex)
                        {
                            apiDto.ErrDescription = ex.Message;
                            await _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto);

                        }

                    }

                }
                else
                {
                    return new ApiResponse("Nessun file da elaborare.");
                }



                return new ApiResponse(true);


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

        #region PrevisioMezziLetture
        [HttpPost("GetEventsByMezzoAndDataAsync")]
        public async Task<ApiResponse> GetEventsByMezzoAndDataAsync([FromBody] DeviceDataRequest apiDto)
        {
            try
            {
                var token = await _ecoFinderService.GetTokenAsync();
                var devices = await _ecoFinderService.GetDevices(token.token);
                var deviceId = (from x in devices where x.description == apiDto.targa.Trim().ToUpper() select x.id).FirstOrDefault();
                var deviceData =
                    await _ecoFinderService.GetDeviceData(token.token, deviceId.ToString(),
                    apiDto.dateStart.SetTime(0,0,0).ToString("yyyy-MM-ddTHH:mm:ss"),
                    apiDto.dateEnd.SetTime(23,59,59).ToString("yyyy-MM-ddTHH:mm:ss"));

                var entities = _gaPrevisioService.GetDetailedEventsTypeAsync(_userId, deviceData.events).Result.Data;

                return new ApiResponse(entities, code.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("ExportEventsMezziLettureAsync")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportEventsMezziLettureAsync([FromBody] List<DetailedEventsType> apiDto)
        {

            try
            {
                
                string title = "Lista Mezzi Letture";
                string[] columns = { "id","description", "idDevice","idEvent","dateTime","info","km",
                "xcoord","ycoord","utenza","comune","indirizzo","numCon","partita","tipoContenitore","tag","matricola"};
                byte[] filecontent = ExporterHelper.ExportExcel(apiDto, title, "", "", "PrevisioMezziLetture", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Previsio_Mezzi_Letture.xlsx"
                };

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }
        #endregion

    }
}