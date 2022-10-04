using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeNdUtenze : GenericEntity
    {
        public string CodAzi { get; set; }
        public string CodFis { get; set; }
        public string NumCon { get; set; }
        public string CodCom { get; set; }
        public string RagCli { get; set; }
        public string Partita { get; set; }
        public DateTime? Decorrenza { get; set; }
        public string Comune { get; set; }
        public string DesVia { get; set; }
        public string Civico { get; set; }
        public string Barrato { get; set; }
        public string Interno { get; set; }
        public double Superfic { get; set; }
        public string Categ { get; set; }
        public string Destar { get; set; }
        public string Istat { get; set; }
        public string DesIstat { get; set; }
        public string CodZona { get; set; }
        public string Descri { get; set; }

    }
}
