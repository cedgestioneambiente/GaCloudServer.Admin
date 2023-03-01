using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.EcSegnalazioni
{
    internal class EcSegnalazioniMapperProfile : Profile
    {
        public EcSegnalazioniMapperProfile()
        {
            //SegnalazioniTipi
            CreateMap<EcSegnalazioniTipo, SegnalazioniTipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<EcSegnalazioniTipo>, SegnalazioniTipiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniStati
            CreateMap<EcSegnalazioniStato, SegnalazioniStatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<EcSegnalazioniStato>, SegnalazioniStatiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniAllegati
            //CreateMap<EcSegnalazioniAllegato, SegnalazioniAllegatoDto>(MemberList.Destination)
            //    .ReverseMap();

            //CreateMap<PagedList<EcSegnalazioniAllegato>, SegnalazioniAllegatiDto>(MemberList.Destination)
            //    .ReverseMap();

            //SegnalazioniDocumenti
            CreateMap<EcSegnalazioniDocumento, SegnalazioniDocumentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<EcSegnalazioniDocumento>, SegnalazioniDocumentiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}


