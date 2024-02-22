using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPreventiviService : IGaPreventiviService
    {
        protected readonly IGenericRepository<PreventiviAnticipoTipologia> gaPreventiviAnticipiTipologieRepo;
        protected readonly IGenericRepository<PreventiviAnticipo> gaPreventiviAnticipiRepo;
        protected readonly IGenericRepository<PreventiviAnticipoAllegato> gaPreventiviAnticipiAllegatiRepo;
        protected readonly IGenericRepository<PreventiviAnticipoPagamento> gaPreventiviAnticipiPagamentiRepo;

        protected readonly IGenericRepository<ViewGaPreventiviAnticipi> viewGaPreventiviAnticipiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaPreventiviService(
            IGenericRepository<PreventiviAnticipoTipologia> gaPreventiviAnticipiTipologieRepo,
            IGenericRepository<PreventiviAnticipo> gaPreventiviAnticipiRepo,
             IGenericRepository<PreventiviAnticipoAllegato> gaPreventiviAnticipiAllegatiRepo,
            IGenericRepository<PreventiviAnticipoPagamento> gaPreventiviAnticipiPagamentiRepo,

            IGenericRepository<ViewGaPreventiviAnticipi> viewGaPreventiviAnticipiRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaPreventiviAnticipiTipologieRepo = gaPreventiviAnticipiTipologieRepo;
            this.gaPreventiviAnticipiRepo = gaPreventiviAnticipiRepo;
            this.gaPreventiviAnticipiAllegatiRepo = gaPreventiviAnticipiAllegatiRepo;
            this.gaPreventiviAnticipiPagamentiRepo = gaPreventiviAnticipiPagamentiRepo;

            this.viewGaPreventiviAnticipiRepo = viewGaPreventiviAnticipiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region PreventiviAnticipiTipologie
        public async Task<PreventiviAnticipiTipologieDto> GetGaPreventiviAnticipiTipologieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPreventiviAnticipiTipologieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PreventiviAnticipiTipologieDto, PagedList<PreventiviAnticipoTipologia>>();
            return dtos;
        }

        public async Task<PreventiviAnticipoTipologiaDto> GetGaPreventiviAnticipoTipologiaByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoTipologiaDto, PreventiviAnticipoTipologia>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoTipologia, PreventiviAnticipoTipologiaDto>();
            await gaPreventiviAnticipiTipologieRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoTipologia, PreventiviAnticipoTipologiaDto>();
            gaPreventiviAnticipiTipologieRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoTipologiaAsync(long id)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetByIdAsync(id);
            gaPreventiviAnticipiTipologieRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoTipologiaAsync(long id, string descrizione)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoTipologiaAsync(long id)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PreventiviAnticipiPagamenti
        public async Task<PreventiviAnticipiPagamentiDto> GetGaPreventiviAnticipiPagamentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPreventiviAnticipiPagamentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PreventiviAnticipiPagamentiDto, PagedList<PreventiviAnticipoPagamento>>();
            return dtos;
        }

        public async Task<PreventiviAnticipoPagamentoDto> GetGaPreventiviAnticipoPagamentoByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoPagamentoDto, PreventiviAnticipoPagamento>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoPagamento, PreventiviAnticipoPagamentoDto>();
            await gaPreventiviAnticipiPagamentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoPagamento, PreventiviAnticipoPagamentoDto>();
            gaPreventiviAnticipiPagamentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoPagamentoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetByIdAsync(id);
            gaPreventiviAnticipiPagamentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoPagamentoAsync(long id, string descrizione)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoPagamentoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiPagamentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiPagamentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PreventiviAnticipi
        public async Task<PreventiviAnticipiDto> GetGaPreventiviAnticipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPreventiviAnticipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PreventiviAnticipiDto, PagedList<PreventiviAnticipo>>();
            return dtos;
        }

        public async Task<PreventiviAnticipoDto> GetGaPreventiviAnticipoByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoDto, PreventiviAnticipo>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipo, PreventiviAnticipoDto>();
            await gaPreventiviAnticipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipo, PreventiviAnticipoDto>();
            gaPreventiviAnticipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            gaPreventiviAnticipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoAsync(long id, string numero)
        {
            var entity = await gaPreventiviAnticipiRepo.GetWithFilterAsync(x => x.Numero == numero && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<bool> SetGaPreventiviAnticipoPagatoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            if (entity.Pagato)
            {
                entity.Pagato = false;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Pagato = true;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPreventiviAnticipi>> GetViewGaPreventiviAnticipiAsync()
        {
            try
            {
                return await viewGaPreventiviAnticipiRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        #endregion

        #endregion

        #region PreventiviAnticipiAllegati
        public async Task<PreventiviAnticipiAllegatiDto> GetGaPreventiviAnticipiAllegatiByAnticipoAsync(long preventiviAnticipoId)
        {
            var entities = await gaPreventiviAnticipiAllegatiRepo.GetWithFilterAsync(x => x.PreventiviAnticipoId == preventiviAnticipoId);
            var dtos = entities.ToDto<PreventiviAnticipiAllegatiDto, PagedList<PreventiviAnticipoAllegato>>();
            return dtos;
        }


        public async Task<PreventiviAnticipoAllegatoDto> GetGaPreventiviAnticipoAllegatoByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoAllegatoDto, PreventiviAnticipoAllegato>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoAllegato, PreventiviAnticipoAllegatoDto>();
            await gaPreventiviAnticipiAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoAllegato, PreventiviAnticipoAllegatoDto>();
            gaPreventiviAnticipiAllegatiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoAllegatoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetByIdAsync(id);
            gaPreventiviAnticipiAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoAllegatoAsync(long id, string descrizione)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoAllegatoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiAllegatiRepo.Update(entity);
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
