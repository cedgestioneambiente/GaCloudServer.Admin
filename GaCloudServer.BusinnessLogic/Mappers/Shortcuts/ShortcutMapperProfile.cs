using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
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

            CreateMap<PagedList<ShortcutLink>, ShortcutLinksDto>(MemberList.Destination)
                .ReverseMap();

            //ShortcutItems
            CreateMap<ShortcutItem, ShortcutItemDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ShortcutItem>, ShortcutItemsDto>(MemberList.Destination)
                .ReverseMap();

            
        }
    }
}


