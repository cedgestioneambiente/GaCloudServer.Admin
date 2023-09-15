using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views
{
    public class ViewGaCrmGarbagePartite:GenericEntity
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
        public decimal? SUPERFICIE { get; set; }
        public decimal? SUPERFICIE_FISSA { get; set; }
        public string TIPO_UTENZA { get; set; }
        public string CODECE_CATEGORIA_UTENZA { get; set; }
        public string DESCRIZIONE_CATEGORIA_UTENZA { get; set; }
        public int? NUMERO_COMPONENTI { get; set; }
        public string DATA_INIZIO { get; set; }
        public string DATA_FINE_PERIODO { get; set; }
        public string DATA_FINE_UTENZA { get; set; }
        public int? PROGRESSIVO_VARIAZIONE { get; set; }
        public string CESSATO { get; set; }
        public string CODICE_ZONA { get; set; }

    }
}
