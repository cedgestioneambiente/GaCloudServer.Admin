using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views
{
    public class ViewConsorzioImportsTasks : GenericEntity
    {
        public string TaskId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Completed { get; set; }
        public int Error { get; set; }
        public int Totale { get; set; }
        public string DurataMinuti { get; set; }
        public string DurataSecondi { get; set; }
        public string Successo { get; set; }
        public string FileId { get; set; }
        public string FullName { get; set; }
    }
}
