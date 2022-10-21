using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using GaCloudServer.Resources.Api.Dtos.Resources.Personale;

namespace GaCloudServer.Resources.Api.Mappers.Personale
{
    public class PersonaleMapperProfile : Profile
    {
        public PersonaleMapperProfile()
        {
            //PersonaleQualifiche
            CreateMap<PersonaleQualificaDto, PersonaleQualificaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleQualificheDto, PersonaleQualificheApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleAssunzioni
            CreateMap<PersonaleAssunzioneDto, PersonaleAssunzioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleAssunzioniDto, PersonaleAssunzioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleDipendenti
            CreateMap<PersonaleDipendenteDto, PersonaleDipendenteApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleDipendentiDto, PersonaleDipendentiApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
