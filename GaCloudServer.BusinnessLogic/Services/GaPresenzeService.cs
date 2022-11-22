using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPresenzeService : IGaPresenzeService
    {
        protected readonly IGenericRepository<PresenzeStatoRichiesta> gaPresenzeStatiRichiesteRepo;
        protected readonly IGenericRepository<PresenzeRichiesta> gaPresenzeRichiesteRepo;
        protected readonly IGenericRepository<PresenzeTipoOra> gaPresenzeTipiOreRepo;
        protected readonly IGenericRepository<PresenzeResponsabile> gaPresenzeResponsabiliRepo;
        protected readonly IGenericRepository<PresenzeResponsabileOnSettore> gaPresenzeResponsabiliOnSettoriRepo;
        protected readonly IGenericRepository<PresenzeProfilo> gaPresenzeProfiliRepo;
        protected readonly IGenericRepository<PresenzeDipendente> gaPresenzeDipendentiRepo;
        protected readonly IGenericRepository<PresenzeDataEsclusa> gaPresenzeDateEscluseRepo;
        protected readonly IGenericRepository<PresenzeOrario> gaPresenzeOrariRepo;
        protected readonly IGenericRepository<PresenzeOrarioGiornata> gaPresenzeOrariGiornateRepo;
        protected readonly IGenericRepository<PresenzeBancaOraUtilizzo> gaPresenzeBancheOreUtilizziRepo;




        protected readonly IUnitOfWork unitOfWork;

        public GaPresenzeService(
            IGenericRepository<PresenzeStatoRichiesta> gaPresenzeStatiRichiesteRepo,
            IGenericRepository<PresenzeRichiesta> gaPresenzeRichiesteRepo,
            IGenericRepository<PresenzeTipoOra> gaPresenzeTipiOreRepo,
            IGenericRepository<PresenzeResponsabile> gaPresenzeResponsabiliRepo,
            IGenericRepository<PresenzeResponsabileOnSettore> gaPresenzeResponsabiliOnSettoriRepo,
            IGenericRepository<PresenzeProfilo> gaPresenzeProfiliRepo,
            IGenericRepository<PresenzeDipendente> gaPresenzeDipendentiRepo,
            IGenericRepository<PresenzeDataEsclusa> gaPresenzeDateEscluseRepo,
            IGenericRepository<PresenzeOrario> gaPresenzeOrariRepo,
            IGenericRepository<PresenzeOrarioGiornata> gaPresenzeOrariGiornateRepo,
            IGenericRepository<PresenzeBancaOraUtilizzo> gaPresenzeBancheOreUtilizziRepo,



        IUnitOfWork unitOfWork)
        {
            this.gaPresenzeStatiRichiesteRepo = gaPresenzeStatiRichiesteRepo;
            this.gaPresenzeRichiesteRepo = gaPresenzeRichiesteRepo;
            this.gaPresenzeTipiOreRepo = gaPresenzeTipiOreRepo;
            this.gaPresenzeResponsabiliRepo = gaPresenzeResponsabiliRepo;
            this.gaPresenzeResponsabiliOnSettoriRepo = gaPresenzeResponsabiliOnSettoriRepo;
            this.gaPresenzeProfiliRepo = gaPresenzeProfiliRepo;
            this.gaPresenzeDipendentiRepo = gaPresenzeDipendentiRepo;
            this.gaPresenzeDateEscluseRepo = gaPresenzeDateEscluseRepo;
            this.gaPresenzeOrariRepo = gaPresenzeOrariRepo;
            this.gaPresenzeOrariGiornateRepo = gaPresenzeOrariGiornateRepo;
            this.gaPresenzeBancheOreUtilizziRepo = gaPresenzeBancheOreUtilizziRepo;


            this.unitOfWork = unitOfWork;

        }

        #region PresenzeStatiRichieste
        public async Task<PresenzeStatiRichiesteDto> GetGaPresenzeStatiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeStatiRichiesteRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeStatiRichiesteDto, PagedList<PresenzeStatoRichiesta>>();
            return dtos;
        }

        public async Task<PresenzeStatoRichiestaDto> GetGaPresenzeStatoRichiestaByIdAsync(long id)
        {
            var entity = await gaPresenzeStatiRichiesteRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeStatoRichiestaDto, PresenzeStatoRichiesta>();
            return dto;
        }

        public async Task<long> AddGaPresenzeStatoRichiestaAsync(PresenzeStatoRichiestaDto dto)
        {
            var entity = dto.ToEntity<PresenzeStatoRichiesta, PresenzeStatoRichiestaDto>();
            await gaPresenzeStatiRichiesteRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeStatoRichiestaAsync(PresenzeStatoRichiestaDto dto)
        {
            var entity = dto.ToEntity<PresenzeStatoRichiesta, PresenzeStatoRichiestaDto>();
            gaPresenzeStatiRichiesteRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeStatoRichiestaAsync(long id)
        {
            var entity = await gaPresenzeStatiRichiesteRepo.GetByIdAsync(id);
            gaPresenzeStatiRichiesteRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPresenzeStatoRichiestaAsync(long id, string descrizione)
        {
            var entity = await gaPresenzeStatiRichiesteRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPresenzeStatoRichiestaAsync(long id)
        {
            var entity = await gaPresenzeStatiRichiesteRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeStatiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeStatiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeRichieste
        public async Task<PresenzeRichiesteDto> GetGaPresenzeRichiesteAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeRichiesteRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeRichiesteDto, PagedList<PresenzeRichiesta>>();
            return dtos;
        }

        public async Task<PresenzeRichiestaDto> GetGaPresenzeRichiestaByIdAsync(long id)
        {
            var entity = await gaPresenzeRichiesteRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeRichiestaDto, PresenzeRichiesta>();
            return dto;
        }

        public async Task<long> AddGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto)
        {
            var entity = dto.ToEntity<PresenzeRichiesta, PresenzeRichiestaDto>();
            var approvazioneAutomatica = gaPresenzeTipiOreRepo.GetByIdAsync(entity.PresenzeTipoOraId).Result.ApprovazioneAutomatica;
            if (approvazioneAutomatica && entity.PresenzeStatoRichiestaId != 3)
            {
                entity.PresenzeStatoRichiestaId = 2;
            }
            await gaPresenzeRichiesteRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto)
        {
            var original = gaPresenzeRichiesteRepo.GetByIdAsNoTraking(x => x.Id == dto.Id);
            var entity = dto.ToEntity<PresenzeRichiesta, PresenzeRichiestaDto>();

            var approvazioneAutomatica = gaPresenzeTipiOreRepo.GetByIdAsync(entity.PresenzeTipoOraId).Result.ApprovazioneAutomatica;
            if (approvazioneAutomatica && entity.PresenzeStatoRichiestaId != 3)
            {
                entity.PresenzeStatoRichiestaId = 2;
            }
            gaPresenzeRichiesteRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeRichiestaAsync(long id)
        {
            var entity = await gaPresenzeRichiesteRepo.GetByIdAsync(id);
            gaPresenzeRichiesteRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto)
        {
            var entity = await gaPresenzeRichiesteRepo.GetWithFilterAsync(x => x.PresenzeDipendenteId == dto.PresenzeDipendenteId && (dto.DataInizio <= x.DataFine && x.DataInizio < dto.DataFine) && x.Id != dto.Id, 1, 0);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPresenzeRichiestaAsync(long id)
        {
            var entity = await gaPresenzeRichiesteRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeTipiOre
        public async Task<PresenzeTipiOreDto> GetGaPresenzeTipiOreAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeTipiOreRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeTipiOreDto, PagedList<PresenzeTipoOra>>();
            return dtos;
        }

        public async Task<PresenzeTipoOraDto> GetGaPresenzeTipoOraByIdAsync(long id)
        {
            var entity = await gaPresenzeTipiOreRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeTipoOraDto, PresenzeTipoOra>();
            return dto;
        }

        public async Task<long> AddGaPresenzeTipoOraAsync(PresenzeTipoOraDto dto)
        {
            var entity = dto.ToEntity<PresenzeTipoOra, PresenzeTipoOraDto>();
            await gaPresenzeTipiOreRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeTipoOraAsync(PresenzeTipoOraDto dto)
        {
            var entity = dto.ToEntity<PresenzeTipoOra, PresenzeTipoOraDto>();
            gaPresenzeTipiOreRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeTipoOraAsync(long id)
        {
            var entity = await gaPresenzeTipiOreRepo.GetByIdAsync(id);
            gaPresenzeTipiOreRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPresenzeTipoOraAsync(long id, string descrizione)
        {
            var entity = await gaPresenzeTipiOreRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPresenzeTipoOraAsync(long id)
        {
            var entity = await gaPresenzeTipiOreRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeTipiOreRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeTipiOreRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeResponsabili
        public async Task<PresenzeResponsabiliDto> GetGaPresenzeResponsabiliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeResponsabiliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeResponsabiliDto, PagedList<PresenzeResponsabile>>();
            return dtos;
        }

        public async Task<PresenzeResponsabileDto> GetGaPresenzeResponsabileByIdAsync(long id)
        {
            var entity = await gaPresenzeResponsabiliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeResponsabileDto, PresenzeResponsabile>();
            return dto;
        }

        public async Task<long> AddGaPresenzeResponsabileAsync(PresenzeResponsabileDto dto)
        {
            var entity = dto.ToEntity<PresenzeResponsabile, PresenzeResponsabileDto>();
            await gaPresenzeResponsabiliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeResponsabileAsync(PresenzeResponsabileDto dto)
        {
            var entity = dto.ToEntity<PresenzeResponsabile, PresenzeResponsabileDto>();
            gaPresenzeResponsabiliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeResponsabileAsync(long id)
        {
            var entity = await gaPresenzeResponsabiliRepo.GetByIdAsync(id);
            gaPresenzeResponsabiliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPresenzeResponsabileAsync(long id, long personaleDipendenteId)
        {
            var entity = await gaPresenzeResponsabiliRepo.GetWithFilterAsync(x => x.PersonaleDipendenteId == personaleDipendenteId && x.Id != id, 1, 0);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPresenzeResponsabileAsync(long id)
        {
            var entity = await gaPresenzeResponsabiliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeResponsabiliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeResponsabiliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeResponsabiliOnSettori

        public async Task<long> UpdateGaPresenzeResponsabileOnSettoreAsync(PresenzeResponsabileOnSettoreDto dto)
        {
            var entity = dto.ToEntity<PresenzeResponsabileOnSettore, PresenzeResponsabileOnSettoreDto>();
            gaPresenzeResponsabiliOnSettoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        #endregion

        #region PresenzeProfili
        public async Task<PresenzeProfiliDto> GetGaPresenzeProfiliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeProfiliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeProfiliDto, PagedList<PresenzeProfilo>>();
            return dtos;
        }

        public async Task<PresenzeProfiloDto> GetGaPresenzeProfiloByIdAsync(long id)
        {
            var entity = await gaPresenzeProfiliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeProfiloDto, PresenzeProfilo>();
            return dto;
        }

        public async Task<long> AddGaPresenzeProfiloAsync(PresenzeProfiloDto dto)
        {
            var entity = dto.ToEntity<PresenzeProfilo, PresenzeProfiloDto>();
            await gaPresenzeProfiliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeProfiloAsync(PresenzeProfiloDto dto)
        {
            var entity = dto.ToEntity<PresenzeProfilo, PresenzeProfiloDto>();
            gaPresenzeProfiliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeProfiloAsync(long id)
        {
            var entity = await gaPresenzeProfiliRepo.GetByIdAsync(id);
            gaPresenzeProfiliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPresenzeProfiloAsync(long id, string descrizione)
        {
            var entity = await gaPresenzeProfiliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPresenzeProfiloAsync(long id)
        {
            var entity = await gaPresenzeProfiliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeProfiliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeProfiliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeDipendenti
        public async Task<PresenzeDipendentiDto> GetGaPresenzeDipendentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeDipendentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeDipendentiDto, PagedList<PresenzeDipendente>>();
            return dtos;
        }

        public async Task<PresenzeDipendenteDto> GetGaPresenzeDipendenteByIdAsync(long id)
        {
            var entity = await gaPresenzeDipendentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeDipendenteDto, PresenzeDipendente>();
            return dto;
        }

        public async Task<long> AddGaPresenzeDipendenteAsync(PresenzeDipendenteDto dto)
        {
            var entity = dto.ToEntity<PresenzeDipendente, PresenzeDipendenteDto>();
            await gaPresenzeDipendentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeDipendenteAsync(PresenzeDipendenteDto dto)
        {
            var entity = dto.ToEntity<PresenzeDipendente, PresenzeDipendenteDto>();
            gaPresenzeDipendentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeDipendenteAsync(long id)
        {
            var entity = await gaPresenzeDipendentiRepo.GetByIdAsync(id);
            gaPresenzeDipendentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPresenzeDipendenteAsync(long id, string matricola)
        {
            var entity = await gaPresenzeDipendentiRepo.GetWithFilterAsync(x => x.Matricola == matricola && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPresenzeDipendenteAsync(long id)
        {
            var entity = await gaPresenzeDipendentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeDipendentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeDipendentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeDateEscluse
        public async Task<PresenzeDateEscluseDto> GetGaPresenzeDateEscluseAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeDateEscluseRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeDateEscluseDto, PagedList<PresenzeDataEsclusa>>();
            return dtos;
        }

        public async Task<PresenzeDataEsclusaDto> GetGaPresenzeDataEsclusaByIdAsync(long id)
        {
            var entity = await gaPresenzeDateEscluseRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeDataEsclusaDto, PresenzeDataEsclusa>();
            return dto;
        }

        public async Task<long> AddGaPresenzeDataEsclusaAsync(PresenzeDataEsclusaDto dto)
        {
            var entity = dto.ToEntity<PresenzeDataEsclusa, PresenzeDataEsclusaDto>();
            await gaPresenzeDateEscluseRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeDataEsclusaAsync(PresenzeDataEsclusaDto dto)
        {
            var entity = dto.ToEntity<PresenzeDataEsclusa, PresenzeDataEsclusaDto>();
            gaPresenzeDateEscluseRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeDataEsclusaAsync(long id)
        {
            var entity = await gaPresenzeDateEscluseRepo.GetByIdAsync(id);
            gaPresenzeDateEscluseRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        public async Task<bool> ChangeStatusGaPresenzeDataEsclusaAsync(long id)
        {
            var entity = await gaPresenzeDateEscluseRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeDateEscluseRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeDateEscluseRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeOrari
        public async Task<PresenzeOrariDto> GetGaPresenzeOrariAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeOrariRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeOrariDto, PagedList<PresenzeOrario>>();
            return dtos;
        }

        public async Task<PresenzeOrarioDto> GetGaPresenzeOrarioByIdAsync(long id)
        {
            var entity = await gaPresenzeOrariRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeOrarioDto, PresenzeOrario>();
            return dto;
        }

        public async Task<long> AddGaPresenzeOrarioAsync(PresenzeOrarioDto dto)
        {
            var entity = dto.ToEntity<PresenzeOrario, PresenzeOrarioDto>();
            await gaPresenzeOrariRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeOrarioAsync(PresenzeOrarioDto dto)
        {
            var entity = dto.ToEntity<PresenzeOrario, PresenzeOrarioDto>();
            gaPresenzeOrariRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeOrarioAsync(long id)
        {
            var entity = await gaPresenzeOrariRepo.GetByIdAsync(id);
            gaPresenzeOrariRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPresenzeOrarioAsync(long id, string descrizione)
        {
            var entity = await gaPresenzeOrariRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPresenzeOrarioAsync(long id)
        {
            var entity = await gaPresenzeOrariRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeOrariRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeOrariRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeOrariGiornate
        public async Task<PresenzeOrariGiornateDto> GetGaPresenzeOrariGiornateAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeOrariGiornateRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeOrariGiornateDto, PagedList<PresenzeOrarioGiornata>>();
            return dtos;
        }

        public async Task<PresenzeOrarioGiornataDto> GetGaPresenzeOrarioGiornataByIdAsync(long id)
        {
            var entity = await gaPresenzeOrariGiornateRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeOrarioGiornataDto, PresenzeOrarioGiornata>();
            return dto;
        }

        public async Task<long> AddGaPresenzeOrarioGiornataAsync(PresenzeOrarioGiornataDto dto)
        {
            var entity = dto.ToEntity<PresenzeOrarioGiornata, PresenzeOrarioGiornataDto>();
            await gaPresenzeOrariGiornateRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeOrarioGiornataAsync(PresenzeOrarioGiornataDto dto)
        {
            var entity = dto.ToEntity<PresenzeOrarioGiornata, PresenzeOrarioGiornataDto>();
            gaPresenzeOrariGiornateRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeOrarioGiornataAsync(long id)
        {
            var entity = await gaPresenzeOrariGiornateRepo.GetByIdAsync(id);
            gaPresenzeOrariGiornateRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        public async Task<bool> ChangeStatusGaPresenzeOrarioGiornataAsync(long id)
        {
            var entity = await gaPresenzeOrariGiornateRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeOrariGiornateRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeOrariGiornateRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PresenzeBancheOreUtilizzi
        public async Task<PresenzeBancheOreUtilizziDto> GetGaPresenzeBancheOreUtilizziAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPresenzeBancheOreUtilizziRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PresenzeBancheOreUtilizziDto, PagedList<PresenzeBancaOraUtilizzo>>();
            return dtos;
        }

        public async Task<PresenzeBancaOraUtilizzoDto> GetGaPresenzeBancaOraUtilizzoByIdAsync(long id)
        {
            var entity = await gaPresenzeBancheOreUtilizziRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PresenzeBancaOraUtilizzoDto, PresenzeBancaOraUtilizzo>();
            return dto;
        }

        public async Task<long> AddGaPresenzeBancaOraUtilizzoAsync(PresenzeBancaOraUtilizzoDto dto)
        {
            var entity = dto.ToEntity<PresenzeBancaOraUtilizzo, PresenzeBancaOraUtilizzoDto>();
            await gaPresenzeBancheOreUtilizziRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPresenzeBancaOraUtilizzoAsync(PresenzeBancaOraUtilizzoDto dto)
        {
            var entity = dto.ToEntity<PresenzeBancaOraUtilizzo, PresenzeBancaOraUtilizzoDto>();
            gaPresenzeBancheOreUtilizziRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPresenzeBancaOraUtilizzoAsync(long id)
        {
            var entity = await gaPresenzeBancheOreUtilizziRepo.GetByIdAsync(id);
            gaPresenzeBancheOreUtilizziRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        public async Task<bool> ChangeStatusGaPresenzeBancaOraUtilizzoAsync(long id)
        {
            var entity = await gaPresenzeBancheOreUtilizziRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPresenzeBancheOreUtilizziRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPresenzeBancheOreUtilizziRepo.Update(entity);
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


