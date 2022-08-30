using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrCerDettaglio : GenericEntity
    {
        public long Id { get; set; }
        public long CdrCerId { get; set; }
        public string Descrizione { get; set; }
        public int PesoDefault { get; set; }
        public bool Disabled { get; set; }

        public CdrCer CdrCer { get; set; }
    }
}