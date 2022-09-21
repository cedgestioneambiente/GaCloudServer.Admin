namespace GaCloudServer.Resources.Api.Dtos.FileManager
{
    public class ItemApiDto
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
    }

    public class ItemsApiDto
    { 
        public List<ItemApiDto> folders { get; set; }
        public List<ItemApiDto> files { get; set; }
        public List<dynamic> path { get; set; }

        public ItemsApiDto()
        {
            folders = new List<ItemApiDto>();
            files = new List<ItemApiDto>();
            path = new List<dynamic>();
        }
    }
}
