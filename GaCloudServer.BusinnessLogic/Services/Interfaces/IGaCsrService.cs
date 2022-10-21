using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Csr;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaCsrService
    {
        #region GaCsrCodiciCers
        Task<CsrCodiciCersDto> GetGaCsrCodiciCersAsync(int page = 1, int pageSize = 0);
        Task<CsrCodiceCerDto> GetGaCsrCodiceCerByIdAsync(long id);

        Task<long> AddGaCsrCodiceCerAsync(CsrCodiceCerDto dto);
        Task<long> UpdateGaCsrCodiceCerAsync(CsrCodiceCerDto dto);

        Task<bool> DeleteGaCsrCodiceCerAsync(long id);

        #region Functions
        Task<bool> ValidateGaCsrCodiceCerAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaCsrCodiceCerAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaCsrCodiciCers>> GetViewGaCsrCodiciCersAsync();
        #endregion
        #endregion

        #region GaCsrComuni
        Task<CsrComuniDto> GetGaCsrComuniAsync(int page = 1, int pageSize = 0);
        Task<CsrComuneDto> GetGaCsrComuneByIdAsync(long id);

        Task<long> AddGaCsrComuneAsync(CsrComuneDto dto);
        Task<long> UpdateGaCsrComuneAsync(CsrComuneDto dto);

        Task<bool> DeleteGaCsrComuneAsync(long id);

        #region Functions
        Task<bool> ValidateGaCsrComuneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaCsrComuneAsync(long id);
        #endregion

        #endregion

        #region GaCsrDestinatari
        Task<CsrDestinatariDto> GetGaCsrDestinatariAsync(int page = 1, int pageSize = 0);
        Task<CsrDestinatarioDto> GetGaCsrDestinatarioByIdAsync(long id);

        Task<long> AddGaCsrDestinatarioAsync(CsrDestinatarioDto dto);
        Task<long> UpdateGaCsrDestinatarioAsync(CsrDestinatarioDto dto);

        Task<bool> DeleteGaCsrDestinatarioAsync(long id);

        #region Functions
        Task<bool> ValidateGaCsrDestinatarioAsync(long id, string ragioneSociale);
        Task<bool> ChangeStatusGaCsrDestinatarioAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaCsrDestinatari>> GetViewGaCsrDestinatariAsync();
        #endregion
        #endregion

        #region GaCsrProduttori
        Task<CsrProduttoriDto> GetGaCsrProduttoriAsync(int page = 1, int pageSize = 0);
        Task<CsrProduttoreDto> GetGaCsrProduttoreByIdAsync(long id);

        Task<long> AddGaCsrProduttoreAsync(CsrProduttoreDto dto);
        Task<long> UpdateGaCsrProduttoreAsync(CsrProduttoreDto dto);

        Task<bool> DeleteGaCsrProduttoreAsync(long id);

        #region Functions
        Task<bool> ValidateGaCsrProduttoreAsync(long id, string ragioneSociale);
        Task<bool> ChangeStatusGaCsrProduttoreAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaCsrProduttori>> GetViewGaCsrProduttoriAsync();
        #endregion
        #endregion

        #region GaCsrRegistrazioni
        Task<CsrRegistrazioniDto> GetGaCsrRegistrazioniAsync(int page = 1, int pageSize = 0);
        Task<CsrRegistrazioneDto> GetGaCsrRegistrazioneByIdAsync(long id);

        Task<long> AddGaCsrRegistrazioneAsync(CsrRegistrazioneDto dto);
        Task<long> UpdateGaCsrRegistrazioneAsync(CsrRegistrazioneDto dto);

        Task<bool> DeleteGaCsrRegistrazioneAsync(long id);

        #region Functions
        Task<bool> ChangeStatusGaCsrRegistrazioneAsync(long id);
        Task<List<int>> GetGaCsrRegistrazioniAnniAsync();
        #endregion

        #region Views
        Task<PagedList<ViewGaCsrRegistrazioni>> GetViewGaCsrRegistrazioniAsync();
        Task<List<ViewGaCsrExports>> GetGaCsrExports(int anno, List<int> comuni);
        #endregion
        #endregion

        #region GaCsrRegistrazioniPesi
        Task<CsrRegistrazioniPesiDto> GetGaCsrRegistrazioniPesiAsync(int page = 1, int pageSize = 0);
        Task<CsrRegistrazionePesoDto> GetGaCsrRegistrazionePesoByIdAsync(long id);

        //Task<long> AddGaCsrRegistrazionePesoAsync(CsrRegistrazionePesoDto dto);
        //Task<long> UpdateGaCsrRegistrazionePesoAsync(CsrRegistrazionePesoDto dto);

        //Task<bool> DeleteGaCsrRegistrazionePesoAsync(long id);

        //#region Functions
        //Task<bool> ValidateGaCsrRegistrazionePesoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaCsrRegistrazionePesoAsync(long id);
        //#endregion

        #region Views
        Task<PagedList<ViewGaCsrRegistrazioniPesi>> GetViewGaCsrRegistrazioniPesiByRegistrazioneIdAsync(long registrazioneId);
        #endregion
        #endregion

        #region GaCsrRipartizioniPercentuali
        Task<CsrRipartizioniPercentualiDto> GetGaCsrRipartizioniPercentualiAsync(int page = 1, int pageSize = 0);
        Task<CsrRipartizionePercentualeDto> GetGaCsrRipartizionePercentualeByIdAsync(long id);
        Task<CsrRipartizioniPercentualiDto> GetGaCsrRipartizioniPercentualiByComuneIdAsync(long comuneId);

        Task<long> AddGaCsrRipartizionePercentualeAsync(CsrRipartizionePercentualeDto dto);
        Task<long> UpdateGaCsrRipartizionePercentualeAsync(CsrRipartizionePercentualeDto dto);

        Task<bool> DeleteGaCsrRipartizionePercentualeAsync(long id);

        #region Functions
        Task<bool> ValidateGaCsrRipartizionePercentualeAsync(long id, long comuneId, long produttoreId);
        Task<bool> ChangeStatusGaCsrRipartizionePercentualeAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaCsrRipartizioniPercentuali>> GetViewGaCsrRipartizioniPercentualiByComuneId(long comuneId);
        #endregion
        #endregion

        #region GaCsrTrasportatori
        Task<CsrTrasportatoriDto> GetGaCsrTrasportatoriAsync(int page = 1, int pageSize = 0);
        Task<CsrTrasportatoreDto> GetGaCsrTrasportatoreByIdAsync(long id);

        Task<long> AddGaCsrTrasportatoreAsync(CsrTrasportatoreDto dto);
        Task<long> UpdateGaCsrTrasportatoreAsync(CsrTrasportatoreDto dto);

        Task<bool> DeleteGaCsrTrasportatoreAsync(long id);

        #region Functions
        Task<bool> ValidateGaCsrTrasportatoreAsync(long id, string ragioneSociale);
        Task<bool> ChangeStatusGaCsrTrasportatoreAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaCsrTrasportatori>> GetViewGaCsrTrasportatoriAsync();
        #endregion
        #endregion
    }
}
