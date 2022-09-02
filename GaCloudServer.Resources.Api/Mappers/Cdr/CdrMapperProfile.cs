using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr;
using GaCloudServer.Resources.Api.Dtos.Cdr;

namespace GaCloudServer.Resources.Api.Mappers.Cdr
{
    public class CdrMapperProfile : Profile
    {
        public CdrMapperProfile()
        {
            //GaCdrCentri Map
            CreateMap<CdrCentroDto, CdrCentroApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CdrCentriDto, CdrCentriApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrComuni Map
            CreateMap<CdrComuneDto, CdrComuneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CdrComuniDto, CdrComuniApiDto>(MemberList.Destination)
                .ReverseMap();



        }
    }
}
