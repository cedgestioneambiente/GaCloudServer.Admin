using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni
{
    public class AutorizzazioniAllegato : GenericFileEntity
    {
        public long AutorizzazioniDocumentoId { get; set; }
        public string Descrizione { get; set; }

        public AutorizzazioniDocumento AutorizzazioniDocumento { get; set; }
    }
}
