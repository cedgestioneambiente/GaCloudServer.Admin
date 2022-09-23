using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Cdr;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Resources;
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
    public class GaCdrController : Controller
    {
        private readonly IGaCdrService _gaCdrService;
        private readonly IApiErrorResources _errorResources;
        private readonly ILogger<GaCdrController> _logger;

        public GaCdrController(
            IGaCdrService gaCdrService
            ,IApiErrorResources errorResources
            ,IFileService fileService
            ,ILogger<GaCdrController> logger)
        {

            _gaCdrService = gaCdrService;
            _errorResources= errorResources;
            _logger = logger;
        }


        #region CdrCentri
        [HttpGet("GetGaCdrCentriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCentriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrCentriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrCentriApiDto, CdrCentriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            
        }

        [HttpGet("GetGaCdrCentroByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCentroByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCdrService.GetGaCdrCentroByIdAsync(id);
                var apiDto = dto.ToApiDto<CdrCentroApiDto, CdrCentroDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCdrCentroAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCdrCentroAsync([FromBody]CdrCentroApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCentroDto, CdrCentroApiDto>();
                var response = await _gaCdrService.AddGaCdrCentroAsync(dto);

                return new ApiResponse(response);
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }

        }

        [HttpPost("UpdateGaCdrCentroAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrCentroAsync([FromBody] CdrCentroApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCentroDto, CdrCentroApiDto>();
                var response = await _gaCdrService.UpdateGaCdrCentroAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCdrCentroAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCdrCentroAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.DeleteGaCdrCentroAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCdrCentroAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCdrCentroAsync(long id,string descrizione)
        {
            try
            {
                var response = await _gaCdrService.ValidateGaCdrCentroAsync(id,descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCdrCentroAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCdrCentroAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.ChangeStatusGaCdrCentroAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #endregion

        #region CdrComuni
        [HttpGet("GetGaCdrComuniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrComuniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrComuniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrComuniApiDto, CdrComuniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCdrComuneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrComuneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCdrService.GetGaCdrComuneByIdAsync(id);
                var apiDto = dto.ToApiDto<CdrComuneApiDto, CdrComuneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCdrComuneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCdrComuneAsync([FromBody] CdrComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrComuneDto, CdrComuneApiDto>();
                var response = await _gaCdrService.AddGaCdrComuneAsync(dto);

                return new ApiResponse(response);
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }

        }

        [HttpPost("UpdateGaCdrComuneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrComuneAsync([FromBody] CdrComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrComuneDto, CdrComuneApiDto>();
                var response = await _gaCdrService.UpdateGaCdrComuneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCdrComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCdrComuneAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.DeleteGaCdrComuneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCdrComuneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCdrComuneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaCdrService.ValidateGaCdrComuneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCdrComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCdrComuneAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.ChangeStatusGaCdrComuneAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region Views
        //[HttpGet("GetViewGaCdrComuniAsync/{all}")]
        //public async Task<ActionResult<ApiResponse>> GetViewGaCdrComuniAsync(bool all = true)
        //{
        //    try
        //    {
        //        var view = await _gaCdrService.GetViewGaCdrComuniAsync(all);
        //        return new ApiResponse(view);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        #endregion

        #endregion

        #region CdrCers
        [HttpGet("GetGaCdrCersAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCersAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrCersAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrCersApiDto, CdrCersDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCdrCerByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCerByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCdrService.GetGaCdrCerByIdAsync(id);
                var apiDto = dto.ToApiDto<CdrCerApiDto, CdrCerDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCdrCerAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCdrCerAsync([FromBody] CdrCerApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCerDto, CdrCerApiDto>();
                var response = await _gaCdrService.AddGaCdrCerAsync(dto);

                return new ApiResponse(response);
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }

        }

        [HttpPost("UpdateGaCdrCerAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrCerAsync([FromBody] CdrCerApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCerDto, CdrCerApiDto>();
                var response = await _gaCdrService.UpdateGaCdrCerAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCdrCerAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCdrCerAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.DeleteGaCdrCerAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCdrCerAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCdrCerAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaCdrService.ValidateGaCdrCerAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCdrCerAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCdrCerAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.ChangeStatusGaCdrCerAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #endregion

        #region CdrCersDettagli
        [HttpGet("GetGaCdrCersDettagliAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCersDettagliAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrCersDettagliAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrCersDettagliApiDto, CdrCersDettagliDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCdrCerDettaglioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrCerDettaglioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCdrService.GetGaCdrCerDettaglioByIdAsync(id);
                var apiDto = dto.ToApiDto<CdrCerDettaglioApiDto, CdrCerDettaglioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCdrCerDettaglioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCdrCerDettaglioAsync([FromBody] CdrCerDettaglioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCerDettaglioDto, CdrCerDettaglioApiDto>();
                var response = await _gaCdrService.AddGaCdrCerDettaglioAsync(dto);

                return new ApiResponse(response);
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }

        }

        [HttpPost("UpdateGaCdrCerDettaglioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrCerDettaglioAsync([FromBody] CdrCerDettaglioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrCerDettaglioDto, CdrCerDettaglioApiDto>();
                var response = await _gaCdrService.UpdateGaCdrCerDettaglioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCdrCerDettaglioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCdrCerDettaglioAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.DeleteGaCdrCerDettaglioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCdrCerDettaglioAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCdrCerDettaglioAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaCdrService.ValidateGaCdrCerDettaglioAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCdrCerDettaglioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCdrCerDettaglioAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.ChangeStatusGaCdrCerDettaglioAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #endregion

        #region CdrCersOnCentri
        //[HttpGet("GetGaCdrCersOnCentriAsync/{page}/{pageSize}")]
        //public async Task<ActionResult<ApiResponse>> GetGaCdrCersOnCentriAsync(int page = 1, int pageSize = 0)
        //{
        //    try
        //    {
        //        var dtos = await _gaCdrService.GetGaCdrCersOnCentriAsync(page, pageSize);
        //        var apiDtos = dtos.ToApiDto<CdrCersOnCentriApiDto, CdrCersOnCentriDto>();
        //        return new ApiResponse(apiDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }

        //}

        [HttpGet("UpdateGaCdrCerOnCentroAsync/{cerId}/{centroId}")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrCerOnCentroAsync(long cerId, long centroId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }

                var response = await _gaCdrService.UpdateGaCdrCerOnCentroAsync(cerId, centroId);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Views
        [HttpGet("GetViewGaCdrCersOnCentriAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCdrCersOnCentriAsync(long id)
        {
            try
            {
                var view = await _gaCdrService.GetViewGaCdrCersOnCentriAsync(id);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #endregion

        #region CdrComuniOnCentri
        [HttpGet("UpdateGaCdrComuneOnCentroAsync/{comuneId}/{centroId}")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrComuneOnCentroAsync(long comuneId, long centroId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var response = await _gaCdrService.UpdateGaCdrComuneOnCentroAsync(comuneId, centroId);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Views
        [HttpGet("GetViewGaCdrComuniOnCentriAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaCdrComuniOnCentriAsync(long id)
        {
            try
            {
                var view = await _gaCdrService.GetViewGaCdrComuniOnCentriAsync(id);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #endregion

        #region CdrConferimenti
        [HttpGet("GetGaCdrConferimentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrConferimentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCdrService.GetGaCdrConferimentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CdrConferimentiApiDto, CdrConferimentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCdrConferimentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCdrConferimentoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCdrService.GetGaCdrConferimentoByIdAsync(id);
                var apiDto = dto.ToApiDto<CdrConferimentoApiDto, CdrConferimentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCdrConferimentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCdrConferimentoAsync([FromBody] CdrConferimentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrConferimentoDto, CdrConferimentoApiDto>();
                var response = await _gaCdrService.AddGaCdrConferimentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (ApiProblemDetailsException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }

        }

        [HttpPost("UpdateGaCdrConferimentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCdrConferimentoAsync([FromBody] CdrConferimentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CdrConferimentoDto, CdrConferimentoApiDto>();
                var response = await _gaCdrService.UpdateGaCdrConferimentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCdrConferimentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCdrConferimentoAsync(long id)
        {
            try
            {
                var response = await _gaCdrService.DeleteGaCdrConferimentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCdrConferimentoAsync")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCdrConferimentoAsync(CdrConferimentoApiDto apiDto)
        {
            try
            {
                var dto = apiDto.ToDto<CdrConferimentoDto, CdrConferimentoApiDto>();
                var response = await _gaCdrService.ValidateGaCdrConferimentoAsync(dto);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #endregion

    }
}