using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views
{
    public class ViewGaCdrRichiesteViaggi : GenericEntity
    {
        public long Numero { get; set; }
        public DateTime Data { get; set; }
        public string Richiedente { get; set; }
        public long CentroId { get; set; }
        public string Centro { get; set; }
        public string Cer { get; set; }
        public string Imm { get; set; }
        public double PesoPresunto { get; set; }
        public double PesoDestino { get; set; }
        public DateTime? DataChiusura { get; set; }
        public long StatoRichiestaId { get; set; }
        public string StatoRichiesta { get; set; }
        public string Note { get; set; }
        public bool Inviata { get; set; }
        public string UserId { get; set; }
    }
}
