using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeTipoOra : GenericListAuditableEntity
    {
        public bool ApprovazioneAutomatica { get; set; }
        public int DecrementaTipo { get; set; }
    }
}
