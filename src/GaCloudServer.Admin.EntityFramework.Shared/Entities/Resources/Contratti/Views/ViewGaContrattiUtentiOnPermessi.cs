using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views
{
    public class ViewGaContrattiUtentiOnPermessi : GenericEntity
    {
        public string UtenteId { get; set; }
        public string Utente { get; set; }
        public long PermessoId { get; set; }
        public string Permesso { get; set; }
        public bool Abilitato { get; set; }
    }
}
