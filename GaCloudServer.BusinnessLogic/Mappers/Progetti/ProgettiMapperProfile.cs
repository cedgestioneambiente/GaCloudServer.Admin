using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Progetti
{
    internal class ProgettiMapperProfile : Profile
    {
        public ProgettiMapperProfile()
        {
            //ProgettiWork
            CreateMap<ProgettiWork, ProgettiWorkDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiWork>, ProgettiWorksDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobs
            CreateMap<ProgettiJob, ProgettiJobDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiJob>, ProgettiJobsDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobAllegati
            CreateMap<ProgettiJobAllegato, ProgettiJobAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiJobAllegato>, ProgettiJobAllegatiDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobTask
            CreateMap<ProgettiJobTask, ProgettiJobTaskDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiJobTask>, ProgettiJobTasksDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiWorkSettings
            CreateMap<ProgettiWorkSetting, ProgettiWorkSettingDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiWorkSetting>, ProgettiWorkSettingsDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobsUndertakings
            CreateMap<ProgettiJobUndertaking, ProgettiJobUndertakingDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiJobUndertaking>, ProgettiJobsUndertakingsDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobsUndertakingsStates
            CreateMap<ProgettiJobUndertakingState, ProgettiJobUndertakingStateDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiJobUndertakingState>, ProgettiJobsUndertakingsStatesDto>(MemberList.Destination)
                .ReverseMap();

            //ProgettiJobsUndertakingsAllegati
            CreateMap<ProgettiJobUndertakingAllegato, ProgettiJobUndertakingAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ProgettiJobUndertakingAllegato>, ProgettiJobsUndertakingsAllegatiDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}

