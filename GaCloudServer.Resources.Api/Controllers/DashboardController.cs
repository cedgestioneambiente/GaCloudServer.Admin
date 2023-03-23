using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Dashboard;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.ApiDtos.Resources.Dashboard;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _DashboardService;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(
            IDashboardService DashboardService
            , ILogger<DashboardController> logger)
        {

            _DashboardService = DashboardService;
            _logger = logger;
        }


        [HttpPost("GetFromQueryAsync")]
        public async Task<ActionResult<ApiResponse>> GetFromQueryAsync([FromBody]DashboardQuery query)
        {
            try
            {
                var entities = await _DashboardService.GetFromQueryAsync(query.query);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpPost("ExportFromQueryAsync")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [ProducesResponseType(typeof(NoContentResult), 204)]
        [AutoWrapIgnore]
        public async Task<IActionResult> ExportFromQueryAsync(DashboardQuery query)
        {

            try
            {
                var entities = await  _DashboardService.GetFromQueryAsync(query.query);
                string title = "Query Result";
                if (entities.Count > 0)
                {
                    List<string> listColumns = new List<string>();
                    dynamic objProp = entities[0];
                    foreach (PropertyInfo prop in entities[0].GetType().GetProperties())
                    { 
                        
                    }

                    foreach (KeyValuePair<string, object> property in objProp)
                    {
                        listColumns.Add(property.Key);
                        Console.WriteLine(property.Key + ": " + property.Value);

                    }

                    string[] columns = listColumns.ToArray();


                    byte[] filecontent = ExporterHelper.ExportObjectExcel(entities, title, "", "", "Query Result", true, columns);

                    return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                    {
                        FileDownloadName = "Query_Result.xlsx"
                    };
                }
                else
                {
                    return NoContent();
                }

                
            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        #region DashboardTypes
        [HttpGet("GetDashboardTypesAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetDashboardTypesAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _DashboardService.GetDashboardTypesAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DashboardTypesApiDto, DashboardTypesDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetDashboardTypeByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetDashboardTypeByIdAsync(long id)
        {
            try
            {
                var dto = await _DashboardService.GetDashboardTypeByIdAsync(id);
                var apiDto = dto.ToApiDto<DashboardTypeApiDto, DashboardTypeDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddDashboardTypeAsync")]
        public async Task<ActionResult<ApiResponse>> AddDashboardTypeAsync([FromBody] DashboardTypeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DashboardTypeDto, DashboardTypeApiDto>();
                var response = await _DashboardService.AddDashboardTypeAsync(dto);

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

        [HttpPost("UpdateDashboardTypeAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateDashboardTypeAsync([FromBody] DashboardTypeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DashboardTypeDto, DashboardTypeApiDto>();
                var response = await _DashboardService.UpdateDashboardTypeAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteDashboardTypeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteDashboardTypeAsync(long id)
        {
            try
            {
                var response = await _DashboardService.DeleteDashboardTypeAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateDashboardTypeAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateDashboardTypeAsync(long id, string descrizione)
        {
            try
            {
                var response = await _DashboardService.ValidateDashboardTypeAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusDashboardTypeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusDashboardTypeAsync(long id)
        {
            try
            {
                var response = await _DashboardService.ChangeStatusDashboardTypeAsync(id);
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

        #region DashboardSections
        [HttpGet("GetDashboardSectionsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetDashboardSectionsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _DashboardService.GetDashboardSectionsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DashboardSectionsApiDto, DashboardSectionsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetDashboardSectionByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetDashboardSectionByIdAsync(long id)
        {
            try
            {
                var dto = await _DashboardService.GetDashboardSectionByIdAsync(id);
                var apiDto = dto.ToApiDto<DashboardSectionApiDto, DashboardSectionDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddDashboardSectionAsync")]
        public async Task<ActionResult<ApiResponse>> AddDashboardSectionAsync([FromBody] DashboardSectionApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DashboardSectionDto, DashboardSectionApiDto>();
                var response = await _DashboardService.AddDashboardSectionAsync(dto);

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

        [HttpPost("UpdateDashboardSectionAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateDashboardSectionAsync([FromBody] DashboardSectionApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DashboardSectionDto, DashboardSectionApiDto>();
                var response = await _DashboardService.UpdateDashboardSectionAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteDashboardSectionAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteDashboardSectionAsync(long id)
        {
            try
            {
                var response = await _DashboardService.DeleteDashboardSectionAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateDashboardSectionAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateDashboardSectionAsync(long id, string descrizione)
        {
            try
            {
                var response = await _DashboardService.ValidateDashboardSectionAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusDashboardSectionAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusDashboardSectionAsync(long id)
        {
            try
            {
                var response = await _DashboardService.ChangeStatusDashboardSectionAsync(id);
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

        #region DashboardItems
        [HttpGet("GetDashboardItemsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetDashboardItemsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _DashboardService.GetDashboardItemsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<DashboardItemsApiDto, DashboardItemsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetDashboardItemByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetDashboardItemByIdAsync(long id)
        {
            try
            {
                var dto = await _DashboardService.GetDashboardItemByIdAsync(id);
                var apiDto = dto.ToApiDto<DashboardItemApiDto, DashboardItemDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddDashboardItemAsync")]
        public async Task<ActionResult<ApiResponse>> AddDashboardItemAsync([FromBody] DashboardItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DashboardItemDto, DashboardItemApiDto>();
                var response = await _DashboardService.AddDashboardItemAsync(dto);

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

        [HttpPost("UpdateDashboardItemAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateDashboardItemAsync([FromBody] DashboardItemApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<DashboardItemDto, DashboardItemApiDto>();
                var response = await _DashboardService.UpdateDashboardItemAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteDashboardItemAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteDashboardItemAsync(long id)
        {
            try
            {
                var response = await _DashboardService.DeleteDashboardItemAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateDashboardItemAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateDashboardItemAsync(long id, string descrizione)
        {
            try
            {
                var response = await _DashboardService.ValidateDashboardItemAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusDashboardItemAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusDashboardItemAsync(long id)
        {
            try
            {
                var response = await _DashboardService.ChangeStatusDashboardItemAsync(id);
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