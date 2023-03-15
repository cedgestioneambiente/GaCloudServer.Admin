using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Autorizzazioni;
using GaCloudServer.Resources.Api.Dtos.Resources.Shortcuts;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class ShortcutsController : Controller
    {
        private readonly IShortcutsService _shortcutsService;
        private readonly ILogger<ShortcutsController> _logger;

        public ShortcutsController(
            IShortcutsService shortcutsService
            , ILogger<ShortcutsController> logger)
        {

            _shortcutsService = shortcutsService;
            _logger = logger;
        }


        #region ShortcutLinks
        [HttpGet("GetShortcutLinksAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetShortcutLinksAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _shortcutsService.GetShortcutLinksAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ShortcutLinksApiDto, ShortcutLinksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetShortcutLinksByRolesAsync/{roles}")]
        public async Task<ActionResult<ApiResponse>> GetShortcutLinksByRolesAsync(string roles)
        {
            try
            {
                var dtos = await _shortcutsService.GetShortcutLinksByRolesAsync(roles);
                var apiDtos = dtos.ToApiDto<ShortcutLinksApiDto, ShortcutLinksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetShortcutLinkByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetShortcutLinkByIdAsync(long id)
        {
            try
            {
                var dto = await _shortcutsService.GetShortcutLinkByIdAsync(id);
                var apiDto = dto.ToApiDto<ShortcutLinkApiDto, ShortcutLinkDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddShortcutLinkAsync")]
        public async Task<ActionResult<ApiResponse>> AddShortcutLinkAsync([FromBody]ShortcutLinkApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ShortcutLinkDto, ShortcutLinkApiDto>();
                var response = await _shortcutsService.AddShortcutLinkAsync(dto);

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

        [HttpPost("UpdateShortcutLinkAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateShortcutLinkAsync([FromBody] ShortcutLinkApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ShortcutLinkDto, ShortcutLinkApiDto>();
                var response = await _shortcutsService.UpdateShortcutLinkAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteShortcutLinkAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteShortcutLinkAsync(long id)
        {
            try
            {
                var response = await _shortcutsService.DeleteShortcutLinkAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateShortcutLinkAsync")]
        public async Task<ActionResult<ApiResponse>> ValidateShortcutLinkAsync(long id,string link)
        {
            try
            {
                var response = await _shortcutsService.ValidateShortcutLinkAsync(id,link);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusShortcutLinkAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusShortcutLinkAsync(long id)
        {
            try
            {
                var response = await _shortcutsService.ChangeStatusShortcutLinkAsync(id);
                return new ApiResponse(response);
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