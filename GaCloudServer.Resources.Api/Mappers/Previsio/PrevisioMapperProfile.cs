using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Previsio;
using GaCloudServer.Resources.Api.Dtos.Resources.Previsio;

namespace GaCloudServer.Resources.Api.Mappers.Previsio
{
    public class PrevisioMapperProfile : Profile
    {
        public PrevisioMapperProfile()
        {
            //PrevisioOdsLetture
            CreateMap<PrevisioOdsLetturaDto, PrevisioOdsLetturaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrevisioOdsLettureDto, PrevisioOdsLettureApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
