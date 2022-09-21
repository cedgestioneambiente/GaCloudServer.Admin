using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views
{
    public class ViewGaMezziScadenze:GenericEntity
    {
        public long MezziVeicoloId { get; set; }
        public string Targa { get; set; }
        public string Cantiere { get; set; }
        public string TipoScadenza { get; set; }
        public DateTime? DataUltimaScadenza { get; set; }
        public DateTime? DataScadenza { get; set; }
        public string PeriodoScadenza { get; set; }
        public string Note { get; set; }
        public string Stato { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public bool Dismesso { get; set; }
    }
}
