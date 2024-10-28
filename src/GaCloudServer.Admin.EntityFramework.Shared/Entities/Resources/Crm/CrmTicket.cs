using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmTicket : GenericAuditableEntity
    {
        public DateTime DataTicket { get; set; }
        public DateTime DataRichiesta { get; set; }
        [ForeignKey("CrmEventComune")]
        public long CrmEventComuneId { get; set; }
        public string? ComuneAlt { get; set; }
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
        [ForeignKey("ContactCenterProvenienza")]
        public long ContactCenterProvenienzaId { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }
        [ForeignKey("ContactCenterTipoRichiesta")]
        public long ContactCenterTipoRichiestaId { get; set; }
        public DateTime? DataChiusura { get; set; }
        [ForeignKey("ContactCenterStatoRichiesta")]
        public long ContactCenterStatoRichiestaId { get; set; }
        public string Creator { get; set; }
        public string Assignee { get; set; }
        public string NoteCrm { get; set; }
        public string NoteOperatore { get; set; }
        public string Tributo { get; set; }
        public string Tags { get; set; }

        public string Intestatario { get; set; }
        public string IntestatarioComune { get; set; }
        public string IntestatarioIndirizzo { get; set; }
        public string IntestatarioCfPiva { get; set; }

        public string? NumReclamo { get; set; }
        public bool? ReclamoFondato { get; set; }
        public CrmEventComune CrmEventComune { get; set; }
        public ContactCenterProvenienza ContactCenterProvenienza { get; set; }
        public ContactCenterTipoRichiesta ContactCenterTipoRichiesta { get; set; }
        public ContactCenterStatoRichiesta ContactCenterStatoRichiesta { get; set; }
    }
}
