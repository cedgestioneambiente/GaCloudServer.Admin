using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.AuditLogging.Services;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaAutorizzazioniService:IGaAutorizzazioniService
    {
        protected readonly IGenericRepository<AutorizzazioniTipo> autorizzazioniTipiRepo;
        protected readonly IGenericRepository<AutorizzazioniDocumento> autorizzazioniDocumentiRepo;
        protected readonly IGenericRepository<AutorizzazioniAllegato> autorizzazioniAllegatiRepo;

        protected readonly IGenericRepository<ViewGaAutorizzazioniDocumenti> viewGaAutorizzazioniDocumentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaAutorizzazioniService(
            IGenericRepository<AutorizzazioniTipo> autorizzazioniTipiRepo,
            IGenericRepository<AutorizzazioniDocumento> autorizzazioniDocumentiRepo,
            IGenericRepository<AutorizzazioniAllegato> autorizzazioniAllegatiRepo,

            IGenericRepository<ViewGaAutorizzazioniDocumenti> viewGaAutorizzazioniDocumentiRepo,

            IUnitOfWork unitOfWork)
        {
            this.autorizzazioniTipiRepo = autorizzazioniTipiRepo;
            this.autorizzazioniDocumentiRepo = autorizzazioniDocumentiRepo;
            this.autorizzazioniAllegatiRepo = autorizzazioniAllegatiRepo;
            this.viewGaAutorizzazioniDocumentiRepo = viewGaAutorizzazioniDocumentiRepo;

            this.unitOfWork = unitOfWork;

        }

        #region AutorizzazioniTipi
        public async Task<AutorizzazioniTipiDto> GetGaAutorizzazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await autorizzazioniTipiRepo.GetAllAsync(page,pageSize);
            var dtos= entities.ToDto<AutorizzazioniTipiDto, PagedList<AutorizzazioniTipo>>();
            return dtos;
        }

        public async Task<AutorizzazioniTipoDto> GetGaAutorizzazioniTipoByIdAsync(long id)
        {
            var entity = await autorizzazioniTipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<AutorizzazioniTipoDto, AutorizzazioniTipo>();
            return dto;
        }

        public async Task<long> AddGaAutorizzazioniTipoAsync(AutorizzazioniTipoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniTipo, AutorizzazioniTipoDto>();
            await autorizzazioniTipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaAutorizzazioniTipoAsync(AutorizzazioniTipoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniTipo, AutorizzazioniTipoDto>();
            autorizzazioniTipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaAutorizzazioniTipoAsync(long id)
        {
            var entity = await autorizzazioniTipiRepo.GetByIdAsync(id);
            autorizzazioniTipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaAutorizzazioniTipoAsync(long id, string descrizione)
        {
            var entity = await autorizzazioniTipiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

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
            var entity = await autorizzazioniTipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                autorizzazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                autorizzazioniTipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            
        }
        #endregion

        #endregion

        #region AutorizzazioniDocumenti
        public async Task<AutorizzazioniDocumentiDto> GetGaAutorizzazioniDocumentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await autorizzazioniDocumentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<AutorizzazioniDocumentiDto, PagedList<AutorizzazioniDocumento>>();
            return dtos;
        }

        public async Task<AutorizzazioniDocumentoDto> GetGaAutorizzazioniDocumentoByIdAsync(long id)
        {
            var entity = await autorizzazioniDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<AutorizzazioniDocumentoDto, AutorizzazioniDocumento>();
            return dto;
        }

        public async Task<long> AddGaAutorizzazioniDocumentoAsync(AutorizzazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniDocumento, AutorizzazioniDocumentoDto>();
            await autorizzazioniDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaAutorizzazioniDocumentoAsync(AutorizzazioniDocumentoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniDocumento, AutorizzazioniDocumentoDto>();
            autorizzazioniDocumentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaAutorizzazioniDocumentoAsync(long id)
        {
            var entity = await autorizzazioniDocumentiRepo.GetByIdAsync(id);
            autorizzazioniDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaAutorizzazioniDocumentoAsync(long id, string numero)
        {
            var entity = await autorizzazioniDocumentiRepo.GetWithFilterAsync(x => x.Numero == numero && x.Id != id);

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
            var entity = await autorizzazioniDocumentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                autorizzazioniDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                autorizzazioniDocumentiRepo.Update(entity);
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
            var entities = await autorizzazioniAllegatiRepo.GetWithFilterAsync(x=>x.AutorizzazioniDocumentoId==autorizzazioniDocumentoId);
            var dtos = entities.ToDto<AutorizzazioniAllegatiDto, PagedList<AutorizzazioniAllegato>>();
            return dtos;
        }

        public async Task<AutorizzazioniAllegatoDto> GetGaAutorizzazioniAllegatoByIdAsync(long id)
        {
            var entity = await autorizzazioniAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<AutorizzazioniAllegatoDto, AutorizzazioniAllegato>();
            return dto;
        }

        public async Task<long> AddGaAutorizzazioniAllegatoAsync(AutorizzazioniAllegatoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniAllegato, AutorizzazioniAllegatoDto>();
            await autorizzazioniAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaAutorizzazioniAllegatoAsync(AutorizzazioniAllegatoDto dto)
        {
            var entity = dto.ToEntity<AutorizzazioniAllegato, AutorizzazioniAllegatoDto>();
            autorizzazioniAllegatiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaAutorizzazioniAllegatoAsync(long id)
        {
            var entity = await autorizzazioniAllegatiRepo.GetByIdAsync(id);
            autorizzazioniAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        public async Task<bool> ChangeStatusGaAutorizzazioniAllegatoAsync(long id)
        {
            var entity = await autorizzazioniAllegatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                autorizzazioniAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                autorizzazioniAllegatiRepo.Update(entity);
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
