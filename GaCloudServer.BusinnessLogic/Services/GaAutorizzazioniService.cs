using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
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
        protected readonly IGenericRepository<AutorizzazioneTipo> autorizzazioniTipiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaAutorizzazioniService(
            IGenericRepository<AutorizzazioneTipo> autorizzazioniTipiRepo,
            IUnitOfWork unitOfWork)
        {
            this.autorizzazioniTipiRepo = autorizzazioniTipiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region Autorizzazioni Tipi
        public async Task<AutorizzazioniTipiDto> GetGaAutorizzazioniTipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await autorizzazioniTipiRepo.GetAllAsync(page,pageSize);
            var dtos= entities.ToDto<AutorizzazioniTipiDto, PagedList<AutorizzazioneTipo>>();
            return dtos;
        }

        public Task<AutorizzazioneTipoDto> GetGaAutorizzazioneTipoByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaAutorizzazioneTipoAsync(AutorizzazioneTipoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaAutorizzazioneTipoAsync(AutorizzazioneTipoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaAutorizzazioneTipoAsync(long id)
        {
            throw new NotImplementedException();
        }

        #region Functions
        public Task<bool> CheckIsUniqueGaAutorizzazioneTipoAsync(long id, string descrizione)
        {
            throw new NotImplementedException();
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
