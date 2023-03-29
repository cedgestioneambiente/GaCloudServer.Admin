using AutoMapper;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Tasks;
using GaCloudServer.Resources.Api.Dtos.Resources.Tasks;

namespace GaCloudServer.Resources.Api.Mappers.Tasks
{
    public class TasksMapperProfile : Profile
    {
        public TasksMapperProfile()
        {
            CreateMap<TasksItemDto, TasksItemApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<TasksItemsDto, TasksItemsApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<TasksTagDto, TasksTagApiDto>(MemberList.Destination)
               .ReverseMap();
            CreateMap<TasksTagsDto, TasksTagsApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
