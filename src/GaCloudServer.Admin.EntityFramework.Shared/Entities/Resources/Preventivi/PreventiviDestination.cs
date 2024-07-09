using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviDestination:GenericAuditableEntity
    {
        public string Descrizione { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Ignore { get; set; }
    }

}
