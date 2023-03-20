using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder
{
    public class QueryBuilderScript : GenericEntity
    {
        public long QueryBuilderSectionId { get; set; }
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public string Roles { get; set; }

        public QueryBuilderSection QueryBuilderSection { get; set; }
    }
}
