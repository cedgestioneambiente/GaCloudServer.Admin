using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleScadenza : GenericFileAuditableEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public long PersonaleScadenzaTipoId { get; set; }
        public long PersonaleScadenzaDettaglioId { get; set; }
        public DateTime DataScadenza { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
        public PersonaleScadenzaTipo PersonaleScadenzaTipo { get; set; }
        public PersonaleScadenzaDettaglio PersonaleScadenzaDettaglio { get; set; }
    }
}
