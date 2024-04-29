using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice
{
    public class BackOfficeDocReceipt:GenericEntity
    {
        public string DocType { get; set; }
        public DateTime OpDate { get; set; }
        public string NumCon {  get; set; }
        public string CodCli { get; set; }
        public string AnnoRif { get; set; }
        public string Note { get; set; }
        public string Note2 { get; set; }

        public string CData { get; set; }
    }
}
