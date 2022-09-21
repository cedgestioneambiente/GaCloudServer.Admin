using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Aziende
{
    internal class AziendeMapperProfile : Profile
    {
        public AziendeMapperProfile()
        {
            //AziendeListe
            CreateMap<AziendeLista, AziendeListaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AziendeLista>, AziendeListeDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

