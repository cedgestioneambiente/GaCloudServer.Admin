using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views
{
    public class ViewConsorzioRegistrazioni : GenericEntity
    {
        public string UserId { get; set; }
        public string Roles { get; set; }
        public float PesoTotale { get; set; }
        public string Operazione { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public string Cer { get; set; }
        public string Produttore { get; set; }
        public long ProduttoreId { get; set; }
        public string Trasportatore { get; set; }
        public string Destinatario { get; set; }
        public string Nominativo { get; set; }

    }
}
