using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views
{
    public class ViewGaReclamiAzioni : GenericEntity
    {
        public long ReclamiDocumentoId { get; set; }
        public string DescrizioneAzione { get; set; }
        public DateTime Data { get; set; }
        public string TipoAzione { get; set; }
        public string Note { get; set; }
        public bool Risposta { get; set; }
        public DateTime? RispostaDefinitiva { get; set; }
    }
}
