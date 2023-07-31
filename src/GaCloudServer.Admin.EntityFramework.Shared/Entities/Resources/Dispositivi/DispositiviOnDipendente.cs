using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi
{
	public class DispositiviOnDipendente : GenericEntity
	{
		public long DispositiviStockId { get; set; }
		public long PersonaleDipendenteId { get; set; }
		public DateTime DataConsegna { get; set; }
		public DateTime? DataRitiro { get; set; }

		public DispositiviStock DispositiviStock { get; set; }
		public PersonaleDipendente PersonaleDipendente { get; set; }

	}
}