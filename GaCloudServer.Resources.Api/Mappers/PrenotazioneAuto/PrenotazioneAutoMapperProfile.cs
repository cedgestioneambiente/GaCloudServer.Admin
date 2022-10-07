using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneAuto;
using GaCloudServer.Resources.Api.Dtos.Resources.PrenotazioneAuto;

namespace GaCloudServer.Resources.Api.Mappers.PrenotazioneAuto
{
    public class PrenotazioneAutoMapperProfile : Profile
    {
        public PrenotazioneAutoMapperProfile()
        {
            CreateMap<PrenotazioneAutoSedeDto, PrenotazioneAutoSedeApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PrenotazioneAutoSediDto, PrenotazioneAutoSediApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneAutoVeicoloDto, PrenotazioneAutoVeicoloApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PrenotazioneAutoVeicoliDto, PrenotazioneAutoVeicoliApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneAutoRegistrazioneDto, PrenotazioneAutoRegistrazioneApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PrenotazioneAutoRegistrazioniDto, PrenotazioneAutoRegistrazioniApiDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}
