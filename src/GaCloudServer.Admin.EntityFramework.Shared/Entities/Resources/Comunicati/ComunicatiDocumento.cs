using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati
{
    public class ComunicatiDocumento:GenericFileEntity
    {
        public DateTime DataDocumento { get; set; }
        public string Numero { get; set; }
        public string Titolo { get; set; }
    }
}
