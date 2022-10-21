using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Global;
using GaCloudServer.Resources.Api.Dtos.Resources.Global;

namespace GaCloudServer.Resources.Api.Mappers.Global
{
    public class GlobalMapperProfile : Profile
    {
        public GlobalMapperProfile()
        {
            //GlobalSedi
            CreateMap<GlobalSedeDto, GlobalSedeApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<GlobalSediDto, GlobalSediApiDto>(MemberList.Destination)
                .ReverseMap();

            //GlobalCentriCosti
            CreateMap<GlobalCentroCostoDto, GlobalCentroCostoApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<GlobalCentriCostiDto, GlobalCentriCostiApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
