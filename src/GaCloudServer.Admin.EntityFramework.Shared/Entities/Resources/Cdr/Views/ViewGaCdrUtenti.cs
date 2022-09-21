using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views
{
    public class ViewGaCdrUtenti : GenericEntity
    {
        public string RagioneSociale { get; set; }
        public string CfPiva { get; set; }
        public string Comune { get; set; }
        public string Indirizzo { get; set; }
        public string Ditta { get; set; }
        public string InserimentoUtente { get; set; }
        public string Approvato { get; set; }
    }
}
