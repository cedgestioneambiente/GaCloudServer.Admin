using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IMailService
    {
        Task<PagedList<MailJob>> GetMailJobsAsync(bool all = true);
        Task<MailJob> GetMailJobByIdAsync(long id);
        Task<long> AddMailJobAsync(MailJob entity);
        Task<long> UpdateMailJobAsync(MailJob entity);
        Task<bool> DeleteMailJobAsync(long id);

        Task<bool> SetErrorOnMailJobAsync(long id);
        Task<bool> SetSendedOnMailJobAsync(long id);
    }
}
