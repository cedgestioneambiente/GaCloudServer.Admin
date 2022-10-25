using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Csr;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Csr
{
    internal class CsrMapperProfile : Profile
    {
        public CsrMapperProfile()
        {
            //CsrCodiciCers
            CreateMap<CsrCodiceCer, CsrCodiceCerDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrCodiceCer>, CsrCodiciCersDto>(MemberList.Destination)
                .ReverseMap();

            //CsrComuni
            CreateMap<CsrComune, CsrComuneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrComune>, CsrComuniDto>(MemberList.Destination)
                .ReverseMap();

            //CsrDestinatari
            CreateMap<CsrDestinatario, CsrDestinatarioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrDestinatario>, CsrDestinatariDto>(MemberList.Destination)
                .ReverseMap();

            //CsrProduttori
            CreateMap<CsrProduttore, CsrProduttoreDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrProduttore>, CsrProduttoriDto>(MemberList.Destination)
                .ReverseMap();

            //CsrRegistrazioni
            CreateMap<CsrRegistrazione, CsrRegistrazioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrRegistrazione>, CsrRegistrazioniDto>(MemberList.Destination)
                .ReverseMap();

            //CsrRegistrazioniPesi
            CreateMap<CsrRegistrazionePeso, CsrRegistrazionePesoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrRegistrazionePeso>, CsrRegistrazioniPesiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrRipartizioniPercentuali
            CreateMap<CsrRipartizionePercentuale, CsrRipartizionePercentualeDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrRipartizionePercentuale>, CsrRipartizioniPercentualiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrTrasportatori
            CreateMap<CsrTrasportatore, CsrTrasportatoreDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CsrTrasportatore>, CsrTrasportatoriDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
