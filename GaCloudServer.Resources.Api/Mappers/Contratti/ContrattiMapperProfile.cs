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
            CreateMap<ContrattiPermessoDto, ContrattiPermessoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiPermessiDto, ContrattiPermessiApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiServizi Map
            CreateMap<ContrattiServizioDto, ContrattiServizioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiServiziDto, ContrattiServiziApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiTipologie Map
            CreateMap<ContrattiTipologiaDto, ContrattiTipologiaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiTipologieDto, ContrattiTipologieApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiUtentiOnPermessi Map
            CreateMap<ContrattiUtenteOnPermessoDto, ContrattiUtenteOnPermessoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiUtentiOnPermessiDto, ContrattiUtentiOnPermessiApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
