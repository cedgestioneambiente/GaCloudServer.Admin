using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleSchedeConsegne : GenericEntity
    {
        public DateTime Data { get; set; }
        public long SchedaConsegnaId { get; set; }
        public string Numero { get; set; }
        public long DipendenteId { get; set; }
        public string Dipendente { get; set; }
        public string Sede { get; set; }
        public string Articolo { get; set; }
        public string Dpi { get; set; }
        public string Taglia { get; set; }
        public int Qta { get; set; }
    }
}

