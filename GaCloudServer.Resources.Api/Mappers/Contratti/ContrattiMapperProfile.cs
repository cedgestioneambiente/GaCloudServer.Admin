using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.Resources.Api.Dtos.Contratti;

namespace GaCloudServer.Resources.Api.Mappers.Contratti
{
    public class ContrattiMapperProfile : Profile
    {
        public ContrattiMapperProfile()
        {
            //GaContrattiPermessi Map
            CreateMap<ContrattoPermessoDto, ContrattoPermessoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiPermessiDto, ContrattiPermessiApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiServizi Map
            CreateMap<ContrattoServizioDto, ContrattoServizioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiServiziDto, ContrattiServiziApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiTipologie Map
            CreateMap<ContrattoTipologiaDto, ContrattoTipologiaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiTipologieDto, ContrattiTipologieApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiUtentiOnPermessi Map
            CreateMap<ContrattoUtenteOnPermessoDto, ContrattoUtenteOnPermessoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiUtentiOnPermessiDto, ContrattiUtentiOnPermessiApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
