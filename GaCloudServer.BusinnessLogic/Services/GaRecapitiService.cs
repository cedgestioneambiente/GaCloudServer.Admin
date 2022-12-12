
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Recapiti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaRecapitiService:IGaRecapitiService
    {
        protected readonly IGenericRepository<ViewGaRecapitiContatti> viewGaRecapitiContattiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaRecapitiService(

            IGenericRepository<ViewGaRecapitiContatti> viewGaRecapitiContattiRepo,

            IUnitOfWork unitOfWork)
        {


            this.viewGaRecapitiContattiRepo = viewGaRecapitiContattiRepo;


            this.unitOfWork = unitOfWork;

        }

        #region RecapitiContatti

        #region Views
        public async Task<PagedList<ViewGaRecapitiContatti>> GetViewGaRecapitiContattiAsync()
        {
            var entities =  await viewGaRecapitiContattiRepo.GetAllAsync(1, 0);
            return entities;
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
