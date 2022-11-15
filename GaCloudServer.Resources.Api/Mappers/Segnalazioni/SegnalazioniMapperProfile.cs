using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.Resources.Api.Dtos.Segnalazioni;

namespace GaCloudServer.Resources.Api.Mappers.Segnalazioni
{
    public class SegnalazioniMapperProfile : Profile
    {
        public SegnalazioniMapperProfile()
        {
            //SegnalazioniTipi
            CreateMap<SegnalazioniTipoDto, SegnalazioniTipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<SegnalazioniTipiDto, SegnalazioniTipiApiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniStati
            CreateMap<SegnalazioniStatoDto, SegnalazioniStatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<SegnalazioniStatiDto, SegnalazioniStatiApiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniAllegati
            CreateMap<SegnalazioniAllegatoDto, SegnalazioniAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<SegnalazioniAllegatiDto, SegnalazioniAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();

            //SegnalazioniDocumenti
            CreateMap<SegnalazioniDocumentoDto, SegnalazioniDocumentoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<SegnalazioniDocumentiDto, SegnalazioniDocumentiApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

