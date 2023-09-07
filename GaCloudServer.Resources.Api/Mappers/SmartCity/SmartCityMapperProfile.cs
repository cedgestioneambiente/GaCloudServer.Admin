using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.SmartCity;
using GaCloudServer.Resources.Api.Dtos.Resources.SmartCity;

namespace GaCloudServer.Resources.Api.Mappers.SmartCity
{
    public class SmartCityMapperProfile : Profile
    {
        public SmartCityMapperProfile()
        {
            //SmartCityPermissions Map
            CreateMap<SmartCityPermissionDto, SmartCityPermissionApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<SmartCityPermissionsDto, SmartCityPermissionsApiDto>(MemberList.Destination)
                .ReverseMap();

            
        }
    }
}
