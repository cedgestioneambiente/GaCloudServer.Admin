using GaCloudServer.BusinnessLogic.Enums;
using Microsoft.AspNetCore.Http;

namespace GaCloudServer.BusinnessLogic.Interfaces
{
    public interface ICommonFileUpload
    {
        public IFormFile FileDetails { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public string FileContentType { get; set; }
        public long FileSize { get; set; }
        public FileType FileType { get; set; }
    }

    public interface ICommonFileDelete
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
    }
}
