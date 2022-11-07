using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleSanzioni : GenericListEntity
    {
        public long DipendenteId { get; set; }
        public string Dipendente { get; set; }
        public long SedeId { get; set; }
        public string Sede { get; set; }
        public DateTime Data { get; set; }
        public string Motivo { get; set; }
        public string DettaglioSanzione { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
    }
}

