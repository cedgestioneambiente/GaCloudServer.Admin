using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmTicket : GenericAuditableEntity
    {
        public DateTime DataTicket { get; set; }
        public DateTime DataRichiesta { get; set; }
        public long CrmEventComuneId { get; set; }
        public string Utente { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string Prg { get; set; }
        public string CodSdi { get; set; }
        public string CfPiva { get; set; }
        public string Via { get; set; }
        public string NumCiv { get; set; }
        public string CodZona { get; set; }
        public long ContactCenterProvenienzaId { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }
        public long ContactCenterTipoRichiestaId { get; set; }
        public DateTime? DataChiusura { get; set; }
        public long ContactCenterStatoRichiestaId { get; set; }
        public string Creator { get; set; }
        public string Assignee { get; set; }
        public string NoteCrm { get; set; }
        public string NoteOperatore { get; set; }
        public string Tributo { get; set; }
        public string Tags { get; set; }

        public CrmEventComune CrmEventComune { get; set; }
        public ContactCenterProvenienza ContactCenterProvenienza { get; set; }
        public ContactCenterTipoRichiesta ContactCenterTipoRichiesta { get; set; }
        public ContactCenterStatoRichiesta ContactCenterStatoRichiesta { get; set; }
    }
}
