using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Extensions
{
    public static class FileExtensions
    {
        public static string GetFileType(this string text)
        {
            switch (text)
            {
                case ".pdf":
                    return "PDF";
                case ".xls":
                case ".xlsx":
                case ".ods":
                    return "XLS";
                case ".doc":
                case ".docx":
                    return "DOC";
                case ".lnk":
                    return "LINK";
                case ".txt":
                    return "TEXT";
                default:
                    return "NONE";
            }
        }
    }
}
