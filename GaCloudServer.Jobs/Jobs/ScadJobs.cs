using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Jobs.Helpers;
using Quartz;

namespace GaCloudServer.Jobs.Jobs
{
    public static class ScadJobs
    {
        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class GaAutorizzazioniScadenziarioJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GaAutorizzazioniScadenziarioJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                using (var scope = _provider.CreateScope())
                {

                    var mailService = scope.ServiceProvider.GetService<IMailService>();
                    var autorizzazioniService = scope.ServiceProvider.GetService<IGaAutorizzazioniService>();
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var list = autorizzazioniService.GetViewGaAutorizzazioniDocumentiAsync().Result;
                    var scadenziario = (from x in list.Data
                                        where x.Archiviata == false && (x.Stato == "R" || x.Stato == "G")
                                        select x).ToList();

                    var columnHeaders = new List<string>() { "Ragione Sociale", "Categoria", "Indirizzo", "Data Scadenza" };

                    var rows = new List<List<string>>();
                    List<string> row;
                    foreach (var itm in scadenziario)
                    {
                        row = new List<string>();
                        row.Add(itm.RagioneSociale);
                        row.Add(itm.AutorizzazioniTipo);
                        row.Add(itm.Indirizzo);
                        row.Add(itm.DataScadenza.ToString("dd/MM/yyyy"));

                        rows.Add(row);
                    }

                    var content = HtmlHelpers.GenerateTable(columnHeaders, rows);

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
                        var notificationUsers = notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(1).Result;
                        var usersId = (from x in notificationUsers.Data select x.UserId).ToList();

                        var response =
                            mailService.AddMailJobAsync(new MailJob()
                            {
                                Id = 0,
                                Description = "Scadenziario Autorizzazioni",
                                DateScheduled = DateTime.Now,
                                Title = "Scadenziario Autorizzazioni",
                                MailingTo = mailTo,
                                MailCc = mailCc,
                                Application = string.Format("1|{0}.{1}.{2}", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.Trigger.Key.Name),
                                Content = content,
                                Template = "DefaultMailJob.html",
                                OkMessage = "Scadenziario Autorizzazioni inoltrato correttamente.",
                                KoMessage = "Si è verificato un problema durante l'invio dello Scadenziario Autorizzazioni",
                                UserId = string.Join(";", usersId)


                            })
                            .Result;
                    }

                }

                return Task.CompletedTask;
            }
        }


        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class GaMezziScadenziarioJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GaMezziScadenziarioJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                using (var scope = _provider.CreateScope())
                {

                    var mailService = scope.ServiceProvider.GetService<IMailService>();
                    var mezziService = scope.ServiceProvider.GetService<IGaMezziService>();
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var list = mezziService.GetViewGaMezziScadenzeAsync(true).Result;
                    var scadenziario = (from x in list.Data
                                        where x.Dismesso == false && (x.Stato == "R" || x.Stato == "G")
                                        select x).ToList();

                    var columnHeaders = new List<string>() { "Targa", "Cantiere", "Tipo Scadenza", "Data Scadenza" };

                    var rows = new List<List<string>>();
                    List<string> row;
                    foreach (var itm in scadenziario)
                    {
                        row = new List<string>();
                        row.Add(itm.Targa);
                        row.Add(itm.Cantiere);
                        row.Add(itm.TipoScadenza);
                        row.Add(itm.DataScadenza.GetValueOrDefault().ToString("dd/MM/yyyy"));

                        rows.Add(row);
                    }

                    var content = HtmlHelpers.GenerateTable(columnHeaders, rows);

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
                        var notificationUsers = notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(1).Result;
                        var usersId = (from x in notificationUsers.Data select x.UserId).ToList();

                        var response =
                            mailService.AddMailJobAsync(new MailJob()
                            {
                                Id = 0,
                                Description = "Scadenziario Mezzi",
                                DateScheduled = DateTime.Now,
                                Title = "Scadenziario Mezzi",
                                MailingTo = mailTo,
                                MailCc = mailCc,
                                Application = string.Format("1|{0}.{1}.{2}", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.Trigger.Key.Name),
                                Content = content,
                                Template = "DefaultMailJob.html",
                                OkMessage = "Scadenziario Mezzi inoltrato correttamente.",
                                KoMessage = "Si è verificato un problema durante l'invio dello Scadenziario Mezzi",
                                UserId = string.Join(";", usersId)


                            })
                            .Result;
                    }

                }

                return Task.CompletedTask;
            }
        }
    }
}
