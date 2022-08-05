using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.Resources.Api.Dtos.Autorizzazioni;

namespace GaCloudServer.Resources.Api.Mappers.Autorizzazioni
{
    public class AutorizzazioniMapperProfile : Profile
    {
        public AutorizzazioniMapperProfile()
        {
            //GaAutorizzazioniTipi Map
            CreateMap<AutorizzazioneTipoDto, AutorizzazioneTipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<AutorizzazioniTipiDto, AutorizzazioniTipiApiDto>(MemberList.Destination)
                .ReverseMap();



        }
    }
}
