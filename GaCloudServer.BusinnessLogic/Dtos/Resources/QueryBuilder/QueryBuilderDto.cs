using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.QueryBuilder
{
    public class QueryBuilderParamTypeDto:GenericDto
    {
        public string Descrizione { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }

        public QueryBuilderParamTypeDto() { }
    }

    public class QueryBuilderParamTypesDto : GenericPagedListDto<QueryBuilderParamTypeDto>
    {

        public QueryBuilderParamTypesDto() { }
    }

    public class QueryBuilderSectionDto:GenericListDto
    {
        public QueryBuilderSectionDto()
        {
        }
    }

    public class QueryBuilderSectionsDto : GenericPagedListDto<QueryBuilderSectionDto>
    {
        public QueryBuilderSectionsDto() { }
    }

    public class QueryBuilderParamOnScriptDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Nome { get; set; }
        public string ApiUrl { get; set; }
        public long QueryBuilderScriptId { get; set; }
        public long QueryBuilderParamTypeId { get; set; }

        public QueryBuilderParamOnScriptDto() { }
    }

    public class QueryBuilderParamOnScriptsDto : GenericPagedListDto<QueryBuilderParamOnScriptDto>
    {

        public QueryBuilderParamOnScriptsDto() { }
    }

    public class QueryBuilderScriptDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public long QueryBuilderSectionId { get; set; }
        public string Roles { get; set; }

        public QueryBuilderScriptDto() { }
    }

    public class QueryBuilderScriptsDto : GenericPagedListDto<QueryBuilderScriptDto>
    {

        public QueryBuilderScriptsDto() { }
    }


}

