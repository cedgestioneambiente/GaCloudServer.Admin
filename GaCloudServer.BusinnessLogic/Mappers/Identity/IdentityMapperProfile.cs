using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Identity;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Mappers.Identity
{
    internal class IdentityMapperProfile : Profile
    {
        public IdentityMapperProfile()
        {
            CreateMap<ViewUserIdentity, ViewUserIdentityDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<ViewUserIdentity>, ViewUserIdentitiesDto>(MemberList.Destination)
                .ReverseMap();

            
        }
    }
}
