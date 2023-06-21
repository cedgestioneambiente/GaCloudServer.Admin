using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Emz.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using mBase = System.Reflection.MethodBase;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class EmzService : IEmzService

    {

        protected readonly IGenericRepository<ViewEmzWhiteList> viewEmzWhiteListRepo;


        protected readonly IUnitOfWork unitOfWork;

        public EmzService(

            IGenericRepository<ViewEmzWhiteList> viewEmzWhiteListRepo,

            IUnitOfWork unitOfWork)
        {

            this.viewEmzWhiteListRepo = viewEmzWhiteListRepo;

            this.unitOfWork = unitOfWork;

        }

        #region Views
        public async Task<PagedList<ViewEmzWhiteList>> GetViewEmzWhiteListAsync()
        {

                var entities = await viewEmzWhiteListRepo.GetAllAsync(1, 0, "Chiave1");

                return entities;

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
