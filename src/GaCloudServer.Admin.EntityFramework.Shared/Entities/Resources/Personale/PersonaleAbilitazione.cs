using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleAbilitazione : GenericFileAuditableEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public long PersonaleAbilitazioneTipoId { get; set; }
        public DateTime DataVisita { get; set; }
        public DateTime DataScadenza { get; set; }
        public string DettaglioAbilitazione { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
        public PersonaleAbilitazioneTipo PersonaleAbilitazioneTipo { get; set; }
    }
}
