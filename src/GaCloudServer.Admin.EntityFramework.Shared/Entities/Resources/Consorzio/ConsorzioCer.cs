using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioCer : GenericListEntity
    {
        public string Codice { get; set; }
        public bool Pericoloso { get; set; }
        public string Immagine { get; set; }
        public string CodiceRaggruppamento { get; set; }
        public long ConsorzioCerSmaltimentoId { get; set; }

        public ConsorzioCerSmaltimento ConsorzioCerSmaltimento { get; set; }
    }
}
