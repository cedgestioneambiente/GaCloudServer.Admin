using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeRichiesta : GenericAuditableEntity
    {
        public long PresenzeDipendenteId { get; set; }
        public long PresenzeStatoRichiestaId { get; set; }
        public long PresenzeTipoOraId { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public double TotaleOre { get; set; }

        public PresenzeDipendente PresenzeDipendente { get; set; }
        public PresenzeStatoRichiesta PresenzeStatoRichiesta { get; set; }
        public PresenzeTipoOra PresenzeTipoOra { get; set; }
    }
}
