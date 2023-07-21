using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views
{
    public class ViewGaDispositiviOnDipendenti : GenericEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public string InfoDispositivo { get; set; }
        public string Serial { get; set; }
        public string AltriDati { get; set; }
        public string Note { get; set; }
        public DateTime DataConsegna { get; set; }
        public DateTime? DataRitiro { get; set; }
    }
}
