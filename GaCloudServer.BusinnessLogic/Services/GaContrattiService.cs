using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaContrattiService : IGaContrattiService
    {
        protected readonly IGenericRepository<ContrattiPermesso> gaContrattiPermessiRepo;
        protected readonly IGenericRepository<ContrattiServizio> gaContrattiServiziRepo;
        protected readonly IGenericRepository<ContrattiTipologia> gaContrattiTipologieRepo;
        protected readonly IGenericRepository<ContrattiUtenteOnPermesso> gaContrattiUtentiOnPermessiRepo;

        protected readonly IGenericRepository<ViewGaContrattiUtenti> viewGaContrattiUtentiRepo;
        protected readonly IGenericRepository<ViewGaContrattiUtentiOnPermessi> viewGaContrattiUtentiOnPermessiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaContrattiService(
            IGenericRepository<ContrattiPermesso> gaContrattiPermessiRepo,
            IGenericRepository<ContrattiServizio> gaContrattiServiziRepo,
            IGenericRepository<ContrattiTipologia> gaContrattiTipologieRepo,
            IGenericRepository<ContrattiUtenteOnPermesso> gaContrattiUtentiOnPermessiRepo,

            IGenericRepository<ViewGaContrattiUtenti> viewGaContrattiUtentiRepo,
            IGenericRepository<ViewGaContrattiUtentiOnPermessi> viewGaContrattiUtentiOnPermessiRepo,


            IUnitOfWork unitOfWork)
        {
            this.gaContrattiPermessiRepo = gaContrattiPermessiRepo;
            this.gaContrattiServiziRepo = gaContrattiServiziRepo;
            this.gaContrattiTipologieRepo = gaContrattiTipologieRepo;
            this.gaContrattiUtentiOnPermessiRepo = gaContrattiUtentiOnPermessiRepo;

            this.viewGaContrattiUtentiRepo = viewGaContrattiUtentiRepo;
            this.viewGaContrattiUtentiOnPermessiRepo = viewGaContrattiUtentiOnPermessiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region Contratti Permessi
        public async Task<ContrattiPermessiDto> GetGaContrattiPermessiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiPermessiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiPermessiDto, PagedList<ContrattiPermesso>>();
            return dtos;
        }

        public async Task<ContrattiPermessoDto> GetGaContrattiPermessoByIdAsync(long id)
        {
            var entity = await gaContrattiPermessiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiPermessoDto, ContrattiPermesso>();
            return dto;
        }

        public async Task<long> AddGaContrattiPermessoAsync(ContrattiPermessoDto dto)
        {
            var entity = dto.ToEntity<ContrattiPermesso, ContrattiPermessoDto>();
            await gaContrattiPermessiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiPermessoAsync(ContrattiPermessoDto dto)
        {
            var entity = dto.ToEntity<ContrattiPermesso, ContrattiPermessoDto>();
            gaContrattiPermessiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiPermessoAsync(long id)
        {
            var entity = await gaContrattiPermessiRepo.GetByIdAsync(id);
            gaContrattiPermessiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiPermessoAsync(long id, string descrizione)
        {
            var entity = await gaContrattiPermessiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiPermessoAsync(long id)
        {
            var entity = await gaContrattiPermessiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiPermessiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiPermessiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti Servizi
        public async Task<ContrattiServiziDto> GetGaContrattiServiziAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiServiziRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiServiziDto, PagedList<ContrattiServizio>>();
            return dtos;
        }

        public async Task<ContrattiServizioDto> GetGaContrattiServizioByIdAsync(long id)
        {
            var entity = await gaContrattiServiziRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiServizioDto, ContrattiServizio>();
            return dto;
        }

        public async Task<long> AddGaContrattiServizioAsync(ContrattiServizioDto dto)
        {
            var entity = dto.ToEntity<ContrattiServizio, ContrattiServizioDto>();
            await gaContrattiServiziRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiServizioAsync(ContrattiServizioDto dto)
        {
            var entity = dto.ToEntity<ContrattiServizio, ContrattiServizioDto>();
            gaContrattiServiziRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiServizioAsync(long id)
        {
            var entity = await gaContrattiServiziRepo.GetByIdAsync(id);
            gaContrattiServiziRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiServizioAsync(long id, string descrizione)
        {
            var entity = await gaContrattiServiziRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiServizioAsync(long id)
        {
            var entity = await gaContrattiServiziRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiServiziRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiServiziRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti Tipologie
        public async Task<ContrattiTipologieDto> GetGaContrattiTipologieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiTipologieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiTipologieDto, PagedList<ContrattiTipologia>>();
            return dtos;
        }

        public async Task<ContrattiTipologiaDto> GetGaContrattiTipologiaByIdAsync(long id)
        {
            var entity = await gaContrattiTipologieRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiTipologiaDto, ContrattiTipologia>();
            return dto;
        }

        public async Task<long> AddGaContrattiTipologiaAsync(ContrattiTipologiaDto dto)
        {
            var entity = dto.ToEntity<ContrattiTipologia, ContrattiTipologiaDto>();
            await gaContrattiTipologieRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiTipologiaAsync(ContrattiTipologiaDto dto)
        {
            var entity = dto.ToEntity<ContrattiTipologia, ContrattiTipologiaDto>();
            gaContrattiTipologieRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiTipologiaAsync(long id)
        {
            var entity = await gaContrattiTipologieRepo.GetByIdAsync(id);
            gaContrattiTipologieRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiTipologiaAsync(long id, string descrizione)
        {
            var entity = await gaContrattiTipologieRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiTipologiaAsync(long id)
        {
            var entity = await gaContrattiTipologieRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti UtentiOnPermessi

        #region Functions
        public async Task<bool> UpdateGaContrattiUtenteOnPermessoAsync(string utenteId, long permessoId)
        {
            try
            {
                var checkExist = await gaContrattiUtentiOnPermessiRepo.CheckIfExist(x => x.UtenteId == utenteId && x.ContrattiPermessoId == permessoId);
                if (checkExist)
                {
                    var entity = await gaContrattiUtentiOnPermessiRepo.GetSingleWithFilter(x => x.UtenteId == utenteId && x.ContrattiPermessoId == permessoId);
                    gaContrattiUtentiOnPermessiRepo.Remove(entity);
                    await SaveChanges();
                    return true;
                }
                else
                {
                    var entity = new ContrattiUtenteOnPermesso();
                    entity.UtenteId = utenteId;
                    entity.ContrattiPermessoId = permessoId;
                    gaContrattiUtentiOnPermessiRepo.Add(entity);
                    await SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaContrattiUtentiOnPermessi>> GetViewGaContrattiUtentiOnPermessiAsync(string id)
        {
            {
                var entities = await viewGaContrattiUtentiOnPermessiRepo.GetWithFilterAsync(x => x.UtenteId == id, 1, 0, "UtenteId");

                return entities;
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

    }
    #endregion
}