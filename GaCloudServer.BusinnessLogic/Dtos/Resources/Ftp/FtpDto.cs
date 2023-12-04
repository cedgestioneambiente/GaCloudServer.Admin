using System.Net;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp
{
    public class FtpUploadDto
    {
        public string serverUri { get; set; }
        public NetworkCredential credentials { get; set; }
        public string filePath { get; set; }
        public string fileName { get; set; }  
        
        public bool usePassive { get; set; }
        public bool useBinary { get; set; }
        public bool keepAlive { get; set; }

        
    }

    public class FtpDownloadDto
    {
        public string serverUri { get; set; }
        public NetworkCredential credentials { get; set; }
        public string filePath { get; set; }
        public string fileName { get; set; }

        public bool usePassive { get; set; }
        public bool useBinary { get; set; }
        public bool keepAlive { get; set; }

    }

    public class FtpFolderDto
    {
        public string serverUri { get; set; }
        public NetworkCredential credentials { get; set; }
        public string filePath { get; set; }

        public bool usePassive { get; set; }
        public bool useBinary { get; set; }
        public bool keepAlive { get; set; }


    }

    public class FtpDownloadAndUploadDto
    {
        public string serverDownloadUri { get; set; }
        public string serverUploadUri { get; set; }
        public NetworkCredential downloadCredentials { get; set; }
        public NetworkCredential uploadCredentials { get; set; }
        public string filePath { get; set; }
        public string? extraPath { get; set; }
        public string fileName { get; set; }

        public bool customRoot {  get; set; }
        public string customRootPath { get; set; }

        public bool usePassive { get; set; }
        public bool useBinary { get; set; }
        public bool keepAlive { get; set; }


    }

    public class FtpMoveDto
    {
        public string serverUri { get; set; }
        public NetworkCredential credentials { get; set; }
        public string sourcefilePath { get; set; }
        public string destinationfilePath { get; set; }
        public string fileName { get; set; }

        public bool usePassive { get; set; }
        public bool useBinary { get; set; }
        public bool keepAlive { get; set; }
    }
}
