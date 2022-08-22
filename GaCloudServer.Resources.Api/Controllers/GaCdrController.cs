using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Cdr;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Cdr;
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
    public class GaCdrController : Controller
    {
        private readonly IGaCdrService _gaCdrService;
        //private readonly IMailService _mailService;
        private readonly IApiErrorResources _errorResources;

        public GaCdrController(IGaCdrService gaCdrService, IApiErrorResources errorResources)
        {

            _gaCdrService = gaCdrService;
            //_mailService = mailService;
            _errorResources = errorResources;
        }

        #region GaCdrCentro
        [HttpGet("GetGaCdrCentriAsync/{page}/{pageSize}/{all?}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCentriAsync(int page = 1, int pageSize = 0, bool all = true)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrCentriAsync(page, pageSize, all);
                var apiDtos = dtos.ToApiDto<CdrCentriApiDto, CdrCentriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
            
        }
        #endregion

        #region GaCdrCer
        [HttpGet("GetGaCdrCersAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCersAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrCersAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrCersApiDto, CdrCersDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region GaCdrCerDettaglio
        [HttpGet("GetGaCdrCersDettagliAsync/{cerId}/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCersDettagliAsync(long cerId, int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrCersDettagliAsync(cerId, page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrCersDettagliApiDto, CdrCersDettagliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region GaCdrComune
        [HttpGet("GetGaCdrComuniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrComuniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrComuniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrComuniApiDto, CdrComuniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }

        }
        #endregion

    }
}