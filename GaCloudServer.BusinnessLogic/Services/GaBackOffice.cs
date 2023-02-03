using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

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

        protected readonly IUnitOfWork unitOfWork;

        public GaBackOfficeService(
            IGenericRepository<BackOfficeTicket> gaBackOfficeTicketsRepo,

            IGenericRepository<ViewGaBackOfficeComuni> viewGaBackOfficeComuniRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeGrouped> viewGaBackOfficeUtenzeGroupedRepo,
            IGenericRepository<ViewGaBackOfficeNdUtenze> viewGaBackOfficeNdUtenzeRepo,
            IGenericRepository<ViewGaBackOfficeNdUtenzeGrouped> viewGaBackOfficeNdUtenzeGroupedRepo,
            IGenericRepository<ViewGaBackOfficeContenitoriLetture> viewGaBackOfficeContenitoriLettureRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaBackOfficeTicketsRepo = gaBackOfficeTicketsRepo;
            this.viewGaBackOfficeUtenzeGroupedRepo = viewGaBackOfficeUtenzeGroupedRepo;
            this.viewGaBackOfficeNdUtenzeRepo = viewGaBackOfficeNdUtenzeRepo;
            this.viewGaBackOfficeNdUtenzeGroupedRepo = viewGaBackOfficeNdUtenzeGroupedRepo;

            this.viewGaBackOfficeComuniRepo = viewGaBackOfficeComuniRepo;

            this.viewGaBackOfficeContenitoriLettureRepo = viewGaBackOfficeContenitoriLettureRepo;

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
