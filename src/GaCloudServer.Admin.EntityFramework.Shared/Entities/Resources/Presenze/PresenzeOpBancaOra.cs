using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeOpBancaOra : GenericEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public double GgFerie { get; set; }
        public double GgFerieCcnl { get; set; }
        public double HhPermessoCcnl { get; set; }
        public double HhRecupero { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
    }
}
