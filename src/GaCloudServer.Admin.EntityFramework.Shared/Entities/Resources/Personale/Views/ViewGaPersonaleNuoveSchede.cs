using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleNuoveSchede : GenericEntity
    {
        public string Articolo { get; set; }
        public string Dpi { get; set; }
        public string Taglia { get; set; }
        public int Qta { get; set; }
    }
}

