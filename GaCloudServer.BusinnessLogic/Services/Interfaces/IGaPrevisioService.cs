using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Previsio;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using static GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder.CustomEcoFinderDto;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPrevisioService
    {

        #region PrevisioOdsLetture
        Task<PrevisioOdsLettureDto> GetGaPrevisioOdsLettureAsync(int page = 1, int pageSize = 0);
        Task<PrevisioOdsLetturaDto> GetGaPrevisioOdsLetturaByIdAsync(long id);

        Task<long> AddGaPrevisioOdsLetturaAsync(PrevisioOdsLetturaDto dto);
        Task<long> AddOrUpdateGaPrevisioOdsLetturaAsync(PrevisioOdsLetturaDto dto);
        Task<long> UpdateGaPrevisioOdsLetturaAsync(PrevisioOdsLetturaDto dto);

        Task<bool> DeleteGaPrevisioOdsLetturaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPrevisioOdsLetturaAsync(long id, string descrizione);
        Task<bool> ChangeStatusElaboratoGaPrevisioOdsLetturaAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPrevisioOdsLetture>> GetViewGaPrevisioOdsLettureAsync();
        Task<ViewGaPrevisioOdsLetture> GetViewGaPrevisioOdsLettureByFileNameAsync(string fileName);
        #endregion

        #endregion

        #region PrevisioOdsReport
        Task<PagedList<ViewGaPrevisioOdsReport>> GetViewGaPrevisioOdsReportByDateAsync(DateTime dateStart,DateTime dateEnd);
        #endregion

        #region PrevisioOdsServiziReport
        Task<PagedList<ViewGaPrevisioOdsServiziReport>> GetViewGaPrevisioOdsServiziReportByDateAsync(DateTime dateStart, DateTime dateEnd);
        #endregion

        #region DetailedEventReport
        Task<PagedList<DetailedEventsType>> GetDetailedEventsTypeAsync(string userId,List<EventsType> events);
        #endregion

        #region PrevisioAnomalieLetture
        Task<PrevisioAnomalieLettureDto> GetGaPrevisioAnomalieLettureAsync(int page = 1, int pageSize = 0);
        Task<PrevisioAnomaliaLetturaDto> GetGaPrevisioAnomaliaLetturaByIdAsync(long id);

        Task<long> AddGaPrevisioAnomaliaLetturaAsync(PrevisioAnomaliaLetturaDto dto);
        Task<long> UpdateGaPrevisioAnomaliaLetturaAsync(PrevisioAnomaliaLetturaDto dto);

        Task<bool> DeleteGaPrevisioAnomaliaLetturaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPrevisioAnomaliaLetturaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGestitoGaPrevisioAnomaliaLetturaAsync(long id);
        Task<long> AddOrUpdateGaPrevisioAnomaliaLetturaAsync(DetailedEventsType dto);
        #endregion

        #endregion


    }
}
