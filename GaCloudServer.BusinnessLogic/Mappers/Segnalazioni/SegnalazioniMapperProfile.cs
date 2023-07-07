using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Segnalazioni
{
    internal class SegnalazioniMapperProfile : Profile
    {
        public SegnalazioniMapperProfile()
        {
            //SegnalazioniTipi
            CreateMap<SegnalazioniTipo, SegnalazioniTipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<SegnalazioniTipo>, SegnalazioniTipiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniStati
            CreateMap<SegnalazioniStato, SegnalazioniStatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<SegnalazioniStato>, SegnalazioniStatiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniDocumentiImmagini
            CreateMap<SegnalazioniDocumentoImmagine, SegnalazioniDocumentoImmagineDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<SegnalazioniDocumentoImmagine>, SegnalazioniDocumentiImmaginiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniDocumenti
            CreateMap<SegnalazioniDocumento, SegnalazioniDocumentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<SegnalazioniDocumento>, SegnalazioniDocumentiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}


