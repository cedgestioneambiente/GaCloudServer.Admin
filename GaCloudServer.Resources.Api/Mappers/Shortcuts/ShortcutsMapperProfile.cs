using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using GaCloudServer.Resources.Api.Dtos.Resources.Shortcuts;

namespace GaCloudServer.Resources.Api.Mappers.Shortcuts
{
    public class ShortcutsMapperProfile:Profile
    {
        public ShortcutsMapperProfile() {
            //ShortcutLinks
            CreateMap<ShortcutLinkDto, ShortcutLinkApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ShortcutLinksDto, ShortcutLinksApiDto>(MemberList.Destination)
                .ReverseMap();

            //ShortcutItems
            CreateMap<ShortcutItemDto, ShortcutItemApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ShortcutItemsDto, ShortcutItemsApiDto>(MemberList.Destination)
                .ReverseMap();

            // QuickLinks
            CreateMap<QuickLinkDto, QuickLinkApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<QuickLinksDto, QuickLinksApiDto>(MemberList.Destination)
                .ReverseMap();
        }

    }
}
