using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
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

        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class GaContrattiScadenziarioJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GaContrattiScadenziarioJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                using (var scope = _provider.CreateScope())
                {

                    var mailService = scope.ServiceProvider.GetService<IMailService>();
                    var contrattiService = scope.ServiceProvider.GetService<IGaContrattiService>();
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var list = contrattiService.GetViewGaContrattiDocumentiScadenziarioAsync(true).Result;
                    var scadenziario = (from x in list.Data
                                        where x.Archiviato == false && (x.Stato == "R" || x.Stato == "G") && x.SoggettoDisabled == false
                                        select x).ToList();

                    var columnHeaders = new List<string>() { "Ragione Sociale", "Tipologia", "Descrizione", "Data Scadenza" };

                    var rows = new List<List<string>>();
                    List<string> row;
                    foreach (var itm in scadenziario)
                    {
                        row = new List<string>();
                        row.Add(itm.RagioneSociale);
                        row.Add(itm.Tipologia);
                        row.Add(itm.Descrizione);
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
                                Description = "Scadenziario Contratti",
                                DateScheduled = DateTime.Now,
                                Title = "Scadenziario Contratti",
                                MailingTo = mailTo,
                                MailCc = mailCc,
                                Application = string.Format("1|{0}.{1}.{2}", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.Trigger.Key.Name),
                                Content = content,
                                Template = "DefaultMailJob.html",
                                OkMessage = "Scadenziario Contratti inoltrato correttamente.",
                                KoMessage = "Si è verificato un problema durante l'invio dello Scadenziario Contratti",
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
        public class GaDipendentiNoviScadenziarioJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GaDipendentiNoviScadenziarioJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                using (var scope = _provider.CreateScope())
                {

                    var mailService = scope.ServiceProvider.GetService<IMailService>();
                    var personaleService = scope.ServiceProvider.GetService<IGaPersonaleService>();
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var list = personaleService.GetViewGaPersonaleScadenziarioAsync().Result;
                    var scadenziario = (from x in list.Data
                                        where (x.Stato == "R" || x.Stato == "G") && x.Disabled == false && x.Sede == "NOVI LIGURE"
                                        select x).OrderBy(x => x.DataScadenza).ToList();

                    var columnHeaders = new List<string>() { "Dipendente", "Tipo Scadenza", "Dettaglio Scadenza", "Data Scadenza" };

                    var rows = new List<List<string>>();
                    List<string> row;
                    foreach (var itm in scadenziario)
                    {
                        row = new List<string>();
                        row.Add(itm.Dipendente);
                        row.Add(itm.ScadenzaTipo);
                        row.Add(itm.ScadenzaDettaglio);
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
                                Description = "Scadenziario Dipendenti Novi Ligure",
                                DateScheduled = DateTime.Now,
                                Title = "Scadenziario Dipendenti Novi Ligure",
                                MailingTo = mailTo,
                                MailCc = mailCc,
                                Application = string.Format("1|{0}.{1}.{2}", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.Trigger.Key.Name),
                                Content = content,
                                Template = "DefaultMailJob.html",
                                OkMessage = "Scadenziario Dipendenti inoltrato correttamente.",
                                KoMessage = "Si è verificato un problema durante l'invio dello Scadenziario Dipendenti",
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
        public class GaDipendentiTortonaScadenziarioJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GaDipendentiTortonaScadenziarioJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                using (var scope = _provider.CreateScope())
                {

                    var mailService = scope.ServiceProvider.GetService<IMailService>();
                    var personaleService = scope.ServiceProvider.GetService<IGaPersonaleService>();
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var list = personaleService.GetViewGaPersonaleScadenziarioAsync().Result;
                    var scadenziario = (from x in list.Data
                                        where (x.Stato == "R" || x.Stato == "G") && x.Disabled == false && x.Sede == "TORTONA"
                                        select x).OrderBy(x => x.DataScadenza).ToList();

                    var columnHeaders = new List<string>() { "Dipendente", "Tipo Scadenza", "Dettaglio Scadenza", "Data Scadenza" };

                    var rows = new List<List<string>>();
                    List<string> row;
                    foreach (var itm in scadenziario)
                    {
                        row = new List<string>();
                        row.Add(itm.Dipendente);
                        row.Add(itm.ScadenzaTipo);
                        row.Add(itm.ScadenzaDettaglio);
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
                                Description = "Scadenziario Dipendenti Tortona",
                                DateScheduled = DateTime.Now,
                                Title = "Scadenziario Dipendenti Tortona",
                                MailingTo = mailTo,
                                MailCc = mailCc,
                                Application = string.Format("1|{0}.{1}.{2}", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.Trigger.Key.Name),
                                Content = content,
                                Template = "DefaultMailJob.html",
                                OkMessage = "Scadenziario Dipendenti inoltrato correttamente.",
                                KoMessage = "Si è verificato un problema durante l'invio dello Scadenziario Dipendenti",
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
        public class GaReclamiScadenziarioJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GaReclamiScadenziarioJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                using (var scope = _provider.CreateScope())
                {

                    var mailService = scope.ServiceProvider.GetService<IMailService>();
                    var reclamiService = scope.ServiceProvider.GetService<IGaReclamiService>();
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var list = reclamiService.GetViewGaReclamiDocumentiAsync().Result;
                    var scadenziario = (from x in list.Data
                                        where (DateTime.Now.AddDays(-7) < x.RispostaEntroData && x.Stato == "IN LAVORAZIONE" && x.Avanzamento != "V")
                                        select x).OrderBy(x => x.OrigineReclamiData).ToList();

                    var columnHeaders = new List<string>() { "Numero Reclamo", "Mittente", "Cantiere", "Oggetto", "Data Reclamo" };

                    var rows = new List<List<string>>();
                    List<string> row;
                    foreach (var itm in scadenziario)
                    {
                        row = new List<string>();
                        row.Add(itm.NumeroReclamo);
                        row.Add(itm.Mittente);
                        row.Add(itm.Cantiere);
                        row.Add(itm.Oggetto);
                        row.Add(itm.OrigineReclamiData.ToString("dd/MM/yyyy"));

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
                                Description = "Scadenziario Reclami",
                                DateScheduled = DateTime.Now,
                                Title = "Scadenziario Reclami",
                                MailingTo = mailTo,
                                MailCc = mailCc,
                                Application = string.Format("1|{0}.{1}.{2}", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.Trigger.Key.Name),
                                Content = content,
                                Template = "DefaultMailJob.html",
                                OkMessage = "Scadenziario Reclami inoltrato correttamente.",
                                KoMessage = "Si è verificato un problema durante l'invio dello Scadenziario Reclami",
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
