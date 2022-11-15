using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec
{
    public class EcSegnalazioniAllegato : GenericFileEntity
    {
        public long SegnalazioniDocumentoId { get; set; }

        public EcSegnalazioniDocumento SegnalazioniDocumento { get; set; }
    }
}
