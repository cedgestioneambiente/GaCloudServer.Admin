using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Hub.Interfaces
{
    public interface INotificationHub
    {
        Task SendMessage(NotificationEventDto notification);
        Task SendNotification(NotificationEventDto dto);
        Task JoinGroup(string groupName);
        Task LeaveGroup(string groupName);
    }
}
