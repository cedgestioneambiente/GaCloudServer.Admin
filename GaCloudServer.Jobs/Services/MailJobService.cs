using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.SSO.Schedule.Configuration;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;

namespace GaCloudServer.Jobs.Services
{
    public class MailJobService : IMailJobService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly GraphServiceClient _graphClient;
        private readonly string _senderEmail;

        public MailJobService(IWebHostEnvironment env, IMailService mailService, IConfiguration configuration, GraphServiceClient graphClient)
        {
            _env = env;
            _mailService = mailService;
            _configuration = configuration;
            _graphClient = graphClient;
            _senderEmail = _configuration["Email:Sender"];
        }

        public async Task<bool> SendMail(MailJob mailJob)
        {
            try
            {
                string templatePath = Path.Combine(_env.ContentRootPath, "Templates/Mail", mailJob.Template);
                string body;
                using (var reader = new StreamReader(templatePath, Encoding.UTF8))
                {
                    body = await reader.ReadToEndAsync();
                }

                body = body.Replace("{jobTitle}", mailJob.Title)
                           .Replace("{jobContent}", mailJob.Content)
                           .Replace("{jobDate}", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                if (mailJob.Link == true)
                {
                    body = body.Replace("{jobLinkHref}", mailJob.LinkHref)
                               .Replace("{jobLinkDescription}", mailJob.LinkDescription);
                }

                var toRecipients = (mailJob.MailingTo ?? string.Empty)
                    .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(a => new Recipient { EmailAddress = new EmailAddress { Address = a } })
                    .ToList();

                var ccRecipients = (mailJob.MailCc ?? string.Empty)
                    .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(a => new Recipient { EmailAddress = new EmailAddress { Address = a } })
                    .ToList();

                var message = new Message
                {
                    Subject = mailJob.Title,
                    Body = new ItemBody { ContentType = BodyType.Html, Content = body },
                    ToRecipients = toRecipients,
                    CcRecipients = ccRecipients
                };

                if (mailJob.Attachment && !string.IsNullOrWhiteSpace(mailJob.AttachmentPath))
                {
                    string attachPathBase = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName;
                    attachPathBase += Path.DirectorySeparatorChar + _configuration.GetSection("EnvConsts").Get<EnvConstsConfiguration>().alternativeFolder;
                    string wwwrootPath = Path.Combine(attachPathBase, "wwwroot");
                    string fullAttachPath = Path.Combine(wwwrootPath, mailJob.AttachmentPath.Replace("/", Path.DirectorySeparatorChar.ToString()));

                    if (System.IO.File.Exists(fullAttachPath))
                    {
                        var bytes = await System.IO.File.ReadAllBytesAsync(fullAttachPath);
                        var fileAttachment = new FileAttachment
                        {
                            ODataType = "#microsoft.graph.fileAttachment",
                            Name = Path.GetFileName(fullAttachPath),
                            ContentBytes = bytes
                        };

                        message.Attachments = new MessageAttachmentsCollectionPage { fileAttachment };
                    }
                }

                // invia la mail come utente/sender specificato nella configurazione
                await _graphClient.Users[_senderEmail].SendMail(message, false).Request().PostAsync();

                return true;
            }
            catch (Exception ex)
            {
                mailJob.KoMessage = ex.Message;
                await _mailService.UpdateMailJobAsync(mailJob);
                return false;
            }
        }
    }
}
