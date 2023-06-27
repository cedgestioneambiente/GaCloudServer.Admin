using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioRegistrazione : GenericEntity
    {
        public string UserId { get; set; }
        public string Roles { get; set; }
        public double PesoTotale { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public long ConsorzioOperazioneId { get; set; }
        public long ConsorzioCerId { get; set; }
        public long ConsorzioProduttoreId { get; set; }
        public long ConsorzioTrasportatoreId { get; set; }
        public long ConsorzioDestinatarioId { get; set; }
        public long ConsorzioPeriodoId { get; set; }
        public string Note { get; set; }
        public string ConsorzioImportTaskId { get; set; }
        public string ImportRecordId { get; set; }


        public ConsorzioCer ConsorzioCer { get; set; }
        public ConsorzioOperazione ConsorzioOperazione { get; set; }
        public ConsorzioProduttore ConsorzioProduttore { get; set; }
        public ConsorzioTrasportatore ConsorzioTrasportatore { get; set; }
        public ConsorzioDestinatario ConsorzioDestinatario { get; set; }
        public ConsorzioPeriodo ConsorzioPeriodo { get; set; }
    }
}
