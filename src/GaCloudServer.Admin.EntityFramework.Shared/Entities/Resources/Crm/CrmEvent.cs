using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmEvent : GenericEntity
    {
        public string CodAzi { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string CpRowNum { get; set; }
        public DateTime DateSchedule { get; set; }
        public string RagSo { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string Pec { get; set; }
        public string Tipo { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public string NumCiv { get; set; }
        public bool Domest { get; set; }
        public long CrmEventStateId { get; set; }
        public long CrmEventAreaId { get; set; }
        public int CrmTicketId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string NotaAnagrafica { get; set; }
        public bool Sended { get; set; }
        public string NotaOperatore { get; set; }
        public DateTime? DataCessazione { get; set; }

        public CrmEventState CrmEventState { get; set; }
        public CrmEventArea CrmEventArea { get; set; }
    }
}
