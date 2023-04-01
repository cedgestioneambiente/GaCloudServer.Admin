using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Tasks;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class TasksService : ITasksService

    {
        protected readonly IGenericRepository<TasksItem> tasksItemsRepo;
        protected readonly IGenericRepository<TasksTag> tasksTagsRepo;

        protected readonly IGenericRepository<ViewTasks> viewTasksRepo;


        protected readonly IUnitOfWork unitOfWork;

        public TasksService(
            IGenericRepository<TasksItem> tasksItemsRepo,
            IGenericRepository<TasksTag> tasksTagsRepo,

            IGenericRepository<ViewTasks> viewTasksRepo,

            IUnitOfWork unitOfWork)
        {
            this.tasksItemsRepo = tasksItemsRepo;
            this.tasksTagsRepo = tasksTagsRepo;

            this.viewTasksRepo = viewTasksRepo;

            this.unitOfWork = unitOfWork;

        }

        #region TasksItems
        public async Task<TasksItemsDto> GetTasksItemsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await tasksItemsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<TasksItemsDto, PagedList<TasksItem>>();
            return dtos;
        }

        public async Task<TasksItemDto> GetTasksItemByIdAsync(long id)
        {
            var entity = await tasksItemsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<TasksItemDto, TasksItem>();
            return dto;
        }

        public async Task<long> AddTasksItemAsync(TasksItemDto dto)
        {
            var entity = dto.ToEntity<TasksItem, TasksItemDto>();
            await tasksItemsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateTasksItemAsync(TasksItemDto dto)
        {
            var entity = dto.ToEntity<TasksItem, TasksItemDto>();
            tasksItemsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteTasksItemAsync(long id)
        {
            var entity = await tasksItemsRepo.GetByIdAsync(id);
            tasksItemsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateTasksItemAsync(long id, string descrizione)
        {
            var entity = await tasksItemsRepo.GetWithFilterAsync(x => x.Title == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusTasksItemAsync(long id)
        {
            var entity = await tasksItemsRepo.GetByIdAsync(id);
            if (entity.Completed)
            {
                entity.Completed = false;
                tasksItemsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Completed = true;
                tasksItemsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewTasks>> GetViewTasksAsync(bool all = true)
        {
            var entities = all ? await viewTasksRepo.GetAllAsync(1, 0) : await viewTasksRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }

        public async Task<PagedList<ViewTasks>> GetViewTasksByUserIdAsync(string userId)
        {
            var entities = await viewTasksRepo.GetWithFilterAsync(x => x.UserId == userId);
            return entities;
        }
        #endregion

        #endregion

        #region TasksTags
        public async Task<TasksTagsDto> GetTasksTagsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await tasksTagsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<TasksTagsDto, PagedList<TasksTag>>();
            return dtos;
        }

        public async Task<TasksTagDto> GetTasksTagByIdAsync(long id)
        {
            var entity = await tasksTagsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<TasksTagDto, TasksTag>();
            return dto;
        }

        public async Task<long> AddTasksTagAsync(TasksTagDto dto)
        {
            var entity = dto.ToEntity<TasksTag, TasksTagDto>();
            await tasksTagsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateTasksTagAsync(TasksTagDto dto)
        {
            var entity = dto.ToEntity<TasksTag, TasksTagDto>();
            tasksTagsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteTasksTagAsync(long id)
        {
            var entity = await tasksTagsRepo.GetByIdAsync(id);
            tasksTagsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateTasksTagAsync(long id, string descrizione)
        {
            var entity = await tasksTagsRepo.GetWithFilterAsync(x => x.Title == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusTasksTagAsync(long id)
        {
            var entity = await tasksTagsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                tasksTagsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                tasksTagsRepo.Update(entity);
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

