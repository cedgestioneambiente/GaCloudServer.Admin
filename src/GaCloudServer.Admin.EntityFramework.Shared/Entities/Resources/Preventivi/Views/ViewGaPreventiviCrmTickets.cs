using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views
{
    public class ViewGaPreventiviCrmTickets : GenericEntity
    {
        public DateTime DataTicket { get; set; }
        public DateTime DataRichiesta { get; set; }
        public string ComuneCod { get; set; }
        public string ClienteComune { get; set; }
        public string CodCliente { get; set; }
        public string Cliente { get; set; }
        public string ClienteIndirizzo { get; set; }
        public string ClienteCfPiva { get; set; }
        public string ClienteCodSdi { get; set; }
        public string Intestatario { get; set; }
        public string IntestatarioComune { get; set; }
        public string IntestatarioIndirizzo { get; set; }
        public string IntestatarioIndirizzoOperativo { get; set; }
        public string IntestatarioCfPiva { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }
        public string NoteCrm { get; set; }
        public string NoteOperatore { get; set; }
        public long? ObjectId { get; set; }
        public string ObjectNumber { get; set; }
        public long? ObjectStatusId { get; set; }
        public string ObjectStatusDesc { get; set; }
        public string ObjectAssigneeId { get; set; }
        public string ObjectAssigneeDesc { get; set; }
        public string ObjectAssigneeCode { get; set; }
        public string TipoDesc { get; set; }
        public bool Important { get; set; }
        public string CreatorDesc { get; set; }

    }
}
