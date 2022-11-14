using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Global;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GlobalService: IGlobalService
    {
        protected readonly IGenericRepository<GlobalSede> globalSediRepo;
        protected readonly IGenericRepository<GlobalCentroCosto> globalCentriCostiRepo;
        protected readonly IGenericRepository<GlobalSettore> globalSettoriRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GlobalService(

            IGenericRepository<GlobalSede> globalSediRepo,
            IGenericRepository<GlobalCentroCosto> globalCentriCostiRepo,
            IGenericRepository<GlobalSettore> globalSettoriRepo,

            IUnitOfWork unitOfWork)
        {
            this.globalSediRepo = globalSediRepo;
            this.globalCentriCostiRepo = globalCentriCostiRepo;
            this.globalSettoriRepo = globalSettoriRepo;

            this.unitOfWork = unitOfWork;

        }

        #region GlobalSedi
        public async Task<GlobalSediDto> GetGlobalSediAsync(int page = 1, int pageSize = 0)
        {
            var entities = await globalSediRepo.GetAllAsync(page,pageSize);
            var dtos= entities.ToDto<GlobalSediDto, PagedList<GlobalSede>>();
            return dtos;
        }

        public async Task<GlobalSedeDto> GetGlobalSedeByIdAsync(long id)
        {
            var entity = await globalSediRepo.GetByIdAsync(id);
            var dto = entity.ToDto<GlobalSedeDto, GlobalSede>();
            return dto;
        }

        public async Task<long> AddGlobalSedeAsync(GlobalSedeDto dto)
        {
            var entity = dto.ToEntity<GlobalSede, GlobalSedeDto>();
            await globalSediRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGlobalSedeAsync(GlobalSedeDto dto)
        {
            var entity = dto.ToEntity<GlobalSede, GlobalSedeDto>();
            globalSediRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGlobalSedeAsync(long id)
        {
            var entity = await globalSediRepo.GetByIdAsync(id);
            globalSediRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGlobalSedeAsync(long id, string descrizione)
        {
            var entity = await globalSediRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGlobalSedeAsync(long id)
        {
            var entity = await globalSediRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                globalSediRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                globalSediRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            
        }
        #endregion

        #endregion

        #region GlobalCentriCosti
        public async Task<GlobalCentriCostiDto> GetGlobalCentriCostiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await globalCentriCostiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<GlobalCentriCostiDto, PagedList<GlobalCentroCosto>>();
            return dtos;
        }

        public async Task<GlobalCentroCostoDto> GetGlobalCentroCostoByIdAsync(long id)
        {
            var entity = await globalCentriCostiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<GlobalCentroCostoDto, GlobalCentroCosto>();
            return dto;
        }

        public async Task<long> AddGlobalCentroCostoAsync(GlobalCentroCostoDto dto)
        {
            var entity = dto.ToEntity<GlobalCentroCosto, GlobalCentroCostoDto>();
            await globalCentriCostiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGlobalCentroCostoAsync(GlobalCentroCostoDto dto)
        {
            var entity = dto.ToEntity<GlobalCentroCosto, GlobalCentroCostoDto>();
            globalCentriCostiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGlobalCentroCostoAsync(long id)
        {
            var entity = await globalCentriCostiRepo.GetByIdAsync(id);
            globalCentriCostiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGlobalCentroCostoAsync(long id, string descrizione)
        {
            var entity = await globalCentriCostiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGlobalCentroCostoAsync(long id)
        {
            var entity = await globalCentriCostiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                globalCentriCostiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                globalCentriCostiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region GlobalSettori
        public async Task<GlobalSettoriDto> GetGlobalSettoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await globalSettoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<GlobalSettoriDto, PagedList<GlobalSettore>>();
            return dtos;
        }

        public async Task<GlobalSettoreDto> GetGlobalSettoreByIdAsync(long id)
        {
            var entity = await globalSettoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<GlobalSettoreDto, GlobalSettore>();
            return dto;
        }

        public async Task<long> AddGlobalSettoreAsync(GlobalSettoreDto dto)
        {
            var entity = dto.ToEntity<GlobalSettore, GlobalSettoreDto>();
            await globalSettoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGlobalSettoreAsync(GlobalSettoreDto dto)
        {
            var entity = dto.ToEntity<GlobalSettore, GlobalSettoreDto>();
            globalSettoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGlobalSettoreAsync(long id)
        {
            var entity = await globalSettoriRepo.GetByIdAsync(id);
            globalSettoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGlobalSettoreAsync(long id, string descrizione)
        {
            var entity = await globalSettoriRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGlobalSettoreAsync(long id)
        {
            var entity = await globalSettoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                globalSettoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                globalSettoriRepo.Update(entity);
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
