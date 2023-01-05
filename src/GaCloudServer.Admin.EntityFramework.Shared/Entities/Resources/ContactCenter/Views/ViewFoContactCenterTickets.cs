using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views
{
    public class ViewFoContactCenterTickets : GenericEntity
    {
        public string Richiedente { get; set; }
        public string RagioneSociale { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string CfPiva { get; set; }
        public string Comune { get; set; }
        public string Cantiere { get; set; }
        public string Stato { get; set; }
        public string Provenienza { get; set; }
        public string TipoTicket { get; set; }
        public string Indirizzo { get; set; }
        public string Zona { get; set; }
        public DateTime DataTicket { get; set; }
        public DateTime? EseguitoIl { get; set; }
        public DateTime? DataEsecuzione { get; set; }
        public string Materiali { get; set; }
        public bool Promemoria { get; set; }
        public bool Inviato { get; set; }
        public bool DaFatturare { get; set; }
        public bool Reclamo { get; set; }
        public bool Stampato { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string TelefonoMail { get; set; }
        public string Info { get; set; }
        public long Numero { get; set; }
        public bool Ingombranti { get; set; }
    }
}
