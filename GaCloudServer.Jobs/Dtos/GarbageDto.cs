
using Duende.IdentityServer.Validation;

namespace GaCloudServer.Jobs.Dtos.Garbage
{


    public class GarbageUtenzaDto
    {
        public string CODICE_COMUNE { get; set; }
        public string CODICE_CONTRATTO { get; set; }
        public string COD_CLI { get; set; }
        public string CODICE_FISCALE { get; set; }
        public string PARTITA_IVA { get; set; }
        public string TIPO_PERSONA { get; set; }
        public string RagSo1 { get; set; }
        public string COGNOME_RAGIONE_SOCIALE { get; set; }
        public string NOME { get; set; }
        public string VIA { get; set; }
        public string NUMERO_CIVICO { get; set; }
        public string BARRATO { get; set; }
        public string SCALA { get; set; }
        public string PIANO { get; set; }
        public string INTERNO { get; set; }
        public string CAP { get; set; }
        public string CITTA { get; set; }
        public string PROVINCIA { get; set; }
        public string CODICE_ZONA { get; set; }
        public string DESCRIZIONE_ZONA { get; set; }

    }

    public class GarbagePartitaDto
    {
        public string CODCIE_COMUNE { get; set; }
        public string CODICE_CONTRATTO { get; set; }
        public string CODICE_PARTITA { get; set; }
        public string COMUNE { get; set; }
        public string VIA { get; set; }
        public string NUMERO_CIVICO { get; set; }
        public string BARRATO { get; set; }
        public string SCALA { get; set; }
        public string PIANO { get; set; }
        public string INTERNO { get; set; }
        private string superficie;
        public string SUPERFICIE { get { return superficie; } set { superficie = value.Replace(",", "."); } }
        private string superficie_fissa;
        public string SUPERFICIE_FISSA { get { return superficie_fissa; } set { superficie_fissa = value.Replace(",", "."); } }
        public string TIPO_UTENZA { get; set; }
        public string CODECE_CATEGORIA_UTENZA { get; set; }
        public string DESCRIZIONE_CATEGORIA_UTENZA { get; set; }
        public string NUMERO_COMPONENTI { get; set; }
        public string DATA_INIZIO { get; set; }
        public string DATA_FINE_PERIODO { get; set; }
        public string DATA_FINE_UTENZA { get; set; }
        public string PROGRESSIVO_VARIAZIONE { get; set; }
        public string CESSATO { get; set; }
        public string CODICE_ZONA { get; set; }
    }

    public class GarbageTipologiaDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public string CodArera { get; set; }
    }

    public class GarbageProvenienzaDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
    }

    public class GarbageStatoDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
    }

    public class GarbageTicketContactCenterDto
    {
        public string NUMERO_TICKET { get; set; }
        public DateTime DATA_RICHIESTA { get; set; }
        public DateTime? DATA_CHIUSURA { get; set; }
        public string COD_COMUNE { get; set; }
        public string COD_UTENZA { get; set; }
        public string TRIBUTO { get; set; }
        public string VIA { get; set; }
        public string CIVICO { get; set; }
        public string ZONA { get; set; }
        public long COD_PROVENIENZA_RICHIESTA { get; set; }
        public long COD_TIPO_RICHIESTA { get; set; }
        public string TELEFONO { get; set; }
        public string CELLULARE { get; set; }
        public string EMAIL { get; set; }
        public string EMAIL_PEC { get; set; }
        public string NOTE_TICKET { get; set; }
        public string NOTE_CHIUSURA { get; set; }
        public long COD_STATO_RICHIESTA { get; set; }
        public string CREATO_DA { get; set; }
        public string ASSEGNATO_A { get; set; }
    }

    public class GarbageTicketMagazzinoDto
    {
        public string NUMERO_TICKET { get; set; }
        public DateTime DATA_RICHIESTA { get; set; }
        public DateTime? DATA_CHIUSURA { get; set; }
        public long COD_COMUNE { get; set; }
        public string COD_UTENZA { get; set; }
        public string TRIBUTO { get; set; }
        public string VIA { get; set; }
        public string CIVICO { get; set; }
        public string ZONA { get; set; }
        public long COD_PROVENIENZA_RICHIESTA { get; set; }
        public long COD_TIPO_RICHIESTA { get; set; }
        public string TELEFONO { get; set; }
        public string CELLULARE { get; set; }
        public string EMAIL { get; set; }
        public string EMAIL_PEC { get; set; }
        public string NOTE_TICKET { get; set; }
        public string NOTE_CHIUSURA { get; set; }
        public long COD_STATO_RICHIESTA { get; set; }
        public string CREATO_DA { get; set; }
        public string ASSEGNATO_A { get; set; }
    }

}
