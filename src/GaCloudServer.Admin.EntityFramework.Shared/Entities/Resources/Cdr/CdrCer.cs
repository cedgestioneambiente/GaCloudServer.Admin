using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrCer : GenericAuditableEntity
    {
        public string Cer { get; set; }
        public string Descrizione { get; set; }
        public string Imm { get; set; }
        public bool? Pericoloso { get; set; }
        public bool? Peso { get; set; }
        public bool? Qta { get; set; }
    }
}