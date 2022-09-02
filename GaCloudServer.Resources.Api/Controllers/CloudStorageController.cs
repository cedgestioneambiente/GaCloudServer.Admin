using AutoWrapper.Filters;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeTypes.Core;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class CloudStorageController : Controller
    {
        private readonly IFileService _fileService;

        public CloudStorageController(
            IFileService fileService)
        {

            _fileService = fileService;
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