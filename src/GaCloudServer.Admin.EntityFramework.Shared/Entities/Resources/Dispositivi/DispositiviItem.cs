using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi
{
	public class DispositiviItem : GenericListEntity
	{
		public long DispositiviTipologiaId { get; set; }
		public long DispositiviMarcaId { get; set; }
		public long DispositiviModelloId { get; set; }
		public long DispositiviClasseId { get; set; }

		public DispositiviMarca DispositiviMarca { get; set; }
		public DispositiviModello DispositiviModello { get; set; }
		public DispositiviTipologia DispositiviTipologia { get; set; }
		public DispositiviClasse DispositiviClasse { get; set; }


	}
}
