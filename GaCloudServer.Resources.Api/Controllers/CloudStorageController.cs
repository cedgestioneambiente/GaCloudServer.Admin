using AutoWrapper.Extensions;
using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Autorizzazioni;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Models;
using GaCloudServer.Resources.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeTypes.Core;
using System.Diagnostics;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class CloudStorageController : Controller
    {
        private readonly IApiErrorResources _errorResources;
        private readonly IFileService _fileService;

        public CloudStorageController(
            IApiErrorResources errorResources
            ,IFileService fileService)
        {

            _fileService = fileService;
            _errorResources= errorResources;
        }

        [HttpGet("DownloadByIdAsync/{fileId}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public async Task<IActionResult> DownloadByIdAsync(string fileId)
        {
            var downloadFileModel = await _fileService.DownloadById(fileId);

            var mimeType = MimeTypeMap.GetMimeType(Path.GetExtension(downloadFileModel.fileName));

            return File(downloadFileModel.stream, mimeType, downloadFileModel.fileName);

        }


    }
}