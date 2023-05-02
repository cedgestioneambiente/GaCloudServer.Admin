using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Dtos.Resources.System;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Consorzio
{
    internal class ConsorzioMapperProfile : Profile
    {
        public ConsorzioMapperProfile()
        {
            //ConsorzioCers
            CreateMap<ConsorzioCer, ConsorzioCerDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioCer>, ConsorzioCersDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioCerSmaltimentosSmaltimenti
            CreateMap<ConsorzioCerSmaltimento, ConsorzioCerSmaltimentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioCerSmaltimento>, ConsorzioCersSmaltimentiDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioComuni
            CreateMap<ConsorzioComune, ConsorzioComuneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioComune>, ConsorzioComuniDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioDestinatari
            CreateMap<ConsorzioDestinatario, ConsorzioDestinatarioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioDestinatario>, ConsorzioDestinatariDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioProduttori
            CreateMap<ConsorzioProduttore, ConsorzioProduttoreDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioProduttore>, ConsorzioProduttoriDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioTrasportatori
            CreateMap<ConsorzioTrasportatore, ConsorzioTrasportatoreDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioTrasportatore>, ConsorzioTrasportatoriDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioRegistrazioni
            CreateMap<ConsorzioRegistrazione, ConsorzioRegistrazioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioRegistrazione>, ConsorzioRegistrazioniDto>(MemberList.Destination)
                .ReverseMap();

            //ConsorzioRegistrazioniAllegati
            CreateMap<ConsorzioRegistrazioneAllegato, ConsorzioRegistrazioneAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ConsorzioRegistrazioneAllegato>, ConsorzioRegistrazioniAllegatiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}