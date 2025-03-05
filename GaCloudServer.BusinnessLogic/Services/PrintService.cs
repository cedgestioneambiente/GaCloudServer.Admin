using DinkToPdf;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Helpers;
using GaCloudServer.BusinnessLogic.Models;
using GaCloudServer.BusinnessLogic.Providers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Reflection;
using fh = GaCloudServer.BusinnessLogic.Helpers.FileHelper;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class PrintService : IPrintService
    {
        private readonly ILocalFileService _localFileService;
        public PrintService(ILocalFileService localFileService)
        {
            _localFileService = localFileService;
        }
        public async Task<string> Print(string templateName,dynamic dto, string? alternativePath=null)
        {
            try
            {
                Type templateType = typeof(TemplateGeneratorHelper);
                MethodInfo mi = templateType.GetMethod(templateName);

                string htmlContent = (string)mi.Invoke(this, new object[] { dto,alternativePath});

                return _localFileService.UploadOnServerPrint(dto.FileName,dto.FilePath,htmlContent,dto.HeaderSettings,dto.FooterSettings,dto.Copies, dto.Title,dto.Css,dto.Orientation,alternativePath,dto.MarginSettings);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> PrintMerged(dynamic dtos, string? alternativePath = null,int? copies=2,MarginSettings margin=null)
        {
            try
            {
                List<ObjectSettings> pages = new List<ObjectSettings>();
                string fileName = "";
                string filePath = "";
                foreach (var dto in dtos)
                {
                    Type templateType = typeof(TemplateGeneratorHelper);
                    MethodInfo mi = templateType.GetMethod(dto.TemplateName);

                    fileName = dto.FileName;
                    filePath= dto.FilePath;

                    var htmlContent= (string)mi.Invoke(this, new object[] { dto,alternativePath });

                    pages.Add(new ObjectSettings()
                    {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Template/" + dto.Css + "/assets", "styles.css") },
                        HeaderSettings = dto.HeaderSettings, //{ FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = "Pagina [page] di [toPage]", Line = true },
                        FooterSettings = dto.FooterSettings//{ FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true, Center = title }
                    });
                }
                

                return _localFileService.UploadMergedOnServerPrint(fileName,filePath,pages,copies.GetValueOrDefault(),Orientation.Portrait,margin);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
