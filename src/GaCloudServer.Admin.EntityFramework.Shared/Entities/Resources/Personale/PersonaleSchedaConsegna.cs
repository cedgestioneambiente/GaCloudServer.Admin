using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleSchedaConsegna : GenericFileEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public DateTime Data { get; set; }
        public string Numero { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
    }
}
