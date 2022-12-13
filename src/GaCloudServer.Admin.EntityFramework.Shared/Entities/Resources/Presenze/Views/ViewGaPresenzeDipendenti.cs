using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views
{
    public class ViewGaPresenzeDipendenti:GenericEntity
    {
		public long PersonaleDipendenteId { get; set; }
		public string UserId { get; set; }
		public string CognomeNome { get; set; }
		public string Sede { get; set; }
		public long SedeId { get; set; }
		public string Settore { get; set; }
		public long SettoreId { get; set; }
		public string Profilo { get; set; }
		public string Orario { get; set; }
		public double HhFerie { get; set; }
		public double HhPermessiCcnl { get; set; }
		public double HhRecupero { get; set; }
		public bool Enabled { get; set; }
		public string Email { get; set; }
	}
}
