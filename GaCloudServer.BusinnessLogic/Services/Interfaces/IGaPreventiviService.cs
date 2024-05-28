using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
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
        public Task<bool> UpdatePreventiviObjectDetailsAsync(long id, PreventiviObjectDto model);
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

        #region Financial
        public Task<double> CheckPreventiviFinancialPositionAsync(string query);
        public Task<bool> RequestPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model);
        public Task<bool> ExecPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model);
        public Task<bool> ExecPreventiviSubjectFinancialLockAsync(PreventiviSubjectFinancialDto model);

        #endregion


    }
}

