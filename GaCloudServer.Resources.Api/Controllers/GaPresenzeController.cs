using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using GaCloudServer.BusinnessLogic.Hub.Interfaces;
using GaCloudServer.BusinnessLogic.Hub;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.Presenze;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaPresenzeController : Controller
    {
        private readonly IGaPresenzeService _gaPresenzeService;
        private readonly INotificationService _notificationService;
        private readonly IMailService _mailService;
        private readonly ILogger<GaPresenzeController> _logger;
        private readonly IHubContext<BackgroundServicesHub, IBackgroundServicesHub> _backgroundServicesHub;

        public GaPresenzeController(
            IGaPresenzeService gaPresenzeService,
            INotificationService notificationService,
            IMailService mailService
            ,ILogger<GaPresenzeController> logger
            , IHubContext<BackgroundServicesHub, IBackgroundServicesHub> backgroundServicesHub)
        {

            _gaPresenzeService = gaPresenzeService;
            _notificationService = notificationService;
            _mailService = mailService;
            _logger = logger;
            _backgroundServicesHub = backgroundServicesHub;

        }

        #region PresenzeStatiRichieste
        [HttpGet("GetGaPresenzeStatiRichiesteAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeStatiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeStatiRichiesteAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeStatiRichiesteApiDto, PresenzeStatiRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeStatoRichiestaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeStatoRichiestaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeStatoRichiestaByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeStatoRichiestaApiDto, PresenzeStatoRichiestaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeStatoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeStatoRichiestaAsync([FromBody] PresenzeStatoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeStatoRichiestaDto, PresenzeStatoRichiestaApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeStatoRichiestaAsync(dto);

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

        [HttpPost("UpdateGaPresenzeStatoRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeStatoRichiestaAsync([FromBody] PresenzeStatoRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeStatoRichiestaDto, PresenzeStatoRichiestaApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeStatoRichiestaAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeStatoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeStatoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeStatoRichiestaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeStatoRichiestaAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeStatoRichiestaAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeStatoRichiestaAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeStatoRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeStatoRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeStatoRichiestaAsync(id);
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
        
        #endregion

        #endregion

        #region PresenzeRichieste
        [HttpGet("GetGaPresenzeRichiesteAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeRichiesteAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeRichiesteAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeRichiesteApiDto, PresenzeRichiesteDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeRichiestaByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeRichiestaByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeRichiestaByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeRichiestaApiDto, PresenzeRichiestaDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeRichiestaAsync([FromBody] PresenzeRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                //var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);//apiDto.DataInizio.ToUniversalTime()

                //apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                //apiDto.DataFine = apiDto.DataFine.Add(offset);

                var tz = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
                apiDto.DataInizio = TimeZoneInfo.ConvertTimeFromUtc(apiDto.DataInizio, tz);
                apiDto.DataFine = TimeZoneInfo.ConvertTimeFromUtc(apiDto.DataFine, tz);

                var dto = apiDto.ToDto<PresenzeRichiestaDto, PresenzeRichiestaApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeRichiestaAsync(dto);

                await _backgroundServicesHub.Clients.Groups(new List<string>() { "Administrator", "Users" }).PresenzeRefresh(true);

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

        [HttpPost("UpdateGaPresenzeRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeRichiestaAsync([FromBody] PresenzeRichiestaApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);

                var dto = apiDto.ToDto<PresenzeRichiestaDto, PresenzeRichiestaApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeRichiestaAsync(dto);

                await this._backgroundServicesHub.Clients.Groups(new List<string>() { "Administrator", "User" }).PresenzeRefresh(true);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeRichiestaAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpPost("ValidateGaPresenzeRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeRichiestaAsync([FromBody] PresenzeRichiestaValidateDto apiDto)
        {
            try
            {
                var dtos = await _gaPresenzeService.ValidateGaPresenzeRichiestaAsync(apiDto);
                return new ApiResponse(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeRichiestaAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeRichiestaAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeRichiestaAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("SendGaPresenzeRichiestaAsync/{id}/{direction}")]
        public async Task<ApiResponse> SendGaPresenzeRichiestaAsync(long id, long direction)
        {
            try
            {
                var richiestaMail = await _gaPresenzeService.GetViewGaPresenzeRichiestaMailByIdAsync(id);
                var respList = await _gaPresenzeService.GetViewGaPresenzeResponsabiliOnSettoreMailBySettoreId(richiestaMail.SettoreId);
                var notificationApp = await _notificationService.GetNotificationAppByDescrizioneAsync(AppConsts.Presenze,AppConsts.PresenzeInfo);
                //var notifications = await _notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(notificationApp.Id);

                List<string> userMails = new List<string>();
                List<string> respMails = new List<string>();

                foreach (var itm in respList.Data)
                {
                    respMails.Add(itm.Email);

                    //foreach (var user in notifications.Data)
                    //{
                    //    if (user.UserId == itm.UserId) { respMails.Add(itm.Email); }
                    //}
                }

                userMails.Add(richiestaMail.RichiedenteEmail);

                //foreach (var user in notifications.Data)
                //{
                //    if (user.UserId == richiestaMail.UserId) { userMails.Add(richiestaMail.RichiedenteEmail); }
                //}

                if (userMails.Count > 0 || respMails.Count > 0)
                {
                    string mailTo = "";
                    string mailCC = "";

                    switch (direction)
                    {
                        case 1:
                            mailTo = string.Join(";", respMails);
                            mailCC = string.Join(";", userMails);
                            break;
                        case 2:
                            mailTo = string.Join(";", userMails);
                            mailCC = string.Join(";", respMails);
                            break;
                    }

                    List<string> descriptors = new List<string>() {
                        "Richiedente",
                        "Data Iniziale",
                        "Data Finale",
                        "Tipo Richiesta",
                        "Stato"
                    };

                    List<string> details = new List<string>() {
                        richiestaMail.Richiedente,
                        richiestaMail.DataInizio.ToString("dd/MM/yyyy HH:mm"),
                        richiestaMail.DataFine.ToString("dd/MM/yyyy HH:mm"),
                        richiestaMail.Tipo,
                        richiestaMail.Stato
                    };

                    var response = await _mailService.AddMailJobAsync(new MailJob()
                    {
                        Id = 0,
                        Description = "Richiesta Assenza",
                        DateScheduled = DateTime.Now,
                        Title = "Richiesta Assenza",
                        MailingTo = mailTo,
                        MailCc = mailCC,
                        Application = String.Format("{0}|{1}", notificationApp.Id, AppConsts.Presenze),
                        Content = HtmlHelpers.GenerateList(descriptors,details),
                        Template = "DefaultMailWithLinkJob.html",
                        Link = true,
                        LinkHref = String.Format("https://cloud.gestioneambiente.net/presenze/calendar/presenze-dipendenti-richieste-calendar"),
                        LinkDescription = "Vai al calendario",
                        UserId =richiestaMail.UserId,
                        OkMessage="La tua richiesta è stata inoltrata correttamente.",
                        KoMessage="Si è verificato un problema durante l'invio della tua richiesta."

                    });
                    return new ApiResponse(response);

                }



                return new ApiResponse(0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
        #endregion

        #region Views
        [HttpGet("GetGaViewPresenzeRichiesteBySettoreIdAsync/{globalSettoreId}")]
        public async Task<ActionResult<ApiResponse>> GetGaViewPresenzeRichiesteBySettoreIdAsync(long globalSettoreId)
        {
            try
            {
                var view = await _gaPresenzeService.GetGaViewPresenzeRichiesteBySettoreIdAsync(globalSettoreId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaViewPresenzeRichiesteRisorseBySettoreIdAsync/{globalSettoreId}")]
        public async Task<ActionResult<ApiResponse>> GetGaViewPresenzeRichiesteRisorseBySettoreIdAsync(long globalSettoreId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeRichiesteRisorseBySettoreIdAsync(globalSettoreId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPresenzeRichiesteRisorseBySettoreIdAndDipendenteAsync/{globalSettoreId}/{dipendente}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeRichiesteRisorseBySettoreIdAndDipendenteAsync(long globalSettoreId,string dipendente)
        {
            try
            {

                var view = await _gaPresenzeService.GetViewGaPresenzeRichiesteRisorseBySettoreIdAndDipendenteAsync(globalSettoreId,dipendente);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPresenzeRichiesteEventiBySettoreIdAsync/{globalSettoreId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeRichiesteEventiBySettoreIdAsync(long globalSettoreId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeRichiesteEventiBySettoreIdAsync(globalSettoreId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPresenzeRichiesteQualificheRisorseByQualificaIdAsync/{qualificaId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeRichiesteQualificheRisorseByQualificaIdAsync(long qualificaId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeRichiesteQualificheRisorseByQualificaIdAsync(qualificaId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPresenzeRichiesteQualificheRisorseByQualificaIdAndDipendenteAsync/{qualificaId}/{dipendente}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeRichiesteQualificheRisorseByQualificaIdAndDipendenteAsync(long qualificaId, string dipendente)
        {
            try
            {

                var view = await _gaPresenzeService.GetViewGaPresenzeRichiesteQualificheRisorseByQualificaIdAndDipendenteAsync(qualificaId, dipendente);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPresenzeRichiesteQualificheEventiByQualificaIdAsync/{qualificaId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeRichiesteQualificheEventiByQualificaIdAsync(long qualificaId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeRichiesteQualificheEventiByQualificaIdAsync(qualificaId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region Widgets
        [HttpGet("GetWidgetGaPresenzeScheduleAsync/{smartWorking}")]
        public async Task<ActionResult<ApiResponse>> GetWidgetGaPresenzeScheduleAsync(bool smartWorking)
        {
            try
            {
                var view = await _gaPresenzeService.GetWidgetGaPresenzeScheduleAsync(smartWorking);
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

        #region PresenzeTipiOre
        [HttpGet("GetGaPresenzeTipiOreAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeTipiOreAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeTipiOreAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeTipiOreApiDto, PresenzeTipiOreDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeTipoOraByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeTipoOraByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeTipoOraByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeTipoOraApiDto, PresenzeTipoOraDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeTipoOraAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeTipoOraAsync([FromBody] PresenzeTipoOraApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeTipoOraDto, PresenzeTipoOraApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeTipoOraAsync(dto);

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

        [HttpPost("UpdateGaPresenzeTipoOraAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeTipoOraAsync([FromBody] PresenzeTipoOraApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeTipoOraDto, PresenzeTipoOraApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeTipoOraAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeTipoOraAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeTipoOraAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeTipoOraAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeTipoOraAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeTipoOraAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeTipoOraAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeTipoOraAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeTipoOraAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeTipoOraAsync(id);
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

        #region PresenzeResponsabili
        [HttpGet("GetGaPresenzeResponsabiliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeResponsabiliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeResponsabiliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeResponsabiliApiDto, PresenzeResponsabiliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeResponsabileByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeResponsabileByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeResponsabileByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeResponsabileApiDto, PresenzeResponsabileDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeResponsabileAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeResponsabileAsync([FromBody] PresenzeResponsabileApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeResponsabileDto, PresenzeResponsabileApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeResponsabileAsync(dto);

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

        [HttpPost("UpdateGaPresenzeResponsabileAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeResponsabileAsync([FromBody] PresenzeResponsabileApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeResponsabileDto, PresenzeResponsabileApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeResponsabileAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeResponsabileAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeResponsabileAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeResponsabileAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeResponsabileAsync/{id}/{personaleDipendenteId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeResponsabileAsync(long id, long personaleDipendenteId)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeResponsabileAsync(id, personaleDipendenteId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeResponsabileAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeResponsabileAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeResponsabileAsync(id);
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
        [HttpGet("GetViewGaPresenzeResponsabiliAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeResponsabiliAsync(bool all=true)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeResponsabiliAsync(all);
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

        #region PresenzeResponsabiliOnSettori

        [HttpGet("UpdateGaPresenzeResponsabileOnSettoreAsync/{responsabileId}/{settoreId}")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeResponsabileOnSettoreAsync(long responsabileId, long settoreId)
        {
            try
            {
                var response = await _gaPresenzeService.UpdateGaPresenzeResponsabileOnSettoreAsync(responsabileId, settoreId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Views
        [HttpGet("GetViewGaPresenzeResponsabiliOnSettoriByDipendenteAsync/{personaleDipendenteId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeResponsabiliOnSettoriByDipendenteAsync(long personaleDipendenteId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeResponsabiliOnSettoriByDipendenteAsync(personaleDipendenteId);
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

        #region PresenzeProfili
        [HttpGet("GetGaPresenzeProfiliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeProfiliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeProfiliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeProfiliApiDto, PresenzeProfiliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeProfiloByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeProfiloByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeProfiloByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeProfiloApiDto, PresenzeProfiloDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeProfiloAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeProfiloAsync([FromBody] PresenzeProfiloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeProfiloDto, PresenzeProfiloApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeProfiloAsync(dto);

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

        [HttpPost("UpdateGaPresenzeProfiloAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeProfiloAsync([FromBody] PresenzeProfiloApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeProfiloDto, PresenzeProfiloApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeProfiloAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeProfiloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeProfiloAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeProfiloAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeProfiloAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeProfiloAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeProfiloAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeProfiloAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeProfiloAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeProfiloAsync(id);
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

        #region PresenzeBancheOreUtilizzi
        [HttpGet("GetGaPresenzeBancheOreUtilizziAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeBancheOreUtilizziAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeBancheOreUtilizziAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeBancheOreUtilizziApiDto, PresenzeBancheOreUtilizziDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeBancaOraUtilizzoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeBancaOraUtilizzoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeBancaOraUtilizzoByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeBancaOraUtilizzoApiDto, PresenzeBancaOraUtilizzoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeBancaOraUtilizzoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeBancaOraUtilizzoAsync([FromBody] PresenzeBancaOraUtilizzoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeBancaOraUtilizzoDto, PresenzeBancaOraUtilizzoApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeBancaOraUtilizzoAsync(dto);

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

        [HttpPost("UpdateGaPresenzeBancaOraUtilizzoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeBancaOraUtilizzoAsync([FromBody] PresenzeBancaOraUtilizzoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeBancaOraUtilizzoDto, PresenzeBancaOraUtilizzoApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeBancaOraUtilizzoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeBancaOraUtilizzoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeBancaOraUtilizzoAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeBancaOraUtilizzoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeBancaOraUtilizzoAsync/{id}/{descrizione}")]

        [HttpGet("ChangeStatusGaPresenzeBancaOraUtilizzoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeBancaOraUtilizzoAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeBancaOraUtilizzoAsync(id);
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

        #region PresenzeDipendenti
        [HttpGet("GetGaPresenzeDipendentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeDipendentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeDipendentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeDipendentiApiDto, PresenzeDipendentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeDipendenteByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeDipendenteByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeDipendenteByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeDipendenteApiDto, PresenzeDipendenteDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeDipendenteAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeDipendenteAsync([FromBody] PresenzeDipendenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeDipendenteDto, PresenzeDipendenteApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeDipendenteAsync(dto);

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

        [HttpPost("UpdateGaPresenzeDipendenteAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeDipendenteAsync([FromBody] PresenzeDipendenteApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeDipendenteDto, PresenzeDipendenteApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeDipendenteAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeDipendenteAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeDipendenteAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeDipendenteAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeDipendenteAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeDipendenteAsync(long id, string matricola)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeDipendenteAsync(id, matricola);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeDipendenteAsync/{id}/{personaleDipendenteId}/{profiloId}/{orarioId}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeDipendenteAsync(long id,long personaleDipendenteId,long profiloId,long orarioId)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeDipendenteAsync(id,personaleDipendenteId,profiloId,orarioId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("SetStatusEnabledGaPresenzeDipendentiAsync/{id}/{personaleDipendenteId}/{profiloId}/{orarioId}")]
        public async Task<ActionResult<ApiResponse>> SetStatusEnabledGaPresenzeDipendentiAsync(long id, long personaleDipendenteId, long profiloId, long orarioId)
        {
            try
            {
                var response = await _gaPresenzeService.SetStatusEnabledGaPresenzeDipendentiAsync(id, personaleDipendenteId, profiloId, orarioId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("SetStatusDisabledGaPresenzeDipendentiAsync/{id}/{personaleDipendenteId}/{profiloId}/{orarioId}")]
        public async Task<ActionResult<ApiResponse>> SetStatusDisabledGaPresenzeDipendentiAsync(long id, long personaleDipendenteId, long profiloId, long orarioId)
        {
            try
            {
                var response = await _gaPresenzeService.SetStatusDisabledGaPresenzeDipendentiAsync(id, personaleDipendenteId, profiloId, orarioId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("UpdateOreGaPresenzeDipendentiAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateOreGaPresenzeDipendentiAsync([FromBody] List<long> ids)
        {
            try
            {
                var response = await _gaPresenzeService.UpdateOreGaPresenzeDipendentiAsync(ids);
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
        [HttpGet("GetViewGaPresenzeDipendentiBySettoreIdAsync/{globalSettoreId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeDipendentiBySettoreIdAsync(long globalSettoreId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeDipendentiBySettoreIdAsync(globalSettoreId);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaPresenzeDipendentiResourcesBySettoreIdAsync/{globalSettoreId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeDipendentiResourcesBySettoreIdAsync(long globalSettoreId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeDipendentiBySettoreIdAsync(globalSettoreId);
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

        #region PresenzeOrario
        [HttpGet("GetGaPresenzeOrariAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeOrariAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeOrariAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeOrariApiDto, PresenzeOrariDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeOrarioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeOrarioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeOrarioByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeOrarioApiDto, PresenzeOrarioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeOrarioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeOrarioAsync([FromBody] PresenzeOrarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeOrarioDto, PresenzeOrarioApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeOrarioAsync(dto);

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

        [HttpPost("UpdateGaPresenzeOrarioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeOrarioAsync([FromBody] PresenzeOrarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<PresenzeOrarioDto, PresenzeOrarioApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeOrarioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeOrarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeOrarioAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeOrarioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeOrarioAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeOrarioAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeOrarioAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeOrarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeOrarioAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeOrarioAsync(id);
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

        #region PresenzeOrariGiornate
        [HttpGet("GetGaPresenzeOrariGiornateAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeOrariGiornateAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeOrariGiornateAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<PresenzeOrariGiornateApiDto, PresenzeOrariGiornateDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaPresenzeOrarioGiornataByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeOrarioGiornataByIdAsync(long id)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeOrarioGiornataByIdAsync(id);
                var apiDto = dto.ToApiDto<PresenzeOrarioGiornataApiDto, PresenzeOrarioGiornataDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaPresenzeOrarioGiornataAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaPresenzeOrarioGiornataAsync([FromBody] PresenzeOrarioGiornataApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                apiDto.OraInizio = apiDto.OraInizio.Add(offset);
                apiDto.OraFine = apiDto.OraFine.Add(offset);
                apiDto.PausaInizio = apiDto.PausaInizio.GetValueOrDefault().Add(offset);
                apiDto.PausaFine = apiDto.PausaFine.GetValueOrDefault().Add(offset);

                var dto = apiDto.ToDto<PresenzeOrarioGiornataDto, PresenzeOrarioGiornataApiDto>();
                var response = await _gaPresenzeService.AddGaPresenzeOrarioGiornataAsync(dto);

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

        [HttpPost("UpdateGaPresenzeOrarioGiornataAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaPresenzeOrarioGiornataAsync([FromBody] PresenzeOrarioGiornataApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                apiDto.OraInizio = apiDto.OraInizio.Add(offset);
                apiDto.OraFine = apiDto.OraFine.Add(offset);
                apiDto.PausaInizio = apiDto.PausaInizio.GetValueOrDefault().Add(offset);
                apiDto.PausaFine = apiDto.PausaFine.GetValueOrDefault().Add(offset);

                var dto = apiDto.ToDto<PresenzeOrarioGiornataDto, PresenzeOrarioGiornataApiDto>();
                var response = await _gaPresenzeService.UpdateGaPresenzeOrarioGiornataAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaPresenzeOrarioGiornataAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaPresenzeOrarioGiornataAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.DeleteGaPresenzeOrarioGiornataAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaPresenzeOrarioGiornataAsync/{id}/{orarioId}/{giorno}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaPresenzeOrarioGiornataAsync(long id, long orarioId,int giorno)
        {
            try
            {
                var response = await _gaPresenzeService.ValidateGaPresenzeOrarioGiornataAsync(id, orarioId,giorno);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaPresenzeOrarioGiornataAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaPresenzeOrarioGiornataAsync(long id)
        {
            try
            {
                var response = await _gaPresenzeService.ChangeStatusGaPresenzeOrarioGiornataAsync(id);
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
        [HttpGet("GetViewGaPresenzeOrariGiornateByOrarioIdAsync/{orarioId}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaPresenzeOrariGiornateByOrarioIdAsync(long orarioId)
        {
            try
            {
                var view = await _gaPresenzeService.GetViewGaPresenzeOrariGiornateByOrarioIdAsync(orarioId);
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

        #region Extras

        [HttpGet("GetGaPresenzeProfiloUtenteByUserIdAsync/{userId}/{isAdmin}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeProfiloUtenteByUserIdAsync(string userId,bool isAdmin)
        {
            try
            {
                var dto = await _gaPresenzeService.GetGaPresenzeProfiloUtenteByUserIdAsync(userId,isAdmin);
                return new ApiResponse(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }


        [HttpGet("GetGaPresenzeGlobalSettoriByUserId/{userId}/{isAdmin}")]
        public async Task<ActionResult<ApiResponse>> GetGaPresenzeGlobalSettoriByUserId(string userId, bool isAdmin)
        {
            try
            {
                var dtos = await _gaPresenzeService.GetGaPresenzeGlobalSettoriByUserId(userId, isAdmin);
                return new ApiResponse(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("CalcTimeGaPresenzeRichiestaAsync")]
        public async Task<ActionResult<ApiResponse>> CalcTimeGaPresenzeRichiestaAsync([FromBody] PresenzeRichiestaApiDto apiDto)
        {
            try
            {
                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                apiDto.DataInizio = apiDto.DataInizio.Add(offset);
                apiDto.DataFine = apiDto.DataFine.Add(offset);

                var dto = apiDto.ToDto<PresenzeRichiestaDto, PresenzeRichiestaApiDto>();
                var result = await _gaPresenzeService.CalcTimeGaPresenzeRichiestaAsync(dto);
                return new ApiResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion
    }
}
