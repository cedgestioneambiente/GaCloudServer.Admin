using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views
{
    public class ViewConsorzioTrasportatori : GenericListEntity
    {
        public string Comune { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }
        public string IndirizzoEsteso { get; set; }
        public long? ConsorzioInternalId { get; set; }

    }
}
