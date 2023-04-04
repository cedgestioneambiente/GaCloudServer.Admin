using System;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattiDocumentoAllegato : GenericFileEntity
    {
        public long ContrattiDocumentoId { get; set; }
        public string Descrizione { get; set; }

        public ContrattiDocumento ContrattiDocumento { get; set; }
    }
}