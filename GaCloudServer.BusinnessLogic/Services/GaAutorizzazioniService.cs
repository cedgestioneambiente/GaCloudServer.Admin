using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaAutorizzazioniService:IGaAutorizzazioniService
    {
        protected readonly IGenericRepository<AutorizzazioniTipo> gaAutorizzazioniTipiRepo;
        protected readonly IGenericRepository<AutorizzazioniDocumento> gaAutorizzazioniDocumentiRepo;
        protected readonly IGenericRepository<AutorizzazioniAllegato> gaAutorizzazioniAllegatiRepo;

        protected readonly IGenericRepository<ViewGaAutorizzazioniDocumenti> viewGaAutorizzazioniDocumentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaAutorizzazioniService(
            IGenericRepository<AutorizzazioniTipo> gaAutorizzazioniTipiRepo,
            IGenericRepository<AutorizzazioniDocumento> gaAutorizzazioniDocumentiRepo,
            IGenericRepository<AutorizzazioniAllegato> gaAutorizzazioniAllegatiRepo,

            IGenericRepository<ViewGaAutorizzazioniDocumenti> viewGaAutorizzazioniDocumentiRepo,

            IUnitOfWork unitOfWork

            )
        {
            this.gaAutorizzazioniTipiRepo = gaAutorizzazioniTipiRepo;
            this.gaAutorizzazioniDocumentiRepo = gaAutorizzazioniDocumentiRepo;
            this.gaAutorizzazioniAllegatiRepo = gaAutorizzazioniAllegatiRepo;

            this.viewGaAutorizzazioniDocumentiRepo = viewGaAutorizzazioniDocumentiRepo;

            this.unitOfWork = unitOfWork;

        }

        #region AutorizzazioniTipi
        public async Task<AutorizzazioniTipiDto> GetGaAutorizzazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaAutorizzazioniTipiRepo.GetAllAsync(page,pageSize);
            var dtos= entities.ToDto<AutorizzazioniTipiDto, PagedList<AutorizzazioniTipo>>();
            return dtos;
        }

        public async Task<AutorizzazioniTipoDto> GetGaAutorizzazioniTipoByIdAsync(long id)
        {
            var entity = await gaAutorizzazioniTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<AutorizzazioniTipoDto, AutorizzazioniTipo>();
            return dto;
        }

        public async Task<long> AddGaAutorizzazioniTipoAsync(AutorizzazioniTipoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniTipo, AutorizzazioniTipoDto>();
            await gaAutorizzazioniTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaAutorizzazioniTipoAsync(AutorizzazioniTipoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniTipo, AutorizzazioniTipoDto>();
            gaAutorizzazioniTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaAutorizzazioniTipoAsync(long id)
        {
            var entity = await gaAutorizzazioniTipiRepo.GetByIdAsync(id);
            gaAutorizzazioniTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaAutorizzazioniTipoAsync(long id, string descrizione)
        {
            var entity = await gaAutorizzazioniTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaAutorizzazioniTipoAsync(long id)
        {
            var entity = await gaAutorizzazioniTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaAutorizzazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaAutorizzazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            
        }
        #endregion

        #endregion

        #region AutorizzazioniDocumenti
        public async Task<AutorizzazioniDocumentiDto> GetGaAutorizzazioniDocumentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaAutorizzazioniDocumentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<AutorizzazioniDocumentiDto, PagedList<AutorizzazioniDocumento>>();
            return dtos;
        }

        public async Task<AutorizzazioniDocumentoDto> GetGaAutorizzazioniDocumentoByIdAsync(long id)
        {
            var entity = await gaAutorizzazioniDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<AutorizzazioniDocumentoDto, AutorizzazioniDocumento>();
            return dto;
        }

        public async Task<long> AddGaAutorizzazioniDocumentoAsync(AutorizzazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniDocumento, AutorizzazioniDocumentoDto>();
            await gaAutorizzazioniDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaAutorizzazioniDocumentoAsync(AutorizzazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniDocumento, AutorizzazioniDocumentoDto>();
            gaAutorizzazioniDocumentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaAutorizzazioniDocumentoAsync(long id)
        {
            var entity = await gaAutorizzazioniDocumentiRepo.GetByIdAsync(id);
            gaAutorizzazioniDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaAutorizzazioniDocumentoAsync(long id, string numero)
        {
            var entity = await gaAutorizzazioniDocumentiRepo.GetWithFilterAsync(x => x.Numero == numero && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaAutorizzazioniDocumentoAsync(long id)
        {
            var entity = await gaAutorizzazioniDocumentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaAutorizzazioniDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaAutorizzazioniDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaAutorizzazioniDocumenti>> GetViewGaAutorizzazioniDocumentiAsync(bool all= true)
        {
            var entities = all? await viewGaAutorizzazioniDocumentiRepo.GetAllAsync(1,0):await viewGaAutorizzazioniDocumentiRepo.GetWithFilterAsync(x=>x.Disabled==false);
            return entities;
        }
        #endregion


        #endregion

        #region AutorizzazioniAllegati
        public async Task<AutorizzazioniAllegatiDto> GetGaAutorizzazioniAllegatiByDocumentoIdAsync(long autorizzazioniDocumentoId)
        {
            var entities = await gaAutorizzazioniAllegatiRepo.GetWithFilterAsync(x=>x.AutorizzazioniDocumentoId==autorizzazioniDocumentoId);
            var dtos = entities.ToDto<AutorizzazioniAllegatiDto, PagedList<AutorizzazioniAllegato>>();
            return dtos;
        }

        public async Task<AutorizzazioniAllegatoDto> GetGaAutorizzazioniAllegatoByIdAsync(long id)
        {
            var entity = await gaAutorizzazioniAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<AutorizzazioniAllegatoDto, AutorizzazioniAllegato>();
            return dto;
        }

        public async Task<long> AddGaAutorizzazioniAllegatoAsync(AutorizzazioniAllegatoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniAllegato, AutorizzazioniAllegatoDto>();
            await gaAutorizzazioniAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaAutorizzazioniAllegatoAsync(AutorizzazioniAllegatoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniAllegato, AutorizzazioniAllegatoDto>();
            gaAutorizzazioniAllegatiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaAutorizzazioniAllegatoAsync(long id)
        {
            var entity = await gaAutorizzazioniAllegatiRepo.GetByIdAsync(id);
            gaAutorizzazioniAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        public async Task<bool> ChangeStatusGaAutorizzazioniAllegatoAsync(long id)
        {
            var entity = await gaAutorizzazioniAllegatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaAutorizzazioniAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaAutorizzazioniAllegatiRepo.Update(entity);
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
