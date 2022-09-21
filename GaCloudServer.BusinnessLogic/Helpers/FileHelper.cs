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

        public static string FileSizeFormatter(long bytes)
        {
            // Load all suffixes in an array  
            string[] suffixes =
            { "Bytes", "KB", "MB", "GB", "TB", "PB" };
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1}{1}", number, suffixes[counter]);

        }
    }
}
