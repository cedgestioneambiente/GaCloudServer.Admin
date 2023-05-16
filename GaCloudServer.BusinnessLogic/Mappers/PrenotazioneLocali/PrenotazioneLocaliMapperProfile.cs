using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneLocali;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Mappers.PrenotazioneLocali
{
    internal class PrenotazioneLocaliMapperProfile : Profile
    {
        public PrenotazioneLocaliMapperProfile()
        {
            CreateMap<PrenotazioneLocaliSede, PrenotazioneLocaliSedeDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<PrenotazioneLocaliSede>, PrenotazioneLocaliSediDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneLocaliUfficio, PrenotazioneLocaliUfficioDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<PrenotazioneLocaliUfficioDto>, PrenotazioneLocaliUfficiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PrenotazioneLocaliRegistrazione, PrenotazioneLocaliRegistrazioneDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<PrenotazioneLocaliRegistrazione>, PrenotazioneLocaliRegistrazioniDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}

