using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts
{
    public class ShortcutLink:GenericEntity
    {
        public string Link { get; set; }
        public string Descrizione { get; set; }
        public string Roles { get; set; }
    }
}
