using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrCer : IGenericEntity
    {
        public long Id { get; set; }
        public string Cer { get; set; }
        public string Descrizione { get; set; }
        public string Imm { get; set; }
        public bool Pericoloso { get; set; }
        public bool Peso { get; set; }
        public bool Qta { get; set; }
        public bool Disabled { get; set; }
    }
}