using GaCloudServer.Jobs.Configuration.Configuration;
using Skoruba.AuditLogging.Events;

namespace GaCloudServer.Jobs.Configuration.AuditLogging
{
    public class ApiAuditSubject : IAuditSubject
    {
        public ApiAuditSubject(IHttpContextAccessor accessor, AuditLoggingConfiguration auditLoggingConfiguration)
        {
            SubjectIdentifier = "scheduler";// subClaim == null ? clientIdClaim.Value : subClaim.Value;
            SubjectName = "schedulerUser";// subClaim == null ? clientIdClaim.Value : nameClaim?.Value;
            SubjectType = "";// subClaim == null ? AuditSubjectTypes.Machine : AuditSubjectTypes.User;

            SubjectAdditionalData = new
            {
                RemoteIpAddress = "0.0.0.0",//accessor.HttpContext.Connection?.RemoteIpAddress?.ToString(),
                LocalIpAddress = "0.0.0.0",//accessor.HttpContext.Connection?.LocalIpAddress?.ToString(),
                Claims = "guest"
            };
        }

        public string SubjectName { get; set; }

        public string SubjectType { get; set; }

        public object SubjectAdditionalData { get; set; }

        public string SubjectIdentifier { get; set; }
    }
}






