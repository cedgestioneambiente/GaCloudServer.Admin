using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.BusinnessLogic.DTOs.Base
{
    public class GenericDto
    {
        public long Id { get; set; }
        public bool Disabled { get; set; }
    }

    public class GenericFileDto:GenericDto
    {
        public string? FileId { get; set; }
        public string? FileFolder { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? FileSize { get; set; }


        public GenericFileDto()
        {

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
