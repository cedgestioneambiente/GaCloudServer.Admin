using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Cdr;
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
    public class GaCdrService : IGaCdrService
    {
        protected readonly IGenericRepository<CdrCentro> cdrCentriRepo;
        protected readonly IGenericRepository<CdrCer> cdrCersRepo;
        protected readonly IGenericRepository<CdrCerDettaglio> cdrCersDettagliRepo;
        protected readonly IGenericRepository<CdrCerOnCentro> cdrCersOnCentriRepo;
        protected readonly IGenericRepository<CdrComune> cdrComuniRepo;
        protected readonly IGenericRepository<CdrComuneOnCentro> cdrComuniOnCentriRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaCdrService(
            IGenericRepository<CdrCentro> cdrCentriRepo,
            IGenericRepository<CdrCer> cdrCersRepo,
            IGenericRepository<CdrCerDettaglio> cdrCersDettagliRepo,
            IGenericRepository<CdrCerOnCentro> cdrCersOnCentriRepo,
            IGenericRepository<CdrComune> cdrComuniRepo,
            IGenericRepository<CdrComuneOnCentro> cdrComuniOnCentriRepo,

            IUnitOfWork unitOfWork)
        {
            this.cdrCentriRepo = cdrCentriRepo;
            this.cdrCersRepo = cdrCersRepo;
            this.cdrCersDettagliRepo = cdrCersDettagliRepo;
            this.cdrCersOnCentriRepo = cdrCersOnCentriRepo;
            this.cdrComuniRepo = cdrComuniRepo;
            this.cdrComuniOnCentriRepo = cdrComuniOnCentriRepo;

            this.unitOfWork = unitOfWork;
        }

        #region Cdr Centri
        public async Task<CdrCentriDto> GetGaCdrCentriAsync(int page = 1, int pageSize = 10, bool all = true)
        {
            var entities = await cdrCentriRepo.GetAllAsync(page, pageSize, "Centro");
            var dtos = entities.ToDto<CdrCentriDto, PagedList<CdrCentro>>();
            return dtos;
        }

        public Task<CdrCentroDto> GetGaCdrCentroByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaCdrCentroAsync(CdrCentroDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaCdrCentroAsync(CdrCentroDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaCdrCentroAsync(long id)
        {
            throw new NotImplementedException();
        }

        #region Functions
        public Task<bool> CheckIsUniqueGaCdrCentroAsync(long id, string centro)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Cdr Cers
        public async Task<CdrCersDto> GetGaCdrCersAsync(int page = 1, int pageSize = 0)
        {
            var entities = await cdrCersRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrCersDto, PagedList<CdrCer>>();
            return dtos;
        }

        public Task<CdrCerDto> GetGaCdrCerByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaCdrCerAsync(CdrCerDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaCdrCerAsync(CdrCerDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaCdrCerAsync(long id)
        {
            throw new NotImplementedException();
        }

        #region Functions
        public Task<bool> CheckIsUniqueGaCdrCerAsync(long id, string cer)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Cdr CersDettagli
        public async Task<CdrCersDettagliDto> GetGaCdrCersDettagliAsync(long cerId, int page = 1, int pageSize = 10)
        {
            var entities = await cdrCersDettagliRepo.GetWithFilterAsync(x => x.CdrCerId == cerId, page, pageSize);
            var dtos = entities.ToDto<CdrCersDettagliDto, PagedList<CdrCerDettaglio>>();
            return dtos;
        }

        public Task<CdrCerDettaglioDto> GetGaCdrCerDettaglioByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaCdrCerDettaglioAsync(long id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Cdr CersOnCentri

        #region Functions
        public Task<bool> UpdateGaCdrCerOnCentroAsync(long cerId, long centroId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Cdr Comuni
        public async Task<CdrComuniDto> GetGaCdrComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await cdrComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CdrComuniDto, PagedList<CdrComune>>();
            return dtos;
        }

        public Task<CdrComuneDto> GetGaCdrComuneByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddGaCdrComuneAsync(CdrComuneDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateGaCdrComuneAsync(CdrComuneDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGaCdrComuneAsync(long id)
        {
            throw new NotImplementedException();
        }

        #region Functions
        public Task<bool> CheckIsUniqueGaCdrComuneAsync(long id, string Comune)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Cdr ComuniOnCentri

        #region Functions
        public Task<bool> UpdateGaCdrComuneOnCentroAsync(long comuneId, long centroId)
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
