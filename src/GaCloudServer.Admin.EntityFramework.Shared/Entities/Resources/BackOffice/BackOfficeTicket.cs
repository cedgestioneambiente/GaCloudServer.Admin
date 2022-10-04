using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice
{
    public class BackOfficeTicket : GenericEntity
    {
        public DateTime Data { get; set; }
        public long BackOfficeTipoTicketId { get; set; }
        public string NumCon { get; set; }
        public string Descrizione { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public long BackOfficeStatoTicketId { get; set; }
        public string UserId { get; set; }

        public BackOfficeStatoTicket BackOfficeStatoTicket { get; set; }
        public BackOfficeTipoTicket BackOfficeTipoTicket { get; set; }

    }
}
