using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Reclami;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaReclamiService
    {
        #region GaReclamiMittenti
        Task<ReclamiMittentiDto> GetGaReclamiMittentiAsync(int page = 1, int pageSize = 0);
        Task<ReclamiMittenteDto> GetGaReclamiMittenteByIdAsync(long id);

        Task<long> AddGaReclamiMittenteAsync(ReclamiMittenteDto dto);
        Task<long> UpdateGaReclamiMittenteAsync(ReclamiMittenteDto dto);

        Task<bool> DeleteGaReclamiMittenteAsync(long id);

        #region Functions
        Task<bool> ValidateGaReclamiMittenteAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaReclamiMittenteAsync(long id);
        #endregion

        #endregion

        #region GaReclamiStati
        Task<ReclamiStatiDto> GetGaReclamiStatiAsync(int page = 1, int pageSize = 0);
        Task<ReclamiStatoDto> GetGaReclamiStatoByIdAsync(long id);

        Task<long> AddGaReclamiStatoAsync(ReclamiStatoDto dto);
        Task<long> UpdateGaReclamiStatoAsync(ReclamiStatoDto dto);

        Task<bool> DeleteGaReclamiStatoAsync(long id);

        #region Functions
        Task<bool> ValidateGaReclamiStatoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaReclamiStatoAsync(long id);
        #endregion

        #endregion

        #region GaReclamiTempiRisposte
        Task<ReclamiTempiRisposteDto> GetGaReclamiTempiRisposteAsync(int page = 1, int pageSize = 0);
        Task<ReclamiTempoRispostaDto> GetGaReclamiTempoRispostaByIdAsync(long id);

        Task<long> AddGaReclamiTempoRispostaAsync(ReclamiTempoRispostaDto dto);
        Task<long> UpdateGaReclamiTempoRispostaAsync(ReclamiTempoRispostaDto dto);

        Task<bool> DeleteGaReclamiTempoRispostaAsync(long id);

        #region Functions
        Task<bool> ValidateGaReclamiTempoRispostaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaReclamiTempoRispostaAsync(long id);
        #endregion

        #endregion

        #region GaReclamiTipiAzioni
        Task<ReclamiTipiAzioniDto> GetGaReclamiTipiAzioniAsync(int page = 1, int pageSize = 0);
        Task<ReclamiTipoAzioneDto> GetGaReclamiTipoAzioneByIdAsync(long id);

        Task<long> AddGaReclamiTipoAzioneAsync(ReclamiTipoAzioneDto dto);
        Task<long> UpdateGaReclamiTipoAzioneAsync(ReclamiTipoAzioneDto dto);

        Task<bool> DeleteGaReclamiTipoAzioneAsync(long id);

        #region Functions
        Task<bool> ValidateGaReclamiTipoAzioneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaReclamiTipoAzioneAsync(long id);
        #endregion

        #endregion

        #region GaReclamiTipiOrigini
        Task<ReclamiTipiOriginiDto> GetGaReclamiTipiOriginiAsync(int page = 1, int pageSize = 0);
        Task<ReclamiTipoOrigineDto> GetGaReclamiTipoOrigineByIdAsync(long id);

        Task<long> AddGaReclamiTipoOrigineAsync(ReclamiTipoOrigineDto dto);
        Task<long> UpdateGaReclamiTipoOrigineAsync(ReclamiTipoOrigineDto dto);

        Task<bool> DeleteGaReclamiTipoOrigineAsync(long id);

        #region Functions
        Task<bool> ValidateGaReclamiTipoOrigineAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaReclamiTipoOrigineAsync(long id);
        #endregion

        #endregion

        #region GaReclamiAzioni
        Task<ReclamiAzioniDto> GetGaReclamiAzioniAsync(int page = 1, int pageSize = 0);
        Task<ReclamiAzioneDto> GetGaReclamiAzioneByIdAsync(long id);

        Task<long> AddGaReclamiAzioneAsync(ReclamiAzioneDto dto);
        Task<long> UpdateGaReclamiAzioneAsync(ReclamiAzioneDto dto);

        Task<bool> DeleteGaReclamiAzioneAsync(long id);

        #region Functions
        Task<bool> ValidateGaReclamiAzioneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaReclamiAzioneAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaReclamiAzioni>> GetViewGaReclamiAzioniByReclamoIdAsync(long reclamiDocumentoId);
        #endregion
        #endregion

        #region GaReclamiDocumenti
        Task<ReclamiDocumentiDto> GetGaReclamiDocumentiAsync(int page = 1, int pageSize = 0);
        Task<ReclamiDocumentoDto> GetGaReclamiDocumentoByIdAsync(long id);

        Task<long> AddGaReclamiDocumentoAsync(ReclamiDocumentoDto dto);
        Task<long> UpdateGaReclamiDocumentoAsync(ReclamiDocumentoDto dto);

        Task<bool> DeleteGaReclamiDocumentoAsync(long id);

        #region Functions
        Task<bool> ValidateGaReclamiDocumentoAsync(long id, string oggetto);
        Task<bool> ChangeStatusGaReclamiDocumentoAsync(long id);
        Task<List<int>> GetGaReclamiAnni();
        string CreateAzioni(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaReclamiDocumenti>> GetViewGaReclamiDocumentiAsync();
        Task<List<ViewGaReclamiDocumenti>> ExportGaReclamiDocumentiAsync();
        Task<List<ViewGaReclamiRegistri>> GetGaReclamiRegistriAsync(int anno);

        #endregion

        #endregion
    }
}

