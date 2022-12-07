using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeRichieste:GenericEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; }
        public long SettoreId { get; set; }
        public string Settore { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
    }
}
