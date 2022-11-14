using GaCloudServer.BusinnessLogic.Dtos.Resources.Presenze;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPresenzeService
    {
        //Amministrativi

        #region GaPresenzeStatiRichieste
        Task<PresenzeStatiRichiesteDto> GetGaPresenzeStatiRichiesteAsync(int page = 1, int pageSize = 0);
        Task<PresenzeStatoRichiestaDto> GetGaPresenzeStatoRichiestaByIdAsync(long id);

        Task<long> AddGaPresenzeStatoRichiestaAsync(PresenzeStatoRichiestaDto dto);
        Task<long> UpdateGaPresenzeStatoRichiestaAsync(PresenzeStatoRichiestaDto dto);

        Task<bool> DeleteGaPresenzeStatoRichiestaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeStatoRichiestaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeStatoRichiestaAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeRichieste
        Task<PresenzeRichiesteDto> GetGaPresenzeRichiesteAsync(int page = 1, int pageSize = 0);
        Task<PresenzeRichiestaDto> GetGaPresenzeRichiestaByIdAsync(long id);

        Task<long> AddGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto);
        Task<long> UpdateGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto);

        Task<bool> DeleteGaPresenzeRichiestaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeRichiestaAsync(PresenzeRichiestaDto dto);
        Task<bool> ChangeStatusGaPresenzeRichiestaAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeTipiOre
        Task<PresenzeTipiOreDto> GetGaPresenzeTipiOreAsync(int page = 1, int pageSize = 0);
        Task<PresenzeTipoOraDto> GetGaPresenzeTipoOraByIdAsync(long id);

        Task<long> AddGaPresenzeTipoOraAsync(PresenzeTipoOraDto dto);
        Task<long> UpdateGaPresenzeTipoOraAsync(PresenzeTipoOraDto dto);

        Task<bool> DeleteGaPresenzeTipoOraAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeTipoOraAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeTipoOraAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeResponsabili
        Task<PresenzeResponsabiliDto> GetGaPresenzeResponsabiliAsync(int page = 1, int pageSize = 0);
        Task<PresenzeResponsabileDto> GetGaPresenzeResponsabileByIdAsync(long id);

        Task<long> AddGaPresenzeResponsabileAsync(PresenzeResponsabileDto dto);
        Task<long> UpdateGaPresenzeResponsabileAsync(PresenzeResponsabileDto dto);

        Task<bool> DeleteGaPresenzeResponsabileAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeResponsabileAsync(long id, long personaleDipendenteId);   
        Task<bool> ChangeStatusGaPresenzeResponsabileAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeResponsabiliOnSettori
        Task<long> UpdateGaPresenzeResponsabileOnSettoreAsync(PresenzeResponsabileOnSettoreDto dto);

        #region Functions
        //Task<bool> ValidateGaPresenzeResponsabileOnSettoreAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaPresenzeResponsabileOnSettoreAsync(long id);
        #endregion

        #endregion

        #region GaPresenzeProfili
        Task<PresenzeProfiliDto> GetGaPresenzeProfiliAsync(int page = 1, int pageSize = 0);
        Task<PresenzeProfiloDto> GetGaPresenzeProfiloByIdAsync(long id);

        Task<long> AddGaPresenzeProfiloAsync(PresenzeProfiloDto dto);
        Task<long> UpdateGaPresenzeProfiloAsync(PresenzeProfiloDto dto);

        Task<bool> DeleteGaPresenzeProfiloAsync(long id);

        #region Functions
        Task<bool> ValidateGaPresenzeProfiloAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPresenzeProfiloAsync(long id);
        #endregion

        #endregion

        //Operativi


    }
}
