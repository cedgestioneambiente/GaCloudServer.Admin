using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrConferimento : GenericEntity
    {
        public string UserId { get; set; }
        public DateTime Data { get; set; }
        public string CfPiva { get; set; }
        public bool Anagrafica { get; set; }
        public bool Ditta { get; set; }
        public long CdrCentroId { get; set; }
        public string CdrComuneId { get; set; }
        public long CdrCerId { get; set; }
        public long CdrCerDettaglioId { get; set; }
        public double Peso { get; set; }
        public int Quantita { get; set; }
        public string Targa { get; set; }
        public string Note { get; set; }
        public string CdrUtenteId { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public bool Noleggio { get; set; }

        public CdrCentro CdrCentro { get; set; }
        public CdrCer CdrCer { get; set; }
        public CdrCerDettaglio CdrCerDettaglio { get; set; }
    }
}
