using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaSegnalazioniService
    {
        #region GaSegnalazioniTipi
        Task<SegnalazioniTipiDto> GetGaSegnalazioniTipiAsync(int page = 1, int pageSize = 0);
        Task<SegnalazioniTipoDto> GetGaSegnalazioniTipoByIdAsync(long id);

        Task<long> AddGaSegnalazioniTipoAsync(SegnalazioniTipoDto dto);
        Task<long> UpdateGaSegnalazioniTipoAsync(SegnalazioniTipoDto dto);

        Task<bool> DeleteGaSegnalazioniTipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaSegnalazioniTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaSegnalazioniTipoAsync(long id);
        #endregion

        #endregion

        #region GaSegnalazioniStati
        Task<SegnalazioniStatiDto> GetGaSegnalazioniStatiAsync(int page = 1, int pageSize = 0);
        Task<SegnalazioniStatoDto> GetGaSegnalazioniStatoByIdAsync(long id);

        Task<long> AddGaSegnalazioniStatoAsync(SegnalazioniStatoDto dto);
        Task<long> UpdateGaSegnalazioniStatoAsync(SegnalazioniStatoDto dto);

        Task<bool> DeleteGaSegnalazioniStatoAsync(long id);

        #region Functions
        Task<bool> ValidateGaSegnalazioniStatoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaSegnalazioniStatoAsync(long id);
        #endregion

        #endregion

        #region GaSegnalazioniFotos
        Task<SegnalazioniFotoDto> GetGaSegnalazioneFotoBySegnalazioneIdAsync(long segnalazioniDocumentoId);

        Task<long> AddGaSegnalazioniFotoAsync(SegnalazioniFotoDto dto);
        //Task<long> UpdateGaSegnalazioniFotoAsync(SegnalazioniFotoDto dto);

        Task<bool> DeleteGaSegnalazioniFotoAsync(long id);

        #region Functions
        //Task<bool> ValidateGaSegnalazioniFotoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaSegnalazioniFotoAsync(long id);
        #endregion

        #endregion

        #region GaSegnalazioniDocumenti
        Task<SegnalazioniDocumentiDto> GetGaSegnalazioniDocumentiAsync(int page = 1, int pageSize = 0);
        Task<SegnalazioniDocumentoDto> GetGaSegnalazioniDocumentoByIdAsync(long id);

        Task<long> AddGaSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto);
        Task<long> UpdateGaSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto);

        Task<bool> DeleteGaSegnalazioniDocumentoAsync(long id);

        #region Functions
        Task<long> UpdateGaSegnalazionePhotoAsync(long id, string folder);
        #endregion

        #region Views
        Task<ViewGaSegnalazioniDocumenti> GetViewGaSegnalazioniDocumentoByIdAsync(long id);
        Task<PagedList<ViewGaSegnalazioniDocumenti>> GetViewGaSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "ga-s-administrator");
        Task<PagedList<ViewGaSegnalazioniDocumenti>> GetViewGaSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "ga-s-administrator", int page = 1, int pageSize = 100);
        #endregion
        #endregion
    }
}
