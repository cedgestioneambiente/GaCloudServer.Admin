using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneAuto;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Mappers.PrenotazioneAuto
{
    internal class PrenotazioneAutoMapperProfile : Profile
    {
        public PrenotazioneAutoMapperProfile()
        {
            CreateMap<PrenotazioneAutoSede, PrenotazioneAutoSedeDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<PrenotazioneAutoSede>, PrenotazioneAutoSediDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneAutoVeicolo, PrenotazioneAutoVeicoloDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<PrenotazioneAutoVeicoloDto>, PrenotazioneAutoVeicoliDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneAutoRegistrazione, PrenotazioneAutoRegistrazioneDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<PrenotazioneAutoRegistrazione>, PrenotazioneAutoRegistrazioniDto>(MemberList.Destination)
                .ReverseMap();

            
        }
    }
}
