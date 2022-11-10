using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeBancaOraUtilizzo : GenericEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public long PresenzeRichiestaId { get; set; }
        public int Tipo { get; set; }
        public double Qta { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
        public PresenzeRichiesta PresenzeRichiesta { get; set; }
    }
}
