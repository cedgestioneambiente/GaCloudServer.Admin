using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Ftp;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using sh = GaCloudServer.BusinnessLogic.Helpers.StringHelper;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class FtpService:IFtpService
    {


        public FtpService()
        {

        }

        #region FTP Methods
        public async Task<string> UploadAsync(FtpUploadDto dto)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://" + dto.serverUri + dto.fileName);

            request.Credentials = dto.credentials;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UsePassive = dto.usePassive;
            request.UseBinary = dto.useBinary;
            request.KeepAlive = dto.keepAlive;

            string response = "";

            using (Stream fileStream = System.IO.File.OpenRead(dto.filePath))
            using (Stream ftpStream = request.GetRequestStream())
            {
                byte[] buffer = new byte[10240];
                int read;
                while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ftpStream.Write(buffer, 0, read);
                    Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                    response = string.Format("Uploaded {0} bytes", fileStream.Position);
                }
            }

            return response;


        }

        public async Task<string> DownloadAsync(FtpDownloadDto dto)
        {
            try
            {
                var directoryExist=Directory.Exists(dto.filePath);

                if (!directoryExist)
                {
                    Directory.CreateDirectory(dto.filePath);
                }


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://" + dto.serverUri + dto.fileName);

                request.Credentials = dto.credentials;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UsePassive = dto.usePassive;
                request.UseBinary = dto.useBinary;
                request.KeepAlive = dto.keepAlive;

                string response = "";

                Uri uri = new Uri(@"ftp://" + dto.serverUri + "/Letture/"+dto.fileName);

                using (WebClient client = new WebClient())
                {
                    client.Credentials = dto.credentials;
                    byte[] data = client.DownloadData(uri);

                    File.WriteAllBytes(Path.Combine(dto.filePath,dto.fileName), data);

                }

                

                return response;
            }
            catch (WebException webEx)
            {
                var errorCode=(FtpWebResponse)webEx.Response;
                return errorCode.StatusDescription.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<string> DownloadAndUploadAsync(FtpDownloadAndUploadDto dto)
        {
            try
            {
                var directoryExist = Directory.Exists(dto.filePath);

                if (!directoryExist)
                {
                    Directory.CreateDirectory(dto.filePath);
                }

                FtpWebRequest request = null;

                if (dto.customRoot && dto.customRootPath?.Length > 0)
                {
                    request = (FtpWebRequest)WebRequest.Create(@"ftp://" + dto.serverUploadUri +"//"+ dto.customRootPath + "//" + dto.fileName);
                }
                else
                {
                    request = (FtpWebRequest)WebRequest.Create(@"ftp://" + dto.serverUploadUri + dto.fileName);
                }
                    


                request.Credentials = dto.uploadCredentials;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = dto.usePassive;
                request.UseBinary = dto.useBinary;
                request.KeepAlive = dto.keepAlive;

                string response = "";

                Uri uri;

                if (dto.extraPath != null && !dto.customRoot && dto.extraPath.Length > 0)
                {
                    uri = new Uri(@"ftp://" + dto.serverDownloadUri + "/Letture/" + dto.extraPath + dto.fileName);
                }
                else if (dto.extraPath != null && dto.customRoot && dto.extraPath.Length > 0)
                {
                    uri = new Uri(@"ftp://" + dto.serverDownloadUri+dto.extraPath+dto.fileName);
                }
                else
                {
                    uri = new Uri(@"ftp://" + dto.serverDownloadUri + "/Letture/" + dto.fileName);
                }

               

                using (WebClient client = new WebClient())
                {
                    client.Credentials = dto.downloadCredentials;
                    byte[] data = client.DownloadData(uri);

                    File.WriteAllBytes(Path.Combine(dto.filePath, dto.fileName), data);

                    //Upload File

                    string responseUpload = "";

                    using (Stream fileStream = System.IO.File.OpenRead(Path.Combine(dto.filePath,dto.fileName)))
                    using (Stream ftpStream = request.GetRequestStream())
                    {
                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ftpStream.Write(buffer, 0, read);
                            Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                            response = string.Format("Uploaded {0} bytes", fileStream.Position);
                        }
                    }

                    return response;


                }



                return response;
            }
            catch (WebException webEx)
            {
                var errorCode = (FtpWebResponse)webEx.Response;
                return errorCode.StatusDescription.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<string> MoveAsync(FtpMoveDto dto)
        {
            try {

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://" + dto.serverUri+"/"+dto.sourcefilePath+"/"+dto.fileName);

                request.Credentials = dto.credentials;
                request.Method = WebRequestMethods.Ftp.Rename;
                request.RenameTo = dto.destinationfilePath+"/"+ dto.fileName;
                request.UsePassive = dto.usePassive;
                request.UseBinary = dto.useBinary;
                request.KeepAlive = dto.keepAlive;

                try {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Console.WriteLine("File spostato con successo.");
                    response.Close();
                    return "Ok";
                }
                catch (WebException ex)
                {
                    return "Ko";
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<string>> ReadFolderAsync(FtpFolderDto dto)
        {
            try
            {
                List<string> fileList= new List<string>();

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://" + dto.serverUri + "/" + dto.filePath);

                request.Credentials = dto.credentials;
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.UsePassive = dto.usePassive;
                request.UseBinary = dto.useBinary;
                request.KeepAlive = dto.keepAlive;

                try
                {
                    // Get FTP response
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        // Get the response stream
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            // Read the response stream
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                // Read each line (which represents a file or directory)
                                while (!reader.EndOfStream)
                                {
                                    string line = reader.ReadLine();

                                    fileList.Add(sh.FTPNormalizeFileName(line));
                                }
                            }
                        }
                    }

                    return fileList;
                }
                catch (WebException ex)
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion

    }
}
