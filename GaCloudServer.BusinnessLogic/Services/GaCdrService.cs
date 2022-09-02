using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;


namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaCdrService : IGaCdrService
    {
        protected readonly IGenericRepository<CdrCentro> gaCdrCentriRepo;
        protected readonly IGenericRepository<CdrComune> gaCdrComuniRepo;


        protected readonly IUnitOfWork unitOfWork;

        public GaCdrService(
            IGenericRepository<CdrCentro> gaCdrCentriRepo,
            IGenericRepository<CdrComune> gaCdrComuniRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaCdrCentriRepo = gaCdrCentriRepo;
            this.gaCdrComuniRepo = gaCdrComuniRepo;


            this.unitOfWork = unitOfWork;
        }

        #region CdrCentri
        public async Task<CdrCentriDto> GetGaCdrCentriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrCentriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCentriDto, PagedList<CdrCentro>>();
            return dtos;
        }

        public async Task<CdrCentroDto> GetGaCdrCentroByIdAsync(long id)
        {
            var entity = await gaCdrCentriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrCentroDto, CdrCentro>();
            return dto;
        }

        public async Task<long> AddGaCdrCentroAsync(CdrCentroDto dto)
        {
            var entity = dto.ToEntity<CdrCentro, CdrCentroDto>();
            await gaCdrCentriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrCentroAsync(CdrCentroDto dto)
        {
            var entity = dto.ToEntity<CdrCentro, CdrCentroDto>();
            gaCdrCentriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrCentroAsync(long id)
        {
            var entity = await gaCdrCentriRepo.GetByIdAsync(id);
            gaCdrCentriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrCentroAsync(long id, string centro)
        {
            var entity = await gaCdrCentriRepo.GetWithFilterAsync(x => x.Centro == centro && x.Id != id);

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
            var entity = await gaCdrCentriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrCentriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrCentriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion


        #region CdrComuni
        public async Task<CdrComuniDto> GetGaCdrComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrComuniDto, PagedList<CdrComune>>();
            return dtos;
        }

        public async Task<CdrComuneDto> GetGaCdrComuneByIdAsync(long id)
        {
            var entity = await gaCdrComuniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrComuneDto, CdrComune>();
            return dto;
        }

        public async Task<long> AddGaCdrComuneAsync(CdrComuneDto dto)
        {
            var entity = dto.ToEntity<CdrComune, CdrComuneDto>();
            await gaCdrComuniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrComuneAsync(CdrComuneDto dto)
        {
            var entity = dto.ToEntity<CdrComune, CdrComuneDto>();
            gaCdrComuniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrComuneAsync(long id)
        {
            var entity = await gaCdrComuniRepo.GetByIdAsync(id);
            gaCdrComuniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrComuneAsync(long id, string centro)
        {
            var entity = await gaCdrComuniRepo.GetWithFilterAsync(x => x.Comune == centro && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrComuneAsync(long id)
        {
            var entity = await gaCdrComuniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrComuniRepo.Update(entity);
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
