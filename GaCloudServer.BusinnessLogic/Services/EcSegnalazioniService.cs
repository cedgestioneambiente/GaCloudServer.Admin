using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.BusinnessLogic.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class EcSegnalazioniService : IEcSegnalazioniService
    {
        protected readonly IGenericRepository<EcSegnalazioniTipo> ecSegnalazioniTipiRepo;
        protected readonly IGenericRepository<EcSegnalazioniStato> ecSegnalazioniStatiRepo;
        protected readonly IGenericRepository<EcSegnalazioniFoto> ecSegnalazioniFotosRepo;
        protected readonly IGenericRepository<EcSegnalazioniDocumento> ecSegnalazioniDocumentiRepo;

        protected readonly IGenericRepository<ViewEcSegnalazioniDocumenti> viewEcSegnalazioniDocumentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public EcSegnalazioniService(
            IGenericRepository<EcSegnalazioniTipo> ecSegnalazioniTipiRepo,
            IGenericRepository<EcSegnalazioniStato> ecSegnalazioniStatiRepo,
            IGenericRepository<EcSegnalazioniFoto> ecSegnalazioniFotosRepo,
            IGenericRepository<EcSegnalazioniDocumento> ecSegnalazioniDocumentiRepo,

            IGenericRepository<ViewEcSegnalazioniDocumenti> viewEcSegnalazioniDocumentiRepo,

            IUnitOfWork unitOfWork)
        {
            this.ecSegnalazioniTipiRepo = ecSegnalazioniTipiRepo;
            this.ecSegnalazioniStatiRepo = ecSegnalazioniStatiRepo;
            this.ecSegnalazioniFotosRepo = ecSegnalazioniFotosRepo;
            this.ecSegnalazioniDocumentiRepo = ecSegnalazioniDocumentiRepo;

            this.viewEcSegnalazioniDocumentiRepo = viewEcSegnalazioniDocumentiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region SegnalazioniTipi
        public async Task<SegnalazioniTipiDto> GetEcSegnalazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await ecSegnalazioniTipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<SegnalazioniTipiDto, PagedList<EcSegnalazioniTipo>>();
            return dtos;
        }

        public async Task<SegnalazioniTipoDto> GetEcSegnalazioniTipoByIdAsync(long id)
        {
            var entity = await ecSegnalazioniTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<SegnalazioniTipoDto, EcSegnalazioniTipo>();
            return dto;
        }

        public async Task<long> AddEcSegnalazioniTipoAsync(SegnalazioniTipoDto dto)
        {
            var entity = dto.ToEntity<EcSegnalazioniTipo, SegnalazioniTipoDto>();
            await ecSegnalazioniTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateEcSegnalazioniTipoAsync(SegnalazioniTipoDto dto)
        {
            var entity = dto.ToEntity<EcSegnalazioniTipo, SegnalazioniTipoDto>();
            ecSegnalazioniTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteEcSegnalazioniTipoAsync(long id)
        {
            var entity = await ecSegnalazioniTipiRepo.GetByIdAsync(id);
            ecSegnalazioniTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateEcSegnalazioniTipoAsync(long id, string descrizione)
        {
            var entity = await ecSegnalazioniTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusEcSegnalazioniTipoAsync(long id)
        {
            var entity = await ecSegnalazioniTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                ecSegnalazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                ecSegnalazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region SegnalazioniStati
        public async Task<SegnalazioniStatiDto> GetEcSegnalazioniStatiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await ecSegnalazioniStatiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<SegnalazioniStatiDto, PagedList<EcSegnalazioniStato>>();
            return dtos;
        }

        public async Task<SegnalazioniStatoDto> GetEcSegnalazioniStatoByIdAsync(long id)
        {
            var entity = await ecSegnalazioniStatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<SegnalazioniStatoDto, EcSegnalazioniStato>();
            return dto;
        }

        public async Task<long> AddEcSegnalazioniStatoAsync(SegnalazioniStatoDto dto)
        {
            var entity = dto.ToEntity<EcSegnalazioniStato, SegnalazioniStatoDto>();
            await ecSegnalazioniStatiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateEcSegnalazioniStatoAsync(SegnalazioniStatoDto dto)
        {
            var entity = dto.ToEntity<EcSegnalazioniStato, SegnalazioniStatoDto>();
            ecSegnalazioniStatiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteEcSegnalazioniStatoAsync(long id)
        {
            var entity = await ecSegnalazioniStatiRepo.GetByIdAsync(id);
            ecSegnalazioniStatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateEcSegnalazioniStatoAsync(long id, string descrizione)
        {
            var entity = await ecSegnalazioniStatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusEcSegnalazioniStatoAsync(long id)
        {
            var entity = await ecSegnalazioniStatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                ecSegnalazioniStatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                ecSegnalazioniStatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region SegnalazioniFotos
        //public async Task<EcSegnalazioniFotosDto> GetEcSegnalazioniFotosAsync(int page = 1, int pageSize = 0)
        //{
        //    var entities = await ecSegnalazioniFotosRepo.GetAllAsync(page, pageSize);
        //    var dtos = entities.ToDto<SegnalazioniFotosDto, PagedList<SegnalazioniFoto>>();
        //    return dtos;
        //}

        public async Task<SegnalazioniFotoDto> GetEcSegnalazioneFotoBySegnalazioneIdAsync(long segnalazioniDocumentoId)
        {
            var entity = await ecSegnalazioniFotosRepo.GetWithFilterAsync(x => x.SegnalazioniDocumentoId == segnalazioniDocumentoId);
            var dto = entity.ToDto<SegnalazioniFotoDto, PagedList<EcSegnalazioniFoto>>();
            return dto;
        }

        public async Task<long> AddEcSegnalazioniFotoAsync(SegnalazioniFotoDto dto)
        {
            var entity = dto.ToEntity<EcSegnalazioniFoto, SegnalazioniFotoDto>();
            await ecSegnalazioniFotosRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        //public async Task<long> UpdateEcSegnalazioniFotoAsync(SegnalazioniFotoDto dto)
        //{
        //    var entity = dto.ToEntity<EcSegnalazioniFoto, SegnalazioniFotoDto>();
        //    ecSegnalazioniFotosRepo.Update(entity);
        //    await SaveChanges();

        //    return entity.Id;

        //}

        public async Task<bool> DeleteEcSegnalazioniFotoAsync(long id)
        {
            var entity = await ecSegnalazioniFotosRepo.GetByIdAsync(id);
            ecSegnalazioniFotosRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        //#region Functions
        //public async Task<bool> ValidateEcSegnalazioniFotoAsync(long id, string descrizione)
        //{
        //    var entity = await ecSegnalazioniFotosRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusEcSegnalazioniFotoAsync(long id)
        //{
        //    var entity = await ecSegnalazioniFotosRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        ecSegnalazioniFotosRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        ecSegnalazioniFotosRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        //#endregion

        #endregion

        #region SegnalazioniDocumenti
        public async Task<SegnalazioniDocumentiDto> GetEcSegnalazioniDocumentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await ecSegnalazioniDocumentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<SegnalazioniDocumentiDto, PagedList<EcSegnalazioniDocumento>>();
            return dtos;
        }

        public async Task<SegnalazioniDocumentoDto> GetEcSegnalazioniDocumentoByIdAsync(long id)
        {
            var entity = await ecSegnalazioniDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<SegnalazioniDocumentoDto, EcSegnalazioniDocumento>();
            return dto;
        }

        public async Task<long> AddEcSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<EcSegnalazioniDocumento, SegnalazioniDocumentoDto>();
            await ecSegnalazioniDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateEcSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<EcSegnalazioniDocumento, SegnalazioniDocumentoDto>();
            ecSegnalazioniDocumentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteEcSegnalazioniDocumentoAsync(long id)
        {
            var entity = await ecSegnalazioniDocumentiRepo.GetByIdAsync(id);
            ecSegnalazioniDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<long> UpdateEcSegnalazionePhotoAsync(long id, string folder)
        {
            var entity = ecSegnalazioniDocumentiRepo.GetByIdAsNoTraking(x => x.Id == id);
            var original = entity;
            entity.ImgFolder = folder;
            ecSegnalazioniDocumentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;
        }
        #endregion

        #region Views
        public async Task<ViewEcSegnalazioniDocumenti> GetViewEcSegnalazioniDocumentoByIdAsync(long id)
        {
            var entity = await viewEcSegnalazioniDocumentiRepo.GetByIdAsync(id);

            return entity;
        }
        public async Task<PagedList<ViewEcSegnalazioniDocumenti>> GetViewEcSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "ga-s-administrator")
        {
            try
            {
                PagedList<ViewEcSegnalazioniDocumenti> entities = null;
                switch (mode)
                {
                    case SegnalazioniDocumentiMode.All:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetAllAsync(1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId, 1, 0, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyEnabled:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false, 1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false, 1, 0, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyOpen:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), 1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), 1, 0, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyClosed:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 3), 1, 0, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 3), 1, 0, "DataOra", "OrderByDescending");
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
        public async Task<PagedList<ViewEcSegnalazioniDocumenti>> GetViewEcSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "ga-s-administrator", int page = 1, int pageSize = 100)
        {
            try
            {
                PagedList<ViewEcSegnalazioniDocumenti> entities = null;
                switch (mode)
                {
                    case SegnalazioniDocumentiMode.All:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetAllAsync(page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId, page, pageSize, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyEnabled:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false, page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false, page, pageSize, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyOpen:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 1 || x.StatoId == 2), page, pageSize, "DataOra", "OrderByDescending");
                        break;
                    case SegnalazioniDocumentiMode.OnlyClosed:
                        entities = userId == "ga-s-administrator" ?
                         await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.Disabled == false && (x.StatoId == 3), page, pageSize, "DataOra", "OrderByDescending")
                        :
                        await viewEcSegnalazioniDocumentiRepo.GetWithFilterAsync(x => x.UserId == userId && x.Disabled == false && (x.StatoId == 3), page, pageSize, "DataOra", "OrderByDescending");
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

