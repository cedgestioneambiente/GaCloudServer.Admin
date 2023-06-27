using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioImportTask : GenericFileEntity
    {
        public string TaskId { get; set; }
        public string Log { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Completed { get; set; }
        public int Error { get; set; }
        public string UserId { get; set; }
    }
}