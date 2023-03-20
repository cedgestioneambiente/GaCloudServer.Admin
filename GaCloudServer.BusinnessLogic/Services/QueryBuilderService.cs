using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.QueryBuilder;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class QueryBuilderService:IQueryBuilderService
    {
        protected readonly IQueryManager _queryManager;

        protected readonly IGenericRepository<QueryBuilderParamType> _queryBuilderParamTypesRepo;
        protected readonly IGenericRepository<QueryBuilderSection> _queryBuilderSectionsRepo;
        protected readonly IGenericRepository<QueryBuilderScript> _queryBuilderScriptsRepo;
        protected readonly IGenericRepository<QueryBuilderParamOnScript> _queryBuilderParamOnScriptsRepo;

        protected readonly IGenericRepository<ViewQueryBuilderParamOnScripts> _viewQueryBuilderParamOnScripts;
        protected readonly IGenericRepository<ViewQueryBuilderScripts> _viewQueryBuilderScripts;

        protected readonly IUnitOfWork unitOfWork;

        public QueryBuilderService(
            IQueryManager queryManager,

            IGenericRepository<QueryBuilderParamType> queryBuilderParamTypesRepo,
            IGenericRepository<QueryBuilderSection> queryBuilderSectionsRepo,
            IGenericRepository<QueryBuilderScript> queryBuilderScriptsRepo,
            IGenericRepository<QueryBuilderParamOnScript> queryBuilderParamOnScriptsRepo,

            IGenericRepository<ViewQueryBuilderParamOnScripts> viewQueryBuilderParamOnScripts,
            IGenericRepository<ViewQueryBuilderScripts> viewQueryBuilderScripts,

        IUnitOfWork unitOfWork)
        {
            this._queryManager = queryManager;

            this._queryBuilderParamTypesRepo = queryBuilderParamTypesRepo;
            this._queryBuilderSectionsRepo = queryBuilderSectionsRepo;
            this._queryBuilderScriptsRepo = queryBuilderScriptsRepo;
            this._queryBuilderParamOnScriptsRepo = queryBuilderParamOnScriptsRepo;

            this._viewQueryBuilderParamOnScripts = viewQueryBuilderParamOnScripts;
            this._viewQueryBuilderScripts = viewQueryBuilderScripts;

            this.unitOfWork = unitOfWork;
        }

        public async Task<List<object>> GetFromQueryAsync(string query)
        {
            var entities = await _queryManager.ExecQueryAsync(query);
            return entities;
        }

        #region QueryBuilderParamTypes
        public async Task<QueryBuilderParamTypesDto> GetQueryBuilderParamTypesAsync(int page = 1, int pageSize = 0)
        {
            var entities = await _queryBuilderParamTypesRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<QueryBuilderParamTypesDto, PagedList<QueryBuilderParamType>>();
            return dtos;
        }

        public async Task<QueryBuilderParamTypeDto> GetQueryBuilderParamTypeByIdAsync(long id)
        {
            var entity = await _queryBuilderParamTypesRepo.GetByIdAsync(id);
            var dto = entity.ToDto<QueryBuilderParamTypeDto, QueryBuilderParamType>();
            return dto;
        }

        public async Task<long> AddQueryBuilderParamTypeAsync(QueryBuilderParamTypeDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderParamType, QueryBuilderParamTypeDto>();
            await _queryBuilderParamTypesRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateQueryBuilderParamTypeAsync(QueryBuilderParamTypeDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderParamType, QueryBuilderParamTypeDto>();
            _queryBuilderParamTypesRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteQueryBuilderParamTypeAsync(long id)
        {
            var entity = await _queryBuilderParamTypesRepo.GetByIdAsync(id);
            _queryBuilderParamTypesRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateQueryBuilderParamTypeAsync(long id, string descrizione)
        {
            var entity = await _queryBuilderParamTypesRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusQueryBuilderParamTypeAsync(long id)
        {
            var entity = await _queryBuilderParamTypesRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                _queryBuilderParamTypesRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                _queryBuilderParamTypesRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region QueryBuilderSections
        public async Task<QueryBuilderSectionsDto> GetQueryBuilderSectionsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await _queryBuilderSectionsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<QueryBuilderSectionsDto, PagedList<QueryBuilderSection>>();
            return dtos;
        }

        public async Task<QueryBuilderSectionDto> GetQueryBuilderSectionByIdAsync(long id)
        {
            var entity = await _queryBuilderSectionsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<QueryBuilderSectionDto, QueryBuilderSection>();
            return dto;
        }

        public async Task<long> AddQueryBuilderSectionAsync(QueryBuilderSectionDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderSection, QueryBuilderSectionDto>();
            await _queryBuilderSectionsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateQueryBuilderSectionAsync(QueryBuilderSectionDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderSection, QueryBuilderSectionDto>();
            _queryBuilderSectionsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteQueryBuilderSectionAsync(long id)
        {
            var entity = await _queryBuilderSectionsRepo.GetByIdAsync(id);
            _queryBuilderSectionsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateQueryBuilderSectionAsync(long id, string descrizione)
        {
            var entity = await _queryBuilderSectionsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusQueryBuilderSectionAsync(long id)
        {
            var entity = await _queryBuilderSectionsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                _queryBuilderSectionsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                _queryBuilderSectionsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region QueryBuilderScripts
        public async Task<QueryBuilderScriptsDto> GetQueryBuilderScriptsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await _queryBuilderScriptsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<QueryBuilderScriptsDto, PagedList<QueryBuilderScript>>();
            return dtos;
        }

        public async Task<QueryBuilderScriptDto> GetQueryBuilderScriptByIdAsync(long id)
        {
            var entity = await _queryBuilderScriptsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<QueryBuilderScriptDto, QueryBuilderScript>();
            return dto;
        }

        public async Task<long> AddQueryBuilderScriptAsync(QueryBuilderScriptDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderScript, QueryBuilderScriptDto>();
            await _queryBuilderScriptsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateQueryBuilderScriptAsync(QueryBuilderScriptDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderScript, QueryBuilderScriptDto>();
            _queryBuilderScriptsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteQueryBuilderScriptAsync(long id)
        {
            var entity = await _queryBuilderScriptsRepo.GetByIdAsync(id);
            _queryBuilderScriptsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateQueryBuilderScriptAsync(long id, string descrizione)
        {
            var entity = await _queryBuilderScriptsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusQueryBuilderScriptAsync(long id)
        {
            var entity = await _queryBuilderScriptsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                _queryBuilderScriptsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                _queryBuilderScriptsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region QueryBuilderParamScripts
        public async Task<QueryBuilderParamOnScriptsDto> GetQueryBuilderParamOnScriptsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await _queryBuilderParamOnScriptsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<QueryBuilderParamOnScriptsDto, PagedList<QueryBuilderParamOnScript>>();
            return dtos;
        }

        public async Task<QueryBuilderParamOnScriptsDto> GetQueryBuilderParamOnScriptsByScriptIdAsync(long scriptId)
        {
            var entities = await _queryBuilderParamOnScriptsRepo.GetWithFilterAsync(x=>x.QueryBuilderScriptId==scriptId);
            var dtos = entities.ToDto<QueryBuilderParamOnScriptsDto, PagedList<QueryBuilderParamOnScript>>();
            return dtos;
        }

        public async Task<QueryBuilderParamOnScriptDto> GetQueryBuilderParamOnScriptByIdAsync(long id)
        {
            var entity = await _queryBuilderParamOnScriptsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<QueryBuilderParamOnScriptDto, QueryBuilderParamOnScript>();
            return dto;
        }

        public async Task<long> AddQueryBuilderParamOnScriptAsync(QueryBuilderParamOnScriptDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderParamOnScript, QueryBuilderParamOnScriptDto>();
            await _queryBuilderParamOnScriptsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateQueryBuilderParamOnScriptAsync(QueryBuilderParamOnScriptDto dto)
        {
            var entity = dto.ToEntity<QueryBuilderParamOnScript, QueryBuilderParamOnScriptDto>();
            _queryBuilderParamOnScriptsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteQueryBuilderParamOnScriptAsync(long id)
        {
            var entity = await _queryBuilderParamOnScriptsRepo.GetByIdAsync(id);
            _queryBuilderParamOnScriptsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateQueryBuilderParamOnScriptAsync(long id,long scriptId, string descrizione)
        {
            var entity = await _queryBuilderParamOnScriptsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.QueryBuilderScriptId==scriptId && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusQueryBuilderParamOnScriptAsync(long id)
        {
            var entity = await _queryBuilderParamOnScriptsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                _queryBuilderParamOnScriptsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                _queryBuilderParamOnScriptsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewQueryBuilderParamOnScripts>> GetViewQueryBuilderParamOnScriptsByScriptIdAsync(long scriptId)
        {
            var view = await _viewQueryBuilderParamOnScripts.GetWithFilterAsync(x => x.QueryBuilderScriptId == scriptId);
            return view;
        }

        public async Task<PagedList<ViewQueryBuilderScripts>> GetViewQueryBuilderScriptsAsync()
        {
            var view = await _viewQueryBuilderScripts.GetAllAsync(1,0,"Section");
            return view;
        }

        public async Task<PagedList<ViewQueryBuilderScripts>> GetViewQueryBuilderScriptsByRolesAsync(string roles)
        {
            var masterSet = new HashSet<string>(roles.Split(","));
            string[] keyword = roles.Split(new char[] { ',' });

            string[] rolesArray = roles.Split(",");
            var links = await _viewQueryBuilderScripts.GetWithFilterAsync(x => x.Disabled == false);

            PagedList<ViewQueryBuilderScripts> dtos = new PagedList<ViewQueryBuilderScripts>();
            List<ViewQueryBuilderScripts> list = new List<ViewQueryBuilderScripts>();
            foreach (var itm in links.Data)
            {
                if (itm.Roles.Split(",").Any(x => keyword.Contains(x)))
                {
                    list.Add(itm);
                }
            }
            dtos.Data.AddRange(list);
            dtos.TotalCount = list.Count;
            dtos.PageSize = 0;
            return dtos;
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
