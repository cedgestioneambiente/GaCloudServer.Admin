using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Recapiti.Views
{
    public class ViewGaRecapitiContatti : GenericEntity
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Cellulare { get; set; }
        public string Interno { get; set; }
        public bool ShowEmailInContacts { get; set; }
        public bool ShowInContacts { get; set; }
        public string Email { get; set; }

    }
}
