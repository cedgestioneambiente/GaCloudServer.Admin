using GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IFtpService
    {
        Task<string> UploadAsync(FtpUploadDto dto);
        Task<string> DownloadAsync(FtpDownloadDto fileName);
        Task<string> DownloadAndUploadAsync(FtpDownloadAndUploadDto fileName);
        Task<string> MoveAsync(FtpMoveDto dto);
        Task<List<string>> ReadFolderAsync(FtpFolderDto dto);

    }
}
