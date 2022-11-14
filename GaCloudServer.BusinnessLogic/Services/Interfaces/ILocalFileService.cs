using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface ILocalFileService
    {
        dynamic UploadOnServerPrint(string fileName, string path, string htmlContent, string title = "", string css = "", Orientation orientation = Orientation.Portrait);
    }
}
