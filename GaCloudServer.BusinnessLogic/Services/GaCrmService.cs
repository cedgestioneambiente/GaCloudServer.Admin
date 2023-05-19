using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaCrmService : IGaCrmService
    {
        protected readonly IQueryManager _queryManager;

        protected readonly IGenericRepository<CrmEventState> gaCrmEventStatesRepo;
        protected readonly IGenericRepository<CrmEventArea> gaCrmEventAreasRepo;
        protected readonly IGenericRepository<CrmEvent> gaCrmEventsRepo;
        protected readonly IGenericRepository<CrmEventDevice> gaCrmEventDevicesRepo;

        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo;

        protected readonly IGenericRepository<ViewGaCrmTickets> viewGaCrmMasterRepo;
        protected readonly IGenericRepository<ViewGaCrmEventJobs> viewGaCrmEventJobsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaCrmService(
            IQueryManager queryManager,

            IGenericRepository<CrmEventState> gaCrmEventStatesRepo,
            IGenericRepository<CrmEventArea> gaCrmEventAreasRepo,
            IGenericRepository<CrmEvent> gaCrmEventsRepo,
            IGenericRepository<CrmEventDevice> gaCrmEventDevicesRepo,

            IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo,
            IGenericRepository<ViewGaCrmEventJobs> viewGaCrmEventJobsRepo,

            IGenericRepository<ViewGaCrmTickets> viewGaCrmMasterRepo,

            IUnitOfWork unitOfWork)
        {
            this._queryManager = queryManager;

            this.gaCrmEventAreasRepo = gaCrmEventAreasRepo;
            this.gaCrmEventStatesRepo = gaCrmEventStatesRepo;
            this.gaCrmEventsRepo = gaCrmEventsRepo;
            this.gaCrmEventDevicesRepo = gaCrmEventDevicesRepo;

            this.viewGaBackOfficeUtenzeDispositiviRepo = viewGaBackOfficeUtenzeDispositiviRepo;

            this.viewGaCrmEventJobsRepo = viewGaCrmEventJobsRepo;
            this.viewGaCrmMasterRepo = viewGaCrmMasterRepo;


            this.unitOfWork = unitOfWork;

        }

        #region CrmMaster

        public async Task<int> UpdateCrmMasterStateByIdAsync(int id, long state)
        {
            var sql = SqlContants.crmMasterUpdateState;
            string newState = "1";
            switch (state)
            {
                case 1:
                    newState= "1"; break;
                case 2:
                    newState= "110"; break;
                case 3:
                    newState= "1000"; break;
                case 4:
                    newState = "1";break;
                default:
                    newState = "1";break;
            }

            sql = sql.Replace("@ID", id.ToString()).Replace("@STATO", newState);

            var result = await _queryManager.ExecCommandAsync(sql);
            return result;
        }

        #region Views
        public async Task<PagedList<ViewGaCrmTickets>> GetViewGaCrmMasterAsync()
        {
            var entities = await viewGaCrmMasterRepo.GetWithFilterAsync(x => (x.CodCausale == 84 || x.CodCausale==88) && (x.Stato==1 || x.Stato==109));
            return entities;
        }
        #endregion

        #endregion

        #region CrmEventStates
        public async Task<CrmEventStatesDto> GetGaCrmEventStatesAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmEventStatesRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CrmEventStatesDto, PagedList<CrmEventState>>();
            return dtos;
        }

        public async Task<CrmEventStateDto> GetGaCrmEventStateByIdAsync(long id)
        {
            var entity = await gaCrmEventStatesRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CrmEventStateDto, CrmEventState>();
            return dto;
        }

        public async Task<long> AddGaCrmEventStateAsync(CrmEventStateDto dto)
        {
            var entity = dto.ToEntity<CrmEventState, CrmEventStateDto>();
            await gaCrmEventStatesRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCrmEventStateAsync(CrmEventStateDto dto)
        {
            var entity = dto.ToEntity<CrmEventState, CrmEventStateDto>();
            gaCrmEventStatesRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCrmEventStateAsync(long id)
        {
            var entity = await gaCrmEventStatesRepo.GetByIdAsync(id);
            gaCrmEventStatesRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCremEventStateAsync(long id, string descrizione)
        {
            var entity = await gaCrmEventStatesRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCrmEventStateAsync(long id)
        {
            var entity = await gaCrmEventStatesRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCrmEventStatesRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCrmEventStatesRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CrmEventAreas
        public async Task<CrmEventAreasDto> GetGaCrmEventAreasAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmEventAreasRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CrmEventAreasDto, PagedList<CrmEventArea>>();
            return dtos;
        }

        public async Task<CrmEventAreaDto> GetGaCrmEventAreaByIdAsync(long id)
        {
            var entity = await gaCrmEventAreasRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CrmEventAreaDto, CrmEventArea>();
            return dto;
        }

        public async Task<long> AddGaCrmEventAreaAsync(CrmEventAreaDto dto)
        {
            var entity = dto.ToEntity<CrmEventArea, CrmEventAreaDto>();
            await gaCrmEventAreasRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCrmEventAreaAsync(CrmEventAreaDto dto)
        {
            var entity = dto.ToEntity<CrmEventArea, CrmEventAreaDto>();
            gaCrmEventAreasRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCrmEventAreaAsync(long id)
        {
            var entity = await gaCrmEventAreasRepo.GetByIdAsync(id);
            gaCrmEventAreasRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCremEventAreaAsync(long id, string descrizione)
        {
            var entity = await gaCrmEventAreasRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCrmEventAreaAsync(long id)
        {
            var entity = await gaCrmEventAreasRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCrmEventAreasRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCrmEventAreasRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CrmEvents
        public async Task<CrmEventsDto> GetGaCrmEventsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmEventsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CrmEventsDto, PagedList<CrmEvent>>();
            return dtos;
        }
        public async Task<CrmEventsDto> GetGaCrmEventByBoardAsync(DateTime date,long area)
        {
            var entities = await gaCrmEventsRepo.GetWithFilterAsync(x => x.DateSchedule.Date==date.Date && x.CrmEventAreaId==area);
            var dtos = entities.ToDto<CrmEventsDto, PagedList<CrmEvent>>();
            return dtos;
        }

        public async Task<CrmEventDto> GetGaCrmEventByIdAsync(long id)
        {
            var entity = await gaCrmEventsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CrmEventDto, CrmEvent>();
            return dto;
        }

        public async Task<CrmEventDto> GetGaCrmEventByTicketIdAsync(long id)
        {
            var entity = gaCrmEventsRepo.GetWithFilterAsync(x=>x.CrmTicketId==id).Result.Data.FirstOrDefault();
            var dto = entity.ToDto<CrmEventDto, CrmEvent>();
            return dto;
        }



        public async Task<long> AddGaCrmEventAsync(CrmEventDto dto)
        {
            var entity = dto.ToEntity<CrmEvent, CrmEventDto>();
            await gaCrmEventsRepo.AddAsync(entity);
            await SaveChanges();

            var devices = await viewGaBackOfficeUtenzeDispositiviRepo.GetWithFilterAsync(x => x.NumCon == dto.NumCon && x.CpAzi == dto.CodAzi && x.CpRowNum == Convert.ToInt32(dto.CpRowNum) && x.DtRit == "31/12/2029");

            foreach (var item in devices.Data)
            {
                var device = new CrmEventDevice();
                device.CrmEventId = entity.Id;
                device.CrmTicketId = dto.CrmTicketId;
                device.Identi1 = item.Identi1;
                device.Identi2= item.Identi2;
                device.TipCon = item.TipCon;
                device.DesCon = item.DesCon;
                device.DtCon = item.DtCon;
                device.DtRit = item.DtRit;
                device.Selected = true;
                device.Completed = false;
                device.Disabled = false;

                await gaCrmEventDevicesRepo.AddAsync(device);
                await SaveChanges();
            }


            return entity.Id;
        }

        public async Task<long> UpdateGaCrmEventAsync(CrmEventDto dto)
        {
            var entity = dto.ToEntity<CrmEvent, CrmEventDto>();
            gaCrmEventsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCrmEventAsync(long id)
        {
            var entity = await gaCrmEventsRepo.GetByIdAsync(id);
            gaCrmEventsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> UpdateGaCrmEventStateByIdAsync(long id, long state)
        {
            var entity = await gaCrmEventsRepo.GetByIdAsync(id);

            entity.CrmEventStateId = state;
            gaCrmEventsRepo.Update(entity);
            await SaveChanges();
            return true;
            
        }

        public async Task<bool> UpdateGaCrmEventsSendedAsync(List<CrmEventDto> dtos)
        {
            foreach (var item in dtos)
            {
                var entity = await gaCrmEventsRepo.GetByIdAsync(item.Id);

                entity.Sended = true;
                gaCrmEventsRepo.Update(entity);
            }

            await SaveChanges();
            return true;
        }
        public async Task<bool> ValidateGaCremEventAsync(long id, string descrizione)
        {
            //var entity = await gaCrmEventsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            //if (entity.Data.Count > 0)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            return true;
        }

        public async Task<bool> ChangeStatusGaCrmEventAsync(long id)
        {
            var entity = await gaCrmEventsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCrmEventsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCrmEventsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CrmEventDevices
        public async Task<CrmEventDevicesDto> GetGaCrmEventDevicesByEventIdAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetWithFilterAsync(x => x.CrmEventId == id);
            var dto = entity.ToDto<CrmEventDevicesDto, PagedList<CrmEventDevice>>();
            return dto;
        }

        public async Task<bool> DeleteGaCrmEventDeviceAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetByIdAsync(id);
            gaCrmEventDevicesRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        public async Task<bool> DeleteGaCrmEventDevicesByEventIdAsync(long id)
        {
            var entities = await gaCrmEventDevicesRepo.GetWithFilterAsync(x => x.CrmEventId == id);
            foreach (var entity in entities.Data)
            {
                gaCrmEventDevicesRepo.Remove(entity);
                await SaveChanges();
            }
            

            return true;
        }

        #region Functions
        public async Task<bool> ChangeStatusGaCrmEventDeviceAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetByIdAsync(id);
            if (entity.Completed)
            {
                entity.Completed = false;
                gaCrmEventDevicesRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Completed = true;
                gaCrmEventDevicesRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        public async Task<bool> ChangeSelectionGaCrmEventDeviceAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetByIdAsync(id);
            if (entity.Selected)
            {
                entity.Selected = false;
                gaCrmEventDevicesRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Selected = true;
                gaCrmEventDevicesRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<bool> SetCompletedGaCrmEventDeviceAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetByIdAsync(id);
            entity.Completed = true;
            gaCrmEventDevicesRepo.Update(entity);
            await SaveChanges();
            return true;
            

        }

        public async Task<bool> SetNotCompletedGaCrmEventDeviceAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetByIdAsync(id);
            entity.Completed = false;
            gaCrmEventDevicesRepo.Update(entity);
            await SaveChanges();
            return true;


        }
        #endregion
        #endregion

        #region CrmEventJobs
        public async Task<PagedList<ViewGaCrmEventJobs>> GetViewGaCrmEventJobsAsync(int page = 1, int pageSize = 0)
        {
            var view = await viewGaCrmEventJobsRepo.GetAllAsync(page, pageSize);
            return view;
        }

        public async Task<PagedList<ViewGaCrmEventJobs>> GetViewGaCrmEventJobsByFilterAsync(DateTime dateStart,DateTime dateEnd)
        {
            var view = await viewGaCrmEventJobsRepo.GetWithFilterAsync(x => x.DateSchedule >= dateStart && x.DateSchedule <= dateEnd);
            return view;
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
