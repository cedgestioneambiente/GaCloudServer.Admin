using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Dispositivi;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Dispositivi
{
    internal class DispositiviMapperProfile : Profile
    {
        public DispositiviMapperProfile()
        {
            CreateMap<DispositiviTipologia, DispositiviTipologiaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviTipologia>, DispositiviTipologieDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviModello, DispositiviModelloDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviModello>, DispositiviModelliDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviMarca, DispositiviMarcaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviMarca>, DispositiviMarcheDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviClasse, DispositiviClasseDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviClasse>, DispositiviClassiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviCategoria, DispositiviCategoriaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviCategoria>, DispositiviCategorieDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviItem, DispositiviItemDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviItem>, DispositiviItemsDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviStock, DispositiviStockDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviStock>, DispositiviStocksDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviOnDipendente, DispositiviOnDipendenteDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviOnDipendente>, DispositiviOnDipendentiDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviOnModulo, DispositiviOnModuloDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviOnModulo>, DispositiviOnModuliDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<DispositiviModulo, DispositiviModuloDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<DispositiviModulo>, DispositiviModuliDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}

