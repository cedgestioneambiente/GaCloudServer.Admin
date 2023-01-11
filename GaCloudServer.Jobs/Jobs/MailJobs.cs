using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Jobs.Helpers;
using GaCloudServer.Jobs.Services;
using Quartz;

namespace GaCloudServer.Jobs.Jobs
{
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    public class MailJobs:IJob
    {
        public readonly IServiceProvider _provider;
        public MailJobs(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _provider.CreateScope())
            {
                var mailService = scope.ServiceProvider.GetService<IMailService>();
                var mailJobService = scope.ServiceProvider.GetService<IMailJobService>();
                var notificationService = scope.ServiceProvider.GetService<INotificationService>();

                var mails = mailService.GetMailJobsAsync(false).Result;

                if (mails.Data.Count > 0)
                {
                    foreach (var mail in mails.Data)
                    {
                        var result = mailJobService.SendMail(mail).Result;
                        if (result == false)
                        {
                            foreach (var itm in mail.UserId.Split(";"))
                            {
                                var userNotification = notificationService.GetViewViewNotificationUsersOnAppsByUserIdAsync(itm).Result;
                                if ((from x in userNotification.Data where x.AppId== TextHelpers.AppSplit(mail.Application) select x).ToList().Count>0)
                                {
                                    var notification = notificationService.AddNotificationEventAsync(new NotificationEventDto()
                                    {
                                        Id = 0,
                                        DateEvent = DateTime.Now,
                                        UserId = itm,
                                        NotificationAppId = TextHelpers.AppSplit(mail.Application),
                                        Title = mail.Title,
                                        Message = mail.KoMessage,
                                        Read = false,
                                        Disabled = false
                                    }).Result;
                                }
                            }

                            

                            var setError = mailService.SetErrorOnMailJobAsync(mail.Id).Result;
                        }
                        else
                        {
                            foreach (var itm in mail.UserId.Split(";"))
                            {
                                var userNotification = notificationService.GetViewViewNotificationUsersOnAppsByUserIdAsync(itm).Result;
                                if ((from x in userNotification.Data where x.AppId == TextHelpers.AppSplit(mail.Application) select x).ToList().Count > 0)
                                {
                                    var notification = notificationService.AddNotificationEventAsync(new NotificationEventDto()
                                    {
                                        Id = 0,
                                        DateEvent = DateTime.Now,
                                        UserId = itm,
                                        NotificationAppId = TextHelpers.AppSplit(mail.Application),
                                        Title = mail.Title,
                                        Message = mail.OkMessage,
                                        Read = false,
                                        Disabled = false
                                    }).Result;
                                }
                            }

                            var setSended = mailService.SetSendedOnMailJobAsync(mail.Id).Result;
                        }
                    }
                }



            }

            return Task.CompletedTask;
        }
    }
}
