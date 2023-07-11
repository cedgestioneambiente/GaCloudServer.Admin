using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi
{
    public class DispositiviOnModulo : GenericEntity
	{
		public long DispositiviModuloId { get; set; }
		public long DispositiviOnDipendenteId { get; set; }

		public DispositiviModulo DispositiviModulo { get; set; }
		public DispositiviOnDipendente DispositiviOnDipendente { get; set; }

	}
}