using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeUtenzeNovi : GenericEntity
    {
        public string CodCli { get; set; }
        public string RagSo { get; set; }
        public string CodFis { get; set; }
        public string Citta { get; set; }
        public string Via { get; set; }
        public string NumCiv { get; set; }
        public string NumCon { get; set; }
        public int PrintCount { get; set; }


    }
}
