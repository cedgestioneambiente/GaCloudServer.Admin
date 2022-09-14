using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Comunicati;
using GaCloudServer.Resources.Api.Dtos.Comunicati;

namespace GaCloudServer.Resources.Api.Mappers.Comunicati
{
    public class ComunicatiMapperProfile : Profile
    {
        public ComunicatiMapperProfile()
        {
            //ComunicatiDocumenti
            CreateMap<ComunicatiDocumentoDto, ComunicatiDocumentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ComunicatiDocumentiDto, ComunicatiDocumentiApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
