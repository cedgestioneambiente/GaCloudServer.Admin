using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using GaCloudServer.Resources.Api.ApiDtos.Resources.Progetti;

namespace GaCloudServer.Resources.Api.Mappers.Progetti
{
    public class ProgettiMapperProfile : Profile
    {
        public ProgettiMapperProfile()
        {
            //ProgettiWork
            CreateMap<ProgettiWorkDto, ProgettiWorkApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiWorksDto, ProgettiWorksApiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobs
            CreateMap<ProgettiJobDto, ProgettiJobApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiJobsDto, ProgettiJobsApiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobAllegati
            CreateMap<ProgettiJobAllegatoDto, ProgettiJobAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiJobAllegatiDto, ProgettiJobAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobTasks
            CreateMap<ProgettiJobTaskDto, ProgettiJobTaskApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiJobTasksDto, ProgettiJobTasksApiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiWorkSettings
            CreateMap<ProgettiWorkSettingDto, ProgettiWorkSettingApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiWorkSettingsDto, ProgettiWorkSettingsApiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobsUndertakings
            CreateMap<ProgettiJobUndertakingDto, ProgettiJobUndertakingApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiJobsUndertakingsDto, ProgettiJobsUndertakingsApiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobsUndertakingsStates
            CreateMap<ProgettiJobUndertakingStateDto, ProgettiJobUndertakingStateApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiJobsUndertakingsStatesDto, ProgettiJobsUndertakingsStatesApiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobsUndertakingsAllegati
            CreateMap<ProgettiJobUndertakingAllegatoDto, ProgettiJobUndertakingAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ProgettiJobsUndertakingsAllegatiDto, ProgettiJobsUndertakingsAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}

