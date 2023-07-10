using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;


namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaCdrService : IGaCdrService
    {
        protected readonly IGenericRepository<CdrCentro> gaCdrCentriRepo;
        protected readonly IGenericRepository<CdrComune> gaCdrComuniRepo;
        protected readonly IGenericRepository<CdrCer> gaCdrCersRepo;
        protected readonly IGenericRepository<CdrCerDettaglio> gaCdrCersDettagliRepo;
        protected readonly IGenericRepository<CdrCerOnCentro> gaCdrCersOnCentriRepo;
        protected readonly IGenericRepository<CdrComuneOnCentro> gaCdrComuniOnCentriRepo;
        protected readonly IGenericRepository<CdrConferimento> gaCdrConferimentiRepo;
        protected readonly IGenericRepository<CdrRichiestaViaggio> gaCdrRichiesteViaggiRepo;
        protected readonly IGenericRepository<CdrStatoRichiesta> gaCdrStatiRichiesteRepo;
        protected readonly IGenericRepository<CdrUtente> gaCdrUtentiRepo;

        protected readonly IGenericRepository<ViewGaCdrCersOnCentri> viewGaCdrCersOnCentriRepo;
        protected readonly IGenericRepository<ViewGaCdrComuniOnCentri> viewGaCdrComuniOnCentriRepo;
        protected readonly IGenericRepository<ViewGaCdrComuni> viewGaCdrComuniRepo;
        protected readonly IGenericRepository<ViewGaCdrConferimenti> viewGaCdrConferimentiRepo;
        protected readonly IGenericRepository<ViewGaCdrRichiesteViaggi> viewGaCdrRichiesteViaggiRepo;
        protected readonly IGenericRepository<ViewGaCdrUtenti> viewGaCdrUtentiRepo;


        protected readonly IUnitOfWork unitOfWork;

        public GaCdrService(
            IGenericRepository<CdrCentro> gaCdrCentriRepo,
            IGenericRepository<CdrComune> gaCdrComuniRepo,
            IGenericRepository<CdrCer> gaCdrCersRepo,
            IGenericRepository<CdrCerDettaglio> gaCdrCersDettagliRepo,
            IGenericRepository<CdrCerOnCentro> gaCdrCersOnCentriRepo,
            IGenericRepository<CdrComuneOnCentro> gaCdrComuniOnCentriRepo,
            IGenericRepository<CdrConferimento> gaCdrConferimentiRepo,
            IGenericRepository<CdrRichiestaViaggio> gaCdrRichiesteViaggiRepo,
            IGenericRepository<CdrStatoRichiesta> gaCdrStatiRichiesteRepo,
            IGenericRepository<CdrUtente> gaCdrUtentiRepo,

            IGenericRepository<ViewGaCdrCersOnCentri> viewGaCdrCersOnCentriRepo,
            IGenericRepository<ViewGaCdrComuniOnCentri> viewGaCdrComuniOnCentriRepo,
            IGenericRepository<ViewGaCdrComuni> viewGaCdrComuniRepo,
            IGenericRepository<ViewGaCdrConferimenti> viewGaCdrConferimentiRepo,
            IGenericRepository<ViewGaCdrRichiesteViaggi> viewGaCdrRichiesteViaggiRepo,
            IGenericRepository<ViewGaCdrUtenti> viewGaCdrUtentiRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaCdrCentriRepo = gaCdrCentriRepo;
            this.gaCdrComuniRepo = gaCdrComuniRepo;
            this.gaCdrCersRepo = gaCdrCersRepo;
            this.gaCdrCersDettagliRepo = gaCdrCersDettagliRepo;
            this.gaCdrCersOnCentriRepo = gaCdrCersOnCentriRepo;
            this.gaCdrComuniOnCentriRepo = gaCdrComuniOnCentriRepo;
            this.gaCdrConferimentiRepo = gaCdrConferimentiRepo;
            this.gaCdrRichiesteViaggiRepo = gaCdrRichiesteViaggiRepo;
            this.gaCdrStatiRichiesteRepo = gaCdrStatiRichiesteRepo;
            this.gaCdrUtentiRepo = gaCdrUtentiRepo;

            this.viewGaCdrCersOnCentriRepo = viewGaCdrCersOnCentriRepo;
            this.viewGaCdrComuniOnCentriRepo = viewGaCdrComuniOnCentriRepo;
            this.viewGaCdrComuniRepo = viewGaCdrComuniRepo;
            this.viewGaCdrConferimentiRepo = viewGaCdrConferimentiRepo;
            this.viewGaCdrRichiesteViaggiRepo = viewGaCdrRichiesteViaggiRepo;
            this.viewGaCdrUtentiRepo = viewGaCdrUtentiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region CdrCentri
        public async Task<CdrCentriDto> GetGaCdrCentriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrCentriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCentriDto, PagedList<CdrCentro>>();
            return dtos;
        }

        public async Task<CdrCentroDto> GetGaCdrCentroByIdAsync(long id)
        {
            var entity = await gaCdrCentriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrCentroDto, CdrCentro>();
            return dto;
        }

        public async Task<long> AddGaCdrCentroAsync(CdrCentroDto dto)
        {
            var entity = dto.ToEntity<CdrCentro, CdrCentroDto>();
            await gaCdrCentriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrCentroAsync(CdrCentroDto dto)
        {
            var entity = dto.ToEntity<CdrCentro, CdrCentroDto>();
            gaCdrCentriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrCentroAsync(long id)
        {
            var entity = await gaCdrCentriRepo.GetByIdAsync(id);
            gaCdrCentriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrCentroAsync(long id, string centro)
        {
            var entity = await gaCdrCentriRepo.GetWithFilterAsync(x => x.Centro == centro && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrCentroAsync(long id)
        {
            var entity = await gaCdrCentriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrCentriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrCentriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CdrComuni
        public async Task<CdrComuniDto> GetGaCdrComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrComuniDto, PagedList<CdrComune>>();
            return dtos;
        }

        public async Task<CdrComuneDto> GetGaCdrComuneByIdAsync(long id)
        {
            var entity = await gaCdrComuniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrComuneDto, CdrComune>();
            return dto;
        }

        public async Task<long> AddGaCdrComuneAsync(CdrComuneDto dto)
        {
            var entity = dto.ToEntity<CdrComune, CdrComuneDto>();
            await gaCdrComuniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrComuneAsync(CdrComuneDto dto)
        {
            var entity = dto.ToEntity<CdrComune, CdrComuneDto>();
            gaCdrComuniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrComuneAsync(long id)
        {
            var entity = await gaCdrComuniRepo.GetByIdAsync(id);
            gaCdrComuniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrComuneAsync(long id, string centro)
        {
            var entity = await gaCdrComuniRepo.GetWithFilterAsync(x => x.Comune == centro && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrComuneAsync(long id)
        {
            var entity = await gaCdrComuniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        //public async Task<PagedList<ViewGaCdrComuni>> GetViewGaCdrComuniAsync(bool all = true)
        //{
        //    var entities = all ? await viewGaCdrComuniRepo.GetAllAsync(1, 0) : await viewGaCdrComuniRepo.GetWithFilterAsync(x => x.Disabled == false);
        //    return entities;
        //}

        #endregion

        #endregion

        #region CdrCers
        public async Task<CdrCersDto> GetGaCdrCersAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrCersRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCersDto, PagedList<CdrCer>>();
            return dtos;
        }

        public async Task<CdrCerDto> GetGaCdrCerByIdAsync(long id)
        {
            var entity = await gaCdrCersRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrCerDto, CdrCer>();
            return dto;
        }

        public async Task<long> AddGaCdrCerAsync(CdrCerDto dto)
        {
            var entity = dto.ToEntity<CdrCer, CdrCerDto>();
            await gaCdrCersRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrCerAsync(CdrCerDto dto)
        {
            var entity = dto.ToEntity<CdrCer, CdrCerDto>();
            gaCdrCersRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrCerAsync(long id)
        {
            var entity = await gaCdrCersRepo.GetByIdAsync(id);
            gaCdrCersRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrCerAsync(long id, string cer)
        {
            var entity = await gaCdrCersRepo.GetWithFilterAsync(x => x.Cer == cer && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrCerAsync(long id)
        {
            var entity = await gaCdrCersRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CdrCersDettagli
        public async Task<CdrCersDettagliDto> GetGaCdrCersDettagliAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrCersDettagliRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCersDettagliDto, PagedList<CdrCerDettaglio>>();
            return dtos;
        }

        public async Task<CdrCersDettagliDto> GetGaCdrCersDettagliByCerIdAsync(long cerId)
        {
            var entities = await gaCdrCersDettagliRepo.GetWithFilterAsync(x=>x.CdrCerId==cerId);
            var dtos = entities.ToDto<CdrCersDettagliDto, PagedList<CdrCerDettaglio>>();
            return dtos;
        }

        public async Task<CdrCerDettaglioDto> GetGaCdrCerDettaglioByIdAsync(long id)
        {
            var entity = await gaCdrCersDettagliRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrCerDettaglioDto, CdrCerDettaglio>();
            return dto;
        }

        public async Task<long> AddGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto)
        {
            var entity = dto.ToEntity<CdrCerDettaglio, CdrCerDettaglioDto>();
            await gaCdrCersDettagliRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto)
        {
            var entity = dto.ToEntity<CdrCerDettaglio, CdrCerDettaglioDto>();
            gaCdrCersDettagliRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrCerDettaglioAsync(long id)
        {
            var entity = await gaCdrCersDettagliRepo.GetByIdAsync(id);
            gaCdrCersDettagliRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrCerDettaglioAsync(long id, string descrizione)
        {
            var entity = await gaCdrCersDettagliRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrCerDettaglioAsync(long id)
        {
            var entity = await gaCdrCersDettagliRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrCersDettagliRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrCersDettagliRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CdrCersOnCentri

        public async Task<CdrCersDto> GetGaCdrCersOnCentriAsync(long id)
        {
            throw new NotImplementedException();
        //        var entities = await gaCdrCersOnCentriRepo.GetWithFilterAsync(x => x.CdrCentroId == id, 1, 0);

        //        var cers = await gaCdrCersRepo.GetAllAsync(1, 0);
        //        var dtos = cers.ToDto<CdrCersDto, PagedList<CdrCer>>();
        //        var data = from x in dtos.Data
        //                   where entities.Data.Any(s => s.CdrCerId == x.Id)
        //                   select x;

        //        var response = new CdrCersDto();
        //        response.TotalCount = data.Count();
        //        response.PageSize = 0;
        //        response.Data = data.ToList();

        }

        public async Task<bool> UpdateGaCdrCerOnCentroAsync(long cerId, long centroId)
        {
            var exists = await gaCdrCersOnCentriRepo.CheckIfExist(x => x.CdrCerId == cerId && x.CdrCentroId == centroId);
            if (exists)
            {
                var entity = await gaCdrCersOnCentriRepo.GetSingleWithFilter(x => x.CdrCerId == cerId && x.CdrCentroId == centroId);
                gaCdrCersOnCentriRepo.Remove(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                var entity = new CdrCerOnCentro();
                entity.CdrCentroId = centroId;
                entity.CdrCerId = cerId;
                gaCdrCersOnCentriRepo.Add(entity);
                await SaveChanges();
                return true;
            }
        }

        #region Views
        public async Task<PagedList<ViewGaCdrCersOnCentri>> GetViewGaCdrCersOnCentriAsync(long id)
        {
            var entities = await viewGaCdrCersOnCentriRepo.GetWithFilterAsync(x => x.CentroId == id, 1, 0);
            return entities;
        }

        #endregion

        #endregion

        #region CdrComuniOnCentri

        public async Task<bool> UpdateGaCdrComuneOnCentroAsync(long comuneId,long centroId)
        {
            var exists=await gaCdrComuniOnCentriRepo.CheckIfExist(x => x.CdrComuneId == comuneId && x.CdrCentroId == centroId);
            if (exists)
            {
                var entity = await gaCdrComuniOnCentriRepo.GetSingleWithFilter(x => x.CdrComuneId == comuneId && x.CdrCentroId == centroId);
                gaCdrComuniOnCentriRepo.Remove(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                var entity = new CdrComuneOnCentro();
                entity.CdrCentroId = centroId;
                entity.CdrComuneId = comuneId;
                gaCdrComuniOnCentriRepo.Add(entity);
                await SaveChanges();
                return true;
            }
        }


        #region Views
        public async Task<PagedList<ViewGaCdrComuniOnCentri>> GetViewGaCdrComuniOnCentriAsync(long id)
        {
            var entities = await viewGaCdrComuniOnCentriRepo.GetWithFilterAsync(x => x.CentroId == id, 1, 0);
            return entities;
        }

        #endregion

        #endregion

        #region CdrConferimenti
        public async Task<CdrConferimentiDto> GetGaCdrConferimentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrConferimentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrConferimentiDto, PagedList<CdrConferimento>>();
            return dtos;
        }

        public async Task<CdrConferimentoDto> GetGaCdrConferimentoByIdAsync(long id)
        {
            var entity = await gaCdrConferimentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrConferimentoDto, CdrConferimento>();
            return dto;
        }

        public async Task<long> AddGaCdrConferimentoAsync(CdrConferimentoDto dto)
        {
            var entity = dto.ToEntity<CdrConferimento, CdrConferimentoDto>();
            await gaCdrConferimentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrConferimentoAsync(CdrConferimentoDto dto)
        {
            var entity = dto.ToEntity<CdrConferimento, CdrConferimentoDto>();
            gaCdrConferimentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrConferimentoAsync(long id)
        {
            var entity = await gaCdrConferimentiRepo.GetByIdAsync(id);
            gaCdrConferimentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<int> ValidateGaCdrConferimentoAsync(CdrConferimentoDto dto)
        {
            //Legenda:
            //1: Limite Inerti 170107(id 8)-Alert
            //2: Limite Inerti 170107(id 8)-Raggiunto
            //3: Limite Inerti 170107(id 8)-Superato
            if (dto.CdrCerId == 8)
            {
                var limite170107 = await gaCdrConferimentiRepo.GetWithFilterAsync(x => x.CdrUtenteId == dto.CdrUtenteId && x.CdrCentroId == dto.CdrCentroId && x.CdrCerId == 8 && x.Data.Year == dto.Data.Year);

                if (limite170107.Data.Count == 3)
                {
                    return 1;
                }

                if (limite170107.Data.Count == 4)
                {
                    return 2;
                }

                if (limite170107.Data.Count > 4)
                {
                    return 3;
                }
            }

            if (dto.CdrCerId == 31)
            {
                //4: Limite Deiezioni Canine 200301 - Alert
                var dateStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                var dateEnd = DateTime.Now.EndOfWeek(DayOfWeek.Sunday);

                var limite200301 = await gaCdrConferimentiRepo.GetWithFilterAsync(x => x.CdrUtenteId == dto.CdrUtenteId && x.CdrCerId == 31 && (x.Data >= dateStart && x.Data <= dateEnd));
                if (limite200301.Data.Count > 0)
                {
                    return 4;
                }
            }

            if (dto.CdrCerId == 7)
            {
                //5: Limite Pneumatici 160103 - Alert(id:7)
                //6: Limite Pneumatici 160103 - Raggiunto(id:7)
                //7: Limite Pneumatici 160103 - Superato(id:7)
                var limite160103 = await gaCdrConferimentiRepo.GetWithFilterAsync(x => x.CdrUtenteId == dto.CdrUtenteId && x.CdrCerId == 7 && x.Data.Year == dto.Data.Year);

                if (limite160103.Data.Count > 0)
                {
                    var qta = 0;
                    foreach (var itm in limite160103.Data)
                    {
                        qta += itm.Quantita;
                    }
                    qta = qta + dto.Quantita;

                    if (qta == 4)//????
                    {
                        return 5;
                    }

                    if (qta == 5)
                    {
                        return 6;
                    }

                    if (qta > 5)
                    {
                        return 7;
                    }
                }
            }

            if (dto.Targa != "" && dto.Noleggio != true)//???
            {
                //8: Limite Accessi - Alert
                //9: Limite Accessi - Raggiunto
                //10: Limite Accessi - Superato
                var limiteAccessi = await gaCdrConferimentiRepo.GetWithFilterAsync(x => x.Data.Year == dto.Data.Year && x.CdrCentroId == dto.CdrCentroId && (x.Targa != "" && x.Targa == dto.Targa) && x.Noleggio == false);
                var accessi = (from x in limiteAccessi.Data
                               select x.Data.ToString("dd/MM/yyyy")).Distinct();


                if (accessi.Count() == 4)
                {
                    return 8;
                }

                if (accessi.Count() == 5)
                {
                    return 9;
                }

                if (accessi.Count() >= 6)
                {
                    return 10;
                }

                var limiteAccessiUtente = await gaCdrConferimentiRepo.GetWithFilterAsync(x => x.Data.Year == dto.Data.Year && x.CdrCentroId == dto.CdrCentroId && (x.Targa != "" && x.CdrUtenteId == dto.CdrUtenteId) && x.Noleggio == false);
                var accessiUtente = (from x in limiteAccessiUtente.Data
                                     select x.Data.ToString("dd/MM/yyyy")).Distinct();


                if (accessiUtente.Count() == 4)
                {
                    return 11;
                }

                if (accessiUtente.Count() == 5)
                {
                    return 12;
                }

                if (accessiUtente.Count() >= 6)
                {
                    return 13;
                }

            }

            return 0;


        }
        #endregion

        #region Views
        public PagedList<ViewGaCdrConferimenti> GetViewGaCdrConferimentiQueryable(GridOperationsModel filterParams)
        {
                if (!string.IsNullOrWhiteSpace(filterParams.quickFilter))
                {
                    var filterResult = viewGaCdrConferimentiRepo.GetAllQueryableV2WithQuickFilter(filterParams, filterParams.quickFilter);
                    return filterResult;
                }
                else
                {
                    var filterResult = viewGaCdrConferimentiRepo.GetAllQueryableV2(filterParams);
                    return filterResult;
                }
        }

        public async Task<PagedList<ViewGaCdrConferimenti>> GetViewGaCdrConferimentiAsync(string numCon, string partita)
        {
            try
            {
                return await viewGaCdrConferimentiRepo.GetWithFilterAsync(x => x.NumCon == numCon && x.Partita == partita, 1, 0, "Data", "OrderByDescending");

            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion


        #endregion

        #region CdrRichiesteViaggi
        public async Task<CdrRichiesteViaggiDto> GetGaCdrRichiesteViaggiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrRichiesteViaggiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrRichiesteViaggiDto, PagedList<CdrRichiestaViaggio>>();
            return dtos;
        }

        public async Task<CdrRichiestaViaggioDto> GetGaCdrRichiestaViaggioByIdAsync(long id)
        {
            var entity = await gaCdrRichiesteViaggiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrRichiestaViaggioDto, CdrRichiestaViaggio>();
            return dto;
        }

        public async Task<long> AddGaCdrRichiestaViaggioAsync(CdrRichiestaViaggioDto dto)
        {
            var entity = dto.ToEntity<CdrRichiestaViaggio, CdrRichiestaViaggioDto>();
            await gaCdrRichiesteViaggiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrRichiestaViaggioAsync(CdrRichiestaViaggioDto dto)
        {
            var entity = dto.ToEntity<CdrRichiestaViaggio, CdrRichiestaViaggioDto>();
            gaCdrRichiesteViaggiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrRichiestaViaggioAsync(long id)
        {
            var entity = await gaCdrRichiesteViaggiRepo.GetByIdAsync(id);
            gaCdrRichiesteViaggiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> SetGaCdrRichiestaViaggioSendedAsync(long id)
        {
            var entity = await gaCdrRichiesteViaggiRepo.GetByIdAsync(id);
            if (entity.Inviata)
            {
                entity.Inviata = false;
                gaCdrRichiesteViaggiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Inviata = true;
                gaCdrRichiesteViaggiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
        }
        #endregion

        #region Views
        public PagedList<ViewGaCdrRichiesteViaggi> GetViewGaCdrRichiesteViaggiQueryable(GridOperationsModel filterParams)
        {
                if (!string.IsNullOrWhiteSpace(filterParams.quickFilter))
                {
                    var filterResult = viewGaCdrRichiesteViaggiRepo.GetAllQueryableV2WithQuickFilter(filterParams, filterParams.quickFilter);
                    return filterResult;
                }
                else
                {
                    var filterResult = viewGaCdrRichiesteViaggiRepo.GetAllQueryableV2(filterParams);
                    return filterResult;
                }

        }

        public async Task<PagedList<ViewGaCdrRichiesteViaggi>> GetViewGaCdrRichiesteViaggi(long centroId, bool all)
        {
            try
            {
                if (all)
                {
                    return await viewGaCdrRichiesteViaggiRepo.GetWithFilterAsync(x => x.CentroId == centroId, 1, 0, "Data", "OrderByDescending");
                }
                else
                {
                    return await viewGaCdrRichiesteViaggiRepo.GetWithFilterAsync(x => x.CentroId == centroId && (x.StatoRichiestaId != -2 && x.StatoRichiestaId != 3), 1, 0, "Data", "OrderByDescending");
                }

            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<PagedList<ViewGaCdrRichiesteViaggi>> GetViewGaCdrRichiesteViaggi(long centroId, bool all, int currentPage)
        {
            try
            {
                if (all)
                {
                    return await viewGaCdrRichiesteViaggiRepo.GetWithFilterAsync(x => x.CentroId == centroId, currentPage, 100, "Data", "OrderByDescending");
                }
                else
                {
                    return await viewGaCdrRichiesteViaggiRepo.GetWithFilterAsync(x => x.CentroId == centroId && (x.StatoRichiestaId != -2 && x.StatoRichiestaId != 3), currentPage, 100, "Data", "OrderByDescending");
                }

            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<ViewGaCdrRichiesteViaggi> GetViewGaCdrRichiestaViaggio(long id)
        {
            try
            {
                return await viewGaCdrRichiesteViaggiRepo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion
        #endregion

        #region CdrStatiRichieste
        public async Task<CdrStatiRichiesteDto> GetGaCdrStatiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCdrStatiRichiesteRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrStatiRichiesteDto, PagedList<CdrStatoRichiesta>>();
            return dtos;
        }

        public async Task<CdrStatoRichiestaDto> GetGaCdrStatoRichiestaByIdAsync(long id)
        {
            var entity = await gaCdrStatiRichiesteRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CdrStatoRichiestaDto, CdrStatoRichiesta>();
            return dto;
        }

        public async Task<long> AddGaCdrStatoRichiestaAsync(CdrStatoRichiestaDto dto)
        {
            var entity = dto.ToEntity<CdrStatoRichiesta, CdrStatoRichiestaDto>();
            await gaCdrStatiRichiesteRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCdrStatoRichiestaAsync(CdrStatoRichiestaDto dto)
        {
            var entity = dto.ToEntity<CdrStatoRichiesta, CdrStatoRichiestaDto>();
            gaCdrStatiRichiesteRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCdrStatoRichiestaAsync(long id)
        {
            var entity = await gaCdrStatiRichiesteRepo.GetByIdAsync(id);
            gaCdrStatiRichiesteRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCdrStatoRichiestaAsync(long id, string descrizione)
        {
            var entity = await gaCdrStatiRichiesteRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCdrStatoRichiestaAsync(long id)
        {
            var entity = await gaCdrStatiRichiesteRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCdrStatiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCdrStatiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region App
        public async Task<bool> CheckGaCdrCanUse(string comune, long centroId)
        {
            var entities = await viewGaCdrComuniOnCentriRepo.GetWithFilterAsync(x=>x.CentroId==centroId && x.Comune==comune && x.Abilitato==true);
            return entities.Data.Count > 0 ? true : false;
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
