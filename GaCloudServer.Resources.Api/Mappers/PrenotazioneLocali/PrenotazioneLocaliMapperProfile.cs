using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneLocali;
using GaCloudServer.Resources.Api.Dtos.Resources.PrenotazioneLocali;

namespace GaCloudServer.Resources.Api.Mappers.PrenotazioneLocali
{
    public class PrenotazioneLocaliMapperProfile : Profile
    {
        public PrenotazioneLocaliMapperProfile()
        {
            CreateMap<PrenotazioneLocaliSedeDto, PrenotazioneLocaliSedeApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PrenotazioneLocaliSediDto, PrenotazioneLocaliSediApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneLocaliUfficioDto, PrenotazioneLocaliUfficioApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PrenotazioneLocaliUfficiDto, PrenotazioneLocaliUfficiApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneLocaliRegistrazioneDto, PrenotazioneLocaliRegistrazioneApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PrenotazioneLocaliRegistrazioniDto, PrenotazioneLocaliRegistrazioniApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
