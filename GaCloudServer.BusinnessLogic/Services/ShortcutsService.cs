using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Quicklinks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Shortcuts.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class ShortcutsService:IShortcutsService

    {
        protected readonly IGenericRepository<ShortcutLink> shortcutLinksRepo;
        protected readonly IGenericRepository<ShortcutItem> shortcutItemsRepo;
        protected readonly IGenericRepository<QuickLink> quickLinksRepo;

        protected readonly IGenericRepository<ViewShortcutItems> viewShortcutItemsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public ShortcutsService(
            IGenericRepository<ShortcutLink> shortcutLinksRepo,
            IGenericRepository<ShortcutItem> shortcutItemsRepo,
            IGenericRepository<QuickLink> quickLinksRepo,

            IGenericRepository<ViewShortcutItems> viewShortcutItemsRepo,

            IUnitOfWork unitOfWork)
        {
            this.shortcutLinksRepo = shortcutLinksRepo;
            this.shortcutItemsRepo = shortcutItemsRepo;
            this.quickLinksRepo = quickLinksRepo;

            this.viewShortcutItemsRepo = viewShortcutItemsRepo;

            this.unitOfWork = unitOfWork;

        }

        #region ShortcutLinks
        public async Task<PageResponse<ShortcutLinkDto>> GetShortcutLinksAsync(PageRequest request)
        {
            var entity = await shortcutLinksRepo.GetAsync(new PageRequest() { });
            var dto = entity.ToModel<PageResponse<ShortcutLinkDto>>();
            return dto;
        }
        public async Task<PageResponse<ShortcutLinkDto>> GetShortcutLinksByRolesAsync(string roles)
        {
            // Protezione input
            if (string.IsNullOrWhiteSpace(roles))
            {
                return new PageResponse<ShortcutLinkDto>
                {
                    Items = Enumerable.Empty<ShortcutLinkDto>(),
                    Count = 0
                };
            }

            // HashSet per lookup O(1)
            var roleSet = roles
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(r => r.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            // Recupero dati
            var links = await shortcutLinksRepo.GetWithFilterAsync(x => !x.Disabled);

            // Filtraggio + mapping in un unico passaggio
            var filtered = links.Data
                .Where(link =>
                    !string.IsNullOrWhiteSpace(link.Roles) &&
                    link.Roles
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(r => r.Trim())
                        .Any(roleSet.Contains)
                )
                .Select(link => link.ToDto<ShortcutLinkDto, ShortcutLink>())
                .ToList();

            // Costruzione response corretta
            return new PageResponse<ShortcutLinkDto>
            {
                Items = filtered,
                Count = filtered.Count
            };
        }


        public async Task<ShortcutLinkDto> GetShortcutLinkByIdAsync(long id)
        {
            var entity = await shortcutLinksRepo.GetAsync(id, new PageRequest() { });
            var dto = entity.ToModel<ShortcutLinkDto>();
            return dto;
        }

        public async Task<long> CreateShortcutLinkAsync(ShortcutLinkDto model)
        {
            var entity = model.ToEntity<ShortcutLink, ShortcutLinkDto>();
            await shortcutLinksRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateShortcutLinkAsync(long id, ShortcutLinkDto model)
        {
            var entity = model.ToEntity<ShortcutLink, ShortcutLinkDto>();
            entity.Id = id;
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
        public async Task<PageResponse<ShortcutItemDto>> GetShortcutItemsAsync(PageRequest request)
        {
            var entities = await shortcutItemsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<ShortcutItemDto>>();
            return dtos;
        }

        public async Task<ShortcutItemDto> GetShortcutItemByIdAsync(long id)
        {
            var entity = await shortcutItemsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ShortcutItemDto, ShortcutItem>();
            return dto;
        }

        public async Task<long> CreateShortcutItemAsync(ShortcutItemDto model)
        {
            var entity = model.ToEntity<ShortcutItem, ShortcutItemDto>();
            await shortcutItemsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateShortcutItemAsync(long id, ShortcutItemDto model)
        {
            var entity = model.ToEntity<ShortcutItem, ShortcutItemDto>();
            entity.Id = id;
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
        public async Task<PageResponse<ViewShortcutItems>> GetViewShortcutByUserIdAsync(string userId)
        {
            var view = await viewShortcutItemsRepo.GetAsync(new PageRequest() { Filter=$"UserId eq '{userId}'"});
            return view;
        }
        #endregion

        #endregion

        #region QuickLinks
        public async Task<PageResponse<QuickLinkDto>> GetQuickLinksAsync(PageRequest request)
        {
            var entities = await quickLinksRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<QuickLinkDto>>();
            return dtos;
        }

        public async Task<QuickLinkDto> GetQuickLinkByIdAsync(long id)
        {
            var entity = await quickLinksRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<QuickLinkDto>();
            return dto;
        }

        public async Task<long> CreateQuickLinkAsync(QuickLinkDto model)
        {
            var entity = model.ToEntity<QuickLink, QuickLinkDto>();
            var response = await quickLinksRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateQuickLinkAsync(long id, QuickLinkDto model)
        {
            var entity = model.ToEntity<QuickLink, QuickLinkDto>();
            entity.Id = id;
            var response = await quickLinksRepo.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteQuickLinkAsync(long id)
        {
            await quickLinksRepo.DeleteAsync(id);
            return true;
        }
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
