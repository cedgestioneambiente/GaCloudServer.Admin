using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaMezziService:IGaMezziService
    {
        protected readonly IGenericRepository<MezziAlimentazione> gaMezziAlimentazioniRepo;
        protected readonly IGenericRepository<MezziCantiere> gaMezziCantieriRepo;
        protected readonly IGenericRepository<MezziClasse> gaMezziClassiRepo;
        protected readonly IGenericRepository<MezziPatente> gaMezziPatentiRepo;
        protected readonly IGenericRepository<MezziPeriodoScadenza> gaMezziPeriodiScadenzeRepo;
        protected readonly IGenericRepository<MezziProprietario> gaMezziProprietariRepo;
        protected readonly IGenericRepository<MezziScadenzaTipo> gaMezziScadenzeTipiRepo;
        protected readonly IGenericRepository<MezziTipo> gaMezziTipiRepo;
        protected readonly IGenericRepository<MezziVeicolo> gaMezziVeicoliRepo;
        protected readonly IGenericRepository<MezziScadenza> gaMezziScadenzeRepo;
        protected readonly IGenericRepository<MezziDocumento> gaMezziDocumentiRepo;


        protected readonly IGenericRepository<ViewGaMezziVeicoli> viewGaMezziVeicoliRepo;
        protected readonly IGenericRepository<ViewGaMezziScadenze> viewGaMezziScadenzeRepo;
        protected readonly IGenericRepository<ViewGaMezziDocumenti> viewGaMezziDocumentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaMezziService(
            IGenericRepository<MezziAlimentazione> gaMezziAlimentazioniRepo,
            IGenericRepository<MezziCantiere> gaMezziCantieriRepo,
            IGenericRepository<MezziClasse> gaMezziClassiRepo,
            IGenericRepository<MezziPatente> gaMezziPatentiRepo,
            IGenericRepository<MezziPeriodoScadenza> gaMezziPeriodiScadenzeRepo,
            IGenericRepository<MezziProprietario> gaMezziProprietariRepo,
            IGenericRepository<MezziScadenzaTipo> gaMezziScadenzeTipiRepo,
            IGenericRepository<MezziTipo> gaMezziTipiRepo,
            IGenericRepository<MezziVeicolo> gaMezziVeicoliRepo,
            IGenericRepository<MezziScadenza> gaMezziScadenzeRepo,
            IGenericRepository<MezziDocumento> gaMezziDocumentiRepo,

            IGenericRepository<ViewGaMezziVeicoli> viewGaMezziVeicoliRepo,
            IGenericRepository<ViewGaMezziScadenze> viewGaMezziScadenzeRepo,
            IGenericRepository<ViewGaMezziDocumenti> viewGaMezziDocumentiRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaMezziAlimentazioniRepo = gaMezziAlimentazioniRepo;
            this.gaMezziCantieriRepo = gaMezziCantieriRepo;
            this.gaMezziClassiRepo = gaMezziClassiRepo;
            this.gaMezziPatentiRepo = gaMezziPatentiRepo;
            this.gaMezziPeriodiScadenzeRepo = gaMezziPeriodiScadenzeRepo;
            this.gaMezziProprietariRepo = gaMezziProprietariRepo;
            this.gaMezziScadenzeTipiRepo = gaMezziScadenzeTipiRepo;
            this.gaMezziTipiRepo = gaMezziTipiRepo;
            this.gaMezziVeicoliRepo = gaMezziVeicoliRepo;
            this.gaMezziScadenzeRepo = gaMezziScadenzeRepo;
            this.gaMezziDocumentiRepo = gaMezziDocumentiRepo;

            this.viewGaMezziVeicoliRepo = viewGaMezziVeicoliRepo;
            this.viewGaMezziDocumentiRepo = viewGaMezziDocumentiRepo;
            this.viewGaMezziScadenzeRepo = viewGaMezziScadenzeRepo;

            this.unitOfWork = unitOfWork;

        }

        #region MezziAlimentazioni
        public async Task<MezziAlimentazioniDto> GetGaMezziAlimentazioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziAlimentazioniRepo.GetAllAsync(page,pageSize);
            var dtos= entities.ToDto<MezziAlimentazioniDto, PagedList<MezziAlimentazione>>();
            return dtos;
        }

        public async Task<MezziAlimentazioneDto> GetGaMezziAlimentazioneByIdAsync(long id)
        {
            var entity = await gaMezziAlimentazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziAlimentazioneDto, MezziAlimentazione>();
            return dto;
        }

        public async Task<long> AddGaMezziAlimentazioneAsync(MezziAlimentazioneDto dto)
        {
            var entity = dto.ToEntity<MezziAlimentazione, MezziAlimentazioneDto>();
            await gaMezziAlimentazioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziAlimentazioneAsync(MezziAlimentazioneDto dto)
        {
            var entity = dto.ToEntity<MezziAlimentazione, MezziAlimentazioneDto>();
            gaMezziAlimentazioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziAlimentazioneAsync(long id)
        {
            var entity = await gaMezziAlimentazioniRepo.GetByIdAsync(id);
            gaMezziAlimentazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziAlimentazioneAsync(long id, string descrizione)
        {
            var entity = await gaMezziAlimentazioniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziAlimentazioneAsync(long id)
        {
            var entity = await gaMezziAlimentazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziAlimentazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziAlimentazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            
        }
        #endregion

        #endregion

        #region MezziCantieri
        public async Task<MezziCantieriDto> GetGaMezziCantieriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziCantieriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziCantieriDto, PagedList<MezziCantiere>>();
            return dtos;
        }

        public async Task<MezziCantiereDto> GetGaMezziCantiereByIdAsync(long id)
        {
            var entity = await gaMezziCantieriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziCantiereDto, MezziCantiere>();
            return dto;
        }

        public async Task<long> AddGaMezziCantiereAsync(MezziCantiereDto dto)
        {
            var entity = dto.ToEntity<MezziCantiere, MezziCantiereDto>();
            await gaMezziCantieriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziCantiereAsync(MezziCantiereDto dto)
        {
            var entity = dto.ToEntity<MezziCantiere, MezziCantiereDto>();
            gaMezziCantieriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziCantiereAsync(long id)
        {
            var entity = await gaMezziCantieriRepo.GetByIdAsync(id);
            gaMezziCantieriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziCantiereAsync(long id, string descrizione)
        {
            var entity = await gaMezziCantieriRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziCantiereAsync(long id)
        {
            var entity = await gaMezziCantieriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziCantieriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziCantieriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region MezziClassi
        public async Task<MezziClassiDto> GetGaMezziClassiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziClassiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziClassiDto, PagedList<MezziClasse>>();
            return dtos;
        }

        public async Task<MezziClasseDto> GetGaMezziClasseByIdAsync(long id)
        {
            var entity = await gaMezziClassiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziClasseDto, MezziClasse>();
            return dto;
        }

        public async Task<long> AddGaMezziClasseAsync(MezziClasseDto dto)
        {
            var entity = dto.ToEntity<MezziClasse, MezziClasseDto>();
            await gaMezziClassiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziClasseAsync(MezziClasseDto dto)
        {
            var entity = dto.ToEntity<MezziClasse, MezziClasseDto>();
            gaMezziClassiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziClasseAsync(long id)
        {
            var entity = await gaMezziClassiRepo.GetByIdAsync(id);
            gaMezziClassiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziClasseAsync(long id, string descrizione)
        {
            var entity = await gaMezziClassiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziClasseAsync(long id)
        {
            var entity = await gaMezziClassiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziClassiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziClassiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region MezziPatenti
        public async Task<MezziPatentiDto> GetGaMezziPatentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziPatentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziPatentiDto, PagedList<MezziPatente>>();
            return dtos;
        }

        public async Task<MezziPatenteDto> GetGaMezziPatenteByIdAsync(long id)
        {
            var entity = await gaMezziPatentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziPatenteDto, MezziPatente>();
            return dto;
        }

        public async Task<long> AddGaMezziPatenteAsync(MezziPatenteDto dto)
        {
            var entity = dto.ToEntity<MezziPatente, MezziPatenteDto>();
            await gaMezziPatentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziPatenteAsync(MezziPatenteDto dto)
        {
            var entity = dto.ToEntity<MezziPatente, MezziPatenteDto>();
            gaMezziPatentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziPatenteAsync(long id)
        {
            var entity = await gaMezziPatentiRepo.GetByIdAsync(id);
            gaMezziPatentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziPatenteAsync(long id, string descrizione)
        {
            var entity = await gaMezziPatentiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziPatenteAsync(long id)
        {
            var entity = await gaMezziPatentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziPatentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziPatentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region MezziPeriodiScadenze
        public async Task<MezziPeriodiScadenzeDto> GetGaMezziPeriodiScadenzeAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziPeriodiScadenzeRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziPeriodiScadenzeDto, PagedList<MezziPeriodoScadenza>>();
            return dtos;
        }

        public async Task<MezziPeriodoScadenzaDto> GetGaMezziPeriodoScadenzaByIdAsync(long id)
        {
            var entity = await gaMezziPeriodiScadenzeRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziPeriodoScadenzaDto, MezziPeriodoScadenza>();
            return dto;
        }

        public async Task<long> AddGaMezziPeriodoScadenzaAsync(MezziPeriodoScadenzaDto dto)
        {
            var entity = dto.ToEntity<MezziPeriodoScadenza, MezziPeriodoScadenzaDto>();
            await gaMezziPeriodiScadenzeRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziPeriodoScadenzaAsync(MezziPeriodoScadenzaDto dto)
        {
            var entity = dto.ToEntity<MezziPeriodoScadenza, MezziPeriodoScadenzaDto>();
            gaMezziPeriodiScadenzeRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziPeriodoScadenzaAsync(long id)
        {
            var entity = await gaMezziPeriodiScadenzeRepo.GetByIdAsync(id);
            gaMezziPeriodiScadenzeRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziPeriodoScadenzaAsync(long id, string descrizione)
        {
            var entity = await gaMezziPeriodiScadenzeRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziPeriodoScadenzaAsync(long id)
        {
            var entity = await gaMezziPeriodiScadenzeRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziPeriodiScadenzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziPeriodiScadenzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region MezziProprietari
        public async Task<MezziProprietariDto> GetGaMezziProprietariAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziProprietariRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziProprietariDto, PagedList<MezziProprietario>>();
            return dtos;
        }

        public async Task<MezziProprietarioDto> GetGaMezziProprietarioByIdAsync(long id)
        {
            var entity = await gaMezziProprietariRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziProprietarioDto, MezziProprietario>();
            return dto;
        }

        public async Task<long> AddGaMezziProprietarioAsync(MezziProprietarioDto dto)
        {
            var entity = dto.ToEntity<MezziProprietario, MezziProprietarioDto>();
            await gaMezziProprietariRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziProprietarioAsync(MezziProprietarioDto dto)
        {
            var entity = dto.ToEntity<MezziProprietario, MezziProprietarioDto>();
            gaMezziProprietariRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziProprietarioAsync(long id)
        {
            var entity = await gaMezziProprietariRepo.GetByIdAsync(id);
            gaMezziProprietariRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziProprietarioAsync(long id, string descrizione)
        {
            var entity = await gaMezziProprietariRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziProprietarioAsync(long id)
        {
            var entity = await gaMezziProprietariRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziProprietariRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziProprietariRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region MezziScadenzeTipi
        public async Task<MezziScadenzeTipiDto> GetGaMezziScadenzeTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziScadenzeTipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziScadenzeTipiDto, PagedList<MezziScadenzaTipo>>();
            return dtos;
        }

        public async Task<MezziScadenzaTipoDto> GetGaMezziScadenzaTipoByIdAsync(long id)
        {
            var entity = await gaMezziScadenzeTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziScadenzaTipoDto, MezziScadenzaTipo>();
            return dto;
        }

        public async Task<long> AddGaMezziScadenzaTipoAsync(MezziScadenzaTipoDto dto)
        {
            var entity = dto.ToEntity<MezziScadenzaTipo, MezziScadenzaTipoDto>();
            await gaMezziScadenzeTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziScadenzaTipoAsync(MezziScadenzaTipoDto dto)
        {
            var entity = dto.ToEntity<MezziScadenzaTipo, MezziScadenzaTipoDto>();
            gaMezziScadenzeTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziScadenzaTipoAsync(long id)
        {
            var entity = await gaMezziScadenzeTipiRepo.GetByIdAsync(id);
            gaMezziScadenzeTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziScadenzaTipoAsync(long id, string descrizione)
        {
            var entity = await gaMezziScadenzeTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziScadenzaTipoAsync(long id)
        {
            var entity = await gaMezziScadenzeTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziScadenzeTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziScadenzeTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region MezziTipi
        public async Task<MezziTipiDto> GetGaMezziTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziTipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziTipiDto, PagedList<MezziTipo>>();
            return dtos;
        }

        public async Task<MezziTipoDto> GetGaMezziTipoByIdAsync(long id)
        {
            var entity = await gaMezziTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziTipoDto, MezziTipo>();
            return dto;
        }

        public async Task<long> AddGaMezziTipoAsync(MezziTipoDto dto)
        {
            var entity = dto.ToEntity<MezziTipo, MezziTipoDto>();
            await gaMezziTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziTipoAsync(MezziTipoDto dto)
        {
            var entity = dto.ToEntity<MezziTipo, MezziTipoDto>();
            gaMezziTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziTipoAsync(long id)
        {
            var entity = await gaMezziTipiRepo.GetByIdAsync(id);
            gaMezziTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziTipoAsync(long id, string descrizione)
        {
            var entity = await gaMezziTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziTipoAsync(long id)
        {
            var entity = await gaMezziTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region MezziVeicoli

        public async Task<MezziVeicoliDto> GetGaMezziVeicoliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaMezziVeicoliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<MezziVeicoliDto, PagedList<MezziVeicolo>>();
            return dtos;
        }

        public async Task<MezziVeicoloDto> GetGaMezziVeicoloByIdAsync(long id)
        {
            var entity = await gaMezziVeicoliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziVeicoloDto, MezziVeicolo>();
            return dto;
        }

        public async Task<long> AddGaMezziVeicoloAsync(MezziVeicoloDto dto)
        {
            var entity = dto.ToEntity<MezziVeicolo, MezziVeicoloDto>();
            await gaMezziVeicoliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaMezziVeicoloAsync(MezziVeicoloDto dto)
        {
            var entity = dto.ToEntity<MezziVeicolo, MezziVeicoloDto>();
            gaMezziVeicoliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziVeicoloAsync(long id)
        {
            var entity = await gaMezziVeicoliRepo.GetByIdAsync(id);
            gaMezziVeicoliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaMezziVeicoloAsync(long id, string targa)
        {
            var entity = await gaMezziVeicoliRepo.GetWithFilterAsync(x => x.Targa == targa && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaMezziVeicoloAsync(long id)
        {
            var entity = await gaMezziVeicoliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziVeicoliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziVeicoliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaMezziVeicoli>> GetViewGaMezziVeicoliAsync(bool all = true)
        {
            var entities = all ? await viewGaMezziVeicoliRepo.GetAllAsync(1, 0) : await viewGaMezziVeicoliRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region MezziScadenze
        public async Task<MezziScadenzeDto> GetGaMezziScadenzeByVeicoloIdAsync(long mezziVeicoloId)
        {
            var entities = await gaMezziScadenzeRepo.GetWithFilterAsync(x => x.MezziVeicoloId == mezziVeicoloId);
            var dtos = entities.ToDto<MezziScadenzeDto, PagedList<MezziScadenza>>();
            return dtos;
        }

        public async Task<MezziScadenzaDto> GetGaMezziScadenzaByIdAsync(long id)
        {
            var entity = await gaMezziScadenzeRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziScadenzaDto, MezziScadenza>();
            return dto;
        }

        public async Task<long> AddGaMezziScadenzaAsync(MezziScadenzaDto dto)
        {
            var entity = dto.ToEntity<MezziScadenza, MezziScadenzaDto>();
            await gaMezziScadenzeRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaMezziScadenzaAsync(MezziScadenzaDto dto)
        {
            var entity = dto.ToEntity<MezziScadenza, MezziScadenzaDto>();
            gaMezziScadenzeRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziScadenzaAsync(long id)
        {
            var entity = await gaMezziScadenzeRepo.GetByIdAsync(id);
            gaMezziScadenzeRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ChangeStatusGaMezziScadenzaAsync(long id)
        {
            var entity = await gaMezziScadenzeRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziScadenzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziScadenzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaMezziScadenze>> GetViewGaMezziScadenzeAsync(bool all=false)
        {
            var entities = all? await viewGaMezziScadenzeRepo.GetAllAsync():await viewGaMezziScadenzeRepo.GetWithFilterAsync(x=>x.Dismesso==false);
            return entities;
        }
        public async Task<PagedList<ViewGaMezziScadenze>> GetViewGaMezziScadenzeByVeicoloIdAsync(long mezziVeicoloId)
        {
            var entities =await viewGaMezziScadenzeRepo.GetWithFilterAsync(x => x.MezziVeicoloId == mezziVeicoloId);
            return entities;
        }
        #endregion

        #endregion

        #region MezziDocumenti
        public async Task<MezziDocumentiDto> GetGaMezziDocumentiByVeicoloIdAsync(long mezziVeicoloId)
        {
            var entities = await gaMezziDocumentiRepo.GetWithFilterAsync(x => x.MezziVeicoloId == mezziVeicoloId);
            var dtos = entities.ToDto<MezziDocumentiDto, PagedList<MezziDocumento>>();
            return dtos;
        }

        public async Task<MezziDocumentoDto> GetGaMezziDocumentoByIdAsync(long id)
        {
            var entity = await gaMezziDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<MezziDocumentoDto, MezziDocumento>();
            return dto;
        }

        public async Task<long> AddGaMezziDocumentoAsync(MezziDocumentoDto dto)
        {
            var entity = dto.ToEntity<MezziDocumento, MezziDocumentoDto>();
            await gaMezziDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaMezziDocumentoAsync(MezziDocumentoDto dto)
        {
            var entity = dto.ToEntity<MezziDocumento, MezziDocumentoDto>();
            gaMezziDocumentiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaMezziDocumentoAsync(long id)
        {
            var entity = await gaMezziDocumentiRepo.GetByIdAsync(id);
            gaMezziDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ChangeStatusGaMezziDocumentoAsync(long id)
        {
            var entity = await gaMezziDocumentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaMezziDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaMezziDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaMezziDocumenti>> GetViewGaMezziDocumentiByVeicoloIdAsync(long mezziVeicoloId)
        {
            var entities = await viewGaMezziDocumentiRepo.GetWithFilterAsync(x => x.MezziVeicoloId == mezziVeicoloId);
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
