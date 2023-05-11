using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views
{
    public class ViewGaCrmCausali : GenericListEntity
    {
        public int Type { get; set; }
        public string TipoOperazione { get; set; }
    }
}
