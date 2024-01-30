using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.Resources.Api.Dtos.Resources.Preventivi;

namespace GaCloudServer.Resources.Api.Mappers.Preventivi
{
    public class PreventiviMapperProfile : Profile
    {
        public PreventiviMapperProfile()
        {

            //PreventiviAnticipiTipologie
            CreateMap<PreventiviAnticipoTipologiaDto, PreventiviAnticipoTipologiaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PreventiviAnticipiTipologieDto, PreventiviAnticipiTipologieApiDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipiPagamenti
            CreateMap<PreventiviAnticipoPagamentoDto, PreventiviAnticipoPagamentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PreventiviAnticipiPagamentiDto, PreventiviAnticipiPagamentiApiDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipi
            CreateMap<PreventiviAnticipoDto, PreventiviAnticipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PreventiviAnticipiDto, PreventiviAnticipiApiDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipiAllegati
            CreateMap<PreventiviAnticipoAllegatoDto, PreventiviAnticipoAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PreventiviAnticipiAllegatiDto, PreventiviAnticipiAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

