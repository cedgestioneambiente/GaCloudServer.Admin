using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views
{
    public class ViewGaPrenotazioneAutoRegistrazioni:GenericEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; }
        public string BackgroundColor { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
    }
}
