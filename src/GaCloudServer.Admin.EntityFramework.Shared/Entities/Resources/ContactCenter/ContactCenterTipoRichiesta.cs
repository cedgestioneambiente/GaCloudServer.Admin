using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter
{
    public class ContactCenterTipoRichiesta : GenericListAuditableEntity
    {
        public bool Ingombranti { get; set; }
        public bool Magazzino { get; set; }
        public bool MagazzinoCalendar { get; set; }
        public bool Fatturazione { get; set; }
        public bool ContactCenter { get; set; }
        public bool ContactCenterCalendar { get; set; }
        public string CodArera { get; set; }
        public long? ContactCenterPrintTemplateId { get; set; }
        public bool PrintMassive { get; set; }
        public string Group { get; set; }
        public int? GiorniGestione { get; set; }
        public bool Commerciale { get; set; }
        public bool Important { get; set; }
        public bool Reclamo { get; set; }
    }
}
