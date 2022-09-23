using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattiUtenteOnPermesso : GenericEntity
    {
        public string UtenteId { get; set; }
        public long ContrattiPermessoId { get; set; }

        public ContrattiPermesso ContrattiPermesso { get; set; }
    }
}