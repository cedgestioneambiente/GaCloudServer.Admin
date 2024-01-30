using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviAnticipoAllegato : GenericFileAuditableEntity
    {
        public string Descrizione { get; set; }
        public long PreventiviAnticipoId { get; set; }


        public PreventiviAnticipo PreventiviAnticipo { get; set; }

    }
}
