using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Api.Dtos.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Reflection;
using code = Microsoft.AspNetCore.Http.StatusCodes;
using gh = GaCloudServer.Resources.Api.Helpers.GenericHelper;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class ConsorzioController : Controller
    {
        private readonly IConsorzioService _consorzioService;
        private readonly ILogger<ConsorzioController> _logger;
        private readonly IFileService _fileService;

        public ConsorzioController(
            IConsorzioService consorzioService
            , IFileService fileService
            , ILogger<ConsorzioController> logger)
        {

            _consorzioService = consorzioService;
            _fileService = fileService;
            _logger = logger;
        }


        #region ConsorzioCers
        [HttpGet("GetConsorzioCersAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioCersAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioCersAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioCersApiDto, ConsorzioCersDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioCerByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioCerByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioCerByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioCerApiDto, ConsorzioCerDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioCerAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioCerAsync([FromBody] ConsorzioCerApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioCerDto, ConsorzioCerApiDto>();
                var response = await _consorzioService.AddConsorzioCerAsync(dto);

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

        [HttpPost("UpdateConsorzioCerAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioCerAsync([FromBody] ConsorzioCerApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioCerDto, ConsorzioCerApiDto>();
                var response = await _consorzioService.UpdateConsorzioCerAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioCerAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioCerAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioCerAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioCerAsync/{id}/{codice}/{codiceRaggruppamento}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioCerAsync(long id, string codice, string codiceRaggruppamento)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioCerAsync(id, codice, codiceRaggruppamento);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioCerAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioCerAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioCerAsync(id);
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
        [HttpGet("GetViewConsorzioCersAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioCersAsync(bool all = true)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioCersAsync(all);
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

        #region ConsorzioSmaltimenti
        [HttpGet("GetConsorzioSmaltimentiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioSmaltimentiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioSmaltimentiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioSmaltimentiApiDto, ConsorzioSmaltimentiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioSmaltimentoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioSmaltimentoByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioSmaltimentoByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioSmaltimentoApiDto, ConsorzioSmaltimentoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioSmaltimentoAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioSmaltimentoAsync([FromBody] ConsorzioSmaltimentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioSmaltimentoDto, ConsorzioSmaltimentoApiDto>();
                var response = await _consorzioService.AddConsorzioSmaltimentoAsync(dto);

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

        [HttpPost("UpdateConsorzioSmaltimentoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioSmaltimentoAsync([FromBody] ConsorzioSmaltimentoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioSmaltimentoDto, ConsorzioSmaltimentoApiDto>();
                var response = await _consorzioService.UpdateConsorzioSmaltimentoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioSmaltimentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioSmaltimentoAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioSmaltimentoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioSmaltimentoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioSmaltimentoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioSmaltimentoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioSmaltimentoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioSmaltimentoAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioSmaltimentoAsync(id);
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

        #region ConsorzioComuni
        [HttpGet("GetConsorzioComuniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioComuniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioComuniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioComuniApiDto, ConsorzioComuniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioComuneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioComuneByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioComuneByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioComuneApiDto, ConsorzioComuneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioComuneAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioComuneAsync([FromBody] ConsorzioComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioComuneDto, ConsorzioComuneApiDto>();
                var response = await _consorzioService.AddConsorzioComuneAsync(dto);

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

        [HttpPost("UpdateConsorzioComuneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioComuneAsync([FromBody] ConsorzioComuneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioComuneDto, ConsorzioComuneApiDto>();
                var response = await _consorzioService.UpdateConsorzioComuneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioComuneAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioComuneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioComuneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioComuneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioComuneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioComuneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioComuneAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioComuneAsync(id);
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
        [HttpGet("GetViewConsorzioComuniAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioComuniAsync(bool all = true)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioComuniAsync(all);
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

        #region ConsorzioProduttori
        [HttpGet("GetConsorzioProduttoriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioProduttoriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioProduttoriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioProduttoriApiDto, ConsorzioProduttoriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioProduttoreByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioProduttoreByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioProduttoreByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioProduttoreApiDto, ConsorzioProduttoreDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioProduttoreAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioProduttoreAsync([FromBody] ConsorzioProduttoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioProduttoreDto, ConsorzioProduttoreApiDto>();
                var response = await _consorzioService.AddConsorzioProduttoreAsync(dto);

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

        [HttpPost("UpdateConsorzioProduttoreAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioProduttoreAsync([FromBody] ConsorzioProduttoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioProduttoreDto, ConsorzioProduttoreApiDto>();
                var response = await _consorzioService.UpdateConsorzioProduttoreAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioProduttoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioProduttoreAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioProduttoreAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioProduttoreAsync/{id}/{cfPiva}/{indirizzo}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioProduttoreAsync(long id, string cfPiva, string indirizzo)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioProduttoreAsync(id, cfPiva, indirizzo);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioProduttoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioProduttoreAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioProduttoreAsync(id);
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
        [HttpGet("GetViewConsorzioProduttoriAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioProduttoriAsync(bool all = true)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioProduttoriAsync(all);
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

        #region ConsorzioDestinatari
        [HttpGet("GetConsorzioDestinatariAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioDestinatariAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioDestinatariAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioDestinatariApiDto, ConsorzioDestinatariDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioDestinatarioByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioDestinatarioByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioDestinatarioByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioDestinatarioApiDto, ConsorzioDestinatarioDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioDestinatarioAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioDestinatarioAsync([FromBody] ConsorzioDestinatarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioDestinatarioDto, ConsorzioDestinatarioApiDto>();
                var response = await _consorzioService.AddConsorzioDestinatarioAsync(dto);

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

        [HttpPost("UpdateConsorzioDestinatarioAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioDestinatarioAsync([FromBody] ConsorzioDestinatarioApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioDestinatarioDto, ConsorzioDestinatarioApiDto>();
                var response = await _consorzioService.UpdateConsorzioDestinatarioAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioDestinatarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioDestinatarioAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioDestinatarioAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioDestinatarioAsync/{id}/{cfPiva}/{indirizzo}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioDestinatarioAsync(long id, string cfPiva, string indirizzo)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioDestinatarioAsync(id, cfPiva, indirizzo);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioDestinatarioAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioDestinatarioAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioDestinatarioAsync(id);
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
        [HttpGet("GetViewConsorzioDestinatariAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioDestinatariAsync(bool all = true)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioDestinatariAsync(all);
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

        #region ConsorzioTrasportatori
        [HttpGet("GetConsorzioTrasportatoriAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioTrasportatoriAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioTrasportatoriAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioTrasportatoriApiDto, ConsorzioTrasportatoriDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioTrasportatoreByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioTrasportatoreByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioTrasportatoreByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioTrasportatoreApiDto, ConsorzioTrasportatoreDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioTrasportatoreAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioTrasportatoreAsync([FromBody] ConsorzioTrasportatoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioTrasportatoreDto, ConsorzioTrasportatoreApiDto>();
                var response = await _consorzioService.AddConsorzioTrasportatoreAsync(dto);

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

        [HttpPost("UpdateConsorzioTrasportatoreAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioTrasportatoreAsync([FromBody] ConsorzioTrasportatoreApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioTrasportatoreDto, ConsorzioTrasportatoreApiDto>();
                var response = await _consorzioService.UpdateConsorzioTrasportatoreAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioTrasportatoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioTrasportatoreAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioTrasportatoreAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioTrasportatoreAsync/{id}/{cfPiva}/{indirizzo}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioTrasportatoreAsync(long id, string cfPiva, string indirizzo)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioTrasportatoreAsync(id, cfPiva, indirizzo);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioTrasportatoreAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioTrasportatoreAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioTrasportatoreAsync(id);
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
        [HttpGet("GetViewConsorzioTrasportatoriAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioTrasportatoriAsync(bool all = true)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioTrasportatoriAsync(all);
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

        #region ConsorzioRegistrazioni
        [HttpGet("GetConsorzioRegistrazioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioRegistrazioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioRegistrazioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioRegistrazioniApiDto, ConsorzioRegistrazioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioRegistrazioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioRegistrazioneByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioRegistrazioneByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioRegistrazioneApiDto, ConsorzioRegistrazioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioRegistrazioneAsync([FromBody] ConsorzioRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioRegistrazioneDto, ConsorzioRegistrazioneApiDto>();
                var response = await _consorzioService.AddConsorzioRegistrazioneAsync(dto);

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

        [HttpPost("UpdateConsorzioRegistrazioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioRegistrazioneAsync([FromBody] ConsorzioRegistrazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioRegistrazioneDto, ConsorzioRegistrazioneApiDto>();
                var response = await _consorzioService.UpdateConsorzioRegistrazioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioRegistrazioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioRegistrazioneAsync/{id}/{userId}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioRegistrazioneAsync(long id, string userId)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioRegistrazioneAsync(id, userId);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioRegistrazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioRegistrazioneAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioRegistrazioneAsync(id);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPut("ImportConsorzioRegistrazioniAsync/{step}")]
        public async Task<ActionResult<ApiResponse>> ImportConsorzioRegistrazioniAsync([FromRoute] int step)
        {
            try
            {
                int passed = 0;
                switch (step)
                {
                    case 1:

                        break;
                }
                
                return new ApiResponse(passed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
        #endregion

        #region Views
        [HttpGet("GetViewConsorzioRegistrazioniAsync/{all}")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioRegistrazioniAsync(bool all = true)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioRegistrazioniAsync(all);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewConsorzioRegistrazioniByRolesAsync/{roles}")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioRegistrazioniByRolesAsync(string roles)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioRegistrazioneByRolesAsync(roles);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("GetViewConsorzioRegistrazioniByFilterAsync")]
        public async Task<ApiResponse> GetViewConsorzioRegistrazioniByFilterAsync([FromBody] ConsorzioRegistrazioniFilterApiDto apiDto)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioRegistrazioniByFilterAsync(apiDto.id, apiDto.roles);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("GetViewConsorzioRegistrazioniQueryable")]
        public ApiResponse GetViewConsorzioRegistrazioniQueryable(GridOperationsModel filter)
        {
            try
            {
                var entities = _consorzioService.GetViewConsorzioRegistrazioniQueryable(filter);
                return new ApiResponse(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }


        //[HttpPost("GetViewConsorzioRegistrazioniQueryableFilterSingleParam/{produttoriId}")]
        //public ApiResponse GetViewConsorzioRegistrazioniQueryableFilterSingleParam(GridOperationsModel filter, string? produttoriId = "0")
        //{
        //    try
        //    {
        //        produttoriId = produttoriId == "NaN" ? "0" : produttoriId;
        //        var entities = _consorzioService.GetViewConsorzioRegistrazioniByProduttoreQueryable(filter, produttoriId.Split(",").Select(long.Parse).ToArray());
        //        return new ApiResponse(entities);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiException(ex.Message);
        //    }
        //}

        [HttpPost("GetViewConsorzioRegistrazioniQueryableFilterSingleParam/{roles}")]
        public ApiResponse GetViewConsorzioRegistrazioniQueryableFilterSingleParam(GridOperationsModel filter, string? roles = "0")
        {
            try
            {
                roles = roles == "NaN" ? "0" : roles;
                var entities = _consorzioService.GetViewConsorzioRegistrazioniByRolesQueryable(filter, roles.Split(","));
                return new ApiResponse(entities);

            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        [HttpPost("GetViewConsorzioRegistrazioniQueryableByDateAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewConsorzioRegistrazioniQueryableByDateAsync(DateRangeDto dto)
        {
            try
            {
                var view = await _consorzioService.GetViewConsorzioRegistrazioniQueryableByDateAsync(dto.dateStart, dto.dateEnd.SetTime(23, 59, 59));
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

        #region ConsorzioRegistrazioniAllegati

        [HttpGet("GetConsorzioRegistrazioniAllegatiByRegistrazioneIdAsync/{consorzioRegistrazioneId}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioRegistrazioniAllegatiByRegistrazioneIdAsync(long consorzioRegistrazioneId)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioRegistrazioniAllegatiByRegistrazioneIdAsync(consorzioRegistrazioneId);
                var apiDtos = dtos.ToApiDto<ConsorzioRegistrazioniAllegatiApiDto, ConsorzioRegistrazioniAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioRegistrazioniAllegatiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioRegistrazioniAllegatiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioRegistrazioniAllegatiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioRegistrazioniAllegatiApiDto, ConsorzioRegistrazioniAllegatiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioRegistrazioneAllegatoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioRegistrazioneAllegatoByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioRegistrazioneAllegatoByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioRegistrazioneAllegatoApiDto, ConsorzioRegistrazioneAllegatoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioRegistrazioneAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioRegistrazioneAllegatoAsync([FromForm] ConsorzioRegistrazioneAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Consorzio";
                var dto = apiDto.ToDto<ConsorzioRegistrazioneAllegatoDto, ConsorzioRegistrazioneAllegatoApiDto>();
                var response = await _consorzioService.AddConsorzioRegistrazioneAllegatoAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _consorzioService.UpdateConsorzioRegistrazioneAllegatoAsync(dto);
                    return new ApiResponse("CreatedWithFile", response, code.Status201Created);
                }

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

        [HttpPost("UpdateConsorzioRegistrazioneAllegatoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioRegistrazioneAllegatoAsync([FromForm] ConsorzioRegistrazioneAllegatoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Consorzio";
                var dto = apiDto.ToDto<ConsorzioRegistrazioneAllegatoDto, ConsorzioRegistrazioneAllegatoApiDto>();
                var response = await _consorzioService.UpdateConsorzioRegistrazioneAllegatoAsync(dto);
                bool failureDelete = false;
                if (apiDto.deleteFile)
                {
                    var deleteResponse = await _fileService.Remove(apiDto.FileId);
                    if (!deleteResponse)
                    {
                        failureDelete = true;

                    }
                    else
                    {
                        dto.Id = response;
                        dto.FileFolder = null;
                        dto.FileName = null;
                        dto.FileSize = null;
                        dto.FileType = null;
                        dto.FileId = null;
                        var updateFileResponse = await _consorzioService.UpdateConsorzioRegistrazioneAllegatoAsync(dto);
                    }
                }

                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    var updateFileResponse = await _consorzioService.UpdateConsorzioRegistrazioneAllegatoAsync(dto);

                    if (!failureDelete)
                    {
                        return new ApiResponse("UpdatedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("UpdatedWithFile/FailureDelete", response, code.Status207MultiStatus);
                    }

                }

                if (!failureDelete)
                {
                    return new ApiResponse("Updated", response, code.Status200OK);
                }
                else
                {
                    return new ApiResponse("Updated/FailureDelete", response, code.Status207MultiStatus);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioRegistrazioneAllegatoAsync/{id}/{fileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioRegistrazioneAllegatoAsync(long id, string fileId)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioRegistrazioneAllegatoAsync(id);
                if (response && fileId != null && fileId != "null" && fileId != "")
                {
                    var deleteResponse = await _fileService.Remove(fileId);
                    if (deleteResponse)
                    {
                        return new ApiResponse("DeletedWithFile", response, code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("DeletedErrorFile", response, code.Status206PartialContent);
                    }
                }

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioRegistrazioneAllegatoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioRegistrazioneAllegatoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioRegistrazioneAllegatoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioRegistrazioneAllegatoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioRegistrazioneAllegatoAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioRegistrazioneAllegatoAsync(id);
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

        #region ConsorzioOperazioni
        [HttpGet("GetConsorzioOperazioniAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioOperazioniAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioOperazioniAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioOperazioniApiDto, ConsorzioOperazioniDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioOperazioneByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioOperazioneByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioOperazioneByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioOperazioneApiDto, ConsorzioOperazioneDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioOperazioneAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioOperazioneAsync([FromBody] ConsorzioOperazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioOperazioneDto, ConsorzioOperazioneApiDto>();
                var response = await _consorzioService.AddConsorzioOperazioneAsync(dto);

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

        [HttpPost("UpdateConsorzioOperazioneAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioOperazioneAsync([FromBody] ConsorzioOperazioneApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioOperazioneDto, ConsorzioOperazioneApiDto>();
                var response = await _consorzioService.UpdateConsorzioOperazioneAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioOperazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioOperazioneAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioOperazioneAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioOperazioneAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioOperazioneAsync(long id, string descrizione)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioOperazioneAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioOperazioneAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioOperazioneAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioOperazioneAsync(id);
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

        #region ConsorzioPeriodi
        [HttpGet("GetConsorzioPeriodiAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioPeriodiAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioPeriodiAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioPeriodiApiDto, ConsorzioPeriodiDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioPeriodoByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioPeriodoByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioPeriodoByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioPeriodoApiDto, ConsorzioPeriodoDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioPeriodoAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioPeriodoAsync([FromBody] ConsorzioPeriodoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioPeriodoDto, ConsorzioPeriodoApiDto>();
                var response = await _consorzioService.AddConsorzioPeriodoAsync(dto);

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

        [HttpPost("UpdateConsorzioPeriodoAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateConsorzioPeriodoAsync([FromBody] ConsorzioPeriodoApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<ConsorzioPeriodoDto, ConsorzioPeriodoApiDto>();
                var response = await _consorzioService.UpdateConsorzioPeriodoAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteConsorzioPeriodoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteConsorzioPeriodoAsync(long id)
        {
            try
            {
                var response = await _consorzioService.DeleteConsorzioPeriodoAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Functions
        [HttpGet("ValidateConsorzioPeriodoAsync/{id}/{descrizione}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioPeriodoAsync(long id, string descrizione)
        {
            try
            {
                var response = await _consorzioService.ValidateConsorzioPeriodoAsync(id, descrizione);
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("ChangeStatusConsorzioPeriodoAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> ChangeStatusConsorzioPeriodoAsync(long id)
        {
            try
            {
                var response = await _consorzioService.ChangeStatusConsorzioPeriodoAsync(id);
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

        #region ConsorzioImportsTasks

        [HttpGet("GetConsorzioImportsTasksAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioImportsTasksAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _consorzioService.GetConsorzioImportsTasksAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<ConsorzioImportsTasksApiDto, ConsorzioImportsTasksDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetConsorzioImportTaskByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetConsorzioImportTaskByIdAsync(long id)
        {
            try
            {
                var dto = await _consorzioService.GetConsorzioImportTaskByIdAsync(id);
                var apiDto = dto.ToApiDto<ConsorzioImportTaskApiDto, ConsorzioImportTaskDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddConsorzioImportTaskAsync")]
        public async Task<ActionResult<ApiResponse>> AddConsorzioImportTaskAsync([FromForm] ConsorzioImportTaskApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Consorzio/Log";
                var dto = apiDto.ToDto<ConsorzioImportTaskDto, ConsorzioImportTaskApiDto>();
                var response = await _consorzioService.AddConsorzioImportTaskAsync(dto);
                if (apiDto.uploadFile)
                {
                    var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);
                    dto.Id = response;
                    dto.FileFolder = fileFolder;
                    dto.FileName = fileUploadResponse.fileName;
                    dto.FileSize = apiDto.File.Length.ToString();
                    dto.FileType = apiDto.File.ContentType;
                    dto.FileId = fileUploadResponse.id;
                    return new ApiResponse("CreatedWithFile", response, code.Status201Created);
                }

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


        #region Functions
        [HttpPost("UploadConsorzioImportFileAsync")]
        public async Task<ActionResult<ApiResponse>> UploadConsorzioImportFileAsync([FromForm] FileApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                string fileFolder = "GaCloud/Consorzio/ImportFiles";

                var fileUploadResponse = await _fileService.Upload(apiDto.File, fileFolder, apiDto.File.FileName);

                var guid = new Guid();

                var response = new { taskId = guid, fileId = fileUploadResponse.id };

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

        [HttpGet("ValidateConsorzioImportStep1/{fileId}")]
        public async Task<ActionResult<ApiResponse>> ValidateConsorzioImportStep1(string fileId)
        {
            try
            {
                var file = await _fileService.DownloadById(fileId);
                DataTable dt = new DataTable();

                using (TextFieldParser parser = new TextFieldParser(file.stream))
                {
                    parser.Delimiters = new string[] { ";" };
                    parser.HasFieldsEnclosedInQuotes = true;

                    // Read the header row to create DataTable columns
                    if (!parser.EndOfData)
                    {
                        string[] headers = parser.ReadFields();
                        foreach (string header in headers)
                        {
                            dt.Columns.Add(header);
                        }
                    }

                    // Read the remaining rows and populate the DataTable
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        dt.Rows.Add(fields);
                    }

                }

                if (dt.Columns.Count == 19)
                {
                    List<string> prgCheck = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        
                        if (!gh.IsNotNullOrEmpty(row.ItemArray[0].ToString()) || !gh.CanConvertToInt(row.ItemArray[0].ToString()))
                        {
                            return new ApiResponse("Step1PrgEmptyError", code.Status200OK);
                        }
                        else
                        {
                            if (prgCheck.Contains(row.ItemArray[0].ToString()))
                            {
                                return new ApiResponse("Step1PrgDuplicateError", code.Status200OK);
                            }
                            else
                            {
                                prgCheck.Add(row.ItemArray[0].ToString());
                            }
                        }
                    }

                    int index = 0;
                    List<ConsorzioImportErrorApiDto> errorList = new List<ConsorzioImportErrorApiDto>();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (index == 0)
                        {
                            index++;
                        }
                        else
                        {
                            int i = 0;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()) || !gh.CanConvertToInt(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo PRG è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()) || !gh.CanConvertToDate(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo DATA è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo CER è vuoto o non valido" });
                            }
                            i++;
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()) || !gh.CanConvertToDouble(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo PESO_KG è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo OPERAZIONE è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo PRODUTTORE_RAGSO è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo PRODUTTORE_INDIRIZZO è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo PRODUTTORE_CFPIVA è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo PRODUTTORE_ISTAT_COMUNE è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo DESTINATARIO_RAGSO è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo DESTINATARIO_INDIRIZZO è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo DESTINATARIO_CFPIVA è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo DESTINATARIO_ISTAT_COMUNE è vuoto o non valido" });
                            }
                            i++;
                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo TRASPORTATORE_RAGSO è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo TRASPORTATORE_INDIRIZZO è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo TRASPORTATORE_CFPIVA è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo TRASPORTATORE_ISTAT_COMUNE è vuoto o non valido" });
                            }
                            i++;

                            if (!gh.IsNotNullOrEmpty(row.ItemArray[i].ToString()) || !gh.CanConvertToInt(row.ItemArray[i].ToString()))
                            {
                                errorList.Add(new ConsorzioImportErrorApiDto() { row = row.ItemArray[0].ToString(), error = "Il campo PERIODO è vuoto o non valido" });
                            }
                            i++;

                            index++;


                        }
                    }

                    if (errorList.Count()==0)
                    {
                        return new ApiResponse("Passed", code.Status200OK);
                    }
                    else
                    {
                        return new ApiResponse("Step1RowError", errorList, code.Status200OK);
                    }
                }
                else
                {
                    return new ApiResponse("Step1ColumnError",dt.Columns.Count, code.Status200OK);
                }
                    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex);
            }
        }
        #endregion

        #endregion
    }
}