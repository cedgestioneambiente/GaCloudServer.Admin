using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Ost.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Ost;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IOstService
    {
        #region OstTickets

        #region Views
        Task<List<int>> GetViewOstTicketsAnniAsync();
        Task<PagedList<ViewOstTickets>> GetViewOstTicketsByAnnoAsync(int anno);
        Task<PagedList<ViewOstTickets>> GetViewOstOpenTicketsByAnnoAsync(int anno);
        Task<OstTicketSummaryDto> GetOstTicketSummaryAsync(int anno);
        Task<OstTicketDistribution> GetOstTicketDistributionAsync(int anno);
        Task<OstTicketDistribution> GetOstTicketSectDistributionAsync(int anno);
        Task<OstTicketStatistics> GetOstTicketStatisticsAsync(int anno);
        #endregion

        #endregion
    }
}
