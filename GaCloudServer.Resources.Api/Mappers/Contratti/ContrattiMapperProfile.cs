using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.Resources.Api.Dtos.Contratti;

namespace GaCloudServer.Resources.Api.Mappers.Contratti
{
    public class ContrattiMapperProfile : Profile
    {
        public ContrattiMapperProfile()
        {
            //GaContrattiPermessi Map
            CreateMap<ContrattiPermessoDto, ContrattiPermessoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiPermessiDto, ContrattiPermessiApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiServizi Map
            CreateMap<ContrattiServizioDto, ContrattiServizioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiServiziDto, ContrattiServiziApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiTipologie Map
            CreateMap<ContrattiTipologiaDto, ContrattiTipologiaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiTipologieDto, ContrattiTipologieApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiUtentiOnPermessi Map
            CreateMap<ContrattiUtenteOnPermessoDto, ContrattiUtenteOnPermessoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiUtentiOnPermessiDto, ContrattiUtentiOnPermessiApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiModalitas Map
            CreateMap<ContrattiModalitaDto, ContrattiModalitaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiModalitasDto, ContrattiModalitasApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiFornitori Map
            CreateMap<ContrattiFornitoreDto, ContrattiFornitoreApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiFornitoriDto, ContrattiFornitoriApiDto>(MemberList.Destination)
                .ReverseMap();

            //GaContrattiDocumenti Map
            CreateMap<ContrattiDocumentoDto, ContrattiDocumentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContrattiDocumentiDto, ContrattiDocumentiApiDto>(MemberList.Destination)
                .ReverseMap();

            //Contratti Request Map
            CreateMap<ContrattiDocumentiRequestDto, ContrattiDocumentiRequestApiDto>(MemberList.Destination)
                .ReverseMap();

            //Contratti List Request Map
            CreateMap<ContrattiDocumentiListRequestDto, ContrattiDocumentiListRequestApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
