using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dashboard.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Dashboard;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class DashboardService:IDashboardService
    {
        protected readonly IQueryManager _queryManager;

        protected readonly IGenericRepository<DashboardType> _DashboardTypesRepo;
        protected readonly IGenericRepository<DashboardSection> _DashboardSectionsRepo;
        protected readonly IGenericRepository<DashboardItem> _DashboardItemsRepo;

        protected readonly IGenericRepository<ViewDashboardItems> _viewDashboardItems;

        protected readonly IUnitOfWork unitOfWork;

        public DashboardService(
            IQueryManager queryManager,

            IGenericRepository<DashboardType> DashboardTypesRepo,
            IGenericRepository<DashboardSection> DashboardSectionsRepo,
            IGenericRepository<DashboardItem> DashboardItemsRepo,

            IGenericRepository<ViewDashboardItems> viewDashboardItems,

        IUnitOfWork unitOfWork)
        {
            this._queryManager = queryManager;

            this._DashboardTypesRepo = DashboardTypesRepo;
            this._DashboardSectionsRepo = DashboardSectionsRepo;
            this._DashboardItemsRepo = DashboardItemsRepo;

            this._viewDashboardItems = viewDashboardItems;

            this.unitOfWork = unitOfWork;
        }

        public async Task<List<object>> GetFromQueryAsync(string query)
        {
            var entities = await _queryManager.ExecQueryAsync(query);
            return entities;
        }

        #region DashboardTypes
        public async Task<DashboardTypesDto> GetDashboardTypesAsync(int page = 1, int pageSize = 0)
        {
            var entities = await _DashboardTypesRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DashboardTypesDto, PagedList<DashboardType>>();
            return dtos;
        }

        public async Task<DashboardTypeDto> GetDashboardTypeByIdAsync(long id)
        {
            var entity = await _DashboardTypesRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DashboardTypeDto, DashboardType>();
            return dto;
        }

        public async Task<long> AddDashboardTypeAsync(DashboardTypeDto dto)
        {
            var entity = dto.ToEntity<DashboardType, DashboardTypeDto>();
            await _DashboardTypesRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateDashboardTypeAsync(DashboardTypeDto dto)
        {
            var entity = dto.ToEntity<DashboardType, DashboardTypeDto>();
            _DashboardTypesRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteDashboardTypeAsync(long id)
        {
            var entity = await _DashboardTypesRepo.GetByIdAsync(id);
            _DashboardTypesRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateDashboardTypeAsync(long id, string descrizione)
        {
            var entity = await _DashboardTypesRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusDashboardTypeAsync(long id)
        {
            var entity = await _DashboardTypesRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                _DashboardTypesRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                _DashboardTypesRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region DashboardSections
        public async Task<DashboardSectionsDto> GetDashboardSectionsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await _DashboardSectionsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DashboardSectionsDto, PagedList<DashboardSection>>();
            return dtos;
        }

        public async Task<DashboardSectionDto> GetDashboardSectionByIdAsync(long id)
        {
            var entity = await _DashboardSectionsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DashboardSectionDto, DashboardSection>();
            return dto;
        }

        public async Task<long> AddDashboardSectionAsync(DashboardSectionDto dto)
        {
            var entity = dto.ToEntity<DashboardSection, DashboardSectionDto>();
            await _DashboardSectionsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateDashboardSectionAsync(DashboardSectionDto dto)
        {
            var entity = dto.ToEntity<DashboardSection, DashboardSectionDto>();
            _DashboardSectionsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteDashboardSectionAsync(long id)
        {
            var entity = await _DashboardSectionsRepo.GetByIdAsync(id);
            _DashboardSectionsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateDashboardSectionAsync(long id, string descrizione)
        {
            var entity = await _DashboardSectionsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusDashboardSectionAsync(long id)
        {
            var entity = await _DashboardSectionsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                _DashboardSectionsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                _DashboardSectionsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region DashboardItems
        public async Task<DashboardItemsDto> GetDashboardItemsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await _DashboardItemsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DashboardItemsDto, PagedList<DashboardItem>>();
            return dtos;
        }

        public async Task<DashboardItemDto> GetDashboardItemByIdAsync(long id)
        {
            var entity = await _DashboardItemsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DashboardItemDto, DashboardItem>();
            return dto;
        }

        public async Task<long> AddDashboardItemAsync(DashboardItemDto dto)
        {
            var entity = dto.ToEntity<DashboardItem, DashboardItemDto>();
            await _DashboardItemsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateDashboardItemAsync(DashboardItemDto dto)
        {
            var entity = dto.ToEntity<DashboardItem, DashboardItemDto>();
            _DashboardItemsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteDashboardItemAsync(long id)
        {
            var entity = await _DashboardItemsRepo.GetByIdAsync(id);
            _DashboardItemsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateDashboardItemAsync(long id, string descrizione)
        {
            var entity = await _DashboardItemsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusDashboardItemAsync(long id)
        {
            var entity = await _DashboardItemsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                _DashboardItemsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                _DashboardItemsRepo.Update(entity);
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
