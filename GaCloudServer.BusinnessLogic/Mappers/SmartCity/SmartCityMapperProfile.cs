using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.SmartCity;
using GaCloudServer.BusinnessLogic.Dtos.Resources.SmartCity;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.SmartCity
{
    internal class SmartCityMapperProfile : Profile
    {
        public SmartCityMapperProfile()
        {
            //SmagrtCityPermission Map
            CreateMap<SmartCityPermission, SmartCityPermissionDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<SmartCityPermission>, SmartCityPermissionsDto>(MemberList.Destination)
                .ReverseMap();

            
        }
    }
}
