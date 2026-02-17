using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Quicklinks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using GaCloudServer.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Shortcuts
{
    internal class ShortcutsMapperProfile : Profile
    {
        public ShortcutsMapperProfile()
        {
            //ShortcutLinks
            CreateMap<ShortcutLink, ShortcutLinkDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PageResponse<ShortcutLink>, PageResponse<ShortcutLinkDto>>(MemberList.Destination)
                .ReverseMap();

            //ShortcutItems
            CreateMap<ShortcutItem, ShortcutItemDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PageResponse<ShortcutItem>, PageResponse<ShortcutItemDto>>(MemberList.Destination)
                .ReverseMap();

            // QuickLinks
            CreateMap<QuickLink, QuickLinkDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PageResponse<QuickLink>, PageResponse<QuickLinkDto>>(MemberList.Destination)
                .ReverseMap();
        }
    }
}


