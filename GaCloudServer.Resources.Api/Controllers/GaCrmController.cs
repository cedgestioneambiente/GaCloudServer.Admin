using AutoMapper;
using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Constants;
using GaCloudServer.Resources.Api.Dtos.Crm;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Garbage;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        private readonly IMailService _mailService;
        private readonly IFileService _fileService;
        private readonly IFtpService _ftpService;
        private readonly INotificationService _notificationService;

        public GaCrmController(
            IGaCrmService gaCrmService
            , IMailService mailService
            , INotificationService notificationService
            , IPrintService printService
            , IFileService fileService
            , IFtpService ftpService
            , ILogger<GaCrmController> logger)
        {

            _gaCrmService = gaCrmService;
            _printService = printService;
            _mailService = mailService;
            _notificationService = notificationService;
            _fileService = fileService;
            _ftpService = ftpService;
            _logger = logger;
        }

        #region CrmMaster

        [HttpGet("UpdateCrmMasterStateByIdAsunc/{id}/{state}")]
        public async Task<ActionResult<ApiResponse>> UpdateCrmMasterStateByIdAsunc(int id, long state)
        {
            try
            {
                var result = await _gaCrmService.UpdateCrmMasterStateByIdAsync(id, state);
                return new ApiResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

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

        #region CrmEventComuni
        [HttpGet("GetGaCrmEventComuniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventComuniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmEventComuniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CrmEventComuniApiDto, CrmEventComuniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmEventComuneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventComuneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventComuneByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventComuneApiDto, CrmEventComuneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmEventComuneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmEventComuneAsync([FromBody] CrmEventComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventComuneDto, CrmEventComuneApiDto>();
                var response = await _gaCrmService.AddGaCrmEventComuneAsync(dto);

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

        [HttpPost("UpdateGaCrmEventComuneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventComuneAsync([FromBody] CrmEventComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventComuneDto, CrmEventComuneApiDto>();
                var response = await _gaCrmService.UpdateGaCrmEventComuneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCrmEventComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmEventComuneAsync(long id)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmEventComuneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaCrmEventComuneAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaCrmEventComuneAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ValidateGaCrmEventComuneAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaCrmEventComuneAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaCrmEventComuneAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ChangeStatusGaCrmEventComuneAsync(id);
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
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventsByBoardAsync(DateTime date, long area)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmEventByBoardAsync(date, area, true);
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

                var responseTari = await _gaCrmService.UpdateCrmTicketStateByIdAsync(dto.CrmTicketId, dto.CrmEventStateId,dto.NotaOperatore);

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
                var dto = await _gaCrmService.GetGaCrmEventByIdAsync(id);

                var devicesRemove = await _gaCrmService.DeleteGaCrmEventDevicesByEventIdAsync(id);
                if (devicesRemove)
                {
                    var response = await _gaCrmService.DeleteGaCrmEventAsync(id);
                    var responseTari = await _gaCrmService.UpdateCrmTicketStateByIdAsync(dto.CrmTicketId, 1, dto.NotaOperatore);


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
        [HttpGet("UpdateGaCrmEventStateByIdAsync/{id}/{crmId}/{state}")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventStateByIdAsync(long id, int crmId, long state)
        {
            try
            {
                var response = await _gaCrmService.UpdateGaCrmEventStateByIdAsync(id, state);
                if (response)
                {
                    var responseTari = await _gaCrmService.UpdateCrmTicketStateByIdAsync(crmId, state);
                    if (responseTari > 0)
                    {
                        return new ApiResponse(response);
                    }
                    else
                    {
                        return new ApiResponse("TariError", null, code.Status200OK);
                    }

                }
                else
                {
                    return new ApiResponse("CrmError", null, code.Status200OK);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("UpdateGaCrmEventStatesByFilterAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventStatesByFilterAsync([FromBody] List<CrmChangeEventStateDto> dto)
        {
            try
            {
                int error = 0;
                int crmError = 0;

                foreach (var itm in dto)
                {
                    var response = await _gaCrmService.UpdateGaCrmEventStateByIdAsync(itm.id, itm.state);
                    if (response)
                    {
                        var devices = await _gaCrmService.GetGaCrmEventDevicesByEventIdAsync(itm.id);
                        if (itm.state == 2)
                        {

                            foreach (var device in devices.Data)
                            {
                                if (device.Selected)
                                {
                                    await _gaCrmService.SetCompletedGaCrmEventDeviceAsync(device.Id);
                                }
                            }
                        }
                        else
                        {
                            foreach (var device in devices.Data)
                            {
                                if (device.Selected)
                                {
                                    await _gaCrmService.SetNotCompletedGaCrmEventDeviceAsync(device.Id);
                                }
                            }

                        }


                        var responseTari = await _gaCrmService.UpdateCrmTicketStateByIdAsync(itm.crmId, itm.state);
                        if (responseTari > 0)
                        {

                        }
                        else
                        {
                            crmError++;
                        }

                    }
                    else
                    {
                        error++;
                    }
                }

                if (error + crmError > 0)
                {
                    return new ApiResponse(string.Format("CrmError: {0}, TariError: {1}", error, crmError), "PartialError", code.Status200OK);
                }
                else
                {
                    return new ApiResponse(true);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("PrintGaCrmEventsGroupedByFilterAsync/{date}/{areaId}/{includeAll}")]
        public async Task<ApiResponse> PrintGaCrmEventsGroupedByFilterAsync(DateTime date, long areaId,bool includeAll)
        {
            try
            {
                var list = await _gaCrmService.GetGaCrmEventByBoardAsync(date, areaId, true);

                if (list == null || (list.Data.Where(x => x.CrmEventStateId == 1).Count() == 0))
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(areaId);
                var dto = await GenerateCrmEventsGroupedTemplate(list.Data.Where(x => x.CrmEventStateId == 1).ToList(), date, area.Descrizione,includeAll);
                if (dto.Items.Count > 0)
                {
                    var response = await _printService.Print("CrmEventsGrouped", dto);

                    return new ApiResponse(response);
                }
                else
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpGet("PrintGaCrmEventsMergedByFilterAsync/{date}/{areaId}")]
        public async Task<ApiResponse> PrintGaCrmEventsMergedByFilterAsync(DateTime date, long areaId)
        {
            try
            {
                var tipologie = await _gaCrmService.GetGaCrmTipiTicketAsync(true);
                var templates = await _gaCrmService.GetGaCrmPrintTemplatesAsync(1, 0);
                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(areaId);

                var list = await _gaCrmService.GetGaCrmEventByBoardAsync(date, areaId, true);

                var dtos = new List<CrmEventTemplateDto>();
                int counter = 0;

                foreach (var _event in list.Data.Where(x => x.CrmEventStateId == 1))
                {
                    var _tipo = tipologie.Data.Where(x => x.Id == _event.TipoId).First();
                    if (!_tipo.PrintMassive)
                    {
                        counter++;
                        if (_tipo.ContactCenterPrintTemplateId == 0 || _tipo.ContactCenterPrintTemplateId == null)
                        {
                            var dto = await GenerateCrmEventMergeTemplate(_event, _event.DateSchedule, area.Descrizione, _tipo.Descrizione, "CrmEventDefault");
                            dtos.Add(dto);
                        }
                        else
                        {
                            var _template = templates.Data.Where(x => x.Id == _tipo.ContactCenterPrintTemplateId).First();
                            var dto = await GenerateCrmEventMergeTemplate(_event, _event.DateSchedule, area.Descrizione, "Redatto in duplice copia", _template.Template + ".pdf", _template.Template);
                            dtos.Add(dto);
                        }
                    }
                }

                if (counter > 0)
                {
                    var response = await _printService.PrintMerged(dtos);

                    return new ApiResponse(response);
                }
                else
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }




            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpGet("PrintGaCrmEventReciptByIdAsync/{id}")]
        public async Task<ApiResponse> PrintGaCrmEventReciptByIdAsync(long id)
        {
            try
            {
                var _event = await _gaCrmService.GetGaCrmEventByIdAsync(id);


                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(_event.CrmEventAreaId);
                if (_event.Tipo == "RITIRO CONTENITORI")
                {
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione, "Ricevuta Prenotazione Ritiro");
                    var response = await _printService.Print("CrmEventRecipt", dto);

                    return new ApiResponse(response);
                }
                else
                {
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione, "Ricevuta Prenotazione Ritiro per Cessazione " + DateTime.Now.ToString("dd/MM/yyyy"), false,"CrmEventCloseRecipt.pdf", "CrmEventCloseRecipt");
                    var response = await _printService.Print("CrmEventCloseRecipt", dto);

                    return new ApiResponse(response);
                }

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpGet("PrintGaCrmEventByIdAsync/{id}")]
        public async Task<ApiResponse> PrintGaCrmEventByIdAsync(long id)
        {
            try
            {
                var _event = await _gaCrmService.GetGaCrmEventByIdAsync(id);
                var tipologie = await _gaCrmService.GetGaCrmTipiTicketAsync(true);
                var _tipo = tipologie.Data.Where(x => x.Id == _event.TipoId).First();
                var templates = await _gaCrmService.GetGaCrmPrintTemplatesAsync(1, 0);


                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(_event.CrmEventAreaId);
                if (_tipo.ContactCenterPrintTemplateId == 0 || _tipo.ContactCenterPrintTemplateId == null)
                {
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione, _tipo.Descrizione);
                    var response = await _printService.Print("CrmEventDefault", dto);

                    return new ApiResponse(response);
                }
                else
                {
                    var _template = templates.Data.Where(x => x.Id == _tipo.ContactCenterPrintTemplateId).First();
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione, "Redatto in duplice copia",false, _template.Template + ".pdf", _template.Template);
                    var response = await _printService.Print(_template.Template, dto);

                    return new ApiResponse(response);
                }

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }


        [HttpGet("SendGaCrmEventsByFilterAsync/{date}/{areaId}/{userId}/{userName}/{all}")]
        public async Task<ApiResponse> SendGaCrmEventsByFilterAsync(DateTime date, long areaId, string userId, string userName, bool all)
        {
            try
            {
                var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.Crm, AppConsts.CrmInfo);


                var list = await _gaCrmService.GetGaCrmEventByBoardAsync(date, areaId, all);

                if (list == null || (list.Data.Where(x => x.CrmEventStateId == 2).Count() == 0))
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(areaId);
                var dto = await GenerateCrmEventsGroupedTemplate(list.Data.Where(x => x.CrmEventStateId == 2).ToList(), date, area.Descrizione,false, "CrmEventsReport.pdf");
                var attachPath = await _printService.Print("CrmEventsReport", dto);

                string mailTo = "tariffa@gestioneambiente.net";
                string mailCC = "matteo.derocchi@gestioneambiente.net;ced@gestioneambiente.net";

                var result = await _mailService.AddMailJobAsync(new MailJob()
                {
                    Id = 0,
                    Description = string.Format("Rapporto Ritiri {0} - {1}", date.ToString("dd/MM/yyyy"), area.Descrizione),
                    DateScheduled = DateTime.Now,
                    Title = string.Format("Rapporto Ritiri {0} - {1}", date.ToString("dd/MM/yyyy"), area.Descrizione),
                    MailingTo = mailTo,
                    MailCc = mailCC,
                    Application = String.Format("{0}|{1}", notificationApp.Id, AppConsts.Crm),
                    Content = HtmlHelpers.GenerateText("In allegato è possibile visionare il report.<br>" + userName),
                    Template = "DefaultMailJob.html",
                    UserId = userId,
                    OkMessage = String.Format("Il Report {0} - {1} è stato inoltrato correttamente.", date.ToString("dd/MM/yyyy"), area.Descrizione),
                    KoMessage = String.Format("Si è verificato un problema durante l'invio del Report {0} - {1}.", date.ToString("dd/MM/yyyy"), area.Descrizione),
                    Attachment = true,
                    AttachmentPath = attachPath
                });

                var response = await _gaCrmService.UpdateGaCrmEventsSendedAsync(list.Data.Where(x => x.CrmEventStateId == 2).ToList());

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

        [HttpGet("GetGaCrmEventDevicesByTicketIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventDevicesByTicketIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventDevicesByTicketIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventDevicesApiDto, CrmEventDevicesDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmEventDeviceByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventDeviceByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmEventDeviceByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmEventDeviceApiDto, CrmEventDeviceDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmEventDeviceAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmEventDeviceAsync([FromBody] CrmEventDeviceApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventDeviceDto, CrmEventDeviceApiDto>();
                var response = await _gaCrmService.AddGaCrmEventDeviceAsync(dto);

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

        [HttpPost("UpdateGaCrmEventDeviceAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventDeviceAsync([FromBody] CrmEventDeviceApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmEventDeviceDto, CrmEventDeviceApiDto>();
                var response = await _gaCrmService.UpdateGaCrmEventDeviceAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCrmEventDeviceAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmEventDeviceAsync(long id)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmEventDeviceAsync(id);

                return new ApiResponse(response);


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

        [HttpGet("ChangeSostLuchGaCrmEventDeviceAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeSostLuchGaCrmEventDeviceAsync(long id)
        {
            try
            {
                var result = await _gaCrmService.ChangeSostLuchGaCrmEventDeviceAsync(id);

                return new ApiResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("AddGaCrmEventDevice120KitAsync/{eventId}/{ticketId}")]
        public async Task<ActionResult<ApiResponse>> ChangeSostLuchGaCrmEventDeviceAsync(long eventId,int ticketId)
        {
            try
            {
                var result = await _gaCrmService.AddGaCrmEventDevice120KitAsync(eventId,ticketId);

                return new ApiResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("AddGaCrmEventDevice30KitAsync/{eventId}/{ticketId}")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmEventDevice30KitAsync(long eventId, int ticketId)
        {
            try
            {
                var result = await _gaCrmService.AddGaCrmEventDevice30KitAsync(eventId, ticketId);

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

        #region CrmTickets
        [HttpGet("GetGaCrmTicketsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmTicketsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CrmTicketsApiDto, CrmTicketsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmTicketByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmTicketByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmTicketApiDto, CrmTicketDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmTicketAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmTicketAsync([FromBody] CrmTicketApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmTicketDto, CrmTicketApiDto>();
                var response = await _gaCrmService.AddGaCrmTicketAsync(dto);

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

        [HttpPost("UpdateGaCrmTicketAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmTicketAsync([FromBody] CrmTicketApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmTicketDto, CrmTicketApiDto>();
                var response = await _gaCrmService.UpdateGaCrmTicketAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCrmTicketAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmTicketAsync(long id)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmTicketAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("GetGaCrmTicketDevicesByUserAsync/{cpAzi}/{numCon}/{cpRowNum}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketDevicesByUserAsync(string cpAzi, string numCon, string cpRowNum)
        {
            try
            {
                var view = await _gaCrmService.GetGaCrmTicketDevicesByUserAsync(cpAzi, numCon, cpRowNum);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmTicketsByUserAsync/{comuneId}/{numCon}/{prg}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketsByUserAsync(long comuneId, string numCon, string prg)
        {
            try
            {
                var view = await _gaCrmService.GetGaCrmTicketsByUserAsync(comuneId, numCon, prg);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("CheckGaCrmTicketEventExistAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> CheckGaCrmTicketEventExistAsync(long id)
        {
            try
            {
                var view = await _gaCrmService.CheckGaCrmTicketEventExistAsync(id);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmTicketEventIfExistAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketEventIfExistAsync(long id)
        {
            try
            {
                var view = await _gaCrmService.GetGaCrmTicketEventIfExistAsync(id);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("SendGaCrmTicketAsync")]
        public async Task<ApiResponse> SendGaCrmTicketAsync([FromBody] CrmSendMailApiDto apiDto)
        {
            try
            {
                var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.Crm, AppConsts.CrmInfo);
                var notifications = await _notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(notificationApp.Id);

                var ticket = await _gaCrmService.GetViewGaCrmTicketByIdAsync(apiDto.id);

                var mailArray = apiDto.mailingList.Split(",");
                string mailTo = string.Join(";",mailArray);

                var dto = await GenerateCrmTicketTemplate(ticket, ticket.TipoDesc);
                var attachPath = await _printService.Print("CrmTicketDefault", dto);

                var result = await _mailService.AddMailJobAsync(new MailJob()
                {
                    Id = 0,
                    Description = "Ticket CRM N° " + apiDto.id,
                    DateScheduled = DateTime.Now,
                    Title = "Ticket CRM N° " + apiDto.id,
                    MailingTo = mailTo,
                    MailCc = "",
                    Application = String.Format("{0}|{1}", notificationApp.Id, AppConsts.Crm),
                    Content = HtmlHelpers.GenerateText("In allegato è possibile visionare il ticket.<br>" + apiDto.userName + ""),
                    Template = "DefaultMailJob.html",
                    UserId = apiDto.userId,
                    OkMessage = String.Format("Il Ticket CRM {0} è stato inoltrato correttamente.", ticket.Id),
                    KoMessage = String.Format("Si è verificato un problema durante l'invio del ticket CRM {0}.", ticket.Id),
                    Attachment = true,
                    AttachmentPath = attachPath
                });

                return new ApiResponse(result);

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }

        [HttpPost("DuplicateGaCrmTicketAsync")]
        public async Task<ApiResponse> DuplicateGaContactCenterTicketAsync([FromBody] CrmDuplicateTicketsApiDto apiDto)
        {
            try
            {
                var entities = await _gaCrmService.DuplicateGaCrmTicketAsync(apiDto.ticketsId, apiDto.userId);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        [HttpPost("ExportGaCrmTicketsAsync")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public IActionResult ExportGaCrmTicketsAsync([FromBody] long[] ids)
        {

            try
            {
                var entities = _gaCrmService.ExportGaCrmTicketsAsync(ids).Result.Data.ToList();


                string title = "Lista Ticket";
                string[] columns = { "Numero", "DataTicket","DataRichiesta","DataProgrammazione",
                    "Utente","CodCli","NumCon","Partita","Prg","CfPiva","Tributo",
                    "ComuneCod","ComuneDesc","Via","NumCiv","CodZona",
                    "CanaleDesc",
                    "Telefono","Cellulare","Email","EmailPec",
                    "TipoDesc",
                    "DataChiusura","StatoDesc",
                    "CreatorDesc","AssigneeDesc",
                    "NoteCrm","NoteOperatore"};
                byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "TICKET_CRM", true, columns);

                return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                {
                    FileDownloadName = "Ticket_CRM.xlsx"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }


        [HttpGet("PrintGaCrmTicketByIdAsync/{id}")]
        public async Task<ApiResponse> PrintGaCrmTicketByIdAsync(long id)
        {
            try
            {
                //var _event = await _gaCrmService.GetGaCrmEventByIdAsync(id);
                var _ticket = await _gaCrmService.GetGaCrmTicketByIdAsync(id);

                CrmEventDto _event = new CrmEventDto();
                _event.Id = _ticket.Id;
                _event.CodAzi = "C"+ _ticket.CrmEventComuneId.ToString();
                _event.CodCli = _ticket.CodCli;
                _event.NumCon = _ticket.NumCon;
                _event.Partita = _ticket.Partita;
                _event.CpRowNum = _ticket.Prg;
                _event.DateSchedule = DateTime.Now;
                _event.DataRichiesta = _ticket.DataRichiesta;
                _event.RagSo = _ticket.Utente;
                _event.CodFis = _ticket.CfPiva;
                _event.Telefono = _ticket.Telefono;
                _event.Cellulare = _ticket.Cellulare;
                _event.Email = _ticket.Email;
                _event.Pec = _ticket.EmailPec;
                _event.TipoId = _ticket.ContactCenterTipoRichiestaId;
                _event.Tipo = "Tipo";
                _event.Citta = "Città";
                _event.Indirizzo = _ticket.Via;
                _event.NumCiv = _ticket.NumCiv;
                _event.CodZona = _ticket.CodZona;
                _event.Domest = _ticket.Tributo == "DOM" ? true : false;
                _event.CrmEventStateId = _ticket.ContactCenterStatoRichiestaId;
                _event.CrmEventAreaId = 0;
                _event.CrmTicketId = Convert.ToInt32(_ticket.Id);
                _event.UserId = _ticket.Creator;
                _event.UserName = "Creatore";
                _event.NotaAnagrafica = _ticket.NoteCrm;
                _event.Sended = false;
                _event.NotaOperatore = _ticket.NoteOperatore;
                _event.Duration = 0;
                _event.RitardoCausaAzienda = false;
                _event.RitardoCausaUtente = false;

                var tipologie = await _gaCrmService.GetGaCrmTipiTicketAsync(true);
                var _tipo = tipologie.Data.Where(x => x.Id == _event.TipoId).First();
                var templates = await _gaCrmService.GetGaCrmPrintTemplatesAsync(1, 0);
                var comune = await _gaCrmService.GetGaCrmEventComuneByIdAsync(_ticket.CrmEventComuneId);


                _event.Tipo = _tipo.Descrizione;
                _event.Citta = comune.Descrizione;

                var area = "";// await _gaCrmService.GetGaCrmEventAreaByIdAsync(_event.CrmEventAreaId);
                if (_tipo.ContactCenterPrintTemplateId == 0 || _tipo.ContactCenterPrintTemplateId == null)
                {
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area, _tipo.Descrizione,true);
                    var response = await _printService.Print("CrmEventDefault", dto);

                    return new ApiResponse(response);
                }
                else
                {
                    var _template = templates.Data.Where(x => x.Id == _tipo.ContactCenterPrintTemplateId).First();
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area, "Redatto in duplice copia",true, _template.Template + ".pdf", _template.Template);
                    var response = await _printService.Print(_template.Template, dto);

                    return new ApiResponse(response);
                }

            }
            catch (Exception ex)
            {
                throw new ApiProblemDetailsException(code.Status400BadRequest);
            }
        }
        #endregion

        #region Views
        [HttpPost("GetViewGaCrmTicketsQueryableFilterSingleParam/{assignee}")]
        public ApiResponse GetViewGaCrmTicketsQueryableFilterSingleParam(GridOperationsModel filter,string? assignee="0")
        {
            try
            {
                //assignee = assignee == "NaN" ? "0" : assignee;
                assignee = assignee == "ARRAY" ? filter.extraFilter.ToString() : "0";
                var entities = _gaCrmService.GetViewGaCrmTicketsByAssigneeQueryable(filter, assignee.ToString().Split(",").ToArray());
                return new ApiResponse(entities);

            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("GetViewGaCrmCalendarTicketAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCrmCalendarTicketAsync()
        {
            try
            {
                var entities = await _gaCrmService.GetViewGaCrmCalendarTicketAsync();
                return new ApiResponse(entities);

            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
        #endregion

        #endregion

        #region CrmTicketAllegati
        [HttpGet("GetGaCrmTicketAllegatiByTicketIdAsync/{CrmTicketTicketId}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketAllegatiByTicketIdAsync(long CrmTicketTicketId)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmTicketAllegatiByTicketIdAsync(CrmTicketTicketId);
                var apiDtos = dtos.ToApiDto<CrmTicketAllegatiApiDto, CrmTicketAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmTicketAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmTicketAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmTicketAllegatoApiDto, CrmTicketAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmTicketAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmTicketAllegatoAsync([FromForm] CrmTicketAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/CrmTicket";
                var dto = apiDto.ToDto<CrmTicketAllegatoDto, CrmTicketAllegatoApiDto>();
                var response = await _gaCrmService.AddGaCrmTicketAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaCrmService.UpdateGaCrmTicketAllegatoAsync(dto);
                    return new ApiResponse("CreatedWithFile", response, code.Status201Created);
                }

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

        [HttpPost("UpdateGaCrmTicketAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmTicketAllegatoAsync([FromBody] CrmTicketAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/CrmTicket";
                var dto = apiDto.ToDto<CrmTicketAllegatoDto, CrmTicketAllegatoApiDto>();
                var response = await _gaCrmService.UpdateGaCrmTicketAllegatoAsync(dto);
                bool failureDelete = false;
                if (apiDto.deleteFile)
                {
                    var deleteResponse = await _fileService.Remove(apiDto.FileId);
                    if (!deleteResponse)
                    {
                        failureDelete = true;

                    }
                    else
                    {
                        dto.Id = response;
                        dto.FileFolder = null;
                        dto.FileName = null;
                        dto.FileSize = null;
                        dto.FileType = null;
                        dto.FileId = null;
                        var updateFileResponse = await _gaCrmService.UpdateGaCrmTicketAllegatoAsync(dto);
                    }
                }

                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _gaCrmService.UpdateGaCrmTicketAllegatoAsync(dto);

                    if (!failureDelete)
                    {
                        return new ApiResponse("UpdatedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("UpdatedWithFile/FailureDelete", response, code.Status207MultiStatus);
                    }

                }

                if (!failureDelete)
                {
                    return new ApiResponse("Updated", response, code.Status200OK);
                }
                else
                {
                    return new ApiResponse("Updated/FailureDelete", response, code.Status207MultiStatus);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpDelete("DeleteGaCrmTicketAllegatoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmTicketAllegatoAsync(long id, string fileId)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmTicketAllegatoAsync(id);
                if (response && fileId != null && fileId != "null" && fileId != "")
                {
                    var deleteResponse = await _fileService.Remove(fileId);
                    if (deleteResponse)
                    {
                        return new ApiResponse("DeletedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("DeletedErrorFile", response, code.Status206PartialContent);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaCrmTicketAllegatoAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaCrmTicketAllegatoAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaCrmTicketService.ValidateGaCrmTicketAllegatoAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaCrmTicketAllegatoAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaCrmTicketAllegatoAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaCrmTicketService.ChangeStatusGaCrmTicketAllegatoAsync(id);
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

        #region CrmTicketTags
        [HttpGet("GetGaCrmTicketTagsAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketTagsAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmTicketTagsAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CrmTicketTagsApiDto, CrmTicketTagsDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmTicketTagByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTicketTagByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCrmService.GetGaCrmTicketTagByIdAsync(id);
                var apiDto = dto.ToApiDto<CrmTicketTagApiDto, CrmTicketTagDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCrmTicketTagAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCrmTicketTagAsync([FromBody] CrmTicketTagApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmTicketTagDto, CrmTicketTagApiDto>();
                var response = await _gaCrmService.AddGaCrmTicketTagAsync(dto);

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

        [HttpPost("UpdateGaCrmTicketTagAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmTicketTagAsync([FromBody] CrmTicketTagApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CrmTicketTagDto, CrmTicketTagApiDto>();
                var response = await _gaCrmService.UpdateGaCrmTicketTagAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCrmTicketTagAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCrmTicketTagAsync(long id)
        {
            try
            {
                var response = await _gaCrmService.DeleteGaCrmTicketTagAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        //[HttpGet("ValidateGaCrmTicketTagAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaCrmTicketTagAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ValidateGaCrmTicketTagAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaCrmTicketTagAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaCrmTicketTagAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaCrmService.ChangeStatusGaCrmTicketTagAsync(id);
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

        [HttpPut("GetViewGaCrmEventJobsByFilterAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCrmEventJobsByFilterAsync([FromRoute] int all, [FromBody]DateRangeDto filter)
        {
            try
            {
                var view = await _gaCrmService.GetViewGaCrmEventJobsByFilterAsync(all==1?true:false,filter.dateStart,filter.dateEnd);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region Garbage
        [HttpGet("UploadFTPViewGaCrmGarbageUtenzeAsync")]
        public async Task<ActionResult<ApiResponse>> UploadFTPViewGaCrmGarbageUtenzeAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ViewGaCrmGarbageUtenze, GarbageUtenzaApiDto>();

                });

                IMapper mapper = config.CreateMapper();

                var view = await _gaCrmService.GetViewGaCrmGarbageUtenzeAsync();
                var list = mapper.Map<List<GarbageUtenzaApiDto>>(view.Data);
                var csvList = list.ToDelimitedText(";", false, true);

                //Creare directory Storage
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                }
                var fileName = string.Format("Storage\\EXPORT_UTENZE.csv");

                var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                System.IO.File.WriteAllText(fullPath, csvList);


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://gestioneambiente.garbageweb.it/" + fileName.Replace("Storage\\", ""));

                request.Credentials = new NetworkCredential("GestAmbAnagrafiche", "G3e$s!An4gR!2023");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                string response = "";

                using (Stream fileStream = System.IO.File.OpenRead(Path.GetFullPath(fileName)))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                        response=string.Format("Uploaded {0} bytes", fileStream.Position);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("UploadFTPViewGaCrmGarbagePartiteAsync")]
        public async Task<ActionResult<ApiResponse>> UploadFTPViewGaCrmGarbagePartiteAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ViewGaCrmGarbagePartite, GarbagePartitaApiDto>();

                });

                IMapper mapper = config.CreateMapper();

                var view = await _gaCrmService.GetViewGaCrmGarbagePartiteAsync();
                var list = mapper.Map<List<GarbagePartitaApiDto>>(view.Data);
                var csvList = list.ToDelimitedText(";", false, true);

                //Creare directory Storage
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                }
                var fileName = string.Format("Storage\\EXPORT_PARTITE.csv");

                var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                System.IO.File.WriteAllText(fullPath, csvList);


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://gestioneambiente.garbageweb.it/" + fileName.Replace("Storage\\", ""));

                request.Credentials = new NetworkCredential("GestAmbAnagrafiche", "G3e$s!An4gR!2023");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                string response = "";

                using (Stream fileStream = System.IO.File.OpenRead(Path.GetFullPath(fileName)))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                        response = string.Format("Uploaded {0} bytes", fileStream.Position);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("UploadFTPViewGaCrmGarbageTipologieAsync")]
        public async Task<ActionResult<ApiResponse>> UploadFTPViewGaCrmGarbageTipologieAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ViewGaCrmGarbageTipologie, GarbageTipologiaApiDto>();

                });

                IMapper mapper = config.CreateMapper();

                var view = await _gaCrmService.GetViewGaCrmGarbageTipologieAsync();
                var list = mapper.Map<List<GarbageTipologiaApiDto>>(view.Data);
                var csvList = list.ToDelimitedText(";", false, true);

                //Creare directory Storage
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                }
                var fileName = string.Format("Storage\\EXPORT_TICKET_TIPOLOGIE.csv");

                var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                System.IO.File.WriteAllText(fullPath, csvList);

                FtpUploadDto dto = new FtpUploadDto();
                dto.serverUri = "gestioneambiente.garbageweb.it/";
                dto.filePath = fullPath;
                dto.fileName = fileName.Replace("Storage\\", "");
                dto.credentials = new NetworkCredential("GestAmbAnagrafiche", "G3e$s!An4gR!2023");
                dto.useBinary = true;
                dto.usePassive = true;
                dto.keepAlive = true;

                var response = await _ftpService.UploadAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("UploadFTPViewGaCrmGarbageProvenienzeAsync")]
        public async Task<ActionResult<ApiResponse>> UploadFTPViewGaCrmGarbageProvenienzeAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ViewGaCrmGarbageProvenienze, GarbageProvenienzaApiDto>();

                });

                IMapper mapper = config.CreateMapper();

                var view = await _gaCrmService.GetViewGaCrmGarbageProvenienzeAsync();
                var list = mapper.Map<List<GarbageProvenienzaApiDto>>(view.Data);
                var csvList = list.ToDelimitedText(";", false, true);

                //Creare directory Storage
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                }
                var fileName = string.Format("Storage\\EXPORT_TICKET_PROVENIENZE.csv");

                var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                System.IO.File.WriteAllText(fullPath, csvList);


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://gestioneambiente.garbageweb.it/" + fileName.Replace("Storage\\", ""));

                request.Credentials = new NetworkCredential("GestAmbAnagrafiche", "G3e$s!An4gR!2023");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                string response = "";

                using (Stream fileStream = System.IO.File.OpenRead(Path.GetFullPath(fileName)))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                        response = string.Format("Uploaded {0} bytes", fileStream.Position);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("UploadFTPViewGaCrmGarbageStatiAsync")]
        public async Task<ActionResult<ApiResponse>> UploadFTPViewGaCrmGarbageStatiAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ViewGaCrmGarbageStati, GarbageStatoApiDto>();

                });

                IMapper mapper = config.CreateMapper();

                var view = await _gaCrmService.GetViewGaCrmGarbageStatiAsync();
                var list = mapper.Map<List<GarbageStatoApiDto>>(view.Data);
                var csvList = list.ToDelimitedText(";", false, true);

                //Creare directory Storage
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                }
                var fileName = string.Format("Storage\\EXPORT_TICKET_STATI.csv");

                var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                System.IO.File.WriteAllText(fullPath, csvList);


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://gestioneambiente.garbageweb.it/" + fileName.Replace("Storage\\", ""));

                request.Credentials = new NetworkCredential("GestAmbAnagrafiche", "G3e$s!An4gR!2023");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                string response = "";

                using (Stream fileStream = System.IO.File.OpenRead(Path.GetFullPath(fileName)))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                        response = string.Format("Uploaded {0} bytes", fileStream.Position);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("UploadFTPViewGaCrmGarbageTicketContactCenterAsync")]
        public async Task<ActionResult<ApiResponse>> UploadFTPViewGaCrmGarbageTicketContactCenterAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ViewGaCrmGarbageTicketContactCenter, GarbageTicketContactCenterApiDto>();

                });

                IMapper mapper = config.CreateMapper();

                var view = await _gaCrmService.GetViewGaCrmGarbageTicketContactCenterAsync();
                var list = mapper.Map<List<GarbageTicketContactCenterApiDto>>(view.Data);
                var csvList = list.ToDelimitedText(";", false, true);

                //Creare directory Storage
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                }
                var fileName = string.Format("Storage\\EXPORT_TICKET_CONTACT_CENTER.csv");

                var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                System.IO.File.WriteAllText(fullPath, csvList);


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://gestioneambiente.garbageweb.it/" + fileName.Replace("Storage\\", ""));

                request.Credentials = new NetworkCredential("GestAmbAnagrafiche", "G3e$s!An4gR!2023");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                string response = "";

                using (Stream fileStream = System.IO.File.OpenRead(Path.GetFullPath(fileName)))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                        response = string.Format("Uploaded {0} bytes", fileStream.Position);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("UploadFTPViewGaCrmGarbageTicketMagazzinoAsync")]
        public async Task<ActionResult<ApiResponse>> UploadFTPViewGaCrmGarbageTicketMagazzinoAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ViewGaCrmGarbageTicketMagazzino, GarbageTicketMagazzinoApiDto>();

                });

                IMapper mapper = config.CreateMapper();

                var view = await _gaCrmService.GetViewGaCrmGarbageTicketMagazzinoAsync();
                var list = mapper.Map<List<GarbageTicketMagazzinoApiDto>>(view.Data);
                var csvList = list.ToDelimitedText(";", false, true);

                //Creare directory Storage
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                }
                var fileName = string.Format("Storage\\EXPORT_TICKET_MAGAZZINO.csv");

                var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                System.IO.File.WriteAllText(fullPath, csvList);


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://gestioneambiente.garbageweb.it/" + fileName.Replace("Storage\\", ""));

                request.Credentials = new NetworkCredential("GestAmbAnagrafiche", "G3e$s!An4gR!2023");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                string response = "";

                using (Stream fileStream = System.IO.File.OpenRead(Path.GetFullPath(fileName)))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                        response = string.Format("Uploaded {0} bytes", fileStream.Position);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region Shared Data Table
        [HttpGet("GetGaCrmTipiTicketAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmTipiTicketAsync(bool all=false)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmTipiTicketAsync(all);
                var apiDtos = dtos.ToApiDto<ContactCenterTipiRichiesteApiDto, ContactCenterTipiRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmProvenienzeTicketAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmProvenienzeTicketAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmProvenienzeTicketAsync(page,pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterProvenienzeApiDto, ContactCenterProvenienzeDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmStatiTicketAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmStatiTicketAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmStatiTicketAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterStatiRichiesteApiDto, ContactCenterStatiRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCrmPrintTemplatesAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCrmPrintTemplatesAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmPrintTemplatesAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ContactCenterPrintTemplatesApiDto, ContactCenterPrintTemplatesDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaCrmTipConAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCrmTipConAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var view = await _gaCrmService.GetViewGaCrmTipConAsync(page, pageSize);
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
        private async Task<CrmEventsTemplateDto> GenerateCrmEventsGroupedTemplate(List<CrmEventDto> events, DateTime date, string area,bool includeAll,string fileName= "CrmEventsGrouped.pdf")
        {
            var dto = new CrmEventsTemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/Crm",
                Title = "Crm Eventi Programmati",
                Css = "CrmEventsGrouped",
                Area = area,
                Data = date.ToString("dd/MM/yyyy"),
                Items = new List<CrmEventDto>(),
                Devices= new List<CrmEventDeviceDto>()
            };

            var tipologie = await _gaCrmService.GetGaCrmTipiTicketAsync(true);
            

            foreach (var item in events)
            {
                var _tipo = tipologie.Data.Where(x => x.Id == item.TipoId).First();
                if (_tipo.PrintMassive || includeAll)
                {

                    dto.Items.Add(item);

                    var devices = await _gaCrmService.GetGaCrmEventDevicesByEventIdAsync(item.Id);
                    foreach (var device in devices.Data)
                    {
                        if (device.Selected)
                            dto.Devices.Add(device);
                    }
                }
            
            }

            return dto;

        }

        private async Task<CrmEventTemplateDto> GenerateCrmEventMergeTemplate(CrmEventDto _event, DateTime date, string area, string title, string fileName = "CrmEventDefault.pdf", string css = "CrmEventDefault")
        {
            var dto = new CrmEventTemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/Crm",
                Title = title,
                Css = css,
                TemplateName=css,
                HeaderSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = "Redatto in duplice copia", Line = true },
                FooterSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true, Center = "Gestione Ambiente S.p.A." },
                Copies = 2,
                Area = area,
                Data = date.ToString("dd/MM/yyyy"),
                Item = _event,
                Devices = new List<CrmEventDeviceDto>()

            };

            var devices = await _gaCrmService.GetGaCrmEventDevicesByEventIdAsync(_event.Id);
            foreach (var device in devices.Data)
            {
                if (device.Selected)
                    dto.Devices.Add(device);
            }



            return dto;

        }

        private async Task<CrmEventTemplateDto> GenerateCrmEventTemplate(CrmEventDto _event, DateTime date, string area, string title, bool fromTicket = false, string fileName = "CrmEventDefault.pdf",string css= "CrmEventDefault")
        {
            var dto = new CrmEventTemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/Crm",
                Title = title,
                Css = css,
                HeaderSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = "Redatto in duplice copia", Line = true },
                FooterSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true,Center="Gestione Ambiente S.p.A." },
                Copies=2,
                Area = area,
                Data = date.ToString("dd/MM/yyyy"),
                Item = _event,
                Devices = new List<CrmEventDeviceDto>()

            };

            if (!fromTicket)
            {
                var devices = await _gaCrmService.GetGaCrmEventDevicesByEventIdAsync(_event.Id);
                foreach (var device in devices.Data)
                {
                    if (device.Selected)
                        dto.Devices.Add(device);
                }
                return dto;
            }
            else
            {
                var devices = await _gaCrmService.GetGaCrmEventDevicesByTicketIdAsync(_event.Id);
                foreach (var device in devices.Data)
                {
                    if (device.Selected)
                        device.CrmEventId=_event.Id;
                        dto.Devices.Add(device);
                }

                return dto;
            }

            

            

            

        }
        private async Task<CrmTicketTemplateDto> GenerateCrmTicketTemplate(ViewGaCrmTickets _event, string title, string fileName = "CrmTicketDefault.pdf", string css = "CrmTicketDefault")
        {
            var dto = new CrmTicketTemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/Crm",
                Title = title,
                Css = css,
                HeaderSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = "Ticket CRM", Line = true },
                FooterSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true, Center = "Gestione Ambiente S.p.A." },
                Copies = 1,
                Item = _event

            };

            return dto;

        }



        #endregion


    }
}