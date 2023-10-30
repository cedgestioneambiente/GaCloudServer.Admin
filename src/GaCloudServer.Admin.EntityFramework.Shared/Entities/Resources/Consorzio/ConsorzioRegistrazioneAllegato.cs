using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioRegistrazioneAllegato : GenericFileAuditableEntity
    {
        public string Descrizione { get; set; }
        public long ConsorzioRegistrazioneId { get; set; }

        public ConsorzioRegistrazione ConsorzioRegistrazione { get; set; }

    }
}
