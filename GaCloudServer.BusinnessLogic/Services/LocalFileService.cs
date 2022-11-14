using DinkToPdf;
using DinkToPdf.Contracts;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class LocalFileService:ILocalFileService
    {
        private readonly string _webRootPath;
        private readonly string _webPath;
        private readonly List<string> _allowedExtensions;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IConverter _converter;

        public LocalFileService(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor, IConverter converter)
        {
            // FileManager Content Folder
            _webPath = "LocalLibrary";
            if (string.IsNullOrWhiteSpace(env.WebRootPath))
            {
                env.WebRootPath = Directory.GetCurrentDirectory();
            }
            _webRootPath = Path.Combine(env.WebRootPath, _webPath);
            _allowedExtensions = new List<string> { "jpg", "jpe", "jpeg", "gif", "png", "svg", "txt", "pdf", "odp", "ods", "odt", "rtf", "doc", "docx", "xls", "xlsx", "ppt", "pptx", "csv", "ogv", "avi", "mkv", "mp4", "webm", "m4v", "ogg", "mp3", "wav", "zip", "rar", "md" };
            _httpContextAccessor = httpContextAccessor;
            _converter = converter;
        }

        public dynamic UploadOnServerPrint(string _fileName, string _path, string _htmlContent, string title = "", string css = "", Orientation orientation = Orientation.Portrait)
        {
            string filePath = Path.Combine(_webRootPath, _path, _fileName);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = orientation,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = filePath
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = _htmlContent,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Template/" + css + "/assets", "styles.css") },
                HeaderSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = "Pagina [page] di [toPage]", Line = true },
                FooterSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true, Center = title }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var directoryExist = Directory.Exists(Path.Combine(_webRootPath, _path));

            if (!directoryExist)
            {
                Directory.CreateDirectory(Path.Combine(_webRootPath, _path));
            }


            var result = _converter.Convert(pdf);

            return MakeWebPath(Path.Combine(_webPath, _path, _fileName));
        }


        private static string MakeWebPath(string path, bool addSeperatorToBegin = false, bool addSeperatorToLast = false)
        {
            path = path.Replace("\\", "/");

            if (addSeperatorToBegin) path = "/" + path;
            if (addSeperatorToLast) path = path + "/";

            return path;
        }


    }
}
