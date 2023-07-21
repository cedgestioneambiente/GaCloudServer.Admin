using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Dispositivi;
using GaCloudServer.Resources.Api.Dtos.Dispositivi;

namespace GaCloudServer.Resources.Api.Mappers.Dispositivi
{
    public class DispositiviMapperProfile : Profile
    {
        public DispositiviMapperProfile()
        {

            CreateMap<DispositiviTipologiaDto, DispositiviTipologiaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviTipologieDto, DispositiviTipologieApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviModelloDto, DispositiviModelloApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviModelliDto, DispositiviModelliApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviMarcaDto, DispositiviMarcaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviMarcheDto, DispositiviMarcheApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviClasseDto, DispositiviClasseApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviClassiDto, DispositiviClassiApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviCategoriaDto, DispositiviCategoriaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviCategorieDto, DispositiviCategorieApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviItemDto, DispositiviItemApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviItemsDto, DispositiviItemsApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviStockDto, DispositiviStockApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviStocksDto, DispositiviStocksApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviOnDipendenteDto, DispositiviOnDipendenteApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviOnDipendentiDto, DispositiviOnDipendentiApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviOnModuloDto, DispositiviOnModuloApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviOnModuliDto, DispositiviOnModuliApiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviModuloDto, DispositiviModuloApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<DispositiviModuliDto, DispositiviModuliApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
