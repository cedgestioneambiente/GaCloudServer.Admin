using DinkToPdf;
using GaCloudServer.BusinnessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;


namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IPrintService
    {
        Task<string> Print(string templateName, dynamic dto,string? alternativePath = null);
        Task<string> PrintMerged(dynamic dtos, string? alternativePath = null,int? copies=2,MarginSettings margin=null);

    }
}
