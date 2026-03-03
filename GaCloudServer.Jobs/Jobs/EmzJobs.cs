using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Jobs.Dtos;
using GaCloudServer.Jobs.Helpers;
using Quartz;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;


namespace GaCloudServer.Jobs.Jobs
{
    public static class EmzJobs
    {

        [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class EmzWhiteList80Job : IJob
        {
            public readonly IServiceProvider _provider;
            public EmzWhiteList80Job(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var mailService = scope.ServiceProvider.GetService<IMailService>();
                        var emzService = scope.ServiceProvider.GetService<IEmzService>();
                        var templ_list = emzService.GetViewEmzWhiteListAsync().Result;
                        var list = from x in  templ_list.Data
                                   select new CustomDto.EmzDto() { Identi2 = x.Identi2, Chiave1 = x.Chiave1, Attivo = x.Attivo};
                        string csv = "";
                        csv += "BOF" + Environment.NewLine;


                        var csvList = list.Where(x=>x.Identi2.StartsWith("80")).ToList().ToDelimitedText(";", false, true);
                        csv += csvList + Environment.NewLine;

                        csv += "EOF";

                        //Creare directory Storage
                        if(!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(),"Storage" )))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\80_Whitelist_Tortona.txt");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        File.WriteAllText(fullPath, csv);



                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://20.82.78.5//emz//whitelist_tortona/80/" + fileName.Replace("Storage\\",""));

                        request.Credentials = new NetworkCredential("emz", "nx*@TYHv8L6HJ9q7");
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.UsePassive = true;
                        request.UseBinary = true;
                        request.KeepAlive = true;
                        

                        using (Stream fileStream = File.OpenRead(Path.GetFullPath(fileName)))
                        using (Stream ftpStream = request.GetRequestStream())
                        {
                            byte[] buffer = new byte[10240];
                            int read;
                            while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ftpStream.Write(buffer, 0, read);
                                Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                            }
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
        public class EmzWhiteListACJob : IJob
        {
            public readonly IServiceProvider _provider;
            public EmzWhiteListACJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            public Task Execute(IJobExecutionContext context)
            {
                try
                {
                    using (var scope = _provider.CreateScope())
                    {

                        var mailService = scope.ServiceProvider.GetService<IMailService>();
                        var emzService = scope.ServiceProvider.GetService<IEmzService>();
                        var templ_list = emzService.GetViewEmzWhiteListAsync().Result;
                        var list = from x in templ_list.Data
                                   select new CustomDto.EmzACDto() { Identi2 = x.Identi2, Chiave1 = x.Chiave1, Attivo = x.Attivo, CharCeck = "1" };
                        string csv = "";
                        csv += "BOF" + Environment.NewLine;


                        var csvList = list.Where(x => x.Identi2.StartsWith("AC")).ToList().ToDelimitedText(";", false, true);
                        csv += csvList + Environment.NewLine;

                        csv += "EOF";

                        //Creare directory Storage
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Storage")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\AC_Whitelist_Tortona.txt");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        File.WriteAllText(fullPath, csv);



                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://20.82.78.5//emz//whitelist_tortona/AC/" + fileName.Replace("Storage\\", ""));

                        request.Credentials = new NetworkCredential("emz", "nx*@TYHv8L6HJ9q7");
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.UsePassive = true;
                        request.UseBinary = true;
                        request.KeepAlive = true;


                        using (Stream fileStream = File.OpenRead(Path.GetFullPath(fileName)))
                        using (Stream ftpStream = request.GetRequestStream())
                        {
                            byte[] buffer = new byte[10240];
                            int read;
                            while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ftpStream.Write(buffer, 0, read);
                                Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                            }
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
