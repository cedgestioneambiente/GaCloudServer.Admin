using DinkToPdf;
using GaCloudServer.BusinnessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;


namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IFileService
    {
        Task<Stream> Download(string folder, string file);
        Task<DownloadFilesModel> DownloadById(string fileId);
        Task<DownloadFilesModel> DownloadByFolderFileName(string folder,string fileName);
        Task<UploadFileResponseModel> Upload(IFormFile file, string folder, string fileName);
        Task<UploadFileResponseModel> UploadStream(MemoryStream stream, string folder, string fileName);
        Task<DriveItem> UploadImage(MemoryStream stream, string _mainFolder, string _targetFolder, string fileName);
        Task<bool> Remove(string fileId);
        Task<string> CreateSharedLink(string fileId);
        Task<List<ItemDto>> GetRootFolderByName(string folderName);
        Task<List<ItemDto>> GetFolderContentById(string folderId, List<ItemDto> path);
        //dynamic UploadOnServerReport(string _fileName, string _path, string _htmlContent, string title = "", string css = "", Orientation orientation = Orientation.Portrait);
    }
}
