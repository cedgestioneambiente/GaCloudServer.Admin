using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleAbilitazioni : GenericEntity
    {
        public long DipendenteId { get; set; }
        public DateTime DataVisita { get; set; }
        public DateTime DataScadenza { get; set; }
        public string Tipo { get; set; }
        public string DettaglioAbilitazione { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
    }
}

