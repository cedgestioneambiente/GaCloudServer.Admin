using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviIsmartDocumento:GenericAuditableEntity
    {
        public string Codcli { get; set; }
        public int Prgfat { get; set; }
        public string IdDocumento { get; set; }

        public string Numfat { get; set; }
        public string Codsez { get; set; }
        public DateTime Dtfat { get; set; }
        public long? PreventiviObjectId { get; set; }
        public string Numprev { get; set; }
        public string Ragsoc { get; set; }

        public decimal? Pagato { get; set; }
        public DateTime? DataPagamento { get; set; }

        public bool EmailInviata { get; set; } = false;
        public bool Gestito { get; set; } = false;

        public DateTime DataInserimento { get; set; } = DateTime.UtcNow;
        public DateTime? DataGestione { get; set; }
    }

}
