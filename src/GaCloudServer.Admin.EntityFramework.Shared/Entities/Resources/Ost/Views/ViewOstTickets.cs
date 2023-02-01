using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Ost.Views
{
    public class ViewOstTickets:GenericEntity
    {
        public int ticket_id { get; set; }
        public string number { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime? dateClosed { get; set; }
        public DateTime? dateLastUpdate { get; set; }
        public string userOpen { get; set; }
        public string userOpenEmail { get; set; }
        public string staff { get; set; }
        public string topic { get; set; }
        public string subject { get; set; }
        public string source { get; set; }
        public string name { get; set; }
        public bool isanswered { get; set; }
        public string settore { get; set; }
    }
}
