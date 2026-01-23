using AuthServer.SSO.Schedule.Configuration;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace GaCloudServer.Jobs.Services
{
    public class MailJobService : IMailJobService
    {
        private readonly IWebHostEnvironment _env;
        private readonly string sender;
        private readonly string senderPassword;
        public readonly IMailService _mailService;
        public IConfiguration _configuration;

        public MailJobService(IWebHostEnvironment env,IMailService mailService,IConfiguration configuration)
        {
            sender = "helpdesk@gestioneambiente.net";
            senderPassword = "P/245790196356uh";
            _env = env;
            _mailService = mailService;
            _configuration = configuration;
        }



        public async Task<bool> SendMail(MailJob mailJob)
        {
            try
            {
                var email = new MimeMessage();

                if (mailJob.MailingTo != null && mailJob.MailingTo.Length > 0)
                {
                    foreach (var mail in mailJob.MailingTo.Split(';'))
                    {
                        email.To.Add(MailboxAddress.Parse(mail));
                    }
                }

                if (mailJob.MailCc != null && mailJob.MailCc.Length > 0)
                {
                    foreach (var mail in mailJob.MailCc.Split(';'))
                    {
                        email.Cc.Add(MailboxAddress.Parse(mail));
                    }
                }



                email.From.Add(MailboxAddress.Parse(sender));
                email.Subject = mailJob.Title;
                string body = string.Empty;
                string templatePath = Path.Combine(_env.ContentRootPath, "Templates/Mail/" + mailJob.Template);

                using (StreamReader reader = new StreamReader(templatePath))
                {

                    body = reader.ReadToEnd();

                }

                body = body.Replace("{jobTitle}", mailJob.Title);
                body = body.Replace("{jobContent}", mailJob.Content);
                body = body.Replace("{jobDate}", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                if (mailJob.Link!=null && mailJob.Link==true)
                {
                    body = body.Replace("{jobLinkHref}", mailJob.LinkHref);
                    body = body.Replace("{jobLinkDescription}", mailJob.LinkDescription);
                }

                if (!mailJob.Attachment)
                {
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };
                }
                else
                {
                    string projectDirectory = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                    string wwwrootPath = "";

                    string attachPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                    attachPath += "\\" + _configuration.GetSection("EnvConsts").Get<EnvConstsConfiguration>().alternativeFolder;


                    if (_env.IsDevelopment())
                    {
                        wwwrootPath = Path.Combine(attachPath, "wwwroot");
                    }
                    else
                    { 
                        wwwrootPath= Path.Combine(attachPath, "wwwroot");
                    }
                    


                    var builder = new BodyBuilder();
                    builder.HtmlBody = body;
                    builder.Attachments.Add(Path.Combine(wwwrootPath, mailJob.AttachmentPath).Replace("/","\\"));
                    email.Body = builder.ToMessageBody();
                }


                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(sender, senderPassword);
                    await client.SendAsync(email);
                    await client.DisconnectAsync(true);
                }


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
