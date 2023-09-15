using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views
{
    public class ViewGaCrmGarbageTicketMagazzino:GenericEntity
    {
        public DateTime DATA_RICHIESTA { get; set; }
        public DateTime? DATA_CHIUSURA { get; set; }
        public long COD_COMUNE { get; set; }
        public string COD_UTENZA { get; set; }
        public string TRIBUTO { get; set; }
        public string VIA { get; set; }
        public string CIVICO { get; set; }
        public string ZONA { get; set; }
        public long COD_PROVENIENZA_RICHIESTA { get; set; }
        public long COD_TIPO_RICHIESTA { get; set; }
        public string TELEFONO { get; set; }
        public string CELLULARE { get; set; }
        public string EMAIL { get; set; }
        public string EMAIL_PEC { get; set; }
        public string NOTE_TICKET { get; set; }
        public string NOTE_CHIUSURA { get; set; }
        public long COD_STATO_RICHIESTA { get; set; }
        public string CREATO_DA { get; set; }
        public string ASSEGNATO_A { get; set; }

    }
}
