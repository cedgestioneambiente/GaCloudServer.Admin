using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeInsolutoTariNovi : GenericEntity
    {
        public string CodCli { get; set; }
        public string NumCont { get; set; }
        public int AnnoRif { get; set; }
        public string CodTributo { get; set; }
        public string DaPagare { get; set; }
        public string Pagato { get; set; }
        public string Saldo { get; set; }
        public string RagSo { get; set; }
        public string Indirizzo { get; set; }
        public string CodFis { get; set; }
        public DateTime DtFat { get; set; }
        public string NumFat { get; set; }
        public string NumAvviso { get; set; }

    }
}
