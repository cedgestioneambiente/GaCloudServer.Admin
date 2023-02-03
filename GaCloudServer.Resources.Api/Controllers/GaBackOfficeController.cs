using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaBackOfficeController : Controller
    {
        private readonly IGaBackOfficeService _gaBackOfficeService;
        private readonly ILogger<GaMezziController> _logger;

        public GaBackOfficeController(
            IGaBackOfficeService gaBackOfficeService
            ,ILogger<GaMezziController> logger)
        {

            _gaBackOfficeService = gaBackOfficeService;
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
        #endregion

        #endregion

        #region BackOfficeUtenze

        #region Views
        [HttpGet("GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync/{codAzi}/{ragCliCf}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi,string ragCliCf)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(codAzi, ragCliCf);
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

        #region BackOfficeNdUtenze

        #region Views
        [HttpGet("GetViewGaBackOfficeNdUtenzeByCodAziAsync/{codAzi}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeByCodAziAsync(string codAzi)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeByCodAziAsync(codAzi);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync/{codAzi}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync(string codAzi,string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync(codAzi,numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync/{codAzi}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync(string codAzi)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync(codAzi);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync/{codAzi}/{ragCliCf}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi,string ragCliCf)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync(codAzi,ragCliCf);
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

        #region BackOfficeContenitori

        #region Views
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
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(string codComune,string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(codComune,numCon);
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