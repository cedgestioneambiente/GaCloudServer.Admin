using DinkToPdf;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Helpers;
using GaCloudServer.BusinnessLogic.Models;
using GaCloudServer.BusinnessLogic.Providers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
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
        public async Task<string> Print(string templateName,dynamic dto)
        {
            try
            {
                Type templateType = typeof(TemplateGeneratorHelper);
                MethodInfo mi = templateType.GetMethod(templateName);

                string htmlContent = (string)mi.Invoke(this, new object[] { dto});

                return _localFileService.UploadOnServerPrint(dto.FileName,dto.FilePath,htmlContent,dto.Title,dto.Css);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
