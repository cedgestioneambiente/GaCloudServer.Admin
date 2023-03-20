using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder.Views
{
    public class ViewQueryBuilderScripts:GenericEntity
    {
        public string Section { get; set; }
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public string Roles { get; set; }
    }
}
