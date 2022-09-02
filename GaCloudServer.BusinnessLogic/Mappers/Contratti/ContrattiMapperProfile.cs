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
            CreateMap<ContrattoPermesso, ContrattoPermessoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattoPermesso>, ContrattiPermessiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiServizi Map
            CreateMap<ContrattoServizio, ContrattoServizioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattoServizio>, ContrattiServiziDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiTipologie Map
            CreateMap<ContrattoTipologia, ContrattoTipologiaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattoTipologia>, ContrattiTipologieDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiUtentiOnPermessi Map
            CreateMap<ContrattoUtenteOnPermesso, ContrattoUtenteOnPermessoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContrattoUtenteOnPermesso>, ContrattiUtentiOnPermessiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
