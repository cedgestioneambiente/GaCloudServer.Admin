using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Csr;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Csr;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
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
    public class GaCsrController : Controller
    {
        private readonly IGaCsrService _gaCsrService;
        private readonly ILogger<GaCsrController> _logger;

        public GaCsrController(
            IGaCsrService gaCsrService
            , ILogger<GaCsrController> logger)
        {

            _gaCsrService = gaCsrService;
            _logger = logger;
        }


        #region CsrCodiciCers
        [HttpGet("GetGaCsrCodiciCersAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrCodiciCersAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrCodiciCersAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrCodiciCersApiDto, CsrCodiciCersDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrCodiceCerByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrCodiceCerByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrCodiceCerByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrCodiceCerApiDto, CsrCodiceCerDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCsrCodiceCerAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCsrCodiceCerAsync([FromBody] CsrCodiceCerApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrCodiceCerDto, CsrCodiceCerApiDto>();
                var response = await _gaCsrService.AddGaCsrCodiceCerAsync(dto);

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

        [HttpPost("UpdateGaCsrCodiceCerAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCsrCodiceCerAsync([FromBody] CsrCodiceCerApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrCodiceCerDto, CsrCodiceCerApiDto>();
                var response = await _gaCsrService.UpdateGaCsrCodiceCerAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCsrCodiceCerAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCsrCodiceCerAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.DeleteGaCsrCodiceCerAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCsrCodiceCerAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCsrCodiceCerAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaCsrService.ValidateGaCsrCodiceCerAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCsrCodiceCerAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCsrCodiceCerAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.ChangeStatusGaCsrCodiceCerAsync(id);
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
        [HttpGet("GetViewGaCsrCodiciCersAsync")]
        public async Task<ApiResponse> GetViewGaCsrCodiciCersAsync()
        {
            try
            {
                var view = await _gaCsrService.GetViewGaCsrCodiciCersAsync();
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

        #region CsrComuni
        [HttpGet("GetGaCsrComuniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrComuniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrComuniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrComuniApiDto, CsrComuniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrComuneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrComuneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrComuneByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrComuneApiDto, CsrComuneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCsrComuneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCsrComuneAsync([FromBody] CsrComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrComuneDto, CsrComuneApiDto>();
                var response = await _gaCsrService.AddGaCsrComuneAsync(dto);

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

        [HttpPost("UpdateGaCsrComuneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCsrComuneAsync([FromBody] CsrComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrComuneDto, CsrComuneApiDto>();
                var response = await _gaCsrService.UpdateGaCsrComuneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCsrComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCsrComuneAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.DeleteGaCsrComuneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCsrComuneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCsrComuneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _gaCsrService.ValidateGaCsrComuneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCsrComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCsrComuneAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.ChangeStatusGaCsrComuneAsync(id);
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

        #region CsrDestinatari
        [HttpGet("GetGaCsrDestinatariAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrDestinatariAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrDestinatariAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrDestinatariApiDto, CsrDestinatariDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrDestinatarioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrDestinatarioByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrDestinatarioByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrDestinatarioApiDto, CsrDestinatarioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCsrDestinatarioAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCsrDestinatarioAsync([FromBody] CsrDestinatarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrDestinatarioDto, CsrDestinatarioApiDto>();
                var response = await _gaCsrService.AddGaCsrDestinatarioAsync(dto);

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

        [HttpPost("UpdateGaCsrDestinatarioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCsrDestinatarioAsync([FromBody] CsrDestinatarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrDestinatarioDto, CsrDestinatarioApiDto>();
                var response = await _gaCsrService.UpdateGaCsrDestinatarioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCsrDestinatarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCsrDestinatarioAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.DeleteGaCsrDestinatarioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCsrDestinatarioAsync/{id}/{ragioneSociale}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCsrDestinatarioAsync(long id, string ragioneSociale)
        {
            try
            {
                var response = await _gaCsrService.ValidateGaCsrDestinatarioAsync(id, ragioneSociale);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCsrDestinatarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCsrDestinatarioAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.ChangeStatusGaCsrDestinatarioAsync(id);
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
        [HttpGet("GetViewGaCsrDestinatariAsync")]
        public async Task<ApiResponse> GetViewGaCsrDestinatariAsync()
        {
            try
            {
                var view = await _gaCsrService.GetViewGaCsrDestinatariAsync();
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

        #region CsrProduttori
        [HttpGet("GetGaCsrProduttoriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrProduttoriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrProduttoriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrProduttoriApiDto, CsrProduttoriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrProduttoreByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrProduttoreByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrProduttoreByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrProduttoreApiDto, CsrProduttoreDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCsrProduttoreAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCsrProduttoreAsync([FromBody] CsrProduttoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrProduttoreDto, CsrProduttoreApiDto>();
                var response = await _gaCsrService.AddGaCsrProduttoreAsync(dto);

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

        [HttpPost("UpdateGaCsrProduttoreAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCsrProduttoreAsync([FromBody] CsrProduttoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrProduttoreDto, CsrProduttoreApiDto>();
                var response = await _gaCsrService.UpdateGaCsrProduttoreAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCsrProduttoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCsrProduttoreAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.DeleteGaCsrProduttoreAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCsrProduttoreAsync/{id}/{ragioneSociale}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCsrProduttoreAsync(long id, string ragioneSociale)
        {
            try
            {
                var response = await _gaCsrService.ValidateGaCsrProduttoreAsync(id, ragioneSociale);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCsrProduttoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCsrProduttoreAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.ChangeStatusGaCsrProduttoreAsync(id);
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
        [HttpGet("GetViewGaCsrProduttoriAsync")]
        public async Task<ApiResponse> GetViewGaCsrProduttoriAsync()
        {
            try
            {
                var view = await _gaCsrService.GetViewGaCsrProduttoriAsync();
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

        #region CsrTrasportatori
        [HttpGet("GetGaCsrTrasportatoriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrTrasportatoriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrTrasportatoriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrTrasportatoriApiDto, CsrTrasportatoriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrTrasportatoreByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrTrasportatoreByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrTrasportatoreByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrTrasportatoreApiDto, CsrTrasportatoreDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCsrTrasportatoreAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCsrTrasportatoreAsync([FromBody] CsrTrasportatoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrTrasportatoreDto, CsrTrasportatoreApiDto>();
                var response = await _gaCsrService.AddGaCsrTrasportatoreAsync(dto);

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

        [HttpPost("UpdateGaCsrTrasportatoreAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCsrTrasportatoreAsync([FromBody] CsrTrasportatoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrTrasportatoreDto, CsrTrasportatoreApiDto>();
                var response = await _gaCsrService.UpdateGaCsrTrasportatoreAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCsrTrasportatoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCsrTrasportatoreAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.DeleteGaCsrTrasportatoreAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCsrTrasportatoreAsync/{id}/{ragioneSociale}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCsrTrasportatoreAsync(long id, string ragioneSociale)
        {
            try
            {
                var response = await _gaCsrService.ValidateGaCsrTrasportatoreAsync(id, ragioneSociale);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCsrTrasportatoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCsrTrasportatoreAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.ChangeStatusGaCsrTrasportatoreAsync(id);
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
        [HttpGet("GetViewGaCsrTrasportatoriAsync")]
        public async Task<ApiResponse> GetViewGaCsrTrasportatoriAsync()
        {
            try
            {
                var view = await _gaCsrService.GetViewGaCsrTrasportatoriAsync();
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

        #region CsrRegistrazioni
        [HttpGet("GetGaCsrRegistrazioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRegistrazioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrRegistrazioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrRegistrazioniApiDto, CsrRegistrazioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrRegistrazioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRegistrazioneByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrRegistrazioneByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrRegistrazioneApiDto, CsrRegistrazioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCsrRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCsrRegistrazioneAsync([FromBody] CsrRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrRegistrazioneDto, CsrRegistrazioneApiDto>();
                var response = await _gaCsrService.AddGaCsrRegistrazioneAsync(dto);

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

        [HttpPost("UpdateGaCsrRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCsrRegistrazioneAsync([FromBody] CsrRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrRegistrazioneDto, CsrRegistrazioneApiDto>();
                var response = await _gaCsrService.UpdateGaCsrRegistrazioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCsrRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCsrRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.DeleteGaCsrRegistrazioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("GetGaCsrRegistrazioniAnniAsync")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRegistrazioniAnniAsync()
        {
            try
            {
                var response = await _gaCsrService.GetGaCsrRegistrazioniAnniAsync();
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCsrRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCsrRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.ChangeStatusGaCsrRegistrazioneAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("GetGaCsrExport")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [AutoWrapIgnore]
        public async Task<IActionResult> GetGaCsrExport([FromBody] CsrExportApiDto apiDto)
        {
            try
            {
                var entities = await _gaCsrService.GetGaCsrExports(apiDto.anno, apiDto.comuni);
                if (entities.Count > 0)
                {

                    string title = "Lista Movimenti";
                    string[] columns = { "Mese", "Data", "Cdr", "Cer", "Modalita","Produttore","Destinatario","DestinatarioIndirizzo","Trasportatore","TrasportatoreIndirizzo",
                                "PesoTotale"};
                    byte[] filecontent = ExporterHelper.ExportExcel(entities, title, "", "", "LISTA_MOVIMENTI", true, columns);

                    return new FileContentResult(filecontent, ExporterHelper.ExcelContentType)
                    {
                        FileDownloadName = "CSR_Lista_Movimenti.xlsx"
                    };
                }
                else
                {
                    return Ok(null);
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }


        #endregion

        #region Views
        [HttpGet("GetViewGaCsrRegistrazioniAsync/{all}")]
        public async Task<ApiResponse> GetViewGaCsrRegistrazioniAsync(bool all = true)
        {
            try
            {
                var view = await _gaCsrService.GetViewGaCsrRegistrazioniAsync(all);
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

        #region CsrRegistrazioniPesi
        [HttpGet("GetGaCsrRegistrazioniPesiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRegistrazioniPesiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrRegistrazioniPesiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrRegistrazioniPesiApiDto, CsrRegistrazioniPesiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrRegistrazionePesoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRegistrazionePesoByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrRegistrazionePesoByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrRegistrazionePesoApiDto, CsrRegistrazionePesoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Views
        [HttpGet("GetViewGaCsrRegistrazioniPesiByRegistrazioneIdAsync/{registrazioneId}")]
        public async Task<ApiResponse> GetViewGaCsrRegistrazioniPesiByRegistrazioneIdAsync(long registrazioneId)
        {
            try
            {
                var view = await _gaCsrService.GetViewGaCsrRegistrazioniPesiByRegistrazioneIdAsync(registrazioneId);
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

        #region CsrRipartizioniPercentuali
        [HttpGet("GetGaCsrRipartizioniPercentualiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRipartizioniPercentualiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaCsrService.GetGaCsrRipartizioniPercentualiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<CsrRipartizioniPercentualiApiDto, CsrRipartizioniPercentualiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrRipartizionePercentualeByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRipartizionePercentualeByIdAsync(long id)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrRipartizionePercentualeByIdAsync(id);
                var apiDto = dto.ToApiDto<CsrRipartizionePercentualeApiDto, CsrRipartizionePercentualeDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaCsrRipartizionePercentualeByComuneIdAsync/{comuneId}")]
        public async Task<ActionResult<ApiResponse>> GetGaCsrRipartizioniPercentualiByComuneIdAsync(long comuneId)
        {
            try
            {
                var dto = await _gaCsrService.GetGaCsrRipartizionePercentualeByIdAsync(comuneId);
                var apiDto = dto.ToApiDto<CsrRipartizionePercentualeApiDto, CsrRipartizionePercentualeDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaCsrRipartizionePercentualeAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaCsrRipartizionePercentualeAsync([FromBody] CsrRipartizionePercentualeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrRipartizionePercentualeDto, CsrRipartizionePercentualeApiDto>();
                var response = await _gaCsrService.AddGaCsrRipartizionePercentualeAsync(dto);

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

        [HttpPost("UpdateGaCsrRipartizionePercentualeAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaCsrRipartizionePercentualeAsync([FromBody] CsrRipartizionePercentualeApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<CsrRipartizionePercentualeDto, CsrRipartizionePercentualeApiDto>();
                var response = await _gaCsrService.UpdateGaCsrRipartizionePercentualeAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaCsrRipartizionePercentualeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaCsrRipartizionePercentualeAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.DeleteGaCsrRipartizionePercentualeAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateGaCsrRipartizionePercentualeAsync/{id}/{comuneId}/{produttoreId}")]
        public async Task<ActionResult<ApiResponse>> ValidateGaCsrRipartizionePercentualeAsync(long id, long comuneId, long produttoreId)
        {
            try
            {
                var response = await _gaCsrService.ValidateGaCsrRipartizionePercentualeAsync(id, comuneId, produttoreId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusGaCsrRipartizionePercentualeAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusGaCsrRipartizionePercentualeAsync(long id)
        {
            try
            {
                var response = await _gaCsrService.ChangeStatusGaCsrRipartizionePercentualeAsync(id);
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
        [HttpGet("GetViewGaCsrRipartizioniPercentualiByComuneIdAsync/{comuneId}")]
        public async Task<ApiResponse> GetViewGaCsrRipartizioniPercentualiByComuneIdAsync(long comuneId)
        {
            try
            {
                var view = await _gaCsrService.GetViewGaCsrRipartizioniPercentualiByComuneIdAsync(comuneId);
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
    }
}
