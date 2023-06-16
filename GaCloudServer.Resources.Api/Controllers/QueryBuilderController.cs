using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.BusinnessLogic.Dtos.Resources.QueryBuilder;
using GaCloudServer.BusinnessLogic.Hub.Interfaces;
using GaCloudServer.BusinnessLogic.Hub;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.QueryBuilder;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Reflection;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class QueryBuilderController : Controller
    {
        private readonly IQueryBuilderService _queryBuilderService;
        private readonly ILogger<QueryBuilderController> _logger;
        private readonly IHubContext<BackgroundServicesHub, IBackgroundServicesHub> hub;

        public QueryBuilderController(
            IQueryBuilderService queryBuilderService
            , IHubContext<BackgroundServicesHub, IBackgroundServicesHub> hub
            , ILogger<QueryBuilderController> logger)
        {

            _queryBuilderService = queryBuilderService;
            _logger = logger;
            this.hub = hub;
        }


        [HttpGet("GetFromQueryAsync/{query}")]
        public async Task<ActionResult<ApiResponse>> GetFromQueryAsync(string query)
        {
            try
            {
                var entities = await _queryBuilderService.GetFromQueryAsync(query);
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
        public async Task<IActionResult> ExportFromQueryAsync(QueryBuilderQuery query)
        {

            try
            {
                DownloadProgressDto progress = new DownloadProgressDto();
                progress.progress = 0;
                progress.message = "Elaborazione query in corso...";
                await hub.Clients.Groups(query.userId).DownloadProgress(progress);

                var entities = await  _queryBuilderService.GetFromQueryAsync(query.query);
                progress.progress = 40;
                progress.message =string.Format("Elaborazione {0} risultati in corso...",entities.Count());
                await hub.Clients.Groups(query.userId).DownloadProgress(progress);

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

                    progress.progress = 60;
                    progress.message = string.Format("Conversione {0} risultati in corso...", entities.Count());
                    await hub.Clients.Groups(query.userId).DownloadProgress(progress);

                    string[] columns = listColumns.ToArray();

                    progress.progress = 80;
                    progress.message = string.Format("Esportazione {0} risultati in corso...", entities.Count());
                    await hub.Clients.Groups(query.userId).DownloadProgress(progress);
                    byte[] filecontent = ExporterHelper.ExportObjectExcel(entities, title, "forceDateTime", "", "Query Result", false, columns);

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
                _logger.LogError(ex.Message);
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        #region QueryBuilderParamTypes
        [HttpGet("GetQueryBuilderParamTypesAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderParamTypesAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _queryBuilderService.GetQueryBuilderParamTypesAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<QueryBuilderParamTypesApiDto, QueryBuilderParamTypesDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetQueryBuilderParamTypeByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderParamTypeByIdAsync(long id)
        {
            try
            {
                var dto = await _queryBuilderService.GetQueryBuilderParamTypeByIdAsync(id);
                var apiDto = dto.ToApiDto<QueryBuilderParamTypeApiDto, QueryBuilderParamTypeDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddQueryBuilderParamTypeAsync")]
        public async Task<ActionResult<ApiResponse>> AddQueryBuilderParamTypeAsync([FromBody] QueryBuilderParamTypeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderParamTypeDto, QueryBuilderParamTypeApiDto>();
                var response = await _queryBuilderService.AddQueryBuilderParamTypeAsync(dto);

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

        [HttpPost("UpdateQueryBuilderParamTypeAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateQueryBuilderParamTypeAsync([FromBody] QueryBuilderParamTypeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderParamTypeDto, QueryBuilderParamTypeApiDto>();
                var response = await _queryBuilderService.UpdateQueryBuilderParamTypeAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteQueryBuilderParamTypeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteQueryBuilderParamTypeAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.DeleteQueryBuilderParamTypeAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateQueryBuilderParamTypeAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateQueryBuilderParamTypeAsync(long id, string descrizione)
        {
            try
            {
                var response = await _queryBuilderService.ValidateQueryBuilderParamTypeAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusQueryBuilderParamTypeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusQueryBuilderParamTypeAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.ChangeStatusQueryBuilderParamTypeAsync(id);
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

        #region QueryBuilderSections
        [HttpGet("GetQueryBuilderSectionsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderSectionsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _queryBuilderService.GetQueryBuilderSectionsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<QueryBuilderSectionsApiDto, QueryBuilderSectionsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetQueryBuilderSectionByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderSectionByIdAsync(long id)
        {
            try
            {
                var dto = await _queryBuilderService.GetQueryBuilderSectionByIdAsync(id);
                var apiDto = dto.ToApiDto<QueryBuilderSectionApiDto, QueryBuilderSectionDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddQueryBuilderSectionAsync")]
        public async Task<ActionResult<ApiResponse>> AddQueryBuilderSectionAsync([FromBody] QueryBuilderSectionApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderSectionDto, QueryBuilderSectionApiDto>();
                var response = await _queryBuilderService.AddQueryBuilderSectionAsync(dto);

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

        [HttpPost("UpdateQueryBuilderSectionAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateQueryBuilderSectionAsync([FromBody] QueryBuilderSectionApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderSectionDto, QueryBuilderSectionApiDto>();
                var response = await _queryBuilderService.UpdateQueryBuilderSectionAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteQueryBuilderSectionAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteQueryBuilderSectionAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.DeleteQueryBuilderSectionAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateQueryBuilderSectionAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateQueryBuilderSectionAsync(long id, string descrizione)
        {
            try
            {
                var response = await _queryBuilderService.ValidateQueryBuilderSectionAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusQueryBuilderSectionAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusQueryBuilderSectionAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.ChangeStatusQueryBuilderSectionAsync(id);
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

        #region QueryBuilderScripts
        [HttpGet("GetQueryBuilderScriptsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderScriptsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _queryBuilderService.GetQueryBuilderScriptsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<QueryBuilderScriptsApiDto, QueryBuilderScriptsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetQueryBuilderScriptByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderScriptByIdAsync(long id)
        {
            try
            {
                var dto = await _queryBuilderService.GetQueryBuilderScriptByIdAsync(id);
                var apiDto = dto.ToApiDto<QueryBuilderScriptApiDto, QueryBuilderScriptDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddQueryBuilderScriptAsync")]
        public async Task<ActionResult<ApiResponse>> AddQueryBuilderScriptAsync([FromBody] QueryBuilderScriptApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderScriptDto, QueryBuilderScriptApiDto>();
                var response = await _queryBuilderService.AddQueryBuilderScriptAsync(dto);

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

        [HttpPost("UpdateQueryBuilderScriptAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateQueryBuilderScriptAsync([FromBody] QueryBuilderScriptApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderScriptDto, QueryBuilderScriptApiDto>();
                var response = await _queryBuilderService.UpdateQueryBuilderScriptAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteQueryBuilderScriptAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteQueryBuilderScriptAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.DeleteQueryBuilderScriptAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateQueryBuilderScriptAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateQueryBuilderScriptAsync(long id, string descrizione)
        {
            try
            {
                var response = await _queryBuilderService.ValidateQueryBuilderScriptAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusQueryBuilderScriptAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusQueryBuilderScriptAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.ChangeStatusQueryBuilderScriptAsync(id);
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

        #region QueryBuilderParamOnScripts
        [HttpGet("GetQueryBuilderParamOnScriptsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderParamOnScriptsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _queryBuilderService.GetQueryBuilderParamOnScriptsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<QueryBuilderParamOnScriptsApiDto, QueryBuilderParamOnScriptsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetQueryBuilderParamOnScriptsByScriptIdAsync/{scriptId}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderParamOnScriptsByScriptIdAsync(long scriptId)
        {
            try
            {
                var dtos = await _queryBuilderService.GetQueryBuilderParamOnScriptsByScriptIdAsync(scriptId);
                var apiDtos = dtos.ToApiDto<QueryBuilderParamOnScriptsApiDto, QueryBuilderParamOnScriptsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetQueryBuilderParamOnScriptByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetQueryBuilderParamOnScriptByIdAsync(long id)
        {
            try
            {
                var dtos = await _queryBuilderService.GetQueryBuilderParamOnScriptByIdAsync(id);
                var apiDtos = dtos.ToApiDto<QueryBuilderParamOnScriptApiDto, QueryBuilderParamOnScriptDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpPost("AddQueryBuilderParamOnScriptAsync")]
        public async Task<ActionResult<ApiResponse>> AddQueryBuilderParamOnScriptAsync([FromBody] QueryBuilderParamOnScriptApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderParamOnScriptDto, QueryBuilderParamOnScriptApiDto>();
                var response = await _queryBuilderService.AddQueryBuilderParamOnScriptAsync(dto);

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

        [HttpPost("UpdateQueryBuilderParamOnScriptAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateQueryBuilderParamOnScriptAsync([FromBody] QueryBuilderParamOnScriptApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<QueryBuilderParamOnScriptDto, QueryBuilderParamOnScriptApiDto>();
                var response = await _queryBuilderService.UpdateQueryBuilderParamOnScriptAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteQueryBuilderParamOnScriptAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteQueryBuilderParamOnScriptAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.DeleteQueryBuilderParamOnScriptAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateQueryBuilderParamOnScriptAsync/{id}/{scriptId}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateQueryBuilderParamOnScriptAsync(long id,long scriptId, string descrizione)
        {
            try
            {
                var response = await _queryBuilderService.ValidateQueryBuilderParamOnScriptAsync(id, scriptId,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusQueryBuilderParamOnScriptAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusQueryBuilderParamOnScriptAsync(long id)
        {
            try
            {
                var response = await _queryBuilderService.ChangeStatusQueryBuilderParamOnScriptAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region Views
        [HttpGet("GetViewQueryBuilderParamOnScriptsByScriptIdAsync/{scriptId}")]
        public async Task<ActionResult<ApiResponse>> GetViewQueryBuilderParamOnScriptsByScriptIdAsync(long scriptId)
        {
            try
            {
                var view = await _queryBuilderService.GetViewQueryBuilderParamOnScriptsByScriptIdAsync(scriptId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewQueryBuilderScriptsAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewQueryBuilderScriptsAsync()
        {
            try
            {
                var view = await _queryBuilderService.GetViewQueryBuilderScriptsAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewQueryBuilderScriptsByRolesAsync/{roles}")]
        public async Task<ActionResult<ApiResponse>> GetViewQueryBuilderScriptsByRolesAsync(string roles)
        {
            try
            {
                var view = await _queryBuilderService.GetViewQueryBuilderScriptsByRolesAsync(roles);
                return new ApiResponse(view);
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