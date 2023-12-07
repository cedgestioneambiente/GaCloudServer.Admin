using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio
{
    public class PrevisioAnomaliaLettura : GenericAuditableEntity
    {
        public string NoteSegnalazione { get; set; }
        public string NoteGestione { get; set; }
        public bool Gestito { get; set; }
        public string Evento { get; set; }
        public string Matricola { get; set; }
        public string Tag { get; set; }
        public string TipoCont { get; set; }
        public string Contratto { get; set; }
        public string Partita { get; set; }
        public string Utenza { get; set; }
        public string Comune { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataEvento { get; set; }
        public double Longitudine { get; set; }
        public double Latitudine { get; set; }
    } 
}
