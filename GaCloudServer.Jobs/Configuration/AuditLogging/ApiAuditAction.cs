using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Skoruba.AuditLogging.Events;

namespace GaCloudServer.Jobs.Configuration.AuditLogging
{
    public class ApiAuditAction : IAuditAction
    {
        public ApiAuditAction(IHttpContextAccessor accessor)
        {
            Action = new
            {
                TraceIdentifier = "null",// accessor.HttpContext.TraceIdentifier,
                RequestUrl = "null",// accessor.HttpContext.Request.GetDisplayUrl(),
                HttpMethod = "null",//accessor.HttpContext.Request.Method
            };
        }

        public object Action { get; set; }
    }
}





