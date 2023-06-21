using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm
{
    public class CrmEventDevice : GenericEntity
    {
        public long CrmEventId { get; set; }
        public int CrmTicketId { get; set; }
        public string Identi1 { get; set; }
        public string Identi2 { get; set; }
        public string TipCon { get; set; }
        public string DesCon { get; set; }
        public string DtCon { get; set; }
        public string DtRit { get; set; }
        public bool Selected { get; set; }
        public bool Completed { get; set; }
        public bool SostLuch { get; set; }
        

        public CrmEvent CrmEvent { get; set; }
    }
}
