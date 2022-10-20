using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleDipendente : GenericEntity

    {
		public string UserId { get; set; }
		public long GlobalSedeId { get; set; }
		public long GlobalCentroCostoId { get; set; }
		public long PersonaleQualificaId { get; set; }
		public long PersonaleAssunzioneId { get; set; }
		public DateTime? DataScadenza { get; set; }
		public string Preposto { get; set; }

		public GlobalSede GlobalSede { get; set; }
		public GlobalCentroCosto GlobalCentroCosto { get; set; }
		public PersonaleQualifica PersonaleQualifica { get; set; }
		public PersonaleAssunzione PersonaleAssunzione { get; set; }
	}
}
