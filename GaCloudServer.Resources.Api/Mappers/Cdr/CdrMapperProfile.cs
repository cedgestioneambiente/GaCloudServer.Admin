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

            //GaCdrCers Map
            CreateMap<CdrCerDto, CdrCerApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CdrCersDto, CdrCersApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrCersDettagli Map
            CreateMap<CdrCerDettaglioDto, CdrCerDettaglioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CdrCersDettagliDto, CdrCersDettagliApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrCersOnCentri Map
            CreateMap<CdrCerOnCentroDto, CdrCerOnCentroApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CdrCersOnCentriDto, CdrCersOnCentriApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrComuniOnCentri Map
            CreateMap<CdrComuneOnCentroDto, CdrComuneOnCentroApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CdrComuniOnCentriDto, CdrComuniOnCentriApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrConferimenti Map
            CreateMap<CdrConferimentoDto, CdrConferimentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CdrConferimentiDto, CdrConferimentiApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
