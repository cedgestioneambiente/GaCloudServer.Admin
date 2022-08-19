using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattoServizio : IGenericEntity
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }
    }
}