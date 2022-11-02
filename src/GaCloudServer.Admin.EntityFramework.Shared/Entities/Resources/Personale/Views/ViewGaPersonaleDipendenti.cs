using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleDipendenti:GenericEntity
    {
        public string UserId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Sede { get; set; }
        public long SedeId { get; set; }
        public string Qualifica { get; set; }
        public long QualificaId { get; set; }
    }
}
