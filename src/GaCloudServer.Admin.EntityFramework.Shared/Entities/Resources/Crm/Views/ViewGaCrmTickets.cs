using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views
{
    public class ViewGaCrmTickets : GenericEntity
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
        public long PrintTemplate { get; set; }
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
        public DateTime? DataProgrammazione { get; set; }

    }
}
