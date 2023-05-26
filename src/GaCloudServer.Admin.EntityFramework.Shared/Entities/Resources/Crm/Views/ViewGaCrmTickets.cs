using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views
{
    public class ViewGaCrmTickets : GenericEntity
    {
        public string Prefix { get; set; }
        public DateTime? DataIns { get; set; }
        public DateTime? DataAnnullamento { get; set; }
        public int? OriginIns { get; set; }
        public string OriginInsDesc { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Rappresenta { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string NotaAnagrafica { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string Pec { get; set; }
        public int? CanaleRisposta { get; set; }
        public int? Stato { get; set; }
        public string StatoDesc { get; set; }
        public DateTime? DataStato { get; set; }
        public int? CodUte { get; set; }
        public string CodUteDesc { get; set; }
        public int? CodUteWork { get; set; }
        public string CodUteWorkDesc { get; set; }
        public int? TotalMinutiWork { get; set; }
        public DateTime? DtScad { get; set; }
        public int? CodCausale { get; set; }
        public string CodCausaleDesc { get; set; }
        public DateTime? DtUlag { get; set; }
        public int? Type { get; set; }
        public string TypeDesc { get; set; }
        public string Indirizzo { get; set; }
        public string CodPers { get; set; }
        public string CodCom { get; set; }
        public string Citta { get; set; }
        public string NumCiv { get; set; }
        public string CodFis { get; set; }
        public string Domest { get; set; }
        public string CodVia { get; set; }
        public string Trasmesso { get; set; }
        public DateTime? OraTrasm { get; set; }
        public string AutoClose { get; set; }
        public int? CpRowNum { get; set; }
        public long? Duration { get; set; }

    }
}
