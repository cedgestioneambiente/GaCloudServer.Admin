using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni
{
    public class SegnalazioniDocumentoImmagine : GenericFileAuditableEntity
    {
        public long SegnalazioniDocumentoId { get; set; }

        public SegnalazioniDocumento SegnalazioniDocumento { get; set; }
    }
}
