using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Mappers.Notification
{
    internal class NotificationMapperProfile : Profile
    {
        public NotificationMapperProfile()
        {
            CreateMap<NotificationApp, NotificationAppDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<NotificationApp>, NotificationAppsDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<NotificationRoleOnApp, NotificationRoleOnAppDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<NotificationRoleOnApp>, NotificationRolesOnAppsDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<NotificationUserOnApp, NotificationUserOnAppDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<NotificationUserOnApp>, NotificationRolesOnAppsDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<NotificationEvent, NotificationEventDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<NotificationEvent>, NotificationEventsDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}
