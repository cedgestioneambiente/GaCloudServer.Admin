using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Base
{
    public class GenericDto
    {
        public long Id { get; set; }
        public bool Disabled { get; set; }
    }

    public class GenericFileDto:GenericDto
    {
        public string FileId { get; set; }
        public string? FileFolder { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
#pragma warning disable CS8632 // L'annotazione per i tipi riferimento nullable deve essere usata solo nel codice in un contesto di annotations '#nullable'.
        public IFormFile? File { get; set; }
#pragma warning restore CS8632 // L'annotazione per i tipi riferimento nullable deve essere usata solo nel codice in un contesto di annotations '#nullable'.
        public bool uploadFile { get; set; }
        public bool deleteFile { get; set; }

        public GenericFileDto()
        {
            FileId = string.Empty;
            FileFolder = string.Empty;
            FileName =  string.Empty;
            FileType =  string.Empty;
            FileSize = string.Empty;
        }
    }

    public class GenericListDto : GenericDto
    {
        [Required(ErrorMessage = "Il campo Descrizione è obbligatorio.")]
        public string Descrizione { get; set; }
        public GenericListDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class GenericPagedListDto<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public GenericPagedListDto()
        {
            Data= new List<T>();
        }
    }
}
