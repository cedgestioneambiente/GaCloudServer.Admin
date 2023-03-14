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
    public class GaRecapitiController : Controller
    {
        private readonly IGaRecapitiService _gaRecapitiService;
        private readonly ILogger<GaRecapitiController> _logger;

        public GaRecapitiController(
            IGaRecapitiService gaRecapitiService
            ,ILogger<GaRecapitiController> logger)
        {

            _gaRecapitiService = gaRecapitiService;
            _logger = logger;
        }


        #region RecapitiContatti
       
        #region Views
        [HttpGet("GetViewGaRecapitiContattiAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaRecapitiContattiAsync()
        {
            try
            {
                var view = await _gaRecapitiService.GetViewGaRecapitiContattiAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaRecapitiContattiByFilterAsync/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaRecapitiContattiByFilterAsync(string filter)
        {
            try
            {
                var view = await _gaRecapitiService.GetViewGaRecapitiContattiByFilterAsync(filter);
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