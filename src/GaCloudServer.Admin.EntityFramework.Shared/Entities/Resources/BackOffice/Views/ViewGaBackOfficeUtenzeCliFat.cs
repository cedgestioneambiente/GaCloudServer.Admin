using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeUtenzeCliFat : GenericEntity
    {
        public string CodCli { get; set; }
        public string RagSo1 { get; set; }
        public string RagSo2 { get; set; }
        public string Via { get; set; }
        public string NumCiv {  get; set; }
        public string Cap { get; set; }
        public string Citta { get; set; }
        public string Piva { get; set; }
        public string Prov { get; set; }
        public string CodIva { get; set; }
        public string TipCli { get; set; }
        public string CodPag { get; set; }
        public string Nazione { get; set; }
        public string Telef { get; set; }
        public string Cel { get; set; }
        public string CodFis { get; set; }
        public DateTime? DtNas { get; set; }
        public string LocNas { get; set; }


    }
}
