using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni;
using GaCloudServer.BusinnessLogic.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IEcSegnalazioniService
    {
        #region EcSegnalazioniTipi
        Task<SegnalazioniTipiDto> GetEcSegnalazioniTipiAsync(int page = 1, int pageSize = 0);
        Task<SegnalazioniTipoDto> GetEcSegnalazioniTipoByIdAsync(long id);

        Task<long> AddEcSegnalazioniTipoAsync(SegnalazioniTipoDto dto);
        Task<long> UpdateEcSegnalazioniTipoAsync(SegnalazioniTipoDto dto);

        Task<bool> DeleteEcSegnalazioniTipoAsync(long id);

        #region Functions
        Task<bool> ValidateEcSegnalazioniTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusEcSegnalazioniTipoAsync(long id);
        #endregion

        #endregion

        #region EcSegnalazioniStati
        Task<SegnalazioniStatiDto> GetEcSegnalazioniStatiAsync(int page = 1, int pageSize = 0);
        Task<SegnalazioniStatoDto> GetEcSegnalazioniStatoByIdAsync(long id);

        Task<long> AddEcSegnalazioniStatoAsync(SegnalazioniStatoDto dto);
        Task<long> UpdateEcSegnalazioniStatoAsync(SegnalazioniStatoDto dto);

        Task<bool> DeleteEcSegnalazioniStatoAsync(long id);

        #region Functions
        Task<bool> ValidateEcSegnalazioniStatoAsync(long id, string descrizione);
        Task<bool> ChangeStatusEcSegnalazioniStatoAsync(long id);
        #endregion

        #endregion

        #region EcSegnalazioniAllegati
        Task<SegnalazioniAllegatoDto> GetEcSegnalazioneAllegatoBySegnalazioneIdAsync(long segnalazioniDocumentoId);

        Task<long> AddEcSegnalazioniAllegatoAsync(SegnalazioniAllegatoDto dto);
        //Task<long> UpdateEcSegnalazioniAllegatoAsync(SegnalazioniAllegatoDto dto);

        Task<bool> DeleteEcSegnalazioniAllegatoAsync(long id);

        #region Functions
        //Task<bool> ValidateEcSegnalazioniAllegatoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusEcSegnalazioniAllegatoAsync(long id);
        #endregion

        #endregion

        #region EcSegnalazioniDocumenti
        Task<SegnalazioniDocumentiDto> GetEcSegnalazioniDocumentiAsync(int page = 1, int pageSize = 0);
        Task<SegnalazioniDocumentoDto> GetEcSegnalazioniDocumentoByIdAsync(long id);

        Task<long> AddEcSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto);
        Task<long> UpdateEcSegnalazioniDocumentoAsync(SegnalazioniDocumentoDto dto);

        Task<bool> DeleteEcSegnalazioniDocumentoAsync(long id);

        #region Functions
        Task<long> UpdateEcSegnalazionePhotoAsync(long id, string folder);
        #endregion

        #region Views
        Task<ViewEcSegnalazioniDocumenti> GetViewEcSegnalazioniDocumentoByIdAsync(long id);
        Task<PagedList<ViewEcSegnalazioniDocumenti>> GetViewEcSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "Ec-s-administrator");
        Task<PagedList<ViewEcSegnalazioniDocumenti>> GetViewEcSegnalazioniDocumentiAsync(SegnalazioniDocumentiMode mode, string userId = "Ec-s-administrator", int page = 1, int pageSize = 100);
        #endregion
        #endregion
    }
}
