using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.SmartCity;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.SmartCity.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.BusinnessLogic.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaSmartCityService : IGaSmartCityService
    {
        protected readonly IGenericRepository<SmartCityPermission> gaSmartCityPermissionsRepo;

        protected readonly IGenericRepository<ViewGaSmartCityPermissions> viewGaSmartCityPermissionsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaSmartCityService(
            IGenericRepository<SmartCityPermission> gaSmartCityPermissionsRepo,

            IGenericRepository<ViewGaSmartCityPermissions> viewGaSmartCityPermissionsRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaSmartCityPermissionsRepo = gaSmartCityPermissionsRepo;

            this.viewGaSmartCityPermissionsRepo = viewGaSmartCityPermissionsRepo;

            this.unitOfWork = unitOfWork;
        }

        #region SmartCityPermissions

        #region Functions

        public async Task<bool> ChangeGaSmartCityPermissionsAsync(string userId,string permissions)
        {
            var entity = await gaSmartCityPermissionsRepo.GetSingleWithFilter(x=>x.UserId==userId);
            if (entity!=null)
            {
                entity.Permissions = permissions;
                gaSmartCityPermissionsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                var item = new SmartCityPermission();
                item.Id = 0;
                item.Disabled = false;
                item.UserId=userId; item.Permissions = permissions;

                gaSmartCityPermissionsRepo.Add(item);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaSmartCityPermissions>> GetViewGaSmartCityPermissionsAsync()
        {
            try
            {
                return await viewGaSmartCityPermissionsRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedList<ViewGaSmartCityPermissions>> GetViewGaSmartCityPermissionsByUserIdAsync(string userId)
        {
            try
            {
                return await viewGaSmartCityPermissionsRepo.GetWithFilterAsync(x=>x.UserId==userId);
            }
            catch (Exception ex)
            {
                throw;
            }
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
