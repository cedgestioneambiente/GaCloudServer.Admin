using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneLocali;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPrenotazioneLocaliService : IGaPrenotazioneLocaliService
    {
        protected readonly IGenericRepository<PrenotazioneLocaliUfficio> gaPrenotazioneLocaliUfficiRepo;
        protected readonly IGenericRepository<PrenotazioneLocaliSede> gaPrenotazioneLocaliSediRepo;
        protected readonly IGenericRepository<PrenotazioneLocaliRegistrazione> gaPrenotazioneLocaliRegistrazioniRepo;

        protected readonly IGenericRepository<ViewGaPrenotazioneLocaliUffici> viewGaPrenotazioneLocaliUfficiRepo;
        protected readonly IGenericRepository<ViewGaPrenotazioneLocaliRegistrazioni> viewGaPrenotazioneLocaliRegistrazioniRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaPrenotazioneLocaliService(
        IGenericRepository<PrenotazioneLocaliUfficio> gaPrenotazioneLocaliUfficiRepo,
        IGenericRepository<PrenotazioneLocaliSede> gaPrenotazioneLocaliSediRepo,
        IGenericRepository<PrenotazioneLocaliRegistrazione> gaPrenotazioneLocaliRegistrazioniRepo,

        IGenericRepository<ViewGaPrenotazioneLocaliUffici> viewGaPrenotazioneLocaliUfficiRepo,
        IGenericRepository<ViewGaPrenotazioneLocaliRegistrazioni> viewGaPrenotazioneLocaliRegistrazioniRepo,

        IUnitOfWork unitOfWork)
        {
            this.gaPrenotazioneLocaliSediRepo = gaPrenotazioneLocaliSediRepo;
            this.gaPrenotazioneLocaliUfficiRepo = gaPrenotazioneLocaliUfficiRepo;
            this.gaPrenotazioneLocaliRegistrazioniRepo = gaPrenotazioneLocaliRegistrazioniRepo;

            this.viewGaPrenotazioneLocaliUfficiRepo = viewGaPrenotazioneLocaliUfficiRepo;
            this.viewGaPrenotazioneLocaliRegistrazioniRepo = viewGaPrenotazioneLocaliRegistrazioniRepo;

            this.unitOfWork = unitOfWork;

        }

        #region PrenotazioneLocaliSedi
        public async Task<PrenotazioneLocaliSediDto> GetGaPrenotazioneLocaliSediAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPrenotazioneLocaliSediRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PrenotazioneLocaliSediDto, PagedList<PrenotazioneLocaliSede>>();
            return dtos;
        }

        public async Task<PrenotazioneLocaliSedeDto> GetGaPrenotazioneLocaliSedeByIdAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliSediRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrenotazioneLocaliSedeDto, PrenotazioneLocaliSede>();
            return dto;
        }

        public async Task<long> AddGaPrenotazioneLocaliSedeAsync(PrenotazioneLocaliSedeDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneLocaliSede, PrenotazioneLocaliSedeDto>();
            await gaPrenotazioneLocaliSediRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPrenotazioneLocaliSedeAsync(PrenotazioneLocaliSedeDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneLocaliSede, PrenotazioneLocaliSedeDto>();
            gaPrenotazioneLocaliSediRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPrenotazioneLocaliSedeAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliSediRepo.GetByIdAsync(id);
            gaPrenotazioneLocaliSediRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPrenotazioneLocaliSedeAsync(long id, string descrizione)
        {
            var entity = await gaPrenotazioneLocaliSediRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPrenotazioneLocaliSedeAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliSediRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPrenotazioneLocaliSediRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPrenotazioneLocaliSediRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PrenotazioneLocaliUffici
        public async Task<PrenotazioneLocaliUfficiDto> GetGaPrenotazioneLocaliUfficiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPrenotazioneLocaliUfficiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PrenotazioneLocaliUfficiDto, PagedList<PrenotazioneLocaliUfficio>>();
            return dtos;
        }

        public async Task<PrenotazioneLocaliUfficioDto> GetGaPrenotazioneLocaliUfficioByIdAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliUfficiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrenotazioneLocaliUfficioDto, PrenotazioneLocaliUfficio>();
            return dto;
        }

        public async Task<long> AddGaPrenotazioneLocaliUfficioAsync(PrenotazioneLocaliUfficioDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneLocaliUfficio, PrenotazioneLocaliUfficioDto>();
            await gaPrenotazioneLocaliUfficiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPrenotazioneLocaliUfficioAsync(PrenotazioneLocaliUfficioDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneLocaliUfficio, PrenotazioneLocaliUfficioDto>();
            gaPrenotazioneLocaliUfficiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPrenotazioneLocaliUfficioAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliUfficiRepo.GetByIdAsync(id);
            gaPrenotazioneLocaliUfficiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPrenotazioneLocaliUfficioAsync(long id, string descrizione)
        {
            var entity = await gaPrenotazioneLocaliUfficiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPrenotazioneLocaliUfficioAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliUfficiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPrenotazioneLocaliUfficiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPrenotazioneLocaliUfficiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views

        public async Task<PagedList<ViewGaPrenotazioneLocaliUffici>> GetViewGaPrenotazioneLocaliUfficiAsync(bool all = false)
        {
            var entities = all ? await viewGaPrenotazioneLocaliUfficiRepo.GetAllAsync(1, 0) : await viewGaPrenotazioneLocaliUfficiRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }

        #endregion

        #endregion

        #region PrenotazioneLocaliRegistrazioni
        public async Task<PrenotazioneLocaliRegistrazioniDto> GetGaPrenotazioneLocaliRegistrazioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPrenotazioneLocaliRegistrazioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PrenotazioneLocaliRegistrazioniDto, PagedList<PrenotazioneLocaliRegistrazione>>();
            return dtos;
        }

        public async Task<PrenotazioneLocaliRegistrazioneDto> GetGaPrenotazioneLocaliRegistrazioneByIdAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliRegistrazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrenotazioneLocaliRegistrazioneDto, PrenotazioneLocaliRegistrazione>();
            return dto;
        }

        public async Task<long> AddGaPrenotazioneLocaliRegistrazioneAsync(PrenotazioneLocaliRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneLocaliRegistrazione, PrenotazioneLocaliRegistrazioneDto>();
            await gaPrenotazioneLocaliRegistrazioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPrenotazioneLocaliRegistrazioneAsync(PrenotazioneLocaliRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneLocaliRegistrazione, PrenotazioneLocaliRegistrazioneDto>();
            gaPrenotazioneLocaliRegistrazioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }
        public async Task<bool> DeleteGaPrenotazioneLocaliRegistrazioneAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliRegistrazioniRepo.GetByIdAsync(id);
            gaPrenotazioneLocaliRegistrazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<int> ValidateGaPrenotazioneLocaliRegistrazioneAsync(PrenotazioneLocaliRegistrazioneDto dto)
        {
            int result = 0;
            var entities = await gaPrenotazioneLocaliRegistrazioniRepo
                .GetWithFilterAsync(x => x.PrenotazioneLocaliUfficioId == dto.PrenotazioneLocaliUfficioId && (dto.DataInizio <= x.DataFine && x.DataInizio < dto.DataFine) && x.Id != dto.Id);

            var veicolo = await gaPrenotazioneLocaliUfficiRepo.GetByIdAsync(dto.PrenotazioneLocaliUfficioId);

            if (entities.Data.Count > 0)
            {
                return -2;
            }

            if (dto.DataInizio > dto.DataFine)
            {
                return -3;
            }

            return result;
        }
        public async Task<bool> ChangeStatusGaPrenotazioneLocaliRegistrazioneAsync(long id)
        {
            var entity = await gaPrenotazioneLocaliRegistrazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPrenotazioneLocaliRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPrenotazioneLocaliRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        #endregion

        #region Views

        public async Task<PagedList<ViewGaPrenotazioneLocaliRegistrazioni>> GetViewGaPrenotazioneLocaliRegistrazioniAsync(bool all = false)
        {
            var entities = all ? await viewGaPrenotazioneLocaliRegistrazioniRepo.GetAllAsync(1, 0) : await viewGaPrenotazioneLocaliRegistrazioniRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }

        public async Task<ViewGaPrenotazioneLocaliRegistrazioni> GetViewGaPrenotazioneLocaliRegistrazioniByIdAsync(long id)
        {
            var view = await viewGaPrenotazioneLocaliRegistrazioniRepo.GetSingleWithFilter(x => x.Id == id);
            return view;
        }
        #endregion

        #endregion

        #region Common
        private async Task<long> SaveChanges()
        {
            return await unitOfWork.SaveChangesAsync();
        }

        #endregion

    }
}

