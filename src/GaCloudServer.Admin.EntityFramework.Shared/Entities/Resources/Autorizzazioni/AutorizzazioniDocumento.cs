using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni
{
    public class AutorizzazioniDocumento : GenericAuditableEntity
    {
        public string Numero { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public long AutorizzazioniTipoId { get; set; }
        public DateTime DataRilascio { get; set; }
        public DateTime DataScadenza { get; set; }
        public int Preavviso { get; set; }
        public bool Archiviata { get; set; }

        public AutorizzazioniTipo AutorizzazioniTipo { get; set; }
    }
}
