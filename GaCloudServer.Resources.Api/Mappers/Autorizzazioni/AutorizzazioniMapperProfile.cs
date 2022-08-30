using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.Resources.Api.Dtos.Autorizzazioni;

namespace GaCloudServer.Resources.Api.Mappers.Autorizzazioni
{
    public class AutorizzazioniMapperProfile : Profile
    {
        public AutorizzazioniMapperProfile()
        {
            //AutorizzazioniTipi
            CreateMap<AutorizzazioniTipoDto, AutorizzazioniTipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<AutorizzazioniTipiDto, AutorizzazioniTipiApiDto>(MemberList.Destination)
                .ReverseMap();

            //AutorizzazioniDocumenti
            CreateMap<AutorizzazioniDocumentoDto, AutorizzazioniDocumentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<AutorizzazioniDocumentiDto, AutorizzazioniDocumentiApiDto>(MemberList.Destination)
                .ReverseMap();

            //AutorizzazioniDocumenti
            CreateMap<AutorizzazioniAllegatoDto, AutorizzazioniAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<AutorizzazioniAllegatiDto, AutorizzazioniAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();



        }
    }
}
