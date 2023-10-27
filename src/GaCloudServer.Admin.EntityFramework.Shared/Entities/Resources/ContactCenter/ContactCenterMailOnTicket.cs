using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter
{
    public class ContactCenterMailOnTicket : GenericAuditableEntity
    {
        public long ContactCenterTicketId { get; set; }
        public long ContactCenterMailId { get; set; }
        public string MailAddress { get; set; }
        public DateTime Data { get; set; }

        public ContactCenterTicket ContactCenterTicket { get; set; }
        public ContactCenterMail ContactCenterMail { get; set; }
    }
}
