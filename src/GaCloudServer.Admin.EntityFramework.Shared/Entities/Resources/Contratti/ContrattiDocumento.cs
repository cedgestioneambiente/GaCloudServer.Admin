using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattiDocumento : GenericEntity
    {
        public long ContrattiSoggettoId { get; set; }
        public int Numero { get; set; }
        public string Descrizione { get; set; }
        public string CodiceCig { get; set; }
        public string Faldone { get; set; }
        public DateTime DataScadenza { get; set; }
        public string ContrattiModalita { get; set; }
        public string ContrattiTipologia { get; set; }
        public string Permissions { get; set; }
        public bool Archiviato { get; set; }
        public int SogliaAvviso { get; set; }

        public ContrattiSoggetto ContrattiSoggetto { get; set; }
    }
}