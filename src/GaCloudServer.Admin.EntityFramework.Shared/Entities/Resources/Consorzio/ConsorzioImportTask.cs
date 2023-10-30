using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioImportTask : GenericFileAuditableEntity
    {
        public string TaskId { get; set; }
        public byte[] Log { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Completed { get; set; }
        public int Error { get; set; }
        public string UserId { get; set; }
        public bool Deleted { get; set; }
    }
}