using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using static GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder.CustomEcoFinderDto;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPrevisioService
    {

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
