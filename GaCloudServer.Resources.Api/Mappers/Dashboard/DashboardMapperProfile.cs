using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Dashboard;
using GaCloudServer.Resources.Api.ApiDtos.Resources.Dashboard;

namespace GaCloudServer.Resources.Api.Mappers.Dashboard
{
    public class DashboardMapperProfile:Profile
    {
        public DashboardMapperProfile() {

            //DashboardTypeDto
            CreateMap<DashboardTypeDto, DashboardTypeApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DashboardTypesDto, DashboardTypesApiDto>(MemberList.Destination)
                .ReverseMap();

            //DashboardSectionDto
            CreateMap<DashboardSectionDto, DashboardSectionApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DashboardSectionsDto, DashboardSectionsApiDto>(MemberList.Destination)
                .ReverseMap();

            //DashboardItemDto
            CreateMap<DashboardItemDto, DashboardItemApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DashboardItemsDto, DashboardItemsApiDto>(MemberList.Destination)
                .ReverseMap();

            //DashboardStoreDto
            CreateMap<DashboardStoreDto, DashboardStoreApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DashboardStoresDto, DashboardStoresApiDto>(MemberList.Destination)
                .ReverseMap();
        }

    }
}
