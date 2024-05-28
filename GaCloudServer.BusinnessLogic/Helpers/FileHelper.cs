using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static CommonFileUploadDto CreateFileData(IFormFile file, string fileName, string pathToStore)
        {
            CommonFileUploadDto fileData = new CommonFileUploadDto();
            fileData.FileDetails = file;
            fileData.FileName = string.Concat(fileName, Path.GetExtension(file.FileName));
            fileData.FilePath = pathToStore;
            fileData.FileSize = file.Length;
            fileData.FileContentType = file.ContentType;
            fileData.FileExtension = Path.GetExtension(file.FileName);

            return fileData;

        }

        public static CommonFileDeleteDto DeleteFileData(string fileName, string filePath)
        {
            CommonFileDeleteDto fileData = new CommonFileDeleteDto();
            fileData.FileName = string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(fileName));
            fileData.FilePath = filePath;
            fileData.FileExtension = Path.GetExtension(fileName);

            return fileData;

        }

        public static T ToCreateFileModel<T>(this T model, long id, string fileName, string baseFolder, string subFolder)
    where T : class
        {
            var fileId = string.Concat(id, Path.GetExtension(fileName));
            var fileFolder = string.Concat(baseFolder, "/", subFolder);

            // Ottenere le proprietà del modello tramite reflection
            var properties = typeof(T).GetProperties();

            // Copia il modello in un nuovo oggetto
            var newModel = Activator.CreateInstance<T>();

            foreach (var property in properties)
            {
                // Copia il valore della proprietà dal modello originale al nuovo modello
                property.SetValue(newModel, property.GetValue(model));
            }

            // Aggiorna le proprietà specifiche
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                idProperty.SetValue(newModel, id);
            }

            var fileIdProperty = typeof(T).GetProperty("FileId");
            if (fileIdProperty != null)
            {
                fileIdProperty.SetValue(newModel, fileId);
            }

            var fileFolderProperty = typeof(T).GetProperty("FileFolder");
            if (fileFolderProperty != null)
            {
                fileFolderProperty.SetValue(newModel, fileFolder);
            }

            return newModel;
        }

        public static T ToDeleteFileModel<T>(this T model)
            where T : class
        {
            // Ottenere le proprietà del modello tramite reflection
            var properties = typeof(T).GetProperties();

            // Copia il modello in un nuovo oggetto
            var newModel = Activator.CreateInstance<T>();

            foreach (var property in properties)
            {
                // Copia il valore della proprietà dal modello originale al nuovo modello
                property.SetValue(newModel, property.GetValue(model));
            }

            // Aggiorna le proprietà specifiche

            var fileIdProperty = typeof(T).GetProperty("FileId");
            if (fileIdProperty != null)
            {
                fileIdProperty.SetValue(newModel, null);
            }

            var fileFolderProperty = typeof(T).GetProperty("FileFolder");
            if (fileFolderProperty != null)
            {
                fileFolderProperty.SetValue(newModel, null);
            }

            var fileNameProperty = typeof(T).GetProperty("FileName");
            if (fileNameProperty != null)
            {
                fileNameProperty.SetValue(newModel, null);
            }

            var fileSizeProperty = typeof(T).GetProperty("FileSize");
            if (fileSizeProperty != null)
            {
                fileSizeProperty.SetValue(newModel, null);
            }

            var fileTypeProperty = typeof(T).GetProperty("FileType");
            if (fileTypeProperty != null)
            {
                fileTypeProperty.SetValue(newModel, null);
            }

            return newModel;
        }
    }
}
