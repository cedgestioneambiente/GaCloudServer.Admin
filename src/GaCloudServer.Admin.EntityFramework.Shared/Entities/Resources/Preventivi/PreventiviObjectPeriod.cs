using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectPeriod:GenericAuditableEntity
    {
        public string Descrizione { get; set; }
        public int DayValid { get; set; }

    }

}
