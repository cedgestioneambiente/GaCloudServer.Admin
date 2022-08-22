using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Contratti;
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
    public class GaContrattiService : IGaContrattiService
    {
        protected readonly IGenericRepository<ContrattoPermesso> contrattiPermessiRepo;
        protected readonly IGenericRepository<ContrattoServizio> contrattiServiziRepo;
        protected readonly IGenericRepository<ContrattoTipologia> contrattiTipologieRepo;
        protected readonly IGenericRepository<ContrattoUtenteOnPermesso> contrattiUtentiOnPermessiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaContrattiService(
            IGenericRepository<ContrattoPermesso> contrattiPermessiRepo,
            IGenericRepository<ContrattoServizio> contrattiServiziRepo,
            IGenericRepository<ContrattoTipologia> contrattiTipologieRepo,
            IGenericRepository<ContrattoUtenteOnPermesso> contrattiUtentiOnPermessiRepo,

            IUnitOfWork unitOfWork)
        {
            this.contrattiPermessiRepo = contrattiPermessiRepo;
            this.contrattiServiziRepo = contrattiServiziRepo;
            this.contrattiTipologieRepo = contrattiTipologieRepo;
            this.contrattiUtentiOnPermessiRepo = contrattiUtentiOnPermessiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region Contratti Permessi
        public async Task<ContrattiPermessiDto> GetGaContrattiPermessiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await contrattiPermessiRepo.GetAllAsync(page,pageSize);
            var dtos= entities.ToDto<ContrattiPermessiDto, PagedList<ContrattoPermesso>>();
            return dtos;
        }

        public Task<ContrattoPermessoDto> GetGaContrattoPermessoByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaContrattoPermessoAsync(ContrattoPermessoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaContrattoPermessoAsync(ContrattoPermessoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaContrattoPermessoAsync(long id)
        {
            throw new NotImplementedException();
        }

        #region Functions
        public Task<bool> CheckIsUniqueGaContrattoPermessoAsync(long id, string descrizione)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Contratti Servizi
        public async Task<ContrattiServiziDto> GetGaContrattiServiziAsync(int page = 1, int pageSize = 0)
        {
            var entities = await contrattiServiziRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiServiziDto, PagedList<ContrattoServizio>>();
            return dtos;
        }

        public Task<ContrattoServizioDto> GetGaContrattoServizioByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaContrattoServizioAsync(ContrattoServizioDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaContrattoServizioAsync(ContrattoServizioDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaContrattoServizioAsync(long id)
        {
            throw new NotImplementedException();
        }

        #region Functions
        public Task<bool> CheckIsUniqueGaContrattoServizioAsync(long id, string descrizione)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Contratti Tipologie
        public async Task<ContrattiTipologieDto> GetGaContrattiTipologieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await contrattiTipologieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiTipologieDto, PagedList<ContrattoTipologia>>();
            return dtos;
        }

        public Task<ContrattoTipologiaDto> GetGaContrattoTipologiaByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaContrattoTipologiaAsync(ContrattoTipologiaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaContrattoTipologiaAsync(ContrattoTipologiaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaContrattoTipologiaAsync(long id)
        {
            throw new NotImplementedException();
        }

        #region Functions
        public Task<bool> CheckIsUniqueGaContrattoTipologiaAsync(long id, string descrizione)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Contratti UtentiOnPermessi
        
        #region Functions
        public Task<bool> UpdateGaContrattiUtenteOnPermessoAsync(string utenteId, long permessoId)
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
