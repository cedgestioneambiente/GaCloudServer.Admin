using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Api.Dtos.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio;

namespace GaCloudServer.Resources.Api.Mappers.Consorzio
{
    public class ConsorzioMapperProfile : Profile
    {
        public ConsorzioMapperProfile()
        {
            //ConsorzioCers
            CreateMap<ConsorzioCerDto, ConsorzioCerApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<ConsorzioCersDto, ConsorzioCersApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioSmaltimenti
            CreateMap<ConsorzioSmaltimentoDto, ConsorzioSmaltimentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioSmaltimentiDto, ConsorzioSmaltimentiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioComuni
            CreateMap<ConsorzioComuneDto, ConsorzioComuneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioComuniDto, ConsorzioComuniApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioDestinatari
            CreateMap<ConsorzioDestinatarioDto, ConsorzioDestinatarioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioDestinatariDto, ConsorzioDestinatariApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioProduttori
            CreateMap<ConsorzioProduttoreDto, ConsorzioProduttoreApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioProduttoriDto, ConsorzioProduttoriApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioTrasportatori
            CreateMap<ConsorzioTrasportatoreDto, ConsorzioTrasportatoreApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioTrasportatoriDto, ConsorzioTrasportatoriApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioRegistrazioni
            CreateMap<ConsorzioRegistrazioneDto, ConsorzioRegistrazioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioRegistrazioniDto, ConsorzioRegistrazioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioRegistrazioniAllegati
            CreateMap<ConsorzioRegistrazioneAllegatoDto, ConsorzioRegistrazioneAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioRegistrazioniAllegatiDto, ConsorzioRegistrazioniAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioPeriodi
            CreateMap<ConsorzioPeriodoDto, ConsorzioPeriodoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioPeriodiDto, ConsorzioPeriodiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioOperazioni
            CreateMap<ConsorzioOperazioneDto, ConsorzioOperazioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioOperazioniDto, ConsorzioOperazioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioImportsTasks
            CreateMap<ConsorzioImportTaskDto, ConsorzioImportTaskApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ConsorzioImportsTasksDto, ConsorzioImportsTasksApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}