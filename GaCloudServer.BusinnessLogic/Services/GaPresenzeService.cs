using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Presenze.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Models;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using static GaCloudServer.BusinnessLogic.Extensions.MiscExtensions;

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

        protected readonly IGenericRepository<ViewGaPresenzeResponsabili> viewGaPresenzeResponsabiliRepo;
        protected readonly IGenericRepository<ViewGaPresenzeResponsabiliOnSettori> viewGaPresenzeResponsabiliOnSettoriRepo;
        protected readonly IGenericRepository<ViewGaPresenzeDipendenti> viewGaPresenzeDipendentiRepo;
        protected readonly IGenericRepository<ViewGaPresenzeOrariGiornate> viewGaPresenzeOrariGiornateRepo;
        protected readonly IGenericRepository<ViewGaPresenzeRichieste> viewGaPresenzeRichiesteRepo;
        protected readonly IGenericRepository<ViewGaPresenzeRichiestaMail> viewGaPresenzeRichiestaMailRepo;

        protected readonly IGenericRepository<GlobalSettore> globalSettoriRepo;


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

            IGenericRepository<ViewGaPresenzeResponsabili> viewGaPresenzeResponsabiliRepo,
            IGenericRepository<ViewGaPresenzeResponsabiliOnSettori> viewGaPresenzeResponsabiliOnSettoriRepo,
            IGenericRepository<ViewGaPresenzeDipendenti> viewGaPresenzeDipendentiRepo,
            IGenericRepository<ViewGaPresenzeOrariGiornate> viewGaPresenzeOrariGiornateRepo,
            IGenericRepository<ViewGaPresenzeRichieste> viewGaPresenzeRichiesteRepo,
            IGenericRepository<ViewGaPresenzeRichiestaMail> viewGaPresenzeRichiestaMailRepo,

            IGenericRepository<GlobalSettore> globalSettoriRepo,

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

            this.viewGaPresenzeResponsabiliRepo = viewGaPresenzeResponsabiliRepo;
            this.viewGaPresenzeResponsabiliOnSettoriRepo = viewGaPresenzeResponsabiliOnSettoriRepo;
            this.viewGaPresenzeDipendentiRepo = viewGaPresenzeDipendentiRepo;
            this.viewGaPresenzeOrariGiornateRepo = viewGaPresenzeOrariGiornateRepo;
            this.viewGaPresenzeRichiesteRepo = viewGaPresenzeRichiesteRepo;
            this.viewGaPresenzeRichiestaMailRepo = viewGaPresenzeRichiestaMailRepo;

            this.globalSettoriRepo = globalSettoriRepo;


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
                entity.PresenzeStatoRichiestaId = 1;
            }
            await gaPresenzeRichiesteRepo.AddAsync(entity);
            await SaveChanges();

            if (await ManageBancaOre(entity))
            {
                return entity.Id;
            }
            else
            {
                gaPresenzeRichiesteRepo.Remove(entity);
                await SaveChanges();
                return -1;
            }
        }

        public async Task<long> UpdateGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto)
        {
            var original = gaPresenzeRichiesteRepo.GetByIdAsNoTraking(x => x.Id == dto.Id);
            var entity = dto.ToEntity<PresenzeRichiesta, PresenzeRichiestaDto>();

            var approvazioneAutomatica = gaPresenzeTipiOreRepo.GetByIdAsync(entity.PresenzeTipoOraId).Result.ApprovazioneAutomatica;
            if (approvazioneAutomatica && entity.PresenzeStatoRichiestaId != 3)
            {
                entity.PresenzeStatoRichiestaId = 1;
            }
            gaPresenzeRichiesteRepo.Update(entity);
            await SaveChanges();

            if (await ManageBancaOre(entity))
            {
                return entity.Id;
            }
            else
            {
                gaPresenzeRichiesteRepo.Remove(entity);
                await SaveChanges();
                return -1;
            }
        }

        public async Task<bool> DeleteGaPresenzeRichiestaAsync(long id)
        {
            var entity = await gaPresenzeRichiesteRepo.GetByIdAsync(id);
            if (await ManageDeleteBancaOre(entity))
            {
                gaPresenzeRichiesteRepo.Remove(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Functions
        public async Task<int> ValidateGaPresenzeRichiestaAsync(PresenzeRichiestaValidateDto dto)
        {
            var entities = await gaPresenzeRichiesteRepo.GetWithFilterAsync(x => x.PresenzeDipendenteId == dto.richiesta.PresenzeDipendenteId && (dto.richiesta.DataInizio <= x.DataFine && x.DataInizio < dto.richiesta.DataFine) && x.Id != dto.richiesta.Id, 1, 0);
            var dipendente = await viewGaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.UserId == dto.UserId);
            var bancaOre = gaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.Id == dto.richiesta.PresenzeDipendenteId).Result.BancaOre;

            if (entities.Data.Count > 0)
            {
                return -1;
            }

            if (dto.richiesta.DataInizio > dto.richiesta.DataFine)
            {
                return -2;
            }

            if (!dto.IsAdmin && !dto.profiloUtente.SuperUser)
            {

                if (dto.richiesta.PresenzeDipendenteId == dipendente.Id && dto.richiesta.PresenzeStatoRichiestaId != 2 && !dto.profiloUtente.AutoApprova)
                {
                    return -3;
                }
            }

            if (bancaOre)
            {
                var validateBancaOre = await ValidateBancaOre(dto.richiesta);
                if (!validateBancaOre) { return -4; }
            }


            return 0;
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

        #region Views
        public async Task<PagedList<ViewGaPresenzeRichieste>> GetGaViewPresenzeRichiesteBySettoreIdAsync(long globalSettoreId)
        {
            var view = await viewGaPresenzeRichiesteRepo.GetWithFilterAsync(x => x.SettoreId == globalSettoreId);
            return view;
        }

        public async Task<ViewGaPresenzeRichiestaMail> GetViewGaPresenzeRichiestaMailByIdAsync(long id)
        {
            var view = await viewGaPresenzeRichiestaMailRepo.GetSingleWithFilter(x => x.Id == id);
            return view;
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

        #region Views
        public async Task<PagedList<ViewGaPresenzeResponsabili>> GetViewGaPresenzeResponsabiliAsync(bool all = true)
        {
            var view = all ? await viewGaPresenzeResponsabiliRepo.GetAllAsync(1, 0) : await viewGaPresenzeResponsabiliRepo.GetWithFilterAsync(x => x.Disabled == all);
            return view;
        }


        #endregion

        #endregion

        #region PresenzeResponsabiliOnSettori

        public async Task<bool> UpdateGaPresenzeResponsabileOnSettoreAsync(long responsabileId, long settoreId)
        {
            var entities = await gaPresenzeResponsabiliOnSettoriRepo.GetWithFilterAsync(x => x.PresenzeResponsabileId == responsabileId && x.GlobalSettoreId == settoreId);
            if (entities.Data.Count > 0)
            {
                var entity = entities.Data[0];
                gaPresenzeResponsabiliOnSettoriRepo.Remove(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                var entity = new PresenzeResponsabileOnSettore();
                entity.Id = 0;
                entity.PresenzeResponsabileId = responsabileId;
                entity.GlobalSettoreId = settoreId;
                entity.Disabled = false;
                await gaPresenzeResponsabiliOnSettoriRepo.AddAsync(entity);
                await SaveChanges();
                return true;
            }

        }

        #region Views
        public async Task<PagedList<ViewGaPresenzeResponsabiliOnSettori>> GetViewGaPresenzeResponsabiliOnSettoriByDipendenteAsync(long personaleDipendenteId)
        {
            var view = await viewGaPresenzeResponsabiliOnSettoriRepo.GetWithFilterAsync(x => x.Id == personaleDipendenteId, 1, 0, "Settore");
            return view;
        }

        public async Task<PagedList<ViewGaPresenzeResponsabiliOnSettori>> GetViewGaPresenzeResponsabiliOnSettoreMailBySettoreId(long settoreId)
        {
            var view = await viewGaPresenzeResponsabiliOnSettoriRepo.GetWithFilterAsync(x => x.GlobalIdSettore == settoreId && x.Abilitato==true);
            return view;
        }
        #endregion

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

        public async Task<bool> ChangeStatusGaPresenzeDipendenteAsync(long id,long personaleDipendenteId)
        {
            if (id == 0)
            {
                var entity = new PresenzeDipendente();
                entity.Id = 0;
                entity.PersonaleDipendenteId = personaleDipendenteId;
                entity.PresenzeOrarioId = 1;
                entity.PresenzeProfiloId = 1;
                entity.HhFerie = 190;
                entity.HhPermessiCcnl = 0;
                entity.HhRecupero = 0;
                entity.Disabled = false;

                await gaPresenzeDipendentiRepo.AddAsync(entity);
                await SaveChanges();
                return true;


            }
            else
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

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPresenzeDipendenti>> GetViewGaPresenzeDipendentiBySettoreIdAsync(long globalSettoreId)
        {
            var view = globalSettoreId==0 ? await viewGaPresenzeDipendentiRepo.GetAllAsync(1, 0) : await viewGaPresenzeDipendentiRepo.GetWithFilterAsync(x => x.SettoreId == globalSettoreId);
            return view;
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
        public async Task<bool> ValidateGaPresenzeOrarioGiornataAsync(long id,long orarioId, int giorno)
        {

            var entity = await gaPresenzeOrariGiornateRepo.GetWithFilterAsync(x => x.PresenzeOrarioId==orarioId && x.Giorno == giorno && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

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

        #region Views
        public async Task<PagedList<ViewGaPresenzeOrariGiornate>> GetViewGaPresenzeOrariGiornateByOrarioIdAsync(long orarioId)
        {
            var view = await viewGaPresenzeOrariGiornateRepo.GetWithFilterAsync(x=>x.PresenzeOrarioId==orarioId);
            return view;
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

        #region Extras
        public async Task<PresenzeProfiloUtenteDto> GetGaPresenzeProfiloUtenteByUserIdAsync(string userId,bool isAdmin)
        {
            PresenzeProfiloUtenteDto profiloUtente = new PresenzeProfiloUtenteDto();
            if (!isAdmin)
            {
                var dipendente = await viewGaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.UserId == userId);
                var dipendenteConfig = await gaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.PersonaleDipendenteId == dipendente.PersonaleDipendenteId);
                var settore = dipendente.SettoreId;
                var responsabile = await gaPresenzeResponsabiliRepo.GetSingleWithFilter(x => x.PersonaleDipendenteId == dipendente.PersonaleDipendenteId);

                List<long> responsabileSettori = new List<long>();
                if (responsabile != null && !dipendenteConfig.SuperUser)
                {
                    var settori = await gaPresenzeResponsabiliOnSettoriRepo.GetWithFilterAsync(x => x.PresenzeResponsabileId == responsabile.Id);
                    foreach (var itm in settori.Data)
                    {
                        responsabileSettori.Add(itm.GlobalSettoreId);
                    }
                }
                else if (responsabile != null && dipendenteConfig.SuperUser)
                {
                    var settori = await globalSettoriRepo.GetAllAsync();
                    foreach (var itm in settori.Data)
                    {
                        responsabileSettori.Add(itm.Id);
                    }
                }
                else if (responsabile == null && dipendenteConfig.SuperUser)
                {
                    var settori = await globalSettoriRepo.GetAllAsync();
                    foreach (var itm in settori.Data)
                    {
                        responsabileSettori.Add(itm.Id);
                    }
                }

                profiloUtente.PresenzeDipendenteId =dipendente.Id;
                profiloUtente.UserId = userId;
                profiloUtente.SettoreId = dipendente.SettoreId;
                profiloUtente.ResponsabileSettori = responsabileSettori;
                profiloUtente.SuperUser = dipendenteConfig.SuperUser;
                profiloUtente.PrivilegiElevati = dipendenteConfig.PrivilegiElevati;
                profiloUtente.AutoApprova = dipendenteConfig.AutoApprova;
                profiloUtente.BancaOre = dipendenteConfig.BancaOre;

                return profiloUtente;
            }
            else
            {
                List<long> responsabileSettori = new List<long>();
                var settori = await globalSettoriRepo.GetAllAsync();
                foreach (var itm in settori.Data)
                {
                    responsabileSettori.Add(itm.Id);
                }

                profiloUtente.PresenzeDipendenteId = 0;
                profiloUtente.UserId = userId;
                profiloUtente.SettoreId = 0;
                profiloUtente.ResponsabileSettori = responsabileSettori;
                profiloUtente.SuperUser = true;
                profiloUtente.PrivilegiElevati = false;
                profiloUtente.AutoApprova = false;
                profiloUtente.BancaOre = false;

                return profiloUtente;
            }
        }

        public async Task<PagedList<GlobalSettore>> GetGaPresenzeGlobalSettoriByUserId(string userId, bool isAdmin)
        {
            if (!isAdmin)
            {
                var dipendente = await viewGaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.UserId == userId);
                var dipendenteConfig = await gaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.PersonaleDipendenteId == dipendente.PersonaleDipendenteId);
                var responsabile = await gaPresenzeResponsabiliRepo.GetSingleWithFilter(x => x.PersonaleDipendenteId == dipendente.PersonaleDipendenteId);

                var settore = dipendente.SettoreId;

                List<long> responsabileSettori = new List<long>();
                if (responsabile != null  && !dipendenteConfig.SuperUser)
                {
                    var settori = await gaPresenzeResponsabiliOnSettoriRepo.GetWithFilterAsync(x => x.PresenzeResponsabileId == responsabile.Id);
                    foreach (var itm in settori.Data)
                    {
                        responsabileSettori.Add(itm.GlobalSettoreId);
                    }
                }
                else if (responsabile != null && dipendenteConfig.SuperUser)
                {
                    var settori = await globalSettoriRepo.GetAllAsync();
                    foreach (var itm in settori.Data)
                    {
                        responsabileSettori.Add(itm.Id);
                    }
                }
                else if (responsabile == null && dipendenteConfig.SuperUser)
                {
                    var settori = await globalSettoriRepo.GetAllAsync();
                    foreach (var itm in settori.Data)
                    {
                        responsabileSettori.Add(itm.Id);
                    }
                }

                responsabileSettori.Add(settore);

                return await globalSettoriRepo.GetWithFilterAsync(x => responsabileSettori.Distinct().Any(r=>r==x.Id));


            }
            else
            {
                List<long> responsabileSettori = new List<long>();
                var settori = await globalSettoriRepo.GetAllAsync();
                foreach (var itm in settori.Data)
                {
                    responsabileSettori.Add(itm.Id);
                }

                return await globalSettoriRepo.GetWithFilterAsync(x => responsabileSettori.Distinct().Contains(x.Id));
            }
        }

        public async Task<double> CalcTimeGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto)
        {
            try
            {
                var dipendente = await gaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeDipendenteId);
                var orariGiornate = await gaPresenzeOrariGiornateRepo.GetWithFilterAsync(x => x.PresenzeOrarioId == dipendente.PresenzeOrarioId);
                var dateEscluse = GetDateEscluse();

                return CalcToHour(dto.DataInizio, dto.DataFine, orariGiornate.Data.ToList(), dateEscluse);



            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion

        #region Private
        private double CalcToHour(DateTime start, DateTime end, List<PresenzeOrarioGiornata> orari, HashSet<DateTime> dateEscluse)
        {
            if (start.ToString("dd/MM/yyyy") == end.ToString("dd/MM/yyyy"))
            {
                var dayOfWeek = (int)start.DayOfWeek;
                var orario = (from x in orari where x.Giorno == dayOfWeek select x).FirstOrDefault();

                if (orario != null)
                {
                    if (!dateEscluse.Contains(start))
                    {
                        var pausaInizio = start.SetTime(orario.PausaInizio.GetValueOrDefault().Hour, orario.PausaInizio.GetValueOrDefault().Minute, orario.PausaInizio.GetValueOrDefault().Second);
                        var pausaFine = end.SetTime(orario.PausaFine.GetValueOrDefault().Hour, orario.PausaFine.GetValueOrDefault().Minute, orario.PausaFine.GetValueOrDefault().Second);

                        var calc = new Calculation(new List<DateTime>(), new OpenHoursModel(orario.OraInizio.ToString("HH:mm") + ";" + orario.OraFine.ToString("HH:mm")));
                        var calcPausa = new Calculation(new List<DateTime>(), new OpenHoursModel(orario.PausaInizio.GetValueOrDefault().ToString("HH:mm") + ";" + orario.PausaFine.GetValueOrDefault().ToString("HH:mm")));
                        var elapsed = calc.getElapsedMinutes(start, end);
                        var pausa = calcPausa.getElapsedMinutes(orario.PausaInizio.GetValueOrDefault(), orario.PausaFine.GetValueOrDefault());
                        if ((pausaInizio >= start && pausaInizio < end) && (pausaFine > start && pausaFine <= end) && (pausaInizio < pausaFine))
                        { elapsed -= pausa; }
                        return elapsed.From100to60Time();
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                HashSet<DateTime> dates = new HashSet<DateTime>();
                dates.Add(start);
                for (var d = start.SetTime(0, 0, 0).AddDays(1); d < end.SetTime(0, 0, 0); d = d.AddDays(1))
                {
                    dates.Add(d);
                }

                dates.Add(end);

                var totalDates = dates.Count;
                var index = 1;
                double totalElapsed = 0;
                double elapsed = 0;

                foreach (var d in dates)
                {
                    var dayOfWeek = (int)d.DayOfWeek;
                    var orario = (from x in orari where x.Giorno == dayOfWeek select x).FirstOrDefault();

                    if (orario != null)
                    {
                        if (!dateEscluse.Contains(d))
                        {
                            var calc = new Calculation(new List<DateTime>(), new OpenHoursModel(orario.OraInizio.ToString("HH:mm") + ";" + orario.OraFine.ToString("HH:mm")));
                            var calcPausa = new Calculation(new List<DateTime>(), new OpenHoursModel(orario.PausaInizio.GetValueOrDefault().ToString("HH:mm") + ";" + orario.PausaFine.GetValueOrDefault().ToString("HH:mm")));

                            if (index == 1)
                            {
                                var startDate = d;
                                var endDate = d.SetTime(23, 59, 0);//.Add(new TimeSpan(23, 59, 0));
                                var pausaInizio = startDate.SetTime(orario.PausaInizio.GetValueOrDefault().Hour, orario.PausaInizio.GetValueOrDefault().Minute, orario.PausaInizio.GetValueOrDefault().Second);
                                var pausaFine = endDate.SetTime(orario.PausaFine.GetValueOrDefault().Hour, orario.PausaFine.GetValueOrDefault().Minute, orario.PausaFine.GetValueOrDefault().Second);

                                elapsed = calc.getElapsedMinutes(startDate, endDate);

                                var pausa = calcPausa.getElapsedMinutes(orario.PausaInizio.GetValueOrDefault(), orario.PausaFine.GetValueOrDefault());
                                if ((pausaInizio >= startDate && pausaInizio < endDate) && (pausaFine > startDate && pausaFine <= endDate) && (pausaInizio < pausaFine))
                                { elapsed -= pausa; }
                                totalElapsed += elapsed;
                                index++;
                            }
                            else if (index == totalDates)
                            {
                                var startDate = d.SetTime(0, 0, 0);//.Add(new TimeSpan(0, 0, 0));
                                var endDate = d;
                                var pausaInizio = startDate.SetTime(orario.PausaInizio.GetValueOrDefault().Hour, orario.PausaInizio.GetValueOrDefault().Minute, orario.PausaInizio.GetValueOrDefault().Second);
                                var pausaFine = endDate.SetTime(orario.PausaFine.GetValueOrDefault().Hour, orario.PausaFine.GetValueOrDefault().Minute, orario.PausaFine.GetValueOrDefault().Second);

                                elapsed = calc.getElapsedMinutes(startDate, endDate);

                                var pausa = calcPausa.getElapsedMinutes(orario.PausaInizio.GetValueOrDefault(), orario.PausaFine.GetValueOrDefault());
                                if ((pausaInizio >= startDate && pausaInizio < endDate) && (pausaFine > startDate && pausaFine <= endDate) && (pausaInizio < pausaFine))
                                { elapsed -= pausa; }
                                totalElapsed += elapsed;
                                index++;
                            }
                            else
                            {
                                var startDate = d.SetTime(0, 0, 0);//.Add(new TimeSpan(0, 0, 0));
                                var endDate = d.SetTime(23, 59, 0);//.Add(new TimeSpan(23, 59, 0));
                                var pausaInizio = startDate.SetTime(orario.PausaInizio.GetValueOrDefault().Hour, orario.PausaInizio.GetValueOrDefault().Minute, orario.PausaInizio.GetValueOrDefault().Second);
                                var pausaFine = endDate.SetTime(orario.PausaFine.GetValueOrDefault().Hour, orario.PausaFine.GetValueOrDefault().Minute, orario.PausaFine.GetValueOrDefault().Second);

                                elapsed = calc.getElapsedMinutes(startDate, endDate);

                                var pausa = calcPausa.getElapsedMinutes(orario.PausaInizio.GetValueOrDefault(), orario.PausaFine.GetValueOrDefault());
                                if ((pausaInizio >= startDate && pausaInizio < endDate) && (pausaFine > startDate && pausaFine <= endDate) && (pausaInizio < pausaFine))
                                { elapsed -= pausa; }
                                totalElapsed += elapsed;
                                index++;
                            }

                        }
                    }
                }
                return totalElapsed.From100to60Time();
            }
        }

        private async Task<bool> ValidateBancaOre(PresenzeRichiestaDto dto)
        {
            //{ id: 0,descrizione: 'NON DECREMENTARE',disabled: false},
            //{ id: 1,descrizione: 'FERIE ORE',disabled: false },
            //{ id: 2, descrizione: 'FERIE ORE CCNL',disabled: false},
            //{ id: 3, descrizione: 'ORE RECUPERO',disabled: false}

            try
            {
                var dipendente = await viewGaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeDipendenteId);
                var tipoDec = gaPresenzeTipiOreRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeTipoOraId).Result.DecrementaTipo;
                if (tipoDec != 0 && (tipoDec == 1 || tipoDec == 2))
                {
                    double risdipendente = 0;
                    switch (tipoDec)
                    {
                        case 1:
                            risdipendente = dipendente.HhFerie;
                            break;
                        case 2:
                            risdipendente = dipendente.HhPermessiCcnl;
                            break;
                        case 3:
                            risdipendente = dipendente.HhRecupero;
                            break;
                        default:
                            risdipendente = 0;
                            break;
                    }

                    if (dto.TotaleOre > risdipendente) { return false; }
                    else { return true; }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private HashSet<DateTime> GetDateEscluse()
        {
            HashSet<DateTime> excludedDates = new HashSet<DateTime>(); ;
            var dates = gaPresenzeDateEscluseRepo.GetAll().ToList();
            foreach (var itm in dates)
            {
                excludedDates.Add(itm.Data);
            }
            return excludedDates;
        }

        private async Task<bool> ManageBancaOre(PresenzeRichiesta dto)
        {
            try
            {
                var dipendente = await gaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeDipendenteId);
                var tipoDec = gaPresenzeTipiOreRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeTipoOraId).Result.DecrementaTipo;
                var bancaOreUtilizzi = await gaPresenzeBancheOreUtilizziRepo.GetSingleWithFilter(x => x.PresenzeDipendenteId == dipendente.Id && x.PresenzeRichiestaId == dto.Id);

                if (bancaOreUtilizzi != null)
                {
                    switch (bancaOreUtilizzi.Tipo)
                    {
                        case 1:
                            dipendente.HhFerie = dipendente.HhFerie.From60to100TimeHour();
                            dipendente.HhFerie += bancaOreUtilizzi.Qta.From60to100TimeHour();
                            dipendente.HhFerie = dipendente.HhFerie.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        case 2:
                            dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From60to100TimeHour();
                            dipendente.HhPermessiCcnl += bancaOreUtilizzi.Qta.From60to100TimeHour();
                            dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        case 3:
                            dipendente.HhRecupero = dipendente.HhRecupero.From60to100TimeHour();
                            dipendente.HhRecupero += bancaOreUtilizzi.Qta.From60to100TimeHour();
                            dipendente.HhRecupero = dipendente.HhRecupero.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        default:

                            break;

                    }

                    switch (tipoDec)
                    {
                        case 1:
                            dipendente.HhFerie = dipendente.HhFerie.From60to100TimeHour();
                            dipendente.HhFerie -= dto.TotaleOre.From60to100TimeHour();
                            dipendente.HhFerie = dipendente.HhFerie.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        case 2:
                            dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From60to100TimeHour();
                            dipendente.HhPermessiCcnl -= dto.TotaleOre.From60to100TimeHour();
                            dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        case 3:
                            dipendente.HhRecupero = dipendente.HhRecupero.From60to100TimeHour();
                            dipendente.HhRecupero -= dto.TotaleOre.From60to100TimeHour();
                            dipendente.HhRecupero = dipendente.HhRecupero.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        default:

                            break;

                    }

                    bancaOreUtilizzi.Tipo = tipoDec;
                    bancaOreUtilizzi.Qta = dto.TotaleOre;
                    gaPresenzeBancheOreUtilizziRepo.Update(bancaOreUtilizzi);
                    await SaveChanges();

                    return true;
                }
                else
                {
                    switch (tipoDec)
                    {
                        case 1:
                            dipendente.HhFerie = dipendente.HhFerie.From60to100TimeHour();
                            dipendente.HhFerie -= dto.TotaleOre.From60to100TimeHour();
                            dipendente.HhFerie = dipendente.HhFerie.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        case 2:
                            dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From60to100TimeHour();
                            dipendente.HhPermessiCcnl -= dto.TotaleOre.From60to100TimeHour();
                            dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        case 3:
                            dipendente.HhRecupero = dipendente.HhRecupero.From60to100TimeHour();
                            dipendente.HhRecupero -= dto.TotaleOre.From60to100TimeHour();
                            dipendente.HhRecupero = dipendente.HhRecupero.From100to60TimeHour();
                            gaPresenzeDipendentiRepo.Update(dipendente);
                            await SaveChanges();
                            break;
                        default:

                            break;

                    }

                    bancaOreUtilizzi = new PresenzeBancaOraUtilizzo();
                    bancaOreUtilizzi.Id = 0;
                    bancaOreUtilizzi.PresenzeDipendenteId = dto.PresenzeDipendenteId;
                    bancaOreUtilizzi.PresenzeRichiestaId = dto.Id;
                    bancaOreUtilizzi.Tipo = tipoDec;
                    bancaOreUtilizzi.Qta = dto.TotaleOre;
                    bancaOreUtilizzi.Disabled = false;

                    gaPresenzeBancheOreUtilizziRepo.Update(bancaOreUtilizzi);
                    await SaveChanges();

                    return true;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> ManageDeleteBancaOre(PresenzeRichiesta dto)
        {
            try
            {
                var tipoDec = gaPresenzeTipiOreRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeTipoOraId).Result.DecrementaTipo;

                if (tipoDec != 0)
                {
                    var dipendente = await gaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeDipendenteId);
                    var bancaOreUtilizzi = await gaPresenzeBancheOreUtilizziRepo.GetSingleWithFilter(x => x.PresenzeDipendenteId == dipendente.Id && x.PresenzeRichiestaId == dto.Id);

                    //Ricarica Banca Ore
                    if (bancaOreUtilizzi != null)
                    {
                        switch (tipoDec)
                        {
                            case 1:
                                dipendente.HhFerie = dipendente.HhFerie.From60to100TimeHour();
                                dipendente.HhFerie += bancaOreUtilizzi.Qta.From60to100TimeHour();
                                dipendente.HhFerie = dipendente.HhFerie.From100to60TimeHour();
                                gaPresenzeDipendentiRepo.Update(dipendente);
                                await SaveChanges();
                                break;
                            case 2:
                                dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From60to100TimeHour();
                                dipendente.HhPermessiCcnl += bancaOreUtilizzi.Qta.From60to100TimeHour();
                                dipendente.HhPermessiCcnl = dipendente.HhPermessiCcnl.From100to60TimeHour();
                                gaPresenzeDipendentiRepo.Update(dipendente);
                                await SaveChanges();
                                break;
                            case 4:
                                dipendente.HhRecupero = dipendente.HhRecupero.From60to100TimeHour();
                                dipendente.HhRecupero += bancaOreUtilizzi.Qta.From60to100TimeHour();
                                dipendente.HhRecupero = dipendente.HhRecupero.From100to60TimeHour();
                                gaPresenzeDipendentiRepo.Update(dipendente);
                                await SaveChanges();
                                break;
                            default:

                                break;

                        }

                        gaPresenzeBancheOreUtilizziRepo.Remove(bancaOreUtilizzi);
                        await SaveChanges();

                        return true;
                    }
                    return true;
                }
                else
                {
                    var dipendente = await gaPresenzeDipendentiRepo.GetSingleWithFilter(x => x.Id == dto.PresenzeDipendenteId);
                    var bancaOreUtilizzi = await gaPresenzeBancheOreUtilizziRepo.GetSingleWithFilter(x => x.PresenzeDipendenteId == dipendente.Id && x.PresenzeRichiestaId == dto.Id);

                    //Ricarica Banca Ore
                    if (bancaOreUtilizzi != null)
                    {
                        gaPresenzeBancheOreUtilizziRepo.Remove(bancaOreUtilizzi);
                        await SaveChanges();

                        return true;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
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


