using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeRichiestaMail:GenericEntity
    {
        public string UserId { get; set; }
        public string Richiedente { get; set; }
        public string RichiedenteEmail { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public long StatoId { get; set; }
        public string Stato { get; set; }
        public long TipoId { get; set; }
        public string Tipo { get; set; }
        public long SettoreId { get; set; }
        public string Settore { get; set; }
    }
}
