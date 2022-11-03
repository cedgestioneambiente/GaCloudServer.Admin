using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleSchedaConsegnaDettaglio : GenericEntity
    {
        public long PersonaleSchedaConsegnaId { get; set; }
        public long PersonaleMagazzinoArticoloId { get; set; }
        public string Taglia { get; set; }
        public int Qta { get; set; }

        public PersonaleSchedaConsegna PersonaleSchedeConsegna { get; set; }
        public PersonaleArticolo PersonaleArticolo { get; set; }
    }
}
