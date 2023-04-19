using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using GaCloudServer.BusinnessLogic.Hub.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace GaCloudServer.BusinnessLogic.Hub
{
    public class BackgroundServicesHub: Hub<IBackgroundServicesHub>
    {
        private readonly IHubContext<BackgroundServicesHub, IBackgroundServicesHub> _hubContext;

        public BackgroundServicesHub(IHubContext<BackgroundServicesHub, IBackgroundServicesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task JoinGroup(string groupName)
        {
            await _hubContext.Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task Subscribe(IEnumerable<string> groups)
        {
            foreach (var group in groups)
            {
                await _hubContext.Groups.AddToGroupAsync(Context.ConnectionId, group);
            }
            
        }

        public async Task LeaveGroup(string groupName)
        {
            await _hubContext.Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroups(string groups)
        {
            var gropList = groups.Split(",");

            foreach (var itm in gropList)
            {
                await _hubContext.Groups.RemoveFromGroupAsync(Context.ConnectionId, itm);
            }

        }

    }
}
