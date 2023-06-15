using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Constants;
using GaCloudServer.Resources.Api.Dtos.Crm;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
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
    public class GaCrmController : Controller
    {
        private readonly IGaCrmService _gaCrmService;
        private readonly ILogger<GaCrmController> _logger;
        private readonly IPrintService _printService;
        private readonly IMailService _mailService;
        private readonly INotificationService _notificationService;

        public GaCrmController(
            IGaCrmService gaCrmService
            , IMailService mailService
            , INotificationService notificationService
            , IPrintService printService
            , ILogger<GaCrmController> logger)
        {

            _gaCrmService = gaCrmService;
            _printService = printService;
            _mailService = mailService;
            _notificationService = notificationService;
            _logger = logger;
        }

        #region CrmMaster

        [HttpGet("UpdateCrmMasterStateByIdAsunc/{id}/{state}")]
        public async Task<ActionResult<ApiResponse>> UpdateCrmMasterStateByIdAsunc(int id,long state)
        {
            try
            {
                var result =await  _gaCrmService.UpdateCrmMasterStateByIdAsync(id, state);
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
        public async Task<ActionResult<ApiResponse>> GetGaCrmEventsByBoardAsync(DateTime date,long area)
        {
            try
            {
                var dtos = await _gaCrmService.GetGaCrmEventByBoardAsync(date,area,true);
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

                var responseTari = await _gaCrmService.UpdateCrmMasterStateByIdAsync(dto.CrmTicketId, dto.CrmEventStateId);

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
        [HttpGet("UpdateGaCrmEventStateByIdAsync/{id}/{crmId}/{state}")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventStateByIdAsync(long id,int crmId,long state)
        {
            try
            {
                var response = await _gaCrmService.UpdateGaCrmEventStateByIdAsync(id,state);
                if (response)
                {
                    var responseTari = await _gaCrmService.UpdateCrmMasterStateByIdAsync(crmId, state);
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
        public async Task<ActionResult<ApiResponse>> UpdateGaCrmEventStatesByFilterAsync([FromBody]List<CrmChangeEventStateDto> dto)
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


                        var responseTari = await _gaCrmService.UpdateCrmMasterStateByIdAsync(itm.crmId, itm.state);
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
                    return new ApiResponse(string.Format("CrmError: {0}, TariError: {1}",error,crmError), "PartialError", code.Status200OK);
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

        [HttpGet("PrintGaCrmEventsByFilterAsync/{date}/{areaId}")]
        public async Task<ApiResponse> PrintGaContactCenterIngByFilterAsync(DateTime date,long areaId)
        {
            try
            {
                var list = await _gaCrmService.GetGaCrmEventByBoardAsync(date,areaId,true);

                if (list == null || (list.Data.Where(x => x.CrmEventStateId == 1).Count() == 0))
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(areaId);
                var dto = await  GenerateCrmEventsTemplate(list.Data.Where(x => x.CrmEventStateId == 1).ToList(), date, area.Descrizione);
                var response = await _printService.Print("CrmEvents", dto);

                return new ApiResponse(response);

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
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione,"Ricevuta Prenotazione Ritiro");
                    var response = await _printService.Print("CrmEventRecipt", dto);

                    return new ApiResponse(response);
                }
                else
                {
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione, "Ricevuta Prenotazione Ritiro per Cessazione "+DateTime.Now.ToString("dd/MM/yyyy"),"CrmEventCloseRecipt.pdf","CrmEventCloseRecipt");
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
                if (_tipo.ContactCenterPrintTemplateId == 0  || _tipo.ContactCenterPrintTemplateId == null)
                {
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione, _tipo.Descrizione);
                    var response = await _printService.Print("CrmEventDefault", dto);

                    return new ApiResponse(response);
                }
                else
                {
                    var _template = templates.Data.Where(x => x.Id == _tipo.ContactCenterPrintTemplateId).First();
                    var dto = await GenerateCrmEventTemplate(_event, _event.DateSchedule, area.Descrizione, "Redatto in duplice copia",  _template.Template+".pdf", _template.Template);
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
        public async Task<ApiResponse> SendGaCrmEventsByFilterAsync(DateTime date, long areaId,string userId,string userName,bool all)
        {
            try
            {
                var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.Crm,AppConsts.CrmInfo);


                var list = await _gaCrmService.GetGaCrmEventByBoardAsync(date, areaId,all);

                if (list == null || (list.Data.Where(x => x.CrmEventStateId == 2).Count() == 0))
                {
                    return new ApiResponse("NoData", null, code.Status200OK);
                }

                var area = await _gaCrmService.GetGaCrmEventAreaByIdAsync(areaId);
                var dto = await GenerateCrmEventsTemplate(list.Data.Where(x=>x.CrmEventStateId==2).ToList(), date, area.Descrizione,"CrmEventsReport.pdf");
                var attachPath = await _printService.Print("CrmEventsReport", dto);

                string mailTo = "ced@gestioneambiente.net;matteo.derocchi@gestioneambiente.net";
                string mailCC = "";

                var result = await _mailService.AddMailJobAsync(new MailJob()
                {
                    Id = 0,
                    Description = string.Format("Rapporto Ritiri {0} - {1}",date.ToString("dd/MM/yyyy"),area.Descrizione),
                    DateScheduled = DateTime.Now,
                    Title = string.Format("Rapporto Ritiri {0} - {1}", date.ToString("dd/MM/yyyy"), area.Descrizione),
                    MailingTo = mailTo,
                    MailCc = mailCC,
                    Application = String.Format("{0}|{1}", notificationApp.Id, AppConsts.Crm),
                    Content = HtmlHelpers.GenerateText("In allegato è possibile visionare il report.<br>"+userName),
                    Template = "DefaultMailJob.html",
                    UserId = userId,
                    OkMessage = String.Format("Il Report {0} - {1} è stato inoltrato correttamente.", date.ToString("dd/MM/yyyy"),area.Descrizione),
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
        
        #endregion

        #region Views
        [HttpPost("GetViewGaCrmTicketsQueryableFilterSingleParam/{assignee}")]
        public ApiResponse GetViewGaCrmTicketsQueryableFilterSingleParam(GridOperationsModel filter, string? assignee = "0")
        {
            try
            {
                assignee = assignee == "NaN" ? "0" : assignee;
                var entities = _gaCrmService.GetViewGaCrmTicketsByAssigneeQueryable(filter, assignee.Split(",").ToArray());
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
        private async Task<CrmEventsTemplateDto> GenerateCrmEventsTemplate(List<CrmEventDto> events, DateTime date, string area,string fileName= "CrmEvents.pdf")
        {
            var dto = new CrmEventsTemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/Crm",
                Title = "Crm Eventi Programmati",
                Css = "CrmEventsReport",
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

        private async Task<CrmEventTemplateDto> GenerateCrmEventTemplate(CrmEventDto _event, DateTime date, string area, string title, string fileName = "CrmEventDefault.pdf",string css= "CrmEventDefault")
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

            var devices = await _gaCrmService.GetGaCrmEventDevicesByEventIdAsync(_event.Id);
            foreach (var device in devices.Data)
            {
                if (device.Selected)
                    dto.Devices.Add(device);
            }

            

            return dto;

        }

        
        #endregion


    }
}