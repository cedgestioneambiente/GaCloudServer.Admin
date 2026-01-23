using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Previsio;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Jobs.Dtos;
using GaCloudServer.Jobs.Dtos.Garbage;
using GaCloudServer.Jobs.Helpers;
using Quartz;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;


namespace GaCloudServer.Jobs.Jobs
{

    public static class LettureJobs
    {
        private static readonly string fileSvuotamentiFtpRoot = "20.82.78.5/LETTURE/";
        private static readonly string fileSvuotamentiFtpEmzRoot = "20.82.78.5/LETTURE/";
        private static readonly NetworkCredential fileSvuotamentiFtpCredentials = new NetworkCredential("srtgaadmin", "K8cAqARVH8*RExtL9VvD7_yU722-WQ");

        private static readonly string nasLettureFtpRoot = "20.82.78.5/";
        private static readonly NetworkCredential nasLettureFtpCredentials = new NetworkCredential("srtgaadmin", "K8cAqARVH8*RExtL9VvD7_yU722-WQ");

        private static readonly string emzLettureFtpRoot = "20.82.78.5/";
        private static readonly NetworkCredential emzLettureFtpCredentials = new NetworkCredential("srtgaadmin", "K8cAqARVH8*RExtL9VvD7_yU722-WQ");


        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class PrevisioOdsLettureGAJob : IJob
        {
            public readonly IServiceProvider _provider;
            public PrevisioOdsLettureGAJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var _ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var _gaPrevisioService = scope.ServiceProvider.GetService<IGaPrevisioService>();

                        try
                        {

                            FtpFolderDto folderDto = new FtpFolderDto();
                            folderDto.serverUri = nasLettureFtpRoot;
                            folderDto.filePath = "FORMULA";
                            folderDto.credentials = nasLettureFtpCredentials;
                            folderDto.useBinary = true;
                            folderDto.usePassive = true;
                            folderDto.keepAlive = true;

                            var fileList =  _ftpService.ReadFolderAsync(folderDto).Result;

                            if (fileList != null)
                            {

                                FtpDownloadAndUploadDto dto = new FtpDownloadAndUploadDto();
                                dto.serverDownloadUri = nasLettureFtpRoot;
                                dto.serverUploadUri = fileSvuotamentiFtpRoot;
                                dto.filePath = "";
                                dto.fileName = "";
                                dto.extraPath = "FORMULA/";
                                dto.customRoot = true;
                                dto.downloadCredentials = nasLettureFtpCredentials;
                                dto.uploadCredentials = fileSvuotamentiFtpCredentials;
                                dto.useBinary = true;
                                dto.usePassive = true;
                                dto.keepAlive = true;

                                foreach (string file in fileList)
                                {
                                    var entityView =  _gaPrevisioService.GetViewGaPrevisioOdsLettureByFileNameAsync(file.Replace(".txt", "")).Result;
                                    if (entityView != null)
                                    {
                                        dto.fileName = file;
                                        PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                                        apiDto.IdServizio = entityView.IdServizio;
                                        apiDto.Descrizione = entityView.Descrizione;
                                        apiDto.Elaborato = true;
                                        apiDto.FileName = dto.fileName;
                                        apiDto.Id = 0;
                                        apiDto.Retry = 0;
                                        apiDto.Disabled = false;

                                        try
                                        {
                                            dto.filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "LocalLibrary", "Download");

                                            var response =  _ftpService.DownloadAndUploadAsync(dto).Result;

                                            if (response.Split("/")[0] != null && response.Split("/")[0] == "550 ")
                                            {
                                                apiDto.Elaborato = false;
                                                apiDto.ErrDescription = response;
                                                var dbResult= _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;
                                            }
                                            else
                                            {
                                                apiDto.ProcDescription = response;
                                                var dbResult= _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;

                                                var ftpMove = new FtpMoveDto();
                                                ftpMove.serverUri = nasLettureFtpRoot;
                                                ftpMove.fileName = dto.fileName;
                                                ftpMove.sourcefilePath = "/FORMULA";
                                                ftpMove.destinationfilePath = "/FORMULA/ELABORATE_GA/";
                                                ftpMove.credentials = nasLettureFtpCredentials;
                                                ftpMove.useBinary = true;
                                                ftpMove.usePassive = true;
                                                ftpMove.keepAlive = true;

                                                var ftpResult= _ftpService.MoveAsync(ftpMove).Result;

                                            }


                                        }
                                        catch (Exception ex)
                                        {
                                            apiDto.ErrDescription = ex.Message;
                                            var dbResult= _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;

                                        }

                                    }
                                    else
                                    {
                                        dto.fileName = file;
                                        PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                                        apiDto.IdServizio = "ODS NON PRESENTE";
                                        apiDto.Descrizione = "ODS NON PRESENTE";
                                        apiDto.Elaborato = true;
                                        apiDto.FileName = dto.fileName;
                                        apiDto.Id = 0;
                                        apiDto.Retry = 0;
                                        apiDto.Disabled = false;
                                        var dbResult= _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;
                                        //ods ancora non presente
                                    }



                                }

                            }
                            else
                            {
                                return Task.CompletedTask;
                            }



                            return Task.CompletedTask;
                        }
                        catch (Exception ex)
                        {
                            return Task.CompletedTask;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Task.CompletedTask;
                }
            }
        }

        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class PrevisioOdsLettureFAJob : IJob
        {
            public readonly IServiceProvider _provider;
            public PrevisioOdsLettureFAJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var _ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var _gaPrevisioService = scope.ServiceProvider.GetService<IGaPrevisioService>();

                        try
                        {
                            FtpFolderDto folderDto = new FtpFolderDto();
                            folderDto.serverUri = nasLettureFtpRoot;
                            folderDto.filePath = "FORMULA//lettureFA";
                            folderDto.credentials = nasLettureFtpCredentials;
                            folderDto.useBinary = true;
                            folderDto.usePassive = true;
                            folderDto.keepAlive = true;

                            var fileList = _ftpService.ReadFolderAsync(folderDto).Result;

                            if (fileList != null)
                            {

                                FtpDownloadAndUploadDto dto = new FtpDownloadAndUploadDto();
                                dto.serverDownloadUri = nasLettureFtpRoot;
                                dto.extraPath = "/FORMULA//lettureFA/";
                                dto.customRoot = true;
                                dto.serverUploadUri = fileSvuotamentiFtpRoot;
                                dto.filePath = "";
                                dto.fileName = "";
                                dto.downloadCredentials = nasLettureFtpCredentials;
                                dto.uploadCredentials = fileSvuotamentiFtpCredentials;
                                dto.useBinary = true;
                                dto.usePassive = true;
                                dto.keepAlive = true;

                                foreach (string file in fileList)
                                {
                                    dto.fileName = file;
                                    PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                                    apiDto.IdServizio = "FORMULA AMBIENTE";
                                    apiDto.Descrizione = "FORMULA AMBIENTE";
                                    apiDto.Elaborato = true;
                                    apiDto.FileName = dto.fileName;
                                    apiDto.Id = 0;
                                    apiDto.Retry = 0;
                                    apiDto.Disabled = false;

                                    try
                                    {
                                        dto.filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "LocalLibrary", "Download");

                                        var response = _ftpService.DownloadAndUploadAsync(dto).Result;

                                        if (response.Split("/")[0] != null && response.Split("/")[0] == "550 ")
                                        {
                                            apiDto.Elaborato = false;
                                            apiDto.ErrDescription = response;
                                            var dbResponse=_gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;
                                        }
                                        else
                                        {
                                            apiDto.ProcDescription = response;
                                            var dbResponse=_gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;

                                            var ftpMove = new FtpMoveDto();
                                            ftpMove.serverUri = nasLettureFtpRoot;
                                            ftpMove.fileName = dto.fileName;
                                            ftpMove.sourcefilePath = "/FORMULA/lettureFA";
                                            ftpMove.destinationfilePath = "/FORMULA/lettureFA/ELABORATE_FA/" + dto.fileName.Substring(0, 4)+"/";
                                            ftpMove.credentials = nasLettureFtpCredentials;
                                            ftpMove.useBinary = true;
                                            ftpMove.usePassive = true;
                                            ftpMove.keepAlive = true;

                                            var ftpResponse = _ftpService.MoveAsync(ftpMove).Result;

                                        }


                                    }
                                    catch (Exception ex)
                                    {
                                        apiDto.ErrDescription = ex.Message;
                                        var dbResponse= _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;

                                    }

                                }

                            }
                            else
                            {
                                return Task.CompletedTask;
                            }
                        }
                        catch (Exception ex)
                        {
                            return Task.CompletedTask;
                        }

                    }

                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Task.CompletedTask;
                }
            }
        }

        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class PrevisioOdsLettureEMZJob : IJob
        {
            public readonly IServiceProvider _provider;
            public PrevisioOdsLettureEMZJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var _ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var _gaPrevisioService = scope.ServiceProvider.GetService<IGaPrevisioService>();

                        try
                        {

                            FtpFolderDto folderDto = new FtpFolderDto();
                            folderDto.serverUri = emzLettureFtpRoot;
                            folderDto.filePath = "EMZ//conferimenti";
                            folderDto.credentials = emzLettureFtpCredentials;
                            folderDto.useBinary = true;
                            folderDto.usePassive = true;
                            folderDto.keepAlive = true;

                            var fileList =  _ftpService.ReadFolderAsync(folderDto).Result;

                            if (fileList != null)
                            {

                                FtpDownloadAndUploadDto dto = new FtpDownloadAndUploadDto();
                                dto.serverDownloadUri = emzLettureFtpRoot;
                                dto.extraPath = "/EMZ/conferimenti/";
                                dto.serverUploadUri = fileSvuotamentiFtpEmzRoot;
                                dto.filePath = "";
                                dto.fileName = "";
                                dto.downloadCredentials = emzLettureFtpCredentials;
                                dto.uploadCredentials = fileSvuotamentiFtpCredentials;
                                dto.useBinary = true;
                                dto.usePassive = true;
                                dto.keepAlive = true;
                                dto.customRoot = true;
                                dto.customRootPath = "emz";

                                foreach (string file in fileList)
                                {
                                    dto.fileName = file;
                                    PrevisioOdsLetturaDto apiDto = new PrevisioOdsLetturaDto();
                                    apiDto.IdServizio = "EMZ";
                                    apiDto.Descrizione = "EMZ";
                                    apiDto.Elaborato = true;
                                    apiDto.FileName = dto.fileName;
                                    apiDto.Id = 0;
                                    apiDto.Retry = 0;
                                    apiDto.Disabled = false;

                                    try
                                    {
                                        dto.filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "LocalLibrary", "Download");

                                        var response = _ftpService.DownloadAndUploadAsync(dto).Result;

                                        if (response.Split("/")[0] != null && response.Split("/")[0] == "550 ")
                                        {
                                            apiDto.Elaborato = false;
                                            apiDto.ErrDescription = response;
                                            var dbResponse= _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;
                                        }
                                        else
                                        {
                                            apiDto.ProcDescription = response;
                                            var dbResponse = _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;

                                            var ftpMove = new FtpMoveDto();
                                            ftpMove.serverUri = emzLettureFtpRoot;
                                            ftpMove.fileName = dto.fileName;
                                            ftpMove.sourcefilePath = "/EMZ/conferimenti";
                                            ftpMove.destinationfilePath = "/EMZ/archivio_conferimenti/";
                                            ftpMove.credentials = emzLettureFtpCredentials;
                                            ftpMove.useBinary = true;
                                            ftpMove.usePassive = true;
                                            ftpMove.keepAlive = true;

                                            var ftpResponse = _ftpService.MoveAsync(ftpMove).Result;

                                        }


                                    }
                                    catch (Exception ex)
                                    {
                                        apiDto.ErrDescription = ex.Message;
                                        var dbResponse = _gaPrevisioService.AddOrUpdateGaPrevisioOdsLetturaAsync(apiDto).Result;

                                    }

                                }

                            }
                            else
                            {
                                return Task.CompletedTask;
                            }
                        }
                        catch (Exception ex)
                        {
                            return Task.CompletedTask;
                        }

                    }

                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Task.CompletedTask;
                }
            }
        }


    }
}
