using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Presenze
{
    internal class PresenzeMapperProfile : Profile
    {
        public PresenzeMapperProfile()
        {
            //PresenzeStatiRichieste
            CreateMap<PresenzeStatoRichiesta, PresenzeStatoRichiestaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeStatoRichiesta>, PresenzeStatiRichiesteDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeRichieste
            CreateMap<PresenzeRichiesta, PresenzeRichiestaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeRichiesta>, PresenzeRichiesteDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeTipiOre
            CreateMap<PresenzeTipoOra, PresenzeTipoOraDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeTipoOra>, PresenzeTipiOreDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeResponsabili
            CreateMap<PresenzeResponsabile, PresenzeResponsabileDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeResponsabile>, PresenzeResponsabiliDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeResponsabiliOnSettori
            CreateMap<PresenzeResponsabileOnSettore, PresenzeResponsabileOnSettoreDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeResponsabileOnSettore>, PresenzeResponsabiliOnSettoriDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeProfili
            CreateMap<PresenzeProfilo, PresenzeProfiloDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeProfilo>, PresenzeProfiliDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeDateEscluse
            CreateMap<PresenzeDataEsclusa, PresenzeDataEsclusaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeDataEsclusa>, PresenzeDateEscluseDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeBancheOreUtilizzi
            CreateMap<PresenzeBancaOraUtilizzo, PresenzeBancaOraUtilizzoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeBancaOraUtilizzo>, PresenzeBancheOreUtilizziDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeDipendenti
            CreateMap<PresenzeDipendente, PresenzeDipendenteDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeDipendente>, PresenzeDipendentiDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeOrari
            CreateMap<PresenzeOrario, PresenzeOrarioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeOrario>, PresenzeOrariDto>(MemberList.Destination)
                .ReverseMap();

            //PresenzeOrariGiornate
            CreateMap<PresenzeOrarioGiornata, PresenzeOrarioGiornataDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PresenzeOrarioGiornata>, PresenzeOrariGiornateDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

