using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

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

        #region Functions
        [HttpPost("CalcGaBackOfficeMassimali")]
        public async Task<ActionResult<ApiResponse>> CalcGaBackOfficeMassimali([FromBody] List<ViewGaBackOfficeUtenzePartite> dtos)
        {
            try
            {

                var view = await _gaBackOfficeService.CalcGaBackOfficeMassimali(dtos);
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

        [HttpGet("GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
              _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

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

        #region Sp
        [HttpGet("GetSpGaBackOfficeUtenzeAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetSpGaBackOfficeUtenzeAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetSpGaBackOfficeUtenzeAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetSpGaBackOfficeUtenzePartiteAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetSpGaBackOfficeUtenzePartiteAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetSpGaBackOfficeUtenzePartiteAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetSpGaBackOfficeUtenzeDispositiviAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetSpGaBackOfficeUtenzeDispositiviAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetSpGaBackOfficeUtenzeDispositiviAsync(codAzi, filter);
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

        #region BackOfficeZone
        [HttpGet("GetGaBackOfficeZoneComuniAsync")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneComuniAsync()
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneComuniAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeZoneVieByComuneAsync/{comune}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneVieByComuneAsync(string comune)
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneVieByComuneAsync(comune);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeZoneCiviciByComuneAndViaAsync/{comune}/{via}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneCiviciByComuneAndViaAsync(string comune,string via)
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneCiviciByComuneAndViaAsync(comune,via);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeZoneZonaAsync/{comune}/{via}/{civico}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneZonaAsync(string comune, string via,string civico)
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneZonaAsync(comune, via,civico);
                return new ApiResponse(view);
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