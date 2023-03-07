using GaCloudServer.Admin.EntityFramework.Shared.Constants;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System.Security.Cryptography.X509Certificates;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPrevisioService:IGaPrevisioService
    {
        protected readonly IGenericRepository<ViewGaPrevisioOdsReport> viewPrevisioOdsReportRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaPrevisioService(
            IGenericRepository<ViewGaPrevisioOdsReport> viewPrevisioOdsReportRepo,

            IUnitOfWork unitOfWork)
        {
            this.viewPrevisioOdsReportRepo = viewPrevisioOdsReportRepo;

            this.unitOfWork = unitOfWork;

        }

        #region BackOfficeUtenze

        #region Views
        public async Task<PagedList<ViewGaPrevisioOdsReport>> GetViewGaPrevisioOdsReportByDateAsync(DateTime dateStart,DateTime dateEnd)
        {
            var view = await viewPrevisioOdsReportRepo
            .GetWithFilterAsync(x=>x.DataOraIniMezzo>=dateStart && x.DataOraFineMezzo<=dateEnd,1,0,"IDServizio");
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
