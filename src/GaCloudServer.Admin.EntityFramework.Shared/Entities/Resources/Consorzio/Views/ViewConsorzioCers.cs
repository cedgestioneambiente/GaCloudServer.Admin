using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views
{
    public class ViewConsorzioCers : GenericListEntity
    {
        public string Codice { get; set; }
        public bool Pericoloso { get; set; }
        public string Immagine { get; set; }
        public string CodiceRaggruppamento { get; set; }
        public string DescrizioneEstesa { get; set; }
        public bool Conteggio { get; set; }

    }
}
