using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi
{
    public class MezziScadenza: GenericFileAuditableEntity
    {
        public long MezziVeicoloId { get; set; }
        public long MezziScadenzaTipoId { get; set; }
        public DateTime DataScadenza { get; set; }
        public DateTime? DataUltimaScadenza { get; set; }
        public string Note { get; set; }

        public MezziVeicolo MezziVeicolo { get; set; }
        public MezziScadenzaTipo MezziScadenzaTipo { get; set; }
    }
}
