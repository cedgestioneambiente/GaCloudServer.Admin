using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Autorizzazioni;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Autorizzazioni
{
    public class AutorizzazioniMapperProfile : Profile
    {
        public AutorizzazioniMapperProfile()
        {
            //AutorizzazioniTipi
            CreateMap<AutorizzazioniTipo, AutorizzazioniTipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AutorizzazioniTipo>, AutorizzazioniTipiDto>(MemberList.Destination)
                .ReverseMap();

            //AutorizzazioniDocumenti
            CreateMap<AutorizzazioniDocumento, AutorizzazioniDocumentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AutorizzazioniDocumento>, AutorizzazioniDocumentiDto>(MemberList.Destination)
                .ReverseMap();

            //AutorizzazioniDocumenti
            CreateMap<AutorizzazioniAllegato, AutorizzazioniAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AutorizzazioniAllegato>, AutorizzazioniAllegatiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
