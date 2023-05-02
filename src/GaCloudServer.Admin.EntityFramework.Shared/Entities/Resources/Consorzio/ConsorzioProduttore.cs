using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioProduttore : GenericListEntity
    {
        public long ConsorzioComuneId { get; set; }
        public string Indirizzo { get; set; }
        public string CdPiva { get; set; }

        public ConsorzioComune ConsorzioComune { get; set; }
    }
}
