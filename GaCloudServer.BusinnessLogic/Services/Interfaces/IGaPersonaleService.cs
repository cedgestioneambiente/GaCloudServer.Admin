using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;

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

        #endregion
    }
}
