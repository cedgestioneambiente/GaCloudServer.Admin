using AutoMapper;
using GaCloudServer.BusinnessLogic.Api.Dtos.Resources.System;
using GaCloudServer.BusinnessLogic.Dtos.Resources.System;

namespace GaCloudServer.Resources.Api.Mappers.System
{
    public class SystemMapperProfile: Profile
    {
            public SystemMapperProfile()
            {
                //SystemVersions
                CreateMap<SystemVersionDto, SystemVersionApiDto>(MemberList.Destination)
                    .ReverseMap();
                CreateMap<SystemVersionsDto, SystemVersionsApiDto>(MemberList.Destination)
                    .ReverseMap();

            }
        }
    }
