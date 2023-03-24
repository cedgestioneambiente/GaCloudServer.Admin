using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder.Views
{
    public class ViewQueryBuilderParamOnScripts:GenericEntity
    {
        public long QueryBuilderScriptId { get; set; }
        public string ParamType { get; set; }
        public string ParamDesc { get; set; }
        public string Descrizione { get; set; }
        public string Nome { get; set; }
        public string ApiUrl { get; set; }
    }
}
