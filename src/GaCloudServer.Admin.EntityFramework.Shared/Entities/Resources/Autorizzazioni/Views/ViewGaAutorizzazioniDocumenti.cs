using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views
{
    public class ViewGaAutorizzazioniDocumenti:GenericEntity
    {
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public string Numero { get; set; }
        public DateTime DataRilascio { get; set; }
        public DateTime DataScadenza { get; set; }
        public string AutorizzazioniTipo { get; set; }
        public string Stato { get; set; }
        public bool Archiviata { get; set; }
    }
}
