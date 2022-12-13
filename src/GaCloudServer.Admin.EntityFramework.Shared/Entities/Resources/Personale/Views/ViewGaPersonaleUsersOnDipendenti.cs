using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleUsersOnDipendenti:GenericEntity
    {
        public string UserId { get; set; }
        public long? DipendenteId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CognomeNome { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
        public bool ShowEmailInContacts { get; set; }
        public bool ShowInApp { get; set; }
        public bool ShowInContacts { get; set; }
    }
}
