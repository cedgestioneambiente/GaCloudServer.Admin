using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views
{
    public class ViewGaPreventiviCrmTickets : GenericEntity
    {
        public long Numero { get; set; }
        public DateTime DataTicket { get; set; }
        public DateTime DataRichiesta { get; set; }
        public long ComuneId { get; set; }
        public string ComuneCod { get; set; }
        public string ComuneDesc { get; set; }
        public long Duration { get; set; }
        public string Utente { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string Prg { get; set; }
        public string CfPiva { get; set; }
        public string Via { get; set; }
        public string NumCiv { get; set; }
        public long CanaleId { get; set; }
        public string CanaleDesc { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }
        public long TipoId { get; set; }
        public string TipoDesc { get; set; }
        public bool Fatturazione { get; set; }
        public bool Magazzino { get; set; }
        public long? PrintTemplate { get; set; }
        public bool MagazzinoCalendar { get; set; }
        public bool ContactCenterCalendar { get; set; }
        public DateTime? DataChiusura { get; set; }
        public long StatoId { get; set; }
        public string StatoDesc { get; set; }
        public string Creator { get; set; }
        public string CreatorDesc { get; set; }
        public string Assignee { get; set; }
        public string AssigneeDesc { get; set; }
        public string NoteCrm { get; set; }
        public string NoteOperatore { get; set; }
        public string CodZona { get; set; }
        public string Tributo { get; set; }
        public string? Tags { get; set;  }
        public long? ObjectId { get; set; }
        public string? ObjectNumber { get; set; }
        public long? ObjectStatusId { get; set; }
        public string? ObjectStatusDesc { get; set;}
        public string? ObjectAssigneeId { get; set; }
        public string? ObjectAssigneeDesc { get; set; }
        public string? ObjectAssigneeCode { get;set; }

    }
}
