using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views
{
    public class ViewGaCsrExports : GenericEntity
    {
        public long ComuneId { get; set; }
        public int MeseId { get; set; }
        public string Mese { get; set; }
        public DateTime Data { get; set; }
        public string Cdr { get; set; }
        public int AnnoId { get; set; }
        public string Cer { get; set; }
        public string Modalita { get; set; }
        public string Produttore { get; set; }
        public string Destinatario { get; set; }
        public string DestinatarioIndirizzo { get; set; }
        public string Trasportatore { get; set; }
        public string TrasportatoreIndirizzo { get; set; }
        public double PesoTotale { get; set; }
    }
}
