using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Models
{
    public  class DownloadFilesModel
    {
        public Stream stream { get; set; }
        public string fileName { get; set; }
    }

    public class UploadFileResponseModel
    { 
        public string id { get; set; }
        public string fileName { get; set; }
        public string? fileSize { get; set; }

    }

    public class ItemDto
    {
        public string? id { get; set; }
        public string? folderId { get; set; }
        public string? name { get; set; }
        public string? createdBy { get; set; }
        public string? createdAt { get; set; }
        public string? modifiedAt { get; set; }
        public string? size { get; set; }
        public string? type { get; set; }
        public string? contents { get; set; }
        public string? description { get; set; }
        public string? webUrl { get; set; }
    }

    public class ItemsDto
    {
        public List<ItemDto> folders { get; set; }
        public List<ItemDto> files { get; set; }
        public List<dynamic> path { get; set; }

        public ItemsDto()
        {
            folders = new List<ItemDto>();
            files = new List<ItemDto>();
            path = new List<dynamic>();
        }
    }
}
