using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Hub.Interfaces
{
    public interface IBackgroundServicesHub
    {
        Task PresenzeRefresh(bool refresh);
        Task JoinGroup(string groupName);
        Task Subscribe(IEnumerable<string> groups);
        Task LeaveGroup(string groupName);
        Task LeaveGroups(string groups);
    }
}
