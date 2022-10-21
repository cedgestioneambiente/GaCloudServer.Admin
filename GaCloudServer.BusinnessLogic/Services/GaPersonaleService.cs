using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPersonaleService : IGaPersonaleService
    {
        protected readonly IGenericRepository<PersonaleQualifica> gaPersonaleQualificheRepo;
        protected readonly IGenericRepository<PersonaleAssunzione> gaPersonaleAssunzioniRepo;
        protected readonly IGenericRepository<PersonaleDipendente> gaPersonaleDipendentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaPersonaleService(
            IGenericRepository<PersonaleQualifica> gaPersonaleQualificheRepo,
            IGenericRepository<PersonaleAssunzione> gaPersonaleAssunzioniRepo,
            IGenericRepository<PersonaleDipendente> gaPersonaleDipendentiRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaPersonaleQualificheRepo = gaPersonaleQualificheRepo;
            this.gaPersonaleAssunzioniRepo = gaPersonaleAssunzioniRepo;
            this.gaPersonaleDipendentiRepo = gaPersonaleDipendentiRepo;

            this.unitOfWork = unitOfWork;

        }

        #region PersonaleQualifiche
        public async Task<PersonaleQualificheDto> GetGaPersonaleQualificheAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleQualificheRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleQualificheDto, PagedList<PersonaleQualifica>>();
            return dtos;
        }

        public async Task<PersonaleQualificaDto> GetGaPersonaleQualificaByIdAsync(long id)
        {
            var entity = await gaPersonaleQualificheRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleQualificaDto, PersonaleQualifica>();
            return dto;
        }

        public async Task<long> AddGaPersonaleQualificaAsync(PersonaleQualificaDto dto)
        {
            var entity = dto.ToEntity<PersonaleQualifica, PersonaleQualificaDto>();
            await gaPersonaleQualificheRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleQualificaAsync(PersonaleQualificaDto dto)
        {
            var entity = dto.ToEntity<PersonaleQualifica, PersonaleQualificaDto>();
            gaPersonaleQualificheRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleQualificaAsync(long id)
        {
            var entity = await gaPersonaleQualificheRepo.GetByIdAsync(id);
            gaPersonaleQualificheRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleQualificaAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleQualificheRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleQualificaAsync(long id)
        {
            var entity = await gaPersonaleQualificheRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleQualificheRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleQualificheRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleAssunzioni
        public async Task<PersonaleAssunzioniDto> GetGaPersonaleAssunzioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleAssunzioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleAssunzioniDto, PagedList<PersonaleAssunzione>>();
            return dtos;
        }

        public async Task<PersonaleAssunzioneDto> GetGaPersonaleAssunzioneByIdAsync(long id)
        {
            var entity = await gaPersonaleAssunzioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleAssunzioneDto, PersonaleAssunzione>();
            return dto;
        }

        public async Task<long> AddGaPersonaleAssunzioneAsync(PersonaleAssunzioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleAssunzione, PersonaleAssunzioneDto>();
            await gaPersonaleAssunzioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleAssunzioneAsync(PersonaleAssunzioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleAssunzione, PersonaleAssunzioneDto>();
            gaPersonaleAssunzioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleAssunzioneAsync(long id)
        {
            var entity = await gaPersonaleAssunzioniRepo.GetByIdAsync(id);
            gaPersonaleAssunzioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleAssunzioneAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleAssunzioniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleAssunzioneAsync(long id)
        {
            var entity = await gaPersonaleAssunzioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleAssunzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleAssunzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleDipendenti
        public async Task<PersonaleDipendentiDto> GetGaPersonaleDipendentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleDipendentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleDipendentiDto, PagedList<PersonaleDipendente>>();
            return dtos;
        }

        public async Task<PersonaleDipendenteDto> GetGaPersonaleDipendenteByIdAsync(long id)
        {
            var entity = await gaPersonaleDipendentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleDipendenteDto, PersonaleDipendente>();
            return dto;
        }

        public async Task<long> AddGaPersonaleDipendenteAsync(PersonaleDipendenteDto dto)
        {
            var entity = dto.ToEntity<PersonaleDipendente, PersonaleDipendenteDto>();
            await gaPersonaleDipendentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleDipendenteAsync(PersonaleDipendenteDto dto)
        {
            var entity = dto.ToEntity<PersonaleDipendente, PersonaleDipendenteDto>();
            gaPersonaleDipendentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleDipendenteAsync(long id)
        {
            var entity = await gaPersonaleDipendentiRepo.GetByIdAsync(id);
            gaPersonaleDipendentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleDipendenteAsync(long id, string userId)
        {
            var entity = await gaPersonaleDipendentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleDipendenteAsync(long id)
        {
            var entity = await gaPersonaleDipendentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleDipendentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleDipendentiRepo.Update(entity);
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

