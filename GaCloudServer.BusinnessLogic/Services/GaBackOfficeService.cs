using GaCloudServer.Admin.EntityFramework.Shared.Constants;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System.Security.Cryptography.X509Certificates;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaBackOfficeService:IGaBackOfficeService
    {
        protected readonly IGenericRepository<BackOfficeTicket> gaBackOfficeTicketsRepo;

        protected readonly IGenericRepository<ViewGaBackOfficeComuni> viewGaBackOfficeComuniRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeGrouped> viewGaBackOfficeUtenzeGroupedRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeNdUtenze> viewGaBackOfficeNdUtenzeRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped> viewGaBackOfficeNdUtenzeGroupedRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeContenitoriLetture> viewGaBackOfficeContenitoriLettureRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenze> viewGaBackOfficeUtenzeRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzePartite> viewGaBackOfficeUtenzePartiteRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo;

        protected readonly IGenericRepository<ViewGaBackOfficeZone> viewGaBackOfficeZoneRepo;

        protected readonly IProcedureManager<SpGaBackOfficeUtenze> spGaBackOfficeUtenzeRepo;
        protected readonly IProcedureManager<SpGaBackOfficeUtenzePartite> spGaBackOfficeUtenzePartiteRepo;
        protected readonly IProcedureManager<SpGaBackOfficeUtenzeDispositivi> spGaBackOfficeUtenzeDispositiviRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaBackOfficeService(
            IGenericRepository<BackOfficeTicket> gaBackOfficeTicketsRepo,

            IGenericRepository<ViewGaBackOfficeComuni> viewGaBackOfficeComuniRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeGrouped> viewGaBackOfficeUtenzeGroupedRepo,
            IGenericRepository<ViewGaBackOfficeNdUtenze> viewGaBackOfficeNdUtenzeRepo,
            IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped> viewGaBackOfficeNdUtenzeGroupedRepo,
            IGenericRepository<ViewGaBackOfficeContenitoriLetture> viewGaBackOfficeContenitoriLettureRepo,
            IGenericRepository<ViewGaBackOfficeUtenze> viewGaBackOfficeUtenzeRepo,
            IGenericRepository<ViewGaBackOfficeUtenzePartite> viewGaBackOfficeUtenzePartiteRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo,

            IGenericRepository<ViewGaBackOfficeZone> viewGaBackOfficeZoneRepo,

            IProcedureManager<SpGaBackOfficeUtenze> spGaBackOfficeUtenzeRepo,
            IProcedureManager<SpGaBackOfficeUtenzePartite> spGaBackOfficeUtenzePartiteRepo,
            IProcedureManager<SpGaBackOfficeUtenzeDispositivi> spGaBackOfficeUtenzeDispositiviRepo,

        IUnitOfWork unitOfWork)
        {
            this.gaBackOfficeTicketsRepo = gaBackOfficeTicketsRepo;
            this.viewGaBackOfficeUtenzeGroupedRepo = viewGaBackOfficeUtenzeGroupedRepo;
            this.viewGaBackOfficeNdUtenzeRepo = viewGaBackOfficeNdUtenzeRepo;
            this.viewGaBackOfficeNdUtenzeGroupedRepo = viewGaBackOfficeNdUtenzeGroupedRepo;

            this.viewGaBackOfficeComuniRepo = viewGaBackOfficeComuniRepo;

            this.viewGaBackOfficeContenitoriLettureRepo = viewGaBackOfficeContenitoriLettureRepo;

            this.viewGaBackOfficeUtenzeRepo = viewGaBackOfficeUtenzeRepo;
            this.viewGaBackOfficeUtenzePartiteRepo = viewGaBackOfficeUtenzePartiteRepo;
            this.viewGaBackOfficeUtenzeDispositiviRepo = viewGaBackOfficeUtenzeDispositiviRepo;

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
        #endregion

        #endregion

        #region BackOfficeUtenze

        #region Views
        public async Task<PagedList<ViewGaBackOfficeUtenzeGrouped>> GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi, string ragCliCf)
        {
            var view = await viewGaBackOfficeUtenzeGroupedRepo.GetWithFilterAsync(x=>x.CodAzi==codAzi && (EF.Functions.Like(x.RagCli,ragCliCf.toWildcardString())||EF.Functions.Like(x.CodFis,ragCliCf.toWildcardString())),1,0,"RagCli");
            return view;
        }

        public async Task<PagedList<ViewGaBackOfficeUtenze>> GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(string cpAzi, string filter)
        {
            var view = await viewGaBackOfficeUtenzeRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi 
            && (EF.Functions.Like(x.RagSo, filter.toWildcardString()) || EF.Functions.Like(x.CodFis, filter.toWildcardString())) ||
            EF.Functions.Like(x.Piva, filter.toWildcardString()) || EF.Functions.Like(x.CodCli, filter.toWildcardString()) ||
            EF.Functions.Like(x.NumCon, filter.toWildcardString())
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

        public async Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(string cpAzi, string numCon)
        {
            var view = await viewGaBackOfficeUtenzeDispositiviRepo.GetWithFilterAsync(x => x.CpAzi == cpAzi
            && x.NumCon == numCon
            , 1, 0, "Partita");
            return view;
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
