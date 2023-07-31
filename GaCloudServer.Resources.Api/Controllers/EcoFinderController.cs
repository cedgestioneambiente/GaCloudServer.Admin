using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Microsoft.AspNetCore.Authorization.Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class EcoFinderController : Controller
    {
        private readonly IEcoFinderService _ecoFinderService;
        private readonly ILogger<EcoFinderController> _logger;
        private readonly IFileService _fileService;

        public EcoFinderController(
            IEcoFinderService ecoFinderService
            , IFileService fileService
            , ILogger<EcoFinderController> logger)
        {

            _ecoFinderService = ecoFinderService;
            _fileService = fileService;
            _logger = logger;
        }


        #region EcoFinder
        [HttpGet("GetTokenAsync")]
        public async Task<ActionResult<ApiResponse>> GetTokenAsync()
        {
            try
            {
                var response = await _ecoFinderService.GetTokenAsync();
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetDevices/{token}")]
        public async Task<ActionResult<ApiResponse>> GetDevices(string token)
        {
            try
            {
                var response = await _ecoFinderService.GetDevices(token);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetDeviceData/{token}/{deviceId}/{dateStart}/{dateEnd}")]
        public async Task<ActionResult<ApiResponse>> GetDeviceData(string token, string deviceId, string dateStart, string dateEnd)
        {
            try
            {
                var response = await _ecoFinderService.GetDeviceData(token,deviceId,dateStart,dateEnd);

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

        

        #endregion

        
    }
}