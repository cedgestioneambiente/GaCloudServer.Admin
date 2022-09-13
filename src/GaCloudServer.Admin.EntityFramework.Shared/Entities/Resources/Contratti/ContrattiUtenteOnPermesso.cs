using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattiUtenteOnPermesso : GenericEntity
    {
        public string UtenteId { get; set; }
        public long ContrattiPermessoId { get; set; }

        public ContrattiPermesso ContrattiPermesso { get; set; }
    }
}