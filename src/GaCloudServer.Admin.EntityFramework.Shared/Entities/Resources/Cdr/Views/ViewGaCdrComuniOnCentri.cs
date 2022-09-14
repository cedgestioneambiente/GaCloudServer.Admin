using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views
{
    public class ViewGaCdrComuniOnCentri : GenericEntity
    {
        public long CentroId { get; set; }
        public long ComuneId { get; set; }
        public string Comune { get; set; }
        public bool Abilitato { get; set; }
    }
}
