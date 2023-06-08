using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioOperazione : GenericListEntity
    {
        public long ConsorzioSmaltimentoId { get; set; }

        public ConsorzioSmaltimento ConsorzioSmaltimento { get; set; }
    }
}
