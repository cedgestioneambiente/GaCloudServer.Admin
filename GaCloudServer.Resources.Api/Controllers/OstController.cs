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
    public class OstController : Controller
    {
        private readonly IOstService _ostService;
        private readonly ILogger<GaSegnalazioniController> _logger;

        public OstController(
            IOstService ostService
            , ILogger<GaSegnalazioniController> logger)
        {

            _ostService = ostService;
            _logger = logger;
        }


        #region Tickets

        #region Views
        [HttpGet("GetViewOstTicketsAnniAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewOstTicketsAnniAsync()
        {
            try
            {
                var view = await _ostService.GetViewOstTicketsAnniAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewOstTicketsByAnnoAsync/{anno}")]
        public async Task<ActionResult<ApiResponse>> GetViewOstTicketsByAnnoAsync(int anno)
        {
            try
            {
                var view = await _ostService.GetViewOstTicketsByAnnoAsync(anno);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpGet("GetViewOstOpenTicketsByAnnoAsync/{anno}")]
        public async Task<ActionResult<ApiResponse>> GetViewOstOpenTicketsByAnnoAsync(int anno)
        {
            try
            {
                var view = await _ostService.GetViewOstOpenTicketsByAnnoAsync(anno);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetOstTicketSummaryAsync/{anno}")]
        public async Task<ActionResult<ApiResponse>> GetOstTicketSummaryAsync(int anno)
        {
            try
            {
                var view = await _ostService.GetOstTicketSummaryAsync(anno);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetOstTicketDistributionAsync/{anno}")]
        public async Task<ActionResult<ApiResponse>> GetOstTicketDistributionAsync(int anno)
        {
            try
            {
                var view = await _ostService.GetOstTicketDistributionAsync(anno);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetOstTicketSectDistributionAsync/{anno}")]
        public async Task<ActionResult<ApiResponse>> GetOstTicketSectDistributionAsync(int anno)
        {
            try
            {
                var view = await _ostService.GetOstTicketSectDistributionAsync(anno);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetOstTicketStatisticsAsync/{anno}")]
        public async Task<ActionResult<ApiResponse>> GetOstTicketStatisticsAsync(int anno)
        {
            try
            {
                var view = await _ostService.GetOstTicketStatisticsAsync(anno);
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
