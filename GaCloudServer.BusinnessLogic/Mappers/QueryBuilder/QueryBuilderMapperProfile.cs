using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder;
using GaCloudServer.BusinnessLogic.Dtos.Resources.QueryBuilder;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.QueryBuilder
{
    internal class QueryBuilderMapperProfile : Profile
    {
        public QueryBuilderMapperProfile()
        {
            //QueryBuilderParamType
            CreateMap<QueryBuilderParamType, QueryBuilderParamTypeDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<QueryBuilderParamType>, QueryBuilderParamTypesDto>(MemberList.Destination)
                .ReverseMap();

            //QueryBuilderSection
            CreateMap<QueryBuilderSection, QueryBuilderSectionDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<QueryBuilderSection>, QueryBuilderSectionsDto>(MemberList.Destination)
                .ReverseMap();

            //QueryBuilderParamOnScript
            CreateMap<QueryBuilderParamOnScript, QueryBuilderParamOnScriptDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<QueryBuilderParamOnScript>, QueryBuilderParamOnScriptsDto>(MemberList.Destination)
                .ReverseMap();

            //QueryBuilderScript
            CreateMap<QueryBuilderScript, QueryBuilderScriptDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<QueryBuilderScript>, QueryBuilderScriptsDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}


