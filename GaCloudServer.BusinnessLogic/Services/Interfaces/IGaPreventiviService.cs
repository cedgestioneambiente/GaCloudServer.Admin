using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPreventiviService
    {
        #region OLD
        #region PreventiviAnticipiTipologie
        Task<PreventiviAnticipiTipologieDto> GetGaPreventiviAnticipiTipologieAsync(int page = 1, int pageSize = 0);
        Task<PreventiviAnticipoTipologiaDto> GetGaPreventiviAnticipoTipologiaByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto);
        Task<long> UpdateGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto);

        Task<bool> DeleteGaPreventiviAnticipoTipologiaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoTipologiaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPreventiviAnticipoTipologiaAsync(long id);
        #endregion

        #endregion

        #region PreventiviAnticipiPagamenti
        Task<PreventiviAnticipiPagamentiDto> GetGaPreventiviAnticipiPagamentiAsync(int page = 1, int pageSize = 0);
        Task<PreventiviAnticipoPagamentoDto> GetGaPreventiviAnticipoPagamentoByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto);
        Task<long> UpdateGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto);

        Task<bool> DeleteGaPreventiviAnticipoPagamentoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoPagamentoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPreventiviAnticipoPagamentoAsync(long id);
        #endregion

        #endregion

        #region PreventiviAnticipi
        Task<PreventiviAnticipiDto> GetGaPreventiviAnticipiAsync(int page = 1, int pageSize = 0);
        Task<PreventiviAnticipoDto> GetGaPreventiviAnticipoByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto);
        Task<long> UpdateGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto);

        Task<bool> DeleteGaPreventiviAnticipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoAsync(long id, string numero);
        Task<bool> ChangeStatusGaPreventiviAnticipoAsync(long id);
        Task<bool> SetGaPreventiviAnticipoPagatoAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPreventiviAnticipi>> GetViewGaPreventiviAnticipiAsync();
        #endregion

        #endregion

        #region PreventiviAnticipiAllegati
        Task<PreventiviAnticipiAllegatiDto> GetGaPreventiviAnticipiAllegatiByAnticipoAsync(long preventiviAnticipoId);
        Task<PreventiviAnticipoAllegatoDto> GetGaPreventiviAnticipoAllegatoByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto);
        Task<long> UpdateGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto);

        Task<bool> DeleteGaPreventiviAnticipoAllegatoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoAllegatoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPreventiviAnticipoAllegatoAsync(long id);
        #endregion

        #endregion

        #endregion

        //Preventivi

        #region TicketCrm
        public Task<PageResponse<ViewGaPreventiviCrmTickets>> GetViewPreventiviCrmTicketsAsync(PageRequest request);
        public Task<PageResponse<CrmEventComuneDto>> GetPreventiviCrmComuniAsync(PageRequest request);
        public Task<PreventiviObjectDto> CreatePreventiviObjectFromCrmTicketAsync(PreventiviObjectAssignementDto model, double saldo);
        #endregion

        #region Objects
        public Task<PageResponse<PreventiviObjectDto>> GetPreventiviObjectsAsync(PageRequest request);
        public Task<PreventiviObjectDto> GetPreventiviObjectByIdAsync(long id);
        public Task<long> CreatePreventiviObjectAsync(PreventiviObjectDto model);
        public Task<long> UpdatePreventiviObjectAsync(long id, PreventiviObjectDto model);
        public Task<bool> DeletePreventiviObjectAsync(long id);

        #region Functions
        public Task<bool> UpdatePreventiviObjectAssigneeAsync(long id, PreventiviObjectDto model);
        public Task<bool> UpdatePreventiviObjectContactDetailsAsync(long id, PreventiviObjectDto model);
        public Task<bool> UpdatePreventiviObjectOperativeDetailsAsync(long id, PreventiviObjectDto model);
        public Task<bool> UpdatePreventiviObjectTypeDetailsAsync(long id, PreventiviObjectDto model);
        #endregion
        #endregion

        #region ObjectAttachments
        public Task<PageResponse<PreventiviObjectAttachmentDto>> GetPreventiviObjectAttachmentsAsync(PageRequest request);
        public Task<PreventiviObjectAttachmentDto> GetPreventiviObjectAttachmentByIdAsync(long id);
        public Task<long> CreatePreventiviObjectAttachmentAsync(PreventiviObjectAttachmentDto model);
        public Task<long> UpdatePreventiviObjectAttachmentAsync(long id, PreventiviObjectAttachmentDto model);
        public Task<bool> DeletePreventiviObjectAttachmentAsync(long id);
        #endregion

        #region ObjectInspectionAttachments
        public Task<PageResponse<PreventiviObjectInspectionAttachmentDto>> GetPreventiviObjectInspectionAttachmentsAsync(PageRequest request);
        public Task<PreventiviObjectInspectionAttachmentDto> GetPreventiviObjectInspectionAttachmentByIdAsync(long id);
        public Task<long> CreatePreventiviObjectInspectionAttachmentAsync(PreventiviObjectInspectionAttachmentDto model);
        public Task<long> UpdatePreventiviObjectInspectionAttachmentAsync(long id, PreventiviObjectInspectionAttachmentDto model);
        public Task<bool> DeletePreventiviObjectInspectionAttachmentAsync(long id);
        #endregion

        #region ObjectInspectionImages
        public Task<PageResponse<PreventiviObjectInspectionImageDto>> GetPreventiviObjectInspectionImagesAsync(PageRequest request);
        public Task<PreventiviObjectInspectionImageDto> GetPreventiviObjectInspectionImageByIdAsync(long id);
        public Task<long> CreatePreventiviObjectInspectionImageAsync(PreventiviObjectInspectionImageDto model);
        public Task<long> UpdatePreventiviObjectInspectionImageAsync(long id, PreventiviObjectInspectionImageDto model);
        public Task<bool> DeletePreventiviObjectInspectionImageAsync(long id);
        #endregion

        #region ObjectStatuses
        public Task<PageResponse<PreventiviObjectStatusDto>> GetPreventiviObjectStatusesAsync(PageRequest request);
        public Task<PreventiviObjectStatusDto> GetPreventiviObjectStatusByIdAsync(long id);
        public Task<long> CreatePreventiviObjectStatusAsync(PreventiviObjectStatusDto model);
        public Task<long> UpdatePreventiviObjectStatusAsync(long id, PreventiviObjectStatusDto model);
        public Task<bool> DeletePreventiviObjectStatusAsync(long id);
        #endregion

        #region ObjectTypes
        public Task<PageResponse<PreventiviObjectTypeDto>> GetPreventiviObjectTypesAsync(PageRequest request);
        public Task<PreventiviObjectTypeDto> GetPreventiviObjectTypeByIdAsync(long id);
        public Task<long> CreatePreventiviObjectTypeAsync(PreventiviObjectTypeDto model);
        public Task<long> UpdatePreventiviObjectTypeAsync(long id, PreventiviObjectTypeDto model);
        public Task<bool> DeletePreventiviObjectTypeAsync(long id);
        #endregion

        #region ObjectInspectionModes
        public Task<PageResponse<PreventiviObjectInspectionModeDto>> GetPreventiviObjectInspectionModesAsync(PageRequest request);
        public Task<PreventiviObjectInspectionModeDto> GetPreventiviObjectInspectionModeByIdAsync(long id);
        public Task<long> CreatePreventiviObjectInspectionModeAsync(PreventiviObjectInspectionModeDto model);
        public Task<long> UpdatePreventiviObjectInspectionModeAsync(long id, PreventiviObjectInspectionModeDto model);
        public Task<bool> DeletePreventiviObjectInspectionModeAsync(long id);
        #endregion

        #region ObjectInspections
        public Task<PageResponse<PreventiviObjectInspectionDto>> GetPreventiviObjectInspectionsAsync(PageRequest request);
        public Task<PreventiviObjectInspectionDto> GetPreventiviObjectInspectionByIdAsync(long id);
        public Task<long> CreatePreventiviObjectInspectionAsync(PreventiviObjectInspectionDto model);
        public Task<long> UpdatePreventiviObjectInspectionAsync(long id, PreventiviObjectInspectionDto model);
        public Task<bool> DeletePreventiviObjectInspectionAsync(long id);
        #endregion

        #region Actions
        public Task<PageResponse<PreventiviActionDto>> GetPreventiviActionsAsync(PageRequest request);
        public Task<PreventiviActionDto> GetPreventiviActionByIdAsync(long id);
        public Task<long> CreatePreventiviActionAsync(PreventiviActionDto model);
        public Task<long> UpdatePreventiviActionAsync(long id, PreventiviActionDto model);
        public Task<bool> DeletePreventiviActionAsync(long id);
        #endregion

        #region ObjectSections
        public Task<PageResponse<PreventiviObjectSectionDto>> GetPreventiviObjectSectionsAsync(PageRequest request);
        public Task<PreventiviObjectSectionDto> GetPreventiviObjectSectionByIdAsync(long id);
        public Task<long> CreatePreventiviObjectSectionAsync(PreventiviObjectSectionDto model);
        public Task<long> UpdatePreventiviObjectSectionAsync(long id, PreventiviObjectSectionDto model);
        public Task<bool> DeletePreventiviObjectSectionAsync(long id);

        #region Functions
        public Task<bool> ChangeOrderPreventiviObjectSectionAsync(List<PreventiviObjectSectionDto> model);
        #endregion
        #endregion

        #region ObjectServiceTypes
        public Task<PageResponse<PreventiviObjectServiceTypeDto>> GetPreventiviObjectServiceTypesAsync(PageRequest request);
        public Task<PreventiviObjectServiceTypeDto> GetPreventiviObjectServiceTypeByIdAsync(long id);
        public Task<long> CreatePreventiviObjectServiceTypeAsync(PreventiviObjectServiceTypeDto model);
        public Task<long> UpdatePreventiviObjectServiceTypeAsync(long id, PreventiviObjectServiceTypeDto model);
        public Task<bool> DeletePreventiviObjectServiceTypeAsync(long id);
        #endregion

        #region ObjectServiceTypeDetails
        public Task<PageResponse<PreventiviObjectServiceTypeDetailDto>> GetPreventiviObjectServiceTypeDetailsAsync(PageRequest request);
        public Task<PreventiviObjectServiceTypeDetailDto> GetPreventiviObjectServiceTypeDetailByIdAsync(long id);
        public Task<long> CreatePreventiviObjectServiceTypeDetailAsync(PreventiviObjectServiceTypeDetailDto model);
        public Task<long> UpdatePreventiviObjectServiceTypeDetailAsync(long id, PreventiviObjectServiceTypeDetailDto model);
        public Task<bool> DeletePreventiviObjectServiceTypeDetailAsync(long id);
        #endregion

        #region ObjectServices
        public Task<PageResponse<PreventiviObjectServiceDto>> GetPreventiviObjectServicesAsync(PageRequest request);
        public Task<PreventiviObjectServiceDto> GetPreventiviObjectServiceByIdAsync(long id);
        public Task<long> CreatePreventiviObjectServiceAsync(PreventiviObjectServiceDto model);
        public Task<long> UpdatePreventiviObjectServiceAsync(long id, PreventiviObjectServiceDto model);
        public Task<bool> DeletePreventiviObjectServiceAsync(long id);

        #region Functions
        public Task<bool> ChangeOrderPreventiviObjectServiceAsync(List<PreventiviObjectServiceDto> model);
        #endregion
        #endregion

        #region Garbages
        public Task<PageResponse<PreventiviGarbageDto>> GetPreventiviGarbagesAsync(PageRequest request);
        public Task<PreventiviGarbageDto> GetPreventiviGarbageByIdAsync(long id);
        public Task<long> CreatePreventiviGarbageAsync(PreventiviGarbageDto model);
        public Task<long> UpdatePreventiviGarbageAsync(long id, PreventiviGarbageDto model);
        public Task<bool> DeletePreventiviGarbageAsync(long id);
        #endregion

        #region ServiceNoteTemplates
        public Task<PageResponse<PreventiviServiceNoteTemplateDto>> GetPreventiviServiceNoteTemplatesAsync(PageRequest request);
        public Task<PreventiviServiceNoteTemplateDto> GetPreventiviServiceNoteTemplateByIdAsync(long id);
        public Task<long> CreatePreventiviServiceNoteTemplateAsync(PreventiviServiceNoteTemplateDto model);
        public Task<long> UpdatePreventiviServiceNoteTemplateAsync(long id, PreventiviServiceNoteTemplateDto model);
        public Task<bool> DeletePreventiviServiceNoteTemplateAsync(long id);
        #endregion

        #region ConditionTemplates
        public Task<PageResponse<PreventiviConditionTemplateDto>> GetPreventiviConditionTemplatesAsync(PageRequest request);
        public Task<PreventiviConditionTemplateDto> GetPreventiviConditionTemplateByIdAsync(long id);
        public Task<long> CreatePreventiviConditionTemplateAsync(PreventiviConditionTemplateDto model);
        public Task<long> UpdatePreventiviConditionTemplateAsync(long id, PreventiviConditionTemplateDto model);
        public Task<bool> DeletePreventiviConditionTemplateAsync(long id);
        #endregion

        #region ObjectPeriods
        public Task<PageResponse<PreventiviObjectPeriodDto>> GetPreventiviObjectPeriodsAsync(PageRequest request);
        public Task<PreventiviObjectPeriodDto> GetPreventiviObjectPeriodByIdAsync(long id);
        public Task<long> CreatePreventiviObjectPeriodAsync(PreventiviObjectPeriodDto model);
        public Task<long> UpdatePreventiviObjectPeriodAsync(long id, PreventiviObjectPeriodDto model);
        public Task<bool> DeletePreventiviObjectPeriodAsync(long id);
        #endregion

        #region ObjectPayouts
        public Task<PageResponse<PreventiviObjectPayoutDto>> GetPreventiviObjectPayoutsAsync(PageRequest request);
        public Task<PreventiviObjectPayoutDto> GetPreventiviObjectPayoutByIdAsync(long id);
        public Task<long> CreatePreventiviObjectPayoutAsync(PreventiviObjectPayoutDto model);
        public Task<long> UpdatePreventiviObjectPayoutAsync(long id, PreventiviObjectPayoutDto model);
        public Task<bool> DeletePreventiviObjectPayoutAsync(long id);
        #endregion

        #region ObjectConditions
        public Task<PageResponse<PreventiviObjectConditionDto>> GetPreventiviObjectConditionsAsync(PageRequest request);
        public Task<PreventiviObjectConditionDto> GetPreventiviObjectConditionByIdAsync(long id);
        public Task<long> CreatePreventiviObjectConditionAsync(PreventiviObjectConditionDto model);
        public Task<long> UpdatePreventiviObjectConditionAsync(long id, PreventiviObjectConditionDto model);
        public Task<bool> DeletePreventiviObjectConditionAsync(long id);

        #region Functions
        public Task<bool> ChangeOrderPreventiviObjectConditionAsync(List<PreventiviObjectConditionDto> model);
        #endregion
        #endregion

        #region Producers
        public Task<PageResponse<PreventiviProducerDto>> GetPreventiviProducersAsync(PageRequest request);
        public Task<PreventiviProducerDto> GetPreventiviProducerByIdAsync(long id);
        public Task<long> CreatePreventiviProducerAsync(PreventiviProducerDto model);
        public Task<long> UpdatePreventiviProducerAsync(long id, PreventiviProducerDto model);
        public Task<bool> DeletePreventiviProducerAsync(long id);
        #endregion

        #region Destinations
        public Task<PageResponse<PreventiviDestinationDto>> GetPreventiviDestinationsAsync(PageRequest request);
        public Task<PreventiviDestinationDto> GetPreventiviDestinationByIdAsync(long id);
        public Task<long> CreatePreventiviDestinationAsync(PreventiviDestinationDto model);
        public Task<long> UpdatePreventiviDestinationAsync(long id, PreventiviDestinationDto model);
        public Task<bool> DeletePreventiviDestinationAsync(long id);
        #endregion

        #region Financial
        public Task<double> CheckPreventiviFinancialPositionAsync(string query);
        public Task<bool> RequestPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model);
        public Task<bool> ExecPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model);
        public Task<bool> ExecPreventiviSubjectFinancialLockAsync(PreventiviSubjectFinancialDto model);

        #endregion

        #region ObjectHistory
        public Task<PageResponse<PreventiviObjectHistoryDto>> GetPreventiviObjectHistoriesAsync(PageRequest request);

        public  Task<PreventiviObjectHistoryDto> GetPreventiviObjectHistoryByIdAsync(long id);

        public Task<long> CreatePreventiviObjectHistoryAsync(PreventiviObjectHistoryDto dto);

        public Task<long> UpdatePreventiviObjectHistoryAsync(long id, PreventiviObjectHistoryDto dto);

        public  Task<bool> DeletePreventiviObjectHistoryAsync(long id);
        #endregion

        #region Ismart Documenti
        public Task<PageResponse<ViewGaPreventiviIsmartDocumenti>> GetViewPreventiviIsmartDocumentiAsync(PageRequest request);
        #endregion


    }
}

