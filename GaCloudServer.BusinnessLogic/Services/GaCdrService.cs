using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Cdr;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;


namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaCdrService : IGaCdrService
    {
        protected readonly IGenericRepository<CdrCentro> cdrCentriRepo;


        protected readonly IUnitOfWork unitOfWork;

        public GaCdrService(
            IGenericRepository<CdrCentro> cdrCentriRepo,

            IUnitOfWork unitOfWork)
        {
            this.cdrCentriRepo = cdrCentriRepo;


            this.unitOfWork = unitOfWork;
        }

        #region CdrCentri
        public async Task<CdrCentriDto> GetGaCdrCentriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await cdrCentriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCentriDto, PagedList<CdrCentro>>();
            return dtos;
        }

        public async Task<CdrCentroDto> GetGaCdrCentroByIdAsync(long id)
        {
            var entity = await cdrCentriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrCentroDto, CdrCentro>();
            return dto;
        }

        public async Task<long> AddGaCdrCentroAsync(CdrCentroDto dto)
        {
            var entity = dto.ToEntity<CdrCentro, CdrCentroDto>();
            await cdrCentriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrCentroAsync(CdrCentroDto dto)
        {
            var entity = dto.ToEntity<CdrCentro, CdrCentroDto>();
            cdrCentriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrCentroAsync(long id)
        {
            var entity = await cdrCentriRepo.GetByIdAsync(id);
            cdrCentriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrCentroAsync(long id, string centro)
        {
            var entity = await cdrCentriRepo.GetWithFilterAsync(x => x.Centro == centro && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrCentroAsync(long id)
        {
            var entity = await cdrCentriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                cdrCentriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                cdrCentriRepo.Update(entity);
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
