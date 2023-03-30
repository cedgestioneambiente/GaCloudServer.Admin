using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Tasks;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Mappers.Tasks
{
    internal class TasksMapperProfile : Profile
    {
        public TasksMapperProfile()
        {
            CreateMap<TasksTag, TasksTagDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<TasksTag>, TasksTagsDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<TasksItem, TasksItemDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<TasksItem>, TasksItemsDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}

