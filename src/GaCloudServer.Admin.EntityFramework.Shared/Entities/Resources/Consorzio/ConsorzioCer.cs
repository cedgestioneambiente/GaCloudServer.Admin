using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioCer : GenericListAuditableEntity
    {
        public string Codice { get; set; }
        public bool Pericoloso { get; set; }
        public string Immagine { get; set; }
        public string CodiceRaggruppamento { get; set; }
        public bool Conteggio { get; set; }
    }
}
