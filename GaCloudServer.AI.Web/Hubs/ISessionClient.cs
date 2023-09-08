using GaCloudServer.AI.Core.Models;
using GaCloudServer.AI.Web.Common;

namespace GaCloudServer.AI.Web.Hubs
{
    public interface ISessionClient
    {
        Task OnStatus(string connectionId, SessionConnectionStatus status);
        Task OnResponse(InferTokenModel token);
        Task OnError(string error);
    }
}
