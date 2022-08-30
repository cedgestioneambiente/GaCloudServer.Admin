using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    public static class FileHelper
    {
        public static string GenerateFileName(string sourceFileName)
        {
            string extension = Path.GetExtension(sourceFileName);
            string fileName = DateTime.Now.ToString("ddMMyyyyHHmmss");
            return fileName + extension;
        }
    }
}
