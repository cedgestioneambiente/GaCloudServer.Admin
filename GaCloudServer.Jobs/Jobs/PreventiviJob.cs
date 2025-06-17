using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Jobs.Helpers;
using Quartz;
using SendGrid.Helpers.Mail;
using static Duende.IdentityServer.Models.IdentityResources;
using static GaCloudServer.Jobs.Helpers.FileHelper;

namespace GaCloudServer.Jobs.Jobs
{

    public static class PreventiviJobs
    {

        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class PreventiviImportJob : IJob
        {
            private readonly IServiceProvider _provider;

            public PreventiviImportJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public async Task Execute(IJobExecutionContext context)
            {
                using var scope = _provider.CreateScope();

                var preventiviService = scope.ServiceProvider.GetRequiredService<IGaPreventiviService>();
                var queryService = scope.ServiceProvider.GetRequiredService<IQueryManager>(); // o come l’hai registrato

                //string query =  "SELECT * FROM [GA_ISMART].[dbo].[VISTA_PREVENTIVI] WHERE IDDOCUMENTO = 'PREV'"; // da affinare
                var query = SqlHelper.LoadSqlFromFile("Scripts/Preventivi/PreventiviIsmartDocumentiGetter.sql");

                var records = await queryService.ExecQueryAsync(query);

                foreach (dynamic item in records)
                {
                    string codcli = item.Codcli;
                    int prgfat = item.Prgfat;
                    string iddoc = item.IdDocumento;

                    await preventiviService.CreatePreventiviIsmartDocumentoAsync(new PreventiviIsmartDocumento
                    {
                        Codcli = codcli,
                        Prgfat = prgfat,
                        IdDocumento = iddoc,
                        Numfat = item.Numfat,
                        Codsez = item.Codsez,
                        Dtfat = item.Dtfat,
                        Numprev= item.Numprev,
                        PreventiviObjectId = item.PreventiviObjectId,
                        Ragsoc = item.Ragsoc,
                        DataInserimento = DateTime.UtcNow
                    });

                }

                // (Step successivo) → recupero dati pagamento da TARI + aggiornamento
                // (Step finale) → invio mail + flag Gestito
            }
        }


        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class PreventiviPagamentiJob : IJob
        {
            private readonly IServiceProvider _provider;

            public PreventiviPagamentiJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public async Task Execute(IJobExecutionContext context)
            {
                using var scope = _provider.CreateScope();

                var preventiviService = scope.ServiceProvider.GetRequiredService<IGaPreventiviService>();
                var queryService = scope.ServiceProvider.GetRequiredService<IQueryManager>();
                var mailService = scope.ServiceProvider.GetService<IMailService>();
                var notificationService = scope.ServiceProvider.GetService<INotificationService>();

                var query = SqlHelper.LoadSqlFromFile("Scripts/Preventivi/PreventiviIsmartDocumentiPayment.sql");
                var records = await queryService.ExecQueryAsync(query);

                foreach (dynamic item in records)
                {
                    long id = item.Id;
                    decimal pagato = item.ImportoPagato;
                    DateTime? dataPagamento = item.DataPagamento;

                    //long preventiviObjectId = -1; try
                    //{
                    //    preventiviObjectId = preventiviService.GetPreventiviObjectsAsync(new Shared.PageRequest() { Filter = $"ObjectNumber eq {item.Numprev}" }).Result.Items?.FirstOrDefault()?.Id ?? -1;
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine($"Preventivo non trovato ({item.Numprev})");
                    //}

                    var result =await preventiviService.UpdatePagamentoPreventivoAsync(id, pagato, dataPagamento);
                    if (result != -1)
                    {

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
                            // Generiamo contenuto minimale
                            var content = HtmlHelpers.GenerateText(
                            $"È stato registrato un pagamento di anticipo per il preventivo {item.Numprev} del cliente {item.Codcli} - {item.Ragsoc}.<br/>" +
                            $"Fattura: {item.Codsez}/{item.Numfat}<br/>" +
                            $"Importo: {item.ImportoPagato?.ToString("N2")}€<br/>" +
                            $"Data: {item.DataPagamento?.ToString("dd/MM/yyyy")}"
                        );

                            // Recupero utenti destinatari per logging o fallback
                            var notificationUsers = await notificationService.GetViewViewNotificationUsersOnAppsByAppIdAsync(1);
                            var usersId = notificationUsers.Data.Select(x => x.UserId).ToList();

                            var job = new MailJob
                            {
                                Id = 0,
                                Description = $"Notifica pagamento anticipo preventivo {item.Numprev}",
                                DateScheduled = DateTime.Now,
                                Title = $"Pagamento anticipo registrato - Preventivo {item.Numprev} - {item.Ragsoc}",
                                MailingTo = mailTo,
                                MailCc = mailCc,//"recupero.crediti@gestioneambiente.net",
                                Application = $"1|{context.JobDetail.Key.Group}.{context.JobDetail.Key.Name}.{context.Trigger.Key.Name}",
                                Content = content,
                                Template = "DefaultMailWithLinkJob.html",
                                OkMessage = $"Mail per il pagamento anticipo preventivo {item.Numprev} inviata con successo.",
                                KoMessage = $"Errore nell'invio mail per pagamento anticipo preventivo {item.Numprev}.",
                                UserId = string.Join(";", usersId),
                                Attachment = false,
                                Link = true,
                                LinkHref = String.Format("https://cloud.gestioneambiente.net/preventivi/tab/object/{0}", item.PreventiviObjectId),
                                LinkDescription = "Vai al preventivo",
                            };

                            var mailResponse = await mailService.AddMailJobAsync(job);
                            if (mailResponse > 0)
                            {
                                await preventiviService.UpdatePagamentoPreventivoMailAsync(id, true);
                            }
                        }


                    }

                    
                }
            }
        }
    }

}
