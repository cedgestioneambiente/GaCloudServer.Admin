using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GaCloudServer.Resources.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class ConsorzioV2Controller : Controller
    {
        private readonly IConsorzioService _consorzioService;
        private readonly ILogger<ConsorzioV2Controller> _logger;

        public ConsorzioV2Controller(
            IConsorzioService consorzioService,
            ILogger<ConsorzioV2Controller> logger)
        {
            _consorzioService = consorzioService;
            _logger = logger;
        }

        [HttpPost("GetViewConsorzioRegistrazioniQueryableFilterSingleParam/{roles?}")]
        public ActionResult<ApiResponse> GetViewConsorzioRegistrazioniQueryableFilterSingleParam([FromBody] GridOperationsModel filter, [FromRoute] string? roles = "0")
        {
            try
            {
                if (roles != "NaN")
                {
                    var entities = _consorzioService.GetViewConsorzioRegistrazioniByRolesQueryable(filter, roles.Split(","));
                    return new ApiResponse(entities);
                }

                return new ApiResponse(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore in GetViewConsorzioRegistrazioniQueryableFilterSingleParam v2");
                throw new ApiException(ex.Message);
            }
        }
    }
}
