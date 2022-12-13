using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views
{
    public class ViewGaPersonaleDipendenti:GenericEntity
    {
        public string UserId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CognomeNome { get; set; }
        public string Sede { get; set; }
        public long SedeId { get; set; }
        public string Qualifica { get; set; }
        public long QualificaId { get; set; }
        public string Email { get; set; }
    }
}
