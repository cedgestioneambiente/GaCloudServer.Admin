using Skoruba.AuditLogging.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Models
{
    public class GetEventModel:AuditEvent
    {
        public string data { get; set; }
        public GetEventModel(string data)
        {
            this.data = data;
        }
    }

    public class AddEventModel : AuditEvent
    {
        public string data { get; set; }
        public AddEventModel(string data)
        {
            this.data = data;
        }
    }

    public class UpdateEventModel : AuditEvent
    {
        public string data { get; set; }
        public UpdateEventModel(string data)
        {
            this.data = data;
        }
    }

    public class DeleteEventModel : AuditEvent
    {
        public string data { get; set; }
        public DeleteEventModel(string data)
        {
            this.data = data;
        }
    }
}
