using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeUtenzePartiteVariazioni : GenericEntity
    {
        public string CodAzi { get; set; }
        public string DesAzi { get; set; }
        public string NumCon { get; set; }
        public int CpRowNum { get; set; }
        public string Partita { get; set; }
        public DateTime? DtIni { get; set; }
        public DateTime? DtFin { get; set; }
        public string Categ { get; set; }
        public string DesCateg { get; set; }
        public string Tributo { get; set; }
        public string AnnoRid { get; set; }
        public string CdRid1 { get; set; }
        public string CdRid2 { get; set; }
        public string CdRid3 { get; set; }
        public string CdRid4 { get; set; }
        public string DesRid1 { get; set; }
        public string DesRid2 { get; set; }
        public string DesRid3 { get; set; }
        public string DesRid4 { get; set; }
        public int NrComp { get; set; }
        public decimal Superfic { get; set; }
        public string Cessato { get; set; }

    }
}
