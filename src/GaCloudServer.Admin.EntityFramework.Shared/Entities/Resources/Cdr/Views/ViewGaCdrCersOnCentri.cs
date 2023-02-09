using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views
{
    public class ViewGaCdrCersOnCentri : GenericEntity
    {
        public long CerId { get; set; }
        public long CentroId { get; set; }
        public string Cer { get; set; }
        public string Imm { get; set; }
        public bool Abilitato { get; set; }
    }
}
