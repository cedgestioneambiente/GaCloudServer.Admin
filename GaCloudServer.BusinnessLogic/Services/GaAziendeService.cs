using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Aziende;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaAziendeService : IGaAziendeService
    {
        protected readonly IGenericRepository<AziendeLista> gaAziendeListeRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaAziendeService(
            IGenericRepository<AziendeLista> gaAziendeListeRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaAziendeListeRepo = gaAziendeListeRepo;

            this.unitOfWork = unitOfWork;

        }

        #region AziendeListe
        public async Task<AziendeListeDto> GetGaAziendeListeAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaAziendeListeRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<AziendeListeDto, PagedList<AziendeLista>>();
            return dtos;
        }

        public async Task<AziendeListeDto> GetGaAziendeListeForContactCenterAsync()
        {
            var entities = await gaAziendeListeRepo.GetWithFilterAsync(x => x.ContactCenterTicket == true);
            var dtos = entities.ToDto<AziendeListeDto, PagedList<AziendeLista>>();
            return dtos;
        }

        public async Task<AziendeListaDto> GetGaAziendeListaByIdAsync(long id)
        {
            var entity = await gaAziendeListeRepo.GetByIdAsync(id);
            var dto = entity.ToDto<AziendeListaDto, AziendeLista>();
            return dto;
        }

        public async Task<long> AddGaAziendeListaAsync(AziendeListaDto dto)
        {
            var entity = dto.ToEntity<AziendeLista, AziendeListaDto>();
            await gaAziendeListeRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaAziendeListaAsync(AziendeListaDto dto)
        {
            var entity = dto.ToEntity<AziendeLista, AziendeListaDto>();
            gaAziendeListeRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaAziendeListaAsync(long id)
        {
            var entity = await gaAziendeListeRepo.GetByIdAsync(id);
            gaAziendeListeRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaAziendeListaAsync(long id, string descrizione)
        {
            var entity = await gaAziendeListeRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaAziendeListaAsync(long id)
        {
            var entity = await gaAziendeListeRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaAziendeListeRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaAziendeListeRepo.Update(entity);
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
