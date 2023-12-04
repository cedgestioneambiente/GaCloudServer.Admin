using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti;
using GaCloudServer.BusinnessLogic.Helpers;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Graph;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaProgettiService : IGaProgettiService
    {
        protected readonly IGenericRepository<ProgettiWork> gaProgettiWorksRepo;
        protected readonly IGenericRepository<ProgettiJob> gaProgettiJobsRepo;
        protected readonly IGenericRepository<ProgettiJobAllegato> gaProgettiJobAllegatiRepo;
        protected readonly IGenericRepository<ProgettiJobTask> gaProgettiJobTasksRepo;
        protected readonly IGenericRepository<ProgettiWorkSetting> gaProgettiWorkSettingsRepo;
        protected readonly IGenericRepository<ProgettiJobUndertaking> gaProgettiJobsUndertakingsRepo;
        protected readonly IGenericRepository<ProgettiJobUndertakingState> gaProgettiJobsUndertakingsStatesRepo;
        protected readonly IGenericRepository<ProgettiJobUndertakingAllegato> gaProgettiJobsUndertakingsAllegatiRepo;

        protected readonly IGenericRepository<ViewGaProgettiJobs> viewGaProgettiJobsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaProgettiService(
            IGenericRepository<ProgettiWork> gaProgettiWorksRepo,
            IGenericRepository<ProgettiJob> gaProgettiJobsRepo,
            IGenericRepository<ProgettiJobAllegato> gaProgettiJobAllegatiRepo,
            IGenericRepository<ProgettiJobTask> gaProgettiJobTasksRepo,
            IGenericRepository<ProgettiWorkSetting> gaProgettiWorkSettingsRepo,
            IGenericRepository<ProgettiJobUndertaking> gaProgettiJobsUndertakingsRepo,
            IGenericRepository<ProgettiJobUndertakingState> gaProgettiJobsUndertakingsStatesRepo,
            IGenericRepository<ProgettiJobUndertakingAllegato> gaProgettiJobsUndertakingsAllegatiRepo,

            IGenericRepository<ViewGaProgettiJobs> viewGaProgettiJobsRepo,

        IUnitOfWork unitOfWork)
        {
            this.gaProgettiWorksRepo = gaProgettiWorksRepo;
            this.gaProgettiJobsRepo = gaProgettiJobsRepo;
            this.gaProgettiJobAllegatiRepo = gaProgettiJobAllegatiRepo;
            this.gaProgettiJobTasksRepo = gaProgettiJobTasksRepo;
            this.gaProgettiWorkSettingsRepo = gaProgettiWorkSettingsRepo;
            this.gaProgettiJobsUndertakingsRepo = gaProgettiJobsUndertakingsRepo;
            this.gaProgettiJobsUndertakingsStatesRepo = gaProgettiJobsUndertakingsStatesRepo;
            this.gaProgettiJobsUndertakingsAllegatiRepo = gaProgettiJobsUndertakingsAllegatiRepo;

            this.viewGaProgettiJobsRepo = viewGaProgettiJobsRepo;

            this.unitOfWork = unitOfWork;

        }

        #region ProgettiWorks
        public async Task<ProgettiWorksDto> GetGaProgettiWorksAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaProgettiWorksRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ProgettiWorksDto, PagedList<ProgettiWork>>();
            return dtos;
        }

        public async Task<ProgettiWorksDto> GetGaProgettiWorksByUserAsync(string userId)
        {
            var entities = await gaProgettiWorksRepo.GetWithFilterAsync(x => x.Disabled == false && x.Resources.Contains(userId));
            var dtos = entities.ToDto<ProgettiWorksDto, PagedList<ProgettiWork>>();
            return dtos;

        }

        public async Task<ProgettiWorkDto> GetGaProgettiWorkByIdAsync(long id)
        {
            var entity = await gaProgettiWorksRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiWorkDto, ProgettiWork>();
            return dto;
        }



        public async Task<long> AddGaProgettiWorkAsync(ProgettiWorkDto dto)
        {
            var entity = dto.ToEntity<ProgettiWork, ProgettiWorkDto>();
            await gaProgettiWorksRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiWorkAsync(ProgettiWorkDto dto)
        {
            var entity = dto.ToEntity<ProgettiWork, ProgettiWorkDto>();
            gaProgettiWorksRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiWorkAsync(long id)
        {
            var entity = await gaProgettiWorksRepo.GetByIdAsync(id);
            gaProgettiWorksRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaProgettiWorkAsync(long id, string descrizione)
        {
            var entity = await gaProgettiWorksRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaProgettiWorkAsync(long id)
        {
            var entity = await gaProgettiWorksRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaProgettiWorksRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaProgettiWorksRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ProgettiJobs
        public async Task<ProgettiJobsDto> GetGaProgettiJobsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaProgettiJobsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ProgettiJobsDto, PagedList<ProgettiJob>>();
            return dtos;
        }

        public async Task<ProgettiJobsDto> GetGaProgettiJobsByWorkIdAsync(long workId)
        {
            var entities = await gaProgettiJobsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiWorkId==workId);
            var dtos = entities.ToDto<ProgettiJobsDto, PagedList<ProgettiJob>>();
            return dtos;

        }
        public async Task<ProgettiJobsDto> GetGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId)
        {
            var entities = await gaProgettiJobsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiWorkId == workId && x.ParentId==parentId);
            var dtos = entities.ToDto<ProgettiJobsDto, PagedList<ProgettiJob>>();
            return dtos;

        }

        public async Task<ProgettiJobDto> GetGaProgettiJobByIdAsync(long id)
        {
            var entity = await gaProgettiJobsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiJobDto, ProgettiJob>();
            return dto;
        }

        public async Task<long> AddGaProgettiJobAsync(ProgettiJobDto dto)
        {
            var entity = dto.ToEntity<ProgettiJob, ProgettiJobDto>();
            await gaProgettiJobsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiJobAsync(ProgettiJobDto dto)
        {
            var entity = dto.ToEntity<ProgettiJob, ProgettiJobDto>();
            gaProgettiJobsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiJobAsync(long id)
        {
            var entity = await gaProgettiJobsRepo.GetByIdAsync(id);
            gaProgettiJobsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaProgettiJobAsync(long id, string descrizione,long workId,long parentId)
        {
            var entity = await gaProgettiJobsRepo.GetWithFilterAsync(x => x.Title == descrizione && x.ProgettiWorkId==workId && x.ParentId== parentId && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaProgettiJobAsync(long id)
        {
            var entity = await gaProgettiJobsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaProgettiJobsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaProgettiJobsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<bool> AddGaProgettiJobLinkAsync(long sourceId, long targetId)
        {
            var entity = await gaProgettiJobsRepo.GetByIdAsync(sourceId);

            if (entity.Links!=null && entity.Links.Contains(targetId.ToString()))
            {
                return true;
            }
            else
            {
                var links = new List<string>(entity.Links != null?entity.Links.Split(","):new List<string>());
                links.Add(targetId.ToString());

                entity.Links = string.Join(",", links);
                gaProgettiJobsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

            
        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaProgettiJobs>> GetViewGaProgettiJobsByWorkIdAsync(long workId)
        {
            var view = await viewGaProgettiJobsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiWorkId == workId);
            return view;

        }

        public async Task<List<GanttItemDto>> GetViewGaProgettiJobsByWorkIdWithChildrenAsync(long workId)
        {
            var view = await viewGaProgettiJobsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiWorkId == workId);
            List<GanttItemDto> nestedObjects = new List<GanttItemDto>();

            foreach (var itm in view.Data.OrderBy(x=>x.Start))
            { 
                var obj= new GanttItemDto();
                obj.Id = itm.Id;
                obj.Title = itm.Title;
                obj.Start = itm.Start;
                obj.End = itm.End;
                obj.Group_id = itm.Group_id;
                obj.Links = itm.Links;
                obj.Linkable = itm.Linkable;
                obj.Draggable = itm.Draggable;
                obj.ItemDraggable = itm.Draggable;
                obj.Expandable = itm.Expandable;
                obj.ParentId = itm.ParentId;
                obj.Color = itm.Color;
                obj.Type = itm.Type;
                obj.Progress = Convert.ToDouble(itm.Progress)/100;
                obj.ProgettiWorkId = itm.ProgettiWorkId;
                obj.Resources = itm.Resources;
                obj.Priority = itm.Priority;
                obj.Completed = itm.Completed;
                obj.Approved = itm.Approved;
                obj.Info = itm.Info;

                nestedObjects.Add(obj);
            }

            var nestedMap = nestedObjects.ToDictionary(obj => obj.Id);

            List<GanttItemDto> nestedStructure = new List<GanttItemDto>();
            foreach (var obj in nestedObjects)
            {
                if (obj.ParentId == 0)
                {
                    nestedStructure.Add(obj);
                    NestedHelper.BuildNestedStructure(obj, nestedMap);
                }
            }

            return nestedStructure;

        }

        public async Task<List<GanttItemDto>> GetViewGaProgettiJobsByWorkIdWithChildrenAndStatusAsync(long workId,bool all=true)
        {
            var view = all==true? await viewGaProgettiJobsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiWorkId == workId):
                await viewGaProgettiJobsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiWorkId == workId && x.Completed==false);


            List<GanttItemDto> nestedObjects = new List<GanttItemDto>();

            foreach (var itm in view.Data.OrderBy(x => x.Start))
            {
                var obj = new GanttItemDto();
                obj.Id = itm.Id;
                obj.Title = itm.Title;
                obj.Start = itm.Start;
                obj.End = itm.End;
                obj.Group_id = itm.Group_id;
                obj.Links = itm.Links;
                obj.Linkable = itm.Linkable;
                obj.Draggable = itm.Draggable;
                obj.ItemDraggable = itm.Draggable;
                obj.Expandable = itm.Expandable;
                obj.ParentId = itm.ParentId;
                obj.Color = itm.Color;
                obj.Type = itm.Type;
                obj.Progress = Convert.ToDouble(itm.Progress) / 100;
                obj.ProgettiWorkId = itm.ProgettiWorkId;
                obj.Resources = itm.Resources;
                obj.Priority = itm.Priority;
                obj.Completed = itm.Completed;
                obj.Approved = itm.Approved;
                obj.Info = itm.Info;

                nestedObjects.Add(obj);
            }

            var nestedMap = nestedObjects.ToDictionary(obj => obj.Id);

            List<GanttItemDto> nestedStructure = new List<GanttItemDto>();
            foreach (var obj in nestedObjects)
            {
                if (obj.ParentId == 0)
                {
                    nestedStructure.Add(obj);
                    NestedHelper.BuildNestedStructure(obj, nestedMap);
                }
            }

            return nestedStructure;

        }
        public async Task<PagedList<ViewGaProgettiJobs>> GetViewGaProgettiJobsByWorkIdAndParentIdAsync(long workId,long parentId)
        {
            var view = await viewGaProgettiJobsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiWorkId == workId && x.ParentId==parentId);
            return view;

        }
        #endregion

        #endregion

        #region ProgettiJobAllegati
        public async Task<ProgettiJobAllegatiDto> GetGaProgettiJobAllegatiByJobIdAsync(long jobId)
        {
            var entities = await gaProgettiJobAllegatiRepo.GetWithFilterAsync(x => x.ProgettiJobId == jobId);
            var dtos = entities.ToDto<ProgettiJobAllegatiDto, PagedList<ProgettiJobAllegato>>();
            return dtos;
        }

        public async Task<ProgettiJobAllegatoDto> GetGaProgettiJobAllegatoByIdAsync(long id)
        {
            var entity = await gaProgettiJobAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiJobAllegatoDto, ProgettiJobAllegato>();
            return dto;
        }

        public async Task<long> AddGaProgettiJobAllegatoAsync(ProgettiJobAllegatoDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobAllegato, ProgettiJobAllegatoDto>();
            await gaProgettiJobAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiJobAllegatoAsync(ProgettiJobAllegatoDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobAllegato, ProgettiJobAllegatoDto>();
            gaProgettiJobAllegatiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiJobAllegatoAsync(long id)
        {
            var entity = await gaProgettiJobAllegatiRepo.GetByIdAsync(id);
            gaProgettiJobAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        #endregion

        #endregion

        #region ProgettiJobTasks
        public async Task<ProgettiJobTasksDto> GetGaProgettiJobTasksByJobIdAsync(long jobId)
        {
            var entities = await gaProgettiJobTasksRepo.GetWithFilterAsync(x => x.ProgettiJobId == jobId);
            var dtos = entities.ToDto<ProgettiJobTasksDto, PagedList<ProgettiJobTask>>();
            return dtos;
        }

        public async Task<ProgettiJobTaskDto> GetGaProgettiJobTaskByIdAsync(long id)
        {
            var entity = await gaProgettiJobTasksRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiJobTaskDto, ProgettiJobTask>();
            return dto;
        }

        public async Task<long> AddGaProgettiJobTaskAsync(ProgettiJobTaskDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobTask, ProgettiJobTaskDto>();
            await gaProgettiJobTasksRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiJobTaskAsync(ProgettiJobTaskDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobTask, ProgettiJobTaskDto>();
            gaProgettiJobTasksRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiJobTaskAsync(long id)
        {
            var entity = await gaProgettiJobTasksRepo.GetByIdAsync(id);
            gaProgettiJobTasksRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions

        #endregion

        #endregion

        #region ProgettiWorkSettings
        public async Task<ProgettiWorkSettingDto> GetGaProgettiWorkSettingByWorkIdAndUserIdAsync(long workId, string userId)
        {
            var entities = await gaProgettiWorkSettingsRepo.GetWithFilterAsync(x => x.ProgettiWorkId == workId && x.UserId==userId);
            var setting = entities.Data.FirstOrDefault();
            if (setting == null)
            {
                var entity = new ProgettiWorkSetting();
                entity.Id = 0;
                entity.Disabled = false;
                entity.ProgettiWorkId = workId;
                entity.UserId = userId;
                entity.AddJobNotification = false;
                entity.UpdateJobNotification = false;
                entity.DeleteJobNotification = false;
                await gaProgettiWorkSettingsRepo.AddAsync(entity);

                var dto = entity.ToDto<ProgettiWorkSettingDto, ProgettiWorkSetting>();
                return dto;


            }
            else { 
                var dto= setting.ToDto<ProgettiWorkSettingDto, ProgettiWorkSetting>();
                return dto;
            }

        }
        public async Task<ProgettiWorkSettingsDto> GetGaProgettiWorkSettingsByWorkIdAsync(long workId)
        {
            var entities = await gaProgettiWorkSettingsRepo.GetWithFilterAsync(x => x.ProgettiWorkId == workId);
            var dtos = entities.ToDto<ProgettiWorkSettingsDto, PagedList<ProgettiWorkSetting>>();
            return dtos;

        }
        public async Task<long> UpdateGaProgettiWorkSettingAsync(ProgettiWorkSettingDto dto)
        {
            var entity = dto.ToEntity<ProgettiWorkSetting, ProgettiWorkSettingDto>();
            gaProgettiWorkSettingsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }
        #endregion

        #region ProgettiJobsUndertakings
        public async Task<ProgettiJobsUndertakingsDto> GetGaProgettiJobsUndertakingsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaProgettiJobsUndertakingsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ProgettiJobsUndertakingsDto, PagedList<ProgettiJobUndertaking>>();
            return dtos;
        }

        public async Task<ProgettiJobUndertakingDto> GetGaProgettiJobUndertakingByIdAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiJobUndertakingDto, ProgettiJobUndertaking>();
            return dto;
        }

        public async Task<ProgettiJobsUndertakingsDto> GetGaProgettiJobsUndertakingsByJobIdAsync(long jobId)
        {
            var entities = await gaProgettiJobsUndertakingsRepo.GetWithFilterAsync(x => x.Disabled == false && x.ProgettiJobId == jobId);
            var dtos = entities.ToDto<ProgettiJobsUndertakingsDto, PagedList<ProgettiJobUndertaking>>();
            return dtos;

        }

        public async Task<long> AddGaProgettiJobUndertakingAsync(ProgettiJobUndertakingDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobUndertaking, ProgettiJobUndertakingDto>();
            await gaProgettiJobsUndertakingsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiJobUndertakingAsync(ProgettiJobUndertakingDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobUndertaking, ProgettiJobUndertakingDto>();
            gaProgettiJobsUndertakingsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiJobUndertakingAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsRepo.GetByIdAsync(id);
            gaProgettiJobsUndertakingsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaProgettiJobUndertakingAsync(long id, string descrizione, long jobId)
        {
            var entity = await gaProgettiJobsUndertakingsRepo.GetWithFilterAsync(x => x.Title == descrizione && x.ProgettiJobId == jobId  && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaProgettiJobUndertakingAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaProgettiJobsUndertakingsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaProgettiJobsUndertakingsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        #endregion


        #endregion

        #region ProgettiJobsUndertakingsAllegati
        public async Task<ProgettiJobsUndertakingsAllegatiDto> GetGaProgettiJobsUndertakingsAllegatiByUndertakingIdAsync(long undertakingId)
        {
            var entities = await gaProgettiJobsUndertakingsAllegatiRepo.GetWithFilterAsync(x => x.ProgettiJobUndertakingId == undertakingId);
            var dtos = entities.ToDto<ProgettiJobsUndertakingsAllegatiDto, PagedList<ProgettiJobUndertakingAllegato>>();
            return dtos;
        }

        public async Task<ProgettiJobUndertakingAllegatoDto> GetGaProgettiJobUndertakingAllegatoByIdAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiJobUndertakingAllegatoDto, ProgettiJobUndertakingAllegato>();
            return dto;
        }

        public async Task<long> AddGaProgettiJobUndertakingAllegatoAsync(ProgettiJobUndertakingAllegatoDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobUndertakingAllegato, ProgettiJobUndertakingAllegatoDto>();
            await gaProgettiJobsUndertakingsAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiJobUndertakingAllegatoAsync(ProgettiJobUndertakingAllegatoDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobUndertakingAllegato, ProgettiJobUndertakingAllegatoDto>();
            gaProgettiJobsUndertakingsAllegatiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiJobUndertakingAllegatoAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsAllegatiRepo.GetByIdAsync(id);
            gaProgettiJobsUndertakingsAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #endregion

        #region ProgettiJobsUndertakingsStates
        public async Task<ProgettiJobsUndertakingsStatesDto> GetGaProgettiJobsUndertakingsStatesAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaProgettiJobsUndertakingsStatesRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ProgettiJobsUndertakingsStatesDto, PagedList<ProgettiJobUndertakingState>>();
            return dtos;
        }

        public async Task<ProgettiJobUndertakingStateDto> GetGaProgettiJobUndertakingStateByIdAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsStatesRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ProgettiJobUndertakingStateDto, ProgettiJobUndertakingState>();
            return dto;
        }

        public async Task<long> AddGaProgettiJobUndertakingStateAsync(ProgettiJobUndertakingStateDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobUndertakingState, ProgettiJobUndertakingStateDto>();
            await gaProgettiJobsUndertakingsStatesRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaProgettiJobUndertakingStateAsync(ProgettiJobUndertakingStateDto dto)
        {
            var entity = dto.ToEntity<ProgettiJobUndertakingState, ProgettiJobUndertakingStateDto>();
            gaProgettiJobsUndertakingsStatesRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaProgettiJobUndertakingStateAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsStatesRepo.GetByIdAsync(id);
            gaProgettiJobsUndertakingsStatesRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaProgettiJobUndertakingStateAsync(long id, string descrizione)
        {
            var entity = await gaProgettiJobsUndertakingsStatesRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaProgettiJobUndertakingStateAsync(long id)
        {
            var entity = await gaProgettiJobsUndertakingsStatesRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaProgettiJobsUndertakingsStatesRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaProgettiJobsUndertakingsStatesRepo.Update(entity);
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


