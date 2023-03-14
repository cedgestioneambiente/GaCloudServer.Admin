using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class WidgetGaPresenzeSchedule : GenericEntity
    {
		public string Personale { get; set; }
		public DateTime DataInizio { get; set; }
		public DateTime DataFine { get; set; }
		public bool Oggi { get; set; }
		public bool Domani { get; set; }
		public string Settore { get; set; }
		public long TipoOreId { get; set; }
		public string TipoOre { get; set;}
		
	}
}
