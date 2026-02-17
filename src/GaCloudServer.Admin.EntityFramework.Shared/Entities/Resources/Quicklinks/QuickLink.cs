using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Quicklinks
{
    public class QuickLink : GenericAuditableEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Descrizione { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
    }
}
