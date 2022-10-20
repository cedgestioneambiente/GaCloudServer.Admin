using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende;
using GaCloudServer.Resources.Api.Dtos.Aziende;

namespace GaCloudServer.Resources.Api.Mappers.Aziende
{
    public class AziendeMapperProfile : Profile
    {
        public AziendeMapperProfile()
        {
            //AziendeListe
            CreateMap<AziendeListaDto, AziendeListaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<AziendeListeDto, AziendeListeApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
