using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Base
{
    public class GenericEntity
    {
        public long Id { get; set; }
        public bool Disabled { get; set; }
    }

    public class GenericFileEntity : GenericEntity
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
}
