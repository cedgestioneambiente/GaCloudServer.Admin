using DinkToPdf;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Helpers;
using GaCloudServer.BusinnessLogic.Models;
using GaCloudServer.BusinnessLogic.Providers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Text;
using fh = GaCloudServer.BusinnessLogic.Helpers.FileHelper;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class FileService : IFileService
    {
        public FileService() { }

        #region Download
        //Refactor 09052025
        public async Task<DownloadFilesModel> DownloadById(string fileId)
        {
            var client = AuthenticateV2(); // Usa il tuo metodo aggiornato di autenticazione

            //  Ottieni il drive corretto (la libreria "Documenti")
            var drive = await GetDriveFromRootSiteAsync(client);

            // Recupera il file
            var fileItem = await client.Drives[drive.Id].Items[fileId]
                .Request()
                .GetAsync();

            var stream = await client.Drives[drive.Id].Items[fileId]
                .Content
                .Request()
                .GetAsync();

            return new DownloadFilesModel
            {
                stream = stream,
                fileName = fileItem.Name
            };
        }

        #endregion

        #region Upload Methods
        //refactored 09052025
        public async Task<UploadFileResponseModel> Upload(IFormFile file, string folder, string fileName)
        {
            try
            {
                fileName = fh.GenerateFileName(fileName);
                IFormFile fileToUpload = file;
                Stream ms = new MemoryStream();

                var subfolder = folder.Split("/").Count();

                DriveItem uploadedFile = null;
                var auth = AuthenticateV2();

                // ✅ Recupera il drive corretto della document library "Documenti condivisi"
                var driveRoot = await GetDriveFromRootSiteAsync(auth);

                // ✅ Recupera la root directory del drive tramite ID
                var driveFolder = await auth.Drives[driveRoot.Id].Root.Children.Request().GetAsync();

                DriveItem? targetFolder = null;

                if (subfolder > 1)
                {
                    DriveItem? parentFolder = null;
                    for (int i = 0; i < subfolder; i++)
                    {
                        string folderName = folder.Split("/")[i];

                        if (i == 0)
                        {
                            parentFolder = driveFolder.FirstOrDefault(x => x.Name == folderName);
                            if (parentFolder == null)
                            {
                                var newFolder = new DriveItem
                                {
                                    Name = folderName,
                                    Folder = new Folder()
                                };

                                parentFolder = await auth.Drives[driveRoot.Id].Root.Children
                                    .Request()
                                    .AddAsync(newFolder);
                            }
                        }
                        else
                        {
                            var parentChildren = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                                .Children
                                .Request()
                                .Filter($"name eq '{folderName}'")
                                .GetAsync();

                            var childFolder = parentChildren.FirstOrDefault(x => x.Name == folderName);

                            if (childFolder == null)
                            {
                                var newFolder = new DriveItem
                                {
                                    Name = folderName,
                                    Folder = new Folder()
                                };

                                parentFolder = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                                    .Children
                                    .Request()
                                    .AddAsync(newFolder);

                                targetFolder = parentFolder;
                            }
                            else
                            {
                                parentFolder = childFolder;
                                targetFolder = childFolder;
                            }
                        }
                    }
                }
                else
                {
                    targetFolder = driveFolder.FirstOrDefault(x => x.Name == folder);

                    if (targetFolder == null)
                    {
                        var newFolder = new DriveItem
                        {
                            Name = folder,
                            Folder = new Folder()
                        };

                        targetFolder = await auth.Drives[driveRoot.Id].Root.Children
                            .Request()
                            .AddAsync(newFolder);
                    }
                }

                using (ms = new MemoryStream())
                {
                    await fileToUpload.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    ms.Position = 0; // Imposta posizione all'inizio

                    if (fileToUpload.Length <= 4 * 1024 * 1024)
                    {
                        uploadedFile = await auth
                            .Drives[driveRoot.Id]
                            .Items[targetFolder.Id]
                            .ItemWithPath(fileName)
                            .Content
                            .Request()
                            .PutAsync<DriveItem>(ms);

                        return new UploadFileResponseModel() { id = uploadedFile.Id, fileName = fileName };
                    }
                    else
                    {
                        var uploadSession = await auth
                            .Drives[driveRoot.Id]
                            .Items[targetFolder.Id]
                            .ItemWithPath(fileName)
                            .CreateUploadSession()
                            .Request()
                            .PostAsync();

                        var maxChunkSize = 320 * 1024;
                        var provider = new ChunkedUploadProvider(uploadSession, auth, ms, maxChunkSize);

                        var chunkRequests = provider.GetUploadChunkRequests();
                        var readBuffer = new byte[maxChunkSize];
                        var trackedExceptions = new List<Exception>();
                        DriveItem itemResult = null;

                        foreach (var request in chunkRequests)
                        {
                            var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);
                            if (result.UploadSucceeded)
                                itemResult = result.ItemResponse;
                        }

                        if (itemResult == null)
                            return null;

                        return new UploadFileResponseModel() { id = itemResult.Id, fileName = fileName };
                    }
                }
            }
            catch (Exception ex)
            {
                throw; // Puoi aggiungere log o gestione errore specifica se preferisci
            }
        }

        //Refactored 09052025
        public async Task<UploadFileResponseModel> Upload(CommonFileUploadDto fileModel)
        {
            try
            {
                fileModel.FileName = fh.GenerateFileName(fileModel.FileName);
                IFormFile fileToUpload = fileModel.FileDetails;
                Stream ms = new MemoryStream();

                var subfolder = fileModel.FilePath.Split("/").Count();

                DriveItem uploadedFile = null;
                var auth = AuthenticateV2(); // ✅ tua nuova autenticazione con client credentials
                var driveRoot = await GetDriveFromRootSiteAsync(auth); // ✅ drive della libreria "Documenti"
                var driveFolder = await auth.Drives[driveRoot.Id].Root.Children.Request().GetAsync();

                DriveItem? targetFolder = null;

                if (subfolder > 1)
                {
                    DriveItem? parentFolder = null;
                    for (int i = 0; i < subfolder; i++)
                    {
                        string folderName = fileModel.FilePath.Split("/")[i];

                        if (i == 0)
                        {
                            parentFolder = driveFolder.FirstOrDefault(x => x.Name == folderName);
                            if (parentFolder == null)
                            {
                                var newFolder = new DriveItem
                                {
                                    Name = folderName,
                                    Folder = new Folder()
                                };

                                parentFolder = await auth.Drives[driveRoot.Id].Root.Children
                                    .Request()
                                    .AddAsync(newFolder);
                            }
                        }
                        else
                        {
                            var children = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                                .Children
                                .Request()
                                .Filter($"name eq '{folderName}'")
                                .GetAsync();

                            var existing = children.FirstOrDefault(x => x.Name == folderName);

                            if (existing == null)
                            {
                                var newFolder = new DriveItem
                                {
                                    Name = folderName,
                                    Folder = new Folder()
                                };

                                parentFolder = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                                    .Children
                                    .Request()
                                    .AddAsync(newFolder);

                                targetFolder = parentFolder;
                            }
                            else
                            {
                                parentFolder = existing;
                                targetFolder = existing;
                            }
                        }
                    }
                }
                else
                {
                    targetFolder = driveFolder.FirstOrDefault(x => x.Name == fileModel.FilePath);
                    if (targetFolder == null)
                    {
                        var newFolder = new DriveItem
                        {
                            Name = fileModel.FilePath,
                            Folder = new Folder()
                        };

                        targetFolder = await auth.Drives[driveRoot.Id].Root.Children
                            .Request()
                            .AddAsync(newFolder);
                    }
                }

                using (ms = new MemoryStream())
                {
                    await fileToUpload.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Position = 0;

                    if (fileToUpload.Length <= 4 * 1024 * 1024)
                    {
                        uploadedFile = await auth
                            .Drives[driveRoot.Id]
                            .Items[targetFolder.Id]
                            .ItemWithPath(fileModel.FileName)
                            .Content
                            .Request()
                            .PutAsync<DriveItem>(ms);

                        return new UploadFileResponseModel
                        {
                            id = uploadedFile.Id,
                            fileName = fileModel.FileName
                        };
                    }
                    else
                    {
                        var uploadSession = await auth
                            .Drives[driveRoot.Id]
                            .Items[targetFolder.Id]
                            .ItemWithPath(fileModel.FileName)
                            .CreateUploadSession()
                            .Request()
                            .PostAsync();

                        var maxChunkSize = 320 * 1024;
                        var provider = new ChunkedUploadProvider(uploadSession, auth, ms, maxChunkSize);

                        var chunkRequests = provider.GetUploadChunkRequests();
                        var readBuffer = new byte[maxChunkSize];
                        var trackedExceptions = new List<Exception>();
                        DriveItem itemResult = null;

                        foreach (var request in chunkRequests)
                        {
                            var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);
                            if (result.UploadSucceeded)
                                itemResult = result.ItemResponse;
                        }

                        if (itemResult == null)
                            return null;

                        return new UploadFileResponseModel
                        {
                            id = itemResult.Id,
                            fileName = fileModel.FileName
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw; // puoi loggare ex.Message qui se necessario
            }
        }

        //Refactored 09052025
        public async Task<UploadFileResponseModel> UploadStream(MemoryStream stream, string folder, string fileName)
        {
            try
            {
                var auth = AuthenticateV2();
                var driveRoot = await GetDriveFromRootSiteAsync(auth);
                var driveFolder = await auth.Drives[driveRoot.Id].Root.Children.Request().GetAsync();

                var subfolder = folder.Split("/").Count();
                DriveItem? targetFolder = null;

                if (subfolder > 1)
                {
                    DriveItem? parentFolder = null;
                    for (int i = 0; i < subfolder; i++)
                    {
                        string folderName = folder.Split("/")[i];

                        if (i == 0)
                        {
                            parentFolder = driveFolder.FirstOrDefault(x => x.Name == folderName);
                            if (parentFolder == null)
                            {
                                var newFolder = new DriveItem
                                {
                                    Name = folderName,
                                    Folder = new Folder()
                                };

                                parentFolder = await auth.Drives[driveRoot.Id].Root.Children
                                    .Request()
                                    .AddAsync(newFolder);
                            }
                        }
                        else
                        {
                            var children = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                                .Children
                                .Request()
                                .Filter($"name eq '{folderName}'")
                                .GetAsync();

                            var existing = children.FirstOrDefault(x => x.Name == folderName);

                            if (existing == null)
                            {
                                var newFolder = new DriveItem
                                {
                                    Name = folderName,
                                    Folder = new Folder()
                                };

                                parentFolder = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                                    .Children
                                    .Request()
                                    .AddAsync(newFolder);

                                targetFolder = parentFolder;
                            }
                            else
                            {
                                parentFolder = existing;
                                targetFolder = existing;
                            }
                        }
                    }
                }
                else
                {
                    targetFolder = driveFolder.FirstOrDefault(x => x.Name == folder);
                    if (targetFolder == null)
                    {
                        var newFolder = new DriveItem
                        {
                            Name = folder,
                            Folder = new Folder()
                        };

                        targetFolder = await auth.Drives[driveRoot.Id].Root.Children
                            .Request()
                            .AddAsync(newFolder);
                    }
                }

                // Upload diretto o chunked in base alla dimensione
                if (stream.Length <= 4 * 1024 * 1024)
                {
                    var uploadedFile = await auth
                        .Drives[driveRoot.Id]
                        .Items[targetFolder.Id]
                        .ItemWithPath(fileName)
                        .Content
                        .Request()
                        .PutAsync<DriveItem>(stream);

                    return new UploadFileResponseModel
                    {
                        id = uploadedFile.Id,
                        fileName = fileName
                    };
                }
                else
                {
                    var uploadSession = await auth
                        .Drives[driveRoot.Id]
                        .Items[targetFolder.Id]
                        .ItemWithPath(fileName)
                        .CreateUploadSession()
                        .Request()
                        .PostAsync();

                    var maxChunkSize = 320 * 1024;
                    var provider = new ChunkedUploadProvider(uploadSession, auth, stream, maxChunkSize);
                    var chunkRequests = provider.GetUploadChunkRequests();
                    var readBuffer = new byte[maxChunkSize];
                    var trackedExceptions = new List<Exception>();
                    DriveItem itemResult = null;

                    foreach (var request in chunkRequests)
                    {
                        var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);
                        if (result.UploadSucceeded)
                            itemResult = result.ItemResponse;
                    }

                    if (itemResult == null)
                        return null;

                    return new UploadFileResponseModel
                    {
                        id = itemResult.Id,
                        fileName = fileName,
                        fileSize = stream.Length.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Refactored 09052025
        public async Task<UploadFileResponseModel> UploadText(string content, string folder, string fileName)
        {
            try
            {
                fileName = fh.GenerateFileName(fileName);
                var auth = AuthenticateV2();
                var driveRoot = await GetDriveFromRootSiteAsync(auth);
                var driveFolder = await auth.Drives[driveRoot.Id].Root.Children.Request().GetAsync();

                var subfolders = folder.Split("/", StringSplitOptions.RemoveEmptyEntries);
                DriveItem? targetFolder = null;
                DriveItem? parentFolder = null;

                // Crea eventuali sottocartelle
                for (int i = 0; i < subfolders.Length; i++)
                {
                    string currentFolderName = subfolders[i];

                    if (i == 0)
                    {
                        parentFolder = driveFolder.FirstOrDefault(x => x.Name == currentFolderName);

                        if (parentFolder == null)
                        {
                            var newFolder = new DriveItem
                            {
                                Name = currentFolderName,
                                Folder = new Folder()
                            };

                            parentFolder = await auth.Drives[driveRoot.Id].Root.Children
                                .Request()
                                .AddAsync(newFolder);
                        }
                    }
                    else
                    {
                        var children = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                            .Children
                            .Request()
                            .Filter($"name eq '{currentFolderName}'")
                            .GetAsync();

                        var existing = children.FirstOrDefault(x => x.Name == currentFolderName);

                        if (existing == null)
                        {
                            var newFolder = new DriveItem
                            {
                                Name = currentFolderName,
                                Folder = new Folder()
                            };

                            parentFolder = await auth.Drives[driveRoot.Id].Items[parentFolder.Id]
                                .Children
                                .Request()
                                .AddAsync(newFolder);

                            targetFolder = parentFolder;
                        }
                        else
                        {
                            parentFolder = existing;
                            targetFolder = existing;
                        }
                    }
                }

                // Se nessuna sottocartella o solo una
                if (subfolders.Length == 1 || targetFolder == null)
                {
                    targetFolder = parentFolder;
                }

                // Prepara lo stream dalla stringa
                using var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                ms.Position = 0;

                DriveItem uploadedFile = null;

                if (ms.Length <= 4 * 1024 * 1024)
                {
                    uploadedFile = await auth
                        .Drives[driveRoot.Id]
                        .Items[targetFolder.Id]
                        .ItemWithPath(fileName)
                        .Content
                        .Request()
                        .PutAsync<DriveItem>(ms);
                }
                else
                {
                    var uploadSession = await auth
                        .Drives[driveRoot.Id]
                        .Items[targetFolder.Id]
                        .ItemWithPath(fileName)
                        .CreateUploadSession()
                        .Request()
                        .PostAsync();

                    var maxChunkSize = 320 * 1024;
                    var provider = new ChunkedUploadProvider(uploadSession, auth, ms, maxChunkSize);
                    var chunkRequests = provider.GetUploadChunkRequests();
                    var readBuffer = new byte[maxChunkSize];
                    var trackedExceptions = new List<Exception>();
                    DriveItem itemResult = null;

                    foreach (var request in chunkRequests)
                    {
                        var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);
                        if (result.UploadSucceeded)
                        {
                            itemResult = result.ItemResponse;
                        }
                    }

                    if (itemResult == null)
                        return null;

                    uploadedFile = itemResult;
                }

                return new UploadFileResponseModel
                {
                    id = uploadedFile.Id,
                    fileName = fileName
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Remove Methods
        //Refactored 09052025
        public async Task<bool> Remove(string fileId)
        {
            try
            {
                var client = AuthenticateV2(); // o Authenticate(), in base alla tua versione
                var drive = await GetDriveFromRootSiteAsync(client);

                await client.Drives[drive.Id].Items[fileId]
                    .Request()
                    .DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la cancellazione: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Get & Get Info Methods
        //Refactor 09052025
        public async Task<List<ItemDto>> GetRootFolderByName(string folder)
        {
            var sp = AuthenticateV2();
            var driveRoot = await GetDriveFromRootSiteAsync(sp);
            var driveFolder = await sp.Drives[driveRoot.Id].Root.Children.Request().GetAsync();

            var sourceFolder = driveFolder.FirstOrDefault(x => x.Name == folder);
            if (sourceFolder == null) return new List<ItemDto>(); // evita null ref

            var children = await sp.Drives[driveRoot.Id].Items[sourceFolder.Id].Children.Request().GetAsync();

            var result = new List<ItemDto>();
            foreach (var itm in children)
            {
                if (itm.Name == "Thumbs.db") continue;

                var item = new ItemDto
                {
                    name = itm.Name.Contains("_") ? itm.Name.Substring(itm.Name.IndexOf("_") + 1) : itm.Name,
                    id = itm.Id,
                    webUrl = itm.WebUrl,
                    createdAt = itm.CreatedDateTime.GetValueOrDefault().ToString("dd/MM/yyyy"),
                    size = FileHelper.FileSizeFormatter(itm.Size.GetValueOrDefault()),
                    type = itm.Folder != null ? "folder" : Path.GetExtension(itm.Name).GetFileType(),
                    contents = itm.Folder?.ChildCount > 1 ? $"{itm.Folder?.ChildCount} elementi" : $"{itm.Folder?.ChildCount} elemento"
                };

                result.Add(item);
            }

            return result;
        }
        //Refactor 09052025
        public async Task<List<ItemDto>> GetFolderContentById(string folderId, List<ItemDto> path)
        {
            var sp = AuthenticateV2();
            var driveRoot = await GetDriveFromRootSiteAsync(sp);

            var children = await sp.Drives[driveRoot.Id].Items[folderId].Children.Request().GetAsync();

            var result = path ?? new List<ItemDto>();
            foreach (var itm in children)
            {
                if (itm.Name == "Thumbs.db") continue;

                var item = new ItemDto
                {
                    name = itm.Name.Contains("_") ? itm.Name.Substring(itm.Name.IndexOf("_") + 1) : itm.Name,
                    id = itm.Id,
                    webUrl = itm.WebUrl,
                    createdAt = itm.CreatedDateTime.GetValueOrDefault().ToString("dd/MM/yyyy"),
                    size = FileHelper.FileSizeFormatter(itm.Size.GetValueOrDefault()),
                    folderId = folderId
                };

                if (itm.Folder != null)
                {
                    item.type = "folder";
                    item.contents = itm.Folder?.ChildCount > 1 ? $"{itm.Folder?.ChildCount} elementi" : $"{itm.Folder?.ChildCount} elemento";
                }
                else
                {
                    item.type = Path.GetExtension(itm.Name).GetFileType();
                }

                result.Add(item);
            }

            return result;
        }

        #endregion

        #region Misc Methods
        //Refactor 09052025
        public async Task<string> CreateSharedLink(string fileId)
        {
            try
            {
                var auth = AuthenticateV2();
                var drive = await GetDriveFromRootSiteAsync(auth);

                var type = "view";
                var scope = "anonymous";

                var result = await auth.Drives[drive.Id].Items[fileId]
                    .CreateLink(type, scope)
                    .Request()
                    .PostAsync();

                return result.Link?.WebUrl ?? throw new Exception("Nessun link generato.");
            }
            catch (ServiceException ex)
            {
                // Opzionale: puoi loggare qui l'errore
                throw new Exception($"Errore nella creazione del link: {ex.Message}", ex);
            }
        }

        #endregion

        #region Auth Methods
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

        //Update 09052025
        private GraphServiceClient AuthenticateV2()
        {
            var clientId = GraphConsts.clientId;
            var clientSecret = GraphConsts.clientSecret;
            var tenantId = GraphConsts.tenantId;

            var authority = $"https://login.microsoftonline.com/{tenantId}";

            var cca = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(authority)
                .Build();

            var scopes = new[] { "https://graph.microsoft.com/.default" };

            var authProvider = new MsalAuthenticationProvider(cca, scopes);

            var graphClient = new GraphServiceClient(authProvider);

            return graphClient;
        }

        #endregion

        #region Helpers
        public async Task<Drive> GetDriveFromRootSiteAsync(GraphServiceClient graphClient)
        {
            // Recupera il sito radice
            var site = await graphClient.Sites["gestioneambiente.sharepoint.com"]
                                        .Request()
                                        .GetAsync();

            // Recupera tutti i drive (librerie documenti)
            var drives = await graphClient.Sites[site.Id]
                                          .Drives
                                          .Request()
                                          .GetAsync();

            // ✅ Cerca la libreria giusta: "Documenti"
            var documentLibrary = drives.FirstOrDefault(d =>
                d.Name.Equals("Documenti", StringComparison.OrdinalIgnoreCase));

            if (documentLibrary == null)
                throw new Exception("Drive 'Documenti' non trovato.");

            return documentLibrary;
        }
        #endregion  

    }
}
