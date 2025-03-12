using GaCloudServer.Admin.EntityFramework.Shared.Constants;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Helpers;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaBackOfficeService:IGaBackOfficeService
    {
        protected readonly IGenericRepository<BackOfficeTicket> gaBackOfficeTicketsRepo;
        protected readonly IGenericRepository<BackOfficeParametroOnCategoria> gaBackOfficeParametroOnCategoriaRepo;
        protected readonly IGenericRepository<BackOfficeMargine> gaBackOfficeMarginiRepo;
        protected readonly IGenericRepository<BackOfficeZona> gaBackOfficeZoneRepo;
        protected readonly IGenericRepository<BackOfficeDocReceipt> gaBackOfficeDocRecipesRepo;


        protected readonly IGenericRepository<ViewGaBackOfficeComuni> viewGaBackOfficeComuniRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeGrouped> viewGaBackOfficeUtenzeGroupedRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeNdUtenze> viewGaBackOfficeNdUtenzeRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped> viewGaBackOfficeNdUtenzeGroupedRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeContenitoriLetture> viewGaBackOfficeContenitoriLettureRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenze> viewGaBackOfficeUtenzeRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzePartite> viewGaBackOfficeUtenzePartiteRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzePartiteVariazioni> viewGaBackOfficeUtenzePartiteVariazioniRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzePartiteDetail> viewGaBackOfficeUtenzePartiteDetailRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzePartiteGrp> viewGaBackOfficeUtenzePartiteGrpRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeZone> viewGaBackOfficeUtenzeZoneRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeInsolutoTariNovi> viewGaBackOfficeInsolutoTariNoviRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeNovi> viewGaBackOfficeUtenzeNoviRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeCliFat> viewGaBackOfficeUtenzeCliFatRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeCliSed> viewGaBackOfficeUtenzeCliSedRepo;

        protected readonly IGenericRepository<ViewGaBackOfficeZone> viewGaBackOfficeZoneRepo;

        protected readonly IProcedureManager<SpGaBackOfficeUtenze> spGaBackOfficeUtenzeRepo;
        protected readonly IProcedureManager<SpGaBackOfficeUtenzePartite> spGaBackOfficeUtenzePartiteRepo;
        protected readonly IProcedureManager<SpGaBackOfficeUtenzeDispositivi> spGaBackOfficeUtenzeDispositiviRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaBackOfficeService(
            IGenericRepository<BackOfficeTicket> gaBackOfficeTicketsRepo,
            IGenericRepository<BackOfficeParametroOnCategoria> gaBackOfficeParametroOnCategoriaRepo,
            IGenericRepository<BackOfficeMargine> gaBackOfficeMarginiRepo,
            IGenericRepository<BackOfficeZona> gaBackOfficeZoneRepo,
            IGenericRepository<BackOfficeDocReceipt> gaBackOfficeDocRecipesRepo,

            IGenericRepository<ViewGaBackOfficeComuni> viewGaBackOfficeComuniRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeGrouped> viewGaBackOfficeUtenzeGroupedRepo,
            IGenericRepository<ViewGaBackOfficeNdUtenze> viewGaBackOfficeNdUtenzeRepo,
            IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped> viewGaBackOfficeNdUtenzeGroupedRepo,
            IGenericRepository<ViewGaBackOfficeContenitoriLetture> viewGaBackOfficeContenitoriLettureRepo,
            IGenericRepository<ViewGaBackOfficeUtenze> viewGaBackOfficeUtenzeRepo,
            IGenericRepository<ViewGaBackOfficeUtenzePartite> viewGaBackOfficeUtenzePartiteRepo,
            IGenericRepository<ViewGaBackOfficeUtenzePartiteVariazioni> viewGaBackOfficeUtenzePartiteVariazioniRepo,
            IGenericRepository<ViewGaBackOfficeUtenzePartiteDetail> viewGaBackOfficeUtenzePartiteDetailRepo,
            IGenericRepository<ViewGaBackOfficeUtenzePartiteGrp> viewGaBackOfficeUtenzePartiteGrpRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeZone> viewGaBackOfficeUtenzeZoneRepo,
            IGenericRepository<ViewGaBackOfficeInsolutoTariNovi> viewGaBackOfficeInsolutoTariNoviRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeNovi> viewGaBackOfficeUtenzeNoviRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeCliFat> viewGaBackOfficeUtenzeCliFatRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeCliSed> viewGaBackOfficeUtenzeCliSedRepo,

            IGenericRepository<ViewGaBackOfficeZone> viewGaBackOfficeZoneRepo,

            IProcedureManager<SpGaBackOfficeUtenze> spGaBackOfficeUtenzeRepo,
            IProcedureManager<SpGaBackOfficeUtenzePartite> spGaBackOfficeUtenzePartiteRepo,
            IProcedureManager<SpGaBackOfficeUtenzeDispositivi> spGaBackOfficeUtenzeDispositiviRepo,

        IUnitOfWork unitOfWork)
        {
            this.gaBackOfficeTicketsRepo = gaBackOfficeTicketsRepo;
            this.gaBackOfficeParametroOnCategoriaRepo = gaBackOfficeParametroOnCategoriaRepo;
            this.gaBackOfficeMarginiRepo = gaBackOfficeMarginiRepo;
            this.gaBackOfficeZoneRepo = gaBackOfficeZoneRepo;
            this.gaBackOfficeDocRecipesRepo = gaBackOfficeDocRecipesRepo;

            this.viewGaBackOfficeUtenzeGroupedRepo = viewGaBackOfficeUtenzeGroupedRepo;
            this.viewGaBackOfficeNdUtenzeRepo = viewGaBackOfficeNdUtenzeRepo;
            this.viewGaBackOfficeNdUtenzeGroupedRepo = viewGaBackOfficeNdUtenzeGroupedRepo;

            this.viewGaBackOfficeComuniRepo = viewGaBackOfficeComuniRepo;

            this.viewGaBackOfficeContenitoriLettureRepo = viewGaBackOfficeContenitoriLettureRepo;

            this.viewGaBackOfficeUtenzeRepo = viewGaBackOfficeUtenzeRepo;
            this.viewGaBackOfficeUtenzePartiteRepo = viewGaBackOfficeUtenzePartiteRepo;
            this.viewGaBackOfficeUtenzePartiteVariazioniRepo = viewGaBackOfficeUtenzePartiteVariazioniRepo;
            this.viewGaBackOfficeUtenzePartiteDetailRepo = viewGaBackOfficeUtenzePartiteDetailRepo;
            this.viewGaBackOfficeUtenzePartiteGrpRepo = viewGaBackOfficeUtenzePartiteGrpRepo;
            this.viewGaBackOfficeUtenzeDispositiviRepo = viewGaBackOfficeUtenzeDispositiviRepo;
            this.viewGaBackOfficeUtenzeZoneRepo = viewGaBackOfficeUtenzeZoneRepo;
            this.viewGaBackOfficeInsolutoTariNoviRepo = viewGaBackOfficeInsolutoTariNoviRepo;
            this.viewGaBackOfficeUtenzeNoviRepo = viewGaBackOfficeUtenzeNoviRepo;
            this.viewGaBackOfficeUtenzeCliFatRepo = viewGaBackOfficeUtenzeCliFatRepo;
            this.viewGaBackOfficeUtenzeCliSedRepo = viewGaBackOfficeUtenzeCliSedRepo;

            this.viewGaBackOfficeZoneRepo = viewGaBackOfficeZoneRepo;

            this.spGaBackOfficeUtenzeRepo = spGaBackOfficeUtenzeRepo;
            this.spGaBackOfficeUtenzePartiteRepo = spGaBackOfficeUtenzePartiteRepo;
            this.spGaBackOfficeUtenzeDispositiviRepo = spGaBackOfficeUtenzeDispositiviRepo;

            this.unitOfWork = unitOfWork;

        }

        #region BackOfficeComuni

        #region Views
        public async Task<PagedList<ViewGaBackOfficeComuni>> GetViewGaBackOfficeComuniAsync()
        {
            var view = await viewGaBackOfficeComuniRepo.GetAllAsync(1, 0, "Descrizione");
            return view;
        }

        public async Task<BackOfficeComuniCustomDto> GetViewGaBackOfficeComuniCustomAsync()
        {
            string filter = "C";
            var view = await viewGaBackOfficeComuniRepo.GetWithFilterAsync(x => EF.Functions.Like(x.CodAzi, filter.toWildcardString()));
            var items = (from x in view.Data
                        select new BackOfficeComuneCustomDto() { Id = x.CodAzi.Trim(), Descrizione = x.Descrizione.Trim(), Disabled = false }).ToList();
            BackOfficeComuniCustomDto dtos = new BackOfficeComuniCustomDto();
            dtos.Data.AddRange(items);
            dtos.PageSize = items.Count();
            return dtos;
        }
        #endregion

        #endregion

        #region BackOfficeUtenze

        #region Functions
        public async Task<BackOfficeMaxContDto> CalcGaBackOfficeMassimali(List<ViewGaBackOfficeUtenzePartite> dtos)
        {

            var margini = await gaBackOfficeMarginiRepo.GetByIdAsync(1);
            var categorie = await gaBackOfficeParametroOnCategoriaRepo.GetAllAsync();
            var zone = await gaBackOfficeZoneRepo.GetAllAsync();

            var entity = new BackOfficeMaxContDto();
            entity.Secco = 0;
            entity.Carta = 0;
            entity.Plastica = 0;
            entity.Umido = 0;
            entity.Vetro = 0;
            entity.Vegetale = 0;

            foreach (var itm in dtos)
            {
                var valori = await SetValoriCategoriaOnUtenza(itm, zone, categorie, margini);
                entity.Secco += (Math.Round(valori.KgMqSmaltimentoRsu * Convert.ToDouble(itm.Superfic), 4, MidpointRounding.ToEven)) / margini.PesoSpecificoRsu;
                entity.Carta += (Math.Round(valori.KgMqRecuperoCarta * Convert.ToDouble(itm.Superfic), 4, MidpointRounding.ToEven)) / margini.PesoSpecificoCarta;
                entity.Plastica += (Math.Round(valori.KgMqRecuperoPlastica * Convert.ToDouble(itm.Superfic), 4, MidpointRounding.ToEven)) / margini.PesoSpecificoPlastica;
                entity.Umido += (Math.Round(valori.KgMqRecuperoUmido * Convert.ToDouble(itm.Superfic), 4, MidpointRounding.ToEven)) / margini.PesoSpecificoUmido;
                entity.Vetro += (Math.Round(valori.KgMqRecuperoVetro * Convert.ToDouble(itm.Superfic), 4, MidpointRounding.ToEven)) / margini.PesoSpecificoVetro;
            }

            return entity;
        }
        #endregion

        #region Views

        public async Task<PagedList<ViewGaBackOfficeUtenzeGrouped>> GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi, string ragCliCf)
        {
            var view = await viewGaBackOfficeUtenzeGroupedRepo.GetWithFilterAsync(x=>x.CodAzi==codAzi && (EF.Functions.Like(x.RagCli,ragCliCf.toWildcardString())||EF.Functions.Like(x.CodFis,ragCliCf.toWildcardString())),1,0,"RagCli");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzePartiteGrp>> GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync(string codAzi, string filter)
        {
            var view = await viewGaBackOfficeUtenzePartiteGrpRepo.GetWithFilterAsync(x => x.CpAzi == codAzi && 
            (EF.Functions.Like(x.RagSo, filter.toWildcardString()) || 
            EF.Functions.Like(x.CodFis, filter.toWildcardString()) ||
            EF.Functions.Like(x.CodCli, filter.toWildcardString()) ||
            EF.Functions.Like(x.NumCon, filter.toWildcardString())), 1, 0, "RagSo");
            return view;
        }

        public async Task<ViewGaBackOfficeUtenze> GetViewGaBackOfficeUtenzaByCpAziAndNumConAsync(string cpAzi, string numCon)
        {
            var view= await viewGaBackOfficeUtenzeRepo.GetSingleWithFilter(x=>x.CpAzi==cpAzi && x.NumCon==numCon);
            return view;
        }
        public async Task<PagedList<ViewGaBackOfficeUtenze>> GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(string cpAzi, string filter)
        {
            var view = await viewGaBackOfficeUtenzeRepo.GetWithFilterAsync(x => x.CpAzi.Trim() == cpAzi.Trim() 
            && ((EF.Functions.Like(x.RagSo, filter.toWildcardString()) || EF.Functions.Like(x.CodFis, filter.toWildcardString())) ||
            EF.Functions.Like(x.Piva, filter.toWildcardString()) || EF.Functions.Like(x.CodCli, filter.toWildcardString()) ||
            EF.Functions.Like(x.NumCon, filter.toWildcardString()))
            , 1, 0, "RagSo");
            return view;
        }


        public async Task<PagedList<ViewGaBackOfficeUtenzePartite>> GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync(string cpAzi, string numCon)
        {
            var view = await viewGaBackOfficeUtenzePartiteRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
            && x.NumCon==numCon
            , 1, 0, "Partita");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzePartiteVariazioni>> GetViewGaBackOfficeUtenzePartiteVariazioniByCpAziAndNumConAndPartitaAsync(string cpAzi, string numCon,string partita)
        {
            var view = await viewGaBackOfficeUtenzePartiteVariazioniRepo.GetWithFilterAsync(x => x.CodAzi == cpAzi
            && x.NumCon == numCon && x.Partita==partita
            , 1, 0, "DtIni","OrderByDescending");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzePartiteDetail>> GetViewGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync(string cpAzi, string via,int startNumCiv,int endNumCiv)
        {
            if (via.Length > 0 && startNumCiv != 0 && endNumCiv != 0)
            {
                var view = await viewGaBackOfficeUtenzePartiteDetailRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
                && (EF.Functions.Like(x.DesVia, via.toWildcardString()))
                && x.NumCivNum >= startNumCiv && x.NumCivNum <= endNumCiv
            , 1, 0, "NumCivNum");
                return view;
            }
            else if (via.Length > 0 && startNumCiv != 0)
            {
                var view = await viewGaBackOfficeUtenzePartiteDetailRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
               && (EF.Functions.Like(x.DesVia, via.toWildcardString()))
               && x.NumCivNum >= startNumCiv
           , 1, 0, "NumCivNum");
                return view;
            }
            else if (via.Length > 0 && endNumCiv != 0)
            {
                var view = await viewGaBackOfficeUtenzePartiteDetailRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
                && (EF.Functions.Like(x.DesVia, via.toWildcardString()))
                && x.NumCivNum <= endNumCiv
            , 1, 0, "NumCivNum");
                return view;
            }
            else if (via.Length > 0)
            {
                var view = await viewGaBackOfficeUtenzePartiteDetailRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
                    && (EF.Functions.Like(x.DesVia, via.toWildcardString()))
                , 1, 0, "NumCivNum");
                return view;
            }
            else
            {
                return null;
            }

            
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(string cpAzi, string numCon)
        {
            var view = await viewGaBackOfficeUtenzeDispositiviRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
            && x.NumCon == numCon
            , 1, 0, "Partita");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAndPartitaAsync(string cpAzi, string numCon, string partita)
        {
            var view = await viewGaBackOfficeUtenzeDispositiviRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
            && x.NumCon == numCon && x.Partita==partita
            , 1, 0, "Partita");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzeZone>> GetViewGaBackOfficeUtenzeZoneAsync()
        {
            try
            {
                return await viewGaBackOfficeUtenzeZoneRepo.GetAllAsync(1, 0);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #region Sp
        public async Task<PagedList<SpGaBackOfficeUtenze>> GetSpGaBackOfficeUtenzeAsync(string cpAzi, string filter)
        {
            var _cpAzi = new SqlParameter("@CPAZI", cpAzi);
            var _filter = new SqlParameter("@FILTER", filter);

            var entities = await spGaBackOfficeUtenzeRepo.ExecStoreProcedureWithParamsAsync(SpConsts.SpBackOfficeUtenze + " @CPAZI,@FILTER", parameters: new[] { _cpAzi, _filter });

            var response = new PagedList<SpGaBackOfficeUtenze>();
            response.Data.AddRange(entities.ToList());
            response.TotalCount = entities.Count();
            response.PageSize = 0;

            return response;
        }

        public async Task<PagedList<SpGaBackOfficeUtenzePartite>> GetSpGaBackOfficeUtenzePartiteAsync(string cpAzi, string filter)
        {
            var _cpAzi = new SqlParameter("@CPAZI", cpAzi);
            var _filter = new SqlParameter("@FILTER", filter);

            var entities = await spGaBackOfficeUtenzePartiteRepo.ExecStoreProcedureWithParamsAsync(SpConsts.SpBackOfficeUtenzePartite+" @CPAZI,@FILTER",parameters: new[] { _cpAzi,_filter});

            var response = new PagedList<SpGaBackOfficeUtenzePartite>();
            response.Data.AddRange(entities.ToList());
            response.TotalCount = entities.Count();
            response.PageSize = 0;

            return response;
        }

        public async Task<PagedList<SpGaBackOfficeUtenzeDispositivi>> GetSpGaBackOfficeUtenzeDispositiviAsync(string cpAzi, string filter)
        {
            var _cpAzi = new SqlParameter("@CPAZI", cpAzi);
            var _filter = new SqlParameter("@FILTER", filter);

            var entities = await spGaBackOfficeUtenzeDispositiviRepo.ExecStoreProcedureWithParamsAsync(SpConsts.SpBackOfficeUtenzeDispositivi + " @CPAZI,@FILTER", parameters: new[] { _cpAzi, _filter });

            var response = new PagedList<SpGaBackOfficeUtenzeDispositivi>();
            response.Data.AddRange(entities.ToList());
            response.TotalCount = entities.Count();
            response.PageSize = 0;

            return response;
        }

        #endregion

        #endregion

        #region BackOfficeNdUtenze

        #region Views
        public async Task<PagedList<ViewGaBackOfficeNdUtenze>> GetViewGaBackOfficeNdUtenzeByCodAziAsync(string codAzi)
        {
            var view = await viewGaBackOfficeNdUtenzeRepo.GetWithFilterAsync(x => x.CodAzi == codAzi, 1, 0, "RagCli");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeNdUtenze>> GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync(string codAzi,string ragCliCf)
        {
            var view = await viewGaBackOfficeNdUtenzeRepo.GetWithFilterAsync(x => x.CodAzi == codAzi && (x.RagCli.Contains(ragCliCf) || x.RagCli.Contains(ragCliCf)), 1, 0, "RagCli");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeNdUtenzeGrouped>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync(string codAzi)
        {
            var view = await viewGaBackOfficeNdUtenzeGroupedRepo.GetWithFilterAsync(x => x.CodAzi == codAzi, 1, 0, "RagCli");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeNdUtenzeGrouped>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi, string ragCliCf)
        {
            var view = await viewGaBackOfficeNdUtenzeGroupedRepo.GetWithFilterAsync(x => x.CodAzi == codAzi && (x.RagCli.Contains(ragCliCf) || x.RagCli.Contains(ragCliCf)), 1, 0, "RagCli");
            return view;
        }

        #endregion

        #endregion

        #region BackOfficeContenitori

        #region Views
        public async Task<PagedList<ViewGaBackOfficeContenitoriLetture>> GetViewGaBackOfficeContenitoriLettureByIdentiAsync(string identi)
        {
            if (identi.Length == 12)
            {
                var view = await viewGaBackOfficeContenitoriLettureRepo.GetWithFilterAsync(x => x.Identi2 == (identi),1,0,"DtReg","OrderByDescending");
                return view;
            }
            else
            {
                var view = await viewGaBackOfficeContenitoriLettureRepo.GetWithFilterAsync(x => x.Identi1 == (identi), 1, 0, "DtReg", "OrderByDescending");
                return view;
            }
        }

        public async Task<PagedList<ViewGaBackOfficeContenitoriLetture>> GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(string codComune,string numCon)
        {
            var view = await viewGaBackOfficeContenitoriLettureRepo.GetWithFilterAsync(x => x.CodComune.Trim()==codComune && x.NumCon.Trim()==numCon,1,0,"DtReg", "OrderByDescending");
            return view;
        }
        #endregion

        #endregion

        #region BackOfficeZone
        public async Task<List<string>> GetGaBackOfficeZoneComuniAsync()
        {
            var result = await viewGaBackOfficeZoneRepo.GetAllAsync();
            return (from x in result.Data
                    select x.Comune).Distinct().ToList();
        }

        public async Task<List<string>> GetGaBackOfficeZoneVieByComuneAsync(string comune)
        {
            var result = await viewGaBackOfficeZoneRepo.GetWithFilterAsync(x => x.Comune == comune);
            return (from x in result.Data
                    select x.Via).Distinct().ToList();
        }
        public async Task<List<string>> GetGaBackOfficeZoneCiviciByComuneAndViaAsync(string comune, string via)
        {
            var result = await viewGaBackOfficeZoneRepo.GetWithFilterAsync(x => x.Comune == comune && x.Via == via);
            return (from x in result.Data
                    select x.Civico).Distinct().ToList();
        }
        public async Task<string> GetGaBackOfficeZoneZonaAsync(string comune, string via, string civico)
        {
            var result = await viewGaBackOfficeZoneRepo.GetWithFilterAsync(x => x.Comune == comune && x.Via == via && x.Civico == civico);
            return (from x in result.Data
                    select x.Zona).FirstOrDefault();
        }
        #endregion

        #region BackOfficeNovi
        public async Task<PagedList<ViewGaBackOfficeUtenzeNovi>> GetViewGaBackOfficeUtenzeNoviAsync(string filter)
        {
            var view = await viewGaBackOfficeUtenzeNoviRepo.GetWithFilterAsync(x =>
            EF.Functions.Like(x.CodCli, filter.toWildcardString())
            || EF.Functions.Like(x.RagSo, filter.toWildcardString())
            || EF.Functions.Like(x.NumCon, filter.toWildcardString())
            || EF.Functions.Like(x.CodFis,filter.toWildcardString()));

            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzeNovi>> GetViewGaBackOfficeUtenzeNoviByAddressAsync(string via, int startNumCiv,int endNumCiv)
        {
            var result = await viewGaBackOfficeUtenzeNoviRepo.GetWithFilterAsync(x => (EF.Functions.Like(x.Via, via.toWildcardString())));

            PagedList<ViewGaBackOfficeUtenzeNovi> view = new PagedList<ViewGaBackOfficeUtenzeNovi>();

            if (via.Length > 0 && startNumCiv != 0 && endNumCiv != 0)
            {

                foreach (var item in result.Data)
                {
                    if (NumberHelper.ConvertStringToNumber(item.NumCiv) >= startNumCiv && NumberHelper.ConvertStringToNumber(item.NumCiv) <= endNumCiv) 
                    { view.Data.Add(item); }
                    
                }
                view.TotalCount = view.Data.Count();
                return view;
            }
            else if (via.Length > 0 && startNumCiv != 0)
            {
                foreach (var item in result.Data)
                {
                    if (NumberHelper.ConvertStringToNumber(item.NumCiv) >= startNumCiv)
                    { view.Data.Add(item); }

                }
                view.TotalCount = view.Data.Count();
                return view;
            }
            else if (via.Length > 0 && endNumCiv != 0)
            {
                foreach (var item in result.Data)
                {
                    if (NumberHelper.ConvertStringToNumber(item.NumCiv) <= endNumCiv)
                    { view.Data.Add(item); }

                }
                view.TotalCount = view.Data.Count();
                return view;
            }
            else if (via.Length > 0)
            {
                foreach (var item in result.Data)
                {
                     view.Data.Add(item); 

                }
                view.TotalCount = view.Data.Count();
                return view;
            }
            else
            {
                return null;
            }
        }

       
        #endregion

        #region BackOfficeDocRecipes
        public async Task<BackOfficeDocRecipesDto> GetGaBackOfficeDocRecipesAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaBackOfficeDocRecipesRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<BackOfficeDocRecipesDto, PagedList<BackOfficeDocReceipt>>();
            return dtos;
        }


        public async Task<BackOfficeDocReceiptDto> GetGaBackOfficeDocRecipesByIdAsync(long id)
        {
            var entity = await gaBackOfficeDocRecipesRepo.GetByIdAsync(id);
            var dto = entity.ToDto<BackOfficeDocReceiptDto, BackOfficeDocReceipt>();
            return dto;
        }

        public async Task<BackOfficeDocRecipesDto> GetGaBackOfficeDocRecipesByCodCliAndNumConAsync(string codCli,string numCon)
        {
            var entities = await gaBackOfficeDocRecipesRepo.GetWithFilterAsync(x=>x.CodCli==codCli && x.NumCon==numCon);
            var dtos = entities.ToDto<BackOfficeDocRecipesDto, PagedList<BackOfficeDocReceipt>>();
            return dtos;
        }


        public async Task<long> AddGaBackOfficeDocReceiptAsync(BackOfficeDocReceiptDto dto)
        {
            var entity = dto.ToEntity<BackOfficeDocReceipt, BackOfficeDocReceiptDto>();
            await gaBackOfficeDocRecipesRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaBeckOfficeDocReceiptAsync(BackOfficeDocReceiptDto dto)
        {
            var entity = dto.ToEntity<BackOfficeDocReceipt, BackOfficeDocReceiptDto>();
            gaBackOfficeDocRecipesRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaBackOfficeDocReceiptAsync(long id)
        {
            var entity = await gaBackOfficeDocRecipesRepo.GetByIdAsync(id);
            gaBackOfficeDocRecipesRepo.Remove(entity);
            await SaveChanges();

            return true;
        }
        #endregion

        #region BackOfficeInsolutoTariNovi
        public async Task<PagedList<ViewGaBackOfficeInsolutoTariNovi>> GetViewGaBackOfficeInsolutoTariNoviByFilterAsync(string codCli,string numCon)
        {
            var view = await viewGaBackOfficeInsolutoTariNoviRepo.GetWithFilterAsync(
                x => x.CodCli==codCli &&
                x.NumCont==numCon,1,0,"AnnoRif");

            return view;
        }
        #endregion

        #region BackOfficeCli
        public async Task<PagedList<ViewGaBackOfficeUtenzeCliFat>> GetViewGaBackOfficeUtenzaCliFatByFilterAsync(string codCli)
        {
            var view = await viewGaBackOfficeUtenzeCliFatRepo.GetWithFilterAsync(
                x => x.CodCli.Trim() == codCli,1,0);

            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenzeCliSed>> GetViewGaBackOfficeUtenzaCliSedByFilterAsync(string codCli)
        {
            var view = await viewGaBackOfficeUtenzeCliSedRepo.GetWithFilterAsync(
                x => x.CodCli.Trim() == codCli, 1, 0);

            return view;
        }
        #endregion

        #region Shared Functions
        private async Task<BackOfficeCategoriaOnUtenzaDto> SetValoriCategoriaOnUtenza(ViewGaBackOfficeUtenzePartite utenza, PagedList<BackOfficeZona> zone, PagedList<BackOfficeParametroOnCategoria> categorie, BackOfficeMargine margine)
        {
            
            BackOfficeCategoriaOnUtenzaDto dto = new BackOfficeCategoriaOnUtenzaDto();
            dto.CodCategoria = utenza.Categ;
            dto.DescCategoria = utenza.DescriCat;

            var zona = zone.Data.Where(x => x.Descrizione.Contains(utenza.Comune.Trim()) && x.Descrizione.Contains(utenza.CodZona.Trim())).FirstOrDefault();
            if (zona == null)
            {
                zona = zone.Data.Where(x => x.Descrizione == "ZONA STANDARD").FirstOrDefault();
            }

            var categoria = categorie.Data.Where(x => x.TipoId == utenza.Categ).FirstOrDefault();

            try
            {
                dto.KgMqSmaltimentoRsu = (categoria.KgMqSmaltimentoGg * zona.CadenzaRsu) * margine.MargineRsu;
                dto.KgMqRecuperoCarta = ((categoria.KgMqRecuperoGg * margine.MargineCarta) * zona.CadenzaCarta) * categoria.PercentualeCarta;
                dto.KgMqRecuperoPlastica = ((categoria.KgMqRecuperoGg * margine.MarginePlastica) * zona.CadenzaPlastica) * categoria.PercentualePlastica;
                dto.KgMqRecuperoUmido = ((categoria.KgMqRecuperoGg * margine.MargineUmido) * zona.CadenzaUmido) * categoria.PercentualeUmido;
                dto.KgMqRecuperoVetro = ((categoria.KgMqRecuperoGg * margine.MargineVetro) * zona.CadenzaVetro) * categoria.PercentualeVetro;


                return dto;
            }
            catch (Exception ex)
            {
                return dto;
            }

        }
        #endregion

        #region Common
        private async Task<long> SaveChanges()
        {
            return await unitOfWork.SaveChangesAsync();
        }

        private void DetachEntity<T>(T entity)
        {
            unitOfWork.DetachEntity(entity);
        }
        #endregion

    }
}
