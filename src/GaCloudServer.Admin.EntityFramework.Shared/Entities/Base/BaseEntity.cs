using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Base
{
    public class GenericEntity
    {
        public long Id { get; set; }
        public bool Disabled { get; set; }

    }

    public class GenericAuditableEntity:GenericEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class GenericFileEntity : GenericEntity
    {
        public string FileId { get; set; }
        public string FileFolder { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
    }

    public class GenericFileAuditableEntity : GenericAuditableEntity
    {
        public string FileId { get; set; }
        public string FileFolder { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
    }

    public class GenericListEntity:GenericEntity
    {
        public string Descrizione { get; set; }
    }

    public class GenericListAuditableEntity : GenericAuditableEntity
    {
        public string Descrizione { get; set; }
    }
}
