using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleScadenziario : GenericEntity
    {
        public string Dipendente { get; set; }
        public string Sede { get; set; }
        public DateTime DataScadenza { get; set; }
        public string ScadenzaTipo { get; set; }
        public string ScadenzaDettaglio { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string Stato { get; set; }
    }
}

