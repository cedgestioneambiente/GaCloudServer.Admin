// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;
using GaCloudServer.Resources.Api.Dtos.Key;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Key;

namespace GaCloudServer.Resources.Api.Mappers
{
    public class KeyApiMapperProfile : Profile
    {
        public KeyApiMapperProfile()
        {
            CreateMap<KeyDto, KeyApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<KeysDto, KeysApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}







