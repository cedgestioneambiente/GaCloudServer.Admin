using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Notifiation;
using GaCloudServer.Resources.Dtos.Resources.Notification;

namespace GaCloudServer.Resources.Api.Mappers.Notification
{
    internal class NotificationMapperProfile : Profile
    {
        public NotificationMapperProfile()
        {
            CreateMap<NotificationAppDto, NotificationAppApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<NotificationAppsDto, NotificationAppsApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<NotificationRoleOnAppDto, NotificationRoleOnAppApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<NotificationRolesOnAppsDto, NotificationRolesOnAppsApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<NotificationUserOnAppDto, NotificationUserOnAppApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<NotificationUsersOnAppsDto, NotificationRolesOnAppsApiDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}
