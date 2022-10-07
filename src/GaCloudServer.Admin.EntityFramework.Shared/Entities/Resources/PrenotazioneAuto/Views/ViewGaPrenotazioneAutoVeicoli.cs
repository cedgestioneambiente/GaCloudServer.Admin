using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views
{
    public class ViewGaPrenotazioneAutoVeicoli:GenericEntity
    {
        public string Targa { get; set; }
        public string Colore { get; set; }
        public string Sede { get; set; }
        public bool Weekend { get; set; }
    }
}
