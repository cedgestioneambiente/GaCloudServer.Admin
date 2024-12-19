using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views
{
    public class ViewGaPreventiviIsmartDocumenti : GenericEntity
    {
        public string Codcli { get; set; }
        public string Branch { get; set; }
        public string Ragsoc { get; set; }
        public string Piva { get; set; }
        public string Codpag { get; set; }
        public string Codsez { get; set; }
        public string Numfat { get; set; }
        public DateTime Dtfat { get; set; }
        public string Tipdoc { get; set; }
        public string Prgfat { get; set; }
        public string Codclised { get; set; }
        public string Controllata { get; set; }
        public string Ragfat { get; set; }
        public string SplitPayment { get; set; }
        public decimal Ritenute { get; set; }
        public decimal ImportoFatt { get; set; }
        public string FileXmlFattura { get; set; }
        public decimal Anticipo { get; set; }
        public bool Archivio { get; set; }
        public string PdfFile { get; set; }
        public string IdDocumento { get; set; }
        public DateTime DataDocCorr { get; set; }
        public string NumItem { get; set; }

    }
}
