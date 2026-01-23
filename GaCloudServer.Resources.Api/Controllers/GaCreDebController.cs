using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Contratti;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System.Globalization;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaCreDebController<TUser, TKey> : ControllerBase
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly string basePath = "GaCloud/CreDeb";

        private readonly IGaCreDebService _gaCreDebService;
        private readonly ICommonService _commonService;
        private readonly ILogger<GaPreventiviController<TUser, TKey>> _logger;
        private readonly IFileService _fileService;
        private readonly IMailService _mailService;
        private readonly IPrintService _printService;
        private readonly INotificationService _notificationService;
        private readonly IQueryBuilderService _queryBuilderService;
        private readonly UserManager<TUser> _userManager;

        public GaCreDebController(
            IGaCreDebService gaCreDebService,
            ICommonService commonService,
            IFileService fileService,
            IMailService mailService,
            IPrintService printService,
            INotificationService notificationService,
            IQueryBuilderService queryBuilderService,
            UserManager<TUser> userManager,
            ILogger<GaPreventiviController<TUser, TKey>> logger)
        {
            _gaCreDebService = gaCreDebService;
            _commonService = commonService;
            _fileService = fileService;
            _mailService = mailService;
            _printService = printService;
            _notificationService = notificationService;
            _queryBuilderService = queryBuilderService;
            _userManager = userManager;
            _logger = logger;
        }

        #region CreDebConti
        [HttpPost("GetCreDebContiAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebContiAsync(PageRequest request)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebContiAsync(request);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetCreDebContoByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebContoByIdAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebContoByIdAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCreDebContoAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCreDebContoAsync(CreDebContoDto model)
        {
            try
            {
                var response = await _gaCreDebService.CreateCreDebContoAsync(model);
                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdateCreDebContoAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCreDebContoAsync(long id, [FromBody] CreDebContoDto model)
        {
            try
            {
                var response = await _gaCreDebService.UpdateCreDebContoAsync(id, model);
                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeleteCreDebContoAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeleteCreDebContoAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.DeleteCreDebContoAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region CreDebCanali
        [HttpPost("GetCreDebCanaliAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebCanaliAsync(PageRequest request)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebCanaliAsync(request);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetCreDebCanaleByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebCanaleByIdAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebCanaleByIdAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCreDebCanaleAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCreDebCanaleAsync(CreDebCanaleDto model)
        {
            try
            {
                var response = await _gaCreDebService.CreateCreDebCanaleAsync(model);
                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdateCreDebCanaleAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCreDebCanaleAsync(long id, [FromBody] CreDebCanaleDto model)
        {
            try
            {
                var response = await _gaCreDebService.UpdateCreDebCanaleAsync(id, model);
                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeleteCreDebCanaleAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeleteCreDebCanaleAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.DeleteCreDebCanaleAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #region CreDebIncassiInObjects
        [HttpPost("GetCreDebIncassiInObjectsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebIncassiInObjectsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebIncassiInObjectsAsync(request);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetCreDebIncassiInObjectByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebIncassiInObjectByIdAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebIncassiInObjectByIdAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCreDebIncassiInObjectAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCreDebIncassiInObjectAsync(CreDebIncassiInObjectDto model)
        {
            try
            {
                var response = await _gaCreDebService.CreateCreDebIncassiInObjectAsync(model);
                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdateCreDebIncassiInObjectAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCreDebIncassiInObjectAsync(long id, [FromBody] CreDebIncassiInObjectDto model)
        {
            try
            {
                var response = await _gaCreDebService.UpdateCreDebIncassiInObjectAsync(id, model);
                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeleteCreDebIncassiInObjectAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeleteCreDebIncassiInObjectAsync(long id)
        {
            try
            {
                var deleteDetailResponse = await _gaCreDebService.DeleteCreDebIncassiInObjectDetailByObjectIdAsync(id);

                if (!deleteDetailResponse)
                {
                    return BadRequest(new { Code = code.Status400BadRequest, Response = "Error deleting details" });
                }

                var response = await _gaCreDebService.DeleteCreDebIncassiInObjectAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        #region Functions
        [HttpGet("UpdateCreDebIncassiInObjectContabAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCreDebIncassiInObjectContabAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.UpdateCreDebIncassiInObjectContabAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion

        #endregion

        #region CreDebIncassiInObjectDetails
        [HttpPost("GetCreDebIncassiInObjectDetailsAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebIncassiInObjectDetailsAsync(PageRequest request)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebIncassiInObjectDetailsAsync(request);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpGet("GetCreDebIncassiInObjectDetailByIdAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebIncassiInObjectDetailByIdAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.GetCreDebIncassiInObjectDetailByIdAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCreDebIncassiInObjectDetailAsync")]
        [ProducesResponseType(code.Status201Created)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCreDebIncassiInObjectDetailAsync(CreDebIncassiInObjectDetailDto model)
        {
            try
            {
                var response = await _gaCreDebService.CreateCreDebIncassiInObjectDetailAsync(model);
                return Ok(new { Code = code.Status201Created, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPut("UpdateCreDebIncassiInObjectDetailAsync/{id}")]
        [ProducesResponseType(code.Status204NoContent)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> UpdateCreDebIncassiInObjectDetailAsync(long id, [FromBody] CreDebIncassiInObjectDetailDto model)
        {
            try
            {
                var response = await _gaCreDebService.UpdateCreDebIncassiInObjectDetailAsync(id, model);
                return Ok(new { Code = code.Status204NoContent, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpDelete("DeleteCreDebIncassiInObjectDetailAsync/{id}")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> DeleteCreDebIncassiInObjectDetailAsync(long id)
        {
            try
            {
                var response = await _gaCreDebService.DeleteCreDebIncassiInObjectDetailAsync(id);
                return Ok(new { Code = code.Status200OK, Response = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }
        #endregion


        #region Proc
        [HttpPost("GetCreDebIncassiAsync")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> GetCreDebIncassiAsync([FromBody] CreDebIncassiExportRequestApiDto request)
        {
            try
            {
                #region Default Record
                var query = System.IO.File.ReadAllText(@".\Query\CreDeb\ExtractPagamentiInDefault.sql");
                query = string.Format(query, "20241125", request.DtStart.ToString("yyyyMMdd"), request.DtEnd.ToString("yyyyMMdd"));

                var responseDefault = await _queryBuilderService.GetFromQueryAsync<CreDebIncassiExportResponseApiDto>(query);
                responseDefault.ForEach(x => x.Clean());
                #endregion

                #region Ritenute Record
                query = System.IO.File.ReadAllText(@".\Query\CreDeb\ExtractPagamentiInRitenute.sql");
                query = string.Format(query, "20241125", request.DtStart.ToString("yyyyMMdd"), request.DtEnd.ToString("yyyyMMdd"));

                var responseRitenute = await _queryBuilderService.GetFromQueryAsync<CreDebIncassiExportResponseApiDto>(query);
                responseRitenute.ForEach(x => x.Clean());
                #endregion

                var combinedResponse = responseDefault.Concat(responseRitenute).ToList();

                return Ok(new { Code = code.Status200OK, Response = combinedResponse });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(new { Code = code.Status400BadRequest, Response = ex.Message });
            }
        }

        [HttpPost("CreateCreDebExportIncassiIn")]
        [ProducesResponseType(code.Status200OK)]
        [ProducesResponseType(code.Status400BadRequest)]
        public async Task<IActionResult> CreateCreDebExportIncassiIn([FromBody] CreDebIncassiExportRequestApiDto request)
        {
            try
            {
                #region Default Record
                var query = System.IO.File.ReadAllText(@".\Query\CreDeb\ExtractPagamentiInDefault.sql");
                query = string.Format(query, "20241125", request.DtStart.ToString("yyyyMMdd"), request.DtEnd.ToString("yyyyMMdd"));

                var responseDefault = await _queryBuilderService.GetFromQueryAsync<CreDebIncassiExportResponseApiDto>(query);
                responseDefault.ForEach(x => x.Clean());
                #endregion

                #region Ritenute Record
                query = System.IO.File.ReadAllText(@".\Query\CreDeb\ExtractPagamentiInRitenute.sql");
                query = string.Format(query, "20241125", request.DtStart.ToString("yyyyMMdd"), request.DtEnd.ToString("yyyyMMdd"));

                var responseRitenute = await _queryBuilderService.GetFromQueryAsync<CreDebIncassiExportResponseApiDto>(query);
                responseRitenute.ForEach(x => x.Clean());
                #endregion

                var obj = new CreDebIncassiInObjectDto();
                obj.DtReg = DateTime.Now;
                obj.DtStart = request.DtStart;
                obj.DtEnd = request.DtEnd;
                obj.NumPag = responseDefault.Count()+responseRitenute.Count();
                var culture = new CultureInfo("it-IT");

                obj.TotPag = responseDefault.Sum(x =>
                {
                    double val;
                    return double.TryParse(x.TotaleOperazione, NumberStyles.Any, culture, out val) ? val : 0;
                });

                obj.TotPag+= responseRitenute.Sum(x =>
                {
                    double val;
                    return double.TryParse(x.TotaleOperazione, NumberStyles.Any, culture, out val) ? val : 0;
                });
                var objectId= await _gaCreDebService.CreateCreDebIncassiInObjectAsync(obj);

                var fileContent = await _gaCreDebService.GenerateCreDebRecordTextFileAsync(objectId, responseDefault, responseRitenute,request.NewProcedure);

                string folder = "IncassiExport"; 
                string fileName = $"incassi_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                var uploadResult = await _fileService.UploadText(fileContent, folder, fileName);
                obj.Id = objectId;
                obj.FileId = uploadResult.id;
                obj.FileName = uploadResult.fileName;
                obj.FileSize = uploadResult.fileSize;
                obj.FileType = "text/plain";
                await _gaCreDebService.UpdateCreDebIncassiInObjectAsync(objectId, obj);


                var response = "";

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