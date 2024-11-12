using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IConsorzioService
    {
        #region ConsorzioCers
        Task<ConsorzioCersDto> GetConsorzioCersAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioCerDto> GetConsorzioCerByIdAsync(long id);

        Task<long> AddConsorzioCerAsync(ConsorzioCerDto dto);
        Task<long> UpdateConsorzioCerAsync(ConsorzioCerDto dto);

        Task<bool> DeleteConsorzioCerAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioCerAsync(long id, string codice, string codiceRaggruppamento);
        Task<bool> ChangeStatusConsorzioCerAsync(long id);
        Task<bool> DuplicateConsorzioCerAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewConsorzioCers>> GetViewConsorzioCersAsync(bool all = true);
        #endregion

        #endregion

        #region ConsorzioSmaltimenti
        Task<ConsorzioSmaltimentiDto> GetConsorzioSmaltimentiAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioSmaltimentoDto> GetConsorzioSmaltimentoByIdAsync(long id);

        Task<long> AddConsorzioSmaltimentoAsync(ConsorzioSmaltimentoDto dto);
        Task<long> UpdateConsorzioSmaltimentoAsync(ConsorzioSmaltimentoDto dto);

        Task<bool> DeleteConsorzioSmaltimentoAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioSmaltimentoAsync(long id, string descrizione);
        Task<bool> ChangeStatusConsorzioSmaltimentoAsync(long id);
        #endregion

        #endregion

        #region ConsorzioComuni
        Task<ConsorzioComuniDto> GetConsorzioComuniAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioComuneDto> GetConsorzioComuneByIdAsync(long id);

        Task<long> AddConsorzioComuneAsync(ConsorzioComuneDto dto);
        Task<long> UpdateConsorzioComuneAsync(ConsorzioComuneDto dto);

        Task<bool> DeleteConsorzioComuneAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioComuneAsync(long id, string descrizione);
        Task<bool> ChangeStatusConsorzioComuneAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewConsorzioComuni>> GetViewConsorzioComuniAsync(bool all = true);
        #endregion

        #endregion

        #region ConsorzioDestinatari
        Task<ConsorzioDestinatariDto> GetConsorzioDestinatariAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioDestinatarioDto> GetConsorzioDestinatarioByIdAsync(long id);

        Task<long> AddConsorzioDestinatarioAsync(ConsorzioDestinatarioDto dto);
        Task<long> UpdateConsorzioDestinatarioAsync(ConsorzioDestinatarioDto dto);

        Task<bool> DeleteConsorzioDestinatarioAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioDestinatarioAsync(long id, string cfPiva, string indirizzo);
        Task<PercentValidateDto> ValidatePercentConsorzioDestinatarioAsync(long id, string cfPiva, string indirizzo, string ragSo, long comuneId);
        Task<PercentValidateDto> ValidatePercentConsorzioDestinatarioV2Async(long id, string cfPiva, string indirizzo, string ragSo, long comuneId);
        Task<bool> ChangeStatusConsorzioDestinatarioAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewConsorzioDestinatari>> GetViewConsorzioDestinatariAsync(bool all = true);
        #endregion

        #endregion

        #region ConsorzioProduttori
        Task<ConsorzioProduttoriDto> GetConsorzioProduttoriAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioProduttoreDto> GetConsorzioProduttoreByIdAsync(long id);

        Task<long> AddConsorzioProduttoreAsync(ConsorzioProduttoreDto dto);
        Task<long> UpdateConsorzioProduttoreAsync(ConsorzioProduttoreDto dto);

        Task<bool> DeleteConsorzioProduttoreAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioProduttoreAsync(long id, string cfPiva, string indirizzo);
        Task<PercentValidateDto> ValidatePercentConsorzioProduttoreAsync(long id, string cfPiva, string indirizzo,string ragSo,long comuneId);
        Task<PercentValidateDto> ValidatePercentConsorzioProduttoreV2Async(long id, string cfPiva, string indirizzo,string ragSo,long comuneId);
        Task<bool> ChangeStatusConsorzioProduttoreAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewConsorzioProduttori>> GetViewConsorzioProduttoriAsync(bool all = true);
        #endregion

        #endregion

        #region ConsorzioTrasportatori
        Task<ConsorzioTrasportatoriDto> GetConsorzioTrasportatoriAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioTrasportatoreDto> GetConsorzioTrasportatoreByIdAsync(long id);

        Task<long> AddConsorzioTrasportatoreAsync(ConsorzioTrasportatoreDto dto);
        Task<long> UpdateConsorzioTrasportatoreAsync(ConsorzioTrasportatoreDto dto);

        Task<bool> DeleteConsorzioTrasportatoreAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioTrasportatoreAsync(long id, string cfPiva, string indirizzo);
        Task<PercentValidateDto> ValidatePercentConsorzioTrasportatoreAsync(long id, string cfPiva, string indirizzo, string ragSo, long comuneId);
        Task<PercentValidateDto> ValidatePercentConsorzioTrasportatoreV2Async(long id, string cfPiva, string indirizzo, string ragSo, long comuneId);
        Task<bool> ChangeStatusConsorzioTrasportatoreAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewConsorzioTrasportatori>> GetViewConsorzioTrasportatoriAsync(bool all = true);
        #endregion

        #endregion

        #region ConsorzioRegistrazioni
        Task<ConsorzioRegistrazioniDto> GetConsorzioRegistrazioniAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioRegistrazioneDto> GetConsorzioRegistrazioneByIdAsync(long id);

        Task<long> AddConsorzioRegistrazioneAsync(ConsorzioRegistrazioneDto dto);
        Task<ConsorzioRegistrazioniDto> AddRangeConsorzioRegistrazioneAsync(ConsorzioRegistrazioniDto dto);

        Task<long> UpdateConsorzioRegistrazioneAsync(ConsorzioRegistrazioneDto dto);

        Task<bool> DeleteConsorzioRegistrazioneAsync(long id);

        #region Functions
        Task<PercentValidateDto> ValidateConsorzioRegistrazioneAsync(ConsorzioRegistrazioneDto dto);
        Task<bool> ChangeStatusConsorzioRegistrazioneAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioniAsync(bool all = true);
        Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioneByRolesAsync(string roles);
        Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioniByFilterAsync(long id, string roles);
        PagedList<ViewConsorzioRegistrazioni> GetViewConsorzioRegistrazioniQueryable(GridOperationsModel filterParams);
        PagedList<ViewConsorzioRegistrazioni> GetViewConsorzioRegistrazioniByRolesQueryable(GridOperationsModel filterParams, string[]? roles);
        Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioniQueryableByDateAsync(DateTime dateStart, DateTime dateEnd);
        #endregion

        #endregion

        #region ConsorzioRegistrazioniAllegati
        Task<ConsorzioRegistrazioniAllegatiDto> GetConsorzioRegistrazioniAllegatiAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioRegistrazioneAllegatoDto> GetConsorzioRegistrazioneAllegatoByIdAsync(long id);
        Task<ConsorzioRegistrazioniAllegatiDto> GetConsorzioRegistrazioniAllegatiByRegistrazioneIdAsync(long consorzioRegistrazioneId);

        Task<long> AddConsorzioRegistrazioneAllegatoAsync(ConsorzioRegistrazioneAllegatoDto dto);
        Task<long> UpdateConsorzioRegistrazioneAllegatoAsync(ConsorzioRegistrazioneAllegatoDto dto);

        Task<bool> DeleteConsorzioRegistrazioneAllegatoAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioRegistrazioneAllegatoAsync(long id, string descrizione);
        Task<bool> ChangeStatusConsorzioRegistrazioneAllegatoAsync(long id);
        #endregion

        #endregion

        #region ConsorzioPeriodi
        Task<ConsorzioPeriodiDto> GetConsorzioPeriodiAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioPeriodoDto> GetConsorzioPeriodoByIdAsync(long id);

        Task<long> AddConsorzioPeriodoAsync(ConsorzioPeriodoDto dto);
        Task<long> UpdateConsorzioPeriodoAsync(ConsorzioPeriodoDto dto);

        Task<bool> DeleteConsorzioPeriodoAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioPeriodoAsync(long id, string descrizione);
        Task<bool> ChangeStatusConsorzioPeriodoAsync(long id);
        #endregion

        #endregion

        #region ConsorzioOperazioni
        Task<ConsorzioOperazioniDto> GetConsorzioOperazioniAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioOperazioneDto> GetConsorzioOperazioneByIdAsync(long id);

        Task<long> AddConsorzioOperazioneAsync(ConsorzioOperazioneDto dto);
        Task<long> UpdateConsorzioOperazioneAsync(ConsorzioOperazioneDto dto);

        Task<bool> DeleteConsorzioOperazioneAsync(long id);

        #region Functions
        Task<bool> ValidateConsorzioOperazioneAsync(long id, string descrizione);
        Task<bool> ChangeStatusConsorzioOperazioneAsync(long id);
        #endregion

        #endregion

        #region ConsorzioImportsTasks
        Task<ConsorzioImportsTasksDto> GetConsorzioImportsTasksAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioImportTaskDto> GetConsorzioImportTaskByIdAsync(long id);
        Task<ConsorzioImportTaskDto> GetConsorzioImportTaskByTaskIdAsync(string taskId);

        Task<long> AddConsorzioImportTaskAsync(ConsorzioImportTaskDto dto);
        Task<long> UpdateConsorzioImportTaskAsync(ConsorzioImportTaskDto dto);
        Task<bool> DeleteConsorzioImportTaskByTaskIdAsync(string taskId);

        #region Functions
        Task<string> GetConsorzioImportTaskLogByTaskId(long id);
        Task<bool> SetConsorzioImportTaskDeletedAsync(string taskId);
        #endregion

        #region Views
        Task<PagedList<ViewConsorzioImportsTasks>> GetViewConsorzioImportsTasksAsync(bool all = true);
        #endregion

        #endregion

        #region ConsorzioComuniDemografie
        Task<ConsorzioComuniDemografieDto> GetConsorzioComuniDemografieAsync(int page = 1, int pageSize = 0);
        Task<ConsorzioComuneDemografiaDto> GetConsorzioComuneDemografiaByIdAsync(long id);

        Task<long> AddConsorzioComuneDemografiaAsync(ConsorzioComuneDemografiaDto dto);
        Task<long> UpdateConsorzioComuneDemografiaAsync(ConsorzioComuneDemografiaDto dto);

        Task<bool> DeleteConsorzioComuneDemografiaAsync(long id);

        #region Views
        Task<PagedList<ViewConsorzioComuniDemografie>> GetViewConsorzioComuniDemografieAsync();
        #endregion

        #endregion
    }
}
