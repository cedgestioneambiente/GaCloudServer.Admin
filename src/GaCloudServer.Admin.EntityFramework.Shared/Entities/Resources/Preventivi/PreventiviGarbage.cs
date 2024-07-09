using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviGarbage:GenericAuditableEntity
    {
        public string Descrizione { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public bool Dangerous { get; set; }
        public bool Analysis { get; set; }
    }

}
