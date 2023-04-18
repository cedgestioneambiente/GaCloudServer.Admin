using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;
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
        protected readonly IGenericRepository<PersonaleScadenza> gaPersonaleScadenzeRepo;
        protected readonly IGenericRepository<PersonaleScadenzaTipo> gaPersonaleScadenzeTipiRepo;
        protected readonly IGenericRepository<PersonaleScadenzaDettaglio> gaPersonaleScadenzeDettagliRepo;
        protected readonly IGenericRepository<PersonaleSanzioneMotivo> gaPersonaleSanzioniMotiviRepo;
        protected readonly IGenericRepository<PersonaleSanzioneDescrizione> gaPersonaleSanzioniDescrizioniRepo;
        protected readonly IGenericRepository<PersonaleSanzione> gaPersonaleSanzioniRepo;
        protected readonly IGenericRepository<PersonaleAbilitazioneTipo> gaPersonaleAbilitazioniTipiRepo;
        protected readonly IGenericRepository<PersonaleAbilitazione> gaPersonaleAbilitazioniRepo;
        protected readonly IGenericRepository<PersonaleRetributivoTipo> gaPersonaleRetributiviTipiRepo;
        protected readonly IGenericRepository<PersonaleRetributivo> gaPersonaleRetributiviRepo;
        protected readonly IGenericRepository<PersonaleSchedaConsegna> gaPersonaleSchedeConsegneRepo;
        protected readonly IGenericRepository<PersonaleSchedaConsegnaDettaglio> gaPersonaleSchedeConsegneDettagliRepo;
        protected readonly IGenericRepository<PersonaleArticolo> gaPersonaleArticoliRepo;
        protected readonly IGenericRepository<PersonaleArticoloModello> gaPersonaleArticoliModelliRepo;
        protected readonly IGenericRepository<PersonaleArticoloTipologia> gaPersonaleArticoliTipologieRepo;
        protected readonly IGenericRepository<PersonaleArticoloDpi> gaPersonaleArticoliDpisRepo;

        protected readonly IGenericRepository<ViewGaPersonaleUsersOnDipendenti> viewGaPersonaleUsersOnDipendentiRepo;
        protected readonly IGenericRepository<ViewGaPersonaleDipendenti> viewGaPersonaleDipendentiRepo;
        protected readonly IGenericRepository<ViewGaPersonaleScadenze> viewGaPersonaleScadenzeRepo;
        protected readonly IGenericRepository<ViewGaPersonaleAbilitazioni> viewGaPersonaleAbilitazioniRepo;
        protected readonly IGenericRepository<ViewGaPersonaleArticoli> viewGaPersonaleArticoliRepo;
        protected readonly IGenericRepository<ViewGaPersonaleNuoveSchede> viewGaPersonaleNuoveSchedeRepo;
        protected readonly IGenericRepository<ViewGaPersonaleRetributivi> viewGaPersonaleRetributiviRepo;
        protected readonly IGenericRepository<ViewGaPersonaleSanzioni> viewGaPersonaleSanzioniRepo;
        protected readonly IGenericRepository<ViewGaPersonaleScadenziario> viewGaPersonaleScadenziarioRepo;
        protected readonly IGenericRepository<ViewGaPersonaleScadenziarioAbilitazioni> viewGaPersonaleScadenziarioAbilitazioniRepo;
        protected readonly IGenericRepository<ViewGaPersonaleSchedeConsegne> viewGaPersonaleSchedeConsegneRepo;


        protected readonly IUnitOfWork unitOfWork;

        public GaPersonaleService(
            IGenericRepository<PersonaleQualifica> gaPersonaleQualificheRepo,
            IGenericRepository<PersonaleAssunzione> gaPersonaleAssunzioniRepo,
            IGenericRepository<PersonaleDipendente> gaPersonaleDipendentiRepo,
            IGenericRepository<PersonaleScadenza> gaPersonaleScadenzeRepo,
            IGenericRepository<PersonaleScadenzaTipo> gaPersonaleScadenzeTipiRepo,
            IGenericRepository<PersonaleScadenzaDettaglio> gaPersonaleScadenzeDettagliRepo,
            IGenericRepository<PersonaleSanzioneMotivo> gaPersonaleSanzioniMotiviRepo,
            IGenericRepository<PersonaleSanzioneDescrizione> gaPersonaleSanzioniDescrizioniRepo,
            IGenericRepository<PersonaleSanzione> gaPersonaleSanzioniRepo,
            IGenericRepository<PersonaleAbilitazioneTipo> gaPersonaleAbilitazioniTipiRepo,
            IGenericRepository<PersonaleAbilitazione> gaPersonaleAbilitazioniRepo,
            IGenericRepository<PersonaleRetributivoTipo> gaPersonaleRetributiviTipiRepo,
            IGenericRepository<PersonaleRetributivo> gaPersonaleRetributiviRepo,
            IGenericRepository<PersonaleSchedaConsegna> gaPersonaleSchedeConsegneRepo,
            IGenericRepository<PersonaleSchedaConsegnaDettaglio> gaPersonaleSchedeConsegneDettagliRepo,
            IGenericRepository<PersonaleArticolo> gaPersonaleArticoliRepo,
            IGenericRepository<PersonaleArticoloModello> gaPersonaleArticoliModelliRepo,
            IGenericRepository<PersonaleArticoloTipologia> gaPersonaleArticoliTipologieRepo,
            IGenericRepository<PersonaleArticoloDpi> gaPersonaleArticoliDpisRepo,

            IGenericRepository<ViewGaPersonaleUsersOnDipendenti> viewGaPersonaleUsersOnDipendentiRepo,
            IGenericRepository<ViewGaPersonaleDipendenti> viewGaPersonaleDipendentiRepo,
            IGenericRepository<ViewGaPersonaleScadenze> viewGaPersonaleScadenzeRepo,
            IGenericRepository<ViewGaPersonaleAbilitazioni> viewGaPersonaleAbilitazioniRepo,
            IGenericRepository<ViewGaPersonaleArticoli> viewGaPersonaleArticoliRepo,
            IGenericRepository<ViewGaPersonaleNuoveSchede> viewGaPersonaleNuoveSchedeRepo,
            IGenericRepository<ViewGaPersonaleRetributivi> viewGaPersonaleRetributiviRepo,
            IGenericRepository<ViewGaPersonaleSanzioni> viewGaPersonaleSanzioniRepo,
            IGenericRepository<ViewGaPersonaleScadenziario> viewGaPersonaleScadenziarioRepo,
            IGenericRepository<ViewGaPersonaleScadenziarioAbilitazioni> viewGaPersonaleScadenziarioAbilitazioniRepo,
            IGenericRepository<ViewGaPersonaleSchedeConsegne> viewGaPersonaleSchedeConsegneRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaPersonaleQualificheRepo = gaPersonaleQualificheRepo;
            this.gaPersonaleAssunzioniRepo = gaPersonaleAssunzioniRepo;
            this.gaPersonaleDipendentiRepo = gaPersonaleDipendentiRepo;
            this.gaPersonaleScadenzeRepo = gaPersonaleScadenzeRepo;
            this.gaPersonaleScadenzeTipiRepo = gaPersonaleScadenzeTipiRepo;
            this.gaPersonaleScadenzeDettagliRepo = gaPersonaleScadenzeDettagliRepo;
            this.gaPersonaleSanzioniMotiviRepo = gaPersonaleSanzioniMotiviRepo;
            this.gaPersonaleSanzioniDescrizioniRepo = gaPersonaleSanzioniDescrizioniRepo;
            this.gaPersonaleSanzioniRepo = gaPersonaleSanzioniRepo;
            this.gaPersonaleAbilitazioniTipiRepo = gaPersonaleAbilitazioniTipiRepo;
            this.gaPersonaleAbilitazioniRepo = gaPersonaleAbilitazioniRepo;
            this.gaPersonaleRetributiviTipiRepo = gaPersonaleRetributiviTipiRepo;
            this.gaPersonaleRetributiviRepo = gaPersonaleRetributiviRepo;
            this.gaPersonaleSchedeConsegneRepo = gaPersonaleSchedeConsegneRepo;
            this.gaPersonaleSchedeConsegneDettagliRepo = gaPersonaleSchedeConsegneDettagliRepo;
            this.gaPersonaleArticoliRepo = gaPersonaleArticoliRepo;
            this.gaPersonaleArticoliModelliRepo = gaPersonaleArticoliModelliRepo;
            this.gaPersonaleArticoliTipologieRepo = gaPersonaleArticoliTipologieRepo;
            this.gaPersonaleArticoliDpisRepo = gaPersonaleArticoliDpisRepo;

            this.viewGaPersonaleUsersOnDipendentiRepo = viewGaPersonaleUsersOnDipendentiRepo;
            this.viewGaPersonaleDipendentiRepo = viewGaPersonaleDipendentiRepo;
            this.viewGaPersonaleScadenzeRepo = viewGaPersonaleScadenzeRepo;
            this.viewGaPersonaleAbilitazioniRepo = viewGaPersonaleAbilitazioniRepo;
            this.viewGaPersonaleArticoliRepo = viewGaPersonaleArticoliRepo;
            this.viewGaPersonaleNuoveSchedeRepo = viewGaPersonaleNuoveSchedeRepo;
            this.viewGaPersonaleRetributiviRepo = viewGaPersonaleRetributiviRepo;
            this.viewGaPersonaleSanzioniRepo = viewGaPersonaleSanzioniRepo;
            this.viewGaPersonaleScadenziarioRepo = viewGaPersonaleScadenziarioRepo;
            this.viewGaPersonaleScadenziarioAbilitazioniRepo = viewGaPersonaleScadenziarioAbilitazioniRepo;
            this.viewGaPersonaleSchedeConsegneRepo = viewGaPersonaleSchedeConsegneRepo;

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

        #region Views
        public async Task<PagedList<ViewGaPersonaleUsersOnDipendenti>> GetViewGaPersonaleUsersOnDipendentiAsync(bool all = true)
        {
            var view = all == true ? await viewGaPersonaleUsersOnDipendentiRepo.GetAllAsync(1, 0, "CognomeNome") : await viewGaPersonaleUsersOnDipendentiRepo.GetWithFilterAsync(x => x.Active==false && x.ShowInApp == true, 1, 0, "CognomeNome");
            return view;
        }

        public async Task<PagedList<ViewGaPersonaleDipendenti>> GetViewGaPersonaleDipendentiByQualificaAndSedeAsync(long qualificaId,long sedeId)
        {
            if (qualificaId == 0)
            {
                if (sedeId == 0)
                {
                    return await viewGaPersonaleDipendentiRepo.GetAllAsync();
                }
                else
                {
                    return await viewGaPersonaleDipendentiRepo.GetWithFilterAsync(x => x.SedeId == sedeId);
                }
            }
            else
            {
                if (sedeId == 0)
                {
                    return await viewGaPersonaleDipendentiRepo.GetWithFilterAsync(x => x.QualificaId == qualificaId);
                }
                else
                {
                    return await viewGaPersonaleDipendentiRepo.GetWithFilterAsync(x => x.QualificaId == qualificaId && x.SedeId == sedeId);
                }
            }
        }

        public async Task<ViewGaPersonaleDipendenti> GetViewGaPersonaleDipendenteByIdAsync(long id)
        {
            return await viewGaPersonaleDipendentiRepo.GetSingleWithFilter(x => x.Id == id);

        }
        #endregion

        #endregion

        #region PersonaleScadenze
        public async Task<PersonaleScadenzeDto> GetGaPersonaleScadenzeByDipendenteIdAsync(long personaleDipendenteId)
        {
            var entities = await gaPersonaleScadenzeRepo.GetWithFilterAsync(x=>x.PersonaleDipendenteId== personaleDipendenteId);
            var dtos = entities.ToDto<PersonaleScadenzeDto, PagedList<PersonaleScadenza>>();
            return dtos;
        }

        public async Task<PersonaleScadenzaDto> GetGaPersonaleScadenzaByIdAsync(long id)
        {
            var entity = await gaPersonaleScadenzeRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleScadenzaDto, PersonaleScadenza>();
            return dto;
        }

        public async Task<long> AddGaPersonaleScadenzaAsync(PersonaleScadenzaDto dto)
        {
            var entity = dto.ToEntity<PersonaleScadenza, PersonaleScadenzaDto>();
            await gaPersonaleScadenzeRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleScadenzaAsync(PersonaleScadenzaDto dto)
        {
            var entity = dto.ToEntity<PersonaleScadenza, PersonaleScadenzaDto>();
            gaPersonaleScadenzeRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleScadenzaAsync(long id)
        {
            var entity = await gaPersonaleScadenzeRepo.GetByIdAsync(id);
            gaPersonaleScadenzeRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaPersonaleScadenzaAsync(long id, string descrizione)
        //{
        //    var entity = await gaPersonaleScadenzeRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        public async Task<bool> ChangeStatusGaPersonaleScadenzaAsync(long id)
        {
            var entity = await gaPersonaleScadenzeRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleScadenzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleScadenzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPersonaleScadenze>> GetViewGaPersonaleScadenzeByDipendenteIdAsync(long dipendenteId)
        {
            var view = await viewGaPersonaleScadenzeRepo.GetWithFilterAsync(x=>x.DipendenteId==dipendenteId);
            return view;

        }

        public async Task<PagedList<ViewGaPersonaleScadenziario>> GetViewGaPersonaleScadenziarioAsync(bool all = true)
        {
            var view = all == true ? await viewGaPersonaleScadenziarioRepo.GetAllAsync(1, 0, "Dipendente") : await viewGaPersonaleScadenziarioRepo.GetWithFilterAsync(x => x.Disabled == false, 1, 0, "Dipendente");
            return view;
        }

        #endregion
        #endregion

        #region PersonaleScadenzeTipi
        public async Task<PersonaleScadenzeTipiDto> GetGaPersonaleScadenzeTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleScadenzeTipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleScadenzeTipiDto, PagedList<PersonaleScadenzaTipo>>();
            return dtos;
        }

        public async Task<PersonaleScadenzaTipoDto> GetGaPersonaleScadenzaTipoByIdAsync(long id)
        {
            var entity = await gaPersonaleScadenzeTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleScadenzaTipoDto, PersonaleScadenzaTipo>();
            return dto;
        }

        public async Task<long> AddGaPersonaleScadenzaTipoAsync(PersonaleScadenzaTipoDto dto)
        {
            var entity = dto.ToEntity<PersonaleScadenzaTipo, PersonaleScadenzaTipoDto>();
            await gaPersonaleScadenzeTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleScadenzaTipoAsync(PersonaleScadenzaTipoDto dto)
        {
            var entity = dto.ToEntity<PersonaleScadenzaTipo, PersonaleScadenzaTipoDto>();
            gaPersonaleScadenzeTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleScadenzaTipoAsync(long id)
        {
            var entity = await gaPersonaleScadenzeTipiRepo.GetByIdAsync(id);
            gaPersonaleScadenzeTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleScadenzaTipoAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleScadenzeTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleScadenzaTipoAsync(long id)
        {
            var entity = await gaPersonaleScadenzeTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleScadenzeTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleScadenzeTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleScadenzeDettagli
        public async Task<PersonaleScadenzeDettagliDto> GetGaPersonaleScadenzeDettagliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleScadenzeDettagliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleScadenzeDettagliDto, PagedList<PersonaleScadenzaDettaglio>>();
            return dtos;
        }

        public async Task<PersonaleScadenzaDettaglioDto> GetGaPersonaleScadenzaDettaglioByIdAsync(long id)
        {
            var entity = await gaPersonaleScadenzeDettagliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleScadenzaDettaglioDto, PersonaleScadenzaDettaglio>();
            return dto;
        }

        public async Task<long> AddGaPersonaleScadenzaDettaglioAsync(PersonaleScadenzaDettaglioDto dto)
        {
            var entity = dto.ToEntity<PersonaleScadenzaDettaglio, PersonaleScadenzaDettaglioDto>();
            await gaPersonaleScadenzeDettagliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleScadenzaDettaglioAsync(PersonaleScadenzaDettaglioDto dto)
        {
            var entity = dto.ToEntity<PersonaleScadenzaDettaglio, PersonaleScadenzaDettaglioDto>();
            gaPersonaleScadenzeDettagliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleScadenzaDettaglioAsync(long id)
        {
            var entity = await gaPersonaleScadenzeDettagliRepo.GetByIdAsync(id);
            gaPersonaleScadenzeDettagliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleScadenzaDettaglioAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleScadenzeDettagliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleScadenzaDettaglioAsync(long id)
        {
            var entity = await gaPersonaleScadenzeDettagliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleScadenzeDettagliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleScadenzeDettagliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleSanzioniMotivi
        public async Task<PersonaleSanzioniMotiviDto> GetGaPersonaleSanzioniMotiviAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleSanzioniMotiviRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleSanzioniMotiviDto, PagedList<PersonaleSanzioneMotivo>>();
            return dtos;
        }

        public async Task<PersonaleSanzioneMotivoDto> GetGaPersonaleSanzioneMotivoByIdAsync(long id)
        {
            var entity = await gaPersonaleSanzioniMotiviRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleSanzioneMotivoDto, PersonaleSanzioneMotivo>();
            return dto;
        }

        public async Task<long> AddGaPersonaleSanzioneMotivoAsync(PersonaleSanzioneMotivoDto dto)
        {
            var entity = dto.ToEntity<PersonaleSanzioneMotivo, PersonaleSanzioneMotivoDto>();
            await gaPersonaleSanzioniMotiviRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleSanzioneMotivoAsync(PersonaleSanzioneMotivoDto dto)
        {
            var entity = dto.ToEntity<PersonaleSanzioneMotivo, PersonaleSanzioneMotivoDto>();
            gaPersonaleSanzioniMotiviRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleSanzioneMotivoAsync(long id)
        {
            var entity = await gaPersonaleSanzioniMotiviRepo.GetByIdAsync(id);
            gaPersonaleSanzioniMotiviRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleSanzioneMotivoAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleSanzioniMotiviRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleSanzioneMotivoAsync(long id)
        {
            var entity = await gaPersonaleSanzioniMotiviRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleSanzioniMotiviRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleSanzioniMotiviRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleSanzioniDescrizioni
        public async Task<PersonaleSanzioniDescrizioniDto> GetGaPersonaleSanzioniDescrizioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleSanzioniDescrizioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleSanzioniDescrizioniDto, PagedList<PersonaleSanzioneDescrizione>>();
            return dtos;
        }

        public async Task<PersonaleSanzioneDescrizioneDto> GetGaPersonaleSanzioneDescrizioneByIdAsync(long id)
        {
            var entity = await gaPersonaleSanzioniDescrizioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleSanzioneDescrizioneDto, PersonaleSanzioneDescrizione>();
            return dto;
        }

        public async Task<long> AddGaPersonaleSanzioneDescrizioneAsync(PersonaleSanzioneDescrizioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleSanzioneDescrizione, PersonaleSanzioneDescrizioneDto>();
            await gaPersonaleSanzioniDescrizioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleSanzioneDescrizioneAsync(PersonaleSanzioneDescrizioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleSanzioneDescrizione, PersonaleSanzioneDescrizioneDto>();
            gaPersonaleSanzioniDescrizioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleSanzioneDescrizioneAsync(long id)
        {
            var entity = await gaPersonaleSanzioniDescrizioniRepo.GetByIdAsync(id);
            gaPersonaleSanzioniDescrizioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleSanzioneDescrizioneAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleSanzioniDescrizioniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleSanzioneDescrizioneAsync(long id)
        {
            var entity = await gaPersonaleSanzioniDescrizioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleSanzioniDescrizioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleSanzioniDescrizioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleSanzioni
        public async Task<PersonaleSanzioniDto> GetGaPersonaleSanzioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleSanzioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleSanzioniDto, PagedList<PersonaleSanzione>>();
            return dtos;
        }

        public async Task<PersonaleSanzioneDto> GetGaPersonaleSanzioneByIdAsync(long id)
        {
            var entity = await gaPersonaleSanzioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleSanzioneDto, PersonaleSanzione>();
            return dto;
        }

        public async Task<long> AddGaPersonaleSanzioneAsync(PersonaleSanzioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleSanzione, PersonaleSanzioneDto>();
            await gaPersonaleSanzioniRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleSanzioneAsync(PersonaleSanzioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleSanzione, PersonaleSanzioneDto>();
            gaPersonaleSanzioniRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleSanzioneAsync(long id)
        {
            var entity = await gaPersonaleSanzioniRepo.GetByIdAsync(id);
            gaPersonaleSanzioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleSanzioneAsync(long id, long personaleDipendenteId, long personaleSanzioneMotivoId, long personaleSanzioneDescrizioneId)
        {
            var entity = await gaPersonaleSanzioniRepo.GetWithFilterAsync(x => x.PersonaleDipendenteId == personaleDipendenteId && x.PersonaleSanzioneMotivoId == personaleSanzioneMotivoId && x.PersonaleSanzioneDescrizioneId == personaleSanzioneDescrizioneId && x.Id != id, 1, 0);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleSanzioneAsync(long id)
        {
            var entity = await gaPersonaleSanzioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleSanzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleSanzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPersonaleSanzioni>> GetViewGaPersonaleSanzioniByDipendenteIdAsync(long dipendenteId)
        {

            try
            {

                var result=dipendenteId==0?await viewGaPersonaleSanzioniRepo.GetAllAsync(): await viewGaPersonaleSanzioniRepo.GetWithFilterAsync(x => x.DipendenteId == dipendenteId);
                return result;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region PersonaleAbilitazioniTipi
        public async Task<PersonaleAbilitazioniTipiDto> GetGaPersonaleAbilitazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleAbilitazioniTipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleAbilitazioniTipiDto, PagedList<PersonaleAbilitazioneTipo>>();
            return dtos;
        }

        public async Task<PersonaleAbilitazioneTipoDto> GetGaPersonaleAbilitazioneTipoByIdAsync(long id)
        {
            var entity = await gaPersonaleAbilitazioniTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleAbilitazioneTipoDto, PersonaleAbilitazioneTipo>();
            return dto;
        }

        public async Task<long> AddGaPersonaleAbilitazioneTipoAsync(PersonaleAbilitazioneTipoDto dto)
        {
            var entity = dto.ToEntity<PersonaleAbilitazioneTipo, PersonaleAbilitazioneTipoDto>();
            await gaPersonaleAbilitazioniTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleAbilitazioneTipoAsync(PersonaleAbilitazioneTipoDto dto)
        {
            var entity = dto.ToEntity<PersonaleAbilitazioneTipo, PersonaleAbilitazioneTipoDto>();
            gaPersonaleAbilitazioniTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleAbilitazioneTipoAsync(long id)
        {
            var entity = await gaPersonaleAbilitazioniTipiRepo.GetByIdAsync(id);
            gaPersonaleAbilitazioniTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleAbilitazioneTipoAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleAbilitazioniTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleAbilitazioneTipoAsync(long id)
        {
            var entity = await gaPersonaleAbilitazioniTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleAbilitazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleAbilitazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleAbilitazioni
        public async Task<PersonaleAbilitazioniDto> GetGaPersonaleAbilitazioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleAbilitazioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleAbilitazioniDto, PagedList<PersonaleAbilitazione>>();
            return dtos;
        }

        public async Task<PersonaleAbilitazioneDto> GetGaPersonaleAbilitazioneByIdAsync(long id)
        {
            var entity = await gaPersonaleAbilitazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleAbilitazioneDto, PersonaleAbilitazione>();
            return dto;
        }

        public async Task<long> AddGaPersonaleAbilitazioneAsync(PersonaleAbilitazioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleAbilitazione, PersonaleAbilitazioneDto>();
            await gaPersonaleAbilitazioniRepo.AddAsync(entity);

            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleAbilitazioneAsync(PersonaleAbilitazioneDto dto)
        {
            var entity = dto.ToEntity<PersonaleAbilitazione, PersonaleAbilitazioneDto>();
            gaPersonaleAbilitazioniRepo.Update(entity);

            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleAbilitazioneAsync(long id)
        {
            var entity = await gaPersonaleAbilitazioniRepo.GetByIdAsync(id);
            gaPersonaleAbilitazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaPersonaleAbilitazioneAsync(long id, string descrizione)
        //{
        //    var entity = await gaPersonaleAbilitazioniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        public async Task<bool> ChangeStatusGaPersonaleAbilitazioneAsync(long id)
        {
            var entity = await gaPersonaleAbilitazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleAbilitazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleAbilitazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPersonaleAbilitazioni>> GetViewGaPersonaleAbilitazioniByDipendenteIdAsync(long dipendenteId)
        {
                if (dipendenteId == 0)
                {
                    return await viewGaPersonaleAbilitazioniRepo.GetAllAsync();
                }
                else
                {
                    return await viewGaPersonaleAbilitazioniRepo.GetWithFilterAsync(x => x.DipendenteId == dipendenteId);
                }
              

        }
        public async Task<PagedList<ViewGaPersonaleScadenziarioAbilitazioni>> GetViewGaPersonaleScadenziarioAbilitazioniAsync()
        {
            try
            {
                return await viewGaPersonaleScadenziarioAbilitazioniRepo.GetAllAsync(1, 0, "Dipendente");
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region PersonaleRetributiviTipi
        public async Task<PersonaleRetributiviTipiDto> GetGaPersonaleRetributiviTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleRetributiviTipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleRetributiviTipiDto, PagedList<PersonaleRetributivoTipo>>();
            return dtos;
        }

        public async Task<PersonaleRetributivoTipoDto> GetGaPersonaleRetributivoTipoByIdAsync(long id)
        {
            var entity = await gaPersonaleRetributiviTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleRetributivoTipoDto, PersonaleRetributivoTipo>();
            return dto;
        }

        public async Task<long> AddGaPersonaleRetributivoTipoAsync(PersonaleRetributivoTipoDto dto)
        {
            var entity = dto.ToEntity<PersonaleRetributivoTipo, PersonaleRetributivoTipoDto>();
            await gaPersonaleRetributiviTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleRetributivoTipoAsync(PersonaleRetributivoTipoDto dto)
        {
            var entity = dto.ToEntity<PersonaleRetributivoTipo, PersonaleRetributivoTipoDto>();
            gaPersonaleRetributiviTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleRetributivoTipoAsync(long id)
        {
            var entity = await gaPersonaleRetributiviTipiRepo.GetByIdAsync(id);
            gaPersonaleRetributiviTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleRetributivoTipoAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleRetributiviTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleRetributivoTipoAsync(long id)
        {
            var entity = await gaPersonaleRetributiviTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleRetributiviTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleRetributiviTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleRetributivi
        public async Task<PersonaleRetributiviDto> GetGaPersonaleRetributiviAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleRetributiviRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleRetributiviDto, PagedList<PersonaleRetributivo>>();
            return dtos;
        }

        public async Task<PersonaleRetributivoDto> GetGaPersonaleRetributivoByIdAsync(long id)
        {
            var entity = await gaPersonaleRetributiviRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleRetributivoDto, PersonaleRetributivo>();
            return dto;
        }

        public async Task<long> AddGaPersonaleRetributivoAsync(PersonaleRetributivoDto dto)
        {
            var entity = dto.ToEntity<PersonaleRetributivo, PersonaleRetributivoDto>();
            await gaPersonaleRetributiviRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleRetributivoAsync(PersonaleRetributivoDto dto)
        {
            var entity = dto.ToEntity<PersonaleRetributivo, PersonaleRetributivoDto>();
            gaPersonaleRetributiviRepo.Update(entity);

            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleRetributivoAsync(long id)
        {
            var entity = await gaPersonaleRetributiviRepo.GetByIdAsync(id);
            gaPersonaleRetributiviRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaPersonaleRetributivoAsync(long id, string descrizione)
        //{
        //    var entity = await gaPersonaleRetributiviRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        public async Task<bool> ChangeStatusGaPersonaleRetributivoAsync(long id)
        {
            var entity = await gaPersonaleRetributiviRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleRetributiviRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleRetributiviRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPersonaleRetributivi>> GetViewGaPersonaleRetributiviByDipendenteIdAsync(long dipendenteId)
        {

            try
            {
                return dipendenteId==0?await viewGaPersonaleRetributiviRepo.GetAllAsync():  await viewGaPersonaleRetributiviRepo.GetWithFilterAsync(x => x.DipendenteId == dipendenteId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region PersonaleSchedeConsegne
        public async Task<PersonaleSchedeConsegneDto> GetGaPersonaleSchedeConsegneAsync(long personaleDipendenteId)
        {
            var entities = await gaPersonaleSchedeConsegneRepo.GetWithFilterAsync(x => x.PersonaleDipendenteId == personaleDipendenteId, 1, 0);
            var dtos = entities.ToDto<PersonaleSchedeConsegneDto, PagedList<PersonaleSchedaConsegna>>();
            return dtos;
        }

        public async Task<PersonaleSchedaConsegnaDto> GetGaPersonaleSchedaConsegnaByIdAsync(long id)
        {
            var entity = await gaPersonaleSchedeConsegneRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleSchedaConsegnaDto, PersonaleSchedaConsegna>();
            return dto;
        }

        public async Task<long> AddGaPersonaleSchedaConsegnaAsync(PersonaleSchedaConsegnaDto dto)
        {
            var entity = dto.ToEntity<PersonaleSchedaConsegna, PersonaleSchedaConsegnaDto>();
            entity.Numero = await GenerateNumberPersonaleSchedaConsegna(dto.Data.Year);
            await gaPersonaleSchedeConsegneRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleSchedaConsegnaAsync(PersonaleSchedaConsegnaDto dto)
        {
            var entity = dto.ToEntity<PersonaleSchedaConsegna, PersonaleSchedaConsegnaDto>();
            gaPersonaleSchedeConsegneRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleSchedaConsegnaAsync(long id)
        {
            var linkedEntities = await gaPersonaleSchedeConsegneDettagliRepo.GetWithFilterAsync(x => x.PersonaleSchedaConsegnaId == id);
            foreach (var itm in linkedEntities.Data)
            {
                gaPersonaleSchedeConsegneDettagliRepo.Remove(itm);
                await SaveChanges();
            }
                

            var entity = await gaPersonaleSchedeConsegneRepo.GetByIdAsync(id);
            gaPersonaleSchedeConsegneRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaPersonaleSchedaConsegnaAsync(long id, string descrizione)
        //{
        //    var entity = await gaPersonaleSchedeConsegneRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusGaPersonaleSchedaConsegnaAsync(long id)
        //{
        //    var entity = await gaPersonaleSchedeConsegneRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        gaPersonaleSchedeConsegneRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        gaPersonaleSchedeConsegneRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPersonaleSchedeConsegne>> GetViewGaPersonaleRiepilogoConsegneAsync()
        {
            try
            {
                return await viewGaPersonaleSchedeConsegneRepo.GetAllAsync(1, 0, "Data", "OrderByDescending");
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region PersonaleSchedeConsegneDettagli
        public async Task<PersonaleSchedeConsegneDettagliDto> GetGaPersonaleSchedeConsegneDettagliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleSchedeConsegneDettagliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleSchedeConsegneDettagliDto, PagedList<PersonaleSchedaConsegnaDettaglio>>();
            return dtos;
        }

        public async Task<PersonaleSchedaConsegnaDettaglioDto> GetGaPersonaleSchedaConsegnaDettaglioByIdAsync(long id)
        {
            var entity = await gaPersonaleSchedeConsegneDettagliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleSchedaConsegnaDettaglioDto, PersonaleSchedaConsegnaDettaglio>();
            return dto;
        }

        public async Task<long> AddGaPersonaleSchedaConsegnaDettaglioAsync(PersonaleSchedaConsegnaDettaglioDto dto)
        {
            var entity = dto.ToEntity<PersonaleSchedaConsegnaDettaglio, PersonaleSchedaConsegnaDettaglioDto>();
            await gaPersonaleSchedeConsegneDettagliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleSchedaConsegnaDettaglioAsync(PersonaleSchedaConsegnaDettaglioDto dto)
        {
            var entity = dto.ToEntity<PersonaleSchedaConsegnaDettaglio, PersonaleSchedaConsegnaDettaglioDto>();
            gaPersonaleSchedeConsegneDettagliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleSchedaConsegnaDettaglioAsync(long id)
        {
            var entity = await gaPersonaleSchedeConsegneDettagliRepo.GetByIdAsync(id);
            gaPersonaleSchedeConsegneDettagliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaPersonaleSchedaConsegnaDettaglioAsync(long id, string descrizione)
        //{
        //    var entity = await gaPersonaleSchedeConsegneDettagliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusGaPersonaleSchedaConsegnaDettaglioAsync(long id)
        //{
        //    var entity = await gaPersonaleSchedeConsegneDettagliRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        gaPersonaleSchedeConsegneDettagliRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        gaPersonaleSchedeConsegneDettagliRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPersonaleNuoveSchede>> GetViewGaPersonaleNuoveSchedeAsync()
        {
            try
            {
                return await viewGaPersonaleNuoveSchedeRepo.GetAllAsync(1, 0);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<PagedList<ViewGaPersonaleSchedeConsegne>> GetViewGaPersonaleSchedeConsegneAsync(long schedaId)
        {

            try
            {
                return await viewGaPersonaleSchedeConsegneRepo.GetWithFilterAsync(x => x.SchedaConsegnaId == schedaId);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region PersonaleArticoliModelli
        public async Task<PersonaleArticoliModelliDto> GetGaPersonaleArticoliModelliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleArticoliModelliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleArticoliModelliDto, PagedList<PersonaleArticoloModello>>();
            return dtos;
        }

        public async Task<PersonaleArticoloModelloDto> GetGaPersonaleArticoloModelloByIdAsync(long id)
        {
            var entity = await gaPersonaleArticoliModelliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleArticoloModelloDto, PersonaleArticoloModello>();
            return dto;
        }

        public async Task<long> AddGaPersonaleArticoloModelloAsync(PersonaleArticoloModelloDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticoloModello, PersonaleArticoloModelloDto>();
            await gaPersonaleArticoliModelliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleArticoloModelloAsync(PersonaleArticoloModelloDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticoloModello, PersonaleArticoloModelloDto>();
            gaPersonaleArticoliModelliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleArticoloModelloAsync(long id)
        {
            var entity = await gaPersonaleArticoliModelliRepo.GetByIdAsync(id);
            gaPersonaleArticoliModelliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleArticoloModelloAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleArticoliModelliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleArticoloModelloAsync(long id)
        {
            var entity = await gaPersonaleArticoliModelliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleArticoliModelliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleArticoliModelliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleArticoliTipologie
        public async Task<PersonaleArticoliTipologieDto> GetGaPersonaleArticoliTipologieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleArticoliTipologieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleArticoliTipologieDto, PagedList<PersonaleArticoloTipologia>>();
            return dtos;
        }

        public async Task<PersonaleArticoloTipologiaDto> GetGaPersonaleArticoloTipologiaByIdAsync(long id)
        {
            var entity = await gaPersonaleArticoliTipologieRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleArticoloTipologiaDto, PersonaleArticoloTipologia>();
            return dto;
        }

        public async Task<long> AddGaPersonaleArticoloTipologiaAsync(PersonaleArticoloTipologiaDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticoloTipologia, PersonaleArticoloTipologiaDto>();
            await gaPersonaleArticoliTipologieRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleArticoloTipologiaAsync(PersonaleArticoloTipologiaDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticoloTipologia, PersonaleArticoloTipologiaDto>();
            gaPersonaleArticoliTipologieRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleArticoloTipologiaAsync(long id)
        {
            var entity = await gaPersonaleArticoliTipologieRepo.GetByIdAsync(id);
            gaPersonaleArticoliTipologieRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleArticoloTipologiaAsync(long id, string descrizione)
        {
            var entity = await gaPersonaleArticoliTipologieRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleArticoloTipologiaAsync(long id)
        {
            var entity = await gaPersonaleArticoliTipologieRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleArticoliTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleArticoliTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleArticoliDpis
        public async Task<PersonaleArticoliDpisDto> GetGaPersonaleArticoliDpisAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleArticoliDpisRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleArticoliDpisDto, PagedList<PersonaleArticoloDpi>>();
            return dtos;
        }

        public async Task<PersonaleArticoloDpiDto> GetGaPersonaleArticoloDpiByIdAsync(long id)
        {
            var entity = await gaPersonaleArticoliDpisRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleArticoloDpiDto, PersonaleArticoloDpi>();
            return dto;
        }

        public async Task<long> AddGaPersonaleArticoloDpiAsync(PersonaleArticoloDpiDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticoloDpi, PersonaleArticoloDpiDto>();
            await gaPersonaleArticoliDpisRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleArticoloDpiAsync(PersonaleArticoloDpiDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticoloDpi, PersonaleArticoloDpiDto>();
            gaPersonaleArticoliDpisRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleArticoloDpiAsync(long id)
        {
            var entity = await gaPersonaleArticoliDpisRepo.GetByIdAsync(id);
            gaPersonaleArticoliDpisRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleArticoloDpiAsync(long id, string descrizione, string caratteristiche)
        {
            var entity = await gaPersonaleArticoliDpisRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Caratteristiche == caratteristiche && x.Id != id, 1, 0);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleArticoloDpiAsync(long id)
        {
            var entity = await gaPersonaleArticoliDpisRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleArticoliDpisRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleArticoliDpisRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PersonaleArticoli
        public async Task<PersonaleArticoliDto> GetGaPersonaleArticoliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPersonaleArticoliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PersonaleArticoliDto, PagedList<PersonaleArticolo>>();
            return dtos;
        }

        public async Task<PersonaleArticoloDto> GetGaPersonaleArticoloByIdAsync(long id)
        {
            var entity = await gaPersonaleArticoliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PersonaleArticoloDto, PersonaleArticolo>();
            return dto;
        }

        public async Task<long> AddGaPersonaleArticoloAsync(PersonaleArticoloDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticolo, PersonaleArticoloDto>();
            await gaPersonaleArticoliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPersonaleArticoloAsync(PersonaleArticoloDto dto)
        {
            var entity = dto.ToEntity<PersonaleArticolo, PersonaleArticoloDto>();
            gaPersonaleArticoliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPersonaleArticoloAsync(long id)
        {
            var entity = await gaPersonaleArticoliRepo.GetByIdAsync(id);
            gaPersonaleArticoliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPersonaleArticoloAsync(long id, long personaleArticoloModelloId, long personaleArticoloTipologiaId, long personaleArticoloDpiId)
        {
            var entity = await gaPersonaleArticoliRepo.GetWithFilterAsync(x => x.PersonaleArticoloModelloId == personaleArticoloModelloId && x.PersonaleArticoloTipologiaId == personaleArticoloTipologiaId && x.PersonaleArticoloDpiId == personaleArticoloDpiId && x.Id != id, 1, 0);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPersonaleArticoloAsync(long id)
        {
            var entity = await gaPersonaleArticoliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPersonaleArticoliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPersonaleArticoliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPersonaleArticoli>> GetViewGaPersonaleArticoliAsync()
        {
            try
            {
                return await viewGaPersonaleArticoliRepo.GetAllAsync(1, 0);
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

        #region Private Functions
        private async Task<string> GenerateNumberPersonaleSchedaConsegna(int year)
        {
            try
            {
                var entities = await gaPersonaleSchedeConsegneRepo.GetWithFilterAsync(x => x.Data.Year == year);
                int num = 0;
                if (entities.Data.Count() > 0) { num = entities.Data.Select(x => int.Parse(x.Numero.Substring(0, x.Numero.IndexOf("/")))).Max(); }
                return (Convert.ToInt32(num) + 1).ToString() + "/" + year.ToString();
            }
            catch (Exception)
            {
                return "1/" + year.ToString();
            }
        }
        #endregion



    }
}

