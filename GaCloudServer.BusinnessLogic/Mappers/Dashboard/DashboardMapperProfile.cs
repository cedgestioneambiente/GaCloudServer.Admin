using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Dashboard;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Dashboard
{
    internal class DashboardMapperProfile : Profile
    {
        public DashboardMapperProfile()
        {
            //DashboardType
            CreateMap<DashboardType, DashboardTypeDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DashboardType>, DashboardTypesDto>(MemberList.Destination)
                .ReverseMap();

            //DashboardSection
            CreateMap<DashboardSection, DashboardSectionDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DashboardSection>, DashboardSectionsDto>(MemberList.Destination)
                .ReverseMap();

            //DashboardItem
            CreateMap<DashboardItem, DashboardItemDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DashboardItem>, DashboardItemsDto>(MemberList.Destination)
                .ReverseMap();

            //DashboardStore
            CreateMap<DashboardStore, DashboardStoreDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DashboardStore>, DashboardStoresDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}


