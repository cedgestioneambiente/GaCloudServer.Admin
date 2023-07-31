using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views
{
    public class ViewGaDispositiviOnModuli : GenericEntity
    {
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public long PersonaleDipendenteId { get; set; }
        public string Nominativo { get; set; }
        public string Sede { get; set; }
        public string InfoDispositivo { get; set; }
        public string Serial { get; set; }
        public string AltriDati { get; set; }
        public DateTime DataConsegna { get; set; }
    }
}
