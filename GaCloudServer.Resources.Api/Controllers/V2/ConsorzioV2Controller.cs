using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class ConsorzioController : Controller
    {
        private readonly IConsorzioService _consorzioService;
        private readonly ILogger<ConsorzioController> _logger;

        public ConsorzioController(
            IConsorzioService consorzioService,
            ILogger<ConsorzioController> logger)
        {
            _consorzioService = consorzioService;
            _logger = logger;
        }

        [HttpPost("GetViewConsorzioRegistrazioniAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioRegistrazioniAsync(PageRequest request)
        {
            try
            {
                var response = await _consorzioService.GetViewConsorzioRegistrazioniAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
    }
}
