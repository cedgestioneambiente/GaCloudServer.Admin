using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeDipendente : GenericEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public string Matricola { get; set; }
        public long PresenzeOrarioId { get; set; }
        public long PresenzeProfiloId { get; set; }
        public double HhFerie { get; set; }
        public double GgFerie { get; set; }
        public double GgPermessiCcnl { get; set; }
        public double HhPermessiCcnl { get; set; }
        public double HhRecupero { get; set; }
        public bool Abilitato { get; set; }
        public bool PrivilegiElevati { get; set; }
        public bool AutoApprova { get; set; }
        public bool SuperUser { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
        public PresenzeOrario PresenzeOrario { get; set; }
        public PresenzeProfilo PresenzeProfilo { get; set; }
    }
}
