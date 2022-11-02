using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using code = Microsoft.AspNetCore.Http.StatusCodes;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class GaContactCenterController : Controller
    {
        private readonly IGaContactCenterService _gaContactCenterService;
        private readonly IFileService _fileService;
        private readonly ILogger<GaContactCenterController> _logger;

        public GaContactCenterController(
            IGaContactCenterService gaContactCenterService
            , IFileService fileService
            , ILogger<GaContactCenterController> logger)
        {

            _gaContactCenterService = gaContactCenterService;
            _fileService = fileService;
            _logger = logger;
        }


        //#region ContactCenterComuni
        //[HttpGet("GetGaContactCenterComuniAsync/{page}/{pageSize}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterComuniAsync(int page = 1, int pageSize = 0)
        //{
        //    try
        //    {
        //        var dtos = await _gaContactCenterService.GetGaContactCenterComuniAsync(page, pageSize);
        //        var apiDtos = dtos.ToApiDto<ContactCenterComuniApiDto, ContactCenterComuniDto>();
        //        return new ApiResponse(apiDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("GetGaContactCenterComuneByIdAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterComuneByIdAsync(long id)
        //{
        //    try
        //    {
        //        var dto = await _gaContactCenterService.GetGaContactCenterComuneByIdAsync(id);
        //        var apiDto = dto.ToApiDto<ContactCenterComuneApiDto, ContactCenterComuneDto>();
        //        return new ApiResponse(apiDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpPost("AddGaContactCenterComuneAsync")]
        //public async Task<ActionResult<ApiResponse>> AddGaContactCenterComuneAsync([FromBody] ContactCenterComuneApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterComuneDto, ContactCenterComuneApiDto>();
        //        var response = await _gaContactCenterService.AddGaContactCenterComuneAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (ApiProblemDetailsException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex);
        //    }

        //}

        //[HttpPost("UpdateGaContactCenterComuneAsync")]
        //public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterComuneAsync([FromBody] ContactCenterComuneApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterComuneDto, ContactCenterComuneApiDto>();
        //        var response = await _gaContactCenterService.UpdateGaContactCenterComuneAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpDelete("DeleteGaContactCenterComuneAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterComuneAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.DeleteGaContactCenterComuneAsync(id);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //#region Functions
        //[HttpGet("ValidateGaContactCenterComuneAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterComuneAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterComuneAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterComuneAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterComuneAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterComuneAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        //#endregion

        //#endregion

        //#region ContactCenterProvenienze
        //[HttpGet("GetGaContactCenterProvenienzeAsync/{page}/{pageSize}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterProvenienzeAsync(int page = 1, int pageSize = 0)
        //{
        //    try
        //    {
        //        var dtos = await _gaContactCenterService.GetGaContactCenterProvenienzeAsync(page, pageSize);
        //        var apiDtos = dtos.ToApiDto<ContactCenterProvenienzeApiDto, ContactCenterProvenienzeDto>();
        //        return new ApiResponse(apiDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("GetGaContactCenterProvenienzaByIdAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterProvenienzaByIdAsync(long id)
        //{
        //    try
        //    {
        //        var dto = await _gaContactCenterService.GetGaContactCenterProvenienzaByIdAsync(id);
        //        var apiDto = dto.ToApiDto<ContactCenterProvenienzaApiDto, ContactCenterProvenienzaDto>();
        //        return new ApiResponse(apiDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpPost("AddGaContactCenterProvenienzaAsync")]
        //public async Task<ActionResult<ApiResponse>> AddGaContactCenterProvenienzaAsync([FromBody] ContactCenterProvenienzaApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterProvenienzaDto, ContactCenterProvenienzaApiDto>();
        //        var response = await _gaContactCenterService.AddGaContactCenterProvenienzaAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (ApiProblemDetailsException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex);
        //    }

        //}

        //[HttpPost("UpdateGaContactCenterProvenienzaAsync")]
        //public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterProvenienzaAsync([FromBody] ContactCenterProvenienzaApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterProvenienzaDto, ContactCenterProvenienzaApiDto>();
        //        var response = await _gaContactCenterService.UpdateGaContactCenterProvenienzaAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpDelete("DeleteGaContactCenterProvenienzaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterProvenienzaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.DeleteGaContactCenterProvenienzaAsync(id);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //#region Functions
        //[HttpGet("ValidateGaContactCenterProvenienzaAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterProvenienzaAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterProvenienzaAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterProvenienzaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterProvenienzaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterProvenienzaAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        //#endregion

        //#endregion

        //#region ContactCenterStatiRichieste
        //[HttpGet("GetGaContactCenterStatiRichiesteAsync/{page}/{pageSize}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterStatiRichiesteAsync(int page = 1, int pageSize = 0)
        //{
        //    try
        //    {
        //        var dtos = await _gaContactCenterService.GetGaContactCenterStatiRichiesteAsync(page, pageSize);
        //        var apiDtos = dtos.ToApiDto<ContactCenterStatiRichiesteApiDto, ContactCenterStatiRichiesteDto>();
        //        return new ApiResponse(apiDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("GetGaContactCenterStatoRichiestaByIdAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterStatoRichiestaByIdAsync(long id)
        //{
        //    try
        //    {
        //        var dto = await _gaContactCenterService.GetGaContactCenterStatoRichiestaByIdAsync(id);
        //        var apiDto = dto.ToApiDto<ContactCenterStatoRichiestaApiDto, ContactCenterStatoRichiestaDto>();
        //        return new ApiResponse(apiDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpPost("AddGaContactCenterStatoRichiestaAsync")]
        //public async Task<ActionResult<ApiResponse>> AddGaContactCenterStatoRichiestaAsync([FromBody] ContactCenterStatoRichiestaApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterStatoRichiestaDto, ContactCenterStatoRichiestaApiDto>();
        //        var response = await _gaContactCenterService.AddGaContactCenterStatoRichiestaAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (ApiProblemDetailsException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex);
        //    }

        //}

        //[HttpPost("UpdateGaContactCenterStatoRichiestaAsync")]
        //public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterStatoRichiestaAsync([FromBody] ContactCenterStatoRichiestaApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterStatoRichiestaDto, ContactCenterStatoRichiestaApiDto>();
        //        var response = await _gaContactCenterService.UpdateGaContactCenterStatoRichiestaAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpDelete("DeleteGaContactCenterStatoRichiestaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterStatoRichiestaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.DeleteGaContactCenterStatoRichiestaAsync(id);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //#region Functions
        //[HttpGet("ValidateGaContactCenterStatoRichiestaAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterStatoRichiestaAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterStatoRichiestaAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterStatoRichiestaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterStatoRichiestaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterStatoRichiestaAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        //#endregion

        //#endregion

        //#region ContactCenterTipiRichieste
        //[HttpGet("GetGaContactCenterTipiRichiesteAsync/{page}/{pageSize}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterTipiRichiesteAsync(int page = 1, int pageSize = 0)
        //{
        //    try
        //    {
        //        var dtos = await _gaContactCenterService.GetGaContactCenterTipiRichiesteAsync(page, pageSize);
        //        var apiDtos = dtos.ToApiDto<ContactCenterTipiRichiesteApiDto, ContactCenterTipiRichiesteDto>();
        //        return new ApiResponse(apiDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("GetGaContactCenterTipoRichiestaByIdAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterTipoRichiestaByIdAsync(long id)
        //{
        //    try
        //    {
        //        var dto = await _gaContactCenterService.GetGaContactCenterTipoRichiestaByIdAsync(id);
        //        var apiDto = dto.ToApiDto<ContactCenterTipoRichiestaApiDto, ContactCenterTipoRichiestaDto>();
        //        return new ApiResponse(apiDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpPost("AddGaContactCenterTipoRichiestaAsync")]
        //public async Task<ActionResult<ApiResponse>> AddGaContactCenterTipoRichiestaAsync([FromBody] ContactCenterTipoRichiestaApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterTipoRichiestaDto, ContactCenterTipoRichiestaApiDto>();
        //        var response = await _gaContactCenterService.AddGaContactCenterTipoRichiestaAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (ApiProblemDetailsException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex);
        //    }

        //}

        //[HttpPost("UpdateGaContactCenterTipoRichiestaAsync")]
        //public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterTipoRichiestaAsync([FromBody] ContactCenterTipoRichiestaApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterTipoRichiestaDto, ContactCenterTipoRichiestaApiDto>();
        //        var response = await _gaContactCenterService.UpdateGaContactCenterTipoRichiestaAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpDelete("DeleteGaContactCenterTipoRichiestaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterTipoRichiestaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.DeleteGaContactCenterTipoRichiestaAsync(id);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //#region Functions
        //[HttpGet("ValidateGaContactCenterTipoRichiestaAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterTipoRichiestaAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterTipoRichiestaAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterTipoRichiestaAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterTipoRichiestaAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterTipoRichiestaAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        //#endregion

        //#endregion

        //#region ContactCenterMails
        //[HttpGet("GetGaContactCenterMailsAsync/{page}/{pageSize}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailsAsync(int page = 1, int pageSize = 0)
        //{
        //    try
        //    {
        //        var dtos = await _gaContactCenterService.GetGaContactCenterMailsAsync(page, pageSize);
        //        var apiDtos = dtos.ToApiDto<ContactCenterMailsApiDto, ContactCenterMailsDto>();
        //        return new ApiResponse(apiDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("GetGaContactCenterMailByIdAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterMailByIdAsync(long id)
        //{
        //    try
        //    {
        //        var dto = await _gaContactCenterService.GetGaContactCenterMailByIdAsync(id);
        //        var apiDto = dto.ToApiDto<ContactCenterMailApiDto, ContactCenterMailDto>();
        //        return new ApiResponse(apiDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpPost("AddGaContactCenterMailAsync")]
        //public async Task<ActionResult<ApiResponse>> AddGaContactCenterMailAsync([FromBody] ContactCenterMailApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterMailDto, ContactCenterMailApiDto>();
        //        var response = await _gaContactCenterService.AddGaContactCenterMailAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (ApiProblemDetailsException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex);
        //    }

        //}

        //[HttpPost("UpdateGaContactCenterMailAsync")]
        //public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterMailAsync([FromBody] ContactCenterMailApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterMailDto, ContactCenterMailApiDto>();
        //        var response = await _gaContactCenterService.UpdateGaContactCenterMailAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpDelete("DeleteGaContactCenterMailAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterMailAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.DeleteGaContactCenterMailAsync(id);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //#region Functions
        //[HttpGet("ValidateGaContactCenterMailAsync/{id}/{mail}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterMailAsync(long id, string mail)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterMailAsync(id, mail);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterMailAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterMailAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterMailAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        //#endregion

        //#endregion

        //#region ContactCenterAllegati
        //[HttpGet("GetGaContactCenterAllegatiAsync/{page}/{pageSize}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterAllegatiAsync(int page = 1, int pageSize = 0)
        //{
        //    try
        //    {
        //        var dtos = await _gaContactCenterService.GetGaContactCenterAllegatiAsync(page, pageSize);
        //        var apiDtos = dtos.ToApiDto<ContactCenterAllegatiApiDto, ContactCenterAllegatiDto>();
        //        return new ApiResponse(apiDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("GetGaContactCenterAllegatoByIdAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> GetGaContactCenterAllegatoByIdAsync(long id)
        //{
        //    try
        //    {
        //        var dto = await _gaContactCenterService.GetGaContactCenterAllegatoByIdAsync(id);
        //        var apiDto = dto.ToApiDto<ContactCenterAllegatoApiDto, ContactCenterAllegatoDto>();
        //        return new ApiResponse(apiDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpPost("AddGaContactCenterAllegatoAsync")]
        //public async Task<ActionResult<ApiResponse>> AddGaContactCenterAllegatoAsync([FromBody] ContactCenterAllegatoApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterAllegatoDto, ContactCenterAllegatoApiDto>();
        //        var response = await _gaContactCenterService.AddGaContactCenterAllegatoAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (ApiProblemDetailsException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex);
        //    }

        //}

        //[HttpPost("UpdateGaContactCenterAllegatoAsync")]
        //public async Task<ActionResult<ApiResponse>> UpdateGaContactCenterAllegatoAsync([FromBody] ContactCenterAllegatoApiDto apiDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new ApiProblemDetailsException(ModelState);
        //        }
        //        var dto = apiDto.ToDto<ContactCenterAllegatoDto, ContactCenterAllegatoApiDto>();
        //        var response = await _gaContactCenterService.UpdateGaContactCenterAllegatoAsync(dto);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpDelete("DeleteGaContactCenterAllegatoAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> DeleteGaContactCenterAllegatoAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.DeleteGaContactCenterAllegatoAsync(id);

        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //#region Functions
        //[HttpGet("ValidateGaContactCenterAllegatoAsync/{id}/{descrizione}")]
        //public async Task<ActionResult<ApiResponse>> ValidateGaContactCenterAllegatoAsync(long id, string descrizione)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ValidateGaContactCenterAllegatoAsync(id, descrizione);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        //[HttpGet("ChangeStatusGaContactCenterAllegatoAsync/{id}")]
        //public async Task<ActionResult<ApiResponse>> ChangeStatusGaContactCenterAllegatoAsync(long id)
        //{
        //    try
        //    {
        //        var response = await _gaContactCenterService.ChangeStatusGaContactCenterAllegatoAsync(id);
        //        return new ApiResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}
        //#endregion

        //#endregion
    }
}
