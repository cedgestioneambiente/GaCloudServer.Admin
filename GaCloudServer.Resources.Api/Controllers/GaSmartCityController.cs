using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
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
    public class GaSmartCityController : Controller
    {
        private readonly IGaBackOfficeService _gaBackOfficeService;
        private readonly IGaSmartCityService _gaSmartCityService;
        private readonly ILogger<GaMezziController> _logger;

        public GaSmartCityController(
            IGaBackOfficeService gaBackOfficeService
            ,IGaSmartCityService gaSmartCityService
            ,ILogger<GaMezziController> logger)
        {

            _gaBackOfficeService = gaBackOfficeService;
            _gaSmartCityService= gaSmartCityService;
            _logger = logger;
        }

        #region BackOfficeComuni

        #region Views
        [HttpGet("GetViewGaBackOfficeComuniAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeComuniAsync()
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeComuniAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeComuniCustomAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeComuniCustomAsync()
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeComuniCustomAsync();
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

        #region BackOfficeUtenze
        [HttpGet("GetViewGaBackOfficeUtenzaByCpAziAndNumConAsync/{codAzi}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzaByCpAziAndNumConAsync(string codAzi, string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzaByCpAziAndNumConAsync(codAzi, numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync/{codAzi}/{via}/{startNumCiv}/{endNumCiv}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync(string codAzi, string via, int startNumCiv,int endNumCiv)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync(codAzi, via,startNumCiv,endNumCiv);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions

        [HttpGet("ExportGaBackOfficeUtenzeByCpAziAndFilterAsync/{codAzi}/{filter}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportGaBackOfficeUtenzeByCpAziAndFilterAsync(string codAzi, string filter)
        {

            try
            {
                var entities = _gaBackOfficeService.GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(codAzi, filter).Result.Data;
                string title = "Lista Utenze";
                string[] columns = GenericHelper.ConvertPropertyToColumn(entities.FirstOrDefault());

                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "LISTA_UTENZE", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Lista_Utenze.xlsx"
                };
            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }


        [HttpGet("ExportGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync/{codAzi}/{via}/{startNumCiv}/{endNumCiv}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync(string codAzi, string via, int startNumCiv, int endNumCiv)
        {

            try
            {
                var entities = _gaBackOfficeService.GetViewGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync(codAzi, via, startNumCiv, endNumCiv).Result.Data;
                string title = "Lista Utenze";
                string[] columns = GenericHelper.ConvertPropertyToColumn(entities.FirstOrDefault());

                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "LISTA_UTENZE", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Lista_Utenze.xlsx"
                };
            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }
        #endregion
        #endregion

        #region BackOfficePartite
        [HttpGet("GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync/{codAzi}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync(string codAzi, string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync(codAzi, numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region BackOfficeDispositivi
        [HttpGet("GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync/{codAzi}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(string codAzi, string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(codAzi, numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAndPartitaAsync/{codAzi}/{numCon}/{partita}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAndPartitaAsync(string codAzi, string numCon,string partita)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAndPartitaAsync(codAzi, numCon,partita);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeContenitoriLettureByIdentiAsync/{identi}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeContenitoriLettureByIdentiAsync(string identi)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeContenitoriLettureByIdentiAsync(identi);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync/{codComune}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(string codComune, string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(codComune, numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region SmartCityPermissions

        #region Functions
        [HttpGet("ChangeGaSmartCityPermissionsAsync/{userId}/{permissions}")]
        public async Task<ActionResult<ApiResponse>> ChangeGaSmartCityPermissionsAsync(string userId,string permissions)
        {
            try
            {

                var view = await _gaSmartCityService.ChangeGaSmartCityPermissionsAsync(userId,permissions);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region Views
        [HttpGet("GetViewGaSmartCityPermissionsAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaSmartCityPermissionsAsync()
        {
            try
            {
                var view = await _gaSmartCityService.GetViewGaSmartCityPermissionsAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaSmartCityPermissionsByUserIdAsync/{userId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaSmartCityPermissionsByUserIdAsync(string userId)
        {
            try
            {
                var view = await _gaSmartCityService.GetViewGaSmartCityPermissionsByUserIdAsync(userId);
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