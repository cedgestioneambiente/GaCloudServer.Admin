using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.CreDeb
{
    public class CreDebCanale:GenericAuditableEntity
    {
        public string CodCanale { get; set; }
        public string DescCanale { get; set; }
        public string ContoNeta { get; set; }
        public bool Exclude { get; set; }

    }

}
