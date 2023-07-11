using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi
{
    public class DispositiviStock : GenericListEntity
	{
		public long DispositiviItemId { get; set; }
		public string Serial { get; set; }
		public string AltriDati { get; set; }
		public DateTime DataRegistrazione { get; set; }
		public DateTime? DataDismissione { get; set; }
		public long DispositiviCategoriaId { get; set; }
		public bool Disponibile { get; set; }

		public DispositiviItem DispositiviItem { get; set; }
		public DispositiviCategoria DispositiviCategoria { get; set; }

	}
}