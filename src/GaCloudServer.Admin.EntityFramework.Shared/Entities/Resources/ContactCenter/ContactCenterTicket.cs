using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter
{
    public class ContactCenterTicket : GenericEntity
    {
        //da implementare
        public DateTime DataTicket { get; set; }
        public DateTime? EseguitoIl { get; set; }
        public DateTime? DataEsecuzione { get; set; }
        public long ContactCenterStatoRichiestaId { get; set; }
        public long ContactCenterProvenienzaId { get; set; }
        public long GlobalSedeId { get; set; }
        public string RichiedenteId { get; set; }
        public bool Inviato { get; set; }
        public string Materiali { get; set; }
        public bool Promemoria { get; set; }
        public bool DaFatturare { get; set; }
        public bool Stampato { get; set; }
        public string TelefonoMail { get; set; }
        public string TipoTicket { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public bool Reclamo { get; set; }

        public ContactCenterComune ContactCenterComune { get; set; }
        public ContactCenterStatoRichiesta ContactCenterStatoRichiesta { get; set; }
        public GlobalSede GlobalSede { get; set; }
        public ContactCenterProvenienza ContactCenterProvenienza { get; set; }


    }
}
