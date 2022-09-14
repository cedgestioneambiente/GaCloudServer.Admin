using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi
{
    public class MezziDocumento:GenericFileEntity
    {
        public string Descrizione { get; set; }
        public long MezziVeicoloId { get; set; }

        public MezziVeicolo MezziVeicolo { get; set; }
    }
}
