
using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Autorizzazioni
{
    public class AutorizzazioniMapperProfile : Profile
    {
        public AutorizzazioniMapperProfile()
        {
            //GaAutorizzazioniTipi Map
            CreateMap<AutorizzazioneTipo, AutorizzazioneTipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AutorizzazioneTipo>, AutorizzazioniTipiDto>(MemberList.Destination)
                .ReverseMap();

           

        }
    }
}
