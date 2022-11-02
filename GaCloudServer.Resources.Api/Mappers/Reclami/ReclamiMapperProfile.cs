using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Reclami;
using GaCloudServer.Resources.Api.Dtos.Reclami;

namespace GaCloudServer.Resources.Api.Mappers.Reclami
{
    public class ReclamiMapperProfile : Profile
    {
        public ReclamiMapperProfile()
        {
            //ReclamiMittenti
            CreateMap<ReclamiMittenteDto, ReclamiMittenteApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ReclamiMittentiDto, ReclamiMittentiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiStati
            CreateMap<ReclamiStatoDto, ReclamiStatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ReclamiStatiDto, ReclamiStatiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiTempiRisposte
            CreateMap<ReclamiTempoRispostaDto, ReclamiTempoRispostaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ReclamiTempiRisposteDto, ReclamiTempiRisposteApiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiTipiAzioni
            CreateMap<ReclamiTipoAzioneDto, ReclamiTipoAzioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ReclamiTipiAzioniDto, ReclamiTipiAzioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiTipiOrigini
            CreateMap<ReclamiTipoOrigineDto, ReclamiTipoOrigineApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ReclamiTipiOriginiDto, ReclamiTipiOriginiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiAzione
            CreateMap<ReclamiAzioniDto, ReclamiAzioniApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ReclamiAzioneDto, ReclamiAzioneApiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiDocumenti
            CreateMap<ReclamiDocumentoDto, ReclamiDocumentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ReclamiDocumentiDto, ReclamiDocumentiApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
