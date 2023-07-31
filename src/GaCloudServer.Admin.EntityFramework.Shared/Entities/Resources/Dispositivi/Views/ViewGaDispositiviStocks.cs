using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views
{
    public class ViewGaDispositiviStocks: GenericEntity
    {
        public string InfoDispositivo { get; set; }
        public string Serial { get; set; }
        public string AltriDati { get; set; }
        public string Note { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public DateTime? DataDismissione { get; set; }
        public string Categoria { get; set; }
        public bool Disponibile { get; set; }
        public string Nominativo { get; set; }
    }
}
