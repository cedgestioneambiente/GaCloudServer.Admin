using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmTicketAllegato : GenericFileAuditableEntity
    {
        public long CrmTicketId { get; set; }
        public string Descrizione { get; set; }
    }
}
