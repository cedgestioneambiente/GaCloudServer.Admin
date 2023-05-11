
using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.QueryBuilder
{

    public class QueryBuilderParamTypeApiDto : GenericApiDto
    {
        public string Descrizione { get; set; }
        public string Type { get; set; }
        public string? Data { get; set; }

        public QueryBuilderParamTypeApiDto() { }
    }

    public class QueryBuilderParamTypesApiDto : GenericPagedListApiDto<QueryBuilderParamTypeApiDto>
    {

        public QueryBuilderParamTypesApiDto() { }
    }

    public class QueryBuilderSectionApiDto : GenericListApiDto
    {
        public QueryBuilderSectionApiDto()
        {
        }
    }

    public class QueryBuilderSectionsApiDto : GenericPagedListApiDto<QueryBuilderSectionApiDto>
    {
        public QueryBuilderSectionsApiDto() { }
    }

    public class QueryBuilderParamOnScriptApiDto : GenericApiDto
    {
        public string Descrizione { get; set; }
        public string Nome { get; set; }
        public string? ApiUrl { get; set; }
        public long QueryBuilderScriptId { get; set; }
        public long QueryBuilderParamTypeId { get; set; }

        public QueryBuilderParamOnScriptApiDto() { }
    }

    public class QueryBuilderParamOnScriptsApiDto : GenericPagedListApiDto<QueryBuilderParamOnScriptApiDto>
    {

        public QueryBuilderParamOnScriptsApiDto() { }
    }

    public class QueryBuilderScriptApiDto : GenericApiDto
    {
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public long QueryBuilderSectionId { get; set; }
        public string Roles { get; set; }

        public QueryBuilderScriptApiDto() { }
    }

    public class QueryBuilderScriptsApiDto : GenericPagedListApiDto<QueryBuilderScriptApiDto>
    {

        public QueryBuilderScriptsApiDto() { }
    }

    public class QueryBuilderQuery { 
        public string userId { get; set; }
        public string query { get; set; }
    }

}
