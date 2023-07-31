using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Dispositivi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Dispositivi;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaDispositiviService : IGaDispositiviService
    {
        protected readonly IGenericRepository<DispositiviTipologia> gaDispositiviTipologieRepo;
        protected readonly IGenericRepository<DispositiviModello> gaDispositiviModelliRepo;
        protected readonly IGenericRepository<DispositiviMarca> gaDispositiviMarcheRepo;
        protected readonly IGenericRepository<DispositiviClasse> gaDispositiviClassiRepo;
        protected readonly IGenericRepository<DispositiviCategoria> gaDispositiviCategorieRepo;
        protected readonly IGenericRepository<DispositiviStock> gaDispositiviStocksRepo;
        protected readonly IGenericRepository<DispositiviItem> gaDispositiviItemsRepo;
        protected readonly IGenericRepository<DispositiviModulo> gaDispositiviModuliRepo;
        protected readonly IGenericRepository<DispositiviOnDipendente> gaDispositiviOnDipendentiRepo;
        protected readonly IGenericRepository<DispositiviOnModulo> gaDispositiviOnModuliRepo;


        protected readonly IGenericRepository<ViewGaDispositiviItems> viewGaDispositiviItemsRepo;
        protected readonly IGenericRepository<ViewGaDispositiviStocks> viewGaDispositiviStocksRepo;
        protected readonly IGenericRepository<ViewGaDispositiviOnDipendenti> viewGaDispositiviOnDipendentiRepo;
        protected readonly IGenericRepository<ViewGaDispositiviOnModuli> viewGaDispositiviOnModuliRepo;


        protected readonly IUnitOfWork unitOfWork;

        public GaDispositiviService(
            IGenericRepository<DispositiviTipologia> gaDispositiviTipologieRepo,
            IGenericRepository<DispositiviModello> gaDispositiviModelliRepo,
            IGenericRepository<DispositiviMarca> gaDispositiviMarcheRepo,
            IGenericRepository<DispositiviClasse> gaDispositiviClassiRepo,
            IGenericRepository<DispositiviCategoria> gaDispositiviCategorieRepo,
            IGenericRepository<DispositiviStock> gaDispositiviStocksRepo,
            IGenericRepository<DispositiviItem> gaDispositiviItemsRepo,
            IGenericRepository<DispositiviModulo> gaDispositiviModuliRepo,
            IGenericRepository<DispositiviOnDipendente> gaDispositiviOnDipendentiRepo,
            IGenericRepository<DispositiviOnModulo> gaDispositiviOnModuliRepo,


            IGenericRepository<ViewGaDispositiviItems> viewGaDispositiviItemsRepo,
            IGenericRepository<ViewGaDispositiviStocks> viewGaDispositiviStocksRepo,
            IGenericRepository<ViewGaDispositiviOnDipendenti> viewGaDispositiviOnDipendentiRepo,
            IGenericRepository<ViewGaDispositiviOnModuli> viewGaDispositiviOnModuliRepo,


            IUnitOfWork unitOfWork)
        {
            this.gaDispositiviTipologieRepo = gaDispositiviTipologieRepo;
            this.gaDispositiviModelliRepo = gaDispositiviModelliRepo;
            this.gaDispositiviMarcheRepo = gaDispositiviMarcheRepo;
            this.gaDispositiviClassiRepo = gaDispositiviClassiRepo;
            this.gaDispositiviCategorieRepo = gaDispositiviCategorieRepo;
            this.gaDispositiviStocksRepo = gaDispositiviStocksRepo;
            this.gaDispositiviItemsRepo = gaDispositiviItemsRepo;
            this.gaDispositiviModuliRepo = gaDispositiviModuliRepo;
            this.gaDispositiviOnDipendentiRepo = gaDispositiviOnDipendentiRepo;
            this.gaDispositiviOnModuliRepo = gaDispositiviOnModuliRepo;


            this.viewGaDispositiviItemsRepo = viewGaDispositiviItemsRepo;
            this.viewGaDispositiviStocksRepo = viewGaDispositiviStocksRepo;
            this.viewGaDispositiviOnDipendentiRepo = viewGaDispositiviOnDipendentiRepo;
            this.viewGaDispositiviOnModuliRepo = viewGaDispositiviOnModuliRepo;


            this.unitOfWork = unitOfWork;

        }

        #region DispositiviTipologie
        public async Task<DispositiviTipologieDto> GetGaDispositiviTipologieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviTipologieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviTipologieDto, PagedList<DispositiviTipologia>>();
            return dtos;
        }

        public async Task<DispositiviTipologiaDto> GetGaDispositiviTipologiaByIdAsync(long id)
        {
            var entity = await gaDispositiviTipologieRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviTipologiaDto, DispositiviTipologia>();
            return dto;
        }

        public async Task<long> AddGaDispositiviTipologiaAsync(DispositiviTipologiaDto dto)
        {
            var entity = dto.ToEntity<DispositiviTipologia, DispositiviTipologiaDto>();
            await gaDispositiviTipologieRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviTipologiaAsync(DispositiviTipologiaDto dto)
        {
            var entity = dto.ToEntity<DispositiviTipologia, DispositiviTipologiaDto>();
            gaDispositiviTipologieRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviTipologiaAsync(long id)
        {
            var entity = await gaDispositiviTipologieRepo.GetByIdAsync(id);
            gaDispositiviTipologieRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaDispositiviTipologiaAsync(long id, string descrizione)
        {
            var entity = await gaDispositiviTipologieRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaDispositiviTipologiaAsync(long id)
        {
            var entity = await gaDispositiviTipologieRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region DispositiviModelli
        public async Task<DispositiviModelliDto> GetGaDispositiviModelliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviModelliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviModelliDto, PagedList<DispositiviModello>>();
            return dtos;
        }

        public async Task<DispositiviModelloDto> GetGaDispositiviModelloByIdAsync(long id)
        {
            var entity = await gaDispositiviModelliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviModelloDto, DispositiviModello>();
            return dto;
        }

        public async Task<long> AddGaDispositiviModelloAsync(DispositiviModelloDto dto)
        {
            var entity = dto.ToEntity<DispositiviModello, DispositiviModelloDto>();
            await gaDispositiviModelliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviModelloAsync(DispositiviModelloDto dto)
        {
            var entity = dto.ToEntity<DispositiviModello, DispositiviModelloDto>();
            gaDispositiviModelliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviModelloAsync(long id)
        {
            var entity = await gaDispositiviModelliRepo.GetByIdAsync(id);
            gaDispositiviModelliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaDispositiviModelloAsync(long id, string descrizione)
        {
            var entity = await gaDispositiviModelliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaDispositiviModelloAsync(long id)
        {
            var entity = await gaDispositiviModelliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviModelliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviModelliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region DispositiviMarche
        public async Task<DispositiviMarcheDto> GetGaDispositiviMarcheAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviMarcheRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviMarcheDto, PagedList<DispositiviMarca>>();
            return dtos;
        }

        public async Task<DispositiviMarcaDto> GetGaDispositiviMarcaByIdAsync(long id)
        {
            var entity = await gaDispositiviMarcheRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviMarcaDto, DispositiviMarca>();
            return dto;
        }

        public async Task<long> AddGaDispositiviMarcaAsync(DispositiviMarcaDto dto)
        {
            var entity = dto.ToEntity<DispositiviMarca, DispositiviMarcaDto>();
            await gaDispositiviMarcheRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviMarcaAsync(DispositiviMarcaDto dto)
        {
            var entity = dto.ToEntity<DispositiviMarca, DispositiviMarcaDto>();
            gaDispositiviMarcheRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviMarcaAsync(long id)
        {
            var entity = await gaDispositiviMarcheRepo.GetByIdAsync(id);
            gaDispositiviMarcheRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaDispositiviMarcaAsync(long id, string descrizione)
        {
            var entity = await gaDispositiviMarcheRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaDispositiviMarcaAsync(long id)
        {
            var entity = await gaDispositiviMarcheRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviMarcheRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviMarcheRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region DispositiviClassi
        public async Task<DispositiviClassiDto> GetGaDispositiviClassiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviClassiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviClassiDto, PagedList<DispositiviClasse>>();
            return dtos;
        }

        public async Task<DispositiviClasseDto> GetGaDispositiviClasseByIdAsync(long id)
        {
            var entity = await gaDispositiviClassiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviClasseDto, DispositiviClasse>();
            return dto;
        }

        public async Task<long> AddGaDispositiviClasseAsync(DispositiviClasseDto dto)
        {
            var entity = dto.ToEntity<DispositiviClasse, DispositiviClasseDto>();
            await gaDispositiviClassiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviClasseAsync(DispositiviClasseDto dto)
        {
            var entity = dto.ToEntity<DispositiviClasse, DispositiviClasseDto>();
            gaDispositiviClassiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviClasseAsync(long id)
        {
            var entity = await gaDispositiviClassiRepo.GetByIdAsync(id);
            gaDispositiviClassiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaDispositiviClasseAsync(long id, string descrizione)
        {
            var entity = await gaDispositiviClassiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaDispositiviClasseAsync(long id)
        {
            var entity = await gaDispositiviClassiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviClassiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviClassiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region DispositiviCategorie
        public async Task<DispositiviCategorieDto> GetGaDispositiviCategorieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviCategorieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviCategorieDto, PagedList<DispositiviCategoria>>();
            return dtos;
        }

        public async Task<DispositiviCategoriaDto> GetGaDispositiviCategoriaByIdAsync(long id)
        {
            var entity = await gaDispositiviCategorieRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviCategoriaDto, DispositiviCategoria>();
            return dto;
        }

        public async Task<long> AddGaDispositiviCategoriaAsync(DispositiviCategoriaDto dto)
        {
            var entity = dto.ToEntity<DispositiviCategoria, DispositiviCategoriaDto>();
            await gaDispositiviCategorieRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviCategoriaAsync(DispositiviCategoriaDto dto)
        {
            var entity = dto.ToEntity<DispositiviCategoria, DispositiviCategoriaDto>();
            gaDispositiviCategorieRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviCategoriaAsync(long id)
        {
            var entity = await gaDispositiviCategorieRepo.GetByIdAsync(id);
            gaDispositiviCategorieRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaDispositiviCategoriaAsync(long id, string descrizione)
        {
            var entity = await gaDispositiviCategorieRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaDispositiviCategoriaAsync(long id)
        {
            var entity = await gaDispositiviCategorieRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviCategorieRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviCategorieRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region DispositiviItems
        public async Task<DispositiviItemsDto> GetGaDispositiviItemsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviItemsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviItemsDto, PagedList<DispositiviItem>>();
            return dtos;
        }

        public async Task<DispositiviItemDto> GetGaDispositiviItemByIdAsync(long id)
        {
            var entity = await gaDispositiviItemsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviItemDto, DispositiviItem>();
            return dto;
        }

        public async Task<long> AddGaDispositiviItemAsync(DispositiviItemDto dto)
        {
            var entity = dto.ToEntity<DispositiviItem, DispositiviItemDto>();
            await gaDispositiviItemsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviItemAsync(DispositiviItemDto dto)
        {
            var entity = dto.ToEntity<DispositiviItem, DispositiviItemDto>();
            gaDispositiviItemsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviItemAsync(long id)
        {
            var entity = await gaDispositiviItemsRepo.GetByIdAsync(id);
            gaDispositiviItemsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaDispositiviItemAsync(long id, string descrizione)
        {
            var entity = await gaDispositiviItemsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaDispositiviItemAsync(long id)
        {
            var entity = await gaDispositiviItemsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviItemsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviItemsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaDispositiviItems>> GetViewGaDispositiviItemsAsync(int page, int pageSize)
        {
            try
            {
                var entities = await viewGaDispositiviItemsRepo.GetAllAsync(page, pageSize);
                return entities;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region DispositiviStocks
        public async Task<DispositiviStocksDto> GetGaDispositiviStocksAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviStocksRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviStocksDto, PagedList<DispositiviStock>>();
            return dtos;
        }

        public async Task<DispositiviStockDto> GetGaDispositiviStockByIdAsync(long id)
        {
            var entity = await gaDispositiviStocksRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviStockDto, DispositiviStock>();
            return dto;
        }

        public async Task<long> AddGaDispositiviStockAsync(DispositiviStockDto dto)
        {
            var entity = dto.ToEntity<DispositiviStock, DispositiviStockDto>();
            await gaDispositiviStocksRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviStockAsync(DispositiviStockDto dto)
        {
            var entity = dto.ToEntity<DispositiviStock, DispositiviStockDto>();
            gaDispositiviStocksRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviStockAsync(long id)
        {
            var entity = await gaDispositiviStocksRepo.GetByIdAsync(id);
            gaDispositiviStocksRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        public async Task<bool> ChangeStatusGaDispositiviStockAsync(long id)
        {
            var entity = await gaDispositiviStocksRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviStocksRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviStocksRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<bool> SetGaDispositiviStockDisponibileAsync(long id)
        {
            try
            {
                var original = gaDispositiviStocksRepo.GetByIdAsNoTraking(x => x.Id == id);
                var entity = await gaDispositiviStocksRepo.GetByIdAsync(id);
                entity.Disponibile = true;

                gaDispositiviStocksRepo.Update(entity);
                await SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<bool> SetGaDispositiviStockNonDisponibileAsync(long id)
        {
 
            try
            {
                var original = gaDispositiviStocksRepo.GetByIdAsNoTraking(x => x.Id == id);
                var entity = await gaDispositiviStocksRepo.GetByIdAsync(id);
                entity.Disponibile = false;

                gaDispositiviStocksRepo.Update(entity);
                await SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<bool> DuplicateGaDispositiviStockAsync(long id)
        {
            try
            {
                var original = gaDispositiviStocksRepo.GetByIdAsNoTraking(x => x.Id == id);
                var entity = original;
                entity.Id = 0;
                entity.Serial = "Dispositivo Duplicato";
                entity.Disponibile = true;

                await gaDispositiviStocksRepo.AddAsync(entity);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaDispositiviStocks>> GetViewGaDispositiviStocksAsync(bool all = true)
        {
            try
            {
                if (all)
                {
                    var entities = await viewGaDispositiviStocksRepo.GetAllAsync();

                    return entities;
                }
                else
                {
                    var entities = await viewGaDispositiviStocksRepo.GetWithFilterAsync(x => x.Disabled == false && x.Disponibile == true);

                    return entities;
                }
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<PagedList<ViewGaDispositiviStocks>> GetViewGaDispositiviStocksListAsync()
        {
            try
            {
                var entities = await viewGaDispositiviStocksRepo.GetAllAsync();

                return entities;

            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        #endregion

        #endregion

        #region DispositiviModuli

        public async Task<DispositiviModuliDto> GetGaDispositiviModuliByDipendenteIdAsync(long dipendenteId)
        {
            var entities = await gaDispositiviModuliRepo.GetWithFilterAsync(x => x.PersonaleDipendenteId == dipendenteId);
            var dtos = entities.ToDto<DispositiviModuliDto, PagedList< DispositiviModulo >>();
            return dtos;
        }

        public async Task<DispositiviModuloDto> GetGaDispositiviModuloByIdAsync(long id)
        {
            var entity = await gaDispositiviModuliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviModuloDto, DispositiviModulo>();
            return dto;
        }

        public async Task<long> AddGaDispositiviModuloAsync(DispositiviModuloDto dto)
        {
            var entity = dto.ToEntity<DispositiviModulo, DispositiviModuloDto>();
            await gaDispositiviModuliRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviModuloAsync(DispositiviModuloDto dto)
        {
            var entity = dto.ToEntity<DispositiviModulo, DispositiviModuloDto>();
            gaDispositiviModuliRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviModuloAsync(long id)
        {
            var entity = await gaDispositiviModuliRepo.GetByIdAsync(id);
            gaDispositiviModuliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #endregion
       
        #region DispositiviOnDipendenti
        public async Task<DispositiviOnDipendentiDto> GetGaDispositiviOnDipendentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaDispositiviOnDipendentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<DispositiviOnDipendentiDto, PagedList<DispositiviOnDipendente>>();
            return dtos;
        }

        public async Task<DispositiviOnDipendenteDto> GetGaDispositiviOnDipendenteByIdAsync(long id)
        {
            var entity = await gaDispositiviOnDipendentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<DispositiviOnDipendenteDto, DispositiviOnDipendente>();
            return dto;
        }

        public async Task<long> AddGaDispositiviOnDipendenteAsync(DispositiviOnDipendenteDto dto)
        {
            var entity = dto.ToEntity<DispositiviOnDipendente, DispositiviOnDipendenteDto>();
            await gaDispositiviOnDipendentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaDispositiviOnDipendenteAsync(DispositiviOnDipendenteDto dto)
        {
            var entity = dto.ToEntity<DispositiviOnDipendente, DispositiviOnDipendenteDto>();
            gaDispositiviOnDipendentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaDispositiviOnDipendenteAsync(long id)
        {
            var entity = await gaDispositiviOnDipendentiRepo.GetByIdAsync(id);
            gaDispositiviOnDipendentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        public async Task<bool> ChangeStatusGaDispositiviOnDipendenteAsync(long id)
        {
            var entity = await gaDispositiviOnDipendentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaDispositiviOnDipendentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaDispositiviOnDipendentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaDispositiviOnDipendenti>> GetViewGaDispositiviOnDipendentiAsync(int page, int pageSize)
        {
            try
            {
                var entities = await viewGaDispositiviOnDipendentiRepo.GetAllAsync(page, pageSize);

                return entities;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        public async Task<PagedList<ViewGaDispositiviOnDipendenti>> GetViewGaDispositiviOnDipendentiByDipendenteIdAsync(long personaleDipendenteId)
        {
            try
            {
                var entities = await viewGaDispositiviOnDipendentiRepo.GetWithFilterAsync(x => x.PersonaleDipendenteId == personaleDipendenteId, 1, 0, "DataConsegna", "OrderByDescending");

                return entities;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }



        #endregion

        #endregion

        #region DispositiviOnModuli

        #region Views
        public async Task<PagedList<ViewGaDispositiviOnModuli>> GetViewGaDispositiviOnModuloByIdAsync(long id)
        {

            try
            {
                var entities = await viewGaDispositiviOnModuliRepo.GetWithFilterAsync(x => x.Id == id);

                return entities;
            }
            catch (Exception ex)
            {
                await SaveChanges();
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

