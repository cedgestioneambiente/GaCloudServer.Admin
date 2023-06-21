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
        public class EmzWhiteListJob : IJob
        {
            public readonly IServiceProvider _provider;
            public EmzWhiteListJob(IServiceProvider provider)
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
                                   select new CustomDto.EmzDto() { Identi2 = x.Identi2, Chiave1 = x.Chiave1, Attivo = x.Attivo };
                        string csv = "";
                        csv += "BOF" + Environment.NewLine;


                        var csvList = list.ToList().ToDelimitedText(";", false, true);
                        csv += csvList + Environment.NewLine;

                        csv += "EOF";

                        //Creare directory Storage
                        if(!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(),"Storage" )))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Storage"));

                        }
                        var fileName = string.Format("Storage\\Whitelist_Tortona.txt");

                        var fullPath = Path.Combine(Path.GetDirectoryName("Storage"), fileName);

                        File.WriteAllText(fullPath, csv);



                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://gads-novi.myds.me//emz//whitelist_tortona/" + fileName.Replace("Storage\\",""));

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
