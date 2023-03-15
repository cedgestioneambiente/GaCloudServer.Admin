using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts.Views
{
    public class ViewShortcutItems:GenericEntity
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string ShortcutLink { get; set; }
        public bool UseRouter { get; set; }
        public string UserId { get; set; }
    }
}
