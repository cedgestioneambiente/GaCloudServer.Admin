using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Cdr;
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

            

        }
    }
}
