using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class ConsorzioService : IConsorzioService
    {
        protected readonly IGenericRepository<ConsorzioCer> consorzioCersRepo;
        protected readonly IGenericRepository<ConsorzioCerSmaltimento> consorzioCersSmaltimentiRepo;
        protected readonly IGenericRepository<ConsorzioComune> consorzioComuniRepo;
        protected readonly IGenericRepository<ConsorzioProduttore> consorzioProduttoriRepo;
        protected readonly IGenericRepository<ConsorzioDestinatario> consorzioDestinatariRepo;
        protected readonly IGenericRepository<ConsorzioTrasportatore> consorzioTrasportatoriRepo;
        protected readonly IGenericRepository<ConsorzioRegistrazione> consorzioRegistrazioniRepo;
        protected readonly IGenericRepository<ConsorzioRegistrazioneAllegato> consorzioRegistrazioniAllegatiRepo;

        protected readonly IGenericRepository<ViewConsorzioCers> viewConsorzioCersRepo;
        protected readonly IGenericRepository<ViewConsorzioProduttori> viewConsorzioProduttoriRepo;
        protected readonly IGenericRepository<ViewConsorzioDestinatari> viewConsorzioDestinatariRepo;
        protected readonly IGenericRepository<ViewConsorzioTrasportatori> viewConsorzioTrasportatoriRepo;
        protected readonly IGenericRepository<ViewConsorzioRegistrazioni> viewConsorzioRegistrazioniRepo;

        protected readonly IUnitOfWork unitOfWork;

        public ConsorzioService(

            IGenericRepository<ConsorzioCer> consorzioCersRepo,
            IGenericRepository<ConsorzioCerSmaltimento> consorzioCersSmaltimentiRepo,
            IGenericRepository<ConsorzioComune> consorzioComuniRepo,
            IGenericRepository<ConsorzioProduttore> consorzioProduttoriRepo,
            IGenericRepository<ConsorzioDestinatario> consorzioDestinatariRepo,
            IGenericRepository<ConsorzioTrasportatore> consorzioTrasportatoriRepo,
            IGenericRepository<ConsorzioRegistrazione> consorzioRegistrazioniRepo,
            IGenericRepository<ConsorzioRegistrazioneAllegato> consorzioRegistrazioniAllegatiRepo,

            IGenericRepository<ViewConsorzioCers> viewConsorzioCersRepo,
            IGenericRepository<ViewConsorzioProduttori> viewConsorzioProduttoriRepo,
            IGenericRepository<ViewConsorzioDestinatari> viewConsorzioDestinatariRepo,
            IGenericRepository<ViewConsorzioTrasportatori> viewConsorzioTrasportatoriRepo,
            IGenericRepository<ViewConsorzioRegistrazioni> viewConsorzioRegistrazioniRepo,

            IUnitOfWork unitOfWork)
        {
            this.consorzioCersRepo = consorzioCersRepo;
            this.consorzioCersSmaltimentiRepo = consorzioCersSmaltimentiRepo;
            this.consorzioComuniRepo = consorzioComuniRepo;
            this.consorzioProduttoriRepo = consorzioProduttoriRepo;
            this.consorzioDestinatariRepo = consorzioDestinatariRepo;
            this.consorzioTrasportatoriRepo = consorzioTrasportatoriRepo;
            this.consorzioRegistrazioniRepo = consorzioRegistrazioniRepo;
            this.consorzioRegistrazioniAllegatiRepo = consorzioRegistrazioniAllegatiRepo;

            this.viewConsorzioCersRepo = viewConsorzioCersRepo;
            this.viewConsorzioProduttoriRepo = viewConsorzioProduttoriRepo;
            this.viewConsorzioDestinatariRepo = viewConsorzioDestinatariRepo;
            this.viewConsorzioTrasportatoriRepo = viewConsorzioTrasportatoriRepo;
            this.viewConsorzioRegistrazioniRepo = viewConsorzioRegistrazioniRepo;


            this.unitOfWork = unitOfWork;

        }

        #region ConsorzioCers
        public async Task<ConsorzioCersDto> GetConsorzioCersAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioCersRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioCersDto, PagedList<ConsorzioCer>>();
            return dtos;
        }

        public async Task<ConsorzioCerDto> GetConsorzioCerByIdAsync(long id)
        {
            var entity = await consorzioCersRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioCerDto, ConsorzioCer>();
            return dto;
        }

        public async Task<long> AddConsorzioCerAsync(ConsorzioCerDto dto)
        {
            var entity = dto.ToEntity<ConsorzioCer, ConsorzioCerDto>();
            await consorzioCersRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioCerAsync(ConsorzioCerDto dto)
        {
            var entity = dto.ToEntity<ConsorzioCer, ConsorzioCerDto>();
            consorzioCersRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioCerAsync(long id)
        {
            var entity = await consorzioCersRepo.GetByIdAsync(id);
            consorzioCersRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioCerAsync(long id, string descrizione)
        {
            var entity = await consorzioCersRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioCerAsync(long id)
        {
            var entity = await consorzioCersRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioCers>> GetViewConsorzioCersAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioCersRepo.GetAllAsync(1, 0) : await viewConsorzioCersRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioCersSmaltimenti
        public async Task<ConsorzioCersSmaltimentiDto> GetConsorzioCersSmaltimentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioCersSmaltimentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioCersSmaltimentiDto, PagedList<ConsorzioCerSmaltimento>>();
            return dtos;
        }

        public async Task<ConsorzioCerSmaltimentoDto> GetConsorzioCerSmaltimentoByIdAsync(long id)
        {
            var entity = await consorzioCersSmaltimentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioCerSmaltimentoDto, ConsorzioCerSmaltimento>();
            return dto;
        }

        public async Task<long> AddConsorzioCerSmaltimentoAsync(ConsorzioCerSmaltimentoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioCerSmaltimento, ConsorzioCerSmaltimentoDto>();
            await consorzioCersSmaltimentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioCerSmaltimentoAsync(ConsorzioCerSmaltimentoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioCerSmaltimento, ConsorzioCerSmaltimentoDto>();
            consorzioCersSmaltimentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioCerSmaltimentoAsync(long id)
        {
            var entity = await consorzioCersSmaltimentiRepo.GetByIdAsync(id);
            consorzioCersSmaltimentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioCerSmaltimentoAsync(long id, string descrizione)
        {
            var entity = await consorzioCersSmaltimentiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioCerSmaltimentoAsync(long id)
        {
            var entity = await consorzioCersSmaltimentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioCersSmaltimentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioCersSmaltimentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ConsorzioComuni
        public async Task<ConsorzioComuniDto> GetConsorzioComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioComuniDto, PagedList<ConsorzioComune>>();
            return dtos;
        }

        public async Task<ConsorzioComuneDto> GetConsorzioComuneByIdAsync(long id)
        {
            var entity = await consorzioComuniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioComuneDto, ConsorzioComune>();
            return dto;
        }

        public async Task<long> AddConsorzioComuneAsync(ConsorzioComuneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioComune, ConsorzioComuneDto>();
            await consorzioComuniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioComuneAsync(ConsorzioComuneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioComune, ConsorzioComuneDto>();
            consorzioComuniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioComuneAsync(long id)
        {
            var entity = await consorzioComuniRepo.GetByIdAsync(id);
            consorzioComuniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioComuneAsync(long id, string descrizione)
        {
            var entity = await consorzioComuniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioComuneAsync(long id)
        {
            var entity = await consorzioComuniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ConsorzioProduttori
        public async Task<ConsorzioProduttoriDto> GetConsorzioProduttoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioProduttoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioProduttoriDto, PagedList<ConsorzioProduttore>>();
            return dtos;
        }

        public async Task<ConsorzioProduttoreDto> GetConsorzioProduttoreByIdAsync(long id)
        {
            var entity = await consorzioProduttoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioProduttoreDto, ConsorzioProduttore>();
            return dto;
        }

        public async Task<long> AddConsorzioProduttoreAsync(ConsorzioProduttoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioProduttore, ConsorzioProduttoreDto>();
            await consorzioProduttoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioProduttoreAsync(ConsorzioProduttoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioProduttore, ConsorzioProduttoreDto>();
            consorzioProduttoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioProduttoreAsync(long id)
        {
            var entity = await consorzioProduttoriRepo.GetByIdAsync(id);
            consorzioProduttoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioProduttoreAsync(long id, string descrizione)
        {
            var entity = await consorzioProduttoriRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioProduttoreAsync(long id)
        {
            var entity = await consorzioProduttoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioProduttoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioProduttoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioProduttori>> GetViewConsorzioProduttoriAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioProduttoriRepo.GetAllAsync(1, 0) : await viewConsorzioProduttoriRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioDestinatari
        public async Task<ConsorzioDestinatariDto> GetConsorzioDestinatariAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioDestinatariRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioDestinatariDto, PagedList<ConsorzioDestinatario>>();
            return dtos;
        }

        public async Task<ConsorzioDestinatarioDto> GetConsorzioDestinatarioByIdAsync(long id)
        {
            var entity = await consorzioDestinatariRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioDestinatarioDto, ConsorzioDestinatario>();
            return dto;
        }

        public async Task<long> AddConsorzioDestinatarioAsync(ConsorzioDestinatarioDto dto)
        {
            var entity = dto.ToEntity<ConsorzioDestinatario, ConsorzioDestinatarioDto>();
            await consorzioDestinatariRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioDestinatarioAsync(ConsorzioDestinatarioDto dto)
        {
            var entity = dto.ToEntity<ConsorzioDestinatario, ConsorzioDestinatarioDto>();
            consorzioDestinatariRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioDestinatarioAsync(long id)
        {
            var entity = await consorzioDestinatariRepo.GetByIdAsync(id);
            consorzioDestinatariRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioDestinatarioAsync(long id, string descrizione)
        {
            var entity = await consorzioDestinatariRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioDestinatarioAsync(long id)
        {
            var entity = await consorzioDestinatariRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioDestinatariRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioDestinatariRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioDestinatari>> GetViewConsorzioDestinatariAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioDestinatariRepo.GetAllAsync(1, 0) : await viewConsorzioDestinatariRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioTrasportatori
        public async Task<ConsorzioTrasportatoriDto> GetConsorzioTrasportatoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioTrasportatoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioTrasportatoriDto, PagedList<ConsorzioTrasportatore>>();
            return dtos;
        }

        public async Task<ConsorzioTrasportatoreDto> GetConsorzioTrasportatoreByIdAsync(long id)
        {
            var entity = await consorzioTrasportatoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioTrasportatoreDto, ConsorzioTrasportatore>();
            return dto;
        }

        public async Task<long> AddConsorzioTrasportatoreAsync(ConsorzioTrasportatoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioTrasportatore, ConsorzioTrasportatoreDto>();
            await consorzioTrasportatoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioTrasportatoreAsync(ConsorzioTrasportatoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioTrasportatore, ConsorzioTrasportatoreDto>();
            consorzioTrasportatoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioTrasportatoreAsync(long id)
        {
            var entity = await consorzioTrasportatoriRepo.GetByIdAsync(id);
            consorzioTrasportatoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioTrasportatoreAsync(long id, string descrizione)
        {
            var entity = await consorzioTrasportatoriRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioTrasportatoreAsync(long id)
        {
            var entity = await consorzioTrasportatoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioTrasportatoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioTrasportatoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioTrasportatori>> GetViewConsorzioTrasportatoriAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioTrasportatoriRepo.GetAllAsync(1, 0) : await viewConsorzioTrasportatoriRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioRegistrazioni
        public async Task<ConsorzioRegistrazioniDto> GetConsorzioRegistrazioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioRegistrazioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioRegistrazioniDto, PagedList<ConsorzioRegistrazione>>();
            return dtos;
        }

        public async Task<ConsorzioRegistrazioneDto> GetConsorzioRegistrazioneByIdAsync(long id)
        {
            var entity = await consorzioRegistrazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioRegistrazioneDto, ConsorzioRegistrazione>();
            return dto;
        }

        public async Task<long> AddConsorzioRegistrazioneAsync(ConsorzioRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazione, ConsorzioRegistrazioneDto>();
            await consorzioRegistrazioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioRegistrazioneAsync(ConsorzioRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazione, ConsorzioRegistrazioneDto>();
            consorzioRegistrazioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioRegistrazioneAsync(long id)
        {
            var entity = await consorzioRegistrazioniRepo.GetByIdAsync(id);
            consorzioRegistrazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioRegistrazioneAsync(long id, string userId)
        {
            var entity = await consorzioRegistrazioniRepo.GetWithFilterAsync(x => x.UserId == userId && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioRegistrazioneAsync(long id)
        {
            var entity = await consorzioRegistrazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioniAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioRegistrazioniRepo.GetAllAsync(1, 0) : await viewConsorzioRegistrazioniRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }

        public async Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioneByRolesAsync(string roles)
        {
            var entities = await viewConsorzioRegistrazioniRepo.GetWithFilterAsync(x => x.Roles == roles);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioRegistrazioniAllegati
        public async Task<ConsorzioRegistrazioniAllegatiDto> GetConsorzioRegistrazioniAllegatiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioRegistrazioniAllegatiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioRegistrazioniAllegatiDto, PagedList<ConsorzioRegistrazioneAllegato>>();
            return dtos;
        }

        public async Task<ConsorzioRegistrazioneAllegatoDto> GetConsorzioRegistrazioneAllegatoByIdAsync(long id)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioRegistrazioneAllegatoDto, ConsorzioRegistrazioneAllegato>();
            return dto;
        }

        public async Task<long> AddConsorzioRegistrazioneAllegatoAsync(ConsorzioRegistrazioneAllegatoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazioneAllegato, ConsorzioRegistrazioneAllegatoDto>();
            await consorzioRegistrazioniAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioRegistrazioneAllegatoAsync(ConsorzioRegistrazioneAllegatoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazioneAllegato, ConsorzioRegistrazioneAllegatoDto>();
            consorzioRegistrazioniAllegatiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioRegistrazioneAllegatoAsync(long id)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetByIdAsync(id);
            consorzioRegistrazioniAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioRegistrazioneAllegatoAsync(long id, string descrizione)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioRegistrazioneAllegatoAsync(long id)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioRegistrazioniAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioRegistrazioniAllegatiRepo.Update(entity);
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
