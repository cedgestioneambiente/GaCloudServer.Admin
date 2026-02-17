using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Shortcuts;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
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
        [HttpPost("GetShortcutLinksAsync")]
        public async Task<IActionResult> GetShortcutLinksAsync([FromBody] PageRequest request)
        {
            try
            {
                var page = await _shortcutsService.GetShortcutLinksAsync(request);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = page });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpGet("GetShortcutLinksByRolesAsync/{roles}")]
        public async Task<IActionResult> GetShortcutLinksByRolesAsync(string roles)
        {
            try
            {
                var response = await _shortcutsService.GetShortcutLinksByRolesAsync(roles);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpGet("GetShortcutLinkByIdAsync/{id}")]
        public async Task<IActionResult> GetShortcutLinkByIdAsync(long id)
        {
            try
            {
                var response = await _shortcutsService.GetShortcutLinkByIdAsync(id);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpPost("CreateShortcutLinkAsync")]
        public async Task<IActionResult> CreateShortcutLinkAsync([FromBody]ShortcutLinkDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var response = await _shortcutsService.CreateShortcutLinkAsync(model);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status201Created, Response = response });
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpPut("UpdateShortcutLinkAsync/{id}")]
        public async Task<IActionResult> UpdateShortcutLinkAsync(long id, [FromBody] ShortcutLinkDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var response = await _shortcutsService.UpdateShortcutLinkAsync(id, model);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpDelete("DeleteShortcutLinkAsync/{id}")]
        public async Task<IActionResult> DeleteShortcutLinkAsync(long id)
        {
            try
            {
                var response = await _shortcutsService.DeleteShortcutLinkAsync(id);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        #region Functions
        [HttpGet("ValidateShortcutLinkAsync")]
        public async Task<IActionResult> ValidateShortcutLinkAsync(long id,string link)
        {
            try
            {
                var response = await _shortcutsService.ValidateShortcutLinkAsync(id,link);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpGet("ChangeStatusShortcutLinkAsync/{id}")]
        public async Task<IActionResult> ChangeStatusShortcutLinkAsync(long id)
        {
            try
            {
                var response = await _shortcutsService.ChangeStatusShortcutLinkAsync(id);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }
        #endregion

        #endregion


        #region ShortcutItems
        [HttpPost("GetShortcutItemsAsync")]
        public async Task<IActionResult> GetShortcutItemsAsync([FromBody] PageRequest request)
        {
            try
            {
                var page = await _shortcutsService.GetShortcutItemsAsync(request);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = page });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpGet("GetShortcutItemByIdAsync/{id}")]
        public async Task<IActionResult> GetShortcutItemByIdAsync(long id)
        {
            try
            {
                var dto = await _shortcutsService.GetShortcutItemByIdAsync(id);
                var apiDto = dto.ToApiDto<ShortcutItemApiDto, ShortcutItemDto>();
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = apiDto });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpPost("CreateShortcutItemAsync")]
        public async Task<IActionResult> CreateShortcutItemAsync([FromBody] ShortcutItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ShortcutItemDto, ShortcutItemApiDto>();
                var response = await _shortcutsService.CreateShortcutItemAsync(dto);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status201Created, Response = response });
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpPut("UpdateShortcutItemAsync/{id}")]
        public async Task<IActionResult> UpdateShortcutItemAsync(long id, [FromBody] ShortcutItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ShortcutItemDto, ShortcutItemApiDto>();
                var response = await _shortcutsService.UpdateShortcutItemAsync(id, dto);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpDelete("DeleteShortcutItemAsync/{id}")]
        public async Task<IActionResult> DeleteShortcutItemAsync(long id)
        {
            try
            {
                var response = await _shortcutsService.DeleteShortcutItemAsync(id);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        #region Views
        [HttpGet("GetViewShortcutByUserIdAsync/{userId}")]
        public async Task<IActionResult> GetViewShortcutByUserIdAsync(string userId)
        {
            try
            {
                var view = await _shortcutsService.GetViewShortcutByUserIdAsync(userId);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = view });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }
        #endregion

        #endregion

        #region QuickLinks
        [HttpPost("GetQuickLinksAsync")]
        public async Task<IActionResult> GetQuickLinksAsync([FromBody] PageRequest request)
        {
            try
            {
                var page = await _shortcutsService.GetQuickLinksAsync(request);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = page });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetQuickLinkByIdAsync/{id}")]
        public async Task<IActionResult> GetQuickLinkByIdAsync(long id)
        {
            try
            {
                var dto = await _shortcutsService.GetQuickLinkByIdAsync(id);
                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = dto });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpPost("CreateQuickLinkAsync")]
        public async Task<IActionResult> CreateQuickLinkAsync([FromBody] QuickLinkDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var response = await _shortcutsService.CreateQuickLinkAsync(dto);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status201Created, Response = response });
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpPut("UpdateQuickLinkAsync/{id}")]
        public async Task<IActionResult> UpdateQuickLinkAsync(long id, [FromBody] QuickLinkDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var response = await _shortcutsService.UpdateQuickLinkAsync(id, dto);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }

        [HttpDelete("DeleteQuickLinkAsync/{id}")]
        public async Task<IActionResult> DeleteQuickLinkAsync(long id)
        {
            try
            {
                var response = await _shortcutsService.DeleteQuickLinkAsync(id);

                return Ok(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, Response = ex.Message });
            }

        }
        #endregion

    }
}