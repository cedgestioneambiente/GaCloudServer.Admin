using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder
{
    public class QueryBuilderParamType:GenericEntity
    {
        public string Descrizione { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
