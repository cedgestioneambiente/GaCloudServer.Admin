using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System.Threading.Tasks;

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

        #region GaPersonaleScadenze
        Task<PersonaleScadenzeDto> GetGaPersonaleScadenzeByDipendenteIdAsync(long personaleDipendenteId);
        Task<PersonaleScadenzaDto> GetGaPersonaleScadenzaByIdAsync(long id);

        Task<long> AddGaPersonaleScadenzaAsync(PersonaleScadenzaDto dto);
        Task<long> UpdateGaPersonaleScadenzaAsync(PersonaleScadenzaDto dto);

        Task<bool> DeleteGaPersonaleScadenzaAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPersonaleScadenzaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleScadenzaAsync(long id);

        Task<PagedList<ViewGaPersonaleScadenziario>> ExportGaPersonaleScadenziarioByIdsAsync(long[] ids);
        #endregion

        #region Views
        Task<PagedList<ViewGaPersonaleScadenze>> GetViewGaPersonaleScadenzeByDipendenteIdAsync(long dipendenteId);
        Task<PagedList<ViewGaPersonaleScadenziario>> GetViewGaPersonaleScadenziarioAsync();
        #endregion

        #endregion

        #region GaPersonaleSanzioniMotivi
        Task<PersonaleSanzioniMotiviDto> GetGaPersonaleSanzioniMotiviAsync(int page = 1, int pageSize = 0);
        Task<PersonaleSanzioneMotivoDto> GetGaPersonaleSanzioneMotivoByIdAsync(long id);

        Task<long> AddGaPersonaleSanzioneMotivoAsync(PersonaleSanzioneMotivoDto dto);
        Task<long> UpdateGaPersonaleSanzioneMotivoAsync(PersonaleSanzioneMotivoDto dto);

        Task<bool> DeleteGaPersonaleSanzioneMotivoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleSanzioneMotivoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleSanzioneMotivoAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleSanzioniDescrizioni
        Task<PersonaleSanzioniDescrizioniDto> GetGaPersonaleSanzioniDescrizioniAsync(int page = 1, int pageSize = 0);
        Task<PersonaleSanzioneDescrizioneDto> GetGaPersonaleSanzioneDescrizioneByIdAsync(long id);

        Task<long> AddGaPersonaleSanzioneDescrizioneAsync(PersonaleSanzioneDescrizioneDto dto);
        Task<long> UpdateGaPersonaleSanzioneDescrizioneAsync(PersonaleSanzioneDescrizioneDto dto);

        Task<bool> DeleteGaPersonaleSanzioneDescrizioneAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleSanzioneDescrizioneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleSanzioneDescrizioneAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleSanzioni
        Task<PersonaleSanzioniDto> GetGaPersonaleSanzioniAsync(int page = 1, int pageSize = 0);
        Task<PersonaleSanzioneDto> GetGaPersonaleSanzioneByIdAsync(long id);

        Task<long> AddGaPersonaleSanzioneAsync(PersonaleSanzioneDto dto);
        Task<long> UpdateGaPersonaleSanzioneAsync(PersonaleSanzioneDto dto);

        Task<bool> DeleteGaPersonaleSanzioneAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleSanzioneAsync(long id, long personaleDipendenteId, long personaleSanzioneMotivoId, long personaleSanzioneDescrizioneId);
        Task<bool> ChangeStatusGaPersonaleSanzioneAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPersonaleSanzioni>> GetViewGaPersonaleSanzioniByDipendenteIdAsync(long dipendenteId);
        #endregion

        #endregion

        #region GaPersonaleAbilitazioniTipi
        Task<PersonaleAbilitazioniTipiDto> GetGaPersonaleAbilitazioniTipiAsync(int page = 1, int pageSize = 0);
        Task<PersonaleAbilitazioneTipoDto> GetGaPersonaleAbilitazioneTipoByIdAsync(long id);

        Task<long> AddGaPersonaleAbilitazioneTipoAsync(PersonaleAbilitazioneTipoDto dto);
        Task<long> UpdateGaPersonaleAbilitazioneTipoAsync(PersonaleAbilitazioneTipoDto dto);

        Task<bool> DeleteGaPersonaleAbilitazioneTipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleAbilitazioneTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleAbilitazioneTipoAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleAbilitazioni
        Task<PersonaleAbilitazioniDto> GetGaPersonaleAbilitazioniAsync(int page = 1, int pageSize = 0);
        Task<PersonaleAbilitazioneDto> GetGaPersonaleAbilitazioneByIdAsync(long id);

        Task<long> AddGaPersonaleAbilitazioneAsync(PersonaleAbilitazioneDto dto);
        Task<long> UpdateGaPersonaleAbilitazioneAsync(PersonaleAbilitazioneDto dto);

        Task<bool> DeleteGaPersonaleAbilitazioneAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPersonaleAbilitazioneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleAbilitazioneAsync(long id);
        Task<PagedList<ViewGaPersonaleScadenziarioAbilitazioni>> ExportGaPersonaleScadenziarioAbilitazioniByIdsAsync(long[] ids);

        #region Views
        Task<PagedList<ViewGaPersonaleAbilitazioni>> GetViewGaPersonaleAbilitazioniByDipendenteIdAsync(long dipendenteId);
        Task<PagedList<ViewGaPersonaleScadenziarioAbilitazioni>> GetViewGaPersonaleScadenziarioAbilitazioniAsync();
        #endregion
        #endregion

        #endregion

        #region GaPersonaleRetributiviTipi
        Task<PersonaleRetributiviTipiDto> GetGaPersonaleRetributiviTipiAsync(int page = 1, int pageSize = 0);
        Task<PersonaleRetributivoTipoDto> GetGaPersonaleRetributivoTipoByIdAsync(long id);

        Task<long> AddGaPersonaleRetributivoTipoAsync(PersonaleRetributivoTipoDto dto);
        Task<long> UpdateGaPersonaleRetributivoTipoAsync(PersonaleRetributivoTipoDto dto);

        Task<bool> DeleteGaPersonaleRetributivoTipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleRetributivoTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleRetributivoTipoAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleRetributivi
        Task<PersonaleRetributiviDto> GetGaPersonaleRetributiviAsync(int page = 1, int pageSize = 0);
        Task<PersonaleRetributivoDto> GetGaPersonaleRetributivoByIdAsync(long id);

        Task<long> AddGaPersonaleRetributivoAsync(PersonaleRetributivoDto dto);
        Task<long> UpdateGaPersonaleRetributivoAsync(PersonaleRetributivoDto dto);

        Task<bool> DeleteGaPersonaleRetributivoAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPersonaleRetributivoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleRetributivoAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPersonaleRetributivi>> GetViewGaPersonaleRetributiviByDipendenteIdAsync(long dipendenteId);
        #endregion

        #endregion

        #region GaPersonaleSchedeConsegne
        Task<PersonaleSchedeConsegneDto> GetGaPersonaleSchedeConsegneAsync(long personaleDipendenteId);
        Task<PersonaleSchedaConsegnaDto> GetGaPersonaleSchedaConsegnaByIdAsync(long id);

        Task<long> AddGaPersonaleSchedaConsegnaAsync(PersonaleSchedaConsegnaDto dto);
        Task<long> UpdateGaPersonaleSchedaConsegnaAsync(PersonaleSchedaConsegnaDto dto);

        Task<bool> DeleteGaPersonaleSchedaConsegnaAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPersonaleSchedaConsegnaAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaPersonaleSchedaConsegnaAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPersonaleSchedeConsegne>> GetViewGaPersonaleRiepilogoConsegneAsync();
        #endregion

        #endregion

        #region GaPersonaleSchedeConsegneDettagli
        Task<PersonaleSchedeConsegneDettagliDto> GetGaPersonaleSchedeConsegneDettagliAsync(int page = 1, int pageSize = 0);
        Task<PersonaleSchedaConsegnaDettaglioDto> GetGaPersonaleSchedaConsegnaDettaglioByIdAsync(long id);

        Task<long> AddGaPersonaleSchedaConsegnaDettaglioAsync(PersonaleSchedaConsegnaDettaglioDto dto);
        Task<long> UpdateGaPersonaleSchedaConsegnaDettaglioAsync(PersonaleSchedaConsegnaDettaglioDto dto);

        Task<bool> DeleteGaPersonaleSchedaConsegnaDettaglioAsync(long id);

        #region Functions
        //Task<bool> ValidateGaPersonaleSchedaConsegnaDettaglioAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaPersonaleSchedaConsegnaDettaglioAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPersonaleNuoveSchede>> GetViewGaPersonaleNuoveSchedeAsync();
        Task<PagedList<ViewGaPersonaleSchedeConsegne>> GetViewGaPersonaleSchedeConsegneAsync(long schedaId);
        Task<PagedList<ViewGaPersonaleSchedeConsegne>> GetViewGaPersonaleSchedeConsegneByDipendenteAsync(long personaleDipendenteId);
        #endregion

        #endregion

        #region GaPersonaleArticoliModelli
        Task<PersonaleArticoliModelliDto> GetGaPersonaleArticoliModelliAsync(int page = 1, int pageSize = 0);
        Task<PersonaleArticoloModelloDto> GetGaPersonaleArticoloModelloByIdAsync(long id);

        Task<long> AddGaPersonaleArticoloModelloAsync(PersonaleArticoloModelloDto dto);
        Task<long> UpdateGaPersonaleArticoloModelloAsync(PersonaleArticoloModelloDto dto);

        Task<bool> DeleteGaPersonaleArticoloModelloAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleArticoloModelloAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleArticoloModelloAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleArticoliTipologie
        Task<PersonaleArticoliTipologieDto> GetGaPersonaleArticoliTipologieAsync(int page = 1, int pageSize = 0);
        Task<PersonaleArticoloTipologiaDto> GetGaPersonaleArticoloTipologiaByIdAsync(long id);

        Task<long> AddGaPersonaleArticoloTipologiaAsync(PersonaleArticoloTipologiaDto dto);
        Task<long> UpdateGaPersonaleArticoloTipologiaAsync(PersonaleArticoloTipologiaDto dto);

        Task<bool> DeleteGaPersonaleArticoloTipologiaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleArticoloTipologiaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPersonaleArticoloTipologiaAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleArticoliDpis
        Task<PersonaleArticoliDpisDto> GetGaPersonaleArticoliDpisAsync(int page = 1, int pageSize = 0);
        Task<PersonaleArticoloDpiDto> GetGaPersonaleArticoloDpiByIdAsync(long id);

        Task<long> AddGaPersonaleArticoloDpiAsync(PersonaleArticoloDpiDto dto);
        Task<long> UpdateGaPersonaleArticoloDpiAsync(PersonaleArticoloDpiDto dto);

        Task<bool> DeleteGaPersonaleArticoloDpiAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleArticoloDpiAsync(long id, string descrizione, string caratteristiche);
        Task<bool> ChangeStatusGaPersonaleArticoloDpiAsync(long id);
        #endregion

        #endregion

        #region GaPersonaleArticoli
        Task<PersonaleArticoliDto> GetGaPersonaleArticoliAsync(int page = 1, int pageSize = 0);
        Task<PersonaleArticoloDto> GetGaPersonaleArticoloByIdAsync(long id);

        Task<long> AddGaPersonaleArticoloAsync(PersonaleArticoloDto dto);
        Task<long> UpdateGaPersonaleArticoloAsync(PersonaleArticoloDto dto);

        Task<bool> DeleteGaPersonaleArticoloAsync(long id);

        #region Functions
        Task<bool> ValidateGaPersonaleArticoloAsync(long id, long personaleArticoloModelloId, long personaleArticoloTipologiaId, long personaleArticoloDpiId);
        Task<bool> ChangeStatusGaPersonaleArticoloAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPersonaleArticoli>> GetViewGaPersonaleArticoliAsync();
        #endregion
        #endregion
    }
}