using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec
{
    public class EcSegnalazioniDocumentoImmagine : GenericFileEntity
    {
        public long SegnalazioniDocumentoId { get; set; }

        public EcSegnalazioniDocumento SegnalazioniDocumento { get; set; }
    }
}
