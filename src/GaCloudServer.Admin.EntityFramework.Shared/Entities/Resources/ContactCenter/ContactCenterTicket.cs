using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter
{
    public class ContactCenterTicket : GenericAuditableEntity
    {
        public string Utente { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string CfPiva { get; set; }
        public string Via { get; set; }
        public string NumCiv { get; set; }
        public string Zona { get; set; }
        public DateTime DataTicket { get; set; }
        public DateTime? EseguitoIl { get; set; }
        public DateTime? DataEsecuzione { get; set; }
        public long ContactCenterStatoRichiestaId { get; set; }
        public long ContactCenterProvenienzaId { get; set; }
        public long ContactCenterComuneId { get; set; }
        public string ComuneAltro { get; set; }
        public long ContactCenterTipoRichiestaId { get; set; }
        public long AziendeListaId { get; set; }
        public string UserId { get; set; }
        public bool Inviato { get; set; }
        public string Materiali { get; set; }
        public bool Promemoria { get; set; }
        public bool DaFatturare { get; set; }
        public bool Stampato { get; set; }
        public string TelefonoMail { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public bool Reclamo { get; set; }
        public string Prg { get; set; }

        public ContactCenterComune ContactCenterComune { get; set; }
        public ContactCenterStatoRichiesta ContactCenterStatoRichiesta { get; set; }
        public AziendeLista AziendeLista { get; set; }
        public ContactCenterProvenienza ContactCenterProvenienza { get; set; }
        public ContactCenterTipoRichiesta ContactCenterTipoRichiesta { get; set; }
    }
}
