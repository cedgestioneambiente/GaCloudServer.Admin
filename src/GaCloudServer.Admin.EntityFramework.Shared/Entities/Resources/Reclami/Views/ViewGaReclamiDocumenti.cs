using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views
{
    public class ViewGaReclamiDocumenti : GenericEntity
    {
        public string NumeroReclamo { get; set; }
        public string OrigineReclami { get; set; }
        public DateTime OrigineReclamiData { get; set; }
        public string Mittente { get; set; }
        public string Oggetto { get; set; }
        public DateTime RispostaEntroData { get; set; }
        public DateTime? RispostaInviataData { get; set; }
        public DateTime? RispostaDefinitivaData { get; set; }
        public bool Fondato { get; set; }
        public string Infondato { get; set; }
        public string Stato { get; set; }
        public string Cantiere { get; set; }
        public string Note { get; set; }
        public string Avanzamento { get; set; }
    }
}
