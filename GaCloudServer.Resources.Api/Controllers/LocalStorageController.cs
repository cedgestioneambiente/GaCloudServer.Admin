using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Models;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeTypes.Core;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class LocalStorageController : Controller
    {
        private readonly ILocalFileService _localFileService;
        private readonly string _webRootPath;
        public LocalStorageController(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment env,
            ILocalFileService localFileService)
        {
            if (string.IsNullOrWhiteSpace(env.WebRootPath))
            {
                env.WebRootPath = Directory.GetCurrentDirectory();
            }
            _webRootPath = env.WebRootPath;
            _localFileService = localFileService;
        }

        [HttpGet("DownloadByPath")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public async Task<IActionResult> DownloadByPath(string path)
        {
            try
            {
                string file = Path.Combine(_webRootPath, path);

                var memory = new MemoryStream();
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

                memory.Position = 0;
                var mimeType = MimeTypeMap.GetMimeType(Path.GetExtension(file));
                return File(memory, mimeType, path);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }




        }

        




    }
}