using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.Graph;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaCrmService : IGaCrmService
    {
        protected readonly IQueryManager _queryManager;

        protected readonly IGenericRepository<CrmEventState> gaCrmEventStatesRepo;
        protected readonly IGenericRepository<CrmEventArea> gaCrmEventAreasRepo;
        protected readonly IGenericRepository<CrmEventComune> gaCrmEventComuniRepo;
        protected readonly IGenericRepository<CrmEvent> gaCrmEventsRepo;
        protected readonly IGenericRepository<CrmEventDevice> gaCrmEventDevicesRepo;
        protected readonly IGenericRepository<CrmTicket> gaCrmTicketsRepo;

        private readonly IGenericRepository<ContactCenterProvenienza> gaCrmProvenienzeTicketRepo;
        private readonly IGenericRepository<ContactCenterTipoRichiesta> gaCrmTipiTicketRepo;
        private readonly IGenericRepository<ContactCenterStatoRichiesta> gaCrmStatiTicketRepo;
        private readonly IGenericRepository<ContactCenterPrintTemplate> gaCrmPrintTemplatesRepo;


        private readonly IGenericRepository<ViewGaBackOfficeTipCon> gaCrmTipConRepo;

        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo;

        protected readonly IGenericRepository<ViewGaCrmTickets> viewGaCrmMasterRepo;
        protected readonly IGenericRepository<ViewGaCrmEventJobs> viewGaCrmEventJobsRepo;
        protected readonly IGenericRepository<ViewGaCrmTickets> viewGaCrmTicketsRepo;
        protected readonly IGenericRepository<ViewGaCrmCalendarTickets> viewGaCrmCalendarTicketsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaCrmService(
            IQueryManager queryManager,

            IGenericRepository<CrmEventState> gaCrmEventStatesRepo,
            IGenericRepository<CrmEventArea> gaCrmEventAreasRepo,
            IGenericRepository<CrmEventComune> gaCrmEventComuniRepo,
            IGenericRepository<CrmEvent> gaCrmEventsRepo,
            IGenericRepository<CrmEventDevice> gaCrmEventDevicesRepo,
            IGenericRepository<CrmTicket> gaCrmTicketsRepo,

            IGenericRepository<ContactCenterProvenienza> gaCrmProvenienzeTicketRepo,
            IGenericRepository<ContactCenterTipoRichiesta> gaCrmTipiTicketRepo,
            IGenericRepository<ContactCenterStatoRichiesta> gaCrmStatiTicketRepo,
            IGenericRepository<ContactCenterPrintTemplate> gaCrmPrintTemplatesRepo,

            IGenericRepository<ViewGaBackOfficeTipCon> gaCrmTipConRepo,

            IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewGaBackOfficeUtenzeDispositiviRepo,
            IGenericRepository<ViewGaCrmEventJobs> viewGaCrmEventJobsRepo,
            IGenericRepository<ViewGaCrmTickets> viewGaCrmTicketsRepo,
            IGenericRepository<ViewGaCrmCalendarTickets> viewGaCrmCalendarTicketsRepo,

            IGenericRepository<ViewGaCrmTickets> viewGaCrmMasterRepo,

            IUnitOfWork unitOfWork)
        {
            this._queryManager = queryManager;

            this.gaCrmEventAreasRepo = gaCrmEventAreasRepo;
            this.gaCrmEventComuniRepo = gaCrmEventComuniRepo;
            this.gaCrmEventStatesRepo = gaCrmEventStatesRepo;
            this.gaCrmEventsRepo = gaCrmEventsRepo;
            this.gaCrmEventDevicesRepo = gaCrmEventDevicesRepo;
            this.gaCrmTicketsRepo = gaCrmTicketsRepo;

            this.gaCrmProvenienzeTicketRepo = gaCrmProvenienzeTicketRepo;
            this.gaCrmTipiTicketRepo = gaCrmTipiTicketRepo;
            this.gaCrmStatiTicketRepo= gaCrmStatiTicketRepo;
            this.gaCrmPrintTemplatesRepo = gaCrmPrintTemplatesRepo;

            this.gaCrmTipConRepo= gaCrmTipConRepo;

            this.viewGaBackOfficeUtenzeDispositiviRepo = viewGaBackOfficeUtenzeDispositiviRepo;

            this.viewGaCrmEventJobsRepo = viewGaCrmEventJobsRepo;
            this.viewGaCrmMasterRepo = viewGaCrmMasterRepo;
            this.viewGaCrmTicketsRepo = viewGaCrmTicketsRepo;
            this.viewGaCrmCalendarTicketsRepo = viewGaCrmCalendarTicketsRepo;


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

        public async Task<long> UpdateCrmTicketStateByIdAsync(int id, long state)
        {
            long newState = 1;
            switch (state)
            {
                case 1:
                    newState = 1; break;
                case 2:
                    newState =2; break;
                case 3:
                    newState = 1; break;
                case 4:
                    newState = 3; break;
                default:
                    newState = 1; break;
            }

            var entity = await gaCrmTicketsRepo.GetByIdAsync(id);
            entity.ContactCenterStatoRichiestaId= newState;

            gaCrmTicketsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

            
        }

        #region Views
        public async Task<PagedList<ViewGaCrmTickets>> GetViewGaCrmMasterAsync()
        {
            var entities = await viewGaCrmMasterRepo.GetWithFilterAsync(x => (x.MagazzinoCalendar == true) && (x.StatoId==1));
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

        #region CrmEventComuni
        public async Task<CrmEventComuniDto> GetGaCrmEventComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmEventComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CrmEventComuniDto, PagedList<CrmEventComune>>();
            return dtos;
        }

        public async Task<CrmEventComuneDto> GetGaCrmEventComuneByIdAsync(long id)
        {
            var entity = await gaCrmEventComuniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CrmEventComuneDto, CrmEventComune>();
            return dto;
        }

        public async Task<long> AddGaCrmEventComuneAsync(CrmEventComuneDto dto)
        {
            var entity = dto.ToEntity<CrmEventComune, CrmEventComuneDto>();
            await gaCrmEventComuniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCrmEventComuneAsync(CrmEventComuneDto dto)
        {
            var entity = dto.ToEntity<CrmEventComune, CrmEventComuneDto>();
            gaCrmEventComuniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCrmEventComuneAsync(long id)
        {
            var entity = await gaCrmEventComuniRepo.GetByIdAsync(id);
            gaCrmEventComuniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCremEventComuneAsync(long id, string descrizione)
        {
            var entity = await gaCrmEventComuniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCrmEventComuneAsync(long id)
        {
            var entity = await gaCrmEventComuniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCrmEventComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCrmEventComuniRepo.Update(entity);
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
        public async Task<CrmEventsDto> GetGaCrmEventByBoardAsync(DateTime date,long area, bool all)
        {
            var entities = all? await gaCrmEventsRepo.GetWithFilterAsync(x => x.DateSchedule.Date==date.Date && x.CrmEventAreaId==area):
                await gaCrmEventsRepo.GetWithFilterAsync(x => x.DateSchedule.Date == date.Date && x.CrmEventAreaId == area && x.Sended==false);
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

        public async Task<CrmEventDeviceDto> GetGaCrmEventDeviceByIdAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CrmEventDeviceDto, CrmEventDevice>();
            return dto;
        }

        public async Task<long> AddGaCrmEventDeviceAsync(CrmEventDeviceDto dto)
        {
            var entity = dto.ToEntity<CrmEventDevice, CrmEventDeviceDto>();
            await gaCrmEventDevicesRepo.AddAsync(entity);
            await SaveChanges();

            return entity.Id;
        }

        public async Task<long> UpdateGaCrmEventDeviceAsync(CrmEventDeviceDto dto)
        {
            var entity = dto.ToEntity<CrmEventDevice, CrmEventDeviceDto>();
            gaCrmEventDevicesRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

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

        public async Task<bool> ChangeSostLuchGaCrmEventDeviceAsync(long id)
        {
            var entity = await gaCrmEventDevicesRepo.GetByIdAsync(id);
            if (entity.SostLuch)
            {
                entity.SostLuch = false;
                gaCrmEventDevicesRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.SostLuch = true;
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

        #region CrmTickets
        public async Task<CrmTicketsDto> GetGaCrmTicketsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmTicketsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CrmTicketsDto, PagedList<CrmTicket>>();
            return dtos;
        }

        public async Task<CrmTicketDto> GetGaCrmTicketByIdAsync(long id)
        {
            var entity = await gaCrmTicketsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CrmTicketDto, CrmTicket>();
            return dto;
        }

        public async Task<long> AddGaCrmTicketAsync(CrmTicketDto dto)
        {
            var entity = dto.ToEntity<CrmTicket, CrmTicketDto>();
            await gaCrmTicketsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCrmTicketAsync(CrmTicketDto dto)
        {
            var entity = dto.ToEntity<CrmTicket, CrmTicketDto>();
            gaCrmTicketsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCrmTicketAsync(long id)
        {
            var entity = await gaCrmTicketsRepo.GetByIdAsync(id);
            gaCrmTicketsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ChangeStatusGaCrmTicketAsync(long id)
        {
            var entity = await gaCrmTicketsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCrmTicketsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCrmTicketsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetGaCrmTicketDevicesByUserAsync(string cpAzi, string numCon, string cpRowNum)
        {
            var view = await viewGaBackOfficeUtenzeDispositiviRepo.GetWithFilterAsync(x => x.NumCon == numCon && x.CpAzi == cpAzi && x.CpRowNum == Convert.ToInt32(cpRowNum) && x.DtRit == "31/12/2029");
            return view;
        }

        public async Task<PagedList<ViewGaCrmTickets>> GetGaCrmTicketsByUserAsync(long comuneId, string numCon, string prg)
        {
            var view = await viewGaCrmTicketsRepo.GetWithFilterAsync(x => x.NumCon == numCon && x.ComuneId == comuneId && x.Prg == prg);
            return view;
        }

        public async Task<bool> CheckGaCrmTicketEventExistAsync(long id)
        {
            var entity = await gaCrmEventsRepo.GetWithFilterAsync(x => x.CrmTicketId == id);

            if (entity.Data.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Views
        public PagedList<ViewGaCrmTickets> GetViewGaCrmTicketsByAssigneeQueryable(GridOperationsModel filterParams, string[]? assignee)
        {

            if (!string.IsNullOrWhiteSpace(filterParams.quickFilter))
            {
                if (assignee == null || assignee.Count() == 0)
                {
                    var filterResult = viewGaCrmTicketsRepo.GetAllQueryableV2WithQuickFilter(filterParams, filterParams.quickFilter);
                    return filterResult;
                }
                else
                {
                    var filterResult = viewGaCrmTicketsRepo.GetWithFilterQueryableV2WithQuickFilter(x => assignee.Contains(x.Assignee), filterParams, filterParams.quickFilter);
                    return filterResult;
                }
            }
            else
            {
                if (assignee == null || assignee.Count() == 0)
                {
                    var filterResult = viewGaCrmTicketsRepo.GetAllQueryableV2(filterParams);
                    return filterResult;
                }
                else
                {
                    var filterResult = viewGaCrmTicketsRepo.GetWithFilterQueryableV2(x => assignee.Contains(x.Assignee), filterParams);
                    return filterResult;
                }
            }

        }

        public async Task<ViewGaCrmTickets> GetViewGaCrmTicketByIdAsync(long id)
        {
            var view = await viewGaCrmTicketsRepo.GetByIdAsync(id);
            return view;

        }

        public async Task<PagedList<ViewGaCrmCalendarTickets>> GetViewGaCrmCalendarTicketAsync()
        {
            var view = await viewGaCrmCalendarTicketsRepo.GetWithFilterAsync(x => x.MagazzinoCalendar == true && x.StatoId==1);
            return view;
        }

        #endregion

        #endregion

        #region Shared Data Tables
        public async Task<ContactCenterProvenienzeDto> GetGaCrmProvenienzeTicketAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmProvenienzeTicketRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterProvenienzeDto, PagedList<ContactCenterProvenienza>>();
            return dtos;
        }

        public async Task<ContactCenterTipiRichiesteDto> GetGaCrmTipiTicketAsync(bool all)
        {
            var entities = all? await gaCrmTipiTicketRepo.GetAllAsync():
            await gaCrmTipiTicketRepo.GetWithFilterAsync(x => x.Magazzino == true || x.Fatturazione == true);
            var dtos = entities.ToDto<ContactCenterTipiRichiesteDto, PagedList<ContactCenterTipoRichiesta>>();
            return dtos;
        }

        public async Task<ContactCenterStatiRichiesteDto> GetGaCrmStatiTicketAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmStatiTicketRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterStatiRichiesteDto, PagedList<ContactCenterStatoRichiesta>>();
            return dtos;
        }
        public async Task<ContactCenterPrintTemplatesDto> GetGaCrmPrintTemplatesAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCrmPrintTemplatesRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterPrintTemplatesDto, PagedList<ContactCenterPrintTemplate>>();
            return dtos;
        }
        public async Task<PagedList<ViewGaBackOfficeTipCon>> GetViewGaCrmTipConAsync(int page = 1, int pageSize = 0)
        {
            var view = await gaCrmTipConRepo.GetAllAsync(page, pageSize);
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
