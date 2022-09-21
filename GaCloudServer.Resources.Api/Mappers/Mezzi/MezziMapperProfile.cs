using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi;
using GaCloudServer.Resources.Api.Dtos.Resources.Mezzi;

namespace GaCloudServer.Resources.Api.Mappers.Mezzi
{
    public class MezziMapperProfile : Profile
    {
        public MezziMapperProfile()
        {
            CreateMap<MezziAlimentazioneDto, MezziAlimentazioneApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziAlimentazioniDto, MezziAlimentazioniApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziCantiereDto, MezziCantiereApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziCantieriDto, MezziCantieriApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziClasseDto, MezziClasseApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziClassiDto, MezziClassiApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziPatenteDto,MezziPatenteApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziPatentiDto, MezziPatentiApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziPeriodoScadenzaDto, MezziPeriodoScadenzaApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziPeriodiScadenzeDto,MezziPeriodiScadenzeApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziProprietarioDto, MezziProprietarioApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziProprietariDto, MezziProprietariApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziScadenzaTipoDto,MezziScadenzaTipoApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap< MezziScadenzeTipiDto, MezziScadenzeTipiApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziTipoDto,MezziTipoApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziTipiDto, MezziTipiApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziVeicoloDto, MezziVeicoloApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziVeicoliDto, MezziVeicoliApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziScadenzaDto, MezziScadenzaApiDto>(MemberList.Destination)
            .ReverseMap();
            CreateMap<MezziScadenzeDto, MezziScadenzeApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziDocumentoDto, MezziDocumentoApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MezziDocumentiDto, MezziDocumentiApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
