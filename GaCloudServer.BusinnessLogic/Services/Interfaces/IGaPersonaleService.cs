using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPersonaleService
    {
        #region GaPersonaleQualifiche
        Task<PersonaleQualificheDto> GetGaPersonaleQualificheAsync(int page = 1, int pageSize = 0);
        Task<PersonaleQualificaDto> GetGaPersonaleQualificaByIdAsync(long id);

        Task<long> AddGaPersonaleQualificaAsync(PersonaleQualificaDto dto);
        Task<long> UpdateGaPersonaleQualificaAsync(PersonaleQualificaDto dto);

        Task<bool> DeleteGaPersonaleQualificaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleQualificaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleQualificaAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleAssunzioni
        Task<PersonaleAssunzioniDto> GetGaPersonaleAssunzioniAsync(int page = 1, int pageSize = 0);
        Task<PersonaleAssunzioneDto> GetGaPersonaleAssunzioneByIdAsync(long id);

        Task<long> AddGaPersonaleAssunzioneAsync(PersonaleAssunzioneDto dto);
        Task<long> UpdateGaPersonaleAssunzioneAsync(PersonaleAssunzioneDto dto);

        Task<bool> DeleteGaPersonaleAssunzioneAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleAssunzioneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleAssunzioneAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleDipendenti
        Task<PersonaleDipendentiDto> GetGaPersonaleDipendentiAsync(int page = 1, int pageSize = 0);
        Task<PersonaleDipendenteDto> GetGaPersonaleDipendenteByIdAsync(long id);

        Task<long> AddGaPersonaleDipendenteAsync(PersonaleDipendenteDto dto);
        Task<long> UpdateGaPersonaleDipendenteAsync(PersonaleDipendenteDto dto);

        Task<bool> DeleteGaPersonaleDipendenteAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleDipendenteAsync(long id, string userId);
        Task<bool> ChangeStatusGaPersonaleDipendenteAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPersonaleUsersOnDipendenti>> GetViewGaPersonaleUsersOnDipendentiAsync(bool all = true);
        Task<PagedList<ViewGaPersonaleDipendenti>> GetViewGaPersonaleDipendentiByQualificaAndSedeAsync(long qualificaId,long sedeId);
        Task<ViewGaPersonaleDipendenti> GetViewGaPersonaleDipendenteByIdAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleScadenzeDettagli
        Task<PersonaleScadenzeDettagliDto> GetGaPersonaleScadenzeDettagliAsync(int page = 1, int pageSize = 0);
        Task<PersonaleScadenzaDettaglioDto> GetGaPersonaleScadenzaDettaglioByIdAsync(long id);

        Task<long> AddGaPersonaleScadenzaDettaglioAsync(PersonaleScadenzaDettaglioDto dto);
        Task<long> UpdateGaPersonaleScadenzaDettaglioAsync(PersonaleScadenzaDettaglioDto dto);

        Task<bool> DeleteGaPersonaleScadenzaDettaglioAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleScadenzaDettaglioAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleScadenzaDettaglioAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleScadenzeTipi
        Task<PersonaleScadenzeTipiDto> GetGaPersonaleScadenzeTipiAsync(int page = 1, int pageSize = 0);
        Task<PersonaleScadenzaTipoDto> GetGaPersonaleScadenzaTipoByIdAsync(long id);

        Task<long> AddGaPersonaleScadenzaTipoAsync(PersonaleScadenzaTipoDto dto);
        Task<long> UpdateGaPersonaleScadenzaTipoAsync(PersonaleScadenzaTipoDto dto);

        Task<bool> DeleteGaPersonaleScadenzaTipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleScadenzaTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleScadenzaTipoAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleDipendentiScadenze
        Task<PersonaleDipendentiScadenzeDto> GetGaPersonaleDipendentiScadenzeAsync(int page = 1, int pageSize = 0);
        Task<PersonaleDipendenteScadenzaDto> GetGaPersonaleDipendenteScadenzaByIdAsync(long id);

        Task<long> AddGaPersonaleDipendenteScadenzaAsync(PersonaleDipendenteScadenzaDto dto);
        Task<long> UpdateGaPersonaleDipendenteScadenzaAsync(PersonaleDipendenteScadenzaDto dto);

        Task<bool> DeleteGaPersonaleDipendenteScadenzaAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPersonaleDipendenteScadenzaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleDipendenteScadenzaAsync(long id);
        #endregion

        #endregion
    }
}
