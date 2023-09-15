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

namespace GaCloudServer.BusinnessLogic.Services
{
    public class FtpService:IFtpService
    {


        public FtpService()
        {

        }

        #region FtpUpload
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


        #endregion

    }
}
