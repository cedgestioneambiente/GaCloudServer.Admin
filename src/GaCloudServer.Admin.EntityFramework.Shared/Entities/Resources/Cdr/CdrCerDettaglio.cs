using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrCerDettaglio : GenericEntity
    {
        public long CdrCerId { get; set; }
        public string Descrizione { get; set; }
        public int PesoDefault { get; set; }

        public CdrCer CdrCer { get; set; }
    }
}