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
}
