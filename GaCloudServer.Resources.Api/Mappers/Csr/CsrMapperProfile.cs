using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Csr;
using GaCloudServer.Resources.Api.Dtos.Csr;

namespace GaCloudServer.Resources.Api.Mappers.Csr
{
    public class CsrMapperProfile : Profile
    {
        public CsrMapperProfile()
        {
            //CsrCodiciCers
            CreateMap<CsrCodiceCerDto, CsrCodiceCerApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrCodiciCersDto, CsrCodiciCersApiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrComuni
            CreateMap<CsrComuneDto, CsrComuneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrComuniDto, CsrComuniApiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrDestinatari
            CreateMap<CsrDestinatarioDto, CsrDestinatarioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrDestinatariDto, CsrDestinatariApiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrProduttori
            CreateMap<CsrProduttoreDto, CsrProduttoreApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrProduttoriDto, CsrProduttoriApiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrRegistrazioni
            CreateMap<CsrRegistrazioneDto, CsrRegistrazioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrRegistrazioniDto, CsrRegistrazioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrRegistrazioniPesi
            CreateMap<CsrRegistrazionePesoDto, CsrRegistrazionePesoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrRegistrazioniPesiDto, CsrRegistrazioniPesiApiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrRipartizioniPercentuali
            CreateMap<CsrRipartizionePercentualeDto, CsrRipartizionePercentualeApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrRipartizioniPercentualiDto, CsrRipartizioniPercentualiApiDto>(MemberList.Destination)
                .ReverseMap();

            //CsrTrasportatori
            CreateMap<CsrTrasportatoreDto, CsrTrasportatoreApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CsrTrasportatoriDto, CsrTrasportatoriApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
