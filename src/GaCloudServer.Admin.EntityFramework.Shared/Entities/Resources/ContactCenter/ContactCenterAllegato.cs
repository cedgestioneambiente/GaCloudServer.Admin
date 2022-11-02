using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter
{
    public class ContactCenterAllegato : GenericFileEntity
    {
        public long ContactCenterTicketId { get; set; }
        public string Descrizione { get; set; }
    }
}
