using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Cdr
{
    internal class CdrMapperProfile : Profile
    {
        public CdrMapperProfile()
        {
            //GaCdrCentri Map
            CreateMap<CdrCentro, CdrCentroDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrCentro>, CdrCentriDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrComuni Map
            CreateMap<CdrComune, CdrComuneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrComune>, CdrComuniDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrCers Map
            CreateMap<CdrCer, CdrCerDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrCer>, CdrCersDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrCersDettagli Map
            CreateMap<CdrCerDettaglio, CdrCerDettaglioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrCerDettaglio>, CdrCersDettagliDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrCersOnCentri Map
            CreateMap<CdrCerOnCentro, CdrCerOnCentroDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrCerOnCentro>, CdrCersOnCentriDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrComuniOnCentri Map
            CreateMap<CdrComuneOnCentro, CdrComuneOnCentroDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrComuneOnCentro>, CdrComuniOnCentriDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrConferimenti Map
            CreateMap<CdrConferimento, CdrConferimentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrConferimento>, CdrConferimentiDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrRichiesteViaggi Map
            CreateMap<CdrRichiestaViaggio, CdrRichiestaViaggioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrRichiestaViaggio>, CdrRichiesteViaggiDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrStatiRichieste Map
            CreateMap<CdrStatoRichiesta, CdrStatoRichiestaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrStatoRichiesta>, CdrStatiRichiesteDto>(MemberList.Destination)
                .ReverseMap();

            //GaCdrUtenti Map
            CreateMap<CdrUtente, CdrUtenteDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrUtente>, CdrUtentiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}