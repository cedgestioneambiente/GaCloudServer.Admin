using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattoUtenteOnPermesso : GenericEntity
    {
        public long Id { get; set; }
        public string UtenteId { get; set; }
        public long ContrattoPermessoId { get; set; }
        public bool Disabled { get; set; }

        public ContrattoPermesso ContrattoPermesso { get; set; }
    }
}