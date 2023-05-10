using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeRichiesteQualificheEventi:GenericEntity
    {
        public string resourceId { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public long settoreId { get; set; }
        public long qualificaId { get; set; }
        public long eventId { get; set; }
    }
}
