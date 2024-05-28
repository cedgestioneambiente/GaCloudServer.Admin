using AutoWrapper.Filters;
using AutoWrapper.Wrappers;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Template;
using GaCloudServer.BusinnessLogic.Services;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.Dtos.Aziende;
using GaCloudServer.Resources.Api.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Resources.BackOffice;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class GaBackOfficeController : Controller
    {
        private readonly IGaBackOfficeService _gaBackOfficeService;
        private readonly IQueryBuilderService _queryBuilderService;
        private readonly ILogger<GaMezziController> _logger;
        private readonly IPrintService _printService;

        public GaBackOfficeController(
            IGaBackOfficeService gaBackOfficeService
            , IQueryBuilderService queryBuilderService
            ,ILogger<GaMezziController> logger,
            IPrintService printService)
        {

            _gaBackOfficeService = gaBackOfficeService;
            _queryBuilderService=queryBuilderService;
            _logger = logger;
            _printService = printService;
        }

        #region BackOfficeComuni

        #region Views
        [HttpGet("GetViewGaBackOfficeComuniAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeComuniAsync()
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeComuniAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeComuniCustomAsync")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeComuniCustomAsync()
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeComuniCustomAsync();
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

        #region BackOfficeUtenze

        #region Functions
        [HttpPost("CalcGaBackOfficeMassimali")]
        public async Task<ActionResult<ApiResponse>> CalcGaBackOfficeMassimali([FromBody] List<ViewGaBackOfficeUtenzePartite> dtos)
        {
            try
            {

                var view = await _gaBackOfficeService.CalcGaBackOfficeMassimali(dtos);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region Views
        [HttpGet("GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync/{codAzi}/{ragCliCf}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi,string ragCliCf)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(codAzi, ragCliCf);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
              _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync/{codAzi}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(string codAzi, string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(codAzi, numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync/{codAzi}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync(string codAzi, string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync(codAzi, numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzePartiteVariazioniByCpAziAndNumConAndPartitaAsync/{codAzi}/{numCon}/{partita}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzePartiteVariazioniByCpAziAndNumConAndPartitaAsync(string codAzi, string numCon,string partita)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzePartiteVariazioniByCpAziAndNumConAndPartitaAsync(codAzi, numCon,partita);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeUtenzeZoneAsync")]
        public async Task<ApiResponse> GetViewGaBackOfficeUtenzeZoneAsync()
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeZoneAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
        #endregion

        #region Sp
        [HttpGet("GetSpGaBackOfficeUtenzeAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetSpGaBackOfficeUtenzeAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetSpGaBackOfficeUtenzeAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetSpGaBackOfficeUtenzePartiteAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetSpGaBackOfficeUtenzePartiteAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetSpGaBackOfficeUtenzePartiteAsync(codAzi, filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetSpGaBackOfficeUtenzeDispositiviAsync/{codAzi}/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetSpGaBackOfficeUtenzeDispositiviAsync(string codAzi, string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetSpGaBackOfficeUtenzeDispositiviAsync(codAzi, filter);
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

        #region BackOfficeNdUtenze

        #region Views
        [HttpGet("GetViewGaBackOfficeNdUtenzeByCodAziAsync/{codAzi}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeByCodAziAsync(string codAzi)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeByCodAziAsync(codAzi);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync/{codAzi}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync(string codAzi,string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync(codAzi,numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync/{codAzi}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync(string codAzi)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync(codAzi);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync/{codAzi}/{ragCliCf}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi,string ragCliCf)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync(codAzi,ragCliCf);
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

        #region BackOfficeContenitori

        #region Views
        [HttpGet("GetViewGaBackOfficeContenitoriLettureByIdentiAsync/{identi}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeContenitoriLettureByIdentiAsync(string identi)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeContenitoriLettureByIdentiAsync(identi);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync/{codComune}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(string codComune,string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(codComune,numCon);
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

        #region BackOfficeNovi

        #region Views
        [HttpGet("GetViewGaBackOfficeUtenzeNoviAsync/{filter}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeNoviAsync(string filter)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeNoviAsync(filter);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #region Views
        [HttpGet("GetViewGaBackOfficeUtenzeNoviByAddressAsync/{via}/{startNumCiv}/{endNumCiv}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzeNoviByAddressAsync(string via,int startNumCiv,int endNumCiv)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzeNoviByAddressAsync(via, startNumCiv, endNumCiv);
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

        #endregion

        #region BackOfficeDocRecipes
        [HttpGet("GetGaBackOfficeDocRecipesAsync/{page}/{pageSize}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeDocRecipesAsync(int page = 1, int pageSize = 0)
        {
            try
            {
                var dtos = await _gaBackOfficeService.GetGaBackOfficeDocRecipesAsync(page, pageSize);
                var apiDtos = dtos.ToApiDto<BackOfficeDocRecipesApiDto, BackOfficeDocRecipesDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeDocRecipesByIdAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeDocRecipesByIdAsync(long id)
        {
            try
            {
                var dto = await _gaBackOfficeService.GetGaBackOfficeDocRecipesByIdAsync(id);
                var apiDto = dto.ToApiDto<BackOfficeDocReceiptApiDto, BackOfficeDocReceiptDto>();
                return new ApiResponse(apiDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeDocRecipesByCodCliAndNumConAsync/{codCli}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeDocRecipesByCodCliAndNumConAsync(string codCli,string numCon)
        {
            try
            {
                var dtos = await _gaBackOfficeService.GetGaBackOfficeDocRecipesByCodCliAndNumConAsync(codCli, numCon);
                var apiDtos = dtos.ToApiDto<BackOfficeDocRecipesApiDto, BackOfficeDocRecipesDto>();
                return new ApiResponse(apiDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("AddGaBackOfficeDocReceiptAsync")]
        public async Task<ActionResult<ApiResponse>> AddGaBackOfficeDocReceiptAsync([FromBody] BackOfficeDocReceiptApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<BackOfficeDocReceiptDto, BackOfficeDocReceiptApiDto>();
                var response = await _gaBackOfficeService.AddGaBackOfficeDocReceiptAsync(dto);

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

        [HttpPost("UpdateGaBeckOfficeDocReceiptAsync")]
        public async Task<ActionResult<ApiResponse>> UpdateGaBeckOfficeDocReceiptAsync([FromBody] BackOfficeDocReceiptApiDto apiDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ApiProblemDetailsException(ModelState);
                }
                var dto = apiDto.ToDto<BackOfficeDocReceiptDto, BackOfficeDocReceiptApiDto>();
                var response = await _gaBackOfficeService.UpdateGaBeckOfficeDocReceiptAsync(dto);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpDelete("DeleteGaBackOfficeDocReceiptAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteGaBackOfficeDocReceiptAsync(long id)
        {
            try
            {
                var response = await _gaBackOfficeService.DeleteGaBackOfficeDocReceiptAsync(id);

                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        #endregion

        #region BackOfficeInsolutoNovi

        #region Functions
        [HttpPost("PrintGaBackOfficeInsolutiNoviF24Async")]
        public async Task<ActionResult<ApiResponse>> PrintGaBackOfficeInsolutiNoviF24Async([FromBody] BackOfficeInsolutoNoviApiDto dto)
        {
            //var tributi = dto.data.GroupBy(x => x.CodTributo).Select(group => new { CodTributo = group.Key, Totale = group.Sum(x => x.Saldo) });

            var rate = dto.data
                .GroupBy(x => x.CodTributo)
                .SelectMany(group =>
                {
                    double totale = group.Sum(item => item.Saldo) ?? 0;
                    double totaleNoDec= Math.Floor(totale);
                    double resto = totale - totaleNoDec;
                    double totaleRata = Math.Round(totaleNoDec / dto.rate, 2,MidpointRounding.ToNegativeInfinity);
                    //double resto = totale - (totaleRata * dto.rate);

                    

                    List<BackOfficeF24RataTemplateDto> rate = new List<BackOfficeF24RataTemplateDto>();
                    double totaleCopertura = 0.0;

                    for (int i = 0; i < dto.rate; i++)
                    {
                        double totRata = 0.0;
                        totaleCopertura += totaleRata;
                        if (dto.rate - 1 == i)
                        {
                            double residuo = totale - (totaleCopertura + resto);

                            totRata = totaleRata + resto+residuo;
                        }
                        else
                        {
                            totRata = totaleRata;
                        }

                        rate.Add(new BackOfficeF24RataTemplateDto()
                        {
                            CodTributo = group.Key,
                            Totale = totRata,
                            Rata = $"{(i + 1):D2}{dto.rate:D2}"
                        });

                    }
                    return rate;
                });


            //max data avviso su codtributo
            try
            {
                var list = new List<BackOfficeF24TemplateDto>();

                foreach (var x in rate.GroupBy(x=>x.Rata))
                {

                    var _dto = await GenerateBackOfficeF24Template(
                        dto.data[0].CodFis,
                        dto.data[0].RagSo.Split(" ")[0].ToString(),
                        dto.data[0].RagSo.Split(" ")[1].ToString(),
                        dto.data[0].AnnoRif.ToString(),
                        "E",
                        "L",
                        "F965",
                        x.ToList(),
                        "F24") ;
                    list.Add(_dto);
                }

                string cData = JsonConvert.SerializeObject(list);

                var receipt = new BackOfficeDocReceiptDto();
                receipt.OpDate= DateTime.Now;
                receipt.DocType = "F24";
                receipt.CData = cData;
                receipt.NumCon = dto.data[0].NumCont;
                receipt.CodCli = dto.data[0].CodCli;
                receipt.AnnoRif = dto.data[0].AnnoRif.ToString();
                receipt.Note = $"Rate generate: {dto.rate}";

                await _gaBackOfficeService.AddGaBackOfficeDocReceiptAsync(receipt);

                var response = await _printService.PrintMerged(list,null,1,new DinkToPdf.MarginSettings() { Bottom=0,Top=0,Left=0,Right=0});
                
                return new ApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpPost("ReprintGaBackOfficeInsolutiNoviF24Async")]
        public async Task<ActionResult<ApiResponse>> ReprintGaBackOfficeInsolutiNoviF24Async([FromBody] CDataApiDto dto)
        {
            try { 
                List<BackOfficeF24TemplateDto> list = JsonConvert.DeserializeObject<List<BackOfficeF24TemplateDto>>(dto.CData);

                var response = await _printService.PrintMerged(list, null, 1, new DinkToPdf.MarginSettings() { Bottom = 0, Top = 0, Left = 0, Right = 0 });

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
        [HttpGet("GetViewGaBackOfficeInsolutoTariNoviByFilterAsync/{codCli}/{numCon}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeInsolutoTariNoviByFilterAsync(string codCli,string numCon)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeInsolutoTariNoviByFilterAsync(codCli,numCon);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetBackOfficeTariNoviFinancialPositionAsync/{codCli}")]
        public async Task<ActionResult<ApiResponse>> GetBackOfficeTariNoviFinancialPositionAsync(string codCli)
        {
            try
            {
                var query= System.IO.File.ReadAllText(@".\Query\BackOffice\TariNoviFinancialPosition.sql");
                query = string.Format(query, codCli);

                var response = await _queryBuilderService.GetFromQueryAsync(query);
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

        #region BackOfficeCli
        #region Views
        [HttpGet("GetViewGaBackOfficeUtenzaCliFatByFilterAsync/{codCli}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzaCliFatByFilterAsync(string codCli)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzaCliFatByFilterAsync(codCli);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        [HttpGet("GetViewGaBackOfficeUtenzaCliSedByFilterAsync/{codCli}")]
        public async Task<ActionResult<ApiResponse>> GetViewGaBackOfficeUtenzaCliSedByFilterAsync(string codCli)
        {
            try
            {
                var view = await _gaBackOfficeService.GetViewGaBackOfficeUtenzaCliSedByFilterAsync(codCli);
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

        #region BackOfficeZone
        [HttpGet("GetGaBackOfficeZoneComuniAsync")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneComuniAsync()
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneComuniAsync();
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeZoneVieByComuneAsync/{comune}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneVieByComuneAsync(string comune)
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneVieByComuneAsync(comune);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeZoneCiviciByComuneAndViaAsync/{comune}/{via}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneCiviciByComuneAndViaAsync(string comune,string via)
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneCiviciByComuneAndViaAsync(comune,via);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

        [HttpGet("GetGaBackOfficeZoneZonaAsync/{comune}/{via}/{civico}")]
        public async Task<ActionResult<ApiResponse>> GetGaBackOfficeZoneZonaAsync(string comune, string via,string civico)
        {
            try
            {
                var view = await _gaBackOfficeService.GetGaBackOfficeZoneZonaAsync(comune, via,civico);
                return new ApiResponse(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }
        #endregion

        #region Helpers
        private async Task<BackOfficeF24TemplateDto> GenerateBackOfficeF24Template(string codFis,string cognome,string nome, string annoRif,string sezione,string sezione2, string codEnte,List<BackOfficeF24RataTemplateDto> _dto,  string title, string fileName = "BackOfficeF24.pdf", string css = "BackOfficeF24")
        {
            var dto = new BackOfficeF24TemplateDto()
            {
                FileName = fileName,
                FilePath = @"Print/BackOffice",
                Title = title,
                Css = css,
                TemplateName = css,
                HeaderSettings = null,
                FooterSettings = null,
                Copies = 1,
                CodFis = codFis,
                Cognome = cognome,
                Nome = nome,
                Rows = new List<BackOfficeF24RowTemplateDto>()
            };

            foreach (var item in _dto)
            {
                var row = new BackOfficeF24RowTemplateDto();
                row.Sezione = sezione;
                row.Sezione2 = sezione2;
                row.CodEnte=codEnte;
                row.Tipo = item.CodTributo;
                row.Valore = item.Totale.ToString();
                row.Rata = item.Rata;
                row.Anno = annoRif;
                dto.Rows.Add(row);
            }

            return dto;

        }
        #endregion

    }
}