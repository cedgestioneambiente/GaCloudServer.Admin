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
        dynamic UploadOnServerPrint(string _fileName, string _path, string _htmlContent, HeaderSettings headerSettings, FooterSettings footerSettings,int copies, string title = "", string css = "", Orientation orientation = Orientation.Portrait,string? alternativePath=null);
        dynamic UploadMergedOnServerPrint(string _fileName, string _path, List<ObjectSettings> pages, int copies, Orientation orientation = Orientation.Portrait,MarginSettings margin=null);
        bool DeleteFromServerPrint(string _fileName, string _path);
    }
}
