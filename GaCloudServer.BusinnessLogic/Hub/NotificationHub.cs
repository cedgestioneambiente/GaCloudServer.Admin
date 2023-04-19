using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using GaCloudServer.BusinnessLogic.Hub.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace GaCloudServer.BusinnessLogic.Hub
{
    public class NotificationHub: Hub<INotificationHub>
    {
        private readonly IHubContext<NotificationHub, INotificationHub> _hubContext;

        public NotificationHub(IHubContext<NotificationHub, INotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessage(NotificationEventDto dto)
        {
            await Clients.All.SendMessage(dto);
        }

        public Task SubscribeToUserNotification(string userId)
        {
            return _hubContext.Groups.AddToGroupAsync(Context.ConnectionId, userId);
        
        }

        public async Task JoinGroup(string groupName)
        {
            await _hubContext.Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await _hubContext.Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

    }
}
