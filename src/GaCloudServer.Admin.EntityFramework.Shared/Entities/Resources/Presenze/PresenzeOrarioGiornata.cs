using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze
{
    public class PresenzeOrarioGiornata : GenericEntity
    {
        public long PresenzeOrarioId { get; set; }
        public int Giorno { get; set; }
        public DateTime OraInizio { get; set; }
        public DateTime OraFine { get; set; }
        public DateTime? PausaInizio { get; set; }
        public DateTime? PausaFine { get; set; }

        public PresenzeOrario PresenzeOrario { get; set; }
    }
}
