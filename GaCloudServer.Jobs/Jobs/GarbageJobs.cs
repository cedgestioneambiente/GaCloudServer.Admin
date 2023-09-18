using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp;
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
    public static class GarbageJobs
    {

        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class GarbageTipologieJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GarbageTipologieJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var garbageService = scope.ServiceProvider.GetService<IGaCrmService>();

                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<ViewGaCrmGarbageTipologie, GarbageTipologiaDto>();

                        });
                        IMapper mapper = config.CreateMapper();

                        var view = garbageService.GetViewGaCrmGarbageTipologieAsync().Result;
                        var list = mapper.Map<List<GarbageTipologiaDto>>(view.Data);
                        var csvList = list.ToDelimitedText(";", false, true);

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\EXPORT_TICKET_TIPOLOGIE.csv");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        System.IO.File.WriteAllText(fullPath, csvList);

                        FtpUploadDto dto = new FtpUploadDto();
                        dto.serverUri = "gestioneambiente.garbageweb.it/Dati/";
                        dto.filePath = fullPath;
                        dto.fileName = fileName.Replace("Storage\\", "");
                        dto.credentials = new NetworkCredential("GestAmbODL", "G3$a$m2023Xde");
                        dto.useBinary = true;
                        dto.usePassive = true;
                        dto.keepAlive = true;

                        var response =  ftpService.UploadAsync(dto).Result;

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
        public class GarbagePartiteJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GarbagePartiteJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var garbageService = scope.ServiceProvider.GetService<IGaCrmService>();

                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<ViewGaCrmGarbagePartite, GarbagePartitaDto>();

                        });

                        IMapper mapper = config.CreateMapper();

                        var view = garbageService.GetViewGaCrmGarbagePartiteAsync().Result;
                        var list = mapper.Map<List<GarbagePartitaDto>>(view.Data);
                        var csvList = list.ToDelimitedText(";", false, true);

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\EXPORT_PARTITE.csv");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        System.IO.File.WriteAllText(fullPath, csvList);

                        FtpUploadDto dto = new FtpUploadDto();
                        dto.serverUri = "gestioneambiente.garbageweb.it/Dati/Dati";
                        dto.filePath = fullPath;
                        dto.fileName = fileName.Replace("Storage\\", "");
                        dto.credentials = new NetworkCredential("GestAmbODL", "G3$a$m2023Xde");
                        dto.useBinary = true;
                        dto.usePassive = true;
                        dto.keepAlive = true;

                        var response = ftpService.UploadAsync(dto).Result;

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
        public class GarbageUtenzeJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GarbageUtenzeJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var garbageService = scope.ServiceProvider.GetService<IGaCrmService>();

                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<ViewGaCrmGarbageUtenze, GarbageUtenzaDto>();

                        });

                        IMapper mapper = config.CreateMapper();

                        var view = garbageService.GetViewGaCrmGarbageUtenzeAsync().Result;
                        var list = mapper.Map<List<GarbageUtenzaDto>>(view.Data);
                        var csvList = list.ToDelimitedText(";", false, true);

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\EXPORT_UTENZE.csv");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        System.IO.File.WriteAllText(fullPath, csvList);

                        FtpUploadDto dto = new FtpUploadDto();
                        dto.serverUri = "gestioneambiente.garbageweb.it/Dati/";
                        dto.filePath = fullPath;
                        dto.fileName = fileName.Replace("Storage\\", "");
                        dto.credentials = new NetworkCredential("GestAmbODL", "G3$a$m2023Xde");
                        dto.useBinary = true;
                        dto.usePassive = true;
                        dto.keepAlive = true;

                        var response = ftpService.UploadAsync(dto).Result;

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
        public class GarbageProvenienzeJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GarbageProvenienzeJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var garbageService = scope.ServiceProvider.GetService<IGaCrmService>();

                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<ViewGaCrmGarbageProvenienze, GarbageProvenienzaDto>();

                        });

                        IMapper mapper = config.CreateMapper();

                        var view = garbageService.GetViewGaCrmGarbageProvenienzeAsync().Result;
                        var list = mapper.Map<List<GarbageProvenienzaDto>>(view.Data);
                        var csvList = list.ToDelimitedText(";", false, true);

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\EXPORT_TICKET_PROVENIENZE.csv");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        System.IO.File.WriteAllText(fullPath, csvList);

                        FtpUploadDto dto = new FtpUploadDto();
                        dto.serverUri = "gestioneambiente.garbageweb.it/Dati/";
                        dto.filePath = fullPath;
                        dto.fileName = fileName.Replace("Storage\\", "");
                        dto.credentials = new NetworkCredential("GestAmbODL", "G3$a$m2023Xde");
                        dto.useBinary = true;
                        dto.usePassive = true;
                        dto.keepAlive = true;

                        var response = ftpService.UploadAsync(dto).Result;

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
        public class GarbageStatiJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GarbageStatiJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var garbageService = scope.ServiceProvider.GetService<IGaCrmService>();

                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<ViewGaCrmGarbageStati, GarbageStatoDto>();

                        });

                        IMapper mapper = config.CreateMapper();

                        var view = garbageService.GetViewGaCrmGarbageStatiAsync().Result;
                        var list = mapper.Map<List<GarbageStatoDto>>(view.Data);
                        var csvList = list.ToDelimitedText(";", false, true);

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\EXPORT_TICKET_STATI.csv");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        System.IO.File.WriteAllText(fullPath, csvList);

                        FtpUploadDto dto = new FtpUploadDto();
                        dto.serverUri = "gestioneambiente.garbageweb.it/Dati/";
                        dto.filePath = fullPath;
                        dto.fileName = fileName.Replace("Storage\\", "");
                        dto.credentials = new NetworkCredential("GestAmbODL", "G3$a$m2023Xde");
                        dto.useBinary = true;
                        dto.usePassive = true;
                        dto.keepAlive = true;

                        var response = ftpService.UploadAsync(dto).Result;

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
        public class GarbageTicketContactCenterJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GarbageTicketContactCenterJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var garbageService = scope.ServiceProvider.GetService<IGaCrmService>();

                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<ViewGaCrmGarbageTicketContactCenter, GarbageTicketContactCenterDto>();

                        });

                        IMapper mapper = config.CreateMapper();

                        var view = garbageService.GetViewGaCrmGarbageTicketContactCenterAsync().Result;
                        var list = mapper.Map<List<GarbageTicketContactCenterDto>>(view.Data);
                        var csvList = list.ToDelimitedText(";", false, true);

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\EXPORT_TICKET_CONTACT_CENTER.csv");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        System.IO.File.WriteAllText(fullPath, csvList);

                        FtpUploadDto dto = new FtpUploadDto();
                        dto.serverUri = "gestioneambiente.garbageweb.it/Dati/";
                        dto.filePath = fullPath;
                        dto.fileName = fileName.Replace("Storage\\", "");
                        dto.credentials = new NetworkCredential("GestAmbODL", "G3$a$m2023Xde");
                        dto.useBinary = true;
                        dto.usePassive = true;
                        dto.keepAlive = true;

                        var response = ftpService.UploadAsync(dto).Result;

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
        public class GarbageTicketMagazzinoJob : IJob
        {
            public readonly IServiceProvider _provider;
            public GarbageTicketMagazzinoJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var ftpService = scope.ServiceProvider.GetService<IFtpService>();
                        var garbageService = scope.ServiceProvider.GetService<IGaCrmService>();

                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<ViewGaCrmGarbageTicketMagazzino, GarbageTicketMagazzinoDto>();

                        });

                        IMapper mapper = config.CreateMapper();

                        var view = garbageService.GetViewGaCrmGarbageTicketMagazzinoAsync().Result;
                        var list = mapper.Map<List<GarbageTicketMagazzinoDto>>(view.Data);
                        var csvList = list.ToDelimitedText(";", false, true);

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\EXPORT_TICKET_MAGAZZINO.csv");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        System.IO.File.WriteAllText(fullPath, csvList);

                        FtpUploadDto dto = new FtpUploadDto();
                        dto.serverUri = "gestioneambiente.garbageweb.it/Dati/";
                        dto.filePath = fullPath;
                        dto.fileName = fileName.Replace("Storage\\", "");
                        dto.credentials = new NetworkCredential("GestAmbODL", "G3$a$m2023Xde");
                        dto.useBinary = true;
                        dto.usePassive = true;
                        dto.keepAlive = true;

                        var response = ftpService.UploadAsync(dto).Result;

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
