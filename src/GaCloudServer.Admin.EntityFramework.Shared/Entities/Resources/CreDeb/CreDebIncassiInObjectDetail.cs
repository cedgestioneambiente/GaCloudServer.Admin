using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.CreDeb
{
    public class CreDebIncassiInObjectDetail:GenericAuditableEntity
    {
        [ForeignKey("IdTask")]
        public long IdTask { get; set; }
        public string CodCli { get; set; }
        public string NumFat { get; set; }
        public DateTime DtFat { get; set; }
        public DateTime DtAvPag { get; set; }
        public DateTime DtReg { get; set; }
        public string ContoC { get; set; }
        public string Canale { get; set; }
        public double Incrim { get; set; }
        public string Descrizione { get; set; }
        public string Segno { get; set; }
        public string Conto { get; set; }
        public string UniqueKey { get; set; }

        public CreDebIncassiInObject Task { get; set; }

    }

}
