using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.PrenotazioneAuto;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPrenotazioneAutoService : IGaPrenotazioneAutoService
    {
        protected readonly IGenericRepository<PrenotazioneAutoVeicolo> gaPrenotazioneAutoVeicoliRepo;
        protected readonly IGenericRepository<PrenotazioneAutoSede> gaPrenotazioneAutoSediRepo;
        protected readonly IGenericRepository<PrenotazioneAutoRegistrazione> gaPrenotazioneAutoRegistrazioniRepo;

        protected readonly IGenericRepository<ViewGaPrenotazioneAutoVeicoli> viewGaPrenotazioneAutoVeicoliRepo;
        protected readonly IGenericRepository<ViewGaPrenotazioneAutoRegistrazioni> viewGaPrenotazioneAutoRegistrazioniRepo;

        protected readonly IUnitOfWork unitOfWork;

        private readonly TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);

        public GaPrenotazioneAutoService(
        IGenericRepository<PrenotazioneAutoVeicolo> gaPrenotazioneAutoVeicoliRepo,
        IGenericRepository<PrenotazioneAutoSede> gaPrenotazioneAutoSediRepo,
        IGenericRepository<PrenotazioneAutoRegistrazione> gaPrenotazioneAutoRegistrazioniRepo,

        IGenericRepository<ViewGaPrenotazioneAutoVeicoli> viewGaPrenotazioneAutoVeicoliRepo,
        IGenericRepository<ViewGaPrenotazioneAutoRegistrazioni> viewGaPrenotazioneAutoRegistrazioniRepo,

        IUnitOfWork unitOfWork)
        {
            this.gaPrenotazioneAutoSediRepo = gaPrenotazioneAutoSediRepo;
            this.gaPrenotazioneAutoVeicoliRepo = gaPrenotazioneAutoVeicoliRepo;
            this.gaPrenotazioneAutoRegistrazioniRepo = gaPrenotazioneAutoRegistrazioniRepo;

            this.viewGaPrenotazioneAutoVeicoliRepo = viewGaPrenotazioneAutoVeicoliRepo;
            this.viewGaPrenotazioneAutoRegistrazioniRepo = viewGaPrenotazioneAutoRegistrazioniRepo;

            this.unitOfWork = unitOfWork;

        }

        #region PrenotazioneAutoSedi
        public async Task<PrenotazioneAutoSediDto> GetGaPrenotazioneAutoSediAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPrenotazioneAutoSediRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PrenotazioneAutoSediDto, PagedList<PrenotazioneAutoSede>>();
            return dtos;
        }

        public async Task<PrenotazioneAutoSedeDto> GetGaPrenotazioneAutoSedeByIdAsync(long id)
        {
            var entity = await gaPrenotazioneAutoSediRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrenotazioneAutoSedeDto, PrenotazioneAutoSede>();
            return dto;
        }

        public async Task<long> AddGaPrenotazioneAutoSedeAsync(PrenotazioneAutoSedeDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneAutoSede, PrenotazioneAutoSedeDto>();
            await gaPrenotazioneAutoSediRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPrenotazioneAutoSedeAsync(PrenotazioneAutoSedeDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneAutoSede, PrenotazioneAutoSedeDto>();
            gaPrenotazioneAutoSediRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPrenotazioneAutoSedeAsync(long id)
        {
            var entity = await gaPrenotazioneAutoSediRepo.GetByIdAsync(id);
            gaPrenotazioneAutoSediRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPrenotazioneAutoSedeAsync(long id, string descrizione)
        {
            var entity = await gaPrenotazioneAutoSediRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPrenotazioneAutoSedeAsync(long id)
        {
            var entity = await gaPrenotazioneAutoSediRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPrenotazioneAutoSediRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPrenotazioneAutoSediRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PrenotazioneAutoVeicoli
        public async Task<PrenotazioneAutoVeicoliDto> GetGaPrenotazioneAutoVeicoliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPrenotazioneAutoVeicoliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PrenotazioneAutoVeicoliDto, PagedList<PrenotazioneAutoVeicolo>>();
            return dtos;
        }

        public async Task<PrenotazioneAutoVeicoloDto> GetGaPrenotazioneAutoVeicoloByIdAsync(long id)
        {
            var entity = await gaPrenotazioneAutoVeicoliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrenotazioneAutoVeicoloDto, PrenotazioneAutoVeicolo>();
            return dto;
        }

        public async Task<long> AddGaPrenotazioneAutoVeicoloAsync(PrenotazioneAutoVeicoloDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneAutoVeicolo, PrenotazioneAutoVeicoloDto>();
            await gaPrenotazioneAutoVeicoliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPrenotazioneAutoVeicoloAsync(PrenotazioneAutoVeicoloDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneAutoVeicolo, PrenotazioneAutoVeicoloDto>();
            gaPrenotazioneAutoVeicoliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPrenotazioneAutoVeicoloAsync(long id)
        {
            var entity = await gaPrenotazioneAutoVeicoliRepo.GetByIdAsync(id);
            gaPrenotazioneAutoVeicoliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPrenotazioneAutoVeicoloAsync(long id, string descrizione)
        {
            var entity = await gaPrenotazioneAutoVeicoliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPrenotazioneAutoVeicoloAsync(long id)
        {
            var entity = await gaPrenotazioneAutoVeicoliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPrenotazioneAutoVeicoliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPrenotazioneAutoVeicoliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPrenotazioneAutoVeicoli>> GetViewGaPrenotazioneAutoVeicoliAsync(bool all = false)
        {
            var entities = all ? await viewGaPrenotazioneAutoVeicoliRepo.GetAllAsync() : await viewGaPrenotazioneAutoVeicoliRepo.GetAllAsync();
            return entities;
        }
        #endregion

        #endregion

        #region PrenotazioneAutoRegistrazioni
        public async Task<PrenotazioneAutoRegistrazioneDto> GetGaPrenotazioneAutoRegistrazioneByIdAsync(long id)
        {
            var entity = await gaPrenotazioneAutoRegistrazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrenotazioneAutoRegistrazioneDto, PrenotazioneAutoRegistrazione>();
            return dto;
        }

        public async Task<long> AddGaPrenotazioneAutoRegistrazioneAsync(PrenotazioneAutoRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneAutoRegistrazione, PrenotazioneAutoRegistrazioneDto>();
            if (String.IsNullOrEmpty(entity.RealeUtilizzatore)) { entity.RealeUtilizzatore = dto.UserName; }
            await gaPrenotazioneAutoRegistrazioniRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaPrenotazioneAutoRegistrazioneAsync(PrenotazioneAutoRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<PrenotazioneAutoRegistrazione, PrenotazioneAutoRegistrazioneDto>();
            gaPrenotazioneAutoRegistrazioniRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }
        public async Task<bool> DeleteGaPrenotazioneAutoRegistrazioneAsync(long id)
        {
            var entity = await gaPrenotazioneAutoRegistrazioniRepo.GetByIdAsync(id);
            gaPrenotazioneAutoRegistrazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<int> ValidateGaPrenotazioneAutoRegistrazioneAsync(PrenotazioneAutoRegistrazioneDto dto)
        {
            int result = 0;
            var dataInizio = dto.DataInizio.Add(offset);
            var dataFine = dto.DataFine.Add(offset);

            var entities = await gaPrenotazioneAutoRegistrazioniRepo
                .GetWithFilterAsync(x => x.PrenotazioneAutoVeicoloId == dto.PrenotazioneAutoVeicoloId && (dataInizio<=x.DataFine && x.DataInizio<dataFine) && x.Id != dto.Id);

            var veicolo = await gaPrenotazioneAutoVeicoliRepo.GetByIdAsync(dto.PrenotazioneAutoVeicoloId);

            if (entities.Data.Count > 0)
            {
                return -2;
            }

            if (dataInizio > dataFine)
            {
                return -3;
            }

            if (veicolo.Weekend)
            {
                if (dto.DataInizio.DayOfWeek != DayOfWeek.Sunday && dto.DataInizio.DayOfWeek != DayOfWeek.Saturday)
                {
                    return -4;
                }

                if (dto.DataFine.DayOfWeek != DayOfWeek.Sunday && dto.DataFine.DayOfWeek != DayOfWeek.Saturday)
                {
                    return -4;
                }
            }

            return result;
        }
        public async Task<bool> ChangeStatusGaPrenotazioneAutoRegistrazioneAsync(long id)
        {
            var entity = await gaPrenotazioneAutoRegistrazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPrenotazioneAutoRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPrenotazioneAutoRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<ViewGaPrenotazioneAutoRegistrazioni> GetViewGaPrenotazioneAutoRegistrazioniByIdAsync(long id)
        {
            var view = await viewGaPrenotazioneAutoRegistrazioniRepo.GetSingleWithFilter(x => x.Id == id);
            return view;
        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPrenotazioneAutoRegistrazioni>> GetViewGaPrenotazioneAutoRegistrazioniAsync(bool all = false)
        {
            var entities = all ? await viewGaPrenotazioneAutoRegistrazioniRepo.GetAllAsync() : await viewGaPrenotazioneAutoRegistrazioniRepo.GetAllAsync();
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
