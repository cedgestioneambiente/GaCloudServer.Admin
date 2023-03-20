using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.QueryBuilder;
using GaCloudServer.Resources.Api.Dtos.Resources.QueryBuilder;

namespace GaCloudServer.Resources.Api.Mappers.QueryBuilder
{
    public class QueryBuilderMapperProfile:Profile
    {
        public QueryBuilderMapperProfile() {
            //QueryBuilderParamType
            CreateMap<QueryBuilderParamTypeDto, QueryBuilderParamTypeApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<QueryBuilderParamTypesDto, QueryBuilderParamTypesApiDto>(MemberList.Destination)
                .ReverseMap();

            //QueryBuilderSection
            CreateMap<QueryBuilderSectionDto, QueryBuilderSectionApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<QueryBuilderSectionsDto, QueryBuilderSectionsApiDto>(MemberList.Destination)
                .ReverseMap();

            //QueryBuilderParamOnScript
            CreateMap<QueryBuilderParamOnScriptDto, QueryBuilderParamOnScriptApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<QueryBuilderParamOnScriptsDto, QueryBuilderParamOnScriptsApiDto>(MemberList.Destination)
                .ReverseMap();

            //QueryBuilderScript
            CreateMap<QueryBuilderScriptDto, QueryBuilderScriptApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<QueryBuilderScriptsDto, QueryBuilderScriptsApiDto>(MemberList.Destination)
                .ReverseMap();
        }

    }
}
