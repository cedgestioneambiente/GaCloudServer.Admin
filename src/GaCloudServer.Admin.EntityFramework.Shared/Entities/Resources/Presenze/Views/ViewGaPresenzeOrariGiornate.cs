using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeOrariGiornate:GenericEntity
    {
		public long PresenzeOrarioId { get; set; }
		public string GiornoDescrizione { get; set; }
		public DateTime OraInizio { get; set; }
		public DateTime OraFine { get; set; }
		public DateTime PausaInizio { get; set; }
		public DateTime PausaFine { get; set; }
	}
}
