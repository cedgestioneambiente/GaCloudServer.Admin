using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using Microsoft.Graph;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaCrmService
    {
        #region CrmMaster

        Task<int> UpdateCrmMasterStateByIdAsync(int id, long state);
        Task<long> UpdateCrmTicketStateByIdAsync(int id, long state, string note=null);

        #region Views
        Task<PagedList<ViewGaCrmTickets>> GetViewGaCrmMasterAsync();
        #endregion

        #endregion

        #region CrmEventStates
        Task<CrmEventStatesDto> GetGaCrmEventStatesAsync(int page = 1, int pageSize = 0);
        Task<CrmEventStateDto> GetGaCrmEventStateByIdAsync(long id);

        Task<long> AddGaCrmEventStateAsync(CrmEventStateDto dto);
        Task<long> UpdateGaCrmEventStateAsync(CrmEventStateDto dto);

        Task<bool> DeleteGaCrmEventStateAsync(long id);

        #region Views
        #endregion

        #endregion

        #region CrmEventAreas
        Task<CrmEventAreasDto> GetGaCrmEventAreasAsync(int page = 1, int pageSize = 0);
        Task<CrmEventAreaDto> GetGaCrmEventAreaByIdAsync(long id);

        Task<long> AddGaCrmEventAreaAsync(CrmEventAreaDto dto);
        Task<long> UpdateGaCrmEventAreaAsync(CrmEventAreaDto dto);

        Task<bool> DeleteGaCrmEventAreaAsync(long id);

        #region Views
        #endregion

        #endregion

        #region CrmEventComuni
        Task<CrmEventComuniDto> GetGaCrmEventComuniAsync(int page = 1, int pageSize = 0);
        Task<CrmEventComuneDto> GetGaCrmEventComuneByIdAsync(long id);

        Task<long> AddGaCrmEventComuneAsync(CrmEventComuneDto dto);
        Task<long> UpdateGaCrmEventComuneAsync(CrmEventComuneDto dto);

        Task<bool> DeleteGaCrmEventComuneAsync(long id);

        #region Views
        #endregion

        #endregion

        #region CrmEvents
        Task<CrmEventsDto> GetGaCrmEventsAsync(int page = 1, int pageSize = 0);
        Task<CrmEventsDto> GetGaCrmEventByBoardAsync(DateTime date, long area,bool all);
        Task<CrmEventDto> GetGaCrmEventByIdAsync(long id);
        Task<CrmEventDto> GetGaCrmEventByTicketIdAsync(long id);
        Task<long> AddGaCrmEventAsync(CrmEventDto dto);
        Task<long> UpdateGaCrmEventAsync(CrmEventDto dto);

        Task<bool> DeleteGaCrmEventAsync(long id);

        #region Functions
        Task<bool> UpdateGaCrmEventStateByIdAsync(long id,long state);

        Task<bool> UpdateGaCrmEventsSendedAsync(List<CrmEventDto> dtos);
        #endregion

        #region Views
        #endregion

        #endregion

        #region CrmEventDevices
        Task<CrmEventDevicesDto> GetGaCrmEventDevicesByEventIdAsync(long id);
        Task<CrmEventDevicesDto> GetGaCrmEventDevicesByTicketIdAsync(long id);
        Task<CrmEventDeviceDto> GetGaCrmEventDeviceByIdAsync(long id);
        Task<long> AddGaCrmEventDeviceAsync(CrmEventDeviceDto dto);
        Task<long> UpdateGaCrmEventDeviceAsync(CrmEventDeviceDto dto);
        Task<bool> DeleteGaCrmEventDeviceAsync(long id);
        Task<bool> DeleteGaCrmEventDevicesByEventIdAsync(long id);
        #region Functions
        Task<bool> ChangeStatusGaCrmEventDeviceAsync(long id);
        Task<bool> ChangeSelectionGaCrmEventDeviceAsync(long id);
        Task<bool> ChangeSostLuchGaCrmEventDeviceAsync(long id);

        Task<bool> SetCompletedGaCrmEventDeviceAsync(long id);
        Task<bool> SetNotCompletedGaCrmEventDeviceAsync(long id);

        Task<bool> AddGaCrmEventDevice120KitAsync(long eventId, int ticketId);

        Task<bool> AddGaCrmEventDevice30KitAsync(long eventId, int ticketId);

        #endregion
        #endregion

        #region CrmTicket
        Task<CrmTicketsDto> GetGaCrmTicketsAsync(int page = 1, int pageSize = 0);
        Task<CrmTicketDto> GetGaCrmTicketByIdAsync(long id);

        Task<long> AddGaCrmTicketAsync(CrmTicketDto dto);
        Task<long> UpdateGaCrmTicketAsync(CrmTicketDto dto);

        Task<bool> DeleteGaCrmTicketAsync(long id);

        #region Functions
        Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetGaCrmTicketDevicesByUserAsync(string cpAzi, string numCon, string cpRowNum);
        Task<PagedList<ViewGaCrmTickets>> GetGaCrmTicketsByUserAsync(long comuneId, string numCon, string prg);
        Task<bool> CheckGaCrmTicketEventExistAsync(long id);
        Task<long?> GetGaCrmTicketEventIfExistAsync(long id);
        Task<bool> DuplicateGaCrmTicketAsync(long[] ticketsId, string userId);
        Task<PagedList<ViewGaCrmTickets>> ExportGaCrmTicketsAsync(long[] ids);
        #endregion

        #region Views
        PagedList<ViewGaCrmTickets> GetViewGaCrmTicketsByAssigneeQueryable(GridOperationsModel filterParams, string[]? assignee);
        Task<ViewGaCrmTickets> GetViewGaCrmTicketByIdAsync(long id);

        Task<PagedList<ViewGaCrmCalendarTickets>> GetViewGaCrmCalendarTicketAsync();
        #endregion

        #endregion

        #region GaCrmTicketAllegati
        Task<CrmTicketAllegatiDto> GetGaCrmTicketAllegatiByTicketIdAsync(long CrmTicketTicketId);
        Task<CrmTicketAllegatoDto> GetGaCrmTicketAllegatoByIdAsync(long id);

        Task<long> AddGaCrmTicketAllegatoAsync(CrmTicketAllegatoDto dto);
        Task<long> UpdateGaCrmTicketAllegatoAsync(CrmTicketAllegatoDto dto);

        Task<bool> DeleteGaCrmTicketAllegatoAsync(long id);

        #region Functions
        //Task<bool> ValidateGaCrmTicketAllegatoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaCrmTicketAllegatoAsync(long id);
        #endregion

        #endregion

        #region CrmTicketTags
        Task<CrmTicketTagsDto> GetGaCrmTicketTagsAsync(int page = 1, int pageSize = 0);
        Task<CrmTicketTagDto> GetGaCrmTicketTagByIdAsync(long id);

        Task<long> AddGaCrmTicketTagAsync(CrmTicketTagDto dto);
        Task<long> UpdateGaCrmTicketTagAsync(CrmTicketTagDto dto);

        Task<bool> DeleteGaCrmTicketTagAsync(long id);

        #region Views
        #endregion

        #region Functions

        #endregion

        #endregion

        #region CrmEventJobs
        Task<PagedList<ViewGaCrmEventJobs>> GetViewGaCrmEventJobsAsync(int page = 1, int pageSize = 0);
        Task<PagedList<ViewGaCrmEventJobs>> GetViewGaCrmEventJobsByFilterAsync(bool all,DateTime dateStart, DateTime dateEnd);
        #endregion

        #region Garbage
        Task<PagedList<ViewGaCrmGarbageUtenze>> GetViewGaCrmGarbageUtenzeAsync();
        Task<PagedList<ViewGaCrmGarbagePartite>> GetViewGaCrmGarbagePartiteAsync();
        Task<PagedList<ViewGaCrmGarbageTipologie>> GetViewGaCrmGarbageTipologieAsync();
        Task<PagedList<ViewGaCrmGarbageProvenienze>> GetViewGaCrmGarbageProvenienzeAsync();
        Task<PagedList<ViewGaCrmGarbageStati>> GetViewGaCrmGarbageStatiAsync();
        Task<PagedList<ViewGaCrmGarbageTicketContactCenter>> GetViewGaCrmGarbageTicketContactCenterAsync();
        Task<PagedList<ViewGaCrmGarbageTicketMagazzino>> GetViewGaCrmGarbageTicketMagazzinoAsync();
        
        #endregion

        #region Shared Data Table
        Task<ContactCenterProvenienzeDto> GetGaCrmProvenienzeTicketAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterTipiRichiesteDto> GetGaCrmTipiTicketAsync(bool all);
        Task<ContactCenterStatiRichiesteDto> GetGaCrmStatiTicketAsync(int page = 1, int pageSize = 0);
        Task<PagedList<ViewGaBackOfficeTipCon>> GetViewGaCrmTipConAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterPrintTemplatesDto> GetGaCrmPrintTemplatesAsync(int page = 1, int pageSize = 0);
        #endregion
    }
}
