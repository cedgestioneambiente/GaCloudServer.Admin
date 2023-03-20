using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder
{
    public class QueryBuilderParamOnScript:GenericEntity
    {
        public long QueryBuilderScriptId { get; set; }
        public long QueryBuilderParamTypeId { get; set; }
        public string Descrizione { get; set; }
        public string Nome { get; set; }

        public QueryBuilderScript QueryBuilderScript { get; set; }
        public QueryBuilderParamType QueryBuilderParamType { get; set; }
    }
}
