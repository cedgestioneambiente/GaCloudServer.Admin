using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Autorizzazioni;
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
    public class GaAutorizzazioniController : Controller
    {
        private readonly IGaAutorizzazioniService _gaAutorizzazioniService;
        private readonly IApiErrorResources _errorResources;

        public GaAutorizzazioniController(IGaAutorizzazioniService gaAutorizzazioniService,IApiErrorResources errorResources)
        {

            _gaAutorizzazioniService = gaAutorizzazioniService;
            _errorResources= errorResources;
        }

        [HttpGet("GetGaAutorizzazioniTipiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaAutorizzazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaAutorizzazioniService.GetGaAutorizzazioniTipiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<AutorizzazioniTipiApiDto, AutorizzazioniTipiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
            
        }
    }
}