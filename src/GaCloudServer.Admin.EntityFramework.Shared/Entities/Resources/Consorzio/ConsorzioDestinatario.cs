using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioDestinatario : GenericListEntity
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }

        public ConsorzioComune ConsorzioComune { get; set; }
    }
}
