using DinkToPdf;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;


namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IFileService
    {
        Task<DownloadFilesModel> DownloadById(string fileId);
        Task<UploadFileResponseModel> Upload(IFormFile file, string folder, string fileName);
        Task<UploadFileResponseModel> Upload(CommonFileUploadDto fileModel);
        Task<UploadFileResponseModel> UploadStream(MemoryStream stream, string folder, string fileName);
        Task<UploadFileResponseModel> UploadText(string content, string folder, string fileName);
        Task<bool> Remove(string fileId);
        Task<string> CreateSharedLink(string fileId);
        Task<List<ItemDto>> GetRootFolderByName(string folderName);
        Task<List<ItemDto>> GetFolderContentById(string folderId, List<ItemDto> path);
    }
}
