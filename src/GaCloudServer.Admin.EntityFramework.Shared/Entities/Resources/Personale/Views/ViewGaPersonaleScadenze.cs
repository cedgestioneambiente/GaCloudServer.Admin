using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleScadenze:GenericEntity
    {
        public long DipendenteId { get; set; }
        public long ScadenzaTipoId { get; set; }
        public string ScadenzaTipo { get; set; }
        public string ScadenzaDettaglio { get; set; }
        public DateTime DataScadenza { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string Stato { get; set; }
    }
}
