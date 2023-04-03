using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class ContrattiDocumento : GenericFileEntity
    {
        public long ContrattiSoggettoId { get; set; }
        public int Numero { get; set; }
        public string Descrizione { get; set; }
        public string CodiceCig { get; set; }
        public string Faldone { get; set; }
        public DateTime DataScadenza { get; set; }
        public long ContrattiModalitaId { get; set; }
        public bool Direzione { get; set; }
        public bool Contabilita { get; set; }
        public bool Personale { get; set; }
        public bool Informatica { get; set; }
        public bool Tecnico { get; set; }
        public bool QualitaSicurezza { get; set; }
        public bool Commerciale { get; set; }
        public bool AffariGenerali { get; set; }
        public bool Archiviato { get; set; }
        public string Permissions { get; set; }
        public long? ContrattiPreventivoId { get; set; }
        public string PreventivoNumero { get; set; }
        public long ContrattiTipologiaId { get; set; }
        public int SogliaAvviso { get; set; }
        public bool Comunicazione { get; set; }

        public ContrattiSoggetto ContrattiSoggetto { get; set; }
        public ContrattiModalita ContrattiModalita { get; set; }
        public ContrattiTipologia ContrattiTipologia { get; set; }
    }
}