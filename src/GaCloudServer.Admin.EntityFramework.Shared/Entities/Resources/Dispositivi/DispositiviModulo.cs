using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi
{
    public class DispositiviModulo: GenericFileEntity
    {
        public DateTime Data { get; set; }
        public string Numero { get; set; }
        public string Note { get; set; }
        public string PersonaleDipendenteId { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }

    }
}
