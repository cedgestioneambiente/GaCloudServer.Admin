using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti
{
    public class ProgettiJob:GenericEntity
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Class { get; set; }   
        public string Link { get; set; }
        public int Miles { get; set; }
        public string Res { get; set; }
        public string Comp { get; set; }
        public int Group { get; set; }
        public int Parent { get; set; }
        public int Open { get; set; }
        public string Depend { get; set; }
        public string Caption { get; set; }
        public string Notes { get; set; }
        public int Priority { get; set; }

        public long ProgettiWorkId { get; set; }

        public ProgettiWork ProgettiWork { get; set; }

    }
}
