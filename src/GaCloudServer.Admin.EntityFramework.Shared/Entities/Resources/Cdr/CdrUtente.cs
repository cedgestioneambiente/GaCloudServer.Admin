using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr
{
    public class CdrUtente : GenericEntity
    {
        public string RagioneSociale { get; set; }
        public string CfPiva { get; set; }
        public long CdrComuneId { get; set; }
        public string Indirizzo { get; set; }
        public bool Ditta { get; set; }
        public bool InserimentoUtente { get; set; }
        public bool Approvato { get; set; }

        public CdrComune CdrComune { get; set; }
    }
}
