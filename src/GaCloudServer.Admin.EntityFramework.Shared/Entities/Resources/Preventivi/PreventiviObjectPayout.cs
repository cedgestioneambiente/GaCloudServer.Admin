using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi
{
    public class PreventiviObjectPayout:GenericAuditableEntity
    {
        [ForeignKey("Object")]
        public long ObjectId { get; set; }
        [ForeignKey("PaymentTerm")]
        public long PaymentTermId { get; set; }
        public string Descrizione { get; set; }
        public DateTime DateValid { get; set; }
        public string Notes { get; set; }
        [ForeignKey("BankAccount")]
        public long BankAccountId { get; set; }
        [ForeignKey("Period")]
        public long PeriodId { get; set; }
        public double Deposit { get; set; }
        public string Note { get; set; }

        //Navigation props
        public PreventiviObjectPeriod Period { get; set; }
        public PreventiviObject Object { get; set; }
        public BankAccount BankAccount { get; set; }
        public PreventiviPaymentTerm PaymentTerm { get; set; }
    }

}
