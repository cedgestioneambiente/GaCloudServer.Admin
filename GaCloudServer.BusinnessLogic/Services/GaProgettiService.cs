using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaProgettiService : IGaProgettiService
    {
        protected readonly IGenericRepository<ProgettiWork> gaProgettiWorksRepo;
        protected readonly IGenericRepository<ProgettiJob> gaProgettiJobsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaProgettiService(
            IGenericRepository<ProgettiWork> gaProgettiWorksRepo,
            IGenericRepository<ProgettiJob> gaProgettiJobsRepo,

        IUnitOfWork unitOfWork)
        {
            this.gaProgettiWorksRepo = gaProgettiWorksRepo;
            this.gaProgettiJobsRepo = gaProgettiJobsRepo;
            this.unitOfWork = unitOfWork;

        }

        #region ProgettiWorks
        public async Task<ProgettiWorksDto> GetGaProgettiWorksAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaProgettiWorksRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ProgettiWorksDto, PagedList<ProgettiWork>>();
            return dtos;
        }

        public async Task<ProgettiWorkDto> GetGaProgettiWorkByIdAsync(long id)
        {
            var entity = await gaProgettiWorksRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiWorkDto, ProgettiWork>();
            return dto;
        }

        public async Task<long> AddGaProgettiWorkAsync(ProgettiWorkDto dto)
        {
            var entity = dto.ToEntity<ProgettiWork, ProgettiWorkDto>();
            await gaProgettiWorksRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiWorkAsync(ProgettiWorkDto dto)
        {
            var entity = dto.ToEntity<ProgettiWork, ProgettiWorkDto>();
            gaProgettiWorksRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiWorkAsync(long id)
        {
            var entity = await gaProgettiWorksRepo.GetByIdAsync(id);
            gaProgettiWorksRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaProgettiWorkAsync(long id, string descrizione)
        {
            var entity = await gaProgettiWorksRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaProgettiWorkAsync(long id)
        {
            var entity = await gaProgettiWorksRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaProgettiWorksRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaProgettiWorksRepo.Update(entity);
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


