using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleArticoli : GenericEntity
    {
        public string Tipologia { get; set; }
        public string Modello { get; set; }
        public string Dpi { get; set; }
    }
}

