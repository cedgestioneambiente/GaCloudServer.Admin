using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using GaCloudServer.Resources.Api.Dtos.Resources.Presenze;

namespace GaCloudServer.Resources.Api.Mappers.Presenze
{
    public class PresenzeMapperProfile : Profile
    {
        public PresenzeMapperProfile()
        {
            //PresenzeStatiRichieste
            CreateMap<PresenzeStatoRichiestaDto, PresenzeStatoRichiestaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeStatiRichiesteDto, PresenzeStatiRichiesteApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeRichieste
            CreateMap<PresenzeRichiestaDto, PresenzeRichiestaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeRichiesteDto, PresenzeRichiesteApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeTipiOre
            CreateMap<PresenzeTipoOraDto, PresenzeTipoOraApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeTipiOreDto, PresenzeTipiOreApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeResponsabili
            CreateMap<PresenzeResponsabileDto, PresenzeResponsabileApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeResponsabiliDto, PresenzeResponsabiliApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeResponsabiliOnSettori
            CreateMap<PresenzeResponsabileOnSettoreDto, PresenzeResponsabileOnSettoreApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeResponsabiliOnSettoriDto, PresenzeResponsabiliOnSettoriApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeProfili
            CreateMap<PresenzeProfiloDto, PresenzeProfiloApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeProfiliDto, PresenzeProfiliApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeDateEscluse
            CreateMap<PresenzeDataEsclusaDto, PresenzeDataEsclusaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeDataEsclusaDto, PresenzeDateEscluseApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeBancheOreUtilizzi
            CreateMap<PresenzeBancaOraUtilizzoDto, PresenzeBancaOraUtilizzoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeBancaOraUtilizzoDto, PresenzeBancheOreUtilizziApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeDipendenti
            CreateMap<PresenzeDipendenteDto, PresenzeDipendenteApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeDipendentiDto, PresenzeDipendentiApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeOrari
            CreateMap<PresenzeOrarioDto, PresenzeOrarioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeOrariDto, PresenzeOrariApiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeOrariGiornate
            CreateMap<PresenzeOrarioGiornataDto, PresenzeOrarioGiornataApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PresenzeOrariGiornateDto, PresenzeOrariGiornateApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

