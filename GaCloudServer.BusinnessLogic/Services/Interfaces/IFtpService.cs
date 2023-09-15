using GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IFtpService
    {
        Task<string> UploadAsync(FtpUploadDto dto);
       
    }
}
