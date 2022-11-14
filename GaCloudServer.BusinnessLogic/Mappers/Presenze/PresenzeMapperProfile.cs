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

            
            //OPERATIVI
            
            ////PresenzeDateEscluse
            //CreateMap<PresenzeOpDataEsclusa, PresenzeDataEsclusaDto>(MemberList.Destination)
            //    .ReverseMap();

            //CreateMap<PagedList<PresenzeOpDataEsclusa>, PresenzeDateEscluseDto>(MemberList.Destination)
            //    .ReverseMap();

            ////PresenzeBancheOre
            //CreateMap<PresenzeOpBancaOra, PresenzeBancaOraDto>(MemberList.Destination)
            //    .ReverseMap();

            //CreateMap<PagedList<PresenzeOpBancaOra>, PresenzeBancheOreDto>(MemberList.Destination)
            //    .ReverseMap();

            ////PresenzeBancheOreUtilizzi
            //CreateMap<PresenzeOpBancaOraUtilizzo, PresenzeBancaOraUtilizzoDto>(MemberList.Destination)
            //    .ReverseMap();

            //CreateMap<PagedList<PresenzeOpBancaOraUtilizzo>, PresenzeBancheOreUtilizziDto>(MemberList.Destination)
            //    .ReverseMap();
        }
    }
}

