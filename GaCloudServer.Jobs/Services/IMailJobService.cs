using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;

namespace GaCloudServer.Jobs.Services
{
    public interface IMailJobService
    {
        Task<bool> SendMail(MailJob mailJob);
    }
}
