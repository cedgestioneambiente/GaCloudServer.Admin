using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Contratti;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Models;
using GaCloudServer.Resources.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    public class GaContrattiController : Controller
    {
        private readonly IGaContrattiService _gaContrattiService;
        private readonly IApiErrorResources _errorResources;

        public GaContrattiController(IGaContrattiService gaContrattiService,IApiErrorResources errorResources)
        {

            _gaContrattiService = gaContrattiService;
            _errorResources= errorResources;
        }

        #region GaContrattiPermessi
        [HttpGet("GetGaContrattiPermessiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiPermessiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiPermessiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiPermessiApiDto, ContrattiPermessiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
            
        }
        #endregion

        #region GaContrattiServizi
        [HttpGet("GetGaContrattiServiziAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiServiziAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiServiziAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiServiziApiDto, ContrattiServiziDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region GaContrattiTipologie
        [HttpGet("GetGaContrattiTipologieAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaContrattiTipologieAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaContrattiService.GetGaContrattiTipologieAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContrattiTipologieApiDto, ContrattiTipologieDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region GaContrattiUtentiOnPermessi

        #endregion
    }
}