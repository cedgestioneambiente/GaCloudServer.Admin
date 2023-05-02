using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views
{
    public class ViewGaCsrRegistrazioni : GenericEntity
    {
        public DateTime Data { get; set; }
        public string Comune { get; set; }
        public string CodiceCer { get; set; }
        public string Trasportatore { get; set; }
        public int PesoTotale { get; set; }
        public string Destinatario { get; set; }
        public string Modalita { get; set; }
    }
}
