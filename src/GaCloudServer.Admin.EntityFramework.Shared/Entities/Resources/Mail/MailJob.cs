using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail
{
    public class MailJob:GenericEntity
    {
        public DateTime DateScheduled { get; set; }
        public string MailingTo { get; set; }
        public string MailCc { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Application { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime DateSend { get; set; }
        public string OkMessage { get; set; }
        public string KoMessage { get; set; }
        public bool IsSended { get; set; }
        public bool IsError { get; set; }
        public bool Attachment { get; set; }
        public string AttachmentPath { get; set; }
    }
}
