using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende
{
    public class AziendeLista : GenericListEntity
    {
        public string DescrizioneBreve { get; set; }
        public bool ContactCenterTicket { get; set; }
    }
}