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
        Task<long> UpdateGaPrevisioOdsLetturaAsync(PrevisioOdsLetturaDto dto);

        Task<bool> DeleteGaPrevisioOdsLetturaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPrevisioOdsLetturaAsync(long id, string descrizione);
        Task<bool> ChangeStatusElaboratoGaPrevisioOdsLetturaAsync(long id);
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


    }
}
