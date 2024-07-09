using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common
{
    public class BankAccount:GenericAuditableEntity
    {
        public string Descrizione { get; set; }
        public string RagioneSociale { get; set; }
        public string Iban {  get; set; }
        public bool IsPersonal { get; set; }
    }
}
