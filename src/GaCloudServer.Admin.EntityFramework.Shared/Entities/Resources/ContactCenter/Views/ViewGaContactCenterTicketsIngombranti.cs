using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views
{
    public class ViewGaContactCenterTicketsIngombranti : GenericEntity
    {
        public long ComuneId { get; set; }
        public DateTime? DataEsecuzione { get; set; }
        public string Indirizzo { get; set; }
        public string Materiali { get; set; }
        public long ContactCenterTipoRichiestaId { get; set; }
        public string Utente { get; set; }
        public string TipoTicket { get; set; }
    }
}
