using DinkToPdf;
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

    public class GenericPrintDto
    { 
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Css { get; set; }
        public Orientation Orientation { get; set; }
        public HeaderSettings HeaderSettings { get; set; }
        public FooterSettings FooterSettings { get; set; }
        public WebSettings WebSettings { get; set; }
        public MarginSettings MarginSettings { get; set; }
        public int Copies { get; set; }

        public GenericPrintDto()
        {
            this.Title = "";
            this.Css = "";
            this.Orientation=Orientation.Portrait;
            this.Copies = 1;
            this.HeaderSettings = new HeaderSettings() { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Right = "Pagina [page] di [toPage]", Line = true };
            this.FooterSettings = new FooterSettings() { FontName = "Arial, Helvetica, sans-serif", FontSize = 9, Line = true, Center = this.Title };
        }
    }
}
