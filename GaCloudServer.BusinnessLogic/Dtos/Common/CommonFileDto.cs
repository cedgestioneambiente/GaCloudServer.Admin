using GaCloudServer.BusinnessLogic.Enums;
using GaCloudServer.BusinnessLogic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GaCloudServer.BusinnessLogic.Dtos.Common
{
    public class CommonFileUploadDto : ICommonFileUpload
    {
        public IFormFile FileDetails {get; set;}
        public string FileName {get; set;}
        public string FilePath {get; set;}
        public string FileExtension {get; set;}
        public string FileContentType {get; set;}
        public long FileSize {get; set;}
        public FileType FileType {get; set;}
    }

    public class CommonFileDeleteDto : ICommonFileDelete
    { 
        public string FileName { get; set;} 
        public string FilePath { get; set;} 
        public string FileExtension { get; set;}    
    }

    public class CommonFileDownloadRequestDto
    {
        public string? filePath { get; set; }
        public string? fileName { get; set; }
        public string? fileId { get; set; }
    }
}
