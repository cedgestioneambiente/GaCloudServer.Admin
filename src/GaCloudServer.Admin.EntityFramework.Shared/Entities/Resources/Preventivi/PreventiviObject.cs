using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity.Views;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObject:GenericAuditableEntity
    {
        public string ObjectNumber { get; set; }
        public DateTime DataInserimento { get; set; }
        public string CodComune { get; set; }
        public string ClienteComune { get; set; }
        public string CodCliente { get; set; }
        public string Cliente { get; set; }
        public string ClienteIndirizzo { get; set; }
        public string ClienteCfPiva { get; set; }
        public string ClienteCodSdi { get; set; }
        public string Intestatario { get; set; }
        public string IntestatarioComune { get; set; }
        public string IntestatarioIndirizzo { get; set; }
        public string IntestatarioIndirizzoOperativo { get; set; }
        public string IntestatarioCfPiva { get; set; }
        public string IntestatarioPiva { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }

        [ForeignKey("Type")]
        public long TypeId { get; set; }
        public string TypeDesc { get; set; }
        [ForeignKey("Status")]
        public long StatusId { get; set; }
        public string AssigneeId { get; set; }
        public DateTime DataCompletamento { get; set; }
        public bool Completed { get; set; }

        public string NoteCrm { get; set; }
        public string NoteOperative { get; set; }

        public long CrmTicketId { get; set; }
        public bool FinancialLock { get; set; }
        public bool FinancialForcedLock { get; set; }
        public string FinancialLockDetail { get; set; }
        public DateTime? FinancialUnlockDate { get; set; }
        public string FinancialUnlockUserId { get; set; }
        public string FinancialUnlockUserName { get; set; }

        public DateTime? FinancialUnlockRequestDate { get; set; }
        public string? FinancialUnlockRequestUserId { get; set; }
        public string? FinancialUnlockRequestUserName { get; set; }

        public DateTime? DataScadenza { get; set; }
        public int Priority { get; set; }
        public string PriorityDesc { get; set; }

        public string IndirizzoSede { get; set; }
        public string IndirizzoFattura { get; set; }
        public bool CausalePag770s {  get; set; } 
        public bool PrintRecap { get; set; }

        //Navigation Props
        public PreventiviObjectStatus Status { get; set; }
        public PreventiviObjectType Type { get; set; }
        public ViewUserIdentity Assignee { get; set; }

    }

}
