using AuthServer.SSO.Schedule.Configuration;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Jobs.Helpers;
using Quartz;

namespace GaCloudServer.Jobs.Jobs
{
    public static class CrmJobs
    {
        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class CrmCessazioniReportJob : IJob
        {
            public readonly IServiceProvider _provider;
            public IConfiguration _configuration { get; }
            public CrmCessazioniReportJob(IServiceProvider provider, IConfiguration configuration)
            {
                _provider = provider;
                _configuration = configuration;
            }

            public Task Execute(IJobExecutionContext context)
            {
                using (var scope = _provider.CreateScope())
                {

                    var mailService = scope.ServiceProvider.GetService<IMailService>();
                    var crmService = scope.ServiceProvider.GetService<IGaCrmService>();
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var printService= scope.ServiceProvider.GetService<IPrintService>();

                    var areasList = crmService.GetGaCrmEventAreasAsync(1, 0).Result;

                    string[] filterAreas = context.MergedJobDataMap.Get("areas").ToString().Split(";");
                    var list = crmService.GetGaCrmEventByAreaIdAsync(filterAreas, DateTime.Now, false).Result;

                    if (list == null || (list.Data.Where(x => x.CrmEventStateId == 2).Count() == 0))
                    {
                        return Task.CompletedTask;
                    }

                    var areas = string.Join(" - ",(from x in areasList.Data.Where(x => filterAreas.Contains(x.Id.ToString()))
                                select x.Descrizione));
                    var dto = GenerateCrmEventsGroupedTemplate(crmService, list.Data.Where(x => x.CrmEventStateId == 2).ToList(), DateTime.Now, areas, false, "CrmEventsReport.pdf");

                    if (dto.Items.Count == 0)
                    {
                        return Task.CompletedTask;
                    }

                    string alternativePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

                    alternativePath += "\\"+_configuration.GetSection("EnvConsts").Get<EnvConstsConfiguration>().alternativeFolder;


                    var attachPath = printService.Print("CrmEventsDailyReport", dto,alternativePath).Result;


                    string mailTo = "";
                    string mailCc = "";

                    foreach (var itm in context.MergedJobDataMap)
                    {
                        if (itm.Key == "to")
                        {
                            mailTo = itm.Value.ToString();
                        }
                        else if (itm.Key == "cc")
                        {
                            mailCc = itm.Value.ToString();
                        }
                    }

                    if (mailTo.Length > 0 || mailCc.Length > 0)
                    {
                        var result = mailService.AddMailJobAsync(new MailJob()
                        {
                            Id = 0,
                            Description = string.Format("Rapporto Cessazioni {0} - {1}", DateTime.Now.ToString("dd/MM/yyyy"), areas),
                            DateScheduled = DateTime.Now,
                            Title = string.Format("Rapporto Cessazioni {0} - {1}", DateTime.Now.ToString("dd/MM/yyyy"), areas),
                            MailingTo = mailTo,
                            MailCc = mailCc,
                            Application = string.Format("1|{0}.{1}.{2}", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.Trigger.Key.Name),
                            Content = HtmlHelpers.GenerateText("In allegato è possibile visionare il report.<br>" + "ga. Cloud"),
                            Template = "DefaultMailJob.html",
                            UserId = "",
                            OkMessage = String.Format("Il Report {0} - {1} è stato inoltrato correttamente.", DateTime.Now.ToString("dd/MM/yyyy"), areas),
                            KoMessage = String.Format("Si è verificato un problema durante l'invio del Report {0} - {1}.", DateTime.Now.ToString("dd/MM/yyyy"), areas),
                            Attachment = true,
                            AttachmentPath = attachPath
                        }).Result;

                        var idToUpdate = (from x in dto.Items
                                          select x.Id).ToList();
                        var updateData = crmService.UpdateGaCrmEventsSendedAsync(list.Data.Where(x => idToUpdate.Contains(x.Id)).ToList()).Result;

                    }

                }

                return Task.CompletedTask;
            }
        }

        #region Helper
        private static CrmEventsTemplateDto GenerateCrmEventsGroupedTemplate(IGaCrmService gaCrmService, List<CrmEventDto> events, DateTime date, string area, bool includeAll, string fileName = "CrmEventsGrouped.pdf")
        {
            var dto = new CrmEventsTemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/Crm",
                Title = "Crm Eventi Programmati",
                Css = "CrmEventsDailyReport",
                Area = area,
                Data = date.ToString("dd/MM/yyyy"),
                Items = new List<CrmEventDto>(),
                Devices = new List<CrmEventDeviceDto>()
            };

            var tipologie = gaCrmService.GetGaCrmTipiTicketAsync(true).Result;


            foreach (var item in events)
            {
                var _tipo = tipologie.Data.Where(x => x.Id == item.TipoId).First();
                if (_tipo.PrintMassive || includeAll)
                {

                    dto.Items.Add(item);

                    var devices =  gaCrmService.GetGaCrmEventDevicesByEventIdAsync(item.Id).Result;
                    foreach (var device in devices.Data)
                    {
                        if (device.Selected)
                            dto.Devices.Add(device);
                    }
                }

            }

            return dto;

        }
        #endregion


    }
}
