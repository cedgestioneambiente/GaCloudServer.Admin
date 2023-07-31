using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi
{
    public class DispositiviModulo: GenericFileEntity
    {
        public DateTime Data { get; set; }
        public string Numero { get; set; }
        public string Note { get; set; }
        public long PersonaleDipendenteId { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
    }
}
