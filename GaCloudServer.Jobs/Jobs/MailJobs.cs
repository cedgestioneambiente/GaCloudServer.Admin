using GaCloudServer.BusinnessLogic.Services.Interfaces;
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

                var mails = mailService.GetMailJobsAsync(false).Result;

                if (mails.Data.Count > 0)
                {
                    foreach (var mail in mails.Data)
                    {
                        var result = mailJobService.SendMail(mail).Result;
                        if (result == false)
                        {
                            var setError = mailService.SetErrorOnMailJobAsync(mail.Id).Result;
                        }
                        else
                        {
                            var setSended = mailService.SetSendedOnMailJobAsync(mail.Id).Result;
                        }
                    }
                }



            }

            return Task.CompletedTask;
        }
    }
}
