using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Shared;
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
    public class CommonController : Controller
    {

        private readonly ICommonService _commonService;
        private readonly ILogger<CommonController> _logger;

        public CommonController(
            ICommonService commonService
            , ILogger<CommonController> logger)
        {

            _commonService = commonService;
            _logger = logger;
            
        }

        #region Gauge
        [HttpPost("GetCommonGaugesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCommonGaugesAsync(PageRequest request)
        {
            try
            {
                var response = await _commonService.GetCommonGaugesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetCommonGaugeByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCommonGaugeByIdAsync(long id)
        {
            try
            {
                var response = await _commonService.GetCommonGaugeByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCommonGaugeAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCommonGaugeAsync(CommonGaugeDto model)
        {
            try
            {
                var response = await _commonService.CreateCommonGaugeAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdateCommonGaugeAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCommonGaugeAsync(long id, [FromBody] CommonGaugeDto model)
        {
            try
            {
                var response = await _commonService.UpdateCommonGaugeAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeleteCommonGaugeAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeleteCommonGaugeAsync(long id)
        {
            try
            {
                var response = await _commonService.DeleteCommonGaugeAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region IvaCode
        [HttpPost("GetCommonIvaCodesAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCommonIvaCodesAsync(PageRequest request)
        {
            try
            {
                var response = await _commonService.GetCommonIvaCodesAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetCommonIvaCodeByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCommonIvaCodeByIdAsync(long id)
        {
            try
            {
                var response = await _commonService.GetCommonIvaCodeByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCommonIvaCodeAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCommonIvaCodeAsync(CommonIvaCodeDto model)
        {
            try
            {
                var response = await _commonService.CreateCommonIvaCodeAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdateCommonIvaCodeAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCommonIvaCodeAsync(long id, [FromBody] CommonIvaCodeDto model)
        {
            try
            {
                var response = await _commonService.UpdateCommonIvaCodeAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeleteCommonIvaCodeAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeleteCommonIvaCodeAsync(long id)
        {
            try
            {
                var response = await _commonService.DeleteCommonIvaCodeAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region BankAccount
        [HttpPost("GetCommonBankAccountsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCommonBankAccountsAsync(PageRequest request)
        {
            try
            {
                var response = await _commonService.GetCommonBankAccountsAsync(request);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetCommonBankAccountByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCommonBankAccountByIdAsync(long id)
        {
            try
            {
                var response = await _commonService.GetCommonBankAccountByIdAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCommonBankAccountAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCommonBankAccountAsync(CommonBankAccountDto model)
        {
            try
            {
                var response = await _commonService.CreateCommonBankAccountAsync(model);

                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdateCommonBankAccountAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCommonBankAccountAsync(long id, [FromBody] CommonBankAccountDto model)
        {
            try
            {
                var response = await _commonService.UpdateCommonBankAccountAsync(id, model);

                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeleteCommonBankAccountAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeleteCommonBankAccountAsync(long id)
        {
            try
            {
                var response = await _commonService.DeleteCommonBankAccountAsync(id);

                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

    }

}



