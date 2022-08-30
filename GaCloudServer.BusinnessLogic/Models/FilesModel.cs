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

    }
}
