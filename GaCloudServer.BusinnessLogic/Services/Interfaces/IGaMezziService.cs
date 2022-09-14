using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaMezziService
    {
        #region GaMezziAlimentazioni
        Task<MezziAlimentazioniDto> GetGaMezziAlimentazioniAsync(int page = 1, int pageSize = 0);
        Task<MezziAlimentazioneDto> GetGaMezziAlimentazioneByIdAsync(long id);

        Task<long> AddGaMezziAlimentazioneAsync(MezziAlimentazioneDto dto);
        Task<long> UpdateGaMezziAlimentazioneAsync(MezziAlimentazioneDto dto);

        Task<bool> DeleteGaMezziAlimentazioneAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziAlimentazioneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziAlimentazioneAsync(long id);
        #endregion

        #endregion

        #region GaMezziCantieri
        Task<MezziCantieriDto> GetGaMezziCantieriAsync(int page = 1, int pageSize = 0);
        Task<MezziCantiereDto> GetGaMezziCantiereByIdAsync(long id);

        Task<long> AddGaMezziCantiereAsync(MezziCantiereDto dto);
        Task<long> UpdateGaMezziCantiereAsync(MezziCantiereDto dto);

        Task<bool> DeleteGaMezziCantiereAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziCantiereAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziCantiereAsync(long id);
        #endregion

        #endregion

        #region GaMezziClassi
        Task<MezziClassiDto> GetGaMezziClassiAsync(int page = 1, int pageSize = 0);
        Task<MezziClasseDto> GetGaMezziClasseByIdAsync(long id);

        Task<long> AddGaMezziClasseAsync(MezziClasseDto dto);
        Task<long> UpdateGaMezziClasseAsync(MezziClasseDto dto);

        Task<bool> DeleteGaMezziClasseAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziClasseAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziClasseAsync(long id);
        #endregion

        #endregion

        #region GaMezziPatenti
        Task<MezziPatentiDto> GetGaMezziPatentiAsync(int page = 1, int pageSize = 0);
        Task<MezziPatenteDto> GetGaMezziPatenteByIdAsync(long id);

        Task<long> AddGaMezziPatenteAsync(MezziPatenteDto dto);
        Task<long> UpdateGaMezziPatenteAsync(MezziPatenteDto dto);

        Task<bool> DeleteGaMezziPatenteAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziPatenteAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziPatenteAsync(long id);
        #endregion

        #endregion

        #region GaMezziPeriodiScadenze
        Task<MezziPeriodiScadenzeDto> GetGaMezziPeriodiScadenzeAsync(int page = 1, int pageSize = 0);
        Task<MezziPeriodoScadenzaDto> GetGaMezziPeriodoScadenzaByIdAsync(long id);

        Task<long> AddGaMezziPeriodoScadenzaAsync(MezziPeriodoScadenzaDto dto);
        Task<long> UpdateGaMezziPeriodoScadenzaAsync(MezziPeriodoScadenzaDto dto);

        Task<bool> DeleteGaMezziPeriodoScadenzaAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziPeriodoScadenzaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziPeriodoScadenzaAsync(long id);
        #endregion

        #endregion

        #region GaMezziProprietari
        Task<MezziProprietariDto> GetGaMezziProprietariAsync(int page = 1, int pageSize = 0);
        Task<MezziProprietarioDto> GetGaMezziProprietarioByIdAsync(long id);

        Task<long> AddGaMezziProprietarioAsync(MezziProprietarioDto dto);
        Task<long> UpdateGaMezziProprietarioAsync(MezziProprietarioDto dto);

        Task<bool> DeleteGaMezziProprietarioAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziProprietarioAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziProprietarioAsync(long id);
        #endregion

        #endregion

        #region GaMezziScadenzeTipi
        Task<MezziScadenzeTipiDto> GetGaMezziScadenzeTipiAsync(int page = 1, int pageSize = 0);
        Task<MezziScadenzaTipoDto> GetGaMezziScadenzaTipoByIdAsync(long id);

        Task<long> AddGaMezziScadenzaTipoAsync(MezziScadenzaTipoDto dto);
        Task<long> UpdateGaMezziScadenzaTipoAsync(MezziScadenzaTipoDto dto);

        Task<bool> DeleteGaMezziScadenzaTipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziScadenzaTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziScadenzaTipoAsync(long id);
        #endregion

        #endregion

        #region GaMezziTipi
        Task<MezziTipiDto> GetGaMezziTipiAsync(int page = 1, int pageSize = 0);
        Task<MezziTipoDto> GetGaMezziTipoByIdAsync(long id);

        Task<long> AddGaMezziTipoAsync(MezziTipoDto dto);
        Task<long> UpdateGaMezziTipoAsync(MezziTipoDto dto);

        Task<bool> DeleteGaMezziTipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaMezziTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaMezziTipoAsync(long id);
        #endregion

        #endregion



    }
}
