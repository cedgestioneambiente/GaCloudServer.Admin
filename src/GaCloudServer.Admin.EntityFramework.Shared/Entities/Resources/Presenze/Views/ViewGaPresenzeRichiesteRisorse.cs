using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeRichiesteRisorse:GenericEntity
    {
        public string title { get; set; }
        public string eventColor { get; set; }
        public long settoreId { get; set; }
        public string F { get; set; }
        public string OCCNL { get; set; }
        public string ORC { get; set; }
    }
}
