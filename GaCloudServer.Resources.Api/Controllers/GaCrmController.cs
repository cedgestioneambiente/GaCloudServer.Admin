using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Crm;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using code = Microsoft.AspNetCore.Http.StatusCodes;

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
        private readonly IPrintService _printService;

        public GaCrmController(
            IGaCrmService gaCrmService
            , IPrintService printService
            , ILogger<GaCrmController> logger)
        {

            _gaCrmService = gaCrmService;
            _printService = printService;
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

        [HttpGet("GetGaCrmEventsByBoardAsync/{date}/{area}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventsByBoardAsync(DateTime date,long area)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmEventByBoardAsync(date,area);
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
                var devicesRemove = await _gaCrmService.DeleteGaCrmEventDevicesByEventIdAsync(id);
                if (devicesRemove)
                {
                    var response = await _gaCrmService.DeleteGaCrmEventAsync(id);

                    return new ApiResponse(response);
                }
                else
                {
                    return new ApiResponse(false);
                }

                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        

        [HttpGet("PrintGaCrmEventsByFilterAsync/{date}/{areaId}")]
        public async Task<ApiResponse> PrintGaContactCenterIngByFilterAsync(DateTime date,long areaId)
        {
            try
            {
                var list = await _gaCrmService.GetGaCrmEventByBoardAsync(date,areaId);

                if (list == null || (list.Data.Where(x => x.CrmEventStateId == 1).Count() == 0))
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(areaId);
                var dto = await  GenerateCrmEventsTemplate(list.Data, date, area.Descrizione);
                var response = await _printService.Print("CrmEvents", dto);

                //var dto = GenerateContactCenterTicketsIngTemplate(apiDto.all ? list : list.Where(x => x.Stato == "IN GESTIONE").ToList(), apiDto.comuneAltro, apiDto.dataEsecuzione.GetValueOrDefault(), apiDto.tipoStampa);
                //var response = await _printService.Print("ContactCenterTicketsIng", dto);


                //var printDto = new ContactCenterStatusTicketsApiDto();
                //if (apiDto.all)
                //{
                //    printDto.ticketsId = (from x in list
                //                          select x.Id).ToArray();

                //}
                //else
                //{
                //    printDto.ticketsId = (from x in list
                //                          where x.Stato == "IN GESTIONE"
                //    select x.Id).ToArray();

                //}
                //await _gaContactCenterService.SetPrintedGaContactCenterTicketsAsync(printDto.ticketsId);

                return new ApiResponse(response);

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }
        #endregion

        #endregion

        #region CrmEventDevices
        [HttpGet("GetGaCrmEventDevicesByEventIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventDevicesByEventIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventDevicesByEventIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventDevicesApiDto, CrmEventDevicesDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        #region Functions
        [HttpGet("ChangeStatusGaCrmEventDeviceAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCrmEventDeviceAsync(long id)
        {
            try
            {
                var result = await _gaCrmService.ChangeStatusGaCrmEventDeviceAsync(id);

                return new ApiResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeSelectionGaCrmEventDeviceAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeSelectionGaCrmEventDeviceAsync(long id)
        {
            try
            {
                var result = await _gaCrmService.ChangeSelectionGaCrmEventDeviceAsync(id);

                return new ApiResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion
        #endregion

        #region CrmEventJobs
        [HttpGet("GetViewGaCrmEventJobsAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCrmEventJobsAsync()
        {
            try
            {
                var view = await _gaCrmService.GetViewGaCrmEventJobsAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("GetViewGaCrmEventJobsByFilterAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCrmEventJobsByFilterAsync([FromBody]DateRangeDto filter)
        {
            try
            {
                var view = await _gaCrmService.GetViewGaCrmEventJobsByFilterAsync(filter.dateStart,filter.dateEnd);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region Helpers
        private async Task<CrmEventsTemplateDto> GenerateCrmEventsTemplate(List<CrmEventDto> events, DateTime date, string area)
        {
            var dto = new CrmEventsTemplateDto()
            {
                FileName = "CrmEventss.pdf",
                FilePath = @"Print/Crm",
                Title = "Crm Eventi Programmati",
                Css = "CrmEvents",
                Area = area,
                Data = date.ToString("dd/MM/yyyy"),
                Items = new List<CrmEventDto>(),
                Devices= new List<CrmEventDeviceDto>()
            };

            foreach (var item in events)
            {
                dto.Items.Add(item);

                var devices = await _gaCrmService.GetGaCrmEventDevicesByEventIdAsync(item.Id);
                foreach (var device in devices.Data)
                {
                    if (device.Selected)
                        dto.Devices.Add(device);
                }
            
            }

            return dto;

        }
        #endregion


    }
}