using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Contratti
{
    public class ContrattiMapperProfile : Profile
    {
        public ContrattiMapperProfile()
        {
            //GaContrattiPermessi Map
            CreateMap<ContrattiPermesso, ContrattiPermessoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattiPermesso>, ContrattiPermessiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiServizi Map
            CreateMap<ContrattiServizio, ContrattiServizioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattiServizio>, ContrattiServiziDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiTipologie Map
            CreateMap<ContrattiTipologia, ContrattiTipologiaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattiTipologia>, ContrattiTipologieDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiUtentiOnPermessi Map
            CreateMap<ContrattiUtenteOnPermesso, ContrattiUtenteOnPermessoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattiUtenteOnPermesso>, ContrattiUtentiOnPermessiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
