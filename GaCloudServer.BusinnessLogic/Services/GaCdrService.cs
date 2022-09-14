using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
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
        protected readonly IGenericRepository<CdrCer> gaCdrCersRepo;
        protected readonly IGenericRepository<CdrCerDettaglio> gaCdrCersDettagliRepo;
        protected readonly IGenericRepository<CdrCerOnCentro> gaCdrCersOnCentriRepo;
        protected readonly IGenericRepository<CdrComuneOnCentro> gaCdrComuniOnCentriRepo;

        protected readonly IGenericRepository<ViewGaCdrCersOnCentri> viewGaCdrCersOnCentriRepo;
        protected readonly IGenericRepository<ViewGaCdrComuniOnCentri> viewGaCdrComuniOnCentriRepo;
        protected readonly IGenericRepository<ViewGaCdrComuni> viewGaCdrComuniRepo;


        protected readonly IUnitOfWork unitOfWork;

        public GaCdrService(
            IGenericRepository<CdrCentro> gaCdrCentriRepo,
            IGenericRepository<CdrComune> gaCdrComuniRepo,
            IGenericRepository<CdrCer> gaCdrCersRepo,
            IGenericRepository<CdrCerDettaglio> gaCdrCersDettagliRepo,
            IGenericRepository<CdrCerOnCentro> gaCdrCersOnCentriRepo,
            IGenericRepository<CdrComuneOnCentro> gaCdrComuniOnCentriRepo,

            IGenericRepository<ViewGaCdrCersOnCentri> viewGaCdrCersOnCentriRepo,
            IGenericRepository<ViewGaCdrComuniOnCentri> viewGaCdrComuniOnCentriRepo,
            IGenericRepository<ViewGaCdrComuni> viewGaCdrComuniRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaCdrCentriRepo = gaCdrCentriRepo;
            this.gaCdrComuniRepo = gaCdrComuniRepo;
            this.gaCdrCersRepo = gaCdrCersRepo;
            this.gaCdrCersDettagliRepo = gaCdrCersDettagliRepo;
            this.gaCdrCersOnCentriRepo = gaCdrCersOnCentriRepo;
            this.gaCdrComuniOnCentriRepo = gaCdrComuniOnCentriRepo;

            this.viewGaCdrCersOnCentriRepo = viewGaCdrCersOnCentriRepo;
            this.viewGaCdrComuniOnCentriRepo = viewGaCdrComuniOnCentriRepo;
            this.viewGaCdrComuniRepo = viewGaCdrComuniRepo;

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

        #region Views
        //public async Task<PagedList<ViewGaCdrComuni>> GetViewGaCdrComuniAsync(bool all = true)
        //{
        //    var entities = all ? await viewGaCdrComuniRepo.GetAllAsync(1, 0) : await viewGaCdrComuniRepo.GetWithFilterAsync(x => x.Disabled == false);
        //    return entities;
        //}

        #endregion

        #endregion

        #region CdrCers
        public async Task<CdrCersDto> GetGaCdrCersAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrCersRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCersDto, PagedList<CdrCer>>();
            return dtos;
        }

        public async Task<CdrCerDto> GetGaCdrCerByIdAsync(long id)
        {
            var entity = await gaCdrCersRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrCerDto, CdrCer>();
            return dto;
        }

        public async Task<long> AddGaCdrCerAsync(CdrCerDto dto)
        {
            var entity = dto.ToEntity<CdrCer, CdrCerDto>();
            await gaCdrCersRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrCerAsync(CdrCerDto dto)
        {
            var entity = dto.ToEntity<CdrCer, CdrCerDto>();
            gaCdrCersRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrCerAsync(long id)
        {
            var entity = await gaCdrCersRepo.GetByIdAsync(id);
            gaCdrCersRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrCerAsync(long id, string cer)
        {
            var entity = await gaCdrCersRepo.GetWithFilterAsync(x => x.Cer == cer && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrCerAsync(long id)
        {
            var entity = await gaCdrCersRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CdrCersDettagli
        public async Task<CdrCersDettagliDto> GetGaCdrCersDettagliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrCersDettagliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCersDettagliDto, PagedList<CdrCerDettaglio>>();
            return dtos;
        }

        public async Task<CdrCerDettaglioDto> GetGaCdrCerDettaglioByIdAsync(long id)
        {
            var entity = await gaCdrCersDettagliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrCerDettaglioDto, CdrCerDettaglio>();
            return dto;
        }

        public async Task<long> AddGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto)
        {
            var entity = dto.ToEntity<CdrCerDettaglio, CdrCerDettaglioDto>();
            await gaCdrCersDettagliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto)
        {
            var entity = dto.ToEntity<CdrCerDettaglio, CdrCerDettaglioDto>();
            gaCdrCersDettagliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrCerDettaglioAsync(long id)
        {
            var entity = await gaCdrCersDettagliRepo.GetByIdAsync(id);
            gaCdrCersDettagliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrCerDettaglioAsync(long id, string descrizione)
        {
            var entity = await gaCdrCersDettagliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrCerDettaglioAsync(long id)
        {
            var entity = await gaCdrCersDettagliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrCersDettagliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrCersDettagliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CdrCersOnCentri

        public async Task<CdrCersDto> GetGaCdrCersOnCentriAsync(long id)
        {
            throw new NotImplementedException();
        //        var entities = await gaCdrCersOnCentriRepo.GetWithFilterAsync(x => x.CdrCentroId == id, 1, 0);

        //        var cers = await gaCdrCersRepo.GetAllAsync(1, 0);
        //        var dtos = cers.ToDto<CdrCersDto, PagedList<CdrCer>>();
        //        var data = from x in dtos.Data
        //                   where entities.Data.Any(s => s.CdrCerId == x.Id)
        //                   select x;

        //        var response = new CdrCersDto();
        //        response.TotalCount = data.Count();
        //        response.PageSize = 0;
        //        response.Data = data.ToList();

        }

        public async Task<bool> UpdateGaCdrCerOnCentroAsync(long cerId, long centroId)
        {
            var exists = await gaCdrCersOnCentriRepo.CheckIfExist(x => x.CdrCerId == cerId && x.CdrCentroId == centroId);
            if (exists)
            {
                var entity = await gaCdrCersOnCentriRepo.GetSingleWithFilter(x => x.CdrCerId == cerId && x.CdrCentroId == centroId);
                gaCdrCersOnCentriRepo.Remove(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                var entity = new CdrCerOnCentro();
                entity.CdrCentroId = centroId;
                entity.CdrCerId = cerId;
                gaCdrCersOnCentriRepo.Add(entity);
                await SaveChanges();
                return true;
            }
        }

        #region Views
        public async Task<PagedList<ViewGaCdrCersOnCentri>> GetViewGaCdrCersOnCentriAsync(long id)
        {
            var entities = await viewGaCdrCersOnCentriRepo.GetWithFilterAsync(x => x.CentroId == id, 1, 0);
            return entities;
        }

        #endregion

        #endregion

        #region CdrComuniOnCentri

        public async Task<bool> UpdateGaCdrComuneOnCentroAsync(long comuneId,long centroId)
        {
            var exists=await gaCdrComuniOnCentriRepo.CheckIfExist(x => x.CdrComuneId == comuneId && x.CdrCentroId == centroId);
            if (exists)
            {
                var entity = await gaCdrComuniOnCentriRepo.GetSingleWithFilter(x => x.CdrComuneId == comuneId && x.CdrCentroId == centroId);
                gaCdrComuniOnCentriRepo.Remove(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                var entity = new CdrComuneOnCentro();
                entity.CdrCentroId = centroId;
                entity.CdrComuneId = comuneId;
                gaCdrComuniOnCentriRepo.Add(entity);
                await SaveChanges();
                return true;
            }
        }


        #region Views
        public async Task<PagedList<ViewGaCdrComuniOnCentri>> GetViewGaCdrComuniOnCentriAsync(long id)
        {
            var entities = await viewGaCdrComuniOnCentriRepo.GetWithFilterAsync(x => x.CentroId == id, 1, 0);
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
