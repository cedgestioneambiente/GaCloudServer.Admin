using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeUtenzePartiteGrp : GenericEntity
    {
        public string CpAzi { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public int CpRowNum { get; set; }
        public string RagSo { get; set; }
        public string CodFis { get; set; }
        public DateTime? DtIni { get; set; }
        public DateTime? DtFin { get; set; }
        public string Cessato { get; set; }
        public string Comune { get; set; }
        public string Via { get; set; }
        public string NumCiv { get; set; }
        public string Barrato { get; set; }
        public string Interno { get; set; }
        public int? Superfic { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }
        public string Categ { get; set; }
        public string CategDesc { get; set; }
        public string CodZona { get; set; }
        public string Tributo { get; set; }

    }
}
