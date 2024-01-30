using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Preventivi
{
    internal class PreventiviMapperProfile : Profile
    {
        public PreventiviMapperProfile()
        {
            //PreventiviAnticipiTipologie
            CreateMap<PreventiviAnticipoTipologia, PreventiviAnticipoTipologiaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipoTipologia>, PreventiviAnticipiTipologieDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipiPagamenti
            CreateMap<PreventiviAnticipoPagamento, PreventiviAnticipoPagamentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipoPagamento>, PreventiviAnticipiPagamentiDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipi
            CreateMap<PreventiviAnticipo, PreventiviAnticipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipo>, PreventiviAnticipiDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipiAllegati
            CreateMap<PreventiviAnticipoAllegato, PreventiviAnticipoAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipoAllegato>, PreventiviAnticipiAllegatiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}

