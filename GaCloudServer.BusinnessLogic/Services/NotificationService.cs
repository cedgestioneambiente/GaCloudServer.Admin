using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Notification.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Notification;
using GaCloudServer.BusinnessLogic.Hub;
using GaCloudServer.BusinnessLogic.Hub.Interfaces;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class NotificationService : INotificationService
    {
        protected readonly IGenericRepository<NotificationApp> notificationAppsRepo;
        protected readonly IGenericRepository<NotificationRoleOnApp> notificationRolesOnAppsRepo;
        protected readonly IGenericRepository<NotificationUserOnApp> notificationUsersOnAppsRepo;
        protected readonly IGenericRepository<NotificationEvent> notificationEventsRepo;

        protected readonly IGenericRepository<ViewNotificationRolesOnApps> viewNotificationRolesOnAppsRepo;
        protected readonly IGenericRepository<ViewNotificationUsersOnApps> viewNotificationUsersOnAppsRepo;
        protected readonly IGenericRepository<ViewNotificationEvents> viewNotificationEventsRepo;


        protected readonly IUnitOfWork unitOfWork;

        private readonly IHubContext<NotificationHub, INotificationHub> hub;


        public NotificationService(
        IGenericRepository<NotificationApp> notificationAppsRepo,
        IGenericRepository<NotificationRoleOnApp> notificationRolesOnAppsRepo,
        IGenericRepository<NotificationUserOnApp> notificationUsersOnAppsRepo,
        IGenericRepository<NotificationEvent> notificationEventsRepo,

        IGenericRepository<ViewNotificationRolesOnApps> viewNotificationRolesOnAppsRepo,
        IGenericRepository<ViewNotificationUsersOnApps> viewNotificationUsersOnAppsRepo,
        IGenericRepository<ViewNotificationEvents> viewNotificationEventsRepo,

        IUnitOfWork unitOfWork,
        IHubContext<NotificationHub, INotificationHub> hub
        )
        {
            this.notificationAppsRepo = notificationAppsRepo;
            this.notificationRolesOnAppsRepo = notificationRolesOnAppsRepo;
            this.notificationUsersOnAppsRepo = notificationUsersOnAppsRepo;
            this.notificationEventsRepo = notificationEventsRepo;

            this.viewNotificationRolesOnAppsRepo = viewNotificationRolesOnAppsRepo;
            this.viewNotificationUsersOnAppsRepo = viewNotificationUsersOnAppsRepo;
            this.viewNotificationEventsRepo = viewNotificationEventsRepo;

            this.unitOfWork = unitOfWork;
            this.hub = hub;


        }


        #region NotificationApps
        public async Task<NotificationAppsDto> GetNotificationAppsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await notificationAppsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<NotificationAppsDto, PagedList<NotificationApp>>();
            return dtos;
        }

        public async Task<NotificationAppDto> GetNotificationAppByIdAsync(long id)
        {
            var entity = await notificationAppsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<NotificationAppDto, NotificationApp>();
            return dto;
        }
        public async Task<NotificationAppDto> GetNotificationAppByDescrizioneAsync(string descrizione)
        {
            var entity = await notificationAppsRepo.GetSingleWithFilter(x=>x.Descrizione==descrizione);
            var dto = entity.ToDto<NotificationAppDto, NotificationApp>();
            return dto;
        }

        public async Task<long> AddNotificationAppAsync(NotificationAppDto dto)
        {
            var entity = dto.ToEntity<NotificationApp, NotificationAppDto>();
            await notificationAppsRepo.AddAsync(entity);
            await SaveChanges();

            return entity.Id;
        }

        public async Task<long> UpdateNotificationAppAsync(NotificationAppDto dto)
        {
            var entity = dto.ToEntity<NotificationApp, NotificationAppDto>();
            notificationAppsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteNotificationAppAsync(long id)
        {
            var entity = await notificationAppsRepo.GetByIdAsync(id);
            notificationAppsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateNotificationAppAsync(long id, string descrizione)
        {
            var entity = await notificationAppsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusNotificationAppAsync(long id)
        {
            var entity = await notificationAppsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                notificationAppsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                notificationAppsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region NotificationRolesOnApps
        public async Task<bool> UpdateNotificationRoleOnAppFromViewAsync(ViewNotificationRolesOnApps view)
        {
            if (view.Enabled)
            {
                //DELETE
                var entity = await notificationRolesOnAppsRepo.GetSingleWithFilter(x => x.NotificationAppId == view.Id && x.RoleId == view.RoleId);
                notificationRolesOnAppsRepo.Remove(entity);
                await SaveChanges();

                return true;
            }
            else
            {
                //ADD
                var entity = new NotificationRoleOnApp();
                entity.NotificationAppId = view.Id;
                entity.RoleId = view.RoleId;
                entity.Disabled = false;
                await notificationRolesOnAppsRepo.AddAsync(entity);
                await SaveChanges();
                return true;
            }
        }

       

        #region Views
        public async Task<PagedList<ViewNotificationRolesOnApps>> GetViewViewNotificationRolesOnAppsAsync(bool all = true)
        {
            var view = all ? await viewNotificationRolesOnAppsRepo.GetAllAsync() : await viewNotificationRolesOnAppsRepo.GetWithFilterAsync(x => x.Disabled == false);
            return view;
        }

        public async Task<PagedList<ViewNotificationRolesOnApps>> GetViewViewNotificationRolesOnAppsByAppIdAsync(long appId)
        {
            var view = await viewNotificationRolesOnAppsRepo.GetWithFilterAsync(x=>x.Id==appId,1,0,"Name");
            return view;
        }
        #endregion

        #endregion

        #region NotificationUsersOnApps
        public async Task<bool> UpdateNotificationUserOnAppFromViewAsync(ViewNotificationUsersOnApps view)
        {
            if (view.Enabled)
            {
                //DELETE
                var entity = await notificationUsersOnAppsRepo.GetSingleWithFilter(x => x.NotificationAppId == view.AppId && x.UserId == view.UserId);
                notificationUsersOnAppsRepo.Remove(entity);
                await SaveChanges();

                return true;
            }
            else
            {
                //ADD
                var entity = new NotificationUserOnApp();
                entity.NotificationAppId = view.AppId;
                entity.UserId = view.UserId;
                entity.Disabled = false;
                await notificationUsersOnAppsRepo.AddAsync(entity);
                await SaveChanges();
                return true;
            }
        }



        #region Views
        public async Task<PagedList<ViewNotificationUsersOnApps>> GetViewViewNotificationUsersOnAppsAsync(bool all = true)
        {
            var view = all ? await viewNotificationUsersOnAppsRepo.GetWithFilterAsync(x=>x.Show==true) : await viewNotificationUsersOnAppsRepo.GetWithFilterAsync(x => x.Disabled == false && x.Show==true);
            return view;
        }

        public async Task<PagedList<ViewNotificationUsersOnApps>> GetViewViewNotificationUsersOnAppsByUserIdAsync(string userId)
        {
            var view = await viewNotificationUsersOnAppsRepo.GetWithFilterAsync(x => x.UserId == userId && x.Show==true, 1, 0, "AppName");
            return view;
        }

        public async Task<PagedList<ViewNotificationUsersOnApps>> GetViewViewNotificationUsersOnAppsByAppIdAsync(long AppId)
        {
            var view = await viewNotificationUsersOnAppsRepo.GetWithFilterAsync(x => x.AppId == AppId && x.Enabled==true, 1, 0, "AppName");
            return view;
        }
        #endregion

        #endregion

        #region NotificationEvents
        public async Task<long> AddNotificationEventAsync(NotificationEventDto dto)
        {
            var entity = dto.ToEntity<NotificationEvent, NotificationEventDto>();
            await notificationEventsRepo.AddAsync(entity);
            await SaveChanges();

            //await hub.Clients.All.SendNotification(dto);

            await hub.Clients.Groups(dto.UserId).SendNotification(dto);

            return entity.Id;
        }

        public async Task<bool> DeleteNotificationEventAsync(long id)
        {
            var entity = await notificationEventsRepo.GetByIdAsync(id);
            notificationEventsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ChangeStatusNotificationEventAsync(long id)
        {
            var entity = await notificationEventsRepo.GetByIdAsync(id);
            if (entity.Read)
            {
                entity.Read = false;
                notificationEventsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Read = true;
                notificationEventsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewNotificationEvents>> GetViewViewNotificationEventsByUserIdAsync(string userId, bool all = true)
        {
            var view = all ? await viewNotificationEventsRepo.GetWithFilterAsync(x => x.UserId == userId,1,0,"DateEvent","OrderByDescending") : await viewNotificationEventsRepo.GetWithFilterAsync(x => x.UserId == userId && x.Read == false, 1, 0, "DateEvent", "OrderByDescending");
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
