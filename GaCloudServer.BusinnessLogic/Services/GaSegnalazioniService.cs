using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.BusinnessLogic.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaSegnalazioniService : IGaSegnalazioniService
    {
        protected readonly IGenericRepository<SegnalazioniTipo> gaSegnalazioniTipiRepo;
        protected readonly IGenericRepository<SegnalazioniStato> gaSegnalazioniStatiRepo;
        protected readonly IGenericRepository<SegnalazioniAllegato> gaSegnalazioniAllegatiRepo;
        protected readonly IGenericRepository<SegnalazioniDocumento> gaSegnalazioniDocumentiRepo;

        protected readonly IGenericRepository<ViewGaSegnalazioniDocumenti> viewGaSegnalazioniDocumentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaSegnalazioniService(
            IGenericRepository<SegnalazioniTipo> gaSegnalazioniTipiRepo,
            IGenericRepository<SegnalazioniStato> gaSegnalazioniStatiRepo,
            IGenericRepository<SegnalazioniAllegato> gaSegnalazioniAllegatiRepo,
            IGenericRepository<SegnalazioniDocumento> gaSegnalazioniDocumentiRepo,

            IGenericRepository<ViewGaSegnalazioniDocumenti> viewGaSegnalazioniDocumentiRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaSegnalazioniTipiRepo = gaSegnalazioniTipiRepo;
            this.gaSegnalazioniStatiRepo = gaSegnalazioniStatiRepo;
            this.gaSegnalazioniAllegatiRepo = gaSegnalazioniAllegatiRepo;
            this.gaSegnalazioniDocumentiRepo = gaSegnalazioniDocumentiRepo;

            this.viewGaSegnalazioniDocumentiRepo = viewGaSegnalazioniDocumentiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region SegnalazioniTipi
        public async Task<SegnalazioniTipiDto> GetGaSegnalazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaSegnalazioniTipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<SegnalazioniTipiDto, PagedList<SegnalazioniTipo>>();
            return dtos;
        }

        public async Task<SegnalazioniTipoDto> GetGaSegnalazioniTipoByIdAsync(long id)
        {
            var entity = await gaSegnalazioniTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<SegnalazioniTipoDto, SegnalazioniTipo>();
            return dto;
        }

        public async Task<long> AddGaSegnalazioniTipoAsync(SegnalazioniTipoDto dto)
        {
            var entity = dto.ToEntity<SegnalazioniTipo, SegnalazioniTipoDto>();
            await gaSegnalazioniTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaSegnalazioniTipoAsync(SegnalazioniTipoDto dto)
        {
            var entity = dto.ToEntity<SegnalazioniTipo, SegnalazioniTipoDto>();
            gaSegnalazioniTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaSegnalazioniTipoAsync(long id)
        {
            var entity = await gaSegnalazioniTipiRepo.GetByIdAsync(id);
            gaSegnalazioniTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaSegnalazioniTipoAsync(long id, string descrizione)
        {
            var entity = await gaSegnalazioniTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaSegnalazioniTipoAsync(long id)
        {
            var entity = await gaSegnalazioniTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaSegnalazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaSegnalazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region SegnalazioniStati
        public async Task<SegnalazioniStatiDto> GetGaSegnalazioniStatiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaSegnalazioniStatiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<SegnalazioniStatiDto, PagedList<SegnalazioniStato>>();
            return dtos;
        }

        public async Task<SegnalazioniStatoDto> GetGaSegnalazioniStatoByIdAsync(long id)
        {
            var entity = await gaSegnalazioniStatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<SegnalazioniStatoDto, SegnalazioniStato>();
            return dto;
        }

        public async Task<long> AddGaSegnalazioniStatoAsync(SegnalazioniStatoDto dto)
        {
            var entity = dto.ToEntity<SegnalazioniStato, SegnalazioniStatoDto>();
            await gaSegnalazioniStatiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaSegnalazioniStatoAsync(SegnalazioniStatoDto dto)
        {
            var entity = dto.ToEntity<SegnalazioniStato, SegnalazioniStatoDto>();
            gaSegnalazioniStatiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaSegnalazioniStatoAsync(long id)
        {
            var entity = await gaSegnalazioniStatiRepo.GetByIdAsync(id);
            gaSegnalazioniStatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaSegnalazioniStatoAsync(long id, string descrizione)
        {
            var entity = await gaSegnalazioniStatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaSegnalazioniStatoAsync(long id)
        {
            var entity = await gaSegnalazioniStatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaSegnalazioniStatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaSegnalazioniStatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region SegnalazioniAllegati
        //public async Task<SegnalazioniAllegatiDto> GetGaSegnalazioniAllegatiAsync(int page = 1, int pageSize = 0)
        //{
        //    var entities = await gaSegnalazioniAllegatiRepo.GetAllAsync(page, pageSize);
        //    var dtos = entities.ToDto<SegnalazioniAllegatiDto, PagedList<SegnalazioniAllegato>>();
        //    return dtos;
        //}

        public async Task<SegnalazioniAllegatiDto> GetGaSegnalazioniAllegatiByDocumentoIdAsync(long segnalazioniDocumentoId)
        {
            var entity = await gaSegnalazioniAllegatiRepo.GetWithFilterAsync(x => x.SegnalazioniDocumentoId == segnalazioniDocumentoId);
            var dto = entity.ToDto<SegnalazioniAllegatiDto, PagedList<SegnalazioniAllegato>>();
            return dto;
        }

        public async Task<long> AddGaSegnalazioniAllegatoAsync(SegnalazioniAllegatoDto dto)
        {
            var entity = dto.ToEntity<SegnalazioniAllegato, SegnalazioniAllegatoDto>();
            await gaSegnalazioniAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        //public async Task<long> UpdateGaSegnalazioniAllegatoAsync(SegnalazioniAllegatoDto dto)
        //{
        //    var entity = dto.ToEntity<SegnalazioniAllegato, SegnalazioniAllegatoDto>();
        //    gaSegnalazioniAllegatiRepo.Update(entity);
        //    await SaveChanges();

        //    return entity.Id;

        //}

        public async Task<bool> DeleteGaSegnalazioniAllegatoAsync(long id)
        {
            var entity = await gaSegnalazioniAllegatiRepo.GetByIdAsync(id);
            gaSegnalazioniAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        //#region Functions
        //public async Task<bool> ValidateGaSegnalazioniAllegatoAsync(long id, string descrizione)
        //{
        //    var entity = await gaSegnalazioniAllegatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusGaSegnalazioniAllegatoAsync(long id)
        //{
        //    var entity = await gaSegnalazioniAllegatiRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        gaSegnalazioniAllegatiRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        gaSegnalazioniAllegatiRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        //#endregion

        #endregion
        
        #region SegnalazioniDocumenti
        public async Task<SegnalazioniDocumentiDto> GetGaSegnalazioniDocumentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaSegnalazioniDocumentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<SegnalazioniDocumentiDto, PagedList<SegnalazioniDocumento>>();
            return dtos;
        }

        public async Task<SegnalazioniDocumentoDto> GetGaSegnalazioniDocumentoByIdAsync(long id)
        {
            var entity = await gaSegnalazioniDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<SegnalazioniDocumentoDto, SegnalazioniDocumento>();
            return dto;
        }

        public async Task<long> AddGaSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<SegnalazioniDocumento, SegnalazioniDocumentoDto>();
            await gaSegnalazioniDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<SegnalazioniDocumento, SegnalazioniDocumentoDto>();
            gaSegnalazioniDocumentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaSegnalazioniDocumentoAsync(long id)
        {
            var entity = await gaSegnalazioniDocumentiRepo.GetByIdAsync(id);
            gaSegnalazioniDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<long> UpdateGaSegnalazionePhotoAsync(long id, string folder)
        {
                var entity = gaSegnalazioniDocumentiRepo.GetByIdAsNoTraking(x => x.Id == id);
                var original = entity;
                entity.ImgFolder = folder;
                gaSegnalazioniDocumentiRepo.Update(entity);
                await SaveChanges();

                return entity.Id;
        }
        #endregion

        #region Views
        public async Task<ViewGaSegnalazioniDocumenti> GetViewGaSegnalazioniDocumentoByIdAsync(long id)
        {
                var entity = await viewGaSegnalazioniDocumentiRepo.GetByIdAsync(id);

                return entity;
        }

        public async Task<PagedList<ViewGaSegnalazioniDocumenti>> GetViewGaSegnalazioniDocumentiAsync(bool all = true)
        {
            var entities = all ? await viewGaSegnalazioniDocumentiRepo.GetAllAsync(1, 0) : await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }

        public async Task<PagedList<ViewGaSegnalazioniDocumenti>> GetViewGaSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "ga-s-administrator")
        {
            try
            {
                PagedList<ViewGaSegnalazioniDocumenti> entities = null;
                switch (mode)
                {
                    case SegnalazioniDocumentiMode.All:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetAllAsync(1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId, 1, 0, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyEnabled:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false, 1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false, 1, 0, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyOpen:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), 1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), 1, 0, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyClosed:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 3), 1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 3), 1, 0, "DataOra", "OrderByDescending");
                        break;
                }

                await SaveChanges();

                return entities;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        public async Task<PagedList<ViewGaSegnalazioniDocumenti>> GetViewGaSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "ga-s-administrator", int page = 1, int pageSize = 100)
        {
            try
            {
                PagedList<ViewGaSegnalazioniDocumenti> entities = null;
                switch (mode)
                {
                    case SegnalazioniDocumentiMode.All:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetAllAsync(page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId, page, pageSize, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyEnabled:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false, page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false, page, pageSize, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyOpen:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), page, pageSize, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyClosed:
                        entities = userId == "ga-s-administrator" ?
                         await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 3), page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewGaSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 3), page, pageSize, "DataOra", "OrderByDescending");
                        break;
                }

                await SaveChanges();

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
