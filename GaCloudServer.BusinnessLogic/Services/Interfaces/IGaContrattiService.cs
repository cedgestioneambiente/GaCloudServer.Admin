using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaContrattiService
    {
        #region GaContrattiPermessi
        Task<ContrattiPermessiDto> GetGaContrattiPermessiAsync(int page = 1, int pageSize = 0);
        Task<ContrattiPermessoDto> GetGaContrattiPermessoByIdAsync(long id);

        Task<long> AddGaContrattiPermessoAsync(ContrattiPermessoDto dto);
        Task<long> UpdateGaContrattiPermessoAsync(ContrattiPermessoDto dto);

        Task<bool> DeleteGaContrattiPermessoAsync(long id);

        #region Functions
        Task<bool> ValidateGaContrattiPermessoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContrattiPermessoAsync(long id);
        #endregion

        #endregion

        #region GaContrattiServizi
        Task<ContrattiServiziDto> GetGaContrattiServiziAsync(int page = 1, int pageSize = 0);
        Task<ContrattiServizioDto> GetGaContrattiServizioByIdAsync(long id);

        Task<long> AddGaContrattiServizioAsync(ContrattiServizioDto dto);
        Task<long> UpdateGaContrattiServizioAsync(ContrattiServizioDto dto);

        Task<bool> DeleteGaContrattiServizioAsync(long id);

        #region Functions
        Task<bool> ValidateGaContrattiServizioAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContrattiServizioAsync(long id);
        #endregion

        #endregion

        #region GaContrattiTipologie
        Task<ContrattiTipologieDto> GetGaContrattiTipologieAsync(int page = 1, int pageSize = 0);
        Task<ContrattiTipologiaDto> GetGaContrattiTipologiaByIdAsync(long id);

        Task<long> AddGaContrattiTipologiaAsync(ContrattiTipologiaDto dto);
        Task<long> UpdateGaContrattiTipologiaAsync(ContrattiTipologiaDto dto);

        Task<bool> DeleteGaContrattiTipologiaAsync(long id);

        #region Functions
        Task<bool> ValidateGaContrattiTipologiaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContrattiTipologiaAsync(long id);

        #endregion

        #endregion

        #region GaContrattiUtentiOnPermessi

        #region Functions
        Task<bool> UpdateGaContrattiUtenteOnPermessoAsync(string utenteId, long permessoId);
        #endregion

        #region Views
        Task<PagedList<ViewGaContrattiUtentiOnPermessi>> GetViewGaContrattiUtentiOnPermessiAsync(string utenteId);
        #endregion

        #endregion

        #region GaContrattiUtenti

        #region Views
        Task<PagedList<ViewGaContrattiUtenti>> GetViewGaContrattiUtentiAsync(int page = 1, int pageSize = 0);
        #endregion

        #endregion

        #region GaContrattiModalitas
        Task<ContrattiModalitasDto> GetGaContrattiModalitasAsync(int page = 1, int pageSize = 0);
        Task<ContrattiModalitaDto> GetGaContrattiModalitaByIdAsync(long id);

        Task<long> AddGaContrattiModalitaAsync(ContrattiModalitaDto dto);
        Task<long> UpdateGaContrattiModalitaAsync(ContrattiModalitaDto dto);

        Task<bool> DeleteGaContrattiModalitaAsync(long id);

        #region Functions
        Task<bool> ValidateGaContrattiModalitaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContrattiModalitaAsync(long id);

        #endregion

        #endregion

        #region GaContrattiSoggetti
        Task<ContrattiSoggettiDto> GetGaContrattiSoggettiAsync(int page = 1, int pageSize = 0);
        Task<ContrattiSoggettoDto> GetGaContrattiSoggettoByIdAsync(long id);

        Task<long> AddGaContrattiSoggettoAsync(ContrattiSoggettoDto dto);
        Task<long> UpdateGaContrattiSoggettoAsync(ContrattiSoggettoDto dto);

        Task<bool> DeleteGaContrattiSoggettoAsync(long id);

        #region Functions
        Task<bool> ValidateGaContrattiSoggettoAsync(long id, string partitaIva);
        Task<bool> ChangeStatusGaContrattiSoggettoAsync(long id);

        #endregion

        #endregion

        #region GaContrattiDocumenti
        Task<ContrattiDocumentiDto> GetGaContrattiDocumentiByIdAsync(long soggettoId);
        Task<ContrattiDocumentoDto> GetGaContrattiDocumentoByIdAsync(long id);

        Task<long> AddGaContrattiDocumentoAsync(ContrattiDocumentoDto dto);
        Task<long> UpdateGaContrattiDocumentoAsync(ContrattiDocumentoDto dto);

        Task<bool> DeleteGaContrattiDocumentoAsync(long id);

        #region Functions
        Task<bool> ValidateGaContrattiDocumentoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContrattiDocumentoAsync(long id);
        Task<bool> ChangeStatusArchiviatoGaContrattiDocumentoAsync(long id);

        Task<PagedList<ViewGaContrattiDocumentiScadenziario>> ExportGaContrattiDocumentiByIdsAsync(long[] ids);

        #endregion

        #region Views
        Task<PagedList<ViewGaContrattiNumeratori>> GetViewGaContrattiNumeratoriAsync();
        Task<PagedList<ViewGaContrattiDocumenti>> GetViewGaContrattiDocumentiByIdAsync(ContrattiDocumentiRequestDto dto);
        Task<PagedList<ViewGaContrattiDocumenti>> GetViewGaContrattiDocumentiByFilterAsync(long id,string roles,bool archiviato);
        Task<PagedList<ViewGaContrattiDocumentiScadenziario>> GetViewGaContrattiDocumentiScadenziarioByFilterAsync(long id,string roles,string tipologie,bool archiviato, string quickFilter = "");
        Task<PagedList<ViewGaContrattiDocumentiScadenziario>> GetViewGaContrattiDocumentiScadenziarioAsync(bool all = false);
        Task<PagedList<ViewGaContrattiDocumentiList>> GetViewGaContrattiDocumentiListByModeAsync(ContrattiDocumentiListRequestDto dto);
        #endregion

        #region Sp
        //Task<PagedList<SpGaContrattiNumeratore>> GetSpGaContrattiNumeratoreAsync();
        //Task<PagedList<SpGaContrattiPermesso>> GetSpGaContrattiPermessoAsync(ContrattiDocumentiRequestDto dto);
        //Task<PagedList<SpGaContrattiPermessoMode>> GetSpGaContrattiPermessoModeAsync(ContrattiDocumentiListRequestDto dto);
        #endregion
        #endregion

        #region GaContrattiDocumentiAllegati
        Task<ContrattiDocumentiAllegatiDto> GetGaContrattiDocumentiAllegatiByDocumentoIdAsync(long contrattiDocumentoId);
        Task<ContrattiDocumentoAllegatoDto> GetGaContrattiDocumentoAllegatoByIdAsync(long id);

        Task<long> AddGaContrattiDocumentoAllegatoAsync(ContrattiDocumentoAllegatoDto dto);
        Task<long> UpdateGaContrattiDocumentoAllegatoAsync(ContrattiDocumentoAllegatoDto dto);

        Task<bool> DeleteGaContrattiDocumentoAllegatoAsync(long id);

        #region Functions
        Task<bool> ChangeStatusGaContrattiDocumentoAllegatoAsync(long id);

        #endregion
        #endregion
    }
}