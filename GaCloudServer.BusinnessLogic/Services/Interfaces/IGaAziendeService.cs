using GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaAziendeService
    {
        #region GaAziendeListe
        Task<AziendeListeDto> GetGaAziendeListeAsync(int page = 1, int pageSize = 0);
        Task<AziendeListeDto> GetGaAziendeListeByRoleAsync(bool roleAdmin,bool roleFormula);
        Task<AziendeListeDto> GetGaAziendeListeForContactCenterAsync();
        Task<AziendeListaDto> GetGaAziendeListaByIdAsync(long id);

        Task<long> AddGaAziendeListaAsync(AziendeListaDto dto);
        Task<long> UpdateGaAziendeListaAsync(AziendeListaDto dto);

        Task<bool> DeleteGaAziendeListaAsync(long id);

        #region Functions
        Task<bool> ValidateGaAziendeListaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaAziendeListaAsync(long id);
        #endregion

        #endregion
    }
}
