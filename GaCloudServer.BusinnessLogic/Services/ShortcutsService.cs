using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class ShortcutsService:IShortcutsService

    {
        protected readonly IGenericRepository<ShortcutLink> shortcutLinksRepo;
        protected readonly IGenericRepository<ShortcutItem> shortcutItemsRepo;

        protected readonly IGenericRepository<ViewShortcutItems> viewShortcutItemsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public ShortcutsService(
            IGenericRepository<ShortcutLink> shortcutLinksRepo,
            IGenericRepository<ShortcutItem> shortcutItemsRepo,

            IGenericRepository<ViewShortcutItems> viewShortcutItemsRepo,

            IUnitOfWork unitOfWork)
        {
            this.shortcutLinksRepo = shortcutLinksRepo;
            this.shortcutItemsRepo = shortcutItemsRepo;

            this.viewShortcutItemsRepo = viewShortcutItemsRepo;

            this.unitOfWork = unitOfWork;

        }

        #region ShortcutLinks
        public async Task<ShortcutLinksDto> GetShortcutLinksAsync(int page = 1, int pageSize = 0)
        {
            var entities = await shortcutLinksRepo.GetAllAsync(page,pageSize);
            var dtos= entities.ToDto<ShortcutLinksDto, PagedList<ShortcutLink>>();
            return dtos;
        }

        public async Task<ShortcutLinksDto> GetShortcutLinksByRolesAsync(string roles)
        {
            var masterSet=new HashSet<string>(roles.Split(","));
            string[] keyword = roles.Split(new char[] { ',' });

            string[] rolesArray = roles.Split(",");
            var links = await shortcutLinksRepo.GetWithFilterAsync(x => x.Disabled==false);

            ShortcutLinksDto dtos = new ShortcutLinksDto();
            List<ShortcutLinkDto> list = new List<ShortcutLinkDto>();
            foreach (var itm in links.Data)
            {
                if (itm.Roles.Split(",").Any(x => keyword.Contains(x)))
                {
                    list.Add(itm.ToDto<ShortcutLinkDto,ShortcutLink>());
                }
            }
            dtos.Data.AddRange(list);
            dtos.TotalCount = list.Count;
            dtos.PageSize = 0;
            return dtos;
        }

        public async Task<ShortcutLinkDto> GetShortcutLinkByIdAsync(long id)
        {
            var entity = await shortcutLinksRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ShortcutLinkDto, ShortcutLink>();
            return dto;
        }

        public async Task<long> AddShortcutLinkAsync(ShortcutLinkDto dto)
        {
            var entity = dto.ToEntity<ShortcutLink, ShortcutLinkDto>();
            await shortcutLinksRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateShortcutLinkAsync(ShortcutLinkDto dto)
        {
            var entity = dto.ToEntity<ShortcutLink, ShortcutLinkDto>();
            shortcutLinksRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteShortcutLinkAsync(long id)
        {
            var entity = await shortcutLinksRepo.GetByIdAsync(id);
            shortcutLinksRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateShortcutLinkAsync(long id, string link)
        {
            var entity = await shortcutLinksRepo.GetWithFilterAsync(x => x.Link == link && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusShortcutLinkAsync(long id)
        {
            var entity = await shortcutLinksRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                shortcutLinksRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                shortcutLinksRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            
        }
        #endregion

        #endregion

        #region ShortcutItems
        public async Task<ShortcutItemsDto> GetShortcutItemsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await shortcutItemsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ShortcutItemsDto, PagedList<ShortcutItem>>();
            return dtos;
        }

        public async Task<ShortcutItemDto> GetShortcutItemByIdAsync(long id)
        {
            var entity = await shortcutItemsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ShortcutItemDto, ShortcutItem>();
            return dto;
        }

        public async Task<long> AddShortcutItemAsync(ShortcutItemDto dto)
        {
            var entity = dto.ToEntity<ShortcutItem, ShortcutItemDto>();
            await shortcutItemsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateShortcutItemAsync(ShortcutItemDto dto)
        {
            var entity = dto.ToEntity<ShortcutItem, ShortcutItemDto>();
            shortcutItemsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteShortcutItemAsync(long id)
        {
            var entity = await shortcutItemsRepo.GetByIdAsync(id);
            shortcutItemsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Views
        public async Task<PagedList<ViewShortcutItems>> GetViewShortcutByUserIdAsync(string userId)
        {
            var view = await viewShortcutItemsRepo.GetWithFilterAsync(x=>x.UserId==userId);
            return view;
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
