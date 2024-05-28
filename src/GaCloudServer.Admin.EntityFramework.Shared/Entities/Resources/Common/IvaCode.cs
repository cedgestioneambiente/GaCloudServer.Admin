using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common
{
    public class IvaCode:GenericEntity
    {
        public string Descrizione { get; set; }
        public string DescrizioneBreve { get; set; }
        public double Valore { get; set; }
        public bool Split {  get; set; }
    }
}
