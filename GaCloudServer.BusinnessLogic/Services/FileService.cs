using DinkToPdf;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Helpers;
using GaCloudServer.BusinnessLogic.Models;
using GaCloudServer.BusinnessLogic.Providers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using fh = GaCloudServer.BusinnessLogic.Helpers.FileHelper;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class FileService : IFileService
    {
        public FileService() { }
        public async Task<string> CreateSharedLink(string fileId)
        {
            try
            {
                var auth = Authenticate();
                var type = "view";
                var scope = "anonymous";

                var driveRoot = await auth.Drive.Request().GetAsync();

                var result = await auth.Drives[driveRoot.Id].Items[fileId]
                    .CreateLink(type, scope)
                    .Request()
                    .PostAsync();

                return result.Link.WebUrl;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Stream> Download(string folder, string file)
        {
            var result = Authenticate();

            var driveRoot = await result.Drive.Request().GetAsync();
            var driveFolder = await result.Drive.Root.Children.Request().GetAsync();
            var targetFolder = (from x in driveFolder
                                where x.Name == folder
                                select x).FirstOrDefault();

            var fileList = result.Drives[driveRoot.Id].Items[targetFolder.Id].Children.Request().GetAsync().Result;

            var fileToDownload = (from x in fileList
                                  where x.Name == file
                                  select x).FirstOrDefault();

            var stream = result.Drives[driveRoot.Id].Items[fileToDownload.Id].Content.Request().GetAsync().Result;

            return stream;
        }

        public async Task<DownloadFilesModel> DownloadByFolderFileName(string folder,string fileName)
        {
            var auth = Authenticate();

            var driveRoot = await auth.Drive.Request().GetAsync();

            var driveFolder = await auth.Drive.Root.Children.Request().GetAsync();
            var targetFolder = (from x in driveFolder
                                where x.Name == folder
                                select x).FirstOrDefault();

            var query = string.Format("startWith(name,'{0}')", fileName);

            var fileItems = await auth
                    .Sites["root"]
                    .Drives[driveRoot.Id]
                    .Items[targetFolder.Id]
                    .Children
                    .Request()
                    .Filter($"name eq '{fileName}'")
                    .GetAsync();
            DriveItem file = null;
            foreach (var item in fileItems)
            {
                if (item.Name == fileName)
                {
                    file = item;
                }
            }

            var stream = auth.Drives[driveRoot.Id].Items[file.Id].Content.Request().GetAsync().Result;

            return new DownloadFilesModel() { stream = stream, fileName = file.Name };
        }

        public async Task<DownloadFilesModel> DownloadById(string fileId)
        {
            var result = Authenticate();

            var driveRoot = await result.Drive.Request().GetAsync();

            var fileItem = result.Drives[driveRoot.Id].Items[fileId].Request().GetAsync().Result;
            var stream = result.Drives[driveRoot.Id].Items[fileId].Content.Request().GetAsync().Result;

            return new DownloadFilesModel() { stream = stream, fileName = fileItem.Name };
        }



        public async Task<bool> Remove(string fileId)
        {
            try
            {
                var result = Authenticate();

                var driveRoot = await result.Drive.Request().GetAsync();

                await result.Drives[driveRoot.Id].Items[fileId].Request().DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<UploadFileResponseModel> Upload(IFormFile file, string folder, string fileName)
        {
            try
            {
                fileName = fh.GenerateFileName(fileName);
                IFormFile fileToUpload = file;
                Stream ms = new MemoryStream();

                var subfolder = folder.Split("/").Count();

                DriveItem uploadedFile = null;
                var auth = Authenticate();
                var driveRoot = await auth.Drive.Request().GetAsync();
                var driveFolder = await auth.Drive.Root.Children.Request().GetAsync();

                DriveItem? targetFolder = null;

                if (subfolder > 1)
                {
                    DriveItem? parentFolder = null;
                    for (int i = 0; i < subfolder; i++)
                    {
                        
                        if (i == 0)
                        {
                            parentFolder = (from x in driveFolder
                                            where x.Name == folder.Split("/")[i].ToString()
                                            select x).FirstOrDefault();
                            if (parentFolder == null)
                            {
                                var _folder = new DriveItem
                                {
                                    Name = folder.Split("/")[i].ToString(),
                                    Folder = new Folder()
                                };

                                var createFolder = await auth
                                    .Sites["root"]
                                    .Drives[driveRoot.Id]
                                    .Root
                                    .Children
                                    .Request()
                                    .AddAsync(_folder);

                                parentFolder = createFolder;
                            }
                        }
                        else
                        {
                            var parentChildren = await auth
                           .Sites["root"]
                           .Drives[driveRoot.Id]
                           .Items[parentFolder.Id]
                           .Children
                           .Request()
                           .Filter($"name eq '{folder.Split("/")[i].ToString()}'")
                           .GetAsync();

                            var childrenFolder = (from x in parentChildren
                                                  where x.Name == folder.Split("/")[i].ToString()
                                                  select x).FirstOrDefault();

                            if (childrenFolder == null)
                            {
                                var _folder = new DriveItem
                                {
                                    Name = folder.Split("/")[i].ToString(),
                                    Folder = new Folder()
                                };

                                var createFolder = await auth
                                    .Sites["root"]
                                    .Drives[driveRoot.Id]
                                    .Items[parentFolder.Id]
                                    .Children
                                    .Request()
                                    .AddAsync(_folder);
                                parentFolder = createFolder;
                                targetFolder = createFolder;
                            }
                            else
                            {
                                parentFolder = childrenFolder;
                                targetFolder = childrenFolder;
                            }

                        }
                    }

                }
                else
                {
                    targetFolder = (from x in driveFolder
                                    where x.Name == folder
                                    select x).FirstOrDefault();

                    if (targetFolder == null)
                    {
                        var _folder = new DriveItem
                        {
                            Name = folder,
                            Folder = new Folder()
                        };

                        var createFolder = await auth
                            .Sites["root"]
                            .Drives[driveRoot.Id]
                            .Root
                            .Children
                            .Request()
                            .AddAsync(_folder);

                        targetFolder = createFolder;

                    }
                }


                using (ms = new MemoryStream())
                {
                    await fileToUpload.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    var buf2 = new byte[ms.Length];
                    ms.Read(buf2, 0, buf2.Length);

                    ms.Position = 0; // Very important!! to set the position at the beginning of the stream

                    if (fileToUpload.Length <= 4000 * 1024)
                    {
                        uploadedFile = (
                        auth
                        .Sites["root"]
                        .Drives[driveRoot.Id]
                        .Items[targetFolder.Id]
                        .ItemWithPath(fileName)
                        .Content.Request()
                        .PutAsync<DriveItem>(ms)).Result;

                        return new UploadFileResponseModel() { id=uploadedFile.Id,fileName=fileName };
                    }
                    else
                    {
                        var uploadSession = await auth
                        .Sites["root"]
                        .Drives[driveRoot.Id]
                        .Items[targetFolder.Id]
                        .ItemWithPath(fileName)
                        .CreateUploadSession().Request().PostAsync();

                        var maxChunkSize = 320 * 1024;
                        var provider = new ChunkedUploadProvider(uploadSession, auth, ms, maxChunkSize);

                        // Setup the chunk request necessities
                        var chunkRequests = provider.GetUploadChunkRequests();
                        var readBuffer = new byte[maxChunkSize];
                        var trackedExceptions = new List<Exception>();
                        DriveItem itemResult = null;

                        //upload the chunks
                        foreach (var request in chunkRequests)
                        {
                            // Do your updates here: update progress bar, etc.
                            // ...
                            // Send chunk request
                            var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);

                            if (result.UploadSucceeded)
                            {
                                itemResult = result.ItemResponse;
                            }
                        }

                        // Check that upload succeeded
                        if (itemResult == null)
                        {
                            // Retry the upload
                            // ...
                            return null;
                        }
                        else
                        {
                            return new UploadFileResponseModel() { id = itemResult.Id, fileName = fileName };
                        }
                    }


                }
            }
            
            catch (Exception ex)
            {
                throw;
            }

                
        }

        public async Task<UploadFileResponseModel> UploadStream(MemoryStream stream, string folder, string fileName)
        {
            try
            {
                Stream ms = new MemoryStream();

                var subfolder = folder.Split("/").Count();

                DriveItem uploadedFile = null;
                var auth = Authenticate();
                var driveRoot = await auth.Drive.Request().GetAsync();
                var driveFolder = await auth.Drive.Root.Children.Request().GetAsync();

                DriveItem? targetFolder = null;

                if (subfolder > 1)
                {
                    DriveItem? parentFolder = null;
                    for (int i = 0; i < subfolder; i++)
                    {

                        if (i == 0)
                        {
                            parentFolder = (from x in driveFolder
                                            where x.Name == folder.Split("/")[i].ToString()
                                            select x).FirstOrDefault();
                            if (parentFolder == null)
                            {
                                var _folder = new DriveItem
                                {
                                    Name = folder.Split("/")[i].ToString(),
                                    Folder = new Folder()
                                };

                                var createFolder = await auth
                                    .Sites["root"]
                                    .Drives[driveRoot.Id]
                                    .Root
                                    .Children
                                    .Request()
                                    .AddAsync(_folder);

                                parentFolder = createFolder;
                            }
                        }
                        else
                        {
                            var parentChildren = await auth
                           .Sites["root"]
                           .Drives[driveRoot.Id]
                           .Items[parentFolder.Id]
                           .Children
                           .Request()
                           .Filter($"name eq '{folder.Split("/")[i].ToString()}'")
                           .GetAsync();

                            var childrenFolder = (from x in parentChildren
                                                  where x.Name == folder.Split("/")[i].ToString()
                                                  select x).FirstOrDefault();

                            if (childrenFolder == null)
                            {
                                var _folder = new DriveItem
                                {
                                    Name = folder.Split("/")[i].ToString(),
                                    Folder = new Folder()
                                };

                                var createFolder = await auth
                                    .Sites["root"]
                                    .Drives[driveRoot.Id]
                                    .Items[parentFolder.Id]
                                    .Children
                                    .Request()
                                    .AddAsync(_folder);
                                parentFolder = createFolder;
                                targetFolder = createFolder;
                            }
                            else
                            {
                                parentFolder = childrenFolder;
                                targetFolder = childrenFolder;
                            }

                        }
                    }

                }
                else
                {
                    targetFolder = (from x in driveFolder
                                    where x.Name == folder
                                    select x).FirstOrDefault();

                    if (targetFolder == null)
                    {
                        var _folder = new DriveItem
                        {
                            Name = folder,
                            Folder = new Folder()
                        };

                        var createFolder = await auth
                            .Sites["root"]
                            .Drives[driveRoot.Id]
                            .Root
                            .Children
                            .Request()
                            .AddAsync(_folder);

                        targetFolder = createFolder;

                    }
                }



                if (stream.Length <= 4000 * 1024)
                {
                    uploadedFile = (
                    auth
                    .Sites["root"]
                    .Drives[driveRoot.Id]
                    .Items[targetFolder.Id]
                    .ItemWithPath(fileName)
                    .Content.Request()
                    .PutAsync<DriveItem>(stream)).Result;

                    return new UploadFileResponseModel() { id = uploadedFile.Id, fileName = fileName };
                }
                else
                {
                    var uploadSession = await auth
                    .Sites["root"]
                    .Drives[driveRoot.Id]
                    .Items[targetFolder.Id]
                    .ItemWithPath(fileName)
                    .CreateUploadSession().Request().PostAsync();

                    var maxChunkSize = 320 * 1024;
                    var provider = new ChunkedUploadProvider(uploadSession, auth, stream, maxChunkSize);

                    // Setup the chunk request necessities
                    var chunkRequests = provider.GetUploadChunkRequests();
                    var readBuffer = new byte[maxChunkSize];
                    var trackedExceptions = new List<Exception>();
                    DriveItem itemResult = null;

                    //upload the chunks
                    foreach (var request in chunkRequests)
                    {
                        // Do your updates here: update progress bar, etc.
                        // ...
                        // Send chunk request
                        var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);

                        if (result.UploadSucceeded)
                        {
                            itemResult = result.ItemResponse;
                        }
                    }

                    // Check that upload succeeded
                    if (itemResult == null)
                    {
                        // Retry the upload
                        // ...
                        return null;
                    }
                    else
                    {
                        return new UploadFileResponseModel() { id = itemResult.Id, fileName = fileName,fileSize=stream.Length.ToString() };
                    }
                }


                
            }

            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<DriveItem> UploadImage(MemoryStream stream, string _mainFolder, string _targetFolder, string fileName)
        {
            fileName = fh.GenerateFileName(fileName);
            DriveItem uploadedFile = null;
            var auth = Authenticate();

            var driveRoot = await auth.Drive.Request().GetAsync();
            var driveFolder = await auth.Drive.Root.Children.Request().GetAsync();
            var mainFolder = (from x in driveFolder
                              where x.Name == _mainFolder
                              select x).FirstOrDefault();
            if (mainFolder == null)
            {
                var _folder = new DriveItem
                {
                    Name = _mainFolder,
                    Folder = new Folder()
                };

                var createFolder = await auth
                    .Sites["root"]
                    .Drives[driveRoot.Id]
                    .Root
                    .Children
                    .Request()
                    .AddAsync(_folder);

                mainFolder = createFolder;

            }
            var mainFolderList = auth.Drives[driveRoot.Id].Items[mainFolder.Id].Children.Request().Filter($"name eq '{_targetFolder}'").GetAsync().Result;

            var targetFolder = (from x in mainFolderList
                                where x.Name == _targetFolder
                                select x).FirstOrDefault();

            if (targetFolder == null)
            {
                var _folder = new DriveItem
                {
                    Name = _targetFolder,
                    Folder = mainFolder.Folder
                };

                var createFolder = await auth
                    .Sites["root"]
                    .Drives[driveRoot.Id]
                    .Items[mainFolder.Id]
                    .Children
                    .Request()
                    .AddAsync(_folder);

                targetFolder = createFolder;

            }


            uploadedFile = (
                    auth
                    .Sites["root"]
                    .Drives[driveRoot.Id]
                    .Items[targetFolder.Id]
                    .ItemWithPath(fileName)
                    .Content.Request()
                    .PutAsync<DriveItem>(stream)).Result;

            return uploadedFile;
        }
        public async Task<List<ItemDto>> GetRootFolderByName(string folder)
        {
            var sp = Authenticate();
            var driveRoot = await sp.Drive.Request().GetAsync();
            var driveFolder = await sp.Drive.Root.Children.Request().GetAsync();
            var sourceFolder = (from x in driveFolder
                                where x.Name == folder
                                select x).FirstOrDefault();
            var children = await sp.Drives[driveRoot.Id].Items[sourceFolder.Id].Children
                .Request()
                .GetAsync();

            var result = new List<ItemDto>();
            foreach (var itm in children)
            {
                var item = new ItemDto();
                item.name = itm.Name.Substring(itm.Name.IndexOf("_") + 1);
                item.id = itm.Id;
                item.webUrl = itm.WebUrl;
                item.createdAt = itm.CreatedDateTime.GetValueOrDefault().ToString("dd/MM/yyyy");
                item.size = FileHelper.FileSizeFormatter(itm.Size.GetValueOrDefault());

                if (itm.Folder != null && itm.Name != "Thumbs.db")
                {
                    item.type = "folder";
                    item.contents = itm.Folder?.ChildCount > 1 ? string.Format("{0} elementi", itm.Folder?.ChildCount) : string.Format("{0} elemento", itm.Folder?.ChildCount);
                    result.Add(item);
                }
                else if (itm.File != null && itm.Name != "Thumbs.db")
                {
                    item.type = Path.GetExtension(itm.Name).GetFileType();
                    result.Add(item);
                }


            }

            return result;


        }
        public async Task<List<ItemDto>> GetFolderContentById(string folderId,List<ItemDto> path)
        {
            var sp = Authenticate();
            var driveRoot = await sp.Drive.Request().GetAsync();
            var driveFolder = await sp.Drive.Root.Children.Request().GetAsync();
            var children = await sp.Drives[driveRoot.Id].Items[folderId].Children
                .Request()
                .GetAsync();

            var header = await sp.Drives[driveRoot.Id].Items[folderId].Request().GetAsync();
            var parentFolder = await sp.Drives[driveRoot.Id].Items[header.ParentReference.Id].Request().GetAsync();


            var result = path;
            foreach (var itm in children)
            {
                var item = new ItemDto();
                item.name = itm.Name.Substring(itm.Name.IndexOf("_") + 1);
                item.id = itm.Id;
                item.webUrl = itm.WebUrl;
                item.createdAt = itm.CreatedDateTime.GetValueOrDefault().ToString("dd/MM/yyyy");
                item.size = FileHelper.FileSizeFormatter(itm.Size.GetValueOrDefault());

                if (itm.Folder != null && itm.Name != "Thumbs.db")
                {
                    item.type = "folder";
                    item.folderId = folderId;
                    item.contents = itm.Folder?.ChildCount>1? string.Format("{0} elementi", itm.Folder?.ChildCount): string.Format("{0} elemento", itm.Folder?.ChildCount);
                    result.Add(item);
                }
                else if (itm.File != null && itm.Name != "Thumbs.db")
                {
                    item.type = Path.GetExtension(itm.Name).GetFileType();
                    item.folderId = folderId;
                    result.Add(item);
                }


            }

            return result;

        }
        private GraphServiceClient Authenticate()
        {
            var clientId = GraphConsts.clientId;
            var clientSecret = GraphConsts.clientSecret;
            var redirectUri = GraphConsts.redirectUri;
            var authority = GraphConsts.authority;
            var cca = ConfidentialClientApplicationBuilder.Create(clientId)
                                                          .WithAuthority(authority)
                                                          .WithRedirectUri(redirectUri)
                                                          .WithClientSecret(clientSecret)
                                                          .Build();


            // use the default permissions assigned from within the Azure AD app registration portal
            List<string> scopes = new List<string>();
            scopes.Add("https://graph.microsoft.com/.default");

            var authenticationProvider = new MsalAuthenticationProvider(cca, scopes.ToArray());
            GraphServiceClient graphClient = new GraphServiceClient(authenticationProvider);
            return graphClient;

        }

        //public dynamic UploadOnServerReport(string _fileName, string _path, string _htmlContent, string title = "", string css = "", Orientation orientation = Orientation.Portrait)
        //{
        //    string filePath = Path.Combine(_webRootPath, _path, _fileName);

        //    var globalSettings = new GlobalSettings
        //    {
        //        ColorMode = ColorMode.Color,
        //        Orientation = orientation,
        //        PaperSize = PaperKind.A4,
        //        Margins = new MarginSettings { Top = 10 },
        //        DocumentTitle = "PDF Report",
        //        Out = filePath
        //    };

        //    var objectSettings = new ObjectSettings
        //    {
        //        PagesCount = true,
        //        HtmlContent = _htmlContent,
        //        WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Report/" + css + "/assets", "styles.css") },
        //        HeaderSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = "Pagina [page] di [toPage]", Line = true },
        //        FooterSettings = { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true, Center = title }
        //    };

        //    var pdf = new HtmlToPdfDocument()
        //    {
        //        GlobalSettings = globalSettings,
        //        Objects = { objectSettings }
        //    };

        //    var directoryExist = Directory.Exists(Path.Combine(_webRootPath, _path));

        //    if (!directoryExist)
        //    {
        //        Directory.CreateDirectory(Path.Combine(_webRootPath, _path));
        //    }


        //    var result = _converter.Convert(pdf);

        //    return MakeWebPath(Path.Combine(_webPath, _path, _fileName));
        //}

    }
}
