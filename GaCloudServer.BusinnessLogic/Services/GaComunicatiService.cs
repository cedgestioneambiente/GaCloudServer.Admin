using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Comunicati;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaComunicatiService:IGaComunicatiService
    {
        protected readonly IGenericRepository<ComunicatiDocumento> gaComunicatiDocumentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaComunicatiService(
            IGenericRepository<ComunicatiDocumento> gaComunicatiDocumentiRepo,

            IUnitOfWork unitOfWork)
        {;
            this.gaComunicatiDocumentiRepo = gaComunicatiDocumentiRepo;

            this.unitOfWork = unitOfWork;

        }

        #region ComunicatiDocumenti
        public async Task<ComunicatiDocumentiDto> GetGaComunicatiDocumentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaComunicatiDocumentiRepo.GetAllAsync(page,pageSize);
            var dtos = entities.ToDto<ComunicatiDocumentiDto, PagedList<ComunicatiDocumento>>();
            return dtos;
        }

        public async Task<ComunicatiDocumentoDto> GetGaComunicatiDocumentoByIdAsync(long id)
        {
            var entity = await gaComunicatiDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ComunicatiDocumentoDto, ComunicatiDocumento>();
            return dto;
        }

        public async Task<long> AddGaComunicatiDocumentoAsync(ComunicatiDocumentoDto dto)
        {
            var entity = dto.ToEntity<ComunicatiDocumento, ComunicatiDocumentoDto>();
            await gaComunicatiDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaComunicatiDocumentoAsync(ComunicatiDocumentoDto dto)
        {
            var entity = dto.ToEntity<ComunicatiDocumento, ComunicatiDocumentoDto>();
            gaComunicatiDocumentiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaComunicatiDocumentoAsync(long id)
        {
            var entity = await gaComunicatiDocumentiRepo.GetByIdAsync(id);
            gaComunicatiDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaComunicatiDocumentoAsync(long id, string numero)
        {
            var entity = await gaComunicatiDocumentiRepo.GetWithFilterAsync(x => x.Numero == numero && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaComunicatiDocumentoAsync(long id)
        {
            var entity = await gaComunicatiDocumentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaComunicatiDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaComunicatiDocumentiRepo.Update(entity);
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
