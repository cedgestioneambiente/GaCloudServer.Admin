using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeUtenzePartiteDetail : GenericEntity
    {
        public string CpAzi { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string Comune { get; set; }
        public string DesVia { get; set; }
        public string NumCiv { get; set; }
        public string Tributo { get; set; }
        public string Cessato { get; set; }
        public string CodCli { get; set; }
        public string RagSo { get; set; }
        public int NumCivNum { get; set; }

    }
}
