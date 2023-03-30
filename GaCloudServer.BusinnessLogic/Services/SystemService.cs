using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.System;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.System;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class SystemService : ISystemService
    {
        protected readonly IGenericRepository<SystemVersion> systemVersionsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public SystemService(

            IGenericRepository<SystemVersion> systemVersionsRepo,

            IUnitOfWork unitOfWork)
        {
            this.systemVersionsRepo = systemVersionsRepo;


            this.unitOfWork = unitOfWork;

        }

        #region SystemVersions
        public async Task<SystemVersionsDto> GetSystemVersionsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await systemVersionsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<SystemVersionsDto, PagedList<SystemVersion>>();
            return dtos;
        }

        public async Task<SystemVersionDto> GetSystemVersionByIdAsync(long id)
        {
            var entity = await systemVersionsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<SystemVersionDto, SystemVersion>();
            return dto;
        }

        public async Task<long> AddSystemVersionAsync(SystemVersionDto dto)
        {
            var entity = dto.ToEntity<SystemVersion, SystemVersionDto>();
            await systemVersionsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateSystemVersionAsync(SystemVersionDto dto)
        {
            var entity = dto.ToEntity<SystemVersion, SystemVersionDto>();
            systemVersionsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteSystemVersionAsync(long id)
        {
            var entity = await systemVersionsRepo.GetByIdAsync(id);
            systemVersionsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateSystemVersionAsync(long id, string descrizione)
        {
            var entity = await systemVersionsRepo.GetWithFilterAsync(x => x.Versione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusSystemVersionAsync(long id)
        {
            var entity = await systemVersionsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                systemVersionsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                systemVersionsRepo.Update(entity);
                await SaveChanges();
                return true;
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

