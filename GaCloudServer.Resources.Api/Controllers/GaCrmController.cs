using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Crm;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaCrmController : Controller
    {
        private readonly IGaCrmService _gaCrmService;
        private readonly ILogger<GaCrmController> _logger;

        public GaCrmController(
            IGaCrmService gaCrmService
            , ILogger<GaCrmController> logger)
        {

            _gaCrmService = gaCrmService;
            _logger = logger;
        }

        #region CrmMaster

        #region Views
        [HttpGet("GetViewGaCrmMasterAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCrmMasterAsync()
        {
            try
            {
                var view = await _gaCrmService.GetViewGaCrmMasterAsync();
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

        #region CrmEventStates
        [HttpGet("GetGaCrmEventStatesAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventStatesAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmEventStatesAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CrmEventStatesApiDto, CrmEventStatesDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmEventStateByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventStateByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventStateByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventStateApiDto, CrmEventStateDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmEventStateAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmEventStateAsync([FromBody] CrmEventStateApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventStateDto, CrmEventStateApiDto>();
                var response = await _gaCrmService.AddGaCrmEventStateAsync(dto);

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

        [HttpPost("UpdateGaCrmEventStateAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventStateAsync([FromBody] CrmEventStateApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventStateDto, CrmEventStateApiDto>();
                var response = await _gaCrmService.UpdateGaCrmEventStateAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCrmEventStateAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmEventStateAsync(long id)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmEventStateAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaCrmEventStateAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaCrmEventStateAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ValidateGaCrmEventStateAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaCrmEventStateAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaCrmEventStateAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ChangeStatusGaCrmEventStateAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        #endregion

        #endregion

        #region CrmEventAreas
        [HttpGet("GetGaCrmEventAreasAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventAreasAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmEventAreasAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CrmEventAreasApiDto, CrmEventAreasDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmEventAreaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventAreaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventAreaByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventAreaApiDto, CrmEventAreaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmEventAreaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmEventAreaAsync([FromBody] CrmEventAreaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventAreaDto, CrmEventAreaApiDto>();
                var response = await _gaCrmService.AddGaCrmEventAreaAsync(dto);

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

        [HttpPost("UpdateGaCrmEventAreaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventAreaAsync([FromBody] CrmEventAreaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventAreaDto, CrmEventAreaApiDto>();
                var response = await _gaCrmService.UpdateGaCrmEventAreaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCrmEventAreaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmEventAreaAsync(long id)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmEventAreaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaCrmEventAreaAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaCrmEventAreaAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ValidateGaCrmEventAreaAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaCrmEventAreaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaCrmEventAreaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ChangeStatusGaCrmEventAreaAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        #endregion

        #endregion

        #region CrmEvents
        [HttpGet("GetGaCrmEventsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmEventsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CrmEventsApiDto, CrmEventsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmEventByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventApiDto, CrmEventDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmEventByTicketIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventByTicketIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventByTicketIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventApiDto, CrmEventDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmEventAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmEventAsync([FromBody] CrmEventApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventDto, CrmEventApiDto>();
                var response = await _gaCrmService.AddGaCrmEventAsync(dto);

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

        [HttpPost("UpdateGaCrmEventAsync")] 
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventAsync([FromBody] CrmEventApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventDto, CrmEventApiDto>();
                var response = await _gaCrmService.UpdateGaCrmEventAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCrmEventAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmEventAsync(long id)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmEventAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaCrmEventAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaCrmEventAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ValidateGaCrmEventAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaCrmEventAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaCrmEventAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ChangeStatusGaCrmEventAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        #endregion

        #endregion


    }
}