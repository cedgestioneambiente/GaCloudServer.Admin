using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Reclami;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaReclamiService : IGaReclamiService
    {
        protected readonly IGenericRepository<ReclamiMittente> gaReclamiMittentiRepo;
        protected readonly IGenericRepository<ReclamiStato> gaReclamiStatiRepo;
        protected readonly IGenericRepository<ReclamiTempoRisposta> gaReclamiTempiRisposteRepo;
        protected readonly IGenericRepository<ReclamiTipoAzione> gaReclamiTipiAzioniRepo;
        protected readonly IGenericRepository<ReclamiTipoOrigine> gaReclamiTipiOriginiRepo;
        protected readonly IGenericRepository<ReclamiAzione> gaReclamiAzioniRepo;
        protected readonly IGenericRepository<ReclamiDocumento> gaReclamiDocumentiRepo;

        protected readonly IGenericRepository<ViewGaReclamiDocumenti> viewGaReclamiDocumentiRepo;
        protected readonly IGenericRepository<ViewGaReclamiAzioni> viewGaReclamiAzioniRepo;
        protected readonly IGenericRepository<ViewGaReclamiRegistri> viewGaReclamiRegistriRepo;


        protected readonly IUnitOfWork unitOfWork;


        public GaReclamiService(
            IGenericRepository<ReclamiMittente> gaReclamiMittentiRepo,
            IGenericRepository<ReclamiStato> gaReclamiStatiRepo,
            IGenericRepository<ReclamiTempoRisposta> gaReclamiTempiRisposteRepo,
            IGenericRepository<ReclamiTipoAzione> gaReclamiTipiAzioniRepo,
            IGenericRepository<ReclamiTipoOrigine> gaReclamiTipiOriginiRepo,
            IGenericRepository<ReclamiAzione> gaReclamiAzioniRepo,
            IGenericRepository<ReclamiDocumento> gaReclamiDocumentiRepo,

            IGenericRepository<ViewGaReclamiDocumenti> viewGaReclamiDocumentiRepo,
            IGenericRepository<ViewGaReclamiAzioni> viewGaReclamiAzioniRepo,
            IGenericRepository<ViewGaReclamiRegistri> viewGaReclamiRegistriRepo,



        IUnitOfWork unitOfWork)
        {
            this.gaReclamiMittentiRepo = gaReclamiMittentiRepo;
            this.gaReclamiStatiRepo = gaReclamiStatiRepo;
            this.gaReclamiTempiRisposteRepo = gaReclamiTempiRisposteRepo;
            this.gaReclamiTipiAzioniRepo = gaReclamiTipiAzioniRepo;
            this.gaReclamiTipiOriginiRepo = gaReclamiTipiOriginiRepo;
            this.gaReclamiAzioniRepo = gaReclamiAzioniRepo;
            this.gaReclamiDocumentiRepo = gaReclamiDocumentiRepo;


            this.viewGaReclamiDocumentiRepo = viewGaReclamiDocumentiRepo;
            this.viewGaReclamiAzioniRepo = viewGaReclamiAzioniRepo;
            this.viewGaReclamiRegistriRepo = viewGaReclamiRegistriRepo;


            this.unitOfWork = unitOfWork;
        }

        #region ReclamiMittenti
        public async Task<ReclamiMittentiDto> GetGaReclamiMittentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaReclamiMittentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ReclamiMittentiDto, PagedList<ReclamiMittente>>();
            return dtos;
        }

        public async Task<ReclamiMittenteDto> GetGaReclamiMittenteByIdAsync(long id)
        {
            var entity = await gaReclamiMittentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ReclamiMittenteDto, ReclamiMittente>();
            return dto;
        }

        public async Task<long> AddGaReclamiMittenteAsync(ReclamiMittenteDto dto)
        {
            var entity = dto.ToEntity<ReclamiMittente, ReclamiMittenteDto>();
            await gaReclamiMittentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaReclamiMittenteAsync(ReclamiMittenteDto dto)
        {
            var entity = dto.ToEntity<ReclamiMittente, ReclamiMittenteDto>();
            gaReclamiMittentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaReclamiMittenteAsync(long id)
        {
            var entity = await gaReclamiMittentiRepo.GetByIdAsync(id);
            gaReclamiMittentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaReclamiMittenteAsync(long id, string descrizione)
        {
            var entity = await gaReclamiMittentiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaReclamiMittenteAsync(long id)
        {
            var entity = await gaReclamiMittentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaReclamiMittentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaReclamiMittentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ReclamiStati
        public async Task<ReclamiStatiDto> GetGaReclamiStatiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaReclamiStatiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ReclamiStatiDto, PagedList<ReclamiStato>>();
            return dtos;
        }

        public async Task<ReclamiStatoDto> GetGaReclamiStatoByIdAsync(long id)
        {
            var entity = await gaReclamiStatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ReclamiStatoDto, ReclamiStato>();
            return dto;
        }

        public async Task<long> AddGaReclamiStatoAsync(ReclamiStatoDto dto)
        {
            var entity = dto.ToEntity<ReclamiStato, ReclamiStatoDto>();
            await gaReclamiStatiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaReclamiStatoAsync(ReclamiStatoDto dto)
        {
            var entity = dto.ToEntity<ReclamiStato, ReclamiStatoDto>();
            gaReclamiStatiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaReclamiStatoAsync(long id)
        {
            var entity = await gaReclamiStatiRepo.GetByIdAsync(id);
            gaReclamiStatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaReclamiStatoAsync(long id, string descrizione)
        {
            var entity = await gaReclamiStatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaReclamiStatoAsync(long id)
        {
            var entity = await gaReclamiStatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaReclamiStatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaReclamiStatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ReclamiTempiRisposte
        public async Task<ReclamiTempiRisposteDto> GetGaReclamiTempiRisposteAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaReclamiTempiRisposteRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ReclamiTempiRisposteDto, PagedList<ReclamiTempoRisposta>>();
            return dtos;
        }

        public async Task<ReclamiTempoRispostaDto> GetGaReclamiTempoRispostaByIdAsync(long id)
        {
            var entity = await gaReclamiTempiRisposteRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ReclamiTempoRispostaDto, ReclamiTempoRisposta>();
            return dto;
        }

        public async Task<long> AddGaReclamiTempoRispostaAsync(ReclamiTempoRispostaDto dto)
        {
            var entity = dto.ToEntity<ReclamiTempoRisposta, ReclamiTempoRispostaDto>();
            await gaReclamiTempiRisposteRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaReclamiTempoRispostaAsync(ReclamiTempoRispostaDto dto)
        {
            var entity = dto.ToEntity<ReclamiTempoRisposta, ReclamiTempoRispostaDto>();
            gaReclamiTempiRisposteRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaReclamiTempoRispostaAsync(long id)
        {
            var entity = await gaReclamiTempiRisposteRepo.GetByIdAsync(id);
            gaReclamiTempiRisposteRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaReclamiTempoRispostaAsync(long id, string descrizione)
        {
            var entity = await gaReclamiTempiRisposteRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaReclamiTempoRispostaAsync(long id)
        {
            var entity = await gaReclamiTempiRisposteRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaReclamiTempiRisposteRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaReclamiTempiRisposteRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ReclamiTipiAzioni
        public async Task<ReclamiTipiAzioniDto> GetGaReclamiTipiAzioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaReclamiTipiAzioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ReclamiTipiAzioniDto, PagedList<ReclamiTipoAzione>>();
            return dtos;
        }

        public async Task<ReclamiTipoAzioneDto> GetGaReclamiTipoAzioneByIdAsync(long id)
        {
            var entity = await gaReclamiTipiAzioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ReclamiTipoAzioneDto, ReclamiTipoAzione>();
            return dto;
        }

        public async Task<long> AddGaReclamiTipoAzioneAsync(ReclamiTipoAzioneDto dto)
        {
            var entity = dto.ToEntity<ReclamiTipoAzione, ReclamiTipoAzioneDto>();
            await gaReclamiTipiAzioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaReclamiTipoAzioneAsync(ReclamiTipoAzioneDto dto)
        {
            var entity = dto.ToEntity<ReclamiTipoAzione, ReclamiTipoAzioneDto>();
            gaReclamiTipiAzioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaReclamiTipoAzioneAsync(long id)
        {
            var entity = await gaReclamiTipiAzioniRepo.GetByIdAsync(id);
            gaReclamiTipiAzioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaReclamiTipoAzioneAsync(long id, string descrizione)
        {
            var entity = await gaReclamiTipiAzioniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaReclamiTipoAzioneAsync(long id)
        {
            var entity = await gaReclamiTipiAzioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaReclamiTipiAzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaReclamiTipiAzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ReclamiTipiOrigini
        public async Task<ReclamiTipiOriginiDto> GetGaReclamiTipiOriginiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaReclamiTipiOriginiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ReclamiTipiOriginiDto, PagedList<ReclamiTipoOrigine>>();
            return dtos;
        }

        public async Task<ReclamiTipoOrigineDto> GetGaReclamiTipoOrigineByIdAsync(long id)
        {
            var entity = await gaReclamiTipiOriginiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ReclamiTipoOrigineDto, ReclamiTipoOrigine>();
            return dto;
        }

        public async Task<long> AddGaReclamiTipoOrigineAsync(ReclamiTipoOrigineDto dto)
        {
            var entity = dto.ToEntity<ReclamiTipoOrigine, ReclamiTipoOrigineDto>();
            await gaReclamiTipiOriginiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaReclamiTipoOrigineAsync(ReclamiTipoOrigineDto dto)
        {
            var entity = dto.ToEntity<ReclamiTipoOrigine, ReclamiTipoOrigineDto>();
            gaReclamiTipiOriginiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaReclamiTipoOrigineAsync(long id)
        {
            var entity = await gaReclamiTipiOriginiRepo.GetByIdAsync(id);
            gaReclamiTipiOriginiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaReclamiTipoOrigineAsync(long id, string descrizione)
        {
            var entity = await gaReclamiTipiOriginiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaReclamiTipoOrigineAsync(long id)
        {
            var entity = await gaReclamiTipiOriginiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaReclamiTipiOriginiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaReclamiTipiOriginiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ReclamiAzioni
        public async Task<ReclamiAzioniDto> GetGaReclamiAzioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaReclamiAzioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ReclamiAzioniDto, PagedList<ReclamiAzione>>();
            return dtos;
        }

        public async Task<ReclamiAzioneDto> GetGaReclamiAzioneByIdAsync(long id)
        {
            var entity = await gaReclamiAzioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ReclamiAzioneDto, ReclamiAzione>();
            return dto;
        }

        public async Task<long> AddGaReclamiAzioneAsync(ReclamiAzioneDto dto)
        {
                var entity = dto.ToEntity<ReclamiAzione, ReclamiAzioneDto>();
                await gaReclamiAzioniRepo.AddAsync(entity);
                await SaveChanges();
                DetachEntity(entity);

                if (entity.Risposta)
                {
                    var list = await gaReclamiAzioniRepo.GetWithFilterAsync(x => x.ReclamiDocumentoId == dto.ReclamiDocumentoId && x.Id != entity.Id);
                    foreach (var itm in list.Data)
                    {
                        itm.Risposta = false;
                        gaReclamiAzioniRepo.Update(itm);
                    }
                    var reclamo = await gaReclamiDocumentiRepo.GetSingleWithFilter(x => x.Id == dto.ReclamiDocumentoId);
                    reclamo.RispostaInviata = dto.Data;
                    reclamo.RispostaDefinitiva = dto.RispostaDefinitiva;
                    gaReclamiDocumentiRepo.Update(reclamo);
                    await SaveChanges();
                }
                else
                {
                    var risposta = await gaReclamiAzioniRepo.GetSingleWithFilter(x => x.Risposta == true && x.ReclamiDocumentoId == dto.ReclamiDocumentoId);
                    if (risposta == null)
                    {
                        var reclamo = await gaReclamiDocumentiRepo.GetSingleWithFilter(x => x.Id == entity.ReclamiDocumentoId);
                        reclamo.RispostaInviata = null;
                        reclamo.RispostaDefinitiva = null;
                        gaReclamiDocumentiRepo.Update(reclamo);
                        await SaveChanges();
                    }
                }

                return entity.Id;
        }

        public async Task<long> UpdateGaReclamiAzioneAsync(ReclamiAzioneDto dto)
        {
                var original = gaReclamiAzioniRepo.GetByIdAsNoTraking(x => x.Id == dto.Id);
                var entity = dto.ToEntity<ReclamiAzione, ReclamiAzioneDto>();
                gaReclamiAzioniRepo.Update(entity);
                await SaveChanges();
                DetachEntity(entity);

                if (entity.Risposta)
                {
                    var list = await gaReclamiAzioniRepo.GetWithFilterAsync(x => x.ReclamiDocumentoId == dto.ReclamiDocumentoId && x.Id != dto.Id);
                    foreach (var itm in list.Data)
                    {
                        itm.Risposta = false;
                        gaReclamiAzioniRepo.Update(itm);
                    }
                    var Reclami = await gaReclamiDocumentiRepo.GetSingleWithFilter(x => x.Id == dto.ReclamiDocumentoId);
                    Reclami.RispostaInviata = dto.Data;
                    Reclami.RispostaDefinitiva = dto.RispostaDefinitiva;
                    gaReclamiDocumentiRepo.Update(Reclami);
                    await SaveChanges();
                }
                else
                {
                    var risposta = await gaReclamiAzioniRepo.GetSingleWithFilter(x => x.Risposta == true && x.ReclamiDocumentoId == dto.ReclamiDocumentoId);
                    if (risposta == null)
                    {
                        var Reclami = await gaReclamiDocumentiRepo.GetSingleWithFilter(x => x.Id == entity.ReclamiDocumentoId);
                        Reclami.RispostaInviata = null;
                        Reclami.RispostaDefinitiva = null;
                        gaReclamiDocumentiRepo.Update(Reclami);
                        await SaveChanges();
                    }
                }

                return entity.Id;

        }

        public async Task<bool> DeleteGaReclamiAzioneAsync(long id)
        {
            var entity = await gaReclamiAzioniRepo.GetByIdAsync(id);
            gaReclamiAzioniRepo.Remove(entity);
            if (entity.Risposta)
            {
                var reclamo = gaReclamiDocumentiRepo.GetById(entity.ReclamiDocumentoId);
                reclamo.RispostaInviata = null;
                reclamo.RispostaDefinitiva = null;
                gaReclamiDocumentiRepo.Update(reclamo);
            }
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaReclamiAzioneAsync(long id, string descrizione)
        {
            var entity = await gaReclamiAzioniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaReclamiAzioneAsync(long id)
        {
            var entity = await gaReclamiAzioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaReclamiAzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaReclamiAzioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaReclamiAzioni>> GetViewGaReclamiAzioniByReclamoIdAsync(long reclamiDocumentoId)
        {
            try
            {
                return await viewGaReclamiAzioniRepo.GetWithFilterAsync(x => x.ReclamiDocumentoId == reclamiDocumentoId);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region ReclamiDocumenti
        public async Task<ReclamiDocumentiDto> GetGaReclamiDocumentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaReclamiDocumentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ReclamiDocumentiDto, PagedList<ReclamiDocumento>>();
            return dtos;
        }

        public async Task<ReclamiDocumentoDto> GetGaReclamiDocumentoByIdAsync(long id)
        {
            var entity = await gaReclamiDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ReclamiDocumentoDto, ReclamiDocumento>();
            return dto;
        }

        public async Task<long> AddGaReclamiDocumentoAsync(ReclamiDocumentoDto dto)
        {
            var entity = dto.ToEntity<ReclamiDocumento, ReclamiDocumentoDto>();

            entity.ReclamiDocumentoId = CreateReclamoId(entity.OrigineData);
            entity.RispostaEntroData = CalcDate(entity.OrigineData, entity.ReclamiTempoRispostaId);

            await gaReclamiDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaReclamiDocumentoAsync(ReclamiDocumentoDto dto)
        {
            var original = gaReclamiDocumentiRepo.GetByIdAsNoTraking(x => x.Id == dto.Id);

            var entity = dto.ToEntity<ReclamiDocumento, ReclamiDocumentoDto>();
            entity.RispostaEntroData = CalcDate(entity.OrigineData, entity.ReclamiTempoRispostaId);

            gaReclamiDocumentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaReclamiDocumentoAsync(long id)
        {
            var entity = await gaReclamiDocumentiRepo.GetByIdAsync(id);
            gaReclamiDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaReclamiDocumentoAsync(long id, string oggetto)
        {
            var entity = await gaReclamiDocumentiRepo.GetWithFilterAsync(x => x.Oggetto == oggetto && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaReclamiDocumentoAsync(long id)
        {
            var entity = await gaReclamiDocumentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaReclamiDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaReclamiDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<List<int>> GetGaReclamiAnni()
        {
            try
            {
                var entities = await viewGaReclamiDocumentiRepo.GetAllAsync();
                var anni = from x in entities.Data
                           select x.OrigineReclamiData.Year;
                anni = anni.Distinct();
                return anni.ToList();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }


        #endregion

        #region Views
        public async Task<PagedList<ViewGaReclamiDocumenti>> GetViewGaReclamiDocumentiAsync()
        {
            try
            {
                return await viewGaReclamiDocumentiRepo.GetAllAsync(1, 0, "OrigineReclamiData", "OrderByDescending");
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<List<ViewGaReclamiRegistri>> GetGaReclamiRegistriAsync(int anno)
        {;
            try
            {
                var entities = await viewGaReclamiRegistriRepo.GetWithFilterAsync(x => x.Data.Year == anno);
                return entities.Data.ToList();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<List<ViewGaReclamiDocumenti>> ExportGaReclamiDocumentiAsync()
        {
            try
            {
                var entity = await viewGaReclamiDocumentiRepo.GetAllAsync();

                return entity.Data.ToList();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #region Helpers
        public string CreateReclamoId(DateTime date)
        {
            var list = gaReclamiDocumentiRepo.GetWithFilter(x => x.OrigineData.Year == date.Year).ToList();
            int num = 0;
            if (list.Count() > 0) { num = list.Select(x => int.Parse(x.ReclamiDocumentoId.Replace("/" + date.Year.ToString(), ""))).Max(); }
            return (Convert.ToInt32(num) + 1).ToString() + "/" + date.Year.ToString();
        }

        public DateTime CalcDate(DateTime date, long id)
        {
            int gg = gaReclamiTempiRisposteRepo.GetSingleWithFilter(x => x.Id == id).Result.Giorni;
            return date.AddDays(gg);
        }

        public string CreateAzioni(long id)
        {
            string strAzioni = "";
            var azioni = gaReclamiAzioniRepo.GetWithFilter(x => x.ReclamiDocumentoId == id);
            foreach (var a in azioni)
            {
                strAzioni += GetAzioniDescrizioneBreve(a.ReclamiTipoAzioneId) + ": " + a.Descrizione + ";";
            }
            return strAzioni.Length > 1 ? strAzioni.Remove(strAzioni.Length - 1) : strAzioni;
        }

        public string GetAzioniDescrizioneBreve(long id)
        {
            return gaReclamiTipiAzioniRepo.GetById(id).DescrizioneBreve;
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
