using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.System;
using GaCloudServer.BusinnessLogic.Dtos.Resources.System;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.System
{
    internal class SystemMapperProfile : Profile
    {
        public SystemMapperProfile()
        {
            //SystemVersions
            CreateMap<SystemVersion, SystemVersionDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<SystemVersion>, SystemVersionsDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

